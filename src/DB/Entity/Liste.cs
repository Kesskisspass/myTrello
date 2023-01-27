namespace Trello
{
    public class Liste
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public Projet Projet { get; set; }
        public ICollection<Carte> Collec_carte;

        public Liste()
        {
            this.ID = 0;
            this.Nom = "";
            this.Projet = new Projet();
        }

        public Liste(string Nom, Projet Projet)
        {
            this.ID = 0;
            this.Nom = Nom;
            this.Projet = Projet;
        }

        public void addCarte(Repository<Carte> repoCarte, string Titre, string Contenu)
        {
            Liste ID_liste = this;
            DateTime Date = DateTime.Today;
            repoCarte.add(new Carte(Titre, Contenu, Date, ID_liste));
        }


    }
}