using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Project;

#nullable disable

namespace Project.Model
{
    public partial class RequestContext : DbContext
    {
        public RequestContext()
        {
        }

        public RequestContext(DbContextOptions<RequestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationForChangingTheNumberOfConsumer> ApplicationForChangingTheNumberOfConsumers { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<FacilityConsumer> FacilityConsumers { get; set; }
        public virtual DbSet<ListOfConsumersForTheApplication> ListOfConsumersForTheApplications { get; set; }
        public virtual DbSet<ListOfConsumersForTheRecalculationFee> ListOfConsumersForTheRecalculationFees { get; set; }
        public virtual DbSet<PersonalAccount> PersonalAccounts { get; set; }
        public virtual DbSet<RequestChangeParametersPersonalAccount> RequestChangeParametersPersonalAccounts { get; set; }
        public virtual DbSet<RequestCommissioningIndividualMeteringDevice> RequestCommissioningIndividualMeteringDevices { get; set; }
        public virtual DbSet<RequestCreatePersonalAccount> RequestCreatePersonalAccounts { get; set; }
        public virtual DbSet<RequestRecalculationFee> RequestRecalculationFees { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TSJSMEG;Database=Request;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<ApplicationForChangingTheNumberOfConsumer>(entity =>
            {
                entity.Property(e => e.AddressFacility).HasMaxLength(50);

                entity.Property(e => e.DateofApplicationSubmission).HasColumnType("date");

                entity.Property(e => e.DepartmentCode).HasMaxLength(7);

                entity.Property(e => e.FullNameApplicant).HasMaxLength(30);

                entity.Property(e => e.PassportDate).HasColumnType("date");

                entity.Property(e => e.PassportId).HasMaxLength(6);

                entity.Property(e => e.PassportSeries).HasMaxLength(4);

                entity.Property(e => e.ReviewStatus)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("(N'На рассмотрении')");

                entity.Property(e => e.Telephone).HasMaxLength(10);
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("Facility");

                entity.Property(e => e.Address).HasMaxLength(50);
            });

            modelBuilder.Entity<FacilityConsumer>(entity =>
            {
                entity.ToTable("FacilityConsumer");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasComment("Для временной регистрации");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.IdFacilityNavigation)
                    .WithMany(p => p.FacilityConsumers)
                    .HasForeignKey(d => d.IdFacility)
                    .HasConstraintName("FK_FacilityConsumer_Facility");
            });

            modelBuilder.Entity<ListOfConsumersForTheApplication>(entity =>
            {
                entity.ToTable("ListOfConsumersForTheApplication");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasComment("Для временной регистрации");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(25);

                entity.HasOne(d => d.IdApplicationForChangingTheNumberOfConsumersNavigation)
                    .WithMany(p => p.ListOfConsumersForTheApplications)
                    .HasForeignKey(d => d.IdApplicationForChangingTheNumberOfConsumers)
                    .HasConstraintName("FK_ListOfConsumersForTheApplication_ApplicationForChangingTheNumberOfConsumers");
            });

            modelBuilder.Entity<ListOfConsumersForTheRecalculationFee>(entity =>
            {
                entity.ToTable("ListOfConsumersForTheRecalculationFee");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasComment("Для временной регистрации");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdRequestRecalculationFeeNavigation)
                    .WithMany(p => p.ListOfConsumersForTheRecalculationFees)
                    .HasForeignKey(d => d.IdRequestRecalculationFee)
                    .HasConstraintName("FK_ListOfConsumersForTheRecalculationFee_RequestRecalculationFee");
            });

            modelBuilder.Entity<PersonalAccount>(entity =>
            {
                entity.ToTable("PersonalAccount");

                entity.Property(e => e.ShareSize).HasMaxLength(10);

                entity.HasOne(d => d.IdFacilityNavigation)
                    .WithMany(p => p.PersonalAccounts)
                    .HasForeignKey(d => d.IdFacility)
                    .HasConstraintName("FK_PersonalAccount_Facility");

                entity.HasOne(d => d.IdSubscriberNavigation)
                    .WithMany(p => p.PersonalAccounts)
                    .HasForeignKey(d => d.IdSubscriber)
                    .HasConstraintName("FK_PersonalAccount_Subscriber");
            });

            modelBuilder.Entity<RequestChangeParametersPersonalAccount>(entity =>
            {
                entity.ToTable("RequestChangeParametersPersonalAccount");

                entity.Property(e => e.AddressFacility).HasMaxLength(50);

                entity.Property(e => e.DateofApplicationSubmission).HasColumnType("date");

                entity.Property(e => e.DepartmentCode).HasMaxLength(7);

                entity.Property(e => e.FullName).HasMaxLength(30);

                entity.Property(e => e.PassportDate).HasColumnType("date");

                entity.Property(e => e.PassportId).HasMaxLength(6);

                entity.Property(e => e.PassportSeries).HasMaxLength(4);

                entity.Property(e => e.ReviewStatus)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("(N'На рассмотрении')");

                entity.Property(e => e.ShareSize).HasMaxLength(10);

                entity.Property(e => e.Telephone).HasMaxLength(10);
            });

            modelBuilder.Entity<RequestCommissioningIndividualMeteringDevice>(entity =>
            {
                entity.ToTable("RequestCommissioningIndividualMeteringDevice");

                entity.Property(e => e.DateCommissioning).HasColumnType("date");

                entity.Property(e => e.DateofApplicationSubmission).HasColumnType("date");

                entity.Property(e => e.DeviceReadingsAtTheTimeOfAdmission).HasMaxLength(10);

                entity.Property(e => e.FactoryNumber).HasMaxLength(15);

                entity.Property(e => e.FullName).HasMaxLength(30);

                entity.Property(e => e.InstallationLocation).HasMaxLength(20);

                entity.Property(e => e.ReviewStatus).HasMaxLength(15);

                entity.Property(e => e.Service).HasMaxLength(15);

                entity.Property(e => e.TypeDevice).HasMaxLength(20);
            });

            modelBuilder.Entity<RequestCreatePersonalAccount>(entity =>
            {
                entity.ToTable("RequestCreatePersonalAccount");

                entity.Property(e => e.AddressFacility).HasMaxLength(50);

                entity.Property(e => e.DateofApplicationSubmission).HasColumnType("date");

                entity.Property(e => e.DepartmentCode).HasMaxLength(7);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.PassportDate).HasColumnType("date");

                entity.Property(e => e.PassportId).HasMaxLength(6);

                entity.Property(e => e.PassportSeries).HasMaxLength(4);

                entity.Property(e => e.ReviewStatus)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("(N'На рассмотрении')")
                    .HasComment("На рассмотрении, отклонена, одобрена");

                entity.Property(e => e.ShareSize).HasMaxLength(10);

                entity.Property(e => e.Telephone).HasMaxLength(10);
            });

            modelBuilder.Entity<RequestRecalculationFee>(entity =>
            {
                entity.ToTable("RequestRecalculationFee");

                entity.Property(e => e.DateofApplicationSubmission).HasColumnType("date");

                entity.Property(e => e.DepartmentCode).HasMaxLength(7);

                entity.Property(e => e.FullName).HasMaxLength(30);

                entity.Property(e => e.PassportDate).HasColumnType("date");

                entity.Property(e => e.PassportId).HasMaxLength(6);

                entity.Property(e => e.PassportSeries).HasMaxLength(4);

                entity.Property(e => e.ReviewStatus)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("(N'На рассмотрении')");

                entity.Property(e => e.Telephone).HasMaxLength(10);
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.ToTable("Subscriber");

                entity.Property(e => e.DepartmentCode).HasMaxLength(7);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(20);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.PassportDate).HasColumnType("date");

                entity.Property(e => e.PassportId).HasMaxLength(6);

                entity.Property(e => e.PassportSeries).HasMaxLength(4);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
