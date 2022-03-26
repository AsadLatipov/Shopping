namespace Shopping.Domain.Commons
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public ErrorModel Error { get; set; }
    }
}
