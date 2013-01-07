using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebManager.Model;
using WebManager.Data;

namespace WebManager.Controllers.api
{
    public class TimeTableController : ApiController
    {
        private EFUnitOfWork uow;

        /// <summary>
        /// 
        /// </summary>
        public TimeTableController() 
            : base()
        {
            this.uow = new EFUnitOfWork();
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeTableController(EFUnitOfWork uow)
            : base()
        {
            this.uow = uow;
        }

        // GET api/TimeTable
        public IEnumerable<TimeTable> Get()
        {
            return uow.TimeTables.GetAll();
        }

        // GET api/TimeTable/5
        public TimeTable Get(int id)
        {
            return uow.TimeTables.GetById(id);
        }

        // POST api/TimeTable
        public void Post([FromBody]TimeTable value)
        {
        }

        // PUT api/TimeTable/5
        public void Put(int id, [FromBody]TimeTable value)
        {
        }

        // DELETE api/TimeTable/5
        public void Delete(int id)
        {
            uow.TimeTables.Remove(uow.TimeTables.GetById(id));
            uow.Commit();
        }
    }
}
