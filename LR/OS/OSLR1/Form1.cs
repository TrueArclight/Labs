using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OSLR1
{
    public partial class Form1 : Form
    {
        enum COMPUTER_NAME_FORMAT
        {
            ComputerNameNetBIOS,
            ComputerNameDnsHostname,
            ComputerNameDnsDomain,
            ComputerNameDnsFullyQualified,
            ComputerNamePhysicalNetBIOS,
            ComputerNamePhysicalDnsHostname,
            ComputerNamePhysicalDnsDomain,
            ComputerNamePhysicalDnsFullyQualified
        }

         
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool GetComputerNameEx(COMPUTER_NAME_FORMAT NameType, StringBuilder lpBuffer, ref uint lpnSize);
        enum EXTENDED_NAME_FORMAT
        {
            NameUnknown = 0,
            NameFullyQualifiedDN = 1,
            NameSamCompatible = 2,
            NameDisplay = 3,
            NameUniqueId = 6,
            NameCanonical = 7,
            NameUserPrincipal = 8,
            NameCanonicalEx = 9,
            NameServicePrincipal = 10,
            NameDnsDomain = 12
        }


        [DllImport("secur32.dll", CharSet = CharSet.Auto)]
        public static extern byte GetUserNameEx(int nameFormat, StringBuilder userName, ref int userNameSize);

        
        [DllImport("kernel32.dll")]
        static extern uint GetSystemDirectory([Out] StringBuilder lpBuffer, uint uSize);

        
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct OSVERSIONINFO
        {
            public int dwOSVersionInfoSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szCSDVersion;
            public UInt16 wServicePackMajor;
            public UInt16 wServicePackMinor;
            public UInt16 wSuiteMask;
            public byte wProductType;
            public byte wReserved;
        }
        [DllImport("kernel32")]
        static extern bool GetVersionEx(ref OSVERSIONINFO osvi);
        
        
        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(SystemMetric smIndex);
        public enum SystemMetric
        {
            SM_CXSCREEN = 0,  // 0x00
            SM_CYSCREEN = 1,  // 0x01
            SM_CXVSCROLL = 2,  // 0x02
            SM_CYHSCROLL = 3,  // 0x03
            SM_CYCAPTION = 4,  // 0x04
            SM_CXBORDER = 5,  // 0x05
            SM_CYBORDER = 6,  // 0x06
            SM_CXDLGFRAME = 7,  // 0x07
            SM_CXFIXEDFRAME = 7,  // 0x07
            SM_CYDLGFRAME = 8,  // 0x08
            SM_CYFIXEDFRAME = 8,  // 0x08
            SM_CYVTHUMB = 9,  // 0x09
            SM_CXHTHUMB = 10, // 0x0A
            SM_CXICON = 11, // 0x0B
            SM_CYICON = 12, // 0x0C
            SM_CXCURSOR = 13, // 0x0D
            SM_CYCURSOR = 14, // 0x0E
            SM_CYMENU = 15, // 0x0F
            SM_CXFULLSCREEN = 16, // 0x10
            SM_CYFULLSCREEN = 17, // 0x11
            SM_CYKANJIWINDOW = 18, // 0x12
            SM_MOUSEPRESENT = 19, // 0x13
            SM_CYVSCROLL = 20, // 0x14
            SM_CXHSCROLL = 21, // 0x15
            SM_DEBUG = 22, // 0x16
            SM_SWAPBUTTON = 23, // 0x17
            SM_CXMIN = 28, // 0x1C
            SM_CYMIN = 29, // 0x1D
            SM_CXSIZE = 30, // 0x1E
            SM_CYSIZE = 31, // 0x1F
            SM_CXSIZEFRAME = 32, // 0x20
            SM_CXFRAME = 32, // 0x20
            SM_CYSIZEFRAME = 33, // 0x21
            SM_CYFRAME = 33, // 0x21
            SM_CXMINTRACK = 34, // 0x22
            SM_CYMINTRACK = 35, // 0x23
            SM_CXDOUBLECLK = 36, // 0x24
            SM_CYDOUBLECLK = 37, // 0x25
            SM_CXICONSPACING = 38, // 0x26
            SM_CYICONSPACING = 39, // 0x27
            SM_MENUDROPALIGNMENT = 40, // 0x28
            SM_PENWINDOWS = 41, // 0x29
            SM_DBCSENABLED = 42, // 0x2A
            SM_CMOUSEBUTTONS = 43, // 0x2B
            SM_SECURE = 44, // 0x2C
            SM_CXEDGE = 45, // 0x2D
            SM_CYEDGE = 46, // 0x2E
            SM_CXMINSPACING = 47, // 0x2F
            SM_CYMINSPACING = 48, // 0x30
            SM_CXSMICON = 49, // 0x31
            SM_CYSMICON = 50, // 0x32
            SM_CYSMCAPTION = 51, // 0x33
            SM_CXSMSIZE = 52, // 0x34
            SM_CYSMSIZE = 53, // 0x35
            SM_CXMENUSIZE = 54, // 0x36
            SM_CYMENUSIZE = 55, // 0x37
            SM_ARRANGE = 56, // 0x38
            SM_CXMINIMIZED = 57, // 0x39
            SM_CYMINIMIZED = 58, // 0x3A
            SM_CXMAXTRACK = 59, // 0x3B
            SM_CYMAXTRACK = 60, // 0x3C
            SM_CXMAXIMIZED = 61, // 0x3D
            SM_CYMAXIMIZED = 62, // 0x3E
            SM_NETWORK = 63, // 0x3F
            SM_CLEANBOOT = 67, // 0x43
            SM_CXDRAG = 68, // 0x44
            SM_CYDRAG = 69, // 0x45
            SM_SHOWSOUNDS = 70, // 0x46
            SM_CXMENUCHECK = 71, // 0x47
            SM_CYMENUCHECK = 72, // 0x48
            SM_SLOWMACHINE = 73, // 0x49
            SM_MIDEASTENABLED = 74, // 0x4A
            SM_MOUSEWHEELPRESENT = 75, // 0x4B
            SM_XVIRTUALSCREEN = 76, // 0x4C
            SM_YVIRTUALSCREEN = 77, // 0x4D
            SM_CXVIRTUALSCREEN = 78, // 0x4E
            SM_CYVIRTUALSCREEN = 79, // 0x4F
            SM_CMONITORS = 80, // 0x50
            SM_SAMEDISPLAYFORMAT = 81, // 0x51
            SM_IMMENABLED = 82, // 0x52
            SM_CXFOCUSBORDER = 83, // 0x53
            SM_CYFOCUSBORDER = 84, // 0x54
            SM_TABLETPC = 86, // 0x56
            SM_MEDIACENTER = 87, // 0x57
            SM_STARTER = 88, // 0x58
            SM_SERVERR2 = 89, // 0x59
            SM_MOUSEHORIZONTALWHEELPRESENT = 91, // 0x5B
            SM_CXPADDEDBORDER = 92, // 0x5C
            SM_DIGITIZER = 94, // 0x5E
            SM_MAXIMUMTOUCHES = 95, // 0x5F

            SM_REMOTESESSION = 0x1000, // 0x1000
            SM_SHUTTINGDOWN = 0x2000, // 0x2000
            SM_REMOTECONTROL = 0x2001, // 0x2001


            SM_CONVERTIBLESLATEMODE = 0x2003,
            SM_SYSTEMDOCKED = 0x2004,
        }

        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, StringBuilder pvParam, uint fWinIni);
       
        
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref uint pvParam, uint fWinIni);


        [DllImport("user32.dll")]
        static extern uint GetSysColor(int nIndex);


       
        [DllImport("kernel32.dll")]
        static extern void GetLocalTime(out SYSTEMTIME lpSystemTime);
        

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TIME_ZONE_INFORMATION
        {
            public int bias;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string standardName;
            public SYSTEMTIME standardDate;
            public int standardBias;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string daylightName;
            public SYSTEMTIME daylightDate;
            public int daylightBias;
        }
        [DllImport("kernel32.dll")]
        static extern uint GetTimeZoneInformation(out TIME_ZONE_INFORMATION lpTimeZoneInformation);

        
        [DllImport("kernel32.dll")]
        static extern uint GetTickCount();

        
        [DllImport("user32.dll")]
        static extern int SetSysColors(int cElements, Int32[] lpaElements, Int32[] lpaRgbValues);


        [DllImport("user32.dll")]
        static extern bool DestroyCaret();


        [DllImport("user32.dll")]
        static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);


        [DllImport("user32.dll")]
        static extern bool ShowCaret(IntPtr hWnd);


        [DllImport("kernel32.dll")]
        static extern uint GetEnvironmentVariable(string lpName,
   [Out] StringBuilder lpBuffer, uint nSize);

        [DllImport("kernel32.dll")]
        static extern ushort GetSystemDefaultLangID();

        [DllImport("user32.dll")]
        static extern uint GetDoubleClickTime();


        [DllImport("user32.dll")]
        static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        [Flags]
        public enum ExitWindows : uint
        {
            // ONE of the following five:
            LogOff = 0x00,
            ShutDown = 0x01,
            Reboot = 0x02,
            PowerOff = 0x08,
            RestartApps = 0x40,
            // plus AT MOST ONE of the following two:
            Force = 0x04,
            ForceIfHung = 0x10,
        }
        [Flags]
        enum ShutdownReason : uint
        {
            MajorApplication = 0x00040000,
            MajorHardware = 0x00010000,
            MajorLegacyApi = 0x00070000,
            MajorOperatingSystem = 0x00020000,
            MajorOther = 0x00000000,
            MajorPower = 0x00060000,
            MajorSoftware = 0x00030000,
            MajorSystem = 0x00050000,

            MinorBlueScreen = 0x0000000F,
            MinorCordUnplugged = 0x0000000b,
            MinorDisk = 0x00000007,
            MinorEnvironment = 0x0000000c,
            MinorHardwareDriver = 0x0000000d,
            MinorHotfix = 0x00000011,
            MinorHung = 0x00000005,
            MinorInstallation = 0x00000002,
            MinorMaintenance = 0x00000001,
            MinorMMC = 0x00000019,
            MinorNetworkConnectivity = 0x00000014,
            MinorNetworkCard = 0x00000009,
            MinorOther = 0x00000000,
            MinorOtherDriver = 0x0000000e,
            MinorPowerSupply = 0x0000000a,
            MinorProcessor = 0x00000008,
            MinorReconfig = 0x00000004,
            MinorSecurity = 0x00000013,
            MinorSecurityFix = 0x00000012,
            MinorSecurityFixUninstall = 0x00000018,
            MinorServicePack = 0x00000010,
            MinorServicePackUninstall = 0x00000016,
            MinorTermSrv = 0x00000020,
            MinorUnstable = 0x00000006,
            MinorUpgrade = 0x00000003,
            MinorWMI = 0x00000015,

            FlagUserDefined = 0x40000000,
            FlagPlanned = 0x80000000
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1
            bool success;
            StringBuilder name = new StringBuilder(256);
            uint size = 256;
            success = GetComputerNameEx(COMPUTER_NAME_FORMAT.ComputerNameNetBIOS, name, ref size);
            label1.Text = "Имя компьютера: " + name.ToString(); 
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                label2.Text += "User not found";

            StringBuilder userName = new StringBuilder(1024);
            int userNameSize = userName.Capacity;

            if (0 != GetUserNameEx((int)EXTENDED_NAME_FORMAT.NameSamCompatible, userName, ref userNameSize))
            {
                string[] nameParts = userName.ToString().Split('\\');
                if (2 != nameParts.Length) label2.Text += "User not found";
                label2.Text = "Имя пользователя: " + nameParts[1];
            }
            //2
            StringBuilder sbSystemDir = new StringBuilder(256);
            GetSystemDirectory(sbSystemDir, 256);
            label3.Text = "Системная директория: " + sbSystemDir;
            //3
            OSVERSIONINFO osvi = new OSVERSIONINFO();
            osvi.dwOSVersionInfoSize = Marshal.SizeOf(osvi);
            GetVersionEx(ref osvi);
            label4.Text = "Версия ОС: " + osvi.dwMajorVersion + '.' + osvi.dwMinorVersion + "." + osvi.dwBuildNumber;
            //4
            switch(GetSystemMetrics(SystemMetric.SM_CLEANBOOT)) {
                case 0:
                    label5.Text = "Тип загрузки: Normal boot";
                    break;
                case 1:
                    label5.Text = "Тип загрузки Fail-safe boot";
                    break;
                case 2:
                    label5.Text = "Тип загрузки Fail-safe boot with nerwork";
                    break;
            }
            label6.Text = "Количество кнопок мышки: " + GetSystemMetrics(SystemMetric.SM_CMOUSEBUTTONS);
            label7.Text ="Размер курсора в пикселях: " + GetSystemMetrics(SystemMetric.SM_CXCURSOR);
            //5 
            StringBuilder wp = new StringBuilder(1024);
            const uint SPI_GETDESKWALLPAPER = 0x0073;
            SystemParametersInfo(SPI_GETDESKWALLPAPER, 1024, wp, 0);
            label8.Text = "Путь к обоям рабочего стола: " + wp;

            const uint SPI_GETFONTSMOOTHINGCONTRAST = 0x200C;
            uint contrast = 0;
            SystemParametersInfo(SPI_GETFONTSMOOTHINGCONTRAST, 0, ref contrast, 0);
            label9.Text = "Контрастность: " + contrast;

            const uint SPI_GETKEYBOARDSPEED = 0x000A;
            uint time = 0;
            SystemParametersInfo(SPI_GETKEYBOARDSPEED, 0, ref time, 0);
            label10.Text = "Скорость повтора клавиатуры : " + time;
            //6
            const int COLOR_BTNHILIGHT = 20;
            int color1 = Convert.ToInt32(GetSysColor(COLOR_BTNHILIGHT));
            Color color_1 = Color.FromArgb(color1 & 0xFF, (color1 & 0xFF00) >> 8, (color1 & 0xFF0000) >> 16);
            label11.Text = "Цвет выделенных трехмерных элементов: R:" + color_1.R +" G:" +color_1.G +" B:"+ color_1.B;
            const int COLOR_INACTIVEBORDER = 11;
            int color2 = Convert.ToInt32(GetSysColor(COLOR_INACTIVEBORDER));
            Color color_2 = Color.FromArgb(color2 & 0xFF, (color2 & 0xFF00) >> 8, (color2 & 0xFF0000) >> 16);
            label12.Text = "Цвет неаквтиной границы окна: R:" + color_2.R + " G:" + color_2.G + " B:" + color_2.B;
            const int COLOR_WINDOW = 5;
            int color3 = Convert.ToInt32(GetSysColor(COLOR_WINDOW));
            Color color_3 = Color.FromArgb(color3 & 0xFF, (color3 & 0xFF00) >> 8, (color3 & 0xFF0000) >> 16);
            label13.Text = "Цвет фона окна: R:" + color_3.R + " G:" + color_3.G + " B:" + color_3.B;
            //7
            SYSTEMTIME myLocalTime;
            GetLocalTime(out myLocalTime);
            label14.Text = "Время: " + myLocalTime.wHour + ":" +myLocalTime.wMinute  + ":" + myLocalTime.wSecond
                + " Дата: " +myLocalTime.wDay + "/" + myLocalTime.wMonth +"/" + myLocalTime.wYear;

            TIME_ZONE_INFORMATION tzi;
            GetTimeZoneInformation(out tzi);
            label15.Text = "Time zone info: " +"\nНазвание: "+ tzi.daylightName + "\nGMT offset: " +
                tzi.daylightBias + "\nНазвание: "+ tzi.standardName + "\nGMT offset: " + tzi.standardBias;

            uint timer = GetTickCount();
            timer /= 1000;
            label16.Text = "Время с начала запуска системы: " + timer + " сек";

            //8
            label20.Text = "Переменная среды: " + Environment.GetEnvironmentVariable("COMSPEC").ToString();
            label21.Text = "ID языка Windows: " + GetSystemDefaultLangID().ToString();
            label22.Text = "Время двойного клика: " + GetDoubleClickTime().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const int COLOR_WINDOW = 5;
            Color color = Color.FromArgb(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            int[] elements = { COLOR_WINDOW };
            int[] colors = { System.Drawing.ColorTranslator.ToWin32(color)};
            SetSysColors(elements.Length, elements, colors);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            const int COLOR_BTNHILIGHT = 20;
            Color color = Color.FromArgb(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));
            int[] elements = { COLOR_BTNHILIGHT };
            int[] colors = { System.Drawing.ColorTranslator.ToWin32(color) };
            SetSysColors(elements.Length, elements, colors);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            const int COLOR_INACTIVEBORDER = 11;
            Color color = Color.FromArgb(Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text));
            int[] elements = { COLOR_INACTIVEBORDER };
            int[] colors = { System.Drawing.ColorTranslator.ToWin32(color) };
            SetSysColors(elements.Length, elements, colors);
        }
        private void textBox10_MouseEnter(object sender, EventArgs e)
        {
            CreateCaret(textBox10.Handle, IntPtr.Zero, 6, textBox10.Height);
            ShowCaret(textBox10.Handle);
        }

        private void textBox10_MouseLeave(object sender, EventArgs e)
        {
            DestroyCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ExitWindowsEx((uint)ExitWindows.LogOff, (uint)ShutdownReason.MajorOther | (uint)ShutdownReason.MinorOther);
        }
    }
}
