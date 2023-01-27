using Microsoft.EntityFrameworkCore;
namespace Trello
{
    public class Context : DbContext
    {
        // Liste tables
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Liste> Listes { get; set; }
        public DbSet<Carte> Cartes { get; set; }
        public DbSet<Etiquette> Etiquettes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }

        public Context()
        {
            //Redéfinition BDD au lancement
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //Config base BDD
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=myTrello123;User=admin;Password=ouicmoa");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relation Carte
            modelBuilder.Entity<Carte>(entity =>
            {
                //Une carte a une seule liste mais une liste a plusieurs cartes
                entity.HasOne(x => x.ID_liste)
                .WithMany(y => y.Collec_carte);
            });

            //Relation Commentaire
            modelBuilder.Entity<Commentaire>(entity =>
           {
               //FK carte
               entity.HasOne(x => x.ID_carte)
               .WithMany(y => y.Collec_comm);
               //FK utilisateur
               entity.HasOne(x => x.ID_utilisateur)
               .WithMany(y => y.Collec_com);
           });

            //Relation Utilisateur
            modelBuilder.Entity<Utilisateur>(entity =>
            {
                //Many to many créant la table UtilisateurProjet
                entity.HasMany(x => x.Collec_projet)
                .WithMany(y => y.Collec_utilisateur);

            });

            //Relation Liste
            modelBuilder.Entity<Liste>(entity =>
            {
                // Une liste a une seule project_ID mais le projetct_id a plusieur listes
                entity.HasOne(x => x.Projet)
                .WithMany(y => y.Collec_liste);
            });


            //Relation Etiquette
            modelBuilder.Entity<Etiquette>(entity =>
            {

                entity.HasOne(x => x.ID_carte)
                .WithMany(y => y.Collec_etiquette);
            });
        }

    }

}