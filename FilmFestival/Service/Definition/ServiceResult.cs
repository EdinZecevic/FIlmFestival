using System;

namespace FilmFestival.Service.Definition
{
    public abstract class ServiceResult<T>
    {
        public abstract T Value { get; }
        public abstract bool IsOk { get; }
        public abstract int Code { get; }
        public abstract String Message { get; }
        public abstract TRet Visit<TIn, TRet>(IServiceResultVisitor<TIn, TRet> visitor);
    }
}