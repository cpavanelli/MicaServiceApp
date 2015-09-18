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
        //public string VistoEmFormatado { get{ return VistoEm.ToString(); }set;}

        micadb2Entities db;
        public MicaService()
        {
            db = new micadb2Entities();
        }

        #region Restaurante
        public Restaurante[] GetRestaurantes()
        {
            //Restaurante[] rs = new Restaurante[db.Restaurantes.Count()];
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
                {
                    // todo porquisse
                    restaurante.Registrado = GetRegistradoDate(restaurante.ID);

                    db.Entry(restaurante).State = EntityState.Modified;
                }

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

        private DateTime? GetRegistradoDate(int id)
        {
            var r = db.Restaurantes.Find(id);
            db.Entry(r).State = EntityState.Detached;
            return r.Registrado;
        }

        #endregion

        #region Media
        public Media[] GetMedias()
        {
            return db.Medias.ToArray();
        }

        public string SaveMedia(Media media, string id)
        {
            try
            {
                if (media.ID == 0)
                {
                    media.Registrado = DateTime.Now;
                    db.Medias.Add(media);
                }
                else
                    db.Entry(media).State = EntityState.Modified;

                db.SaveChanges();
                return media.ID.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool DeleteMedia(Media media)
        {
            var r = db.Medias.Find(media.ID);
            db.Medias.Remove(r);
            db.SaveChanges();
            return true;
        } 

        #endregion

        #region Eventos

        public Evento[] GetEventos()
        {
            return db.Eventos.ToArray();
        }

        public string SaveEvento(Evento evento, string id)
        {
            try
            {
                if (evento.ID == 0)
                {
                    evento.Registrado = DateTime.Now;
                    db.Eventos.Add(evento);
                }
                else
                    db.Entry(evento).State = EntityState.Modified;

                db.SaveChanges();
                return evento.ID.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool DeleteEvento(Evento evento)
        {
            var r = db.Eventos.Find(evento.ID);
            db.Eventos.Remove(r);
            db.SaveChanges();
            return true;
        } 

        #endregion

        #region Dash

        public DashItem[] GetDash()
        {
            List<DashItem> items = new List<DashItem>();

            foreach (var item in db.Restaurantes.OrderByDescending(r => r.Registrado).Take(10))
                items.Add(new DashItem() { Nome = "Restaurante: " + item.Nome, Registrado = item.Registrado, IsRestaurante = true, ID = item.ID });

            foreach (var item in db.Eventos.OrderByDescending(r => r.Registrado).Take(10))
                items.Add(new DashItem() { Nome = "Evento: " + item.Nome, Registrado = item.Registrado, Quando = item.Inicio, IsEvento = true, ID = item.ID });

            foreach (var item in db.Medias.OrderByDescending(r => r.Registrado).Take(10))
                items.Add(new DashItem() { Nome = "Media: " + item.Nome, Registrado = item.Registrado, ID = item.ID });

            return items.OrderByDescending(i => i.Registrado).Take(3).ToArray();
        }

        public DashItem[] GetNextEvents()
        {
            List<DashItem> items = new List<DashItem>();

            foreach (var item in db.Eventos.OrderByDescending(r => r.Registrado).Take(10))
            {
                items.Add(new DashItem() { Nome = "Evento: " + item.Nome, Registrado = item.Registrado, Quando = item.Inicio, Dia = returnDia(item.Inicio) });
            }

            return items.OrderByDescending(i => i.Quando).Take(2).ToArray();
        }

        private string returnDia(Nullable<DateTime> _quando)
        {
            if (_quando.HasValue)
            {
                if (_quando.Value.Date == DateTime.Today)
                    return "Hoje";
                else if (_quando.Value.Date == DateTime.Today.AddDays(1))
                    return "Amanhã";
            }

            return null;
        } 

        #endregion
        
    }
}
