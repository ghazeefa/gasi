using DeadlineManagementDB.FileUpload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DeadlineManagementDB.Helper {
    public class FileUploadedHelper : IHelper<FileUploaded> {
        private DeadlineManagementContext context = new DeadlineManagementContext();

        public void Add(FileUploaded model) {
            using (context) {
                context.Entry(model.User).State = EntityState.Unchanged;
                context.Entry(model.FileUploadedDetail.Department.Branch).State = EntityState.Unchanged;
                context.Entry(model.FileUploadedDetail.Department).State = EntityState.Unchanged;
                context.Entry(model.FileUploadedDetail.FileType.FileCategory).State = EntityState.Unchanged;
                context.Entry(model.FileUploadedDetail.FileType).State = EntityState.Unchanged;

                context.FileUploades.Add(model);
                context.SaveChanges();
            }
        }

        public ICollection<FileUploaded> GetAll() {
            return context.FileUploades
                .Include(x => x.User)
                .Include(x => x.FileUploadedDetail)
                .Include(x => x.FileUploadedDetail.FileType)
                .Include(x => x.FileUploadedDetail.FileType.FileCategory)
                .Include(x => x.FileUploadedDetail.Department)
                .Include(x => x.FileUploadedDetail.Department.Branch)
                .Include(x => x.FileUploadedDetail.Department.Branch.Company)
                .ToList();
        }

        public FileUploaded GetById(int Id) {
            return context.FileUploades
                .Include(x => x.User)
                .Include(x => x.FileUploadedDetail)
                .Include(x => x.FileUploadedDetail.FileType)
                .Include(x => x.FileUploadedDetail.FileType.FileCategory)
                .Include(x => x.FileUploadedDetail.Department)
                .Include(x => x.FileUploadedDetail.Department.Branch)
                .Include(x => x.FileUploadedDetail.Department.Branch.Company)
                .Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Remove(FileUploaded model) {
            using (context) {
                var found = GetById(model.Id);
                context.FileUploades.Remove(found);
                context.SaveChanges();
            }
        }

        public void Update(FileUploaded model) {
            throw new NotImplementedException();
        }
    }
}
