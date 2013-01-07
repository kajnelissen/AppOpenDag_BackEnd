using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebManager.Data;
using WebManager.Model;

namespace WebManager.Controllers.api
{
    /// <summary>
    /// 
    /// </summary>
    public class StudyInformationController : ApiController
    {
        private EFUnitOfWork uow;

        /// <summary>
        /// 
        /// </summary>
        public StudyInformationController() 
            : base()
        {
            this.uow = new EFUnitOfWork();
        }

        /// <summary>
        /// 
        /// </summary>
        public StudyInformationController(EFUnitOfWork uow)
            : base()
        {
            this.uow = uow;
        }

        // GET api/StudyInformation
        public IEnumerable<StudyInformation> Get()
        {
            return uow.StudyInfos.GetAll();
        }

        // GET api/StudyInformation/5
        public StudyInformation Get(int id)
        {
            return uow.StudyInfos.GetById(id);
        }

        // POST api/StudyInformation
        public void Post([FromBody]StudyInformation value)
        {
        }

        // PUT api/StudyInformation/5
        public void Put(int id, [FromBody]StudyInformation value)
        {
        }

        // DELETE api/StudyInformation/5
        public void Delete(int id)
        {
            uow.StudyInfos.Remove(uow.StudyInfos.GetById(id));
            uow.Commit();
        }
    }
}
