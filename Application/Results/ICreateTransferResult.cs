using Domain.IServices;

namespace Application.Results;

public interface ICreateTransferResult
{
    public List<long> TransferIds { get; set; }
    public IDatabaseTransaction DbTransaction  {get; set;}

}
