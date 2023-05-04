# dotnet-multi-tenant-configuration

PoC to show configuration working in a multi-tenant environment.

## Usage

1. Send HTTP request to GET `https://localhost:7245/config/email`
2. Confirm global configuration is returned
3. Add a header called `Tenant` with a value of `TenantA`
4. Confirm TenantA configuration is returned
5. Add a header called `Tenant` with a value of `TenantB`
6. Confirm TenantB configuration is returned
7. Add a header called `Tenant` with a value of `TenantC`
8. Confirm global configuration is returned

In a real-world environment, the tenant would come from a claim inside a JWT token or cookie.  However, the principle is the same.
