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
        /// 系统用户Id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 租户Id
        /// </summary>
        public Guid? TenantId { get; set; }
        /// <summary>
        /// 用户填写的姓名
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 用户填写的证件号码
        /// </summary>
        public string IdNo { get; set; } = null!;
        /// <summary>
        /// 用户填写的手机号
        /// </summary>
        public string MobileNo { get; set; } = null!;

        public string FlowId { get; set; } = null!;
    }
}
