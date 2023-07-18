using EventManagementApplication.Core.Utilities.Results;

namespace EventManagementApplication.Business.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
