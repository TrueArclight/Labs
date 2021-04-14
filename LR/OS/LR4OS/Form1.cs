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
using System.Diagnostics;

namespace LR4OS
{
    public partial class Form1 : Form
    {
        private uint num_threads = 0;
        public static int num_process = 0;
        private PROCESS_MEMORY_COUNTERS pmc;
        //modul
        

        //inner enum used only internally
        [Flags]
        private enum SnapshotFlags : uint
        {
            HeapList = 0x00000001,
            Process = 0x00000002,
            Thread = 0x00000004,
            Module = 0x00000008,
            Module32 = 0x00000010,
            Inherit = 0x80000000,
            All = 0x0000001F,
            NoHeaps = 0x40000000
        }
        //inner struct used only internally
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct PROCESSENTRY32
        {
            const int MAX_PATH = 260;
            internal UInt32 dwSize;
            internal UInt32 cntUsage;
            internal UInt32 th32ProcessID;
            internal IntPtr th32DefaultHeapID;
            internal UInt32 th32ModuleID;
            internal UInt32 cntThreads;
            internal UInt32 th32ParentProcessID;
            internal Int32 pcPriClassBase;
            internal UInt32 dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            internal string szExeFile;
        }

        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr CreateToolhelp32Snapshot([In] UInt32 dwFlags, [In] UInt32 th32ProcessID);

        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern bool Process32First([In] IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern bool Process32Next([In] IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle([In] IntPtr hObject);
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentProcess();

        [StructLayout(LayoutKind.Sequential, Size = 40)]
        private struct PROCESS_MEMORY_COUNTERS
        {
            public uint cb;             // The size of the structure, in bytes (DWORD).
            public uint PageFaultCount;         // The number of page faults (DWORD).
            public uint PeakWorkingSetSize;     // The peak working set size, in bytes (SIZE_T).
            public uint WorkingSetSize;         // The current working set size, in bytes (SIZE_T).
            public uint QuotaPeakPagedPoolUsage;    // The peak paged pool usage, in bytes (SIZE_T).
            public uint QuotaPagedPoolUsage;    // The current paged pool usage, in bytes (SIZE_T).
            public uint QuotaPeakNonPagedPoolUsage; // The peak nonpaged pool usage, in bytes (SIZE_T).
            public uint QuotaNonPagedPoolUsage;     // The current nonpaged pool usage, in bytes (SIZE_T).
            public uint PagefileUsage;          // The Commit Charge value in bytes for this process (SIZE_T). Commit Charge is the total amount of memory that the memory manager has committed for a running process.
            public uint PeakPagefileUsage;      // The peak value in bytes of the Commit Charge during the lifetime of this process (SIZE_T).
        }

        [DllImport("psapi.dll", SetLastError = true)]
        static extern bool GetProcessMemoryInfo(IntPtr hProcess, out PROCESS_MEMORY_COUNTERS counters, uint size);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(
            uint processAccess,
            bool bInheritHandle,
            int processId
        );
        [DllImport("kernel32.dll")]
        static extern bool Thread32First(IntPtr hSnapshot, ref THREADENTRY32 lpte);
        [DllImport("kernel32.dll")]
        static extern bool Thread32Next(IntPtr hSnapshot, ref THREADENTRY32 lpte);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct THREADENTRY32
        { 
            internal UInt32 dwSize;
            internal UInt32 cntUsage;
            internal UInt32 th32ThreadID;
            internal UInt32 th32OwnerProcessID;
            internal UInt32 tpBasePri;
            internal Int32 tpDeltaPri;
            internal UInt32 dwFlags;
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [PreserveSig]
        public static extern uint GetModuleFileName
        (   
        [In]
        IntPtr hModule,

        [Out]
        StringBuilder lpFilename,

        [In]
        [MarshalAs(UnmanagedType.U4)]
        int nSize
        );
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll")]
        static extern bool Module32First(IntPtr hSnapshot, ref MODULEENTRY32 lpme);
        [DllImport("kernel32.dll")]
        static extern bool Module32Next(IntPtr hSnapshot, ref MODULEENTRY32 lpme);
        [StructLayout(LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public struct MODULEENTRY32
        {
            internal uint dwSize;
            internal uint th32ModuleID;
            internal uint th32ProcessID;
            internal uint GlblcntUsage;
            internal uint ProccntUsage;
            internal IntPtr modBaseAddr;
            internal uint modBaseSize;
            internal IntPtr hModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            internal string szModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            internal string szExePath;
        }
        enum ThreadPriority
        {
            THREAD_MODE_BACKGROUND_BEGIN = 0x00010000,
            THREAD_MODE_BACKGROUND_END = 0x00020000,
            THREAD_PRIORITY_ABOVE_NORMAL = 1,
            THREAD_PRIORITY_BELOW_NORMAL = -1,
            THREAD_PRIORITY_HIGHEST = 2,
            THREAD_PRIORITY_IDLE = -15,
            THREAD_PRIORITY_LOWEST = -2,
            THREAD_PRIORITY_NORMAL = 0,
            THREAD_PRIORITY_TIME_CRITICAL = 15
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            num_process = 0;
            num_threads = 0;
            IntPtr handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.Process, 0);
            PROCESSENTRY32 procEntry = new PROCESSENTRY32();
            procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(PROCESSENTRY32));
            while (Process32Next(handleToSnapshot, ref procEntry))
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[num_process].Cells[0].Value = num_process;
                dataGridView1.Rows[num_process].Cells[1].Value = procEntry.szExeFile.ToString();
                dataGridView1.Rows[num_process].Cells[2].Value = procEntry.th32ProcessID.ToString();
                dataGridView1.Rows[num_process].Cells[3].Value = procEntry.cntThreads.ToString();


                IntPtr h = OpenProcess((uint)ProcessAccessFlags.QueryInformation, false, (int)procEntry.th32ProcessID);
                if (h != null)
                {
                    pmc.cb = (uint)Marshal.SizeOf(typeof(PROCESS_MEMORY_COUNTERS));
                }
                if (GetProcessMemoryInfo(h, out pmc, pmc.cb))
                {
                    dataGridView1.Rows[num_process].Cells[4].Value = (pmc.WorkingSetSize / 1024) + " кб";
                }
                else
                {
                    dataGridView1.Rows[num_process].Cells[4].Value = "Unknown";
                    CloseHandle(h);
                }
                num_process++;
                num_threads += procEntry.cntThreads;
                
            }
            CloseHandle(handleToSnapshot);
            label1.Text = "Количество потоков: " + num_threads;
            //Threads
            THREADENTRY32 threadEntry = new THREADENTRY32();
            threadEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(THREADENTRY32));
            IntPtr threadSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.Thread, 0);
            int threads = 0;
            while (Thread32Next(threadSnapshot, ref threadEntry))
            {
                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[threads].Cells[0].Value = threads;
                dataGridView2.Rows[threads].Cells[1].Value = threadEntry.th32ThreadID.ToString();
                dataGridView2.Rows[threads].Cells[2].Value = threadEntry.th32OwnerProcessID.ToString();
                switch (threadEntry.tpBasePri)
                {
                    case 4: dataGridView2.Rows[threads].Cells[3].Value = "Ожидающий"; break;
                    case 8: dataGridView2.Rows[threads].Cells[3].Value = "Нормальный"; break;
                    case 13: dataGridView2.Rows[threads].Cells[3].Value = "Высокий"; break;
                    case 24: dataGridView2.Rows[threads].Cells[3].Value = "Реального времени"; break;
                    default: dataGridView2.Rows[threads].Cells[3].Value = "Unknown"; break;
                }
                switch (threadEntry.tpDeltaPri)
                {
                    case (int)ThreadPriority.THREAD_PRIORITY_LOWEST: dataGridView2.Rows[threads].Cells[4].Value = "Lowest"; break;
                    case (int)ThreadPriority.THREAD_PRIORITY_BELOW_NORMAL: dataGridView2.Rows[threads].Cells[4].Value = "Below Normal"; break;
                    case (int)ThreadPriority.THREAD_PRIORITY_NORMAL: dataGridView2.Rows[threads].Cells[4].Value = "Normal"; break;
                    case (int)ThreadPriority.THREAD_PRIORITY_ABOVE_NORMAL: dataGridView2.Rows[threads].Cells[4].Value = "Above normal"; break;
                    case (int)ThreadPriority.THREAD_PRIORITY_HIGHEST: dataGridView2.Rows[threads].Cells[4].Value = "Highest"; break;
                    case (int)ThreadPriority.THREAD_PRIORITY_TIME_CRITICAL: dataGridView2.Rows[threads].Cells[4].Value = "Time critical"; break;
                    case (int)ThreadPriority.THREAD_PRIORITY_IDLE: dataGridView2.Rows[threads].Cells[4].Value = "Idle"; break;
                    default: dataGridView2.Rows[threads].Cells[4].Value = "Unknown"; break;
                }           
                threads++;
            }
            CloseHandle(threadSnapshot); 
            label5.Text ="ID процесса: " + Process.GetCurrentProcess().Id.ToString();
            label6.Text = "Псевдодескриптор: " + Process.GetCurrentProcess().ToString();
            IntPtr h1 = OpenProcess((uint)ProcessAccessFlags.DuplicateHandle, false,  Process.GetCurrentProcess().Id);
            label7.Text = "Дескриптор текущего процесса: " + h1.ToString();
            IntPtr h2 = OpenProcess((uint)ProcessAccessFlags.All, false, Process.GetCurrentProcess().Id);
            label8.Text = "Копия дескриптора текущего процесса: " + h2.ToString();
            CloseHandle(h1);
            CloseHandle(h2);
            StringBuilder fileName = new StringBuilder(255);
            GetModuleFileName(IntPtr.Zero, fileName, fileName.Capacity);
            label10.Text = "Модуль: " + fileName.ToString();
            label11.Text = "Дескриптор модуля: " + GetModuleHandle(fileName.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MODULEENTRY32 me32 = new MODULEENTRY32();
            me32.dwSize = (UInt32)Marshal.SizeOf(typeof(MODULEENTRY32));
            IntPtr hs = CreateToolhelp32Snapshot((uint)SnapshotFlags.Module, 0);
            while (Module32Next(hs, ref me32))
            {
                richTextBox1.Text += '\n' + Encoding.ASCII.GetString(Encoding.Unicode.GetBytes(me32.szModule));
            }
            CloseHandle(hs);
        }
    }
}

