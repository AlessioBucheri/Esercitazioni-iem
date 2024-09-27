using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLibreria.Models.DAL
{
    internal interface IDaoInserimento<T>
    {
        bool Insert(T obj);
        bool Update(T obj);
        bool Delete(string obj);
        bool Delete(int id);

    }
}
