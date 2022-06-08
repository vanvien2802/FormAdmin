using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernUI_FontAw.Model;
using ModernUI_FontAw.Repositories;

namespace ModernUI_FontAw.BLL
{
    public class AdminBLL_OderHis
    {
        private IRepository<UseComputerHistory> repository;

        public AdminBLL_OderHis() : this(new GenericRepository<UseComputerHistory>())
        {

        }

        public AdminBLL_OderHis(IRepository<UseComputerHistory> _repository)
        {
            repository = _repository;
        }
        public IEnumerable<UseComputerHistory> GetAll()
        {
            IEnumerable<UseComputerHistory> data = repository.GetAll().ToList();
            foreach (UseComputerHistory i in data)
            {
                i.Customer.FullNameCus = i.Customer.FirstName + i.Customer.LastName;
            }
            return data;
        }
        
        public void DelHis(string id)
        {

            repository.Delete(Convert.ToInt32(id));
            repository.Save();
        }
        public UseComputerHistory GetCusById(int id)
        {
            return repository.GetById(id);

        }

        public void UpdateAdd(UseComputerHistory cus)
        {
            bool add = true;
            foreach (UseComputerHistory i in GetAll())
            {
                //if (i.ID_User == cus.ID_User)
                //{
                //    add = false;
                //    break;
                //}
            }
            if (add)
            {
                Add(cus);

            }
            else UpDate(cus);

        }
        public void Add(UseComputerHistory cus)
        {
            repository.Insert(cus);
            repository.Save();
        }

        public void UpdateDelegate(UseComputerHistory c1, UseComputerHistory c2)
        {
            //c1.FirstName = c2.FirstName; c1.LastName = c2.LastName; c1.Phone = c2.Phone; c1.Email = c2.Email;
            //c1.DateOfBirth = c2.DateOfBirth; c1.Day_Create = c2.Day_Create; c1.Money = c2.Money; c1.ID_Employee = c2.ID_Employee;
            //c1.Gender = c2.Gender; c1.ID_User = c2.ID_User;
        }

        public void UpDate(UseComputerHistory customer)
        {
            //repository.Update(UseComputerHistory, UseComputerHistory.ID_User, UpdateDelegate);
            //repository.Save();
        }

        public List<UseComputerHistory> Sort(string txt)
        {
            List<UseComputerHistory> list = new List<UseComputerHistory>();
            if (txt == "Name")
            {
                list = GetAll().OrderBy(p => p.Customer.LastName).ToList();
            }
            if (txt == "ID_Computer")
            {
                list = GetAll().OrderBy(p => p.ID_User).ToList();
            }
            if (txt == "ID_History")
            {
                list = GetAll().OrderBy(p => p.ID_HistoryUseComputer).ToList();
            }
            return list;

        }
        public List<UseComputerHistory> Search(string s, string txt)
        {
            List<UseComputerHistory> data = new List<UseComputerHistory>();
            List<UseComputerHistory> data1 = GetAll().ToList();
            foreach (UseComputerHistory i in data1)
            {
                i.Customer.FullNameCus = i.Customer.FirstName + i.Customer.LastName;
            }
            if (s == "Name")
            {
                foreach (UseComputerHistory i in data1)
                {
                    if (i.Customer.FullNameCus.Contains(txt))
                    {
                        data.Add(i);
                        return data;
                    }
                }
            }
            else if (s == "ID_Computer")
            {
                int id = Convert.ToInt32(txt);
                foreach (UseComputerHistory i in repository.GetAll())
                {
                    if (i.ID_Computer == id)
                    {
                        data.Add(i);
                    }
                }
            }
            else if (s == "ID_History")
            {
                int id = Convert.ToInt32(txt);
                foreach (UseComputerHistory i in repository.GetAll())
                {
                    if (i.ID_HistoryUseComputer == id)
                    {
                        data.Add(i);
                    }
                }
            }
            else if (s == "All")
            {
                data = GetAll().ToList();
            }
            return data;
        }
    }
}
