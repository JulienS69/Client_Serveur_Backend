using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ORM
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=BDD")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Compte> Compte { get; set; }
        public virtual DbSet<Transaction_Operation> Transaction_Operation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Prenom)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Compte)
                .WithMany(e => e.Client)
                .Map(m => m.ToTable("CompteClient").MapLeftKey("IdClient").MapRightKey("IdCompte"));

            modelBuilder.Entity<Compte>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Compte>()
                .HasMany(e => e.Transaction_Operation)
                .WithRequired(e => e.Compte)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction_Operation>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction_Operation>()
                .Property(e => e.Montant)
                .IsUnicode(false);
        }
    }
}
