using System.Collections.Generic;
namespace CEFParser
{
    public interface ITableMapper<TableName> where TableName : class
    {
        /// <summary>
        /// Map values from a Dictionary containing keys present in the event log keys
        /// with standard names to properties in a table schema object.
        /// </summary>
        /// <param name="entries">Dictionary containing keys present in the event log.</param>
        /// <returns>Mapped table schema object.</returns>
        TableName Map(Dictionary<string, string> entries);
    }
}
