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
using System.Runtime;

namespace LR3OS
{
    public partial class Form3 : Form
    {
        private int i;
        private SYSTEM_INFO lpSystemInfo;
        private uint address;

        [DllImport("kernel32.dll", SetLastError = true)]

        internal static extern void GetSystemInfo(ref SYSTEM_INFO Info);
        [StructLayout(LayoutKind.Sequential)]
        internal struct SYSTEM_INFO
        {
            internal ushort wProcessorArchitecture;
            internal ushort wReserved;
            internal uint dwPageSize;
            internal IntPtr lpMinimumApplicationAddress;
            internal IntPtr lpMaximumApplicationAddress;
            internal IntPtr dwActiveProcessorMask;
            internal uint dwNumberOfProcessors;
            internal uint dwProcessorType;
            internal uint dwAllocationGranularity;
            internal ushort wProcessorLevel;
            internal ushort wProcessorRevision;
        }
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
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(
            uint processAccess,
            bool bInheritHandle,
            int processId
        );
        [DllImport("kernel32.dll")]
        static extern int VirtualQueryEx(IntPtr hProcess, uint lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public uint AllocationProtect;
            public IntPtr RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }
        public enum AllocationProtectEnum : uint
        {
            PAGE_EXECUTE = 0x00000010,
            PAGE_EXECUTE_READ = 0x00000020,
            PAGE_EXECUTE_READWRITE = 0x00000040,
            PAGE_EXECUTE_WRITECOPY = 0x00000080,
            PAGE_NOACCESS = 0x00000001,
            PAGE_READONLY = 0x00000002,
            PAGE_READWRITE = 0x00000004,
            PAGE_WRITECOPY = 0x00000008,
            PAGE_GUARD = 0x00000100,
            PAGE_NOCACHE = 0x00000200,
            PAGE_WRITECOMBINE = 0x00000400
        }

        public enum StateEnum : uint
        {
            MEM_COMMIT = 0x1000,
            MEM_FREE = 0x10000,
            MEM_RESERVE = 0x2000
        }

        public enum TypeEnum : uint
        {
            MEM_IMAGE = 0x1000000,
            MEM_MAPPED = 0x40000,
            MEM_PRIVATE = 0x20000
        }

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle([In] IntPtr hObject);
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
            Form2 Main = this.Owner as Form2;
            int rPos = Main.dataGridView1.CurrentRow.Index;
            IntPtr handle = OpenProcess((uint)ProcessAccessFlags.QueryInformation, false, Convert.ToInt32(Main.dataGridView1.Rows[rPos].Cells[2].Value));
            GetSystemInfo(ref lpSystemInfo);
            address = (uint)lpSystemInfo.lpMinimumApplicationAddress;
            MEMORY_BASIC_INFORMATION m;
            i = 0;
            do
            {
                dataGridView2.Rows.Add(1);
                VirtualQueryEx(handle, address, out m, (uint)Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));
                dataGridView2.Rows[i].Cells[0].Value = m.BaseAddress.ToString("X6");
                switch (m.Type)
                {
                    case (uint)TypeEnum.MEM_IMAGE: dataGridView2.Rows[i].Cells[1].Value = "Image"; break;
                    case (uint)TypeEnum.MEM_MAPPED: dataGridView2.Rows[i].Cells[1].Value = "Mapped"; break;
                    case (uint)TypeEnum.MEM_PRIVATE: dataGridView2.Rows[i].Cells[1].Value = "Private"; break;
                    default: dataGridView2.Rows[i].Cells[1].Value = "Unknown"; break;
                }
                dataGridView2.Rows[i].Cells[2].Value = ((uint)m.RegionSize / 1024).ToString();
                switch (m.State)
                {
                    case (uint)StateEnum.MEM_COMMIT: dataGridView2.Rows[i].Cells[3].Value = "Commit"; break;
                    case (uint)StateEnum.MEM_FREE: dataGridView2.Rows[i].Cells[3].Value = "Free"; break;
                    case (uint)StateEnum.MEM_RESERVE: dataGridView2.Rows[i].Cells[3].Value = "Reserveds"; break;
                    default: dataGridView2.Rows[i].Cells[3].Value = "Unknown"; break;
                }
                switch (m.Protect)
                {
                    case (uint)AllocationProtectEnum.PAGE_EXECUTE: dataGridView2.Rows[i].Cells[4].Value = "PAGE_EXECUTE"; break;
                    case (uint)AllocationProtectEnum.PAGE_EXECUTE_READ: dataGridView2.Rows[i].Cells[4].Value = "PAGE_EXECUTE_READ"; break;
                    case (uint)AllocationProtectEnum.PAGE_EXECUTE_READWRITE: dataGridView2.Rows[i].Cells[4].Value = "PAGE_EXECUTE_READWRITE"; break;
                    case (uint)AllocationProtectEnum.PAGE_EXECUTE_WRITECOPY: dataGridView2.Rows[i].Cells[4].Value = "PAGE_EXECUTE_WRITECOPY"; break;
                    case (uint)AllocationProtectEnum.PAGE_NOACCESS: dataGridView2.Rows[i].Cells[4].Value = "PAGE_NOACCESS"; break;
                    case (uint)AllocationProtectEnum.PAGE_READONLY: dataGridView2.Rows[i].Cells[4].Value = "PAGE_READONLY"; break;
                    case (uint)AllocationProtectEnum.PAGE_READWRITE: dataGridView2.Rows[i].Cells[4].Value = "PAGE_READWRITE"; break;
                    case (uint)AllocationProtectEnum.PAGE_WRITECOPY: dataGridView2.Rows[i].Cells[4].Value = "PAGE_WRITECOPY"; break;
                    case (uint)AllocationProtectEnum.PAGE_GUARD: dataGridView2.Rows[i].Cells[4].Value = "PAGE_GUARD"; break;
                    case (uint)AllocationProtectEnum.PAGE_NOCACHE: dataGridView2.Rows[i].Cells[4].Value = "PAGE_NOCACHE"; break;
                    case (uint)AllocationProtectEnum.PAGE_WRITECOMBINE: dataGridView2.Rows[i].Cells[4].Value = "PAGE_WRITECOMBINE"; break;
                    default: dataGridView2.Rows[i].Cells[4].Value = "Unknown"; break;
                }
                i++;
                address += (uint)m.RegionSize;
            } while (address <= (uint)lpSystemInfo.lpMaximumApplicationAddress);

            CloseHandle(handle);
        }
    }
}
