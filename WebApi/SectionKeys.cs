namespace WebApi;

public record SectionKeys
{
    public string Global { get; }
    public string Tenant { get; }

    public SectionKeys(string sectionKey, string tenantAlias)
    {
        Global = $"Global:{sectionKey}";
        Tenant = $"{tenantAlias}:{sectionKey}";
    }
}
