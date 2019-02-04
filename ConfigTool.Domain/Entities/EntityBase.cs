namespace ConfigTool.Domain.Entities
{
  public abstract class EntityBase
  {
    public int Id { get; private set; }
    public bool IsNew() => Id == default;
  }
}