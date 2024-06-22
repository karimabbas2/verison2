using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces.GenaricInterface;
using AppDomain;


namespace AppCore.Interfaces
{
    public interface IExtenstions : IGenaricInterface<Extenstion, int>
    {
        Task<int> GetLastExtName();
        List<int> GetlAllExtensionNumers();
        Task<List<Extenstion>> GetAllExtensionConfig();
        Task<List<Extenstion>> GettAllExtensionVoicePrompts();
        Task<int> GetExtenionsNumberById(int id);

    }
}