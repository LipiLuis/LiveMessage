using System;
using LiveMessageAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace LiveMessageAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<ConversationModel> Conversations { get; set; }
        public DbSet<NotificationModel> Notifications { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aqui você pode configurar o mapeamento das entidades e suas relações,
            // se necessário, usando o Fluent API do Entity Framework Core.

            
            modelBuilder.Entity<ConversationModel>()
        .Ignore(e => e.ParticipantIds);

            // Exemplo de configuração para a entidade UserModel:
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.Id);

            // Exemplo de configuração para a entidade MessageModel:
            modelBuilder.Entity<MessageModel>()
                .HasKey(m => m.Id);
            modelBuilder.Entity<MessageModel>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId);
            modelBuilder.Entity<MessageModel>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId);

            // Configurações adicionais para outras entidades, se necessário.

            base.OnModelCreating(modelBuilder);
        }
    }
}

