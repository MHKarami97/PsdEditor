namespace PsdEditor;

public class Data
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Difficulty { get; set; }
    public string Location { get; set; }
    public DateTime GoTime { get; set; }
    public DateTime BackTime { get; set; }

    public Dictionary<string, string> ToDictionary()
    {
        var data = GetType().GetProperties()
            .Select(info => (info.Name, Value: info.GetValue(this, null) ?? ""));

        return data
            .ToDictionary(item => item.Name, item => (item.Value is Enum ? item.Value.GetHashCode() : item.Value).ToString() ?? "");
    }
}