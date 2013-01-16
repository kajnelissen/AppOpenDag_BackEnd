using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebManager.Data;
using WebManager.Data.Contracts;
using WebManager.Model;

namespace WebManager.Controllers.api
{
    /// <summary>
    /// 
    /// </summary>
    public class StudyController : ApiController
    {
        private EFUnitOfWork uow;

        /// <summary>
        /// 
        /// </summary>
        public StudyController()
            : base()
        {
            this.uow = new EFUnitOfWork();
        }

        /// <summary>
        /// 
        /// </summary>
        public StudyController(EFUnitOfWork uow)
            : base()
        {
            this.uow = uow;
        }

        // GET api/study
        public IEnumerable<Study> Get()
        {
            return uow.Studies.GetAll();
        }

        // GET api/study/5
        public Study Get(int id)
        {
            return uow.Studies.GetById(id);
        }

        // POST api/study
        public void Post([FromBody]Study value)
        {
        }

        // PUT api/study/5
        public void Put(int id, [FromBody]Study value)
        {
        }

        // DELETE api/study/5
        public void Delete(int id)
        {
            uow.Studies.Remove(uow.Studies.GetById(id));
            uow.Commit();
        }
    }
}
