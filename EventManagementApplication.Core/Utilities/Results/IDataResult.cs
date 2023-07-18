using EventManagementApplication.Core.Utilities.Results;

namespace EventManagementApplication.Business.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
