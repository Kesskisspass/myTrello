namespace Trello
{
    public class Etiquette
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Couleur { get; set; }
        public Carte ID_carte { get; set; }
        public Etiquette()
        {
            this.ID = 0;
            this.Nom = "";
            this.Couleur = "";
            this.ID_carte = new Carte();
        }

        public Etiquette(string Nom, string Couleur, Carte ID_carte)
        {
            this.ID = 0;
            this.Nom = Nom;
            this.Couleur = Couleur;
            this.ID_carte = ID_carte;
        }
    }
}