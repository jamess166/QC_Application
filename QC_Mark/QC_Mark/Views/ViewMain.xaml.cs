#region Imported Namespaces

//.NET common used namespaces
//Revit.NET common used namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
//Revit.NET extend used namespaces
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
//QCLibrary.NET common used namespaces
using QCLibraryRevit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

#endregion

namespace QC_Mark
{
    /// <summary>
    /// Lógica de interacción para ViewMain.xaml
    /// </summary>
    public partial class ViewMain : Window
    {
        /// <summary>
        /// Altura inicial de vista
        /// </summary>
        private static double ThisHeigth;

        private static bool IsMinimize;

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewMain()
        {
            InitializeComponent();
            ThisHeigth = this.Height;
            IsMinimize = false;
        }

        /// <summary>
        /// Restaura la vista a tamaño normal
        /// </summary>
        public void ChangeHeigth()
        {
            if (IsMinimize)
            {
                this.Height = ThisHeigth;
                IsMinimize = false;
            }
            else
            {
                this.Height = 70;
                IsMinimize = true;
            }
        }

        /// <summary>
        /// Restaurar ventana al darle doble click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TtitleButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChangeHeigth();
        }

        /// <summary>
        /// Informacion de la version del proyecto
        /// </summary>
        public string projectVersion = CommonAssemblyInfo.Number;
        public string ProjectVersion
        {
            get { return projectVersion; }
            set { projectVersion = value; }
        }

        /// <summary>
        /// Evento para activar el movimiento de la vista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        /// <summary>
        /// Evento para cerra el boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento para cargar logo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgLogo_Loaded(object sender, RoutedEventArgs e)
        {
            //esta opcion define el la imagen resource para asignar 
            System.Drawing.Image img = Properties.Resources.Icon;
            ImageSource imgSrc = ImageUti.GetImageSource(img);
            this.Icon = imgSrc;
            this.imgLogo.Source = imgSrc;
        }

        /// <summary>
        /// Accion principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Boton Principal
        }
    }
}
