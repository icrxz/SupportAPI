using Microsoft.AspNetCore.Mvc;
using SupportAPI.Data;
using System;

namespace SupportAPI.API.Comment
{
    [Route("api/comment")]
    public partial class CommentController : BaseAPI
    {
        private BaseContext context;

        public CommentController(BaseContext context)
        {
            this.context = context;
        }        
    }
}
