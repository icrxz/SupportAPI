using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportAPI.API.User
{
    public partial class UserController
    {
        [HttpGet("validate/{login}/{password}")]
        public async Task<ActionResult<Data.User>> ValidateUser(string login, string password)
        {
            try
            {
                var userData = await context.Users.
                    Where(x => x.Login == login && x.Password == password).
                    FirstOrDefaultAsync();

                return OkResponse(userData);
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex);
            }
            finally { context.Dispose(); }
        }
    }
}
