using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        bool Save();
    }
}