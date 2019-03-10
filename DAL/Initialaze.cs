using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Initialaze:DropCreateDatabaseAlways<DbStaffContext>
    {
        protected override void Seed(DbStaffContext context)
        {
            base.Seed(context);
        }
    }
}
