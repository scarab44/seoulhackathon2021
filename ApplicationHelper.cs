using System.Collections.Generic;
using Tizen.Applications;
using Tizen.NUI;

namespace MiniKi
{
    public static class ApplicationHelper
    {

        public static readonly string ResoucePath = Application.Current.DirectoryInfo.Resource;

        public static GaussianBlurView MainGaussianBlurView = null;

        //(del by hch, 2021/08/20)
        //public static List<MenuItem> OrderList = new List<MenuItem>();

        public static bool IsEmulator()
        {
            string value;
            var result = Tizen.System.Information.TryGetValue("tizen.org/system/model_name", out value);
            return (result && value.Equals("Emulator"));
        }

        public static void ActivateBlur()
        {
            if (!IsEmulator())
            {
                MainGaussianBlurView?.Activate();
            }
        }

        public static void DeactivateBlur()
        {
            if (!IsEmulator())
            {
                MainGaussianBlurView?.Deactivate();
            }
        }

        public static float GetPortraitWidth()
        {
            var width = 0.0f;
            if (Window.Instance.Size.Width < Window.Instance.Size.Height)
            {
                width = Window.Instance.Size.Width;

            }
            else
            {
                width = Window.Instance.Size.Height;
            }
            return width;
        }
    }
}
