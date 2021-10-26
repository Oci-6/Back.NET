using DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorios
{
    public interface IRepositorioInstitucion
    {
        IEnumerable<TenantInstitucion> GetAll();
        TenantInstitucion Get(Guid id);
        void Insert(TenantInstitucion entity);
        void Update(TenantInstitucion entity);
        void Delete(TenantInstitucion entity);
    }
}
