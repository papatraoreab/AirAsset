using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirAsset.Models
{
    public class ApplicationModel
    {
        //Element de collection Item
        public class Item
        {
            public string Value { get; set; }
            public string Label { get; set; }
        }


        //Element de type Item
        public Item[] EntrepotListe { get; set; } //Lineorwareouse
        public Item[] LocalisationListe { get; set; } //Location
        public Item[] FournisseurListe { get; set; } //Supplier
        public Item[] PoinEcoulementListe { get; set; } //FlowPoint
        public Item[] ProgrammeListe { get; set; } //PlaneProgram
        public Item[] SecteurListe { get; set; } //Sector
        public Item[] StatutListe { get; set; } // Order_status
        public Item[] SuiviListe { get; set; } //
        public Item[] TypeListe { get; set; } // Types


        //Initialisations des champs et collections /Constructeurs
        public ApplicationModel()
        {
            //Init Entrepot 
            EntrepotListe = new Item[]
            {
                new Item {Value = "1", Label = "Pieces elementaires metalliques"},
                new Item {Value = "2", Label = "Assemblage S/E"},
                new Item {Value = "3", Label = "Assemblage general"},
                new Item {Value = "4", Label = "Autre"},
                new Item {Value = "5", Label = "Pieces Elementaires Composites"},
                new Item {Value = "6", Label = "Magasin Outils Coupants (C12)"},
                new Item {Value = "7", Label = "Magasin Matieres Metalliques (F07 + Parc)"},
                new Item {Value = "8", Label = "Magasin matieres composites (M0)"},
                new Item {Value = "9", Label = "Magasin matieres dangereuses (O32)"},
                new Item {Value = "10", Label = "Magasin pieces elementaires (O37)"},
                new Item {Value = "11", Label = "Magasin equipements (W15G)"},
                new Item {Value = "12", Label = "Magasin consommables (W20)"},
                new Item {Value = "13", Label = "Market place grandes pieces (I05)"},
                new Item {Value = "14", Label = "Market place petites pieces (W15D)"},
                new Item {Value = "15", Label = "Stockage produits finis (ZB12)"},
                new Item {Value = "16", Label = "Stockage produits finis (ZB34)"},
                new Item {Value = "17", Label = "Stockage produits finis (ZC22)"}
            };


            //Init Localisation 
            LocalisationListe = new Item[]
            {
                new Item {Value = "1", Label = "A07"},
                new Item {Value = "2", Label = "A11"},
                new Item {Value = "3", Label = "A15"},
                new Item {Value = "4", Label = "B28"},
                new Item {Value = "5", Label = "C12"},
                new Item {Value = "6", Label = "E03"},
                new Item {Value = "7", Label = "F07"},
                new Item {Value = "8", Label = "G03"},
                new Item {Value = "9", Label = "G19"},
                new Item {Value = "10", Label = "H36"},
                new Item {Value = "11", Label = "I05"},
                new Item {Value = "12", Label = "I07"},
                new Item {Value = "13", Label = "I31"},
                new Item {Value = "14", Label = "J00"},
                new Item {Value = "15", Label = "K01"},
                new Item {Value = "16", Label = "K06"},
                new Item {Value = "17", Label = "K101"},
                new Item {Value = "18", Label = "K15"},
                new Item {Value = "19", Label = "K23"},
                new Item {Value = "20", Label = "K33"},
                new Item {Value = "21", Label = "L09"},
                new Item {Value = "22", Label = "L39"},
                new Item {Value = "23", Label = "M0"},
                new Item {Value = "24", Label = "M03"},
                new Item {Value = "25", Label = "N04"},
                new Item {Value = "26", Label = "N37"},
                new Item {Value = "27", Label = "N41"},
                new Item {Value = "28", Label = "O01"},
                new Item {Value = "29", Label = "O101"},
                new Item {Value = "30", Label = "O32"},
                new Item {Value = "31", Label = "O34"},
                new Item {Value = "32", Label = "O37"},
                new Item {Value = "33", Label = "O7"},
                new Item {Value = "34", Label = "P05"},
                new Item {Value = "35", Label = "P20"},
                new Item {Value = "36", Label = "P34"},
                new Item {Value = "37", Label = "Q03"},
                new Item {Value = "38", Label = "Q04"},
                new Item {Value = "39", Label = "Q06"},
                new Item {Value = "40", Label = "R14"},
                new Item {Value = "41", Label = "S22"},
                new Item {Value = "42", Label = "S26"},
                new Item {Value = "43", Label = "S30"},
                new Item {Value = "44", Label = "U12"},
                new Item {Value = "45", Label = "U34"},
                new Item {Value = "46", Label = "U37"},
                new Item {Value = "47", Label = "V13"},
                new Item {Value = "48", Label = "V18"},
                new Item {Value = "49", Label = "V24"},
                new Item {Value = "50", Label = "W11"},
                new Item {Value = "51", Label = "W15"},
                new Item {Value = "52", Label = "W29"},
                new Item {Value = "53", Label = "W32"},
                new Item {Value = "54", Label = "W6"},
                new Item {Value = "55", Label = "X13"},
                new Item {Value = "56", Label = "Y04"},
                new Item {Value = "57", Label = "Y10"},
                new Item {Value = "58", Label = "Y13"},
                new Item {Value = "59", Label = "Y26"},
                new Item {Value = "60", Label = "Y6"},
                new Item {Value = "61", Label = "ZA35"},
                new Item {Value = "62", Label = "ZB06"},
                new Item {Value = "63", Label = "ZB12"},
                new Item {Value = "64", Label = "ZB19"},
                new Item {Value = "65", Label = "ZB34"},
                new Item {Value = "66", Label = "ZC20"},
                new Item {Value = "67", Label = "ZC22"},
                new Item {Value = "68", Label = "ZC24"},
                new Item {Value = "69", Label = "ZD30"},
                new Item {Value = "70", Label = "ZG23"},
                new Item {Value = "71", Label = "ZH38"},
                new Item {Value = "72", Label = "ZI27"},
                new Item {Value = "73", Label = "ZK30"},
                new Item {Value = "74", Label = "ZL46"},
                new Item {Value = "75", Label = "ZM40"},
                new Item {Value = "76", Label = "ZO49"},
                new Item {Value = "77", Label = "ZP46"},
                new Item {Value = "78", Label = "ZP53"},
                new Item {Value = "79", Label = "ZP56"},
                new Item {Value = "80", Label = "ZQ44"},
                new Item {Value = "81", Label = "ZR54"},
                new Item {Value = "82", Label = "ZU49"}
            };
            
            
            /*
            //Init Fournisseur
            FournisseurListe = new Item[]
            {
                new Item {Value = "1", Label = "Maurice & Co"},
                new Item {Value = "2", Label = "Autres"}
            };
            */

            //Init PointEcoulement 
            PoinEcoulementListe = new Item[]
            {
                new Item {Value = "1", Label = "Aeroparc"},
                new Item {Value = "2", Label = "Autres"},
            };


            //Init Programme 
            ProgrammeListe = new Item[]
            {
                new Item {Value = "1", Label = "A320"},
                new Item {Value = "2", Label = "A330"},
                new Item {Value = "3", Label = "A350"},
                new Item {Value = "4", Label = "A380"},
                new Item {Value = "5", Label = "A400M"},
                new Item {Value = "6", Label = "ATR"},
                new Item {Value = "7", Label = "Logistics"}
            };


            //Init Secteur 
            SecteurListe = new Item[]
            {
                new Item {Value = "1", Label = "Air Inlet"},
                new Item {Value = "2", Label = "Aileron"},
                new Item {Value = "3", Label = "CWB"},
                new Item {Value = "4", Label = "Fin"},
                new Item {Value = "5", Label = "Keelbeam"},
                new Item {Value = "6", Label = "Logistics"},
                new Item {Value = "7", Label = "Radome"},
                new Item {Value = "8", Label = "Rudder"}

            };


            //Init Statut 
            StatutListe = new Item[]
            {
                new Item {Value = "1", Label = "Stocke"},
                new Item {Value = "2", Label = "En Service"},
                new Item {Value = "3", Label = "En Maintenace"},
                new Item {Value = "4", Label = "Detruit"}
            };


            //Init Suivi 
            SuiviListe = new Item[]
            {
                new Item {Value = "1", Label = "Oui"},
                new Item {Value = "2", Label = "Non"}
            };


            //Init Type 
            TypeListe = new Item[]
            {
                new Item {Value = "1", Label = "Bache"},
                new Item {Value = "2", Label = "Palonnier"},
                new Item {Value = "3", Label = "Ferrure"},
                new Item {Value = "4", Label = "Supply point"},
                new Item {Value = "5", Label = "Congelateur"},
                new Item {Value = "6", Label = "Micro-ondes"},
                new Item {Value = "7", Label = "Palettier"},
                new Item {Value = "8", Label = "Etagere"},
                new Item {Value = "9", Label = "Raletier"},
                new Item {Value = "10", Label = "Cantilever"},
                new Item {Value = "11", Label = "Jig Transport"},
                new Item {Value = "12", Label = "Rack dynamique"},
                new Item {Value = "13", Label = "Remorque"},
                new Item {Value = "14", Label = "Roll"}
            };
        }
    }
}