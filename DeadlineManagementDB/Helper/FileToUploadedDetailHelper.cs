using DeadlineManagementDB.FileUpload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DeadlineManagementDB.Helper {
    public class FileToUploadedDetailHelper : IHelper<FileToUploadedDetail> {
        private DeadlineManagementContext ctx = new DeadlineManagementContext();
        public void Add(FileToUploadedDetail model) {
            throw new NotImplementedException();
        }

        public ICollection<FileToUploadedDetail> GetAll() {
            return ctx.FileToUploadedDetails.ToList();
        }

        public FileToUploadedDetail GetById(int Id) {
            return ctx.FileToUploadedDetails.FirstOrDefault(x => x.Id == Id);
        }

        public void Remove(FileToUploadedDetail model) {
            throw new NotImplementedException();
        }

        public void Update(FileToUploadedDetail model) {
            throw new NotImplementedException();
        }

        public int GetFileDetail(int  file_type_id, int depart_id) {
            using (ctx) {
                return (Convert.ToInt32((from sc in ctx.FileToUploadedDetails.Include(x => x.FileType).Include(x => x.Department)
                                         where sc.Department.Id == depart_id && sc.FileType.Id == file_type_id 
                                         select sc.Id).FirstOrDefault()));
            }
        }
    }
}
