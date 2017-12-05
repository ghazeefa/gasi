using DeadlineManagementDB.Supporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DeadlineManagementDB.Helper {
    public class DepartmentHelper : IHelper<Department> {

        private DeadlineManagementContext ctx = new DeadlineManagementContext();

        public void Add(Department model) {
            using (ctx) {
                ctx.Entry(model.Branch).State = System.Data.Entity.EntityState.Unchanged;
                ctx.Departments.Add(model);
                ctx.SaveChanges();
            }
        }

        public ICollection<Department> GetAll() {
            return ctx.Departments.Include(x => x.Branch).ToList(); 
        }

        public Department GetById(int Id) {
            return ctx.Departments.Include(x => x.Branch).FirstOrDefault(x => x.Id == Id);
        }

        public void Remove(Department model) {
            throw new NotImplementedException();
        }

        public void Update(Department model) {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartmentsByBranchId(int braId) {
            return ctx.Departments.Include(x => x.Branch)
                      .Where(x => x.Branch.Id == braId).ToList();
        }
    }
}
