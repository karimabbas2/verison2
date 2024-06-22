using AppCore.Interfaces;
using AppDomain;
using AppPersistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppPersistence.Repository
{
    public class SIPSettingReposiroty(MyDbContext myDbContext) : GenaricRepository<SIPSetting, int>(myDbContext), ISIPSettingInterface
    {
        private readonly MyDbContext _myDbContext = myDbContext;

    }

}