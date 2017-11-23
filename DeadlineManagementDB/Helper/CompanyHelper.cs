using DeadlineManagementDB.Supporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DeadlineManagementDB.Helper {
    public class CompanyHelper : IHelper<Company> {

        private DeadlineManagementContext ctx = new DeadlineManagementContext();

        public void Add(Company model) {
            using (ctx) {
               
                ctx.companies.Add(model);
                ctx.SaveChanges();
            }
        }

        public ICollection<Company> GetAll() {
            return ctx.companies.Include(x => x.Branches).ToList();
        }

        public Company GetById(int Id) {
            return ctx.companies.Include(x => x.Branches).FirstOrDefault(x => x.Id == Id);
        }

        public void Remove(Company model) {
            using (ctx) {
                var found = GetById(model.Id);
                foreach (var branch in found.Branches) {
                    ctx.branches.Remove(branch);
                    ctx.SaveChanges();
                }
                ctx.companies.Remove(found);
                ctx.SaveChanges();
            }
        }

        public void Update(Company model) {
            throw new NotImplementedException();
        }
    }
}
