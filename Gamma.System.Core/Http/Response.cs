namespace Gamma.System.Core.Http;

public class Response<T>
{
    public bool Success { get; set; } = true;
    public T Data { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
    
}