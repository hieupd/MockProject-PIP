using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IDeleteService
    {
        int Delete(object Id, List<string> error);
    }
}
