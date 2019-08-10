using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportAPI.Data;

namespace SupportAPI.API.Ticket
{
    [Route("api/ticket")]
    public partial class TicketController : BaseAPI
    {
        private BaseContext context;

        public TicketController(BaseContext c)
        {
            this.context = c;
        }
    }
}
