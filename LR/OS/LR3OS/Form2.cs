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

namespace LR3OS
{
    public partial class Form2 : Form
    {
        private uint num_threads = 0;
        public static int num_process = 0;
        private PROCESS_MEMORY_COUNTERS pmc;

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

        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
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
                }
                num_process++;
                num_threads += procEntry.cntThreads;
            }
            
            CloseHandle(handleToSnapshot);
            label1.Text += num_threads;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 addRec = new Form3();
            addRec.Owner = this;
            addRec.ShowDialog();
        }
    }
}
