//MainWindow.xaml.cs
//Created on 3/6/2020
//Written by Gavin Jessel
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Controls;

namespace SATCalendarWPF
{

    //The code in this document refers to the blurring of the background, as well as the Minimize and Close buttons.
    //THIS CODE HAS NOT BEEN WRITTEN BY ME, I DO NOT TAKE ANY CREDIT FOR IT.
    //I was not able to find the source of this code, I believe it was on a GitHub somewhere however I got this code 4 months ago and
    //can't find it in my history anymore.
    //This code however is sort of similar to what I used: https://github.com/asm512/blurry-background-WPF
    internal enum AccentState
    {
        ACCENT_DISABLED = 0,
        ACCENT_ENABLE_GRADIENT = 1,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_ENABLE_ACRYLICBLURBEHIND = 4,
        ACCENT_INVALID_STATE = 5
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AccentPolicy
    {
        public AccentState AccentState;
        public uint AccentFlags;
        public uint GradientColor;
        public uint AnimationId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    internal enum WindowCompositionAttribute
    {
        // ...
        WCA_ACCENT_POLICY = 19
        // ...
    }

    public partial class MainWindow : Window
    {

        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        private uint _blurOpacity;
        public double BlurOpacity
        {
            get { return _blurOpacity; }
            set { _blurOpacity = (uint)value; EnableBlur(); } 
        }

        private uint _blurBackgroundColor = 0x990000; //BGR colour formatting

        public MainWindow()
        {
            InitializeComponent();

            Loaded += Window_Loaded;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EnableBlur(); //Calls blur function
            frame.NavigationService.Navigate(new LoginWindow()); //Jumps to the LoginWindow.xaml file on launch (This is my code)
        }

        internal void EnableBlur() //Defining background blur effect (function)
        {
            var windowHelper = new WindowInteropHelper(this);

            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND;
            accent.GradientColor = (_blurOpacity << 24) | (_blurBackgroundColor & 0xFFFFFF);

            var accentStructSize = Marshal.SizeOf(accent);

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //My Code
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            //My Code
            WindowState = WindowState.Minimized;
        }

    }
}
