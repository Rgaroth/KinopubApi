namespace KinopubApi.Results;

public class KinopubResult<T> : IKinopubResult<T>
{
    public bool IsSuccess => string.IsNullOrEmpty(Error);
    public string Error { get; set; }
    public T Data { get; set; }
    
    public IKinopubResult<T> WithError(string error)
    {
        Error = error;
        return this;
    }

    public IKinopubResult<T> WithData(T data)
    {
        Data = data;
        return this;
    }
}