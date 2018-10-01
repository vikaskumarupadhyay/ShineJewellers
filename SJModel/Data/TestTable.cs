using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SJModel.Data
{
    [Table("TestTable")]
  public partial class TestTable
    {
        [Key]
        public string column1 { get; set; }
        public string Column2 { get; set; }
    }
}
