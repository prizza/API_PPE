using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_PPE.Models;

public partial class AppDbContext : DbContext
{

    private readonly IConfiguration _configuration;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    public virtual DbSet<Activitylog> Activitylogs { get; set; }

    public virtual DbSet<Apiclient> Apiclients { get; set; }

    public virtual DbSet<JsonDataD> JsonDataDs { get; set; }

    public virtual DbSet<JsonDataH> JsonDataHs { get; set; }

    public virtual DbSet<JsonReceived> JsonReceiveds { get; set; }

    public virtual DbSet<JsonResultPpe> JsonResultPpes { get; set; }

    public virtual DbSet<Sysmaster> Sysmasters { get; set; }

    public virtual DbSet<Userlist> Userlists { get; set; }

    public virtual DbSet<VwGetDataAlert> VwGetDataAlerts { get; set; }

    public virtual DbSet<VwUserlistIndex> VwUserlistIndices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activitylog>(entity =>
        {
            entity.HasKey(e => e.Idact).HasName("PK_IDACT");

            entity.ToTable("ACTIVITYLOG");

            entity.Property(e => e.Idact).HasColumnName("IDACT");
            entity.Property(e => e.Actname)
                .HasMaxLength(255)
                .HasColumnName("ACTNAME");
            entity.Property(e => e.Comname)
                .HasMaxLength(255)
                .HasColumnName("COMNAME");
            entity.Property(e => e.Entryby)
                .HasMaxLength(50)
                .HasColumnName("ENTRYBY");
            entity.Property(e => e.Entrydate)
                .HasColumnType("datetime")
                .HasColumnName("ENTRYDATE");
            entity.Property(e => e.Frmname)
                .HasMaxLength(255)
                .HasColumnName("FRMNAME");
            entity.Property(e => e.Newdata)
                .HasColumnType("text")
                .HasColumnName("NEWDATA");
            entity.Property(e => e.Olddata)
                .HasColumnType("text")
                .HasColumnName("OLDDATA");
        });

