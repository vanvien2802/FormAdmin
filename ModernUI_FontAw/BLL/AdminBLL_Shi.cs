using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernUI_FontAw.Model;
using ModernUI_FontAw.Repositories;

namespace ModernUI_FontAw.BLL
{
    public class AdminBLL_Shi
    {
        private IRepository<Shift> repository;

        public AdminBLL_Shi() : this(new GenericRepository<Shift>())
        {

        }

        public AdminBLL_Shi(IRepository<Shift> _repository)
        {
            repository = _repository;
        }
        public IEnumerable<Shift> GetAll()
        {
            IEnumerable<Shift> data = repository.GetAll().ToList();
            repository.Save();
            return data;
        }
        
        public void DelShift(int id)
        {
            repository.Delete(id);
            repository.Save();
        }
    }
}
