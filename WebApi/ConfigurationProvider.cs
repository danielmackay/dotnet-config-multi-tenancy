namespace WebApi;

public class MultiTenantConfigurationProvider
{
    private readonly IConfiguration _configuration;
    private readonly ITenantService _tenantService;

    private readonly Dictionary<Type, string> SectionKeyMap = new Dictionary<Type, string>()
    {
        { typeof(EmailConfig), "Email" }
    };

    public MultiTenantConfigurationProvider(IConfiguration configuration, ITenantService tenantService)
    {
        _configuration = configuration;
        _tenantService = tenantService;
    }

    public T? GetSection<T>() where T : IConfig
    {
        var keys = GetSectionKeys<T>();
        var config = _configuration.GetSection(keys.Tenant).Get<T>();
        if (config != null)
            return config;

        return _configuration.GetSection(keys.Global).Get<T>();
    }

    private SectionKeys GetSectionKeys<T>()
    {
        var sectionKey = SectionKeyMap.GetValueOrDefault(typeof(T));
        var tenantAlias = _tenantService.GetTenantAlias();
        return new SectionKeys(sectionKey!, tenantAlias);
    }
}
