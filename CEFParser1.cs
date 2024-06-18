using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CEFParser
{
    /// <summary>
    /// Parser for the Cef format.
    /// </summary>
    public class CEFParser1 : IMessageParser<CommonSecurityLog>
    {
        private readonly ITableMapper<CommonSecurityLog> cefMapper;
        private readonly ConfigOptions options;

        public CEFParser1(ITableMapper<CommonSecurityLog> _cefMapper)
        {
            cefMapper = _cefMapper;
        }

        /// <summary>
        /// Parses the CEF event and returns a CommonSecurityLog object.
        /// </summary>
        /// <param name="message">The log to parse.</param>
        /// <returns>Parsed CommonSecurityLog object.</returns>
        ///
        /// The parser works by diving the message body into two parts:
        /// - The message till the last pipe character and can be parsed
        ///   through RegEx.
        /// - the message which contains data in the "<key>=<value>" format.
        public CommonSecurityLog Parse(string message)
        {
            string msgBody = "";
            if (message.StartsWith("{") == false)
            {
                msgBody = message;
            }
            else
            {
                msgBody = JsonConvert.DeserializeObject<ExtractLog>(message).log;
            }
            Dictionary<string, string> entries = new();

            int splitIndex = msgBody[..(msgBody.IndexOf("|rt=") + 1)].LastIndexOf('|');
            if (splitIndex == -1)
            {
                return null;
            }

            string cefString = msgBody[..splitIndex];
            string keyValueMessage = msgBody[(splitIndex + 1)..];

            MatchRegex(cefString, entries);
            if (entries.Count == 0)
            {
                return null;
            }

            ParseKeyValuePairs(keyValueMessage, entries);
            return cefMapper.Map(entries);
        }

        /// <summary>
        /// Parses the key-value pairs from the CEF message.
        /// </summary>
        /// <param name="cefString">The part of event message till the last '|' character.</param>
        /// <param name="entries">The dictionary to add the key-value pairs.</param>
        private void MatchRegex(string cefString, Dictionary<string, string> entries)
        {
            string rgxPattern = "(?<Host>[\\w-._~]+) CEF:0\\|(?<deviceVendor>[\\w\\s]+)\\|(?<deviceProduct>[\\w-\\s]+)\\|(?<sender_sw_version>[\\w.-]+)\\|(?<type>[\\w-]+)\\|(?<Name>[\\w\\d]+)\\|(?<Severity>10|\\d)";
            Regex rg = new(pattern: rgxPattern);
            GroupCollection matches = rg.Match(cefString).Groups;
            if (matches.Count < 1)
            {
                return;
            }

            for (int count = 1; count < matches.Count; count++)
            {
                entries[matches[count].Name] = matches[count].Value;
            }
        }

        /// <summary>
        /// Parses the key-value pairs from the CEF message.
        /// </summary>
        /// <param name="message">The part of CEF message containing key-value pairs.</param>
        /// <param name="entries">The dictionary to populate with key-value pairs.</param>
        private static void ParseKeyValuePairs(string message, Dictionary<string, string> entries)
        {
            string previousKey = "";
            foreach (string pair in message.Split(' '))
            {
                string[] keyValuePair = pair.Split('=');
                if (keyValuePair.Length > 1)
                {
                    string key = keyValuePair[0];
                    string value = keyValuePair[1];
                    for (int i = 2; i < keyValuePair.Length; i++)
                        value += keyValuePair[i];

                    if (value.StartsWith("\\\""))
                        try
                        {
                            entries[key] = Regex.Unescape(value);
                        }
                        catch
                        {
                            entries[key] = value;
                        }
                    else
                        entries[key] = value;
                    previousKey = key;

                }
                else
                {
                    if (pair.EndsWith("\\\""))
                    {
                        try
                        {
                            entries[previousKey] += " " + Regex.Unescape(pair);
                        }
                        catch
                        {
                            entries[previousKey] += " " + pair;
                        }
                    }
                    else
                    {
                        entries[previousKey] += " " + pair;
                    }
                }
            }
        }
    }
}