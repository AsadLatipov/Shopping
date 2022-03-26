namespace Shopping.Domain.Commons
{
    public class ErrorModel
    {
        public ErrorModel(int code, string message)
        {
            Code = code;
            Message = message;
        }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
