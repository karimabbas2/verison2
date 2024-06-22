using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppDomain;
using AppPersistence.Context;

namespace AppPersistence.Repository
{
    public class VoicePromptsRepository(MyDbContext myDbContext) : GenaricRepository<VoicePrompts, int>(myDbContext), IFileInterface
    {
        private readonly MyDbContext _myDbContext = myDbContext;

    }
}