using System;
using System.Text;

namespace umaStatus.Utilities
{
  public class ClassBuilder
  {
    private StringBuilder stringBuilder;

    public static ClassBuilder Default(string value) => new ClassBuilder(value);


    public ClassBuilder(string value)
    {
      stringBuilder = new StringBuilder();
      stringBuilder.Append(value);
    }

    public ClassBuilder AddValue(string value)
    {
      stringBuilder.Append(value);
      return this;
    }

    public ClassBuilder AddClass(string value)
    {
      stringBuilder.Append(" ").Append(value);
      return this;
    }

    public ClassBuilder AddClass(string value, bool when) => when ? AddClass(value) : this;

    public ClassBuilder AddClass(string value, Func<bool> when ) => AddClass(value, when());

    public string Build() => stringBuilder.ToString().Trim();

    public override string ToString() => Build();
  }
}
