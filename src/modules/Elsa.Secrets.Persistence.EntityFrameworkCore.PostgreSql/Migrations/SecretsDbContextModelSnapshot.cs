﻿// <auto-generated />
using System;
using Elsa.Secrets.Persistence.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Elsa.Secrets.Persistence.EntityFrameworkCore.PostgreSql.Migrations
{
    [DbContext(typeof(SecretsDbContext))]
    partial class SecretsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Elsa")
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Elsa.Secrets.Management.Secret", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EncryptedValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("ExpiresAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan?>("ExpiresIn")
                        .HasColumnType("interval");

                    b.Property<bool>("IsLatest")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LastAccessedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .HasColumnType("text");

                    b.Property<string>("Scope")
                        .HasColumnType("text");

                    b.Property<string>("SecretId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("TenantId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExpiresAt")
                        .HasDatabaseName("IX_Secret_ExpiresAt");

                    b.HasIndex("LastAccessedAt")
                        .HasDatabaseName("IX_Secret_LastAccessedAt");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Secret_Name");

                    b.HasIndex("Scope")
                        .HasDatabaseName("IX_Secret_Scope");

                    b.HasIndex("Status")
                        .HasDatabaseName("IX_Secret_Status");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("IX_Secret_TenantId");

                    b.HasIndex("Version")
                        .HasDatabaseName("IX_Secret_Version");

                    b.ToTable("Secrets", "Elsa");
                });
#pragma warning restore 612, 618
        }
    }
}
