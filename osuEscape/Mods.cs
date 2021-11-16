using System;

namespace osuEscape
{
    [Flags]
    public enum Mods
    {
        NM = 0,      // No mod
        NF = 1 << 0, // No Fail
        EZ = 1 << 1, // Easy
        TD = 1 << 2, // Touch device
        HD = 1 << 3, // Hidden
        HR = 1 << 4, // Hard Rock
        SD = 1 << 5, // Sudden Death
        DT = 1 << 6, // Double Time
        RX = 1 << 7, // Relax
        HT = 1 << 8, // Half Time
        NC = 1 << 9, // Nightcore
        FL = 1 << 10, // Flashlight
        AT = 1 << 11, // Auto Play
        SO = 1 << 12, // Spun Out
        AP = 1 << 13, // Auto Pilot
        PF = 1 << 14, // Perfect
        K4 = 1 << 15,
        K5 = 1 << 16,
        K6 = 1 << 17,
        K7 = 1 << 18,
        K8 = 1 << 19,
        Fi = 1 << 20,
        Rn = 1 << 21,
        Cm = 1 << 22,
        Tp = 1 << 23,
        K9 = 1 << 24,
        Coop = 1 << 25,
        K1 = 1 << 26,
        K3 = 1 << 27,
        K2 = 1 << 28,
        ScoreV2 = 1 << 29,
        Lm = 1 << 30,
        SpeedChanging = DT | HT | NC,
        MapChanging = HR | EZ | SpeedChanging
    }
}