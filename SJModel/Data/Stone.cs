using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SJModel.Data
{
    [Table("Stone")]
    public partial class Stone
    {
        [Key]
        public int StoneId { get; set; }

        public string StoneName { get; set; }

        public bool? IsActive { get; set; }
    }
}
