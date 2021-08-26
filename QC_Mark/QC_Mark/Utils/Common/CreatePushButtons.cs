#region Imported Namespaces

//.NET common used namespaces
//Revit.NET common used namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
//QCLibrary.NET common used namespaces
using QCLibraryRevit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

#endregion

namespace QC_Mark
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

            //Imagen de ayuda
            Image imgToolTip = Properties.Resources.QCToolTip; //esta opcion define el la imagen resource para asignar
            ImageSource imgSrcToolTip = ImageUti.GetImageSource(imgToolTip);

            PushButtonData btnData = new PushButtonData(
                "Button",
                "Button",
                Assembly.GetExecutingAssembly().Location,
                "QC_Mark.AppMain"
                )
            {
                ToolTip = "Descripcion corta",
                ToolTipImage = imgSrcToolTip,
                LongDescription = "Descripcion larga",
                Image = imgSrc,
                LargeImage = imgSrc,
            };

            //Contextual Help
            ContextualHelp contextualHelp = new ContextualHelp(
                ContextualHelpType.Url, "https://qcingenieros.com");

            btnData.SetContextualHelp(contextualHelp);

            //Indicar en que condiciones se activa el boton
            if (AvailabilityClassName != string.Empty)
            { btnData.AvailabilityClassName = AvailabilityClassName; }

            return btnData;
        }
    }
}
