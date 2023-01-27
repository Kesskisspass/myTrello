namespace Trello
{
    public class Projet
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Contenu { get; set; }
        public DateTime Date { get; set; }
        public Utilisateur ID_Utilisateur { get; set; }
        public ICollection<Liste> Collec_liste { get; set; } = new List<Liste>();
        public ICollection<Utilisateur> Collec_utilisateur;

        public Projet()
        {
            this.ID = 0;
            this.Nom = "";
            this.Contenu = "";
            this.Date = new DateTime();
            this.ID_Utilisateur = new Utilisateur();
        }

        public Projet(string Nom, string Contenu, DateTime Date, Utilisateur ID_Utilisateur)
        {
            this.ID = 0;
            this.Nom = Nom;
            this.Contenu = Contenu;
            this.Date = Date;
            this.ID_Utilisateur = ID_Utilisateur;
        }

        // public void addListe(Liste liste)
        // {
        //     var context = new Context();
        //     Repository<Liste> repoListe = new Repository<Liste>(context);
        //     // Liste listToAdd = new Liste()
        //     liste.Projet = this;
        //     // Collec_liste.Add(liste);
        //     repoListe.add(liste);
        // }
        // public void addListe2(Liste liste)
        // {
        //     liste.Projet = this;
        //     Collec_liste.Add(liste);
        // }

        // public List<Liste> getAllLinkedLists()
        // {
        //     re
        // }

        // public ICollection<Liste> getAllListes()
        // {
        //     return Collec_liste;
        // }
        public void showLists()
        {
            // ICollection<Liste> allListes = getAllListes();
            foreach (Liste l in Collec_liste)
            {
                System.Console.WriteLine(l.Nom);
            }
        }

    }
}