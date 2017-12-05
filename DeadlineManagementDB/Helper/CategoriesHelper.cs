﻿using System.Collections.Generic;
using System.Linq;
using DeadlineManagementDB.Supporting;
using DeadlineManagementDB.FileUpload;

namespace DeadlineManagementDB.Helper {
    public class CategoriesHelper : IHelper<FileCategory> {
        private DeadlineManagementContext ctx = new DeadlineManagementContext();
        public void Add(FileCategory model) {
            using (ctx) {
                ctx.FileCategories.Add(model);
                ctx.SaveChanges();
            }
        }

        public ICollection<FileCategory> GetAll() {
            return ctx.FileCategories.ToList();
        }

        public FileCategory GetById(int Id) {
            return ctx.FileCategories.FirstOrDefault(x => x.Id == Id);
        }

        public void Remove(FileCategory model) {
            throw new System.NotImplementedException();
        }

        public void Update(FileCategory model) {
            throw new System.NotImplementedException();
        }
    }
}
