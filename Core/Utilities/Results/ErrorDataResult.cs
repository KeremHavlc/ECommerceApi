﻿namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data , string message) : base(data, false , message) { }
        public ErrorDataResult(string message) : base(default, false, message) { }
    }
}
