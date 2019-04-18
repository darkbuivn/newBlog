using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Common.Contant;

namespace Blogs.ViewModels.ApiViewModel
{
    public class ApiViewModel<T>
    {
        public StatusCode ApiStatusCode { get; set; }
        public string ResponseMessage { get; set; }
        public T Data { get; set; }
    }
}