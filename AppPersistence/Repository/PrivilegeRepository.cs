using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppDomain;
using AppPersistence.Context;

namespace AppPersistence.Repository
{
    public class PrivilegeRepository : GenaricRepository<Privilege, int>, IPrivilege
    {
        private readonly MyDbContext _myDBContext;
        public PrivilegeRepository(MyDbContext myDBContext) : base(myDBContext)
        {
            _myDBContext = myDBContext;
        }
    }
}