using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace Wallee.ESign.EnterpriseAuths
{
    public class EnterpriseAuthDto : EntityDto<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
    }
}
