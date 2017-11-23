using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeadlineManagementDB.FileUpload;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace DeadlineManagementDB.Helper
{
    public class UploadFileHelper :IHelper<FileUploaded>
    {
        private DeadlineManagementContext context = new DeadlineManagementContext();

        public void Add(FileUploaded model) {
            using (context) {
                context.fileuploades.Add(model);
                context.SaveChanges();
            }
        }

        public ICollection<FileUploaded> GetAll() {
            return context.fileuploades.Include(x => x.user).ToList();
        }

        public FileUploaded GetById(int Id) {
            return context.fileuploades.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Remove(FileUploaded model) {
            using (context) {
                var found = GetById(model.Id);
                context.fileuploades.Remove(found);
                context.SaveChanges();
            }
        }

        public void Update(FileUploaded model) {
            throw new NotImplementedException();
        }
    }
}