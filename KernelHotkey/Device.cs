using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace low_level_sendkeys.KernelHotkey
{
    public abstract class Device
    {
        protected SafeFileHandle device;
        protected const uint IOCTL_GET_FILTER = 0x222020;
        protected const uint IOCTL_GET_PRECEDENCE = 0x222008;
        protected const uint IOCTL_READ = 0x222100;
        protected const uint IOCTL_SET_EVENT = 0x222040;
        protected const uint IOCTL_SET_FILTER = 0x222010;
        protected const uint IOCTL_SET_PRECEDENCE = 0x222004;
        protected const uint IOCTL_WRITE = 0x222080;
        protected ManualResetEvent unempty;
        private int v;

        protected Device()
        {
        }

        [DllImport("kernel32.dll", CharSet=CharSet.Auto, SetLastError=true)]
        protected static extern SafeFileHandle CreateFile(string FileName, [MarshalAs(UnmanagedType.U4)] FileAccess DesiredAccess, [MarshalAs(UnmanagedType.U4)] FileShare ShareMode, IntPtr SecurityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode CreationDisposition, [MarshalAs(UnmanagedType.U4)] FileAttributes FlagsAndAttributes, IntPtr TemplateFile);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        protected static extern bool RawGetFilter(SafeFileHandle Device, uint IoControlCode, IntPtr InBuffer, uint InBufferSize, out ushort OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        protected static extern bool RawGetPrecedence(SafeFileHandle Device, uint IoControlCode, IntPtr InBuffer, uint InBufferSize, out int OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        protected static extern bool RawSetEvent(SafeFileHandle Device, uint IoControlCode, ref IntPtr InBuffer, uint InBufferSize, IntPtr OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        protected static extern bool RawSetFilter(SafeFileHandle Device, uint IoControlCode, ref ushort InBuffer, uint InBufferSize, IntPtr OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        protected static extern bool RawSetPrecedence(SafeFileHandle Device, uint IoControlCode, ref int InBuffer, uint InBufferSize, IntPtr OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        public bool Wait()
        {
            return this.unempty.WaitOne();
        }

        public bool Wait(int millisecondsTimeout)
        {
            return this.unempty.WaitOne(millisecondsTimeout, false);
        }

        public bool Wait(TimeSpan timeout)
        {
            return this.unempty.WaitOne(timeout, false);
        }

        public static Device Wait(Device[] devices)
        {
            return Wait(devices, -1, false);
        }

        public static Device Wait(Device[] devices, int millisecondsTimeout)
        {
            return Wait(devices, millisecondsTimeout, false);
        }

        public bool Wait(TimeSpan timeout, bool exitContext)
        {
            return this.unempty.WaitOne(timeout, exitContext);
        }

        public static Device Wait(Device[] devices, TimeSpan timeout)
        {
            return Wait(devices, timeout, false);
        }

        public bool Wait(int millisecondsTimeout, bool exitContext)
        {
            return this.unempty.WaitOne(millisecondsTimeout, exitContext);
        }

        public static Device Wait(Device[] devices, int millisecondsTimeout, bool exitContext)
        {
            ManualResetEvent[] waitHandles = new ManualResetEvent[devices.Length];
            for (int i = 0; i < devices.Length; i++)
            {
                waitHandles[i] = devices[i].unempty;
            }
            int index = WaitHandle.WaitAny(waitHandles, millisecondsTimeout, exitContext);
            if (index == 0x102)
            {
                return null;
            }
            return devices[index];
        }

        public static Device Wait(Device[] devices, TimeSpan timeout, bool exitContext)
        {
            ManualResetEvent[] waitHandles = new ManualResetEvent[devices.Length];
            for (int i = 0; i < devices.Length; i++)
            {
                waitHandles[i] = devices[i].unempty;
            }
            int index = WaitHandle.WaitAny(waitHandles, timeout, exitContext);
            if (index == 0x102)
            {
                return null;
            }
            return devices[index];
        }

        public int ID
        {
            get
            {
                return this.v;
            }
            protected set
            {
                this.v = value;
            }
        }

        public int Precedence
        {
            get
            {
                int num;
                uint num2;
                RawGetPrecedence(this.device, 0x222008, IntPtr.Zero, 0, out num, 4, out num2, IntPtr.Zero);
                return num;
            }
            set
            {
                uint num;
                RawSetPrecedence(this.device, 0x222004, ref value, 4, IntPtr.Zero, 0, out num, IntPtr.Zero);
            }
        }
    }
}

