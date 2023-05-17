namespace Wallee.ESign.RemoteApi
{
    /// <summary>
    /// 认证请求返回的数据
    /// </summary>
    public class ESignAuthResponseDto
    {
        public int Code { get; set; }
        public string Message { get; set; } = null!;

        public RemoteApiResponseData Data { get; set; } = null!;
    }

    public class RemoteApiResponseData
    {
        public string FlowId { get; set; } = null!;
    }
}
