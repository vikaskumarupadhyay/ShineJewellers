using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJModel.Data;

namespace SJModel
{
  public  class TestTableModel
    {
        public MainContainer Db=new MainContainer();
        //public TestTableModel(MainContainer db)
        //{
        //    Db = db;
        //}
      //  public TestTableModel(IDatabaseFactory)
        public void SaveTestTable()
        {
            try
            {

            
           //
           // Db.TestTable.Add(tbale);
            Db.SaveChanges();
            }
            catch (Exception ex)
            {

                string ds = ex.Message;
            }
        }
    }
}
