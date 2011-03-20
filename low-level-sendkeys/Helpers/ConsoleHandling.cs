﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace low_level_sendkeys.Helpers
{
    internal class ConsoleHandling
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(UInt32 dwProcessId);
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        private static extern bool GetFileInformationByHandle(SafeFileHandle hFile, out BY_HANDLE_FILE_INFORMATION lpFileInformation);
        [DllImport("kernel32.dll")]
        private static extern SafeFileHandle GetStdHandle(UInt32 nStdHandle);
        [DllImport("kernel32.dll")]
        private static extern bool SetStdHandle(UInt32 nStdHandle, SafeFileHandle hHandle);
        [DllImport("kernel32.dll")]
        private static extern bool DuplicateHandle(IntPtr hSourceProcessHandle, SafeFileHandle hSourceHandle, IntPtr hTargetProcessHandle,
        out SafeFileHandle lpTargetHandle, UInt32 dwDesiredAccess, Boolean bInheritHandle, UInt32 dwOptions);

        private const UInt32 ATTACH_PARENT_PROCESS = 0xFFFFFFFF;
        private const UInt32 STD_INPUT_HANDLE = 0xFFFFFFF6;
        private const UInt32 STD_OUTPUT_HANDLE = 0xFFFFFFF5;
        private const UInt32 STD_ERROR_HANDLE = 0xFFFFFFF4;
        private const UInt32 DUPLICATE_SAME_ACCESS = 2;

        static SafeFileHandle hStdIn, hStdOut, hStdErr, hStdOutDup, hStdErrDup, hStdInDup;
        static BY_HANDLE_FILE_INFORMATION bhfi;

        private struct BY_HANDLE_FILE_INFORMATION
        {
            public UInt32 FileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME CreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastWriteTime;
            public UInt32 VolumeSerialNumber;
            public UInt32 FileSizeHigh;
            public UInt32 FileSizeLow;
            public UInt32 NumberOfLinks;
            public UInt32 FileIndexHigh;
            public UInt32 FileIndexLow;
        }

        internal static void InitConsoleHandles()
        {
            hStdIn = GetStdHandle(STD_INPUT_HANDLE);
            hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
            hStdErr = GetStdHandle(STD_ERROR_HANDLE);

            // Get current process handle
            IntPtr hProcess = Process.GetCurrentProcess().Handle;

            // Duplicate Stdout handle to save initial value
            DuplicateHandle(hProcess, hStdIn, hProcess, out hStdInDup, 0, true, DUPLICATE_SAME_ACCESS);

            // Duplicate Stdout handle to save initial value
            DuplicateHandle(hProcess, hStdOut, hProcess, out hStdOutDup, 0, true, DUPLICATE_SAME_ACCESS);

            // Duplicate Stderr handle to save initial value
            DuplicateHandle(hProcess, hStdErr, hProcess, out hStdErrDup, 0, true, DUPLICATE_SAME_ACCESS);

            // Attach to console window – this may modify the standard handles
            AttachConsole(ATTACH_PARENT_PROCESS);
            //AllocConsole();

            // Adjust the standard handles
            if (GetFileInformationByHandle(GetStdHandle(STD_INPUT_HANDLE), out bhfi))
            {
                SetStdHandle(STD_INPUT_HANDLE, hStdInDup);
            }
            else
            {
                SetStdHandle(STD_INPUT_HANDLE, hStdIn);
            }

            if (GetFileInformationByHandle(GetStdHandle(STD_OUTPUT_HANDLE), out bhfi))
            {
                SetStdHandle(STD_OUTPUT_HANDLE, hStdOutDup);
            }
            else
            {
                SetStdHandle(STD_OUTPUT_HANDLE, hStdOut);
            }

            if (GetFileInformationByHandle(GetStdHandle(STD_ERROR_HANDLE), out bhfi))
            {
                SetStdHandle(STD_ERROR_HANDLE, hStdErrDup);
            }
            else
            {
                SetStdHandle(STD_ERROR_HANDLE, hStdErr);
            }
        }

        internal static void ReleaseConsoleHandles()
        {
            //System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            FreeConsole();
        }
    }
}
