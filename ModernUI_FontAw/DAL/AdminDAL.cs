using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernUI_FontAw.Model;

namespace ModernUI_FontAw.DAL
{
    public class AdminDAL
    {
        Admin db = new Admin();
        private static AdminDAL _Instance;
        public static AdminDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AdminDAL();
                    return _Instance;
                }
                else
                {
                    return _Instance;
                }
            }
            private set { }
        }
        //public delegate bool Mydel(SinhVien s1, SinhVien s2);


    }
}