        modelBuilder.Entity<Apiclient>(entity =>
        {
            entity.HasKey(e => e.Idclient).HasName("PK__APICLIEN__86D389596B676EFE");

            entity.ToTable("APICLIENT");

            entity.Property(e => e.Idclient).HasColumnName("IDCLIENT");
            entity.Property(e => e.Apitoken)
                .HasMaxLength(255)
                .HasColumnName("APITOKEN");
            entity.Property(e => e.Clientname)
                .HasMaxLength(200)
                .HasColumnName("CLIENTNAME");
            entity.Property(e => e.Entrydate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ENTRYDATE");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("ISACTIVE");
        });

        modelBuilder.Entity<JsonDataD>(entity =>
        {
            entity.HasKey(e => e.IdjsonDataD);

            entity.ToTable("JSON_DATA_D");

            entity.Property(e => e.IdjsonDataD).HasColumnName("IDJSON_DATA_D");
            entity.Property(e => e.Bbox)
                .HasMaxLength(150)
                .HasColumnName("BBOX");
            entity.Property(e => e.Entrydate)
                .HasColumnType("datetime")
                .HasColumnName("ENTRYDATE");
            entity.Property(e => e.IdjsonDataH).HasColumnName("IDJSON_DATA_H");
            entity.Property(e => e.Label)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("LABEL");
            entity.Property(e => e.Score).HasColumnName("SCORE");

            entity.HasOne(d => d.IdjsonDataHNavigation).WithMany(p => p.JsonDataDs)
                .HasForeignKey(d => d.IdjsonDataH)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JSON_DATA_D_JSON_DATA_H");
        });

        modelBuilder.Entity<JsonDataH>(entity =>
        {
            entity.HasKey(e => e.IdjsonDataH);

            entity.ToTable("JSON_DATA_H");

            entity.Property(e => e.IdjsonDataH).HasColumnName("IDJSON_DATA_H");
            entity.Property(e => e.CameraId)
                .HasMaxLength(50)
                .HasColumnName("CAMERA_ID");
            entity.Property(e => e.CameraIp)
                .HasMaxLength(50)
                .HasColumnName("CAMERA_IP");
            entity.Property(e => e.ComputerIp)
                .HasMaxLength(50)
                .HasColumnName("COMPUTER_IP");
            entity.Property(e => e.Entrydate)
                .HasColumnType("datetime")
                .HasColumnName("ENTRYDATE");
            entity.Property(e => e.Images)
                .HasMaxLength(255)
                .HasColumnName("IMAGES");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("TIMESTAMP");
        });

        modelBuilder.Entity<JsonReceived>(entity =>
        {
            entity.HasKey(e => e.IdjsonReceived).HasName("PK_JSON_DATA");

            entity.ToTable("JSON_RECEIVED");

            entity.Property(e => e.IdjsonReceived).HasColumnName("IDJSON_RECEIVED");
            entity.Property(e => e.Entrydate)
                .HasColumnType("datetime")
                .HasColumnName("ENTRYDATE");
            entity.Property(e => e.Isprocessed).HasColumnName("ISPROCESSED");
            entity.Property(e => e.JsonName)
                .HasMaxLength(150)
                .HasColumnName("JSON_NAME");
            entity.Property(e => e.JsonValue).HasColumnName("JSON_VALUE");
        });

        modelBuilder.Entity<JsonResultPpe>(entity =>
        {
            entity.HasKey(e => e.IdjsonRestPpe);

            entity.ToTable("JSON_RESULT_PPE");

            entity.Property(e => e.IdjsonRestPpe).HasColumnName("IDJSON_REST_PPE");
            entity.Property(e => e.Bboxs)
                .HasMaxLength(50)
                .HasColumnName("BBOXS");
            entity.Property(e => e.Entrydate)
                .HasColumnType("datetime")
                .HasColumnName("ENTRYDATE");
            entity.Property(e => e.Fauls)
                .HasMaxLength(255)
                .HasColumnName("FAULS");
            entity.Property(e => e.IdjsonDataD).HasColumnName("IDJSON_DATA_D");
            entity.Property(e => e.Labels)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("LABELS");
            entity.Property(e => e.Scores).HasColumnName("SCORES");
        });

        modelBuilder.Entity<Sysmaster>(entity =>
        {
            entity.HasKey(e => e.Sysid);

            entity.ToTable("SYSMASTER");

            entity.Property(e => e.Sysid).HasColumnName("SYSID");
            entity.Property(e => e.Entryby)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENTRYBY");
            entity.Property(e => e.Entrydate)
                .HasColumnType("datetime")
                .HasColumnName("ENTRYDATE");
            entity.Property(e => e.Syscode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SYSCODE");
            entity.Property(e => e.Sysflag).HasColumnName("SYSFLAG");
            entity.Property(e => e.Sysname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SYSNAME");
            entity.Property(e => e.Sysvalue).HasColumnName("SYSVALUE");
        });

        modelBuilder.Entity<Userlist>(entity =>
        {
            entity.HasKey(e => e.Iduser);

            entity.ToTable("USERLIST");

            entity.Property(e => e.Iduser).HasColumnName("IDUSER");
            entity.Property(e => e.Deletedate)
                .HasColumnType("datetime")
                .HasColumnName("DELETEDATE");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Entryby)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENTRYBY");
            entity.Property(e => e.Entrydate)
                .HasColumnType("datetime")
                .HasColumnName("ENTRYDATE");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MOBILE");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Updateby)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UPDATEBY");
            entity.Property(e => e.Updatedate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATEDATE");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Userlists)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USERLIST_SYSMASTER");
        });

        modelBuilder.Entity<VwGetDataAlert>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_GET_DATA_ALERT");

            entity.Property(e => e.CameraId)
                .HasMaxLength(50)
                .HasColumnName("CAMERA_ID");
            entity.Property(e => e.Fauls)
                .HasMaxLength(4000)
                .HasColumnName("FAULS");
            entity.Property(e => e.IdjsonDataH).HasColumnName("IDJSON_DATA_H");
            entity.Property(e => e.Images)
                .HasMaxLength(255)
                .HasColumnName("IMAGES");
            entity.Property(e => e.Score).HasColumnName("SCORE");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("TIMESTAMP");
        });

        modelBuilder.Entity<VwUserlistIndex>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_USERLIST_INDEX");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Iduser).HasColumnName("IDUSER");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MOBILE");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.StatusName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STATUS_NAME");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
