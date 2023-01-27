namespace Trello
{
    public class Commentaire
    {
        public int ID {get;set;}
        public string Contenu {get;set;}
        public DateTime Date_creation {get;set;}
        public Carte ID_carte {get;set;}
        public Utilisateur ID_utilisateur {get;set;}    
        public Commentaire()
        {
            this.ID=0;
            this.Contenu="";
            this.Date_creation=new DateTime();
            this.ID_carte=new Carte();
            this.ID_utilisateur=new Utilisateur();        
        }

        public Commentaire(string Contenu, DateTime Date_creation, Carte ID_carte, Utilisateur ID_utilisateur)
        {
            this.ID=0;
            this.Contenu=Contenu;
            this.Date_creation=Date_creation;
            this.ID_carte=ID_carte;
            this.ID_utilisateur=ID_utilisateur;        
        }
    }
}