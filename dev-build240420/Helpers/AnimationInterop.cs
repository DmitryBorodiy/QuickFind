using Avalonia.Controls;

namespace QuickFind.Helpers
{
    public static class AnimationInterop
    {
        public static void ShowBorderAnimate(Control control)
        {
            if(control == null) return;

            if(control.Classes.Contains("hide"))
               control.Classes.Remove("hide");

            if(control.Classes.Contains("show"))
               control.Classes.Remove("show");

            control.Classes.Add("show");
        }

        public static void HideBorderAnimate(Control control)
        {
            if(control == null) return;

            if(control.Classes.Contains("hide"))
               control.Classes.Remove("hide");

            if(control.Classes.Contains("show"))
               control.Classes.Remove("show");

            control.Classes.Add("hide");
        }
    }
}
