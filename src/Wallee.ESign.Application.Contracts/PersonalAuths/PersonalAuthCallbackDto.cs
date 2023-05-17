namespace Wallee.ESign.PersonalAuths
{
    /// <summary>
    /// 当实名认证通过后e签宝会通过异步回调接口返回数据
    /// </summary>
    public class PersonalAuthCallbackDto
    {
        /// <summary>
        /// 个人认证流程id
        /// </summary>
        public string FlowId { get; set; } = null!;
        /// <summary>
        /// 个人账户id，核身认证时为null
        /// </summary>
        public string AccountId { get; set; } = null!;
        /// <summary>
        /// 认证是否成功. true - 成功; false - 失败
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 业务上下文Id
        /// </summary>
        public string ContextId { get; set; } = null!;
        /// <summary>
        /// 认证结果校验码, 用于串联e签宝其他业务
        /// </summary>
        public string Verifycode { get; set; } = null!;
    }
}
