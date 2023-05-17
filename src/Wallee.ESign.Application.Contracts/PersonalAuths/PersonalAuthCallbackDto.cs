namespace Wallee.ESign.PersonalAuths
{
    /// <summary>
    /// ��ʵ����֤ͨ����eǩ����ͨ���첽�ص��ӿڷ�������
    /// </summary>
    public class PersonalAuthCallbackDto
    {
        /// <summary>
        /// ������֤����id
        /// </summary>
        public string FlowId { get; set; } = null!;
        /// <summary>
        /// �����˻�id��������֤ʱΪnull
        /// </summary>
        public string AccountId { get; set; } = null!;
        /// <summary>
        /// ��֤�Ƿ�ɹ�. true - �ɹ�; false - ʧ��
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// ҵ��������Id
        /// </summary>
        public string ContextId { get; set; } = null!;
        /// <summary>
        /// ��֤���У����, ���ڴ���eǩ������ҵ��
        /// </summary>
        public string Verifycode { get; set; } = null!;
    }
}
