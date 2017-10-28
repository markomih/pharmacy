using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core;
using Core.Entities;
using Core.Services;
using Data;
using NHibernate.Linq;

namespace Services
{
    public class ApotekarskaUstanovaService : Service<ApotekarskaUstanova>, IApotekarskaUstanovaService
    {
        public ApotekarskaUstanovaService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override ApotekarskaUstanova Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<ApotekarskaUstanova>(id);

                if (obj == null) return null;

                obj.ProdajnoMestoList = session.Query<ProdajnoMesto>().Where(x => x.Deleted == false && x.ApotekarskaUstanova.Id == obj.Id).ToList();
                return obj;
            }
        }

        public override void Create(ApotekarskaUstanova entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    List<ProdajnoMesto> prodajnoMestos = new List<ProdajnoMesto>();

                    if (entity.ProdajnoMestoList != null)
                        prodajnoMestos.AddRange(entity.ProdajnoMestoList.Select(x => session.Get<ProdajnoMesto>(x.Id)));

                    entity.ProdajnoMestoList = prodajnoMestos;

                    session.SaveOrUpdate(entity);
                    session.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public override void Update(ApotekarskaUstanova entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    List<ProdajnoMesto> prodajnoMestos = new List<ProdajnoMesto>();
                    
                    if (entity.ProdajnoMestoList != null)
                        prodajnoMestos.AddRange(entity.ProdajnoMestoList.Select(x => session.Get<ProdajnoMesto>(x.Id)));
                    
                    entity.ProdajnoMestoList = prodajnoMestos;

                    session.Update(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public override void Update(int id, ApotekarskaUstanova entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var obj = Get(id);

                    obj.Kontakt = entity.Kontakt;
                    obj.Naziv = entity.Naziv;
                    obj.ProdajnoMestoList = entity.ProdajnoMestoList;
                    obj.Sajt = entity.Sajt;
                    
                    session.Update(obj);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public override void Delete(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var entity = session.Get<ApotekarskaUstanova>(id);

                    entity.Deleted = true;
                    session.Update(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("ApotekarskaUstanova");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Naziv");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("BrojTelefona");
            dataTable.Columns.Add("Sajt");

            dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +Naziv");

            List<ApotekarskaUstanova> objList;
            using (var session = DataLayer.GetSession())
                objList =
                    session.QueryOver<ApotekarskaUstanova>().Where(x => x.Deleted == false)?.List<ApotekarskaUstanova>()
                        as List<ApotekarskaUstanova>;


            if (objList == null) return dataTable;
            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Naziv, x.Kontakt.Email, x.Kontakt.BrojTelefona, x.Sajt));

            return dataTable;
        }
    }
}