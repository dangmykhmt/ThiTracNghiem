﻿// <auto-generated />
using System;
using CaseStudy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaseStudy.Migrations
{
    [DbContext(typeof(trac_nghiem_onlineEntities))]
    partial class trac_nghiem_onlineEntitiesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CaseStudy.Model.question", b =>
                {
                    b.Property<int>("id_question")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("answer_a");

                    b.Property<string>("answer_b");

                    b.Property<string>("answer_c");

                    b.Property<string>("answer_d");

                    b.Property<string>("content");

                    b.Property<string>("correct_answer");

                    b.Property<int>("id_subject");

                    b.HasKey("id_question");

                    b.HasIndex("id_subject");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("CaseStudy.Model.quests_of_test", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_question");

                    b.Property<int>("test_code");

                    b.HasKey("ID");

                    b.HasIndex("id_question");

                    b.HasIndex("test_code");

                    b.ToTable("quests_of_test");
                });

            modelBuilder.Entity("CaseStudy.Model.score", b =>
                {
                    b.Property<int>("id_score")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("detail");

                    b.Property<int>("id_student");

                    b.Property<double>("score_number");

                    b.Property<int>("test_code");

                    b.HasKey("id_score");

                    b.HasIndex("id_student");

                    b.HasIndex("test_code");

                    b.ToTable("scores");
                });

            modelBuilder.Entity("CaseStudy.Model.student", b =>
                {
                    b.Property<int>("id_student")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("birthday");

                    b.Property<string>("email");

                    b.Property<string>("gender");

                    b.Property<string>("name");

                    b.Property<string>("password");

                    b.Property<string>("phone");

                    b.Property<string>("username");

                    b.HasKey("id_student");

                    b.ToTable("students");
                });

            modelBuilder.Entity("CaseStudy.Model.student_test_detail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("answer_a");

                    b.Property<string>("answer_b");

                    b.Property<string>("answer_c");

                    b.Property<string>("answer_d");

                    b.Property<int>("id_question");

                    b.Property<int>("id_student");

                    b.Property<string>("student_answer");

                    b.Property<int>("test_code");

                    b.HasKey("ID");

                    b.HasIndex("id_question");

                    b.HasIndex("id_student");

                    b.ToTable("student_test_detail");
                });

            modelBuilder.Entity("CaseStudy.Model.subject", b =>
                {
                    b.Property<int>("id_subject")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("subject_name");

                    b.HasKey("id_subject");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("CaseStudy.Model.test", b =>
                {
                    b.Property<int>("test_code")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_subject");

                    b.Property<string>("test_name");

                    b.Property<int>("total_questions");

                    b.HasKey("test_code");

                    b.HasIndex("id_subject");

                    b.ToTable("tests");
                });

            modelBuilder.Entity("CaseStudy.Model.question", b =>
                {
                    b.HasOne("CaseStudy.Model.subject", "subject")
                        .WithMany("questions")
                        .HasForeignKey("id_subject")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CaseStudy.Model.quests_of_test", b =>
                {
                    b.HasOne("CaseStudy.Model.question", "question")
                        .WithMany("quests_of_test")
                        .HasForeignKey("id_question")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CaseStudy.Model.test", "test")
                        .WithMany("quests_of_test")
                        .HasForeignKey("test_code")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CaseStudy.Model.score", b =>
                {
                    b.HasOne("CaseStudy.Model.student", "student")
                        .WithMany("scores")
                        .HasForeignKey("id_student")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CaseStudy.Model.test", "test")
                        .WithMany("scores")
                        .HasForeignKey("test_code")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CaseStudy.Model.student_test_detail", b =>
                {
                    b.HasOne("CaseStudy.Model.question", "question")
                        .WithMany("student_test_detail")
                        .HasForeignKey("id_question")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CaseStudy.Model.student", "student")
                        .WithMany("student_test_detail")
                        .HasForeignKey("id_student")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CaseStudy.Model.test", b =>
                {
                    b.HasOne("CaseStudy.Model.subject", "subject")
                        .WithMany("tests")
                        .HasForeignKey("id_subject")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
