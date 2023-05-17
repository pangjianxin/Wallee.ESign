namespace Wallee.ESign.PersonalAuths
{
    /// <summary>
    /// 当配置notifyUrl之后e签宝会调用接口传入数据
    /// </summary>
    public class EnterpriseAuthCallbackDto
    {
        /// <summary>
        /// 组织认证流程id
        /// </summary>
        public string FlowId { get; set; } = null!;
        /// <summary>
        /// 办理人认证流程id，无经办理人认证是为null
        /// </summary>
        public string AgentFlowId { get; set; } = null!;
        /// <summary>
        /// 组织账户id，核身认证时为null
        /// </summary>
        public string AccountId { get; set; } = null!;
        /// <summary>
        /// 办理人账户id，核身认证时为null
        /// </summary>
        public string AgentAccountId { get; set; } = null!;
        /// <summary>
        /// 认证是否成功. true - 成功; false - 失败
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 业务上下文Id
        /// </summary>
        public string ContextId { get; set; } = null!;
        /// <summary>
        /// 认证结果校验码,用于串联e签宝其他业务
        /// </summary>
        public string VerifyCode { get; set; } = null!;
    }
}
