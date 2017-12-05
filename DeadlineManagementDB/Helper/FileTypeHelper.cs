using DeadlineManagementDB.FileUpload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DeadlineManagementDB.Helper {
    public class FileTypeHelper : IHelper<FileType> {
        private DeadlineManagementContext ctx = new DeadlineManagementContext();
        public void Add(FileType model) {
            throw new NotImplementedException();
        }

        public ICollection<FileType> GetAll() {
            return ctx.FileTypes
                .Include(x => x.FileCategory)
                .ToList();
        }

        public FileType GetById(int Id) {
            return ctx.FileTypes.FirstOrDefault(x => x.Id==Id);
        }

        public void Remove(FileType model) {
            throw new NotImplementedException();
        }

        public void Update(FileType model) {
            throw new NotImplementedException();
        }
    }
}
