namespace Shared.Tenancy
{
    public sealed class TenantContext : ITenantContext
    {
        public Guid TenantId { get; init; }

        public string? TenantSlug { get; init; }

        public bool HasTenant => TenantId != Guid.Empty;
    }
}
