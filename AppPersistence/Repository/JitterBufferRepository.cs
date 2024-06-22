using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppDomain;
using AppPersistence.Context;

namespace AppPersistence.Repository
{
    public class JitterBufferRepository : GenaricRepository<JitterBuffer, int>, IJitterBuffer
    {
        private readonly MyDbContext _myDBContext;
        public JitterBufferRepository(MyDbContext myDBContext) : base(myDBContext)
        {
            _myDBContext = myDBContext;
        }
    }
}