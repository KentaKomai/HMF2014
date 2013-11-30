﻿using System;
using System.Runtime.InteropServices;

namespace WpfFaceMatch.Models.Win32
{
	static class NativeMethods
	{
		public static WS GetWindowLong(this IntPtr hWnd)
		{
			return (WS)NativeMethods.GetWindowLong(hWnd, (int)GWL.STYLE);
		}
		public static WSEX GetWindowLongEx(this IntPtr hWnd)
		{
			return (WSEX)NativeMethods.GetWindowLong(hWnd, (int)GWL.EXSTYLE);
		}

		[DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
		public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		public static WS SetWindowLong(this IntPtr hWnd, WS dwNewLong)
		{
			return (WS)NativeMethods.SetWindowLong(hWnd, (int)GWL.STYLE, (int)dwNewLong);
		}
		public static WSEX SetWindowLongEx(this IntPtr hWnd, WSEX dwNewLong)
		{
			return (WSEX)NativeMethods.SetWindowLong(hWnd, (int)GWL.EXSTYLE, (int)dwNewLong);
		}
		
		[DllImport("user32.dll")]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SWP flags);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool PostMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr SendMessage(IntPtr hWnd, WM msg, IntPtr wParam, IntPtr lParam);

		public static ClassStyles GetClassLong(this IntPtr hwnd, ClassLongFlags flags)
		{
			if (IntPtr.Size == 8)
			{
				return (ClassStyles)NativeMethods.GetClassLong64(hwnd, flags);
			}
			return (ClassStyles)NativeMethods.GetClassLong32(hwnd, flags);
		}

		[DllImport("user32.dll", EntryPoint="GetClassLong")]
		public static extern IntPtr GetClassLong32(IntPtr hwnd, ClassLongFlags nIndex);

		[DllImport("user32.dll", EntryPoint="GetClassLongPtr")]
		public static extern IntPtr GetClassLong64(IntPtr hwnd, ClassLongFlags nIndex);

		public static ClassStyles SetClassLong(this IntPtr hwnd, ClassLongFlags flags, ClassStyles dwLong)
		{
			if (IntPtr.Size == 8)
			{
				return (ClassStyles)NativeMethods.SetClassLong64(hwnd, flags, (IntPtr)dwLong);
			}
			return (ClassStyles)NativeMethods.SetClassLong32(hwnd, flags, (IntPtr)dwLong);
		}

		[DllImport("user32.dll", EntryPoint="SetClassLong")]
		public static extern IntPtr SetClassLong32(IntPtr hWnd, ClassLongFlags nIndex, IntPtr dwNewLong);

		[DllImport("user32.dll", EntryPoint="SetClassLongPtr")]
		public static extern IntPtr SetClassLong64(IntPtr hWnd, ClassLongFlags nIndex, IntPtr dwNewLong);
	}
}
