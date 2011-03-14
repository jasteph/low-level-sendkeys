namespace KernelHotkey
{
    using Microsoft.Win32.SafeHandles;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class Mouse : Device
    {
        public Mouse(int id)
        {
            uint num;
            if ((id < 0) || (id > 9))
            {
                throw new ArgumentOutOfRangeException("id");
            }
            string fileName = @"\\.\mouse" + id.ToString();
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

        ~Mouse()
        {
            base.device.Close();
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern bool RawRead(SafeFileHandle Device, uint IoControlCode, IntPtr InBuffer, uint InBufferSize, [In, Out] MOUSE_INPUT_DATA[] OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern bool RawRead(SafeFileHandle Device, uint IoControlCode, IntPtr InBuffer, uint InBufferSize, out MOUSE_INPUT_DATA OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern bool RawWrite(SafeFileHandle Device, uint IoControlCode, MOUSE_INPUT_DATA[] InBuffer, uint InBufferSize, IntPtr OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint="DeviceIoControl", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern bool RawWrite(SafeFileHandle Device, uint IoControlCode, ref MOUSE_INPUT_DATA InBuffer, uint InBufferSize, IntPtr OutBuffer, uint OutBufferSize, out uint BytesReturned, IntPtr Overlapped);
        public Stroke Read()
        {
            MOUSE_INPUT_DATA outBuffer = new MOUSE_INPUT_DATA();
            uint bytesReturned = 0;
            uint outBufferSize = (uint) Marshal.SizeOf(typeof(MOUSE_INPUT_DATA));
            RawRead(base.device, 0x222100, IntPtr.Zero, 0, out outBuffer, outBufferSize, out bytesReturned, IntPtr.Zero);
            if (bytesReturned > 0)
            {
                Stroke stroke = new Stroke();
                stroke.flags = (Flags) outBuffer.Flags;
                stroke.state = (States) outBuffer.ButtonFlags;
                stroke.rolling = outBuffer.ButtonData;
                stroke.x = outBuffer.LastX;
                stroke.y = outBuffer.LastY;
                stroke.information = outBuffer.ExtraInformation;
                return stroke;
            }
            return null;
        }

        public uint Read(Stroke[] strokes)
        {
            return this.Read(strokes, strokes.Length);
        }

        public uint Read(Stroke[] strokes, int number)
        {
            if ((number == 0) || (strokes.Length < number))
            {
                return 0;
            }
            MOUSE_INPUT_DATA[] outBuffer = new MOUSE_INPUT_DATA[number];
            uint bytesReturned = 0;
            uint num2 = (uint) Marshal.SizeOf(typeof(MOUSE_INPUT_DATA));
            RawRead(base.device, 0x222100, IntPtr.Zero, 0, outBuffer, (uint) (number * num2), out bytesReturned, IntPtr.Zero);
            bytesReturned /= num2;
            for (int i = 0; i < bytesReturned; i++)
            {
                strokes[i].flags = (Flags) outBuffer[i].Flags;
                strokes[i].state = (States) outBuffer[i].ButtonFlags;
                strokes[i].rolling = outBuffer[i].ButtonData;
                strokes[i].x = outBuffer[i].LastX;
                strokes[i].y = outBuffer[i].LastY;
                strokes[i].information = outBuffer[i].ExtraInformation;
            }
            return bytesReturned;
        }

        private static Mouse[] SelectMice(Device[] devices)
        {
            int num = 0;
            foreach (Device device in devices)
            {
                if (device is Mouse)
                {
                    num++;
                }
            }
            Mouse[] mouseArray = new Mouse[num];
            num = 0;
            foreach (Device device2 in devices)
            {
                if (device2 is Mouse)
                {
                    mouseArray[num++] = (Mouse) device2;
                }
            }
            return mouseArray;
        }

        public static Mouse Wait(Device[] devices)
        {
            return (Mouse) Device.Wait(SelectMice(devices));
        }

        public static Mouse Wait(Mouse[] mice)
        {
            return (Mouse) Device.Wait(mice);
        }

        public static Mouse Wait(Device[] devices, int millisecondsTimeout)
        {
            return (Mouse) Device.Wait(SelectMice(devices), millisecondsTimeout);
        }

        public static Mouse Wait(Device[] devices, TimeSpan timeout)
        {
            return (Mouse) Device.Wait(SelectMice(devices), timeout);
        }

        public static Mouse Wait(Mouse[] mice, int millisecondsTimeout)
        {
            return (Mouse) Device.Wait(mice, millisecondsTimeout);
        }

        public static Mouse Wait(Mouse[] mice, TimeSpan timeout)
        {
            return (Mouse) Device.Wait(mice, timeout);
        }

        public static Mouse Wait(Device[] devices, int millisecondsTimeout, bool exitContext)
        {
            return (Mouse) Device.Wait(SelectMice(devices), millisecondsTimeout, exitContext);
        }

        public static Mouse Wait(Device[] devices, TimeSpan timeout, bool exitContext)
        {
            return (Mouse) Device.Wait(SelectMice(devices), timeout, exitContext);
        }

        public static Mouse Wait(Mouse[] mice, int millisecondsTimeout, bool exitContext)
        {
            return (Mouse) Device.Wait(mice, millisecondsTimeout, exitContext);
        }

        public static Mouse Wait(Mouse[] mice, TimeSpan timeout, bool exitContext)
        {
            return (Mouse) Device.Wait(mice, timeout, exitContext);
        }

        public bool Write(Stroke stroke)
        {
            MOUSE_INPUT_DATA inBuffer = new MOUSE_INPUT_DATA();
            uint bytesReturned = 0;
            uint inBufferSize = (uint) Marshal.SizeOf(typeof(MOUSE_INPUT_DATA));
            inBuffer.UnitId = 0;
            inBuffer.Flags = (ushort) stroke.flags;
            inBuffer.ButtonFlags = (ushort) stroke.state;
            inBuffer.ButtonData = stroke.rolling;
            inBuffer.RawButtons = 0;
            inBuffer.LastX = stroke.x;
            inBuffer.LastY = stroke.y;
            inBuffer.ExtraInformation = stroke.information;
            RawWrite(base.device, 0x222080, ref inBuffer, inBufferSize, IntPtr.Zero, 0, out bytesReturned, IntPtr.Zero);
            return (bytesReturned > 0);
        }

        public uint Write(Stroke[] strokes)
        {
            return this.Write(strokes, strokes.Length);
        }

        public uint Write(Stroke[] strokes, int number)
        {
            if ((number == 0) || (strokes.Length < number))
            {
                return 0;
            }
            MOUSE_INPUT_DATA[] inBuffer = new MOUSE_INPUT_DATA[number];
            uint bytesReturned = 0;
            uint num2 = (uint) Marshal.SizeOf(typeof(MOUSE_INPUT_DATA));
            for (int i = 0; i < number; i++)
            {
                inBuffer[i].UnitId = 0;
                inBuffer[i].Flags = (ushort) strokes[i].flags;
                inBuffer[i].ButtonFlags = (ushort) strokes[i].state;
                inBuffer[i].ButtonData = strokes[i].rolling;
                inBuffer[i].RawButtons = 0;
                inBuffer[i].LastX = strokes[i].x;
                inBuffer[i].LastY = strokes[i].y;
                inBuffer[i].ExtraInformation = strokes[i].information;
            }
            RawWrite(base.device, 0x222080, inBuffer, (uint) (number * num2), IntPtr.Zero, 0, out bytesReturned, IntPtr.Zero);
            return (bytesReturned / num2);
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
            BUTTON_1_DOWN = 1,
            BUTTON_1_UP = 2,
            BUTTON_2_DOWN = 4,
            BUTTON_2_UP = 8,
            BUTTON_3_DOWN = 0x10,
            BUTTON_3_UP = 0x20,
            BUTTON_4_DOWN = 0x40,
            BUTTON_4_UP = 0x80,
            BUTTON_5_DOWN = 0x100,
            BUTTON_5_UP = 0x200,
            HWHEEL = 0x800,
            LEFT_BUTTON_DOWN = 1,
            LEFT_BUTTON_UP = 2,
            MIDDLE_BUTTON_DOWN = 0x10,
            MIDDLE_BUTTON_UP = 0x20,
            MOVE = 0x1000,
            NONE = 0,
            RIGHT_BUTTON_DOWN = 4,
            RIGHT_BUTTON_UP = 8,
            WHEEL = 0x400
        }

        public enum Flags : ushort
        {
            ATTRIBUTES_CHANGED = 4,
            MOVE_ABSOLUTE = 1,
            MOVE_NOCOALESCE = 8,
            MOVE_RELATIVE = 0,
            TERMSRV_SRC_SHADOW = 0x100,
            VIRTUAL_DESKTOP = 2
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSE_INPUT_DATA
        {
            public ushort UnitId;
            public ushort Flags;
            public ushort ButtonFlags;
            public short ButtonData;
            public uint RawButtons;
            public int LastX;
            public int LastY;
            public uint ExtraInformation;
        }

        public enum States : ushort
        {
            BUTTON_1_DOWN = 1,
            BUTTON_1_UP = 2,
            BUTTON_2_DOWN = 4,
            BUTTON_2_UP = 8,
            BUTTON_3_DOWN = 0x10,
            BUTTON_3_UP = 0x20,
            BUTTON_4_DOWN = 0x40,
            BUTTON_4_UP = 0x80,
            BUTTON_5_DOWN = 0x100,
            BUTTON_5_UP = 0x200,
            HWHEEL = 0x800,
            LEFT_BUTTON_DOWN = 1,
            LEFT_BUTTON_UP = 2,
            MIDDLE_BUTTON_DOWN = 0x10,
            MIDDLE_BUTTON_UP = 0x20,
            RIGHT_BUTTON_DOWN = 4,
            RIGHT_BUTTON_UP = 8,
            WHEEL = 0x400
        }

        public class Stroke
        {
            public Mouse.Flags flags;
            public uint information;
            public short rolling;
            public Mouse.States state;
            public int x;
            public int y;
        }
    }
}

