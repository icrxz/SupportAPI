using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportAPI.Data;

namespace SupportAPI.API.Comment
{
    partial class CommentController
    {
        [HttpPost("add")]
        public async Task<ActionResult<bool>> Save([FromBody] VMs.Comment comment)
        {
            try
            {
                var ticketUserID = -1;

                var tickerUser = await context.TicketUsers
                    .Where(x => x.RowStatus == Base.enRowStatus.Active && x.TicketId == comment.TicketId && x.UserId == comment.User.Id)
                    .FirstOrDefaultAsync();

                if (tickerUser != null)
                {

                    ticketUserID = tickerUser.Id;
                }
                else
                {
                    // TICKET USER
                    ticketUserID = context.TicketUsers
                    .Max(x => x.Id);

                    var ticketUser = new TicketUser
                    {
                        Id = ++ticketUserID,
                        UserId = comment.User.Id,
                        TicketId = comment.TicketId,
                        RowStatus = Base.enRowStatus.Active,
                        RowDate = DateTime.Now
                    };

                    context.TicketUsers.Add(ticketUser);
                    await context.SaveChangesAsync();
                }
                
                // COMMENT
                var commentId = context.Comments
                .Max(x => x.Id);

                var dataComment = new Data.Comment
                {
                    Id = ++commentId,
                    Comments = comment.Description,
                    TicketUserId = ticketUserID,                
                    RowStatus = Base.enRowStatus.Active,
                    RowDate = DateTime.Now,                        
                };

                context.Comments.Add(dataComment);

                await context.SaveChangesAsync();
                    
                return OkResponse(true);
                
            }
            catch(Exception ex) { return BadRequestResponse(ex); }
            finally { context.Dispose(); }
        }
    }
}
