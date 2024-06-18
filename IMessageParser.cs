namespace CEFParser
{
    /// <summary>
    /// Represents a type used to parse event bodies.
    /// </summary>
    public interface IMessageParser<TableName> where TableName : class
    {
        TableName Parse(string msgBody);
    }

}
