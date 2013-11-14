using System.ServiceModel;

namespace Service.Contracts
{
    [ServiceContract]
    public interface IStatefulService
    {
        [OperationContract]
        int IncrementAndReturn();
    }
}