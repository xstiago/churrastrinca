using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurrasTrinca.DataAccess
{
    public class ChurrasTrincaDBInitializer : DropCreateDatabaseIfModelChanges<ChurrasTrincaContext>
    {
        protected override void Seed(ChurrasTrincaContext context)
        {
            base.Seed(context);
        }
    }
}
