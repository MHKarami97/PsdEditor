namespace PsdEditor.Util;

public static class Types
{
    public static IEnumerable<string> PropertiesFromType(object type)
    {
        var t = type.GetType();
        var props = t.GetProperties();

        return props.Select(prp => prp.Name).ToArray();
    }
}