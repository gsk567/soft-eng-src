using System.Text;

namespace DesignPatterns;

public class Kebap
{
    internal Kebap()
    {
    }
    
    public Guid Id { get; internal set; }

    public bool IsSpicy { get; internal set; }

    public bool WithVegitables { get; internal set; }

    public bool WithoutMeat { get; internal set; }
    
    public string CreatorName { get; internal set; }

    public DateTime CreationDate { get; internal set; }

    public override string ToString()
    {
        var result = new StringBuilder();
        var props = this.GetType().GetProperties();
        foreach (var prop in props)
        {
            result.AppendLine($"{prop.Name}: {prop.GetValue(this)}");
        }

        return result.ToString();
    }
}