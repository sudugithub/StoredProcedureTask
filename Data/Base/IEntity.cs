namespace Data.Base
{
    public interface IEntity
    {
        long Id { get; }
        bool IsNew { get; }
        DateTime? CreatedTime { get; }
    }
}
