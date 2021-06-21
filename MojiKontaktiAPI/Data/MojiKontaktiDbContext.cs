using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MojiKontaktiAPI.Models
{
    public class MojiKontaktiDbContext : DbContext
    {
        public MojiKontaktiDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Kontakt> Kontakti { get; set; }
        public virtual DbSet<EmailAdresa> EmailAdrese { get; set; }
        public virtual DbSet<BrojTelefona> BrojeviTelefona { get; set; }
        public virtual DbSet<Tag> Tagovi { get; set; }

        // Seeding the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kontakt>().HasData(
                new Kontakt
                {
                    KontaktID = 15,
                    Ime = "Ante",
                    Prezime = "Gotovac",
                    Bookmarkiran = false,
                },
                new Kontakt
                {
                    KontaktID = 16,
                    Ime = "Josip",
                    Prezime = "Gabrilović",
                    Bookmarkiran = false,
                },
                new Kontakt
                {
                    KontaktID = 17,
                    Ime = "Mirna",
                    Prezime = "Medić",
                    Nadimak = "Maca",
                    Bookmarkiran = true,
                },
                new Kontakt
                {
                    KontaktID = 18,
                    Ime = "Bruno",
                    Prezime = "Medaković",
                    Bookmarkiran = false,
                },
                new Kontakt
                {
                    KontaktID = 19,
                    Ime = "Toni",
                    Prezime = "Kazinoti",
                    Nadimak = "Kazi",
                    Bookmarkiran = true,
                }
            );

            modelBuilder.Entity<BrojTelefona>().HasData(
                new BrojTelefona
                {
                    BrojTelefonaID = 15,
                    KontaktID = 15,
                    PozivniBrojDrzave = "385",
                    Broj = "923587894",
                    Opis = "Posao"
                },
                new BrojTelefona
                {
                    BrojTelefonaID = 16,
                    KontaktID = 16,
                    PozivniBrojDrzave = "385",
                    Broj = "958796574",
                    Opis = "Bolnica"
                },
                new BrojTelefona
                {
                    BrojTelefonaID = 17,
                    KontaktID = 17,
                    PozivniBrojDrzave = "385",
                    Broj = "915647893",
                    Opis = "Privatni"
                },
                new BrojTelefona
                {
                    BrojTelefonaID = 18,
                    KontaktID = 18,
                    PozivniBrojDrzave = "385",
                    Broj = "986542389",
                    Opis = "Posao"
                },
                new BrojTelefona
                {
                    BrojTelefonaID = 19,
                    KontaktID = 19,
                    PozivniBrojDrzave = "385",
                    Broj = "923587894",
                    Opis = "Privatni"
                },
                new BrojTelefona
                {
                    BrojTelefonaID = 20,
                    KontaktID = 19,
                    PozivniBrojDrzave = "385",
                    Broj = "953652178",
                    Opis = "Posao"
                }
            );

            modelBuilder.Entity<EmailAdresa>().HasData(
                new EmailAdresa
                {
                    EmailAdresaID = 15,
                    KontaktID = 15,
                    Email = "ante.g@hotmail.com",
                },
                new EmailAdresa
                {
                    EmailAdresaID = 16,
                    KontaktID = 17,
                    Email = "mirnaaaa@gmail.com",
                },
                new EmailAdresa
                {
                    EmailAdresaID = 17,
                    KontaktID = 19,
                    Email = "toni.kazinoti@gmail.com",
                },
                new EmailAdresa
                {
                    EmailAdresaID = 18,
                    KontaktID = 19,
                    Email = "tk48322@unist.hr",
                }
            );

            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    TagID = 15,
                    KontaktID = 15,
                    Naziv = "Prijatelj"
                },
                new Tag
                {
                    TagID = 16,
                    KontaktID = 15,
                    Naziv = "Zvati u 8h"
                },
                new Tag
                {
                    TagID = 17,
                    KontaktID = 17,
                    Naziv = "Rođak"
                },
                new Tag
                {
                    TagID = 18,
                    KontaktID = 19,
                    Naziv = "Brat"
                },
                new Tag
                {
                    TagID = 19,
                    KontaktID = 19,
                    Naziv = "Najjači"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
