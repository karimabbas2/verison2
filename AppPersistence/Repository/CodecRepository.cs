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
    public class CodecRepository : GenaricRepository<Codec, int>, ICodec
    {
        private readonly MyDbContext _myDBContext;
        public CodecRepository(MyDbContext myDBContext) : base(myDBContext)
        {
            _myDBContext = myDBContext;
        }
    }

}