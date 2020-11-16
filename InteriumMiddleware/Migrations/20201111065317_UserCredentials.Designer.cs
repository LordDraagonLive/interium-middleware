﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InteriumMiddleware.Migrations
{
    [DbContext(typeof(UserCredentialsContext))]
    [Migration("20201111065317_UserCredentials")]
    partial class UserCredentials
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InteriumMiddleware.Models.ClientCredential", b =>
                {
                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientSecret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RedirectUri")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("ClientCredential");
                });

            modelBuilder.Entity("InteriumMiddleware.Models.UserCredential", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientCredentialsClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CredentialsId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExchangeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientCredentialsClientId");

                    b.ToTable("UserCredential");
                });

            modelBuilder.Entity("InteriumMiddleware.Models.UserCredential", b =>
                {
                    b.HasOne("InteriumMiddleware.Models.ClientCredential", "ClientCredentials")
                        .WithMany()
                        .HasForeignKey("ClientCredentialsClientId");
                });
#pragma warning restore 612, 618
        }
    }
}