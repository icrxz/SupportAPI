using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportAPI.API.User
{
    public partial class UserController
    {
        [HttpGet("getUser/{id}")]
        public async Task<VMs.User> GetUserData(int id)
        {
            try
            {
                //QUERY
                var dataU = await context.Users
                    .Where(x => x.RowStatus == Data.Base.enRowStatus.Active && x.Id == id)
                    .FirstOrDefaultAsync();

                return ConvertVMUser(dataU);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("getUserLogin/{user}")]
        public async Task<VMs.User> GetUserLogin(string user)
        {
            try
            {
                //QUERY
                var dataU = await context.Users
                    .Where(x => x.RowStatus == Data.Base.enRowStatus.Active && x.Login == user)
                    .FirstOrDefaultAsync();

                return ConvertVMUser(dataU);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public VMs.User ConvertVMUser(Data.User user)
        {
            try
            {
                VMs.User result = new VMs.User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Company = user.Company,
                    Login = user.Login,
                    Password = user.Password,
                    Email = user.Email,
                    Type = user.Type.ToString()
                };

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
