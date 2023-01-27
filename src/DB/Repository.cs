using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Trello
{
    public class Repository<T> where T : class
    {
        private Context _db;
        private DbSet<T> _table;

        public Repository(Context db)
        {
            _db = db;
            _table = _db.Set<T>();
        }


        // Part 1
        // CRUD

        // CREATE
        public void add(T entity)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _table.Add(entity);
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    System.Console.WriteLine("Add : transaction annulée");
                }
            }
        }

        // READ
        // getById
        public T getById(int id)
        {
            if (_table.Find(id) != null)
            {
                try
                {
                    return _table.Find(id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            return null;
        }

        // getAll
        public List<T> getAll()
        {
            return _table.ToList();
        }

        // UPDATE
        public void update(int id, T newEntity)
        {
            var entityToUpdate = getById(id);
            if (entityToUpdate != null)
            {
                using (var transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        _table.Entry(entityToUpdate).CurrentValues.SetValues(newEntity);
                        _db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }

        }

        // DELETE
        public void remove(int id)
        {

            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var entity = getById(id);
                    _table.Remove(entity);
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        // Part 3
        // Récupération des entités liées

        // Renvoie toutes les listes liées à un projet (param: id projet)
        public List<Liste> getListesOfProjet(Projet p)
        {
            // Projet p = _db.Projets.Find(id);
            List<Liste> allListes = _db.Listes
                                    .Where(l => l.Projet == p)
                                    .ToList();
            return allListes;
        }

        // Renvoie toutes les cartes liées à une liste (param: id liste)
        public List<Carte> getCartesOfListe(Liste l)
        {
            // Liste l = _db.Listes.Find(id);
            List<Carte> allCartes = _db.Cartes
                                    .Where(c => c.ID_liste == l)
                                    .ToList();
            return allCartes;
        }

        // Renvoie toutes les projets liées à un utilisateur (param: id utilisateur)
        public List<Projet> getProjetsOfUtilisateur(Utilisateur u)
        {
            // Utilisateur u = _db.Utilisateurs.Find(id);
            List<Projet> allProjets = _db.Projets
                                    .Where(p => p.ID_Utilisateur == u)
                                    .ToList();
            return allProjets;
        }

        // Renvoie toutes les commentaires liées à un utilisateur (param: id utilisateur)
        public List<Commentaire> getCommentairesOfUtilisateur(Utilisateur u)
        {
            // Utilisateur u = _db.Utilisateurs.Find(id);
            List<Commentaire> allCommentaires = _db.Commentaires
                                    .Where(c => c.ID_utilisateur == u)
                                    .ToList();
            return allCommentaires;
        }

        // Renvoie tous les commentaires d'une carte (param: id_carte)
        public List<Commentaire> getCommentairesOfCarte(Carte c)
        {
            // Carte c = _db.Cartes.Find(id);
            List<Commentaire> allCommentaires = _db.Commentaires
                                    .Where(co => co.ID_carte == c)
                                    .ToList();
            return allCommentaires;
        }
        // Renvoie toutes les etiquettes d'une carte (param: id_carte)
        public List<Etiquette> getEtiquettesOfCarte(Carte c)
        {
            // Carte c = _db.Cartes.Find(id);
            List<Etiquette> allEtiquettes = _db.Etiquettes
                                    .Where(e => e.ID_carte == c)
                                    .ToList();
            return allEtiquettes;

        }

        // Part 5 Authentication
        public void authent(string entree, string password)
        {
            var users = _db.Utilisateurs.ToList();
            bool connected = false;

            foreach (Utilisateur u in users)
            {
                if (u.Nom == entree || u.Adresse_email == entree)
                {
                    if (u.Mot_de_passe == password)
                    {
                        System.Console.WriteLine("Connecté");
                        connected = true;
                        break;
                    }
                }
            }
            if (!connected)
                System.Console.WriteLine("Mauvais identifiant/password");

        }

        // Part 6 Recherche
        public void search(string word)
        {
            word = word.ToLower();
            searchUtilisateur(word);
            searchProjet(word);
            searchListes(word);
            searchCartes(word);

        }
        public void searchUtilisateur(string word)
        {
            List<Utilisateur> users = _db.Utilisateurs.ToList();
            var results = users.Where(e => e.Nom.ToLower().Contains(word)
            || e.Adresse_email.ToLower().Contains(word));
            if (results.Count() > 0)
            {
                System.Console.WriteLine("Utilisateurs correspondant à la recherche :");
                foreach (Utilisateur r in results)
                {
                    System.Console.WriteLine("- " + r.Nom + " - " + r.Adresse_email);
                }
                System.Console.WriteLine("####################");
            }
        }
        public void searchProjet(string word)
        {
            List<Projet> projets = _db.Projets.ToList();
            var results = projets.Where(e => e.Nom.ToLower().Contains(word)
            || e.Contenu.ToLower().Contains(word));
            if (results.Count() > 0)
            {
                System.Console.WriteLine("Projets correspondant à la recherche :");
                foreach (Projet r in results)
                {
                    System.Console.WriteLine("- " + r.Nom + " - " + r.Contenu);
                }
                System.Console.WriteLine("####################");
            }
        }
        public void searchListes(string word)
        {
            List<Liste> listes = _db.Listes.ToList();
            var results = listes.Where(e => e.Nom.ToLower().Contains(word));
            if (results.Count() > 0)
            {
                System.Console.WriteLine("Listes correspondant à la recherche :");
                foreach (Liste r in results)
                {
                    System.Console.WriteLine("- " + r.Nom);
                }
                System.Console.WriteLine("####################");
            }
        }
        public void searchCartes(string word)
        {
            List<Carte> cartes = _db.Cartes.ToList();
            var results = cartes.Where(e => e.Titre.ToLower().Contains(word)
            || e.Contenu.ToLower().Contains(word));
            if (results.Count() > 0)
            {
                System.Console.WriteLine("Cartes correspondant à la recherche :");
                foreach (Carte r in results)
                {
                    System.Console.WriteLine("- " + r.Titre + " - " + r.Contenu);
                }
                System.Console.WriteLine("####################");
            }
        }

    }
}