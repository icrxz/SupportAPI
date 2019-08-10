using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportAPI.API
{
    public class BaseAPI : Controller
    {
        protected ActionResult<T> OkResponse<T> (T value)
        {
            return new OkObjectResult(value);
        }

        protected ActionResult BadRequestResponse(Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}
