using DeadlineManagementDB.Supporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DeadlineManagementDB.Helper {
    public class BranchHelper : IHelper<Branch> {

        private DeadlineManagementContext ctx = new DeadlineManagementContext();

        public void Add(Branch model) {
            using (ctx) {
                ctx.Branches.Add(model);
                ctx.SaveChanges();
            }
        }

        public ICollection<Branch> GetAll() {
            return ctx.Branches.ToList();
        }

        public Branch GetById(int Id) {
            return ctx.Branches.Include(x => x.Departments).FirstOrDefault(x => x.Id == Id);
        }

        public void Remove(Branch model) {
            using (ctx) {
                var found = GetById(model.Id);
                foreach (var depart in found.Departments) {
                    ctx.Departments.Remove(depart);
                    ctx.SaveChanges();
                }

                ctx.Branches.Remove(found);
                ctx.SaveChanges();
            }
        }

        public void Update(Branch model) {
            throw new NotImplementedException();
        }


        public List<Branch> GetBranchesByCompanyId(int  compId) {
            return ctx.Branches
                .Include(x => x.Company)
                .Include(x=> x.Departments)
                .Where(x => x.Company.Id == compId).ToList();
        }
    }
}
