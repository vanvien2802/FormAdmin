using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernUI_FontAw.Model;
using ModernUI_FontAw.Repositories;

namespace ModernUI_FontAw.BLL
{
    public class AdminBLL_Em
    {
        private IRepository<Employee> repository;

        public AdminBLL_Em() : this(new GenericRepository<Employee>())
        {

        }

        public AdminBLL_Em(IRepository<Employee> _repository)
        {
            repository = _repository;
        }
        public IEnumerable<Employee> GetAll()
        {
            IEnumerable<Employee> data = repository.GetAll().ToList();
            repository.Save();
            return data;
        }
        
    }
}
