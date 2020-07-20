namespace Common.Interfaces
{
    public interface IImage
    {
        int Id { get; set; }
        Item Item { get; set; }
        int ItemId { get; set; }
    }
}