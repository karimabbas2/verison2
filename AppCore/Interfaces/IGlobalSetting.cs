using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces.GenaricInterface;
using AppDomain;

namespace AppCore.Interfaces
{
    public interface IGlobalSetting : IGenaricInterface<GlobalExtenstionDefault,int> 
    {
        Task<GlobalExtenstionDefault> GetFirstByIdAsync(int id);

    }
}