﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PathWays.Data.Model;
using System;

namespace PathWays.Data.Model.Migrations
{
    [DbContext(typeof(PathWaysContext))]
    [Migration("20180510102012_AddUserPathways")]
    partial class AddUserPathways
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PathWays.Data.Model.AccessCodeExcludeWord", b =>
                {
                    b.Property<int>("AccessCodeExcludeWordId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExcludeWord")
                        .HasMaxLength(6);

                    b.HasKey("AccessCodeExcludeWordId");

                    b.ToTable("AccessCodeExcludeWords");
                });

            modelBuilder.Entity("PathWays.Data.Model.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerDisplayText")
                        .HasMaxLength(255);

                    b.Property<int>("AnswerOrder");

                    b.Property<string>("AnswerTitleText")
                        .HasMaxLength(500);

                    b.Property<int?>("AnswerType");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("NextItemId");

                    b.Property<int?>("NextItemType");

                    b.Property<int?>("PathwayToCreate");

                    b.Property<int>("QuestionId");

                    b.HasKey("AnswerId");

                    b.HasIndex("PathwayToCreate");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("PathWays.Data.Model.Domain", b =>
                {
                    b.Property<int>("DomainId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DomainAbbreviation")
                        .HasMaxLength(7);

                    b.Property<string>("DomainDescription")
                        .HasMaxLength(500);

                    b.Property<string>("DomainEmbedCode")
                        .HasMaxLength(20);

                    b.Property<string>("DomainTitle")
                        .HasMaxLength(150);

                    b.Property<bool?>("EnforceTerms");

                    b.Property<int?>("FirstObjectId");

                    b.Property<int?>("FirstObjectType");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("OrganizationId");

                    b.Property<string>("TermsOfUseHtml");

                    b.HasKey("DomainId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("PathWays.Data.Model.Ending", b =>
                {
                    b.Property<int>("EndingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("DomainId");

                    b.Property<string>("EndingDescription");

                    b.Property<string>("EndingTitle")
                        .IsRequired();

                    b.Property<int>("EndingType");

                    b.Property<int?>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("PathwayId");

                    b.Property<string>("ReturnInstructions");

                    b.Property<int?>("ReturnNextItemId");

                    b.Property<int>("ReturnNextItemType");

                    b.Property<int?>("ServiceId");

                    b.Property<string>("SystemTitle");

                    b.HasKey("EndingId");

                    b.HasIndex("DomainId");

                    b.HasIndex("PathwayId");

                    b.ToTable("Endings");
                });

            modelBuilder.Entity("PathWays.Data.Model.InlineResource", b =>
                {
                    b.Property<int>("InlineResourceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DisplayId")
                        .HasMaxLength(20);

                    b.Property<int>("DomainId");

                    b.Property<string>("ExternalUrl")
                        .HasMaxLength(1000);

                    b.Property<int?>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("NextItemId");

                    b.Property<int?>("NextItemType");

                    b.Property<int>("PathwayId");

                    b.Property<string>("ResourceDescription")
                        .HasMaxLength(2000);

                    b.Property<string>("ResourceInstructions")
                        .HasMaxLength(2000);

                    b.Property<string>("ResourceTitle")
                        .HasMaxLength(255);

                    b.Property<int>("ResourceType");

                    b.Property<bool?>("SharePublicly");

                    b.Property<int?>("TemplateDoc");

                    b.Property<string>("TemplateHtml");

                    b.HasKey("InlineResourceId");

                    b.HasIndex("DomainId");

                    b.HasIndex("PathwayId");

                    b.ToTable("InlineResources");
                });

            modelBuilder.Entity("PathWays.Data.Model.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DisplayLogoId");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(200);

                    b.Property<bool?>("DisplaySupportChat");

                    b.Property<bool?>("DisplaySupportEmail");

                    b.Property<bool?>("DisplaySupportPhone");

                    b.Property<bool?>("DisplayUserSupport");

                    b.Property<decimal?>("FlatMonthlyFee")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("LicenseType");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<Guid>("OrganizationGuid");

                    b.Property<int?>("OrganizationStatus");

                    b.Property<decimal?>("PerComplationFee")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal?>("PerServiceAccessFee")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal?>("PerVisitFee")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("SupportChatDescription")
                        .HasMaxLength(1000);

                    b.Property<string>("SupportChatUrl")
                        .HasMaxLength(1000);

                    b.Property<string>("SupportEmail")
                        .HasMaxLength(100);

                    b.Property<string>("SupportEmailDescription")
                        .HasMaxLength(1000);

                    b.Property<string>("SupportPhone1")
                        .HasMaxLength(15);

                    b.Property<string>("SupportPhone1Description")
                        .HasMaxLength(1000);

                    b.Property<string>("SupportPhone2")
                        .HasMaxLength(15);

                    b.Property<string>("SupportPhone2Description")
                        .HasMaxLength(1000);

                    b.Property<int>("TimeZoneOffset");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("PathWays.Data.Model.Pathway", b =>
                {
                    b.Property<int>("PathwayId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("DomainId");

                    b.Property<int?>("FirstObjectId");

                    b.Property<int?>("FirstObjectType");

                    b.Property<bool>("IsActive");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("PathAbbreviation")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("PathDescription")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<string>("PathName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("PathwayId");

                    b.HasIndex("DomainId");

                    b.ToTable("Pathways");
                });

            modelBuilder.Entity("PathWays.Data.Model.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DisplayId")
                        .HasMaxLength(20);

                    b.Property<int>("DomainId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("PathwayId");

                    b.Property<string>("QuestionTitle")
                        .HasMaxLength(255);

                    b.Property<string>("QuestionTitleText")
                        .HasMaxLength(1500);

                    b.Property<int?>("QuestionType");

                    b.HasKey("QuestionId");

                    b.HasIndex("DomainId");

                    b.HasIndex("PathwayId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("PathWays.Data.Model.ReportItem", b =>
                {
                    b.Property<int>("ReportItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AssociatedServiceId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EndingDescription")
                        .HasMaxLength(2500);

                    b.Property<int>("EndingId");

                    b.Property<string>("EndingTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("EndingType");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("SystemTitle")
                        .HasMaxLength(500);

                    b.Property<int>("UserReportId");

                    b.HasKey("ReportItemId");

                    b.HasIndex("EndingId");

                    b.HasIndex("UserReportId");

                    b.ToTable("ReportItems");
                });

            modelBuilder.Entity("PathWays.Data.Model.SystemSettings", b =>
                {
                    b.Property<int>("SystemSettingsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("Type");

                    b.Property<string>("Value");

                    b.HasKey("SystemSettingsId");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("PathWays.Data.Model.SystemUser", b =>
                {
                    b.Property<int>("SystemUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("AcceptsTextMessages");

                    b.Property<string>("AccountEmail")
                        .HasMaxLength(100);

                    b.Property<string>("AccountMobile")
                        .HasMaxLength(15);

                    b.Property<bool>("AdminAccess");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FullName")
                        .HasMaxLength(100);

                    b.Property<bool?>("IsActive");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Password")
                        .HasMaxLength(250);

                    b.Property<int>("SystemUserRoleId");

                    b.Property<Guid>("UserGuid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("SystemUserId");

                    b.HasIndex("SystemUserRoleId");

                    b.ToTable("SystemUsers");
                });

            modelBuilder.Entity("PathWays.Data.Model.SystemUserRole", b =>
                {
                    b.Property<int>("SystemUserRoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleDescritption")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("SessionDuration")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(900);

                    b.HasKey("SystemUserRoleId");

                    b.ToTable("SystemUserRoles");
                });

            modelBuilder.Entity("PathWays.Data.Model.UserExploration", b =>
                {
                    b.Property<int>("UserExplorationId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("AcceptedTerms");

                    b.Property<string>("AccessCode")
                        .HasMaxLength(15);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("DomainId");

                    b.Property<DateTime>("ExplorationCompletionDate");

                    b.Property<byte?>("ExplorationStatus");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("OrganizationId");

                    b.HasKey("UserExplorationId");

                    b.ToTable("UserExplorations");
                });

            modelBuilder.Entity("PathWays.Data.Model.UserExplorationToken", b =>
                {
                    b.Property<int>("UserExplorationTokenId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessCode")
                        .HasMaxLength(15);

                    b.Property<string>("AuthToken")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<DateTime>("ExpiresOn");

                    b.Property<int?>("ExplorationId");

                    b.Property<DateTime>("IssuedOn");

                    b.Property<byte>("RoleId");

                    b.Property<int?>("SystemUserId");

                    b.Property<int?>("UserExplorationId");

                    b.HasKey("UserExplorationTokenId");

                    b.HasIndex("UserExplorationId");

                    b.ToTable("UserExplorationTokens");
                });

            modelBuilder.Entity("PathWays.Data.Model.UserPathway", b =>
                {
                    b.Property<int>("UserPathwayId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<DateTime?>("PathwayCompletionDate");

                    b.Property<int?>("PathwayId");

                    b.Property<int?>("PathwayStatus");

                    b.Property<string>("PathwayTitle")
                        .HasMaxLength(100);

                    b.Property<int>("PathwayType");

                    b.Property<int>("UserExplorationId");

                    b.HasKey("UserPathwayId");

                    b.HasIndex("PathwayId");

                    b.HasIndex("UserExplorationId");

                    b.ToTable("UserPathways");
                });

            modelBuilder.Entity("PathWays.Data.Model.UserReport", b =>
                {
                    b.Property<int>("UserReportId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("UserExplorationId");

                    b.Property<int?>("UserReportStatus");

                    b.HasKey("UserReportId");

                    b.HasIndex("UserExplorationId");

                    b.ToTable("UserReports");
                });

            modelBuilder.Entity("PathWays.Data.Model.UserToken", b =>
                {
                    b.Property<int>("UserTokenId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthToken")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<DateTime>("ExpiresOn");

                    b.Property<DateTime>("IssuedOn");

                    b.Property<int?>("ParticipantId");

                    b.Property<int>("RoleId");

                    b.Property<Guid?>("SystemUserGuid");

                    b.Property<int?>("SystemUserId");

                    b.HasKey("UserTokenId");

                    b.HasIndex("SystemUserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("PathWays.Data.Model.Answer", b =>
                {
                    b.HasOne("PathWays.Data.Model.Pathway", "Pathway")
                        .WithMany("Answers")
                        .HasForeignKey("PathwayToCreate")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PathWays.Data.Model.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PathWays.Data.Model.Domain", b =>
                {
                    b.HasOne("PathWays.Data.Model.Organization", "Organization")
                        .WithMany("Domains")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PathWays.Data.Model.Ending", b =>
                {
                    b.HasOne("PathWays.Data.Model.Domain", "Domain")
                        .WithMany("Endings")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PathWays.Data.Model.Pathway", "Pathway")
                        .WithMany("Endings")
                        .HasForeignKey("PathwayId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PathWays.Data.Model.InlineResource", b =>
                {
                    b.HasOne("PathWays.Data.Model.Domain", "Domain")
                        .WithMany("InlineResources")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PathWays.Data.Model.Pathway", "Pathway")
                        .WithMany("InlineResources")
                        .HasForeignKey("PathwayId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PathWays.Data.Model.Pathway", b =>
                {
                    b.HasOne("PathWays.Data.Model.Domain", "Domain")
                        .WithMany("Pathways")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PathWays.Data.Model.Question", b =>
                {
                    b.HasOne("PathWays.Data.Model.Domain", "Domain")
                        .WithMany("Questions")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PathWays.Data.Model.Pathway", "Pathway")
                        .WithMany("Questions")
                        .HasForeignKey("PathwayId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PathWays.Data.Model.ReportItem", b =>
                {
                    b.HasOne("PathWays.Data.Model.Ending", "Ending")
                        .WithMany("ReportItems")
                        .HasForeignKey("EndingId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PathWays.Data.Model.UserReport", "UserReport")
                        .WithMany("ReportItems")
                        .HasForeignKey("UserReportId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PathWays.Data.Model.SystemUser", b =>
                {
                    b.HasOne("PathWays.Data.Model.SystemUserRole", "SystemUserRole")
                        .WithMany()
                        .HasForeignKey("SystemUserRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PathWays.Data.Model.UserExplorationToken", b =>
                {
                    b.HasOne("PathWays.Data.Model.UserExploration", "UserExploration")
                        .WithMany("UserExplorationTokens")
                        .HasForeignKey("UserExplorationId");
                });

            modelBuilder.Entity("PathWays.Data.Model.UserPathway", b =>
                {
                    b.HasOne("PathWays.Data.Model.Pathway", "Pathway")
                        .WithMany("UserPathways")
                        .HasForeignKey("PathwayId");

                    b.HasOne("PathWays.Data.Model.UserExploration", "UserExploration")
                        .WithMany("UserPathways")
                        .HasForeignKey("UserExplorationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PathWays.Data.Model.UserReport", b =>
                {
                    b.HasOne("PathWays.Data.Model.UserExploration", "UserExploration")
                        .WithMany("UserReports")
                        .HasForeignKey("UserExplorationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PathWays.Data.Model.UserToken", b =>
                {
                    b.HasOne("PathWays.Data.Model.SystemUser", "SystemUser")
                        .WithMany()
                        .HasForeignKey("SystemUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
