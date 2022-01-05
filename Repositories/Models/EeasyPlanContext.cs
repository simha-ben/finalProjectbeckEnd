using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repositories.Models
{
    public partial class EeasyPlanContext : DbContext
    {
        public EeasyPlanContext()
        {
        }

        public EeasyPlanContext(DbContextOptions<EeasyPlanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Age> Age { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Migdar> Migdar { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<SumOfParticipants> SumOfParticipants { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-AATM9US;Initial Catalog=EeasyPlan;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Age>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.FromUser).HasColumnName("fromUser");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(250);

                entity.Property(e => e.ToUser).HasColumnName("toUser");

                entity.HasOne(d => d.FromUserNavigation)
                    .WithMany(p => p.MessageFromUserNavigation)
                    .HasForeignKey(d => d.FromUser)
                    .HasConstraintName("FK__Message__fromUse__6FE99F9F");

                entity.HasOne(d => d.ToUserNavigation)
                    .WithMany(p => p.MessageToUserNavigation)
                    .HasForeignKey(d => d.ToUser)
                    .HasConstraintName("FK__Message__toUser__70DDC3D8");
            });

            modelBuilder.Entity<Migdar>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Language).HasColumnName("language");

                entity.Property(e => e.Migdar).HasColumnName("migdar");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Programer).HasColumnName("programer");

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publishDate")
                    .HasColumnType("date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Subject).HasColumnName("subject");

                entity.Property(e => e.SumOfParticipants).HasColumnName("sumOfParticipants");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.AgeNavigation)
                    .WithMany(p => p.Program)
                    .HasForeignKey(d => d.Age)
                    .HasConstraintName("FK__Program__age__3B75D760");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.Program)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK__Program__Languag__5FB337D6");

                entity.HasOne(d => d.MigdarNavigation)
                    .WithMany(p => p.Program)
                    .HasForeignKey(d => d.Migdar)
                    .HasConstraintName("FK__Program__Migdar__5EBF139D");

                entity.HasOne(d => d.ProgramerNavigation)
                    .WithMany(p => p.Program)
                    .HasForeignKey(d => d.Programer)
                    .HasConstraintName("FK__Program__program__71D1E811");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.Program)
                    .HasForeignKey(d => d.Subject)
                    .HasConstraintName("FK__Program__subject__47DBAE45");

                entity.HasOne(d => d.SumOfParticipantsNavigation)
                    .WithMany(p => p.Program)
                    .HasForeignKey(d => d.SumOfParticipants)
                    .HasConstraintName("FK__Program__sumOfPa__3C69FB99");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Program)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK__Program__type__3A81B327");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<SumOfParticipants>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
