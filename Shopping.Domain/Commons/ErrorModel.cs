namespace Shopping.Domain.Commons
{
    public class ErrorModel
    {
        public ErrorModel(int? code = null, string message = null)
        {
            Code = code;
            Message = message;
        }
        public int? Code { get; set; }
        public string Message { get; set; }
    }
}
