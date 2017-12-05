using DeadlineManagementDB.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadlineManagementDB.Helper {
    public class UserHelper : IHelper<User> {
        private DeadlineManagementContext ctx = new DeadlineManagementContext();
        public void Add(User model) {
            using (ctx) {
                ctx.Users.Add(model);
                ctx.SaveChanges();
            }
        }

        public ICollection<User> GetAll() {
            return ctx.Users.ToList();
        }

        public User GetById(int Id) {
            return ctx.Users.FirstOrDefault(x => x.Id == Id);
        }

        public void Remove(User model) {
            throw new NotImplementedException();
        }

        public void Update(User model) {
            throw new NotImplementedException();
        }

        public string GetUserexists(string name,string password) {
            return ctx.Users.FirstOrDefault(x => x.FirstName.Equals(name) && x.Password.Equals(password)).SecondName;
        }
    }
}
