using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    /// <remarks/>
    [Serializable( )]
    public enum DeviceVendorEnum
    {

        /// <remarks/>
        [XmlEnum( "ABOV Semiconductor:126" )]
        ABOVSemiconductor126,

        /// <remarks/>
        [XmlEnum( "Actel:56" )]
        Actel56,

        /// <remarks/>
        [XmlEnum( "Altera:85" )]
        Altera85,

        /// <remarks/>
        [XmlEnum( "Altium:65" )]
        Altium65,

        /// <remarks/>
        [XmlEnum( "Ambiq Micro:120" )]
        AmbiqMicro120,

        /// <remarks/>
        [XmlEnum( "Analog Devices:1" )]
        AnalogDevices1,

        /// <remarks/>
        [XmlEnum( "ARM:82" )]
        ARM82,

        /// <remarks/>
        [XmlEnum( "ARM CMSIS:109" )]
        ARMCMSIS109,

        /// <remarks/>
        [XmlEnum( "Atmel:3" )]
        Atmel3,

        /// <remarks/>
        [XmlEnum( "CSR:118" )]
        CSR118,

        /// <remarks/>
        [XmlEnum( "Cypress:19" )]
        Cypress19,

        /// <remarks/>
        [XmlEnum( "Dialog Semiconductor:113" )]
        DialogSemiconductor113,

        /// <remarks/>
        [XmlEnum( "Dolphin:57" )]
        Dolphin57,

        /// <remarks/>
        [XmlEnum( "Domosys:26" )]
        Domosys26,

        /// <remarks/>
        [XmlEnum( "Ember:98" )]
        Ember98,

        /// <remarks/>
        [XmlEnum( "Energy Micro:97" )]
        EnergyMicro97,

        /// <remarks/>
        [XmlEnum( "EnOcean:91" )]
        EnOcean91,

        /// <remarks/>
        [XmlEnum( "Evatronix:64" )]
        Evatronix64,

        /// <remarks/>
        [XmlEnum( "Freescale:78" )]
        Freescale78,

        /// <remarks/>
        [XmlEnum( "Generic:5" )]
        Generic5,

        /// <remarks/>
        [XmlEnum( "GigaDevice:123" )]
        GigaDevice123,

        /// <remarks/>
        [XmlEnum( "Holtek:106" )]
        Holtek106,

        /// <remarks/>
        [XmlEnum( "Hynix Semiconductor:6" )]
        HynixSemiconductor6,

        /// <remarks/>
        [XmlEnum( "Hyundai:35" )]
        Hyundai35,

        /// <remarks/>
        [XmlEnum( "Infineon:7" )]
        Infineon7,

        /// <remarks/>
        [XmlEnum( "Kionix:127" )]
        Kionix127,

        /// <remarks/>
        [XmlEnum( "Lapis Semiconductor:10" )]
        LapisSemiconductor10,

        /// <remarks/>
        [XmlEnum( "Luminary Micro:76" )]
        LuminaryMicro76,

        /// <remarks/>
        [XmlEnum( "Maxim:23" )]
        Maxim23,

        /// <remarks>
        /// This is missing from the official schema, but found in the Keil Repository... 
        /// </remarks>
        [XmlEnum( "MediaTek:129" )]
        MediaTek129,

        /// <remarks/>
        [XmlEnum( "MegaChips:128" )]
        MegaChips128,

        /// <remarks/>
        [XmlEnum( "Mentor Graphics Co.:24" )]
        MentorGraphicsCo24,

        /// <remarks/>
        [XmlEnum( "Micronas:30" )]
        Micronas30,

        /// <remarks/>
        [XmlEnum( "Microsemi:112" )]
        Microsemi112,

        /// <remarks/>
        [XmlEnum( "Milandr:99" )]
        Milandr99,

        /// <remarks/>
        [XmlEnum( "NetSilicon:67" )]
        NetSilicon67,

        /// <remarks/>
        [XmlEnum( "Nordic Semiconductor:54" )]
        NordicSemiconductor54,

        /// <remarks/>
        [XmlEnum( "Nuvoton:18" )]
        Nuvoton18,

        /// <remarks/>
        [XmlEnum( "NXP:11" )]
        NXP11,

        /// <remarks/>
        [XmlEnum( "OKI SEMICONDUCTOR CO.,LTD.:108" )]
        OKISEMICONDUCTORCOLTD108,

        /// <remarks/>
        [XmlEnum( "Realtek Semiconductor:124" )]
        RealtekSemiconductor124,

        /// <remarks/>
        [XmlEnum( "Redpine Signals:125" )]
        RedpineSignals125,

        /// <remarks/>
        [XmlEnum( "Renesas:117" )]
        Renesas117,

        /// <remarks/>
        [XmlEnum( "ROHM:103" )]
        ROHM103,

        /// <remarks/>
        [XmlEnum( "Samsung:47" )]
        Samsung47,

        /// <remarks/>
        [XmlEnum( "Silicon Labs:21" )]
        SiliconLabs21,

        /// <remarks/>
        [XmlEnum( "SONiX:110" )]
        SONiX110,

        /// <remarks/>
        [XmlEnum( "Spansion:100" )]
        Spansion100,

        /// <remarks/>
        [XmlEnum( "STMicroelectronics:13" )]
        STMicroelectronics13,

        /// <remarks/>
        [XmlEnum( "Sunrise Micro Devices:121" )]
        SunriseMicroDevices121,

        /// <remarks/>
        [XmlEnum( "TI:16" )]
        TI16,

        /// <remarks/>
        [XmlEnum( "Texas Instruments:16" )]
        TexasInstruments16,

        /// <remarks/>
        [XmlEnum( "Toshiba:92" )]
        Toshiba92,

        /// <remarks/>
        [XmlEnum( "Triad Semiconductor:104" )]
        TriadSemiconductor104,

        /// <remarks/>
        [XmlEnum( "WIZnet:122" )]
        WIZnet122,

        /// <remarks/>
        [XmlEnum( "Freescale Semiconductor:78" )]
        FreescaleSemiconductor78,

        /// <remarks/>
        [XmlEnum( "NXP (founded by Philips):11" )]
        NXPfoundedbyPhilips11,
    }

    /// <remarks/>
    [Serializable( )]
    [XmlType( IncludeInSchema=false)]
    public enum ItemsChoiceType1 {
    
        /// <remarks/>
        category,
    
        /// <remarks/>
        component,
    
        /// <remarks/>
        keyword,
    }

    [Serializable( )]
    public enum DcoreEnum {
    
        /// <remarks/>
        SC000,
    
        /// <remarks/>
        SC300,
    
        /// <remarks/>
        [XmlEnum( "Cortex-M0")]
        CortexM0,
    
        /// <remarks/>
        [XmlEnum( "Cortex-M0+")]
        CortexM01,
    
        /// <remarks/>
        [XmlEnum( "Cortex-M1")]
        CortexM1,
    
        /// <remarks/>
        [XmlEnum( "Cortex-M3")]
        CortexM3,
    
        /// <remarks/>
        [XmlEnum( "Cortex-M4")]
        CortexM4,
    
        /// <remarks/>
        [XmlEnum( "Cortex-M7")]
        CortexM7,
    
        /// <remarks/>
        [XmlEnum( "Cortex-R4")]
        CortexR4,
    
        /// <remarks/>
        [XmlEnum( "Cortex-R5")]
        CortexR5,
    
        /// <remarks/>
        [XmlEnum( "Cortex-A5")]
        CortexA5,
    
        /// <remarks/>
        [XmlEnum( "Cortex-A7")]
        CortexA7,
    
        /// <remarks/>
        [XmlEnum( "Cortex-A8")]
        CortexA8,
    
        /// <remarks/>
        [XmlEnum( "Cortex-A9")]
        CortexA9,
    
        /// <remarks/>
        [XmlEnum( "Cortex-A15")]
        CortexA15,
    
        /// <remarks/>
        [XmlEnum( "Cortex-A17")]
        CortexA17,
    
        /// <remarks/>
        [XmlEnum( "Cortex-A53")]
        CortexA53,
    
        /// <remarks/>
        [XmlEnum( "Cortex-A57")]
        CortexA57,
    
        /// <remarks/>
        [XmlEnum( "Cortex-A72")]
        CortexA72,
    
        /// <remarks/>
        other,
    }

    [Serializable( )]
    public enum DfpuEnum {
    
        /// <remarks/>
        FPU,
    
        /// <remarks/>
        [XmlEnum( "1")]
        Item1,
    
        /// <remarks/>
        NO_FPU,
    
        /// <remarks/>
        [XmlEnum( "0")]
        Item0,
    
        /// <remarks/>
        SP_FPU,
    
        /// <remarks/>
        DP_FPU,
    
        /// <remarks/>
        [XmlEnum( "*")]
        Item,
    }

    [Serializable( )]
    public enum DmpuEnum {
    
        /// <remarks/>
        MPU,
    
        /// <remarks/>
        NO_MPU,
    
        /// <remarks/>
        [XmlEnum( "0")]
        Item0,
    
        /// <remarks/>
        [XmlEnum( "1")]
        Item1,
    
        /// <remarks/>
        [XmlEnum( "*")]
        Item,
    }

    [Serializable( )]
    public enum DendianEnum {
    
        /// <remarks/>
        [XmlEnum( "Little-endian")]
        Littleendian,
    
        /// <remarks/>
        [XmlEnum( "Big-endian")]
        Bigendian,
    
        /// <remarks/>
        Configurable,
    
        /// <remarks/>
        [XmlEnum( "*")]
        Item,
    }

    [Serializable( )]
    public enum DebugProtocolEnum {
    
        /// <remarks/>
        jtag,
    
        /// <remarks/>
        swd,
    }

    [Serializable( )]
    public enum MemoryIDTypeEnum {
    
        /// <remarks/>
        IRAM1,
    
        /// <remarks/>
        IRAM2,
    
        /// <remarks/>
        IRAM3,
    
        /// <remarks/>
        IRAM4,
    
        /// <remarks/>
        IRAM5,
    
        /// <remarks/>
        IRAM6,
    
        /// <remarks/>
        IRAM7,
    
        /// <remarks/>
        IRAM8,
    
        /// <remarks/>
        IROM1,
    
        /// <remarks/>
        IROM2,
    
        /// <remarks/>
        IROM3,
    
        /// <remarks/>
        IROM4,
    
        /// <remarks/>
        IROM5,
    
        /// <remarks/>
        IROM6,
    
        /// <remarks/>
        IROM7,
    
        /// <remarks/>
        IROM8,
    }

    /// <remarks/>
    [GeneratedCode( "xsd", "4.6.1055.0")]
    [Serializable( )]
    public enum DataPatchAccessTypeEnum {
    
        /// <remarks/>
        DP,
    
        /// <remarks/>
        AP,
    
        /// <remarks/>
        Mem,
    }

}