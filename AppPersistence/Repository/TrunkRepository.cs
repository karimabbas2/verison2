using AppCore.Interfaces;
using AppDomain.TrunkEntity;
using AppPersistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppPersistence.Repository
{
    public class TrunkRepository(MyDbContext myDbContext) : GenaricRepository<Trunk, int>(myDbContext), ITrunk
    {
        private readonly MyDbContext _myDbContext = myDbContext;

        public new async Task<List<Trunk>> GetAllAsync()
        {
            return await _myDbContext.Trunks.Include(x => x.DTMF_Mode).AsNoTracking().ToListAsync();
        }

        public async Task<List<Trunk>> GetAllTrunksConfig()
        {
            return await _myDbContext.Trunks.Include(x => x.DTMF_Mode).Select(x => new Trunk
            {
                Type = x.Type,
                Name =x.Name,
                Server_Address = x.Server_Address,
                Transport = x.Transport,
                Need_Registration =x.Need_Registration,
                User_Name =x.User_Name,
                Password=x.Password,
                KA_Freq =x.KA_Freq,
                Out_Proxy_Server=x.Out_Proxy_Server,
                Out_Proxy_Port=x.Out_Proxy_Port,
                Port=x.Port,
                A_CodecTo = x.A_CodecTo
            }).AsNoTracking().ToListAsync();
        }
    }

}