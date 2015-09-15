using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MicaWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MicaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MicaService.svc or MicaService.svc.cs at the Solution Explorer and start debugging.
    public class MicaService : IMicaService
    {
        micadb2Entities db;
        public MicaService()
        {
            db = new micadb2Entities();
        }

        public Restaurante[] GetRestaurantes()
        {
            return db.Restaurantes.ToArray();
        }

        public string SaveRestaurante(Restaurante restaurante, string id)
        {
            try
            {
                if (restaurante.ID == 0)
                {
                    restaurante.Registrado = DateTime.Now;
                    db.Restaurantes.Add(restaurante);
                }
                else
                    db.Entry(restaurante).State = EntityState.Modified;

                db.SaveChanges();
                return restaurante.ID.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool DeleteRestaurante(Restaurante restaurante)
        {
            var r = db.Restaurantes.Find(restaurante.ID);
            db.Restaurantes.Remove(r);
            db.SaveChanges();
            return true;
        }

    }
}
