using FilmFestival.Service.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Service
{
    public class OkServiceResult<T> : ServiceResult<T>
    {
        private T _value;
        public override T Value { get { return _value; } }
        public override bool IsOk { get { return true; } }
        public override String Message { get { return "OK"; } }
        public override int Code { get { return 200; } }
        public OkServiceResult(T value)
        {
            this._value = value;
        }
        public override TRet Visit<TIn, TRet>(IServiceResultVisitor<TIn, TRet> visitor)
        {
            return visitor.VisitOk(this as OkServiceResult<TIn>);
        }
    }

    public class OkServiceResult : OkServiceResult<Nothing>
    {
        public OkServiceResult()
            : base(null)
        {
        }
    }

    public class Nothing
    {
    }
}
