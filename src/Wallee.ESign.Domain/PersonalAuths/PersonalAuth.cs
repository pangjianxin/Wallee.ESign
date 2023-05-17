using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Wallee.ESign.PersonalAuths
{
    /// <summary>
    /// 外部的个人用户实名认证
    /// 目前是e签宝
    /// </summary>
    public class PersonalAuth : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        protected PersonalAuth()
        {

        }

        public PersonalAuth(Guid id, Guid userId, string name, string idNo, string mobileNo, string flowId) : base(id)
        {
            UserId = userId;
            Name = name;
            IdNo = idNo;
            MobileNo = mobileNo;
            FlowId = flowId;
        }

        /// <summary>
        /// 系统用户Id
        /// </summary>
        public Guid UserId { get; private set; }
        /// <summary>
        /// 租户Id
        /// </summary>
        public Guid? TenantId { get; private set; }
        /// <summary>
        /// 用户填写的姓名
        /// </summary>
        public string Name { get; private set; } = null!;
        /// <summary>
        /// 用户填写的证件号码
        /// </summary>
        public string IdNo { get; private set; } = null!;
        /// <summary>
        /// 用户填写的手机号
        /// </summary>
        public string MobileNo { get; private set; } = null!;

        public string FlowId { get; private set; } = null!;
    }
}
