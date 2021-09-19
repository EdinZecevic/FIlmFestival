using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Service.Definition
{
    public interface IServiceResultVisitor<Tin, TRet>
    {
        TRet VisitOk(OkServiceResult<Tin> result);
    }
}
