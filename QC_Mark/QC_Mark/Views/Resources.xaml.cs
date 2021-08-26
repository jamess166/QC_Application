using System;
using System.Windows;

namespace QC_Mark
{
    /// <summary>
    /// Lógica de interacción para Resources.xaml
    /// </summary>
    public partial class Resources : ResourceDictionary
    {
        private void QCingLink(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://qcingenieros.com");
        }

        private void AddInLink(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://qcingenieros.com");
        }
    }
}
