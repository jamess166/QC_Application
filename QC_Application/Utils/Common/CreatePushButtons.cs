#region Imported Namespaces

//.NET common used namespaces
//Revit.NET common used namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

#endregion

namespace QC_Application
{
    public class CreatePushButtons
    {
        /// <summary>
        /// Crea boton
        /// </summary>
        /// <returns></returns>
        public static PushButtonData PushButton(string AvailabilityClassName)
        {
            //Imagen de Icono
            Image img = Properties.Resources.Icon; //esta opcion define el la imagen resource para asignar
            ImageSource imgSrc = ImageUti.GetImageSource(img);

            PushButtonData btnData = new PushButtonData(
                "Button",
                "Button",
                Assembly.GetExecutingAssembly().Location,
                "QC_Application"
                )
            {
                ToolTip = "Descripcion corta",
                LongDescription = "Descripcion larga",
                Image = imgSrc,
                LargeImage = imgSrc,
            };

            //Buscar File Help
            string file = @"C:\ProgramData\Autodesk\ApplicationPlugins\QC_Application.bundle\Contents\help.html";
            if (File.Exists(file) == false)
                file = @"C:\ProgramData\Autodesk\ApplicationPlugins\QC_Application.bundle\Contents\help\help.html";

            //Contextual Help
            ContextualHelp contextual = new ContextualHelp(ContextualHelpType.Url, file);

            btnData.SetContextualHelp(contextual);

            //Indicar en que condiciones se activa el boton
            if (AvailabilityClassName != string.Empty)
            { btnData.AvailabilityClassName = AvailabilityClassName; }

            return btnData;
        }
    }
}
