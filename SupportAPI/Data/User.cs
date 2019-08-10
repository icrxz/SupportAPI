using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportAPI.Data
{
    public enum enUserType : short { Support = 0, Client = 1, Dev = 2 }

    [Table("USUARIO")]
    public class User : Base
    {
        #region ID
        [Column("ID")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        #endregion

        #region Nome
        [Column("NOME", TypeName = "varchar(50)"), StringLength(50)]
        public string Name { get; set; }
        #endregion

        #region Empresa
        [Column("EMPRESA", TypeName = "varchar(100)"), StringLength(100)]
        public string Company { get; set; }
        #endregion

        #region Usuario
        [Column("USUARIO", TypeName = "varchar(50)"), StringLength(50)]
        public string Login { get; set; }
        #endregion

        #region Senha
        [Column("SENHA", TypeName = "varchar(50)"), StringLength(50)]
        public string Password { get; set; }
        #endregion

        #region Tipo
        [Column("TIPO")]
        public short TypeInner { get; set; }

        [NotMapped]
        public enUserType Type
        {
            get { return (enUserType)this.TypeInner; }
            set { this.RowStatusValue = (short)value; }
        }
        #endregion

        #region Email
        [Column("EMAIL", TypeName = "varchar(100)"), StringLength(100)]
        public string Email { get; set; }
        #endregion

        #region New
        public User()
        {
            this.Id = -1;
        }
        #endregion
    }
}
