using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportAPI.Data;

namespace SupportAPI.API.User
{
    public partial class UserController
    {
        [HttpPost("add")]
        public async Task<ActionResult<bool>> Save([FromBody] VMs.User user)
        {
            try
            {
                //Validation
                if (!context.Users
                    .Where(x => x.RowStatus == Base.enRowStatus.Active && x.Login == user.Login && x.Email == user.Email)
                    .Any())
                {
                    // USERS

                    var userId = context.Users
                    .Max(x => x.Id);

                    var dataUser = new Data.User
                    {
                        Id = ++userId,
                        Company = user.Company,
                        Login = user.Login,
                        Name = user.Name,
                        Password = user.Password,
                        Email = user.Email,
                        TypeInner = (short)Enum.Parse(typeof(enUserType), user.Type),

                        RowStatus = Base.enRowStatus.Active,
                        RowDate = DateTime.Now,
                    };

                    context.Users.Add(dataUser);

                    await context.SaveChangesAsync();

                    return OkResponse(true);
                }
                else
                    throw new Exception("Usuário já cadastrado!");
            }
            catch (Exception ex) { return BadRequestResponse(ex); }
            finally { context.Dispose(); }
        }
    }
}
