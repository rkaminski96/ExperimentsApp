using System;
using System.Net;

namespace ExperimentsApp.API.Exceptions
{
    public class ErrorCode
    {
        public string Message { get; set; }

        public ErrorCode(string message)
        {
            Message = message;
        }
    }
}
