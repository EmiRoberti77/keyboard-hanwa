namespace CommaBoard.Store.Interface
{
    public interface ICommaBoardButton
    {
        bool Buffer { get; set; }
        bool ClickAndRelease { get; set; }
        int Id { get; }
        string Name { get; set; }
        bool RequiresNumber { get; set; }
        bool SendData { get; set; }
        string Value { get; set; }
    }
}