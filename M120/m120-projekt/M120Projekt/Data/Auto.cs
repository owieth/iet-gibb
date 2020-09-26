using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace M120Projekt.Data
{
    public class Auto
    {
        #region Datenbankschicht
        [Key]
        public Int64 AutoID { get; set; }
        [Required]
        public String Beschreibung { get; set; }
        [Required]
        public String AutoBezeichnung { get; set; }
        [Required]
        public Int64 Leistung { get; set; }
        [Required]
        public String Farbe { get; set; }
        [Required]
        public Int64 Kilometerstand { get; set; }
        [Required]
        public DateTime Inverkehrssetzung { get; set; }
        [Required]
        public Boolean Zustand { get; set; }
        [Required]
        public Int64 Preis { get; set; }
        [Required]
        #endregion
        #region Applikationsschicht
        [NotMapped]

        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static IEnumerable<Data.Auto> LesenAlle()
        {
            return (from record in Data.Global.context.Auto select record);
        }
        public static Data.Auto LesenID(Int64 klasseAId)
        {
            return (from record in Data.Global.context.Auto where record.AutoID == klasseAId select record).FirstOrDefault();
        }
        public static IEnumerable<Data.Auto> LesenAttributGleich(String suchbegriff)
        {
            return (from record in Data.Global.context.Auto where record.Beschreibung == suchbegriff select record);
        }
        public static IEnumerable<Data.Auto> LesenAttributWie(String suchbegriff)
        {
            return (from record in Data.Global.context.Auto where record.Beschreibung.Contains(suchbegriff) select record);
        }
        public Int64 Erstellen()
        {
            if (this.Beschreibung == null || this.Beschreibung == "") this.Beschreibung = "leer";
            if (this.Inverkehrssetzung == null) this.Inverkehrssetzung = DateTime.MinValue;
            if (this.AutoBezeichnung == null || this.AutoBezeichnung == "") this.AutoBezeichnung = "leer";
            if (this.Leistung == 0) this.Leistung = 100;
            if (this.Farbe == null || this.Farbe == "") this.Farbe = "leer";
            if (this.Kilometerstand == 0) this.Kilometerstand = 0;
            if (this.Preis == 0) this.Preis = 1000;


            Data.Global.context.Auto.Add(this);
            try
            {
                Data.Global.context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return this.AutoID;
        }
        public Int64 Aktualisieren()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Modified;
            Data.Global.context.SaveChanges();
            return this.AutoID;
        }
        public void Loeschen()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
            Data.Global.context.SaveChanges();
        }
        public override string ToString()
        {
            return AutoID.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
