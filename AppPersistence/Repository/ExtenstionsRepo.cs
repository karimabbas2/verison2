using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages;
using AppCore.Interfaces;
using AppDomain;
using AppPersistence.Context;
using Microsoft.EntityFrameworkCore;


namespace AppPersistence.Repository
{
    public class ExtenstionsRepo : GenaricRepository<Extenstion, int>, IExtenstions
    {
        private readonly MyDbContext _myDbContext;

        public ExtenstionsRepo(MyDbContext myDbContext) : base(myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<int> GetLastExtName()
        {
            var lastEXt = await _myDbContext.Extenstions.OrderBy(x => x.Id).LastOrDefaultAsync();
            return lastEXt?.Ext_Number ?? 0;
        }

        //Masking the method for new requierment
        public new async Task<List<Extenstion>> GetAllAsync()
        {
            return await _myDbContext.Extenstions.Include(x => x.DTMF_Mode).OrderBy(x => x.Ext_Number).AsNoTracking().ToListAsync();
        }

        public List<int> GetlAllExtensionNumers()
        {
            return [.. _myDbContext.Extenstions.Select(x => x.Ext_Number)];
        }

        public async Task<List<Extenstion>> GetAllExtensionConfig()
        {
            return await _myDbContext.Extenstions.Include(x => x.DTMF_Mode)
            .Select(x => new Extenstion
            {
                Ext_Number = x.Ext_Number,
                SIP_Password = x.SIP_Password,
                Enable_VM = x.Enable_VM,
                Ext_CC_Registrations = x.Ext_CC_Registrations,
                AuthId = x.AuthId,
                F_Name = x.F_Name,
                L_Name = x.L_Name,
                CallerId_Number = x.CallerId_Number,
                Language = x.Language,
                Enable_DM = x.Enable_DM,
                DTMF_Mode = x.DTMF_Mode,
                Enable_NAT = x.Enable_NAT,
                A_CodecTo = x.A_CodecTo

            }).AsNoTracking().ToListAsync();

        }

        public async Task<List<Extenstion>> GettAllExtensionVoicePrompts()
        {
            return await _myDbContext.Extenstions.Select(x => new Extenstion
            {
                Id = x.Id,
                F_Name = x.F_Name,
                L_Name = x.L_Name,
                Ext_Number = x.Ext_Number

            }).AsNoTracking().ToListAsync();
        }

        public async Task<int> GetExtenionsNumberById(int id)
        {
            return await _myDbContext.Extenstions.Where(x => x.Id == id)
            .Select(x => x.Ext_Number).FirstAsync();
        }
    }
}