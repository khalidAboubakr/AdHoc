using System.Web.Mvc;

namespace AdHoc.Shared.Base
{
    public class JsonResponse<T> : JsonResult
    {
        public bool Success { get; set; }
        public T data { get; set; }

    }
}
