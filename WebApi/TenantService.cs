namespace WebApi;

public class TenantService : ITenantService
{
    private readonly IHttpContextAccessor _httpContextAccessor;


    public TenantService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetTenantAlias()
    {
        _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Tenant", out var tenantAlias);

        return tenantAlias;
    }
}

public interface ITenantService
{
    public string GetTenantAlias();
}