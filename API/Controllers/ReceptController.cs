using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class ReceptController : ApiController
    {
        public IEnumerable<Recept> Get()
        {
            var aps = ServiceProvider.Get<ReceptService>().GetAll();
            aps.ForEach(o =>
            {
            });

            return aps;
        }

        // GET api/Recept/5
        public Recept Get(int id)
        {
            var o = ServiceProvider.Get<ReceptService>().Get(id);

            if (o == null)
                return null;


            return o;
        }

        // POST api/Recept
        public bool Post([FromBody] Recept obj)
        {
            try
            {
                ServiceProvider.Get<ReceptService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Recept/5
        public void Put(int id, [FromBody] Recept obj)
        {
            ServiceProvider.Get<ReceptService>().Update(id, obj);
        }

        // DELETE api/Recept/5
        public void Delete(int id)
        {
            ServiceProvider.Get<ReceptService>().Delete(id);
        }
    }
}