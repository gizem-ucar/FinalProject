using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        //Constructor geçişi.
        public Result(bool success, string message):this(success)
        {
            Message = message;    
            
        }
        public Result(bool success)  //success i set etmeyi buna vereceğiz.
        {
            Success = success;
        }
        //implementasyon
        public bool Success { get; }    

        public string Message { get; }
    }
}
