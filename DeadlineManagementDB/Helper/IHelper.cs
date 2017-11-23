using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadlineManagementDB.Helper {
    interface IHelper<T> {
        void Add(T model);
        void Remove(T model);
        void Update(T model);

        T GetById(int Id);
        ICollection<T> GetAll();
    }
}
