using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspNetCore.WebApi.Extensions
{
    public static class HttpExtensions
    {
        public static bool IsSucess(this HttpStatusCode statusCode) => new HttpResponseMessage(statusCode).IsSuccessStatusCode;
        
    }
}