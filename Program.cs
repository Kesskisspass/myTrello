using System.ComponentModel;
using Trello;
// Console.WriteLine("Hello, World!");

var context = new Context();
Repository<Utilisateur> repo = new Repository<Utilisateur>(context);
Repository<Projet> repoProjet = new Repository<Projet>(context);
Repository<Liste> repoListe = new Repository<Liste>(context);
Repository<Carte> repoCarte = new Repository<Carte>(context);
Repository<Etiquette> repoEtiquette = new Repository<Etiquette>(context);
Repository<Commentaire> repoCommentaire = new Repository<Commentaire>(context);

// Utilisateur tom = new Utilisateur("Tom SELECT", "tom@magnumsql.com", "starsky&hutch", new DateTime(2005, 05, 01));
// Utilisateur neo = new Utilisateur("Thomas ANDERSON", "neo@one.com", "smithIsAPussy", new DateTime(2012, 06, 12));
// Utilisateur paul = new Utilisateur("Paul ATREIDES", "spicypaulo@arrakis.com", "bigWorm92", new DateTime(2015, 09, 10));

// Projet projet1 = new Projet("CatchBadGuys", "Arrêter les malfrats à Oahu", new DateTime(2005, 05, 01), tom);
// Projet projet2 = new Projet("SaveTrinity", "C'est pas mal clair, il s'agit de sauver Trinity!", new DateTime(2012, 06, 12), neo);
// Projet projet3 = new Projet("SpiceThingsUp", "Prendre le contrôle d'Arrakis", new DateTime(2015, 09, 10), paul);

// Liste liste1 = new Liste("Liste1", projet1);
// Liste liste2 = new Liste("Liste2", projet2);
// Liste liste3 = new Liste("Liste3", projet3);

// Carte carte1 = new Carte("Acheter une voiture rouge", "important, elle va plus vite", new DateTime(2005, 05, 01), liste1);
// Carte carte2 = new Carte("Apprendre le kung fu", "utile pour se défendre!", new DateTime(2012, 06, 12), liste2);
// Carte carte3 = new Carte("Virer les Harkonnen", "Déjà pour se venger, ensuite pour contrôler la planète!", new DateTime(2015, 09, 10), liste3);

// Etiquette rouge = new Etiquette("Bloquant", "rouge", carte1);
// Etiquette bleu = new Etiquette("Urgent", "bleu", carte2);
// Etiquette orange = new Etiquette("LongTerme", "orange", carte3);

// Commentaire comm1 = new Commentaire("La chemise hawaïenne est non négociable!", new DateTime(2005, 05, 12), carte1, tom);
// Commentaire comm2 = new Commentaire("J'aime bien le vert moi, vous en pensez quoi?", new DateTime(2012, 06, 12), carte2, neo);
// Commentaire comm3 = new Commentaire("Coucou les Fremens, vous venez?", new DateTime(2015, 09, 15), carte3, paul);

// repo.add(tom);
// repo.add(neo);
// repo.add(paul);

// repoProjet.add(projet1);
// repoProjet.add(projet2);
// repoProjet.add(projet3);

// repoListe.add(liste1);
// repoListe.add(liste2);
// repoListe.add(liste3);

// repoCarte.add(carte1);
// repoCarte.add(carte2);
// repoCarte.add(carte3);

// repoEtiquette.add(rouge);
// repoEtiquette.add(bleu);
// repoEtiquette.add(orange);

// repoCommentaire.add(comm1);
// repoCommentaire.add(comm2);
// repoCommentaire.add(comm3);

// var maListe = repoListe.getById(1);

// repoProjet.getInfoProjet(2);
// repoListe.getInfoListe(1);
// repo.getInfoUtilisateurCommentaire(1);
// repo.getInfoUtilisateurProjet(1);
// repoCarte.getInfoCarteCommentaires(1);
// repoCarte.getInfoCarteEtiquettes(1);


// repo.authent("Tom SELECT", "starsky&hutch");
// repo.authent("Tom SELECT", "starsky");
// repo.authent("jean", "starsky&hutch");
// repo.search("o");

// Creation de deux fonctions qui affiche une ou l'ensemble des entites demandées (necessite System.ComponentModel;)
void displayOne<T>(T obj)
{
    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
    {
        string name = descriptor.Name;
        object value = descriptor.GetValue(obj);
        Console.WriteLine($"{name}={value}");
    }
}
void displayAll<T>(List<T> entities)
{
    foreach (T entity in entities)
        displayOne(entity);
}

// displayOne(repoCarte.getById(1));
// displayAll(repoCommentaire.getAll());
// displayOne(repo.getById(2));
// displayAll(repoProjet.getAll());


// displayAll(repoCarte.getInfoCarteEtiquettes(1));
// displayOne(repo.getById(1));
// var updatedUser = repo.getById(1);
// updatedUser.Nom = "Tom SELECT";
// repo.update(1, updatedUser);
// displayOne(repo.getById(1));

// Projet p1 = repoProjet.getById(1);
// var l1 = new Liste("bla bla bla", p1);
// p1.addListe2(l1);

// Liste l1 = new Liste("nouvelle liste", p1);
// repoListe.add(l1);
// p1.showLists();

// List<Commentaire> allCommUser1 = repo.getCommentairesOfUtilisateur(3);
// displayAll(allCommUser1);
Utilisateur u1 = repo.getById(1);
// System.Console.WriteLine(u1.GetType());

// displayAll(repo.getCommentairesOfUtilisateur(u1));
// displayAll(repo.getProjetsOfUtilisateur(u1));

// Projet p1 = repoProjet.getById(1);
// displayAll(repoProjet.getListesOfProjet(p1));

// repo.search("ou");
repo.search("i");