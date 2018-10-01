using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace SJModel.Core
{
   public interface IDatabaseFactory
    {

        DbContext Get(); 
    }
}
