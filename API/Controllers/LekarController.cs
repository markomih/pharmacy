using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class LekarController : ApiController
    {
        public IEnumerable<Lekar> Get()
        {
            var aps = ServiceProvider.Get<LekarService>().GetAll();
            aps.ForEach(o =>
            {
                o.ReceptList = null;
            });

            return aps;
        }

        // GET api/Lekar/5
        public Lekar Get(int id)
        {
            var o = ServiceProvider.Get<LekarService>().Get(id);

            if (o == null)
                return null;

            o.ReceptList = null;

            return o;
        }

        // POST api/Lekar
        public bool Post([FromBody] Lekar obj)
        {
            try
            {
                ServiceProvider.Get<LekarService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Lekar/5
        public void Put(int id, [FromBody] Lekar obj)
        {
            ServiceProvider.Get<LekarService>().Update(id, obj);
        }

        // DELETE api/Lekar/5
        public void Delete(int id)
        {
            ServiceProvider.Get<LekarService>().Delete(id);
        }
    }
}