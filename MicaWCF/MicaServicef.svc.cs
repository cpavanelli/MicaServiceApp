//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.ServiceModel.Web;
//using System.Text;

//namespace MicaWCF
//{
//    public class MicaService : IMicaServicef
//    {
//        micadb2Entities db;
//        public MicaService()
//        {
//            db = new micadb2Entities();
//        }

//        public Restaurante[] GetRestaurantes()
//        {
//            return db.Restaurantes.ToArray();
//        }

//        public string SaveRestaurante(Restaurante restaurante, string id)
//        {
//            try
//            {
//                if (restaurante.ID == 0)
//                    db.Restaurantes.Add(restaurante);
//                else
//                {
//                    db.Entry(restaurante).State = EntityState.Modified;
//                    db.SaveChanges();
//                }


//                return restaurante.ID.ToString();
//            }
//            catch (Exception ex)
//            {
//                return ex.Message;
//            }
//        }

//        public bool DeleteRestaurante(Restaurante restaurante)
//        {
//            var r = db.Restaurantes.Find(restaurante.ID);
//            db.Restaurantes.Remove(r);
//            return true;
//        }

//    }
//}
