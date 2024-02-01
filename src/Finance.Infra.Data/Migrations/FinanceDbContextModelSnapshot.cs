﻿// <auto-generated />
using System;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Finance.Infra.Data.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    partial class FinanceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Finance.Domain.Entity.Entities.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SystemExpenseId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("SystemIncomeId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.HasKey("Id");

                    b.HasIndex("SystemExpenseId");

                    b.HasIndex("SystemIncomeId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Entities.Expenses.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataVencimencimento");

                    b.Property<int>("Month")
                        .HasColumnType("int")
                        .HasColumnName("Mes");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OverdueExpense")
                        .HasColumnType("datetime2")
                        .HasColumnName("DespesaEmAtraso");

                    b.Property<bool>("PayedOut")
                        .HasColumnType("bit")
                        .HasColumnName("Pago");

                    b.Property<DateTime>("RegistrationChangeDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAlteracaoCadastro");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCadastro");

                    b.Property<int>("TransactionTypes")
                        .HasColumnType("int")
                        .HasColumnName("TipoTransacao");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Valor");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.Property<DateTime>("paymentDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataPagamento");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Despesa");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Entities.Incomes.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("IncameDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInvestimento");

                    b.Property<int>("Month")
                        .HasColumnType("int")
                        .HasColumnName("Mes");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationChangeDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAlteracaoCadastro");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCadastro");

                    b.Property<int>("TransactionTypes")
                        .HasColumnType("int")
                        .HasColumnName("TipoTransacao");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Valor");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Investimento");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Entities.Systems.SystemExpenses.SystemExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DayMonthlyBookClose")
                        .HasColumnType("int")
                        .HasColumnName("DiaFechamentoMensal");

                    b.Property<bool>("GenerateExpensesCopy")
                        .HasColumnType("bit")
                        .HasColumnName("GerarCopiaDespesa");

                    b.Property<int>("Month")
                        .HasColumnType("int")
                        .HasColumnName("Mes");

                    b.Property<int>("MonthCopy")
                        .HasColumnType("int")
                        .HasColumnName("MesCopia");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.Property<int>("YearCopy")
                        .HasColumnType("int")
                        .HasColumnName("AnoCopia");

                    b.HasKey("Id");

                    b.ToTable("SistemaDespesa");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Entities.Systems.SystemIncomes.SystemIncome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DayMonthlyBookClose")
                        .HasColumnType("int")
                        .HasColumnName("DiaFechamentoMensal");

                    b.Property<int>("Month")
                        .HasColumnType("int")
                        .HasColumnName("Mes");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.HasKey("Id");

                    b.ToTable("SistemaInvestiemnto");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Entities.Users.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Finance.Domain.Entity.Entities.Users.Systems.UserSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ActualSystemMonth")
                        .HasColumnType("bit")
                        .HasColumnName("MesAtual");

                    b.Property<bool>("Administrator")
                        .HasColumnType("bit")
                        .HasColumnName("Administrador");

                    b.Property<int>("SystemExpenseId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("SystemIncomeId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EmailUsuario");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeUsuario");

                    b.HasKey("Id");

                    b.HasIndex("SystemExpenseId");

                    b.HasIndex("SystemIncomeId");

                    b.ToTable("UsuarioSistema");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Finance.Domain.Entity.Entities.Categories.Category", b =>
                {
                    b.HasOne("Finance.Domain.Entity.Entities.Systems.SystemExpenses.SystemExpense", "SystemExpense")
                        .WithMany()
                        .HasForeignKey("SystemExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finance.Domain.Entity.Entities.Systems.SystemIncomes.SystemIncome", "SystemIncome")
                        .WithMany()
                        .HasForeignKey("SystemIncomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemExpense");

                    b.Navigation("SystemIncome");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Entities.Expenses.Expense", b =>
                {
                    b.HasOne("Finance.Domain.Entity.Entities.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Entities.Incomes.Income", b =>
                {
                    b.HasOne("Finance.Domain.Entity.Entities.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Entities.Users.Systems.UserSystem", b =>
                {
                    b.HasOne("Finance.Domain.Entity.Entities.Systems.SystemExpenses.SystemExpense", "SystemExpense")
                        .WithMany()
                        .HasForeignKey("SystemExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finance.Domain.Entity.Entities.Systems.SystemIncomes.SystemIncome", "SystemIncome")
                        .WithMany()
                        .HasForeignKey("SystemIncomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemExpense");

                    b.Navigation("SystemIncome");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Finance.Domain.Entity.Entities.Users.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Finance.Domain.Entity.Entities.Users.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finance.Domain.Entity.Entities.Users.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Finance.Domain.Entity.Entities.Users.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
