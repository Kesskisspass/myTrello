namespace Trello
{
    public class Carte
    {
        public int ID { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }
        public DateTime Date_creation { get; set; }
        public Liste ID_liste { get; set; }
        public ICollection<Commentaire> Collec_comm;
        public ICollection<Etiquette> Collec_etiquette;
        public Carte()
        {
            this.ID = 0;
            this.Titre = "";
            this.Contenu = "";
            this.Date_creation = new DateTime();
            this.ID_liste = new Liste();
        }

        public Carte(string Titre, string Contenu, DateTime Date_creation, Liste ID_liste)
        {
            this.ID = 0;
            this.Titre = Titre;
            this.Contenu = Contenu;
            this.Date_creation = Date_creation;
            this.ID_liste = ID_liste;
        }
        public void changeListe(Liste newListeID)
        {
            this.ID_liste = newListeID;
        }

    }
}