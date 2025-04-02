using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_1Mars_Koscher_Jouhier
{
    class Station
    {
        string ligne;
        string nom;
        float longitude;
        float latitude;
        string commune;
        int code_postal;

        public Station(string ligne, string nom, float longitude, float latitude, string commune, int code_postal)
        {
            this.ligne = ligne;
            this.nom = nom;
            this.longitude = longitude;
            this.latitude = latitude;
            this.commune = commune;
            this.code_postal = code_postal;
        }

        public string Ligne
        {
            get { return ligne; }
        }
        public string Nom
        {
            get { return nom; }
        }
        public float Longitude
        {
            get { return longitude; }
        }
        public float Latitude
        {
            get { return latitude; }
        }
        public string Commune
        {
            get { return commune; }
        }
        public int Code_postal
        {
            get { return code_postal; }
        }
    }
}
