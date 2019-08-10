using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportAPI.Data;

namespace SupportAPI.API.User
{
    [Route("api/user")]
    public partial class UserController : BaseAPI
    {
        private BaseContext context;

        public UserController(BaseContext c)
        {
            this.context = c;
        }
    }
}
