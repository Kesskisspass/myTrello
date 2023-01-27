namespace Trello
{
    public class Utilisateur{
        public int ID {get;set;}
        public string Nom {get;set;}
        public string Adresse_email {get;set;}
        public string Mot_de_passe {get;set;}
        public DateTime Date_inscription {get;set;}
        public ICollection<Projet> Collec_projet;
        public ICollection<Commentaire> Collec_com;
    
        public Utilisateur()
        {
            this.ID=0;
            this.Nom="";
            this.Adresse_email="";
            this.Mot_de_passe="";
            this.Date_inscription=new DateTime();        
        }

        public Utilisateur(string Nom, string Adresse_email, string Mot_de_passe, DateTime Date_inscription)
        {
            this.ID=0;
            this.Nom=Nom;
            this.Adresse_email=Adresse_email;
            this.Mot_de_passe=Mot_de_passe;
            this.Date_inscription=Date_inscription;
        }
    }
}