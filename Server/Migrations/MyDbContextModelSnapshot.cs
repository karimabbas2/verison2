﻿// <auto-generated />
using System;
using AppPersistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AppDomain.Codec", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codec_Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Codecs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Codec_Name = "alaw",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Codec_Name = "ulaw",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Codec_Name = "speex",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Codec_Name = "gsm",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Codec_Name = "opus",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Codec_Name = "g722",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            Codec_Name = "g729",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            Codec_Name = "g723",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            Codec_Name = "g719",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AppDomain.DTMF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DTMF_Mode")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DTMFs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DTMF_Mode = "rfc4733"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DTMF_Mode = "info"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DTMF_Mode = "inband"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DTMF_Mode = "rfc4733_info"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DTMF_Mode = "auto"
                        });
                });

            modelBuilder.Entity("AppDomain.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Dept_name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dept_name = " "
                        });
                });

            modelBuilder.Entity("AppDomain.DestRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Dest_name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DestRoutes");
                });

            modelBuilder.Entity("AppDomain.Extenstion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("A_CodecFrom")
                        .HasColumnType("longtext");

                    b.Property<string>("A_CodecTo")
                        .HasColumnType("longtext");

                    b.Property<string>("AuthId")
                        .HasColumnType("longtext");

                    b.Property<int?>("CFB_Time_CondtionId")
                        .HasColumnType("int");

                    b.Property<int?>("CFN_Time_CondtionId")
                        .HasColumnType("int");

                    b.Property<int?>("CFU_Time_CondtionId")
                        .HasColumnType("int");

                    b.Property<int?>("Call_Forward_AlwaysId")
                        .HasColumnType("int");

                    b.Property<int?>("Call_Forward_No_AnswerId")
                        .HasColumnType("int");

                    b.Property<int?>("Call_Forworad_BusyId")
                        .HasColumnType("int");

                    b.Property<int?>("Call_PrivilegeId")
                        .HasColumnType("int");

                    b.Property<int?>("CallerId_Number")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DND_Time_CondtionId")
                        .HasColumnType("int");

                    b.Property<string>("DND_WhiteList")
                        .HasColumnType("longtext");

                    b.Property<int?>("DTMF_ModeId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("Do_Not_Disturb")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("Enable_DM")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Enable_Ext")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Enable_KA")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Enable_NAT")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Enable_VM")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Ext_CC_Registrations")
                        .HasColumnType("longtext");

                    b.Property<int>("Ext_Number")
                        .HasColumnType("int");

                    b.Property<string>("Ext_User_pswd")
                        .HasColumnType("longtext");

                    b.Property<int?>("Extension_Ring_Time")
                        .HasColumnType("int");

                    b.Property<string>("F_Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("JitterBufferId")
                        .HasColumnType("int");

                    b.Property<string>("Job_Title")
                        .HasColumnType("longtext");

                    b.Property<int?>("KA_Freq")
                        .HasColumnType("int");

                    b.Property<string>("L_Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("Language")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .HasColumnType("longtext");

                    b.Property<string>("SIP_Password")
                        .HasColumnType("longtext");

                    b.Property<int?>("SRTP")
                        .HasColumnType("int");

                    b.Property<bool>("Sync_Contact")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("VM_Password")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CFB_Time_CondtionId");

                    b.HasIndex("CFN_Time_CondtionId");

                    b.HasIndex("CFU_Time_CondtionId");

                    b.HasIndex("Call_Forward_AlwaysId");

                    b.HasIndex("Call_Forward_No_AnswerId");

                    b.HasIndex("Call_Forworad_BusyId");

                    b.HasIndex("Call_PrivilegeId");

                    b.HasIndex("DND_Time_CondtionId");

                    b.HasIndex("DTMF_ModeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("JitterBufferId");

                    b.ToTable("Extenstions");
                });

            modelBuilder.Entity("AppDomain.GlobalExtenstionDefault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodecFrom")
                        .HasColumnType("longtext");

                    b.Property<string>("CodecTo")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Enable_NAT")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Enable_VM")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Ext_CC_Registrations")
                        .HasColumnType("int");

                    b.Property<int?>("Ext_DTMF")
                        .HasColumnType("int");

                    b.Property<int?>("Ext_Privilege")
                        .HasColumnType("int");

                    b.Property<int?>("Ext_Ring_Time")
                        .HasColumnType("int");

                    b.Property<int?>("JitterBuffer")
                        .HasColumnType("int");

                    b.Property<bool>("Sync_Contact")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("GlobalExtenstionDefaults");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodecFrom = "alaw,ulaw,speex,gsm,opus,g722,g729,g723,g719",
                            CodecTo = "",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Enable_NAT = false,
                            Enable_VM = false,
                            Ext_CC_Registrations = 3,
                            Ext_DTMF = 1,
                            Ext_Privilege = 1,
                            Ext_Ring_Time = 60,
                            JitterBuffer = 1,
                            Sync_Contact = false
                        });
                });

            modelBuilder.Entity("AppDomain.JitterBuffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("JitterBuffer_Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("JitterBuffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JitterBuffer_Name = "disable"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JitterBuffer_Name = "fixed"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JitterBuffer_Name = "adaptive"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JitterBuffer_Name = "neteq"
                        });
                });

            modelBuilder.Entity("AppDomain.Privilege", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Privilege_Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Call_Privileges");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Privilege_Name = "internal"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Privilege_Name = "local"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Privilege_Name = "national"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Privilege_Name = "international"
                        });
                });

            modelBuilder.Entity("AppDomain.SIPSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("RTP_Range_From")
                        .HasColumnType("int");

                    b.Property<int?>("RTP_Range_TO")
                        .HasColumnType("int");

                    b.Property<string>("STUN_Address")
                        .HasColumnType("longtext");

                    b.Property<int?>("TCP_PORT")
                        .HasColumnType("int");

                    b.Property<int?>("TLS_PORT")
                        .HasColumnType("int");

                    b.Property<int?>("UDP_PORT")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SIPSettings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RTP_Range_From = 10000,
                            RTP_Range_TO = 20000,
                            TCP_PORT = 5060,
                            TLS_PORT = 5162,
                            UDP_PORT = 5060
                        });
                });

            modelBuilder.Entity("AppDomain.TimeGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Time_Groupe")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TimeGroups");
                });

            modelBuilder.Entity("AppDomain.TrunkEntity.Trunk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("A_CodecFrom")
                        .HasColumnType("longtext");

                    b.Property<string>("A_CodecTo")
                        .HasColumnType("longtext");

                    b.Property<string>("AuthID")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DTMF_ModeId")
                        .HasColumnType("int");

                    b.Property<bool>("Enable_KA")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Enable_NAT")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Enable_Trunk")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("From_Domain")
                        .HasColumnType("longtext");

                    b.Property<string>("From_User")
                        .HasColumnType("longtext");

                    b.Property<int?>("KA_Freq")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<bool>("Need_Registration")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Out_Proxy_Port")
                        .HasColumnType("int");

                    b.Property<string>("Out_Proxy_Server")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int?>("Port")
                        .HasColumnType("int");

                    b.Property<int?>("SRTP")
                        .HasColumnType("int");

                    b.Property<string>("Server_Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Transport")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<string>("User_Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DTMF_ModeId");

                    b.ToTable("Trunks");
                });

            modelBuilder.Entity("AppDomain.VoicePrompts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ExtenstionId")
                        .HasColumnType("int");

                    b.Property<string>("File_Format")
                        .HasColumnType("longtext");

                    b.Property<string>("File_Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ExtenstionId");

                    b.ToTable("VoicePrompts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "22e40406-8a9d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "20942eaa-82f6-4047-90e5-6471d9200d5d",
                            Email = "FiberMe@admin.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAIAAYagAAAAEIc6znnQaSXjxB3eA78meo4c3n4IshXWpjZnvP/dks5kedbVgc7GuJjXkQMQYB416w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a34f35af-1c34-4398-928b-feb4e1e4d555",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AppDomain.Extenstion", b =>
                {
                    b.HasOne("AppDomain.TimeGroups", "CFB_Time_Condtion")
                        .WithMany()
                        .HasForeignKey("CFB_Time_CondtionId");

                    b.HasOne("AppDomain.TimeGroups", "CFN_Time_Condtion")
                        .WithMany()
                        .HasForeignKey("CFN_Time_CondtionId");

                    b.HasOne("AppDomain.TimeGroups", "CFU_Time_Condtion")
                        .WithMany()
                        .HasForeignKey("CFU_Time_CondtionId");

                    b.HasOne("AppDomain.DestRoute", "Call_Forward_Always")
                        .WithMany()
                        .HasForeignKey("Call_Forward_AlwaysId");

                    b.HasOne("AppDomain.DestRoute", "Call_Forward_No_Answer")
                        .WithMany()
                        .HasForeignKey("Call_Forward_No_AnswerId");

                    b.HasOne("AppDomain.DestRoute", "Call_Forworad_Busy")
                        .WithMany()
                        .HasForeignKey("Call_Forworad_BusyId");

                    b.HasOne("AppDomain.Privilege", "Call_Privilege")
                        .WithMany()
                        .HasForeignKey("Call_PrivilegeId");

                    b.HasOne("AppDomain.TimeGroups", "DND_Time_Condtion")
                        .WithMany()
                        .HasForeignKey("DND_Time_CondtionId");

                    b.HasOne("AppDomain.DTMF", "DTMF_Mode")
                        .WithMany()
                        .HasForeignKey("DTMF_ModeId");

                    b.HasOne("AppDomain.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDomain.JitterBuffer", "JitterBuffer")
                        .WithMany()
                        .HasForeignKey("JitterBufferId");

                    b.Navigation("CFB_Time_Condtion");

                    b.Navigation("CFN_Time_Condtion");

                    b.Navigation("CFU_Time_Condtion");

                    b.Navigation("Call_Forward_Always");

                    b.Navigation("Call_Forward_No_Answer");

                    b.Navigation("Call_Forworad_Busy");

                    b.Navigation("Call_Privilege");

                    b.Navigation("DND_Time_Condtion");

                    b.Navigation("DTMF_Mode");

                    b.Navigation("Department");

                    b.Navigation("JitterBuffer");
                });

            modelBuilder.Entity("AppDomain.TrunkEntity.Trunk", b =>
                {
                    b.HasOne("AppDomain.DTMF", "DTMF_Mode")
                        .WithMany()
                        .HasForeignKey("DTMF_ModeId");

                    b.Navigation("DTMF_Mode");
                });

            modelBuilder.Entity("AppDomain.VoicePrompts", b =>
                {
                    b.HasOne("AppDomain.Extenstion", "Extenstion")
                        .WithMany()
                        .HasForeignKey("ExtenstionId");

                    b.Navigation("Extenstion");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
