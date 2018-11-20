namespace ConfigTool.Domain.Entities
{
  public class Tattoo
  {
    public Tattoo(string text, object picture)
    {
      Text = text;
      Picture = picture;
    }

    public string Text { get; }
    public object Picture { get; }
  }
}