using AppCore.Interfaces;
using AppDomain;
using AppPersistence.Context;

namespace AppPersistence.Repository
{
    public class DepartmentRepository : GenaricRepository<Department, int>, IDepartment
    {
        private readonly MyDbContext _myDBContext;
        public DepartmentRepository(MyDbContext myDBContext) : base(myDBContext)
        {
            _myDBContext = myDBContext;
        }
    }
}