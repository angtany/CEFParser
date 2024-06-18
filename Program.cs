// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Options;

namespace CEFParser
{
    class Program
    {
        static private readonly ITableMapper<CommonSecurityLog> cefMapper = new CommonSecurityLogMapper();
        //static private readonly IOptions<ConfigOptions> options = new ConfigOptions();

        public static void Main(string[] args)
        {

            IMessageParser<CommonSecurityLog> parser = new CEFParser1(cefMapper) ;

            string log = "1273 <14>1 2024-05-08T01:10:31-07:00 tusredrwep52hb - - - - CEF:0|Palo Alto Networks|PAN-OS|10.1.11|end|TRAFFIC|1|rt=May 08 2024 08:10:31 GMT deviceExternalId=013201027985 src=10.226.66.16 dst=10.50.10.50 sourceTranslatedAddress=0.0.0.0 destinationTranslatedAddress=0.0.0.0 cs1Label=Rule cs1=IANOUTER_to_CORPNET_DNS suser= duser= app=dns-base cs3Label=Virtual System cs3=vsys1 cs4Label=Source Zone cs4=IANOUTER cs5Label=Destination Zone cs5=CORPNET deviceInboundInterface=ethernet1/23.21 deviceOutboundInterface=ethernet1/21 cs6Label=LogProfile cs6=Base-LoggingProfile cn1Label=SessionID cn1=781099 cnt=1 spt=42301 dpt=53 sourceTranslatedPort=0 destinationTranslatedPort=0 flexString1Label=Flags flexString1=0x19 proto=udp act=allow flexNumber1Label=Total bytes flexNumber1=180 in=84 out=96 cn2Label=Packets cn2=2 PanOSPacketsReceived=1 PanOSPacketsSent=1 start=$cefformatted-time_generated cn3Label=Elapsed time in seconds cn3=0 cs2Label=URL Category cs2=any externalId=7360463872407464946 reason=aged-out PanOSDGl1=18 PanOSDGl2=0 PanOSDGl3=0 PanOSDGl4=0 PanOSVsysName=FABRIC dvchost=tusredrwep52hb cat=from-policy PanOSActionFlags=0x8000000000000000 PanOSSrcUUID= PanOSDstUUID= PanOSTunnelID=0 PanOSMonitorTag= PanOSParentSessionID=0 PanOSParentStartTime= PanOSTunnelType=N/A";
            CommonSecurityLog parsedLog = parser.Parse(log);

            if ( parsedLog == null)
            {
                throw new Exception("Invalid CEF Format");
            }
            else
            {
                
                Console.WriteLine(parsedLog.DeviceVendor);
            }
            
        }
    }
}