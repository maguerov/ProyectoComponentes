using Lw.ApplicationMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Controllers
{
    public class BussinessException : Exception
    {
        public int ExceptionId;

        public ApplicationMessage AppMessage { get; set; }

        public string ExceptionDetails { get; set; }


        public BussinessException()
        {

        }

        public BussinessException(int exceptionId)
        {
            ExceptionId = exceptionId;
        }

        public BussinessException(int exceptionId, Exception innerException)
        {
            ExceptionId = exceptionId;
            ExceptionDetails = innerException.Message;
        }
    }
}