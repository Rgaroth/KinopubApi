namespace KinopubApi.Exceptions;

public class ClientAuthException : Exception
{
    public ClientAuthException(string message) : base(message) { }
    public ClientAuthException() : base() { }
}