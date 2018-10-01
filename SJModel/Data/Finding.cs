using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SJModel.Data
{

    [Table("Findings")]
    public partial class Finding
    {
        [Key]
        public int FindingId { get; set; }

        public string  FindingName { get; set; }

        public bool? IsActive { get; set; }
    }
}
