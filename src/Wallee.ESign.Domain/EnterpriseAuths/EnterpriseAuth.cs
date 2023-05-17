using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Wallee.ESign.EnterpriseAuths
{
    public class EnterpriseAuth : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        protected EnterpriseAuth() { }
        public EnterpriseAuth(Guid id, Guid personalAuthId) : base(id)
        {
            PersonalAuthId = personalAuthId;
        }
        public Guid PersonalAuthId { get; set; }

        public Guid? TenantId { get; set; }
    }
}
