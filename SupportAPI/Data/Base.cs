using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SupportAPI.Data
{
    public class Base
    {
        public enum enRowStatus : short { Removed = -1, Temporary = 0, Active = 1 }

        [Column("BASEROWD"), DataType(DataType.Date)]
        public DateTime RowDate { get; set; }

        [Column("BASEROWS")]
        public short RowStatusValue { get; set; }

        [NotMapped]
        public enRowStatus RowStatus
        {
            get { return (enRowStatus)this.RowStatusValue; }
            set { this.RowStatusValue = (short)value; }
        }


        public Base()
        {
            this.RowDate = DateTime.Now;
            this.RowStatus = enRowStatus.Temporary;
        }


    }
}
