namespace Wallee.ESign.PersonalAuths
{
    /// <summary>
    /// ������notifyUrl֮��eǩ������ýӿڴ�������
    /// </summary>
    public class EnterpriseAuthCallbackDto
    {
        /// <summary>
        /// ��֯��֤����id
        /// </summary>
        public string FlowId { get; set; } = null!;
        /// <summary>
        /// ��������֤����id���޾���������֤��Ϊnull
        /// </summary>
        public string AgentFlowId { get; set; } = null!;
        /// <summary>
        /// ��֯�˻�id��������֤ʱΪnull
        /// </summary>
        public string AccountId { get; set; } = null!;
        /// <summary>
        /// �������˻�id��������֤ʱΪnull
        /// </summary>
        public string AgentAccountId { get; set; } = null!;
        /// <summary>
        /// ��֤�Ƿ�ɹ�. true - �ɹ�; false - ʧ��
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// ҵ��������Id
        /// </summary>
        public string ContextId { get; set; } = null!;
        /// <summary>
        /// ��֤���У����,���ڴ���eǩ������ҵ��
        /// </summary>
        public string VerifyCode { get; set; } = null!;
    }
}
