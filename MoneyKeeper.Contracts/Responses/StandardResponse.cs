using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MoneyKeeper.Contracts.Responses
{
    public class StandardResponse<T>
    {
        public HttpStatusCode Status { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public StandardResponse(HttpStatusCode status, T data = default, string message = null)
        {
            Status = status;
            Data = data;
            Message = message;
        }

        public StandardResponse(T data = default, string message = null)
        {
            Status = HttpStatusCode.OK;
            Data = data;
            Message = message;
        }

        public IActionResult Result
        {
            get
            {
                var result = new ObjectResult(new { Status, Message, Data });
                result.StatusCode = (int)Status;
                return result;
            }
        }
    }
}
