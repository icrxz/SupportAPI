using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportAPI.API.Comment;
using SupportAPI.API.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportAPI.API.Ticket
{
    public partial class TicketController
    {
        [HttpGet("getTickets")]
        public async Task<ActionResult<List<VMs.Ticket>>> GetTickets()
        {
            try
            {
                var dataT = await context.Tickets
                    .Where(x => x.RowStatus == Data.Base.enRowStatus.Active)
                    .ToListAsync();

                List<VMs.Ticket> result = new List<VMs.Ticket>();
                foreach (Data.Ticket t in dataT)
                {
                    result.Add(await ConvertVMTicket(t as Data.Ticket));
                }

                return OkResponse(result);
            }
            catch (Exception ex) { return BadRequestResponse(ex); }
            finally { context.Dispose(); }
        }

        [HttpGet("getTicket/{id}")]
        public async Task<ActionResult<VMs.Ticket>> GetTicketData(int id)
        {
            try
            {
                //QUERY
                var dataT = await context.Tickets
                    .Where(x => x.RowStatus == Data.Base.enRowStatus.Active && x.Id == id)
                    .FirstOrDefaultAsync();

                var result = await ConvertVMTicket(dataT);

                return OkResponse(result);
            }
            catch (Exception ex)
            {
                return BadRequestResponse(ex);
            }
            finally { context.Dispose(); }
        }

        public async Task<VMs.Ticket> ConvertVMTicket(Data.Ticket ticket)
        {
            try
            {
                VMs.User u;
                List<VMs.Comment> c;
                using (var user = new UserController(context))
                {
                    u = await user.GetUserData(ticket.UserId);
                }
                using (var com = new CommentController(context))
                {
                    c = await com.GetCommentData(ticket.Id);
                }
                VMs.Ticket result = new VMs.Ticket
                {
                    Id = ticket.Id,
                    ClosingDate = ticket.ClosingDate,
                    Code = ticket.Code,
                    Description = ticket.Description,
                    OpeningDate = ticket.OpeningDate,
                    Priority = ticket.Priority.ToString(),
                    Status = ticket.Status.ToString(),
                    Type = ticket.Type.ToString(),
                    Owner = u,
                    Comments = c
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
