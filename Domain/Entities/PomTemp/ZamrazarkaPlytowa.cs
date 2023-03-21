using System;
using System.Collections.Generic;

namespace Domain.Entities.PomTemp;

public partial class ZamrazarkaPlytowa
{
    public long ZamrazarkaPlytowaId { get; set; }

    public DateTime Czas { get; set; }

    public int DiW1 { get; set; }

    public int DiW2 { get; set; }

    public int DiW3 { get; set; }

    public int DiW4 { get; set; }

    public int DiW5 { get; set; }

    public int DiW6 { get; set; }

    public int DiW7 { get; set; }

    public int DiW8 { get; set; }

    public int DiW9 { get; set; }

    public int DiW10 { get; set; }

    public int DiW11 { get; set; }

    public int Dc06 { get; set; }

    public double TevapOutWart { get; set; }

    public double TevapInWart { get; set; }

    public double PmrSsWart { get; set; }

    public double PmrTlWart { get; set; }

    public double? PmrZbiornikWart { get; set; }

    public double? TmrZbiornikDefWart { get; set; }

    public double? TmrWym1InWart { get; set; }

    public double? TmrWym1OutWart { get; set; }

    public double? Tr744Wym1OutWart { get; set; }

    public double? Ekd1U20 { get; set; }

    public double? Ekd2U20 { get; set; }

    public double? Ekd1U21 { get; set; }

    public double? Ekd2U21 { get; set; }

    public double? Ekd1U25 { get; set; }

    public double? Ekd2U25 { get; set; }

    public double? Ekd1U26 { get; set; }

    public double? Ekd2U26 { get; set; }

    public double? Ekd1U27 { get; set; }

    public double? Ekd2U27 { get; set; }

    public double? P1analog { get; set; }

    public double? P2analog { get; set; }

    public double? P4analog { get; set; }

    public double? TmaszynWart { get; set; }

    public double? Dpmr { get; set; }

    public int? P1Hours1 { get; set; }

    public int? P1Hours2 { get; set; }

    public int? P2Hours1 { get; set; }

    public int? P2Hours2 { get; set; }

    public int? P3Hours1 { get; set; }

    public int? P3Hours2 { get; set; }

    public int? P4Hours1 { get; set; }

    public int? P4Hours2 { get; set; }

    public int? P5Hours1 { get; set; }

    public int? P5Hours2 { get; set; }

    public int? P6Hours1 { get; set; }

    public int? P6Hours2 { get; set; }

    public double? Dpwl1ConcentPpm { get; set; }

    public double? Dpwl1AlarmPpm { get; set; }

    public double? DpwlSensTime { get; set; }

    public double? P1freq { get; set; }

    public double? P2ferq { get; set; }

    public double? P4freq { get; set; }

    public double? Lt1freq { get; set; }

    public double? Lt2freq { get; set; }

    public double? Lt3freq { get; set; }

    public double? Mt1freq { get; set; }

    public double? Mt2freq { get; set; }

    public double? P1prad { get; set; }

    public double? P2prad { get; set; }

    public double? P4prad { get; set; }

    public double? Lt1prad { get; set; }

    public double? Lt2prad { get; set; }

    public double? Lt3prad { get; set; }

    public double? Mt1prad { get; set; }

    public double? Mt2prad { get; set; }

    public double? FalP1Power { get; set; }

    public double? FalP2Power { get; set; }

    public double? FalP4Power { get; set; }

    public double? FalClt1Power { get; set; }

    public double? FalClt2Power { get; set; }

    public double? FalClt3Power { get; set; }

    public double? FalCmt1Power { get; set; }

    public double? FalCmt2Power { get; set; }

    public double? P1Rpm { get; set; }

    public double? P2Rpm { get; set; }

    public double? P4Rpm { get; set; }

    public double? Clt1Rpm { get; set; }

    public double? Clt2Rpm { get; set; }

    public double? Clt3Rpm { get; set; }

    public double? Cmt1Rpm { get; set; }

    public double? Cmt2Rpm { get; set; }

    public double? Vpf1StanKod { get; set; }

    public double? Vpf2StanKod { get; set; }

    public double? Vpf3StanKod { get; set; }

    public double? Vpf1TblokScala { get; set; }

    public double? Vpf2TblokScala { get; set; }

    public double? Vpf3TblokScala { get; set; }

    public double? TmrOut1Wart { get; set; }

    public double? TmrOut2Wart { get; set; }

    public double? TmrOut3Wart { get; set; }

    public double? Tr744Wym2Out { get; set; }

    public double? Tr744Wym2In { get; set; }

    public double? Tr744Wym3In { get; set; }

    public double? Tr744Wym3Out { get; set; }

    public double? TzewWart { get; set; }

    public double? TgWym3In { get; set; }

    public double? TgWym3Out { get; set; }

    public double? TgWym2Out { get; set; }

    public double? TwInWart { get; set; }

    public double? TwOutWart { get; set; }

    public double? HourNow { get; set; }

    public double? MinuteNow { get; set; }

    public double? StpMr { get; set; }

    public double? StpMrNoc { get; set; }

    public double? StpMrDiff { get; set; }

    public double? DzienStartHour { get; set; }

    public double? DzienStartMin { get; set; }

    public double? DzienStopHour { get; set; }

    public double? DzienStopMin { get; set; }

    public double? Vpf1CzasMrozenia { get; set; }

    public double? Vpf2CzasMrozenia { get; set; }

    public double? Vpf3CzasMrozenia { get; set; }

    public double? Vpf1CzasDef { get; set; }

    public double? Vpf2CzasDef { get; set; }

    public double? Vpf3CzasDef { get; set; }

    public double? Vpf4StanKod { get; set; }

    public double? Vpf4TblokScala { get; set; }

    public double? Vpf4CzasMrozenia { get; set; }

    public double? Vpf4CzasDef { get; set; }

    public double? TmrOut4Wart { get; set; }

    public int DiW12 { get; set; }
}
