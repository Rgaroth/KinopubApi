namespace KinopubApi.Results;

public interface IKinopubResult<T>
{
    public bool IsSuccess { get; }
    public string Error { get; set; }

    public IKinopubResult<T> WithError(string error);
    public T Data { get; set; }
    public IKinopubResult<T> WithData(T data);
}