using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace low_level_sendkeys.KernelHotkey
{
    public class Keyboard : Device
    {
        public Keyboard(int id)
        {
            uint num;
            if ((id < 0) || (id > 9))
            {
                throw new ArgumentOutOfRangeException("number");
            }
            string fileName = @"\\.\keyboard" + id.ToString();
            base.device = Device.CreateFile(fileName, FileAccess.Read, FileShare.None, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            if (base.device.IsInvalid)
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
            base.unempty = new ManualResetEvent(false);
            IntPtr handle = base.unempty.SafeWaitHandle.DangerousGetHandle();
            if (!Device.RawSetEvent(base.device, 0x222040, ref handle, (uint) IntPtr.Size, IntPtr.Zero, 0, out num, IntPtr.Zero))
            {
                base.device.Close();
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
            base.ID = id;
        }

        ~Keyboard()
        {
            base.device.Close();
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern bool RawRead(SafeFileHandle Device, uint IoControlCode, IntPtr InBuffer, uint InBufferSize, [In, Out] KEYBOARD_INPUT_DATA[] OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern bool RawRead(SafeFileHandle Device, uint IoControlCode, IntPtr InBuffer, uint InBufferSize, out KEYBOARD_INPUT_DATA OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern bool RawWrite(SafeFileHandle Device, uint IoControlCode, KEYBOARD_INPUT_DATA[] InBuffer, uint InBufferSize, IntPtr OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern bool RawWrite(SafeFileHandle Device, uint IoControlCode, ref KEYBOARD_INPUT_DATA InBuffer, uint InBufferSize, IntPtr OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        public KeyStroke Read()
        {
            KEYBOARD_INPUT_DATA outBuffer = new KEYBOARD_INPUT_DATA();
            uint bytesReturned = 0;
            uint outBufferSize = (uint) Marshal.SizeOf(typeof(KEYBOARD_INPUT_DATA));
            RawRead(base.device, 0x222100, IntPtr.Zero, 0, out outBuffer, outBufferSize, out bytesReturned, IntPtr.Zero);
            if (bytesReturned > 0)
            {
                KeyStroke keyStroke = new KeyStroke();
                keyStroke.code = outBuffer.MakeCode;
                keyStroke.state = (States) outBuffer.Flags;
                keyStroke.information = outBuffer.ExtraInformation;
                return keyStroke;
            }
            return null;
        }

        public uint Read(KeyStroke[] keyStrokes)
        {
            return this.Read(keyStrokes, keyStrokes.Length);
        }

        public uint Read(KeyStroke[] keyStrokes, int number)
        {
            if ((number <= 0) || (keyStrokes.Length < number))
            {
                return 0;
            }
            KEYBOARD_INPUT_DATA[] outBuffer = new KEYBOARD_INPUT_DATA[number];
            uint bytesReturned = 0;
            uint num2 = (uint) Marshal.SizeOf(typeof(KEYBOARD_INPUT_DATA));
            RawRead(base.device, 0x222100, IntPtr.Zero, 0, outBuffer, (uint) (number * num2), out bytesReturned, IntPtr.Zero);
            bytesReturned /= num2;
            for (int i = 0; i < bytesReturned; i++)
            {
                keyStrokes[i].code = outBuffer[i].MakeCode;
                keyStrokes[i].state = (States) outBuffer[i].Flags;
                keyStrokes[i].information = outBuffer[i].ExtraInformation;
            }
            return bytesReturned;
        }

        private static Keyboard[] SelectKeyboards(Device[] devices)
        {
            int num = 0;
            foreach (Device device in devices)
            {
                if (device is Keyboard)
                {
                    num++;
                }
            }
            Keyboard[] keyboardArray = new Keyboard[num];
            num = 0;
            foreach (Device device2 in devices)
            {
                if (device2 is Keyboard)
                {
                    keyboardArray[num++] = (Keyboard) device2;
                }
            }
            return keyboardArray;
        }

        public static Keyboard Wait(Device[] devices)
        {
            return (Keyboard) Device.Wait(SelectKeyboards(devices));
        }

        public static Keyboard Wait(Keyboard[] keyboards)
        {
            return (Keyboard) Device.Wait(keyboards);
        }

        public static Keyboard Wait(Device[] devices, int millisecondsTimeout)
        {
            return (Keyboard) Device.Wait(SelectKeyboards(devices), millisecondsTimeout);
        }

        public static Keyboard Wait(Device[] devices, TimeSpan timeout)
        {
            return (Keyboard) Device.Wait(SelectKeyboards(devices), timeout);
        }

        public static Keyboard Wait(Keyboard[] keyboards, int millisecondsTimeout)
        {
            return (Keyboard) Device.Wait(keyboards, millisecondsTimeout);
        }

        public static Keyboard Wait(Keyboard[] keyboards, TimeSpan timeout)
        {
            return (Keyboard) Device.Wait(keyboards, timeout);
        }

        public static Keyboard Wait(Device[] devices, int millisecondsTimeout, bool exitContext)
        {
            return (Keyboard) Device.Wait(SelectKeyboards(devices), millisecondsTimeout, exitContext);
        }

        public static Keyboard Wait(Device[] devices, TimeSpan timeout, bool exitContext)
        {
            return (Keyboard) Device.Wait(SelectKeyboards(devices), timeout, exitContext);
        }

        public static Keyboard Wait(Keyboard[] keyboards, int millisecondsTimeout, bool exitContext)
        {
            return (Keyboard) Device.Wait(keyboards, millisecondsTimeout, exitContext);
        }

        public static Keyboard Wait(Keyboard[] keyboards, TimeSpan timeout, bool exitContext)
        {
            return (Keyboard) Device.Wait(keyboards, timeout, exitContext);
        }

        public bool Write(KeyStroke keyStroke)
        {
            KEYBOARD_INPUT_DATA inBuffer = new KEYBOARD_INPUT_DATA();
            uint bytesReturned = 0;
            uint inBufferSize = (uint) Marshal.SizeOf(typeof(KEYBOARD_INPUT_DATA));
            inBuffer.UnitId = 0;
            inBuffer.MakeCode = keyStroke.code;
            inBuffer.Flags = (ushort) keyStroke.state;
            inBuffer.Reserved = 0;
            inBuffer.ExtraInformation = keyStroke.information;
            RawWrite(base.device, 0x222080, ref inBuffer, inBufferSize, IntPtr.Zero, 0, out bytesReturned, IntPtr.Zero);
            return (bytesReturned > 0);
        }

        public uint Write(KeyStroke[] keyStrokes)
        {
            return this.Write(keyStrokes, keyStrokes.Length);
        }

        public uint Write(KeyStroke[] keyStrokes, int number)
        {
            if ((number <= 0) || (keyStrokes.Length < number))
            {
                return 0;
            }
            KEYBOARD_INPUT_DATA[] inBuffer = new KEYBOARD_INPUT_DATA[number];
            uint bytesReturned = 0;
            uint num2 = (uint) Marshal.SizeOf(typeof(KEYBOARD_INPUT_DATA));
            for (int i = 0; i < number; i++)
            {
                inBuffer[i].UnitId = 0;
                inBuffer[i].MakeCode = keyStrokes[i].code;
                inBuffer[i].Flags = (ushort) keyStrokes[i].state;
                inBuffer[i].Reserved = 0;
                inBuffer[i].ExtraInformation = keyStrokes[i].information;
            }
            RawWrite(base.device, 0x222080, inBuffer, (uint) (number * num2), IntPtr.Zero, 0, out bytesReturned, IntPtr.Zero);
            return (bytesReturned / num2);
        }

        public void FreeResources()
        {
            if (!device.IsClosed) device.Close();
        }

        public Filters Filter
        {
            get
            {
                ushort num;
                uint num2;
                Device.RawGetFilter(base.device, 0x222020, IntPtr.Zero, 0, out num, 2, out num2, IntPtr.Zero);
                return (Filters) num;
            }
            set
            {
                uint num2;
                ushort inBuffer = (ushort) value;
                Device.RawSetFilter(base.device, 0x222010, ref inBuffer, 2, IntPtr.Zero, 0, out num2, IntPtr.Zero);
            }
        }

        [Flags]
        public enum Filters : ushort
        {
            ALL = 0xffff,
            BREAK = 2,
            E0 = 4,
            E1 = 8,
            MAKE = 1,
            NONE = 0,
            TERMSRV_SET_LED = 0x10,
            TERMSRV_SHADOW = 0x20,
            TERMSRV_VKPACKET = 0x40
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBOARD_INPUT_DATA
        {
            public ushort UnitId;
            public ushort MakeCode;
            public ushort Flags;
            public ushort Reserved;
            public uint ExtraInformation;
        }

        public enum States : ushort
        {
            BREAK = 1,
            E0 = 2,
            E1 = 4,
            MAKE = 0,
            TERMSRV_SET_LED = 8,
            TERMSRV_SHADOW = 0x10,
            TERMSRV_VKPACKET = 0x20
        }
    }
}

