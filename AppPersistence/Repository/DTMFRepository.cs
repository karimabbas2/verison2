using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppDomain;
using AppPersistence.Context;


namespace AppPersistence.Repository
{
    public class DTMFRepository : GenaricRepository<DTMF, int>, IDTMF
    {
        private readonly MyDbContext _myDBContext;
        public DTMFRepository(MyDbContext myDBContext) : base(myDBContext)
        {
            _myDBContext = myDBContext;
        }
    }
}