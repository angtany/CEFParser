using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CEFParser
{
    public class CommonSecurityLogMapper : ITableMapper<CommonSecurityLog>
    {
   

    /// <summary>
    /// Maps CEF keys to CommonSecurityLog column names.
    /// </summary>
    private readonly IReadOnlyDictionary<string, string> map = new Dictionary<string, string>()
        {
            {"act", "DeviceAction"},
            {"app", "ApplicationProtocol"},
            {"cnt", "EventCount"},
            {"deviceVendor", "DeviceVendor"},
            {"deviceProduct", "DeviceProduct"},
            {"sender_sw_version", "DeviceVersion"},
            {"destinationDnsDomain", "DestinationDnsDomain"},
            {"destinationServiceName", "DestinationServiceName"},
            {"destinationTranslatedAddress", "DestinationTranslatedAddress"},
            {"destinationTranslatedPort", "DestinationTranslatedPort"},
            {"deviceDirection", "CommunicationDirection"},
            {"deviceDnsDomain", "DeviceDnsDomain"},
            {"deviceExternalId", "DeviceExternalID"},
            {"deviceFacility", "DeviceFacility"},
            {"deviceInboundInterface", "DeviceInboundInterface"},
            {"deviceNtDomain", "DeviceNtDomain"},
            {"deviceOutboundInterface", "DeviceOutboundInterface"},
            {"devicePayloadId", "DevicePayloadId"},
            {"deviceProcessName", "ProcessName"},
            {"deviceTranslatedAddress", "DeviceTranslatedAddress"},
            {"dhost", "DestinationHostName"},
            {"dmac", "DestinationMacAddress"},
            {"dntdom", "DestinationNTDomain"},
            {"dpid", "DestinationProcessId"},
            {"dpriv", "DestinationUserPrivileges"},
            {"dproc", "DestinationProcessName"},
            {"dpt", "DestinationPort"},
            {"dst", "DestinationIP"},
            {"dtz", "DeviceTimeZone"},
            {"duid", "DestinationUserID"},
            {"duser", "DestinationUserName"},
            {"dvc", "DeviceAddress"},
            {"dvchost", "DeviceName"},
            {"dvcmac", "DeviceMacAddress"},
            {"dvcpid", "ProcessID"},
            {"externalId", "ExternalID"},
            {"fileCreateTime", "FileCreateTime"},
            {"fileHash", "FileHash"},
            {"fileId", "FileID"},
            {"fileModificationTime", "FileModificationTime"},
            {"filePath", "FilePath"},
            {"filePermission", "FilePermission"},
            {"fileType", "FileType"},
            {"fname", "FileName"},
            {"fsize", "FileSize"},
            {"Host", "Computer"},
            {"in", "ReceivedBytes"},
            {"msg", "Message"},
            {"Name", "Activity"},
            {"oldFileCreateTime", "OldFileCreateTime"},
            {"oldFileHash", "OldFileHash"},
            {"oldFileId", "OldFileID"},
            {"oldFileModificationTime", "OldFileModificationTime"},
            {"oldFileName", "OldFileName"},
            {"oldFilePath", "OldFilePath"},
            {"oldFilePermission", "OldFilePermission"},
            {"oldFileSize", "OldFileSize"},
            {"oldFileType", "OldFileType"},
            {"out", "SentBytes"},
            {"Outcome", "Outcome"},
            {"proto", "Protocol"},
            {"request", "RequestURL"},
            {"requestClientApplication", "RequestClientApplication"},
            {"requestContext", "RequestContext"},
            {"requestCookies", "RequestCookies"},
            {"requestMethod", "RequestMethod"},
            {"rt", "ReceiptTime"},
            {"Severity", "LogSeverity"},
            {"shost", "SourceHostName"},
            {"smac", "SourceMacAddress"},
            {"sntdom", "SourceNTDomain"},
            {"sourceDnsDomain", "SourceDnsDomain"},
            {"sourceServiceName", "SourceServiceName"},
            {"sourceTranslatedAddress", "SourceTranslatedAddress"},
            {"sourceTranslatedPort", "SourceTranslatedPort"},
            {"spid", "SourceProcessId"},
            {"spriv", "SourceUserPrivileges"},
            {"sproc", "SourceProcessName"},
            {"spt", "SourcePort"},
            {"src", "SourceIP"},
            {"suid", "SourceUserID"},
            {"suser", "SourceUserName"},
            {"type", "DeviceEventClassID"},
            {"c6a1", "DeviceCustomIPv6Address1"},
            {"c6a1Label", "DeviceCustomIPv6Address1Label"},
            {"c6a2", "DeviceCustomIPv6Address2"},
            {"c6a2Label", "DeviceCustomIPv6Address2Label"},
            {"c6a3", "DeviceCustomIPv6Address3"},
            {"c6a3Label", "DeviceCustomIPv6Address3Label"},
            {"c6a4", "DeviceCustomIPv6Address4"},
            {"c6a4Label", "DeviceCustomIPv6Address4Label"},
            {"cfp1", "DeviceCustomFloatingPoint1"},
            {"cfp1Label", "deviceCustomFloatingPoint1Label"},
            {"cfp2", "DeviceCustomFloatingPoint2"},
            {"cfp2Label", "deviceCustomFloatingPoint2Label"},
            {"cfp3", "DeviceCustomFloatingPoint3"},
            {"cfp3Label", "deviceCustomFloatingPoint3Label"},
            {"cfp4", "DeviceCustomFloatingPoint4"},
            {"cfp4Label", "deviceCustomFloatingPoint4Label"},
            {"cn1", "DeviceCustomNumber1"},
            {"cn1Label", "DeviceCustomNumber1Label"},
            {"cn2", "DeviceCustomNumber2"},
            {"cn2Label", "DeviceCustomNumber2Label"},
            {"cn3", "DeviceCustomNumber3"},
            {"cn3Label", "DeviceCustomNumber3Label"},
            {"cs1", "DeviceCustomString1"},
            {"cs1Label", "DeviceCustomString1Label"},
            {"cs2", "DeviceCustomString2"},
            {"cs2Label", "DeviceCustomString2Label"},
            {"cs3", "DeviceCustomString3"},
            {"cs3Label", "DeviceCustomString3Label"},
            {"cs4", "DeviceCustomString4"},
            {"cs4Label", "DeviceCustomString4Label"},
            {"cs5", "DeviceCustomString5"},
            {"cs5Label", "DeviceCustomString5Label"},
            {"cs6", "DeviceCustomString6"},
            {"cs6Label", "DeviceCustomString6Label"},
            {"flexString1", "FlexString1"},
            {"flexString1Label", "FlexString1Label"},
            {"flexString2", "FlexString2"},
            {"flexString2Label", "FlexString2Label"},
            {"deviceCustomDate1", "DeviceCustomDate1"},
            {"deviceCustomDate1Label", "DeviceCustomDate1Label"},
            {"deviceCustomDate2", "DeviceCustomDate2"},
            {"deviceCustomDate2Label", "DeviceCustomDate2Label"},
            {"flexDate1", "FlexDate1"},
            {"flexDate1Label", "FlexDate1Label"},
            {"flexNumber1", "FlexNumber1"},
            {"flexNumber1Label", "FlexNumber1Label"},
            {"flexNumber2", "FlexNumber2"},
            {"flexNumber2Label", "FlexNumber2Label"},
        };

    public CommonSecurityLogMapper()
        {
        
    }

    public CommonSecurityLog Map(Dictionary<string, string> entries)
    {
        CommonSecurityLog eventLog = new();
        Type type = eventLog.GetType();


        foreach (KeyValuePair<string, string> entry in entries)
        {
            if (entry.Key == "TimeGenerated")
            {
                continue;
            }
            else if (map.ContainsKey(entry.Key))
            {
                string propertyName = map[entry.Key];
                PropertyInfo property = type.GetProperty(propertyName);
                Type valueType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                if (property != null)
                {
                    object value = Convert.ChangeType(entry.Value, valueType);
                    property.SetValue(eventLog, value, null);
                }
                else
                {
                    throw new Exception($"CEF key property not found.The Key is - {entry.Key}");
                }
            }
            else
            {
                if (eventLog.AdditionalExtensions != null)
                {
                    eventLog.AdditionalExtensions += ";";
                }

                eventLog.AdditionalExtensions += $"{entry.Key}={entry.Value}";
            }
        }

        eventLog.SourceSystem = "OpsManager";

        if (eventLog.DeviceAction != null)
            eventLog.SimplifiedDeviceAction = eventLog.DeviceAction;
        return eventLog;
    }
}
}
