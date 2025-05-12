namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data , string message) : base(data, false , message)
        {            
        }
    }
}
