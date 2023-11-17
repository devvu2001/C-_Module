using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_csharp.SQLAdapter
{
    public interface ISQLAdapter<T>
    {
        void Insert(T item);
        void Update(T item);
        void Delete(Guid id);
        T GetById(Guid id);
        List<T> GetAll();
    }

}
