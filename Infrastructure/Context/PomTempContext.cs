using Domain.Entities.PomTemp;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public partial class PomTempContext : DbContext
{
    public PomTempContext()
    {
    }

    public PomTempContext(DbContextOptions<PomTempContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Email> Emaile { get; set; }

    public virtual DbSet<Granice> Granice { get; set; }

    public virtual DbSet<Komora> Komory { get; set; }

    public virtual DbSet<Operator> Operatorzy { get; set; }

    public virtual DbSet<Technologium> Technologia { get; set; }

    public virtual DbSet<Temperatury> Temperatury { get; set; }

    public virtual DbSet<ZamrazarkaPlytowa> ZamrazarkaPlytowa { get; set; }

    public virtual DbSet<Zmienna> Zmienne { get; set; }

    public virtual DbSet<ZmiennaTemp> ZmienneTemp { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Polish_CI_AS");

        modelBuilder.Entity<Email>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Email");

            entity.Property(e => e.Adres)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Email_ID");
            entity.Property(e => e.Imie)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Granice>(entity =>
        {
            entity.HasKey(e => e.GraniceId).HasName("Granice_IDX");

            entity.ToTable("Granice");

            entity.Property(e => e.GraniceId).HasColumnName("Granice_ID");
            entity.Property(e => e.CzasStart)
                .HasColumnType("datetime")
                .HasColumnName("Czas_Start");
            entity.Property(e => e.CzasStop)
                .HasColumnType("datetime")
                .HasColumnName("Czas_Stop");
            entity.Property(e => e.GranicaMax).HasColumnName("Granica_Max");
            entity.Property(e => e.GranicaMin).HasColumnName("Granica_Min");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ZmiennaFk).HasColumnName("Zmienna_FK");

            entity.HasOne(d => d.ZmiennaFkNavigation).WithMany(p => p.Granices)
                .HasForeignKey(d => d.ZmiennaFk)
                .HasConstraintName("Zmienna_Granica_OK");
        });

        modelBuilder.Entity<Komora>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Komora");

            entity.Property(e => e.Czas).HasColumnType("datetime");
            entity.Property(e => e.CzasStart)
                .HasColumnType("datetime")
                .HasColumnName("Czas_Start");
            entity.Property(e => e.CzasStop)
                .HasColumnType("datetime")
                .HasColumnName("Czas_Stop");
            entity.Property(e => e.Komora1).HasColumnName("Komora");
            entity.Property(e => e.KomoraId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Komora_ID");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Operator");

            entity.Property(e => e.Haslo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Imie)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OperatorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Operator_ID");
            entity.Property(e => e.Uprawnienia)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Technologium>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TECHNOLOGIA");

            entity.Property(e => e.Czas)
                .HasColumnType("datetime")
                .HasColumnName("czas");
            entity.Property(e => e.Pom1).HasColumnName("pom1");
            entity.Property(e => e.Pom1Max).HasColumnName("pom1_max");
            entity.Property(e => e.Pom1Min).HasColumnName("pom1_min");
            entity.Property(e => e.Pom1Status).HasColumnName("pom1_status");
            entity.Property(e => e.Pom2).HasColumnName("pom2");
            entity.Property(e => e.Pom2Max).HasColumnName("pom2_max");
            entity.Property(e => e.Pom2Min).HasColumnName("pom2_min");
            entity.Property(e => e.Pom2Status).HasColumnName("pom2_status");
            entity.Property(e => e.Pom3).HasColumnName("pom3");
            entity.Property(e => e.Pom3Max).HasColumnName("pom3_max");
            entity.Property(e => e.Pom3Min).HasColumnName("pom3_min");
            entity.Property(e => e.Pom3Status).HasColumnName("pom3_status");
            entity.Property(e => e.Pom4).HasColumnName("pom4");
            entity.Property(e => e.Pom4Max).HasColumnName("pom4_max");
            entity.Property(e => e.Pom4Min).HasColumnName("pom4_min");
            entity.Property(e => e.Pom4Status).HasColumnName("pom4_status");
            entity.Property(e => e.TechnologiaId).HasColumnName("technologia_id");
        });

        modelBuilder.Entity<Temperatury>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Temperatury");

            entity.HasIndex(e => e.Czas, "Temperatury-Czas_IX");

            entity.Property(e => e.Czas).HasColumnType("datetime");
            entity.Property(e => e.TemperaturyId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Temperatury_ID");
        });

        modelBuilder.Entity<ZamrazarkaPlytowa>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Zamrazarka_plytowa");

            entity.Property(e => e.Clt1Rpm).HasColumnName("CLT1_RPM");
            entity.Property(e => e.Clt2Rpm).HasColumnName("CLT2_RPM");
            entity.Property(e => e.Clt3Rpm).HasColumnName("CLT3_RPM");
            entity.Property(e => e.Cmt1Rpm).HasColumnName("CMT1_RPM");
            entity.Property(e => e.Cmt2Rpm).HasColumnName("CMT2_RPM");
            entity.Property(e => e.Czas).HasColumnType("datetime");
            entity.Property(e => e.Dc06).HasColumnName("DC_0_6");
            entity.Property(e => e.DiW1).HasColumnName("DI_W_1");
            entity.Property(e => e.DiW10).HasColumnName("DI_W_10");
            entity.Property(e => e.DiW11).HasColumnName("DI_W_11");
            entity.Property(e => e.DiW12).HasColumnName("DI_W_12");
            entity.Property(e => e.DiW2).HasColumnName("DI_W_2");
            entity.Property(e => e.DiW3).HasColumnName("DI_W_3");
            entity.Property(e => e.DiW4).HasColumnName("DI_W_4");
            entity.Property(e => e.DiW5).HasColumnName("DI_W_5");
            entity.Property(e => e.DiW6).HasColumnName("DI_W_6");
            entity.Property(e => e.DiW7).HasColumnName("DI_W_7");
            entity.Property(e => e.DiW8).HasColumnName("DI_W_8");
            entity.Property(e => e.DiW9).HasColumnName("DI_W_9");
            entity.Property(e => e.Dpmr).HasColumnName("DPmr");
            entity.Property(e => e.Dpwl1AlarmPpm).HasColumnName("DPWL_1_Alarm_ppm");
            entity.Property(e => e.Dpwl1ConcentPpm).HasColumnName("DPWL_1_concent_ppm");
            entity.Property(e => e.DpwlSensTime).HasColumnName("DPWL_sens_time");
            entity.Property(e => e.Ekd1U20).HasColumnName("EKD1_U20");
            entity.Property(e => e.Ekd1U21).HasColumnName("EKD1_U21");
            entity.Property(e => e.Ekd1U25).HasColumnName("EKD1_U25");
            entity.Property(e => e.Ekd1U26).HasColumnName("EKD1_U26");
            entity.Property(e => e.Ekd1U27).HasColumnName("EKD1_U27");
            entity.Property(e => e.Ekd2U20).HasColumnName("EKD2_U20");
            entity.Property(e => e.Ekd2U21).HasColumnName("EKD2_U21");
            entity.Property(e => e.Ekd2U25).HasColumnName("EKD2_U25");
            entity.Property(e => e.Ekd2U26).HasColumnName("EKD2_U26");
            entity.Property(e => e.Ekd2U27).HasColumnName("EKD2_U27");
            entity.Property(e => e.FalClt1Power).HasColumnName("Fal_CLT1_Power");
            entity.Property(e => e.FalClt2Power).HasColumnName("Fal_CLT2_Power");
            entity.Property(e => e.FalClt3Power).HasColumnName("Fal_CLT3_Power");
            entity.Property(e => e.FalCmt1Power).HasColumnName("Fal_CMT1_Power");
            entity.Property(e => e.FalCmt2Power).HasColumnName("Fal_CMT2_Power");
            entity.Property(e => e.FalP1Power).HasColumnName("Fal_P1_Power");
            entity.Property(e => e.FalP2Power).HasColumnName("Fal_P2_Power");
            entity.Property(e => e.FalP4Power).HasColumnName("Fal_P4_Power");
            entity.Property(e => e.Lt1freq).HasColumnName("LT1freq");
            entity.Property(e => e.Lt1prad).HasColumnName("LT1Prad");
            entity.Property(e => e.Lt2freq).HasColumnName("LT2freq");
            entity.Property(e => e.Lt2prad).HasColumnName("LT2Prad");
            entity.Property(e => e.Lt3freq).HasColumnName("LT3freq");
            entity.Property(e => e.Lt3prad).HasColumnName("LT3Prad");
            entity.Property(e => e.Mt1freq).HasColumnName("MT1freq");
            entity.Property(e => e.Mt1prad).HasColumnName("MT1Prad");
            entity.Property(e => e.Mt2freq).HasColumnName("MT2freq");
            entity.Property(e => e.Mt2prad).HasColumnName("MT2Prad");
            entity.Property(e => e.P1Hours1).HasColumnName("P1_Hours_1");
            entity.Property(e => e.P1Hours2).HasColumnName("P1_Hours_2");
            entity.Property(e => e.P1Rpm).HasColumnName("P1_RPM");
            entity.Property(e => e.P1prad).HasColumnName("P1Prad");
            entity.Property(e => e.P2Hours1).HasColumnName("P2_Hours_1");
            entity.Property(e => e.P2Hours2).HasColumnName("P2_Hours_2");
            entity.Property(e => e.P2Rpm).HasColumnName("P2_RPM");
            entity.Property(e => e.P2prad).HasColumnName("P2Prad");
            entity.Property(e => e.P3Hours1).HasColumnName("P3_Hours_1");
            entity.Property(e => e.P3Hours2).HasColumnName("P3_Hours_2");
            entity.Property(e => e.P4Hours1).HasColumnName("P4_Hours_1");
            entity.Property(e => e.P4Hours2).HasColumnName("P4_Hours_2");
            entity.Property(e => e.P4Rpm).HasColumnName("P4_RPM");
            entity.Property(e => e.P4prad).HasColumnName("P4Prad");
            entity.Property(e => e.P5Hours1).HasColumnName("P5_Hours_1");
            entity.Property(e => e.P5Hours2).HasColumnName("P5_Hours_2");
            entity.Property(e => e.P6Hours1).HasColumnName("P6_Hours_1");
            entity.Property(e => e.P6Hours2).HasColumnName("P6_Hours_2");
            entity.Property(e => e.PmrSsWart).HasColumnName("PmrSS_Wart");
            entity.Property(e => e.PmrTlWart).HasColumnName("PmrTL_Wart");
            entity.Property(e => e.PmrZbiornikWart).HasColumnName("PmrZbiornik_Wart");
            entity.Property(e => e.StpMr).HasColumnName("STP_mr");
            entity.Property(e => e.StpMrDiff).HasColumnName("STP_mr_diff");
            entity.Property(e => e.StpMrNoc).HasColumnName("STP_mr_noc");
            entity.Property(e => e.TevapInWart).HasColumnName("TevapIN_Wart");
            entity.Property(e => e.TevapOutWart).HasColumnName("TevapOUT_Wart");
            entity.Property(e => e.TgWym2Out).HasColumnName("TG_wym2OUT");
            entity.Property(e => e.TgWym3In).HasColumnName("TG_wym3IN");
            entity.Property(e => e.TgWym3Out).HasColumnName("TG_wym3OUT");
            entity.Property(e => e.TmaszynWart).HasColumnName("Tmaszyn_Wart");
            entity.Property(e => e.TmrOut1Wart).HasColumnName("TmrOUT1_Wart");
            entity.Property(e => e.TmrOut2Wart).HasColumnName("TmrOUT2_Wart");
            entity.Property(e => e.TmrOut3Wart).HasColumnName("TmrOUT3_Wart");
            entity.Property(e => e.TmrOut4Wart).HasColumnName("TmrOUT4_Wart");
            entity.Property(e => e.TmrWym1InWart).HasColumnName("Tmr_wym1IN_Wart");
            entity.Property(e => e.TmrWym1OutWart).HasColumnName("Tmr_wym1OUT_Wart");
            entity.Property(e => e.TmrZbiornikDefWart).HasColumnName("TmrZbiornikDEF_Wart");
            entity.Property(e => e.Tr744Wym1OutWart).HasColumnName("TR744_wym1OUT_Wart");
            entity.Property(e => e.Tr744Wym2In).HasColumnName("TR744_wym2IN");
            entity.Property(e => e.Tr744Wym2Out).HasColumnName("TR744_wym2OUT");
            entity.Property(e => e.Tr744Wym3In).HasColumnName("TR744_wym3IN");
            entity.Property(e => e.Tr744Wym3Out).HasColumnName("TR744_wym3OUT");
            entity.Property(e => e.TwInWart).HasColumnName("TW_IN_Wart");
            entity.Property(e => e.TwOutWart).HasColumnName("TW_OUT_Wart");
            entity.Property(e => e.TzewWart).HasColumnName("Tzew_Wart");
            entity.Property(e => e.Vpf1CzasDef).HasColumnName("VPF1_CzasDEF");
            entity.Property(e => e.Vpf1CzasMrozenia).HasColumnName("VPF1_CzasMrozenia");
            entity.Property(e => e.Vpf1StanKod).HasColumnName("VPF1_Stan_Kod");
            entity.Property(e => e.Vpf1TblokScala).HasColumnName("VPF1_Tblok_scala");
            entity.Property(e => e.Vpf2CzasDef).HasColumnName("VPF2_CzasDEF");
            entity.Property(e => e.Vpf2CzasMrozenia).HasColumnName("VPF2_CzasMrozenia");
            entity.Property(e => e.Vpf2StanKod).HasColumnName("VPF2_Stan_Kod");
            entity.Property(e => e.Vpf2TblokScala).HasColumnName("VPF2_Tblok_scala");
            entity.Property(e => e.Vpf3CzasDef).HasColumnName("VPF3_CzasDEF");
            entity.Property(e => e.Vpf3CzasMrozenia).HasColumnName("VPF3_CzasMrozenia");
            entity.Property(e => e.Vpf3StanKod).HasColumnName("VPF3_Stan_Kod");
            entity.Property(e => e.Vpf3TblokScala).HasColumnName("VPF3_Tblok_scala");
            entity.Property(e => e.Vpf4CzasDef).HasColumnName("VPF4_CzasDEF");
            entity.Property(e => e.Vpf4CzasMrozenia).HasColumnName("VPF4_CzasMrozenia");
            entity.Property(e => e.Vpf4StanKod).HasColumnName("VPF4_Stan_Kod");
            entity.Property(e => e.Vpf4TblokScala).HasColumnName("VPF4_Tblok_scala");
            entity.Property(e => e.ZamrazarkaPlytowaId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Zamrazarka_plytowa_ID");
        });

        modelBuilder.Entity<Zmienna>(entity =>
        {
            entity.HasKey(e => e.ZmiennaId).HasName("Zmienna_IDX");

            entity.ToTable("Zmienna");

            entity.Property(e => e.ZmiennaId).HasColumnName("Zmienna_ID");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Opis)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ZmiennaTemp>(entity =>
        {
            entity.HasKey(e => e.ZmiennaTempId).HasName("ZmiennaTemp_IDX");

            entity.ToTable("ZmiennaTemp");

            entity.Property(e => e.ZmiennaTempId).HasColumnName("ZmiennaTemp_ID");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Opis)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

