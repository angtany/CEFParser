using System;

namespace CEFParser
{
    /// <summary>
    /// Represents a class containing common fields in a built-in Azure Sentinel table.
    /// </summary>
    public abstract class SentinelTable
    {
        public string SourceSystem { get; set; }
        public DateTime TimeGenerated { get; set; }
        public string Type { get; set; }
    }
}