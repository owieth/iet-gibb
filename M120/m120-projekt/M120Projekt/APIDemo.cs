using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void createAuto()
        {
            Data.Auto auto = new Data.Auto();
            auto.Beschreibung = "Auto oli ist ein tolles Auto";
            auto.AutoBezeichnung = "loioioio";
            auto.Leistung = 52450;
            auto.Farbe = "Rot";
            auto.Kilometerstand = 120000;
            auto.Inverkehrssetzung = DateTime.Today;
            auto.Zustand = true;
            auto.Preis = 180000;
            Int64 autoID = auto.Erstellen();
        }

        public static List<Data.Auto> getAllAutos()
        {
            return Data.Auto.LesenAlle().ToList();
        }

        public static Data.Auto findAutoById(Int64 id)
        {
            return Data.Auto.LesenID(id);
        }

        public static void updateAutoById(Int64 id)
        {
            Data.Auto auto = Data.Auto.LesenID(id);
            auto.Aktualisieren();
        }

        public static void deleteAutoById(Int64 id)
        {
            Data.Auto.LesenID(id).Loeschen();
        }
        #endregion
    }
}
