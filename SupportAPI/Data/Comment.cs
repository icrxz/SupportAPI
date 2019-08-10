using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportAPI.Data
{
    [Table("COMENTARIO")]
    public class Comment : Base
    {
        #region New
        public Comment()
        {
            this.Id = -1;
        }
        #endregion

        #region ID
        [Column("ID")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        #endregion

        #region TicketUserId
        [Column("TICKET_USUARIO_ID")]
        public int TicketUserId { get; set; }        
        #endregion

        #region Comment
        [Column("COMENTARIO", TypeName = "varchar(4000)"), StringLength(4000)]
        public string Comments { get; set; }
        #endregion

    }
}
