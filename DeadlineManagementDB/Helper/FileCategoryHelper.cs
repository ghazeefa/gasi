using DeadlineManagementDB.FileUpload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadlineManagementDB.Helper {
    public class FileCategoryHelper : IHelper<FileCategory> {
        private DeadlineManagementContext ctx = new DeadlineManagementContext();
        public void Add(FileCategory model) {
            throw new NotImplementedException();
        }

        public ICollection<FileCategory> GetAll() {
            return ctx.FileCategories.ToList();
        }

        public FileCategory GetById(int Id) {
            return ctx.FileCategories.FirstOrDefault(x => x.Id == Id);
        }

        public void Remove(FileCategory model) {
            throw new NotImplementedException();
        }

        public void Update(FileCategory model) {
            throw new NotImplementedException();
        }
    }
}
