namespace AdventureLog_API.Models;

public interface IEntity<TIndex>
{
    TIndex Id { get; set; }
}
