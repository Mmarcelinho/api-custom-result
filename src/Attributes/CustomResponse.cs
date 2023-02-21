using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.WebApi.Controllers.Shared;

namespace AspNetCore.WebApi.Attributes
{
    public class CustomResponse
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
        public class CustomResponseAttribute : ProducesResponseTypeAttribute
        {
            public CustomResponseAttribute(int statusCode) : base(typeof(CustomResult), statusCode) { }
        }
    }

}