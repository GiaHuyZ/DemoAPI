using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class OAnQuanGameContext : IdentityDbContext<UserAccount, UserRole, int>
    {
        public OAnQuanGameContext()
        {
        }

        public OAnQuanGameContext(DbContextOptions<OAnQuanGameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<AchievementUser> AchievementUsers { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<Iventory> Iventorys { get; set; }
        public virtual DbSet<LoginHistory> LoginHistories { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<RedeemCode> RedeemCodes { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserRedeemCode> UserRedeemCodes { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.ToTable("Achievement");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AchievementName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("achievementName");

                entity.Property(e => e.Reward)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("reward");
            });

            modelBuilder.Entity<AchievementUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AchievementId })
                    .HasName("pk_achievementUser_id");

                entity.ToTable("AchievementUser");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.AchievementId).HasColumnName("achievementId");

                entity.Property(e => e.IsDone).HasColumnName("isDone");

                entity.Property(e => e.Progress).HasColumnName("progress");

                entity.HasOne(d => d.Achievement)
                    .WithMany(p => p.AchievementUsers)
                    .HasForeignKey(d => d.AchievementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Achieveme__achie__59063A47");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AchievementUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Achieveme__userI__5812160E");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("endTime");

                entity.Property(e => e.NumberOfPlayer).HasColumnName("number_of_player");

                entity.Property(e => e.PlayerStartId).HasColumnName("player_start_Id");

                entity.Property(e => e.ResultId).HasColumnName("resultId");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");

                entity.HasOne(d => d.PlayerStart)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.PlayerStartId)
                    .HasConstraintName("FK__Game__player_sta__48CFD27E");

                entity.HasOne(d => d.Result)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.ResultId)
                    .HasConstraintName("FK__Game__resultId__49C3F6B7");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("itemDescription");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("itemName");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK__Item__typeId__3D5E1FD2");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("ItemType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("typeName");
            });

            modelBuilder.Entity<Iventory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Iventories)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__Iventorys__itemI__403A8C7D");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Iventories)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK__Iventorys__playe__412EB0B6");
            });

            modelBuilder.Entity<LoginHistory>(entity =>
            {
                entity.ToTable("LoginHistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IpDevice)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IP_Device");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("login_time");

                entity.Property(e => e.LogoutTime)
                    .HasColumnType("datetime")
                    .HasColumnName("logout_time");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.LoginHistories)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK__LoginHist__playe__440B1D61");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.ToTable("Participant");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Participa__gameI__4D94879B");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK__Participa__playe__4CA06362");
            });

            modelBuilder.Entity<RedeemCode>(entity =>
            {
                entity.ToTable("RedeemCode");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("code");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("Result");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("UserAccount");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("avatar");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nickName");

                //entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDate");

                //entity.HasOne(d => d.Role)
                //    .WithMany(p => p.UserAccounts)
                //    .HasForeignKey(d => d.RoleId)
                //    .HasConstraintName("FK__UserAccou__roleI__38996AB5");
            });

            modelBuilder.Entity<UserRedeemCode>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RedeemId })
                    .HasName("pk_redeemCode_id");

                entity.ToTable("UserRedeemCode");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.RedeemId).HasColumnName("redeemId");

                entity.HasOne(d => d.Redeem)
                    .WithMany(p => p.UserRedeemCodes)
                    .HasForeignKey(d => d.RedeemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRedee__redee__534D60F1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRedeemCodes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRedee__userI__52593CB8");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
