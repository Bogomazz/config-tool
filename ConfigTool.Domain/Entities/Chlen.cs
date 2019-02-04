namespace ConfigTool.Domain.Entities
{
  public class Chlen : EntityBase
  {
    public Chlen(string owner, int length, bool isHairy, Tattoo tattoo)
    {
      Owner = owner;
      Length = length;
      IsHairy = isHairy;
      Tattoo = tattoo;
    }

    public string Owner { get; }
    public int Length { get; }
    public bool IsHairy { get; }
    public Tattoo Tattoo { get; }
  }
}