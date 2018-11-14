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
                new Item {Value = "1", Label = "Assemblage General"},
                new Item {Value = "2", Label = "Assemblage S/E"},
                new Item {Value = "3", Label = "Finition"},
                new Item {Value = "4", Label = "Magasin Consommables (W20)"},
                new Item {Value = "5", Label = "Magasin Equipement (W15G)"},
                new Item {Value = "6", Label = "Magasin Matieres Composites (M0)"},
                new Item {Value = "7", Label = "Magasin Matieres Dangereuses (032)"},
                new Item {Value = "8", Label = "Magasin Matieres Metalliques (F07 + Parc)"},
                new Item {Value = "9", Label = "Magasin Outils Coupants (C12)"},
                new Item {Value = "10", Label = "Market Place Grandes Pieces (I05)"},
                new Item {Value = "11", Label = "Market Place Petites Pieces (W15D)"},
                new Item {Value = "12", Label = "Pieces Elementaires Composites"},
                new Item {Value = "13", Label = "Pieces Elementaires Metalliques"},
                new Item {Value = "14", Label = "Autres"}
            };


            //Init Localisation 
            LocalisationListe = new Item[]
            {
                new Item {Value = "1", Label = "A6"},
                new Item {Value = "2", Label = "A15"},
                new Item {Value = "3", Label = "C1"},
                new Item {Value = "4", Label = "C4"},
                new Item {Value = "5", Label = "Flower"},
                new Item {Value = "6", Label = "ZB12"}
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
                new Item {Value = "6", Label = "ATR"}
            };


            //Init Secteur 
            SecteurListe = new Item[]
            {
                new Item {Value = "1", Label = "Air Inlet"},
                new Item {Value = "2", Label = "CWB"},
                new Item {Value = "3", Label = "Fin"},
                new Item {Value = "4", Label = "Keelbeam"},
                new Item {Value = "5", Label = "Logistics"},
                new Item {Value = "6", Label = "Radome"},
                new Item {Value = "7", Label = "Rudder"}

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
                new Item {Value = "2", Label = "Caisse"},
                new Item {Value = "3", Label = "Chariot"},
                new Item {Value = "4", Label = "Congélateur"},
                new Item {Value = "5", Label = "Etagere"},
                new Item {Value = "6", Label = "Ferrure"},
                new Item {Value = "7", Label = "Micro-Ondes"},
                new Item {Value = "8", Label = "Palettier"},
                new Item {Value = "9", Label = "Palonnier"},
                new Item {Value = "10", Label = "Raletier"},
                new Item {Value = "11", Label = "Roll"},
                new Item {Value = "12", Label = "Supply Point"},
                new Item {Value = "13", Label = "Traine"}
            };
        }
    }
}