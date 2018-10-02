using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJModel.Data
{
    public partial class MainContainer:DbContext
    {
        public MainContainer():base("name=MainConnectionString")
        {

        }
        public MainContainer(string connectionString) : base(connectionString) { }



        public virtual DbSet<Finding> Findings { get; set; }
        public virtual DbSet<Stone> Stones { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // base.OnModelCreating(modelBuilder);
        }

    }
}
