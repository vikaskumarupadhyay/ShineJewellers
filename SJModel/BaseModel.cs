using SJModel.Core;
using SJModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJModel
{
   public abstract class BaseModel
    {
        protected MainContainer DB { get; set; }

        protected BaseModel(MainContainer db)
        {
            DB = db;
        }

        protected BaseModel(IDatabaseFactory dbFactory)
        {
            DB = (dbFactory.Get() as MainContainer);
        }

    }
}
