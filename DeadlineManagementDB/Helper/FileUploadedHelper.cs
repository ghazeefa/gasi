using DeadlineManagementDB.FileUpload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadlineManagementDB.Helper {
    public class FileUploadedHelper : IHelper<FileUploaded> {
        private DeadlineManagementContext ctx = new DeadlineManagementContext();

        public void Add(FileUploaded model) {
            throw new NotImplementedException();
        }

        public ICollection<FileUploaded> GetAll() {
            throw new NotImplementedException();
        }

        public FileUploaded GetById(int Id) {
            throw new NotImplementedException();
        }

        public void Remove(FileUploaded model) {
            throw new NotImplementedException();
        }

        public void Update(FileUploaded model) {
            throw new NotImplementedException();
        }
    }
}
