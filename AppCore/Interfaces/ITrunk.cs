using AppCore.Interfaces.GenaricInterface;
using AppDomain.TrunkEntity;

namespace AppCore.Interfaces
{
    public interface ITrunk : IGenaricInterface<Trunk, int>
    {
        Task<List<Trunk>> GetAllTrunksConfig();

    }
}