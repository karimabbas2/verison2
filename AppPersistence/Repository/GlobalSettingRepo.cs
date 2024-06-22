using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppDomain;
using AppPersistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppPersistence.Repository
{
    public class GlobalSettingRepo : GenaricRepository<GlobalExtenstionDefault, int>, IGlobalSetting
    {
        private readonly MyDbContext _myDbContext;

        public GlobalSettingRepo(MyDbContext myDbContext) : base(myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<GlobalExtenstionDefault> GetFirstByIdAsync(int id)
        {
            return await _myDbContext.GlobalExtenstionDefaults.Where(x => x.Id == id).SingleAsync();
        }
    }
}