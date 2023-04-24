using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ShowExampleNotification();
            ShowErrorNotification();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void ShowExampleNotification()
        {
            // Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Andrew sent you a picture")
                .AddText("Check this out, The Enchantments in Washington!")
                .Show(); // Not seeing the Show() method? Make sure you have version 7.0, and if you're using .NET 6 (or later), then your TFM must be net6.0-windows10.0.17763.0 or greater
        }

        public static void ShowErrorNotification()
        {
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "warning.png");

            new ToastContentBuilder()
                .AddText("Error")
                .AddText("Se ha producido un error en la aplicación.")
                .AddButton(new ToastButton("Ver detalles", "action=details"))
                .AddButton(new ToastButtonDismiss("Cerrar"))
                .SetToastDuration(ToastDuration.Long)
                .AddAppLogoOverride(new Uri(imagePath))
                .AddAudio(new ToastAudio() { Src = new Uri("ms-winsoundevent:Notification.Looping.Alarm2"), Silent = false })
                .Show();
        }
    }
}
