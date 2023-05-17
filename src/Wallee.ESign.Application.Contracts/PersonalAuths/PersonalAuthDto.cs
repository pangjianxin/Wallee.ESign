using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace Wallee.ESign.PersonalAuths
{
    public class PersonalAuthDto : EntityDto<Guid>, IMultiTenant
    {
        /// <summary>
        /// ϵͳ�û�Id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// �⻧Id
        /// </summary>
        public Guid? TenantId { get; set; }
        /// <summary>
        /// �û���д������
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// �û���д��֤������
        /// </summary>
        public string IdNo { get; set; } = null!;
        /// <summary>
        /// �û���д���ֻ���
        /// </summary>
        public string MobileNo { get; set; } = null!;

        public string FlowId { get; set; } = null!;
    }
}
