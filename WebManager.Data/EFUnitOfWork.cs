using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebManager.Data.Contracts;
using WebManager.Models;

namespace WebManager.Data
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private AppDbContext DbContext { get; set; }

        public IRepository<Study> Studies
        {
            get { return new EFRepository<Study>(this.DbContext); }
        }

        public IRepository<StudyInformation> StudyInfos
        {
            get { return new EFRepository<StudyInformation>(this.DbContext); }
        }

        public EFUnitOfWork()
        {
            CreateDbContext();
        }

        public void Commit()
        {
            this.DbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.DbContext.Dispose();
        }

        private void CreateDbContext()
        {
            this.DbContext = new AppDbContext();

            this.DbContext.Configuration.ProxyCreationEnabled = false;
            this.DbContext.Configuration.LazyLoadingEnabled = false;
            this.DbContext.Configuration.ValidateOnSaveEnabled = false;
        }
    }
}
