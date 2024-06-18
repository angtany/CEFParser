using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CEFParser
{
    public class ConfigOptions
    {
        /// <summary>
        /// The <c>TenantId</c> property represents the
        /// tenant ID of the application.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The <c>AppId</c> property represents the
        /// application ID of the application.
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// The <c>AppSecret</c> property represents the
        /// secret key for the application.
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// The <c>DCRStreamName</c> property represents the
        /// input stream name of the data collection rule.
        /// </summary>
        public string DCRStreamName { get; set; }

        /// <summary>
        /// The <c>CEFRegex</c> property represents the
        /// RegEx pattern to parse the CEF message till the
        /// last pipe character.
        /// </summary>
        public string CEFRegex { get; set; }

        /// <summary>
        /// The <c>MaxRetry</c> property represents the
        /// maximum number to times to retry sending data to
        /// the API before pushing it to Storage Queue.
        /// </summary>
        public int MaxRetry { get; set; } = 0;

        /// <summary>
        /// The <c>APIVersion</c> property represents
        /// the API version for the Custom Logs API.
        /// </summary>
        public string APIVersion { get; set; } = "2021-11-01-preview";

        /// <summary>
        /// The <c>UseCompression</c> property represents the
        /// boolean setting to enable request body compression using Gzip.
        /// </summary>
        public bool UseCompression { get; set; } = true;

        /// <summary>
        /// The <c>EventHubName</c> property represents the
        /// event hub name.
        /// </summary>
        public string EventHubName { get; set; }

        /// <summary>
        /// The <c>RetryTime</c> property represents the
        /// time after which the function tries to retry sending
        /// the data to the API.
        /// </summary>
        public int RetryTime { get; set; } = 0;

        /// <summary>
        /// The client id of the user managed identity
        /// used to send the data to the DCR API.
        /// </summary>
        public string UserManagedIdentityClientId { get; set; }

        /// <summary>
        /// The source of the data.
        /// like ADO, SysLog, GitHub etc.
        /// </summary>
        public SourceType Source { get; set; }

        /// <summary>
        /// ReportItNow APIM key
        /// </summary>
        public string ReportItNowAPIMKey { get; set; }

        /// <summary>
        /// Authorization Scopes
        public string ReportItNowAPIScope { get; set; }

        /// <summary>
        /// ReportItNow Base URI
        public string ReportItNowBaseURI { get; set; }
    }
}
