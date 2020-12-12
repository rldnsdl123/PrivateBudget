using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Runtime.InteropServices;
using Utility;

namespace PrivateBugetProject
{
    public class WindowViewModel:BasePropertyChange
    {
        private Window _Main;
        private int _OuterMarginSize = 10;


        public bool Borderless { get { return (_Main.WindowState == WindowState.Maximized); } }

        public double WindowMinWidth { get; set; } = 400;
        public double WindowMinHeight { get; set; } = 400;
        public int TitleHegith { get; set; } = 42;
        public int OuterMarginSize
        {
            get
            {
                return _Main.WindowState == WindowState.Maximized ? 0 : _OuterMarginSize;
            }
            set
            {
                _OuterMarginSize = value;
            }
        }

        public int ResizeBorder { get { return Borderless ? 0 : 6; } }
        public Thickness ResizeBorderThickness
        {
            get
            {
                return new Thickness(ResizeBorder + OuterMarginSize);
            }
        }


        public ICommand MinimizeCmd { get; set; }
        public ICommand MaximizeCmd { get; set; }
        public ICommand NormalizeCmd { get; set; }
        public ICommand MenuCmd { get; set; }



        public WindowViewModel(Window mainWindow)
        {
            _Main = mainWindow;

            _Main.StateChanged += _Main_StateChanged;

            MinimizeCmd = new BaseCommand(() => _Main.WindowState = WindowState.Minimized);
            MaximizeCmd = new BaseCommand(() => _Main.WindowState = WindowState.Maximized);
            NormalizeCmd = new BaseCommand(() => _Main.WindowState = WindowState.Normal);
            MenuCmd = new BaseCommand(() => SystemCommands.ShowSystemMenu(mainWindow, GetMouseLocation.GetMousePosition()));

            _Main.MouseLeftButtonDown += _Main_MouseLeftButtonDown;
        }

        private void _Main_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _Main.DragMove();
        }

        private void _Main_StateChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(ResizeBorderThickness));
        }
    }
}
