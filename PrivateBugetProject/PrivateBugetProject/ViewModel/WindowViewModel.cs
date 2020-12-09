﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace PrivateBugetProject
{
    public class WindowViewModel:BasePropertyChange
    {
        private Window _Main;

        public double WindowMinWidth { get; set; } = 400;
        public double WindowMinHeight { get; set; } = 400;
        public ICommand MinimizeCmd { get; set; }
        public ICommand MaximizeCmd { get; set; }
        public ICommand ExitCmd { get; set; }


        public WindowViewModel(Window mainWindow)
        {
            _Main = mainWindow;

            _Main.StateChanged += _Main_StateChanged;

            MinimizeCmd = new BaseCommand(() => _Main.WindowState = WindowState.Minimized);
            MaximizeCmd = new BaseCommand(() => _Main.WindowState = WindowState.Maximized);
            ExitCmd = new BaseCommand(() => _Main.WindowState = WindowState.Normal);
        }

        private void _Main_StateChanged(object sender, EventArgs e)
        { 

        }
    }
}
