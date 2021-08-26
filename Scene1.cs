using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

namespace MiniKi
{
    public class Scene1 : NUIApplication
    {
       
        override protected void OnCreate()
        {
            base.OnCreate();


            FontClient.Instance.AddCustomFontDirectory(ApplicationHelper.ResoucePath + "font/");
            // NOTE To use theme.xaml, uncomment below line.
            ThemeManager.ApplyTheme(new Theme(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "theme/theme.xaml"));

            

            GetDefaultWindow().AddAvailableOrientation(Window.WindowOrientation.Portrait);
            GetDefaultWindow().SetPreferredOrientation(Window.WindowOrientation.Portrait);



            //Set default transition option
            GetDefaultWindow().GetDefaultNavigator().Transition = new Transition()
            {
                AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOutSine),
            };

            //(2021/08/24, large view mode 추가)
            //(ori)
            //GetDefaultWindow().GetDefaultNavigator().Push(new MainPage1());
            //(chg)
            GetDefaultWindow().GetDefaultNavigator().Push(new MainPage());

            //(ok)
            //GetDefaultWindow().Add(new MainPage1());

            GetDefaultWindow().KeyEvent += OnScene1KeyEvent;

            Tizen.Log.Info("MiniKi", "Scen1::onCreate()");
        }

        private void OnScene1KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        override protected void OnPause()
        {
            base.OnPause();
        }

        override protected void OnResume()
        {
            base.OnResume();
        }

        override protected void OnTerminate()
        {
            base.OnTerminate();
        }

        override protected void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            base.OnAppControlReceived(e);
        }
    }
}

//(참고1)
//private readonly Color[] button1Colors = {
//            Color.Black,
//            Color.Red,
//            Color.Green,
//            Color.Blue,
//            new Color(global::System.Drawing.Color.FromName("Pink")),
//            new Color(global::System.Drawing.Color.FromName("Olive")),
//            new Color(global::System.Drawing.Color.FromName("Lime")),
//            new Color(global::System.Drawing.Color.FromName("Aqua")),
//            new Color(global::System.Drawing.Color.FromName("Navy")),
//            Color.White,
//        };