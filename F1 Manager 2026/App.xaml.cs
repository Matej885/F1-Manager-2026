using System;
using System.Windows;

namespace F1_Manager_2026
{
    public partial class App : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            // Toto je "Atómovka". Zastaví proces, vlákna aj hudbu.
            System.Diagnostics.Process.GetCurrentProcess().Kill();

            base.OnExit(e);
        }
    }
}   