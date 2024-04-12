using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace QuickFind.Controls
{
    public partial class FontIcon : TextBlock
    {
        public FontIcon()
        {
            this.FontFamily = (FontFamily)Application.Current.Resources["FluentIcons"];
        }

        public string Glyph
        {
            get
            {
                if(this.Text != null) return this.Text;
                else return string.Empty;
            }
            set
            {
                this.Text = value;
            }
        }

        private bool _isFilled = false;
        public bool IsFilled
        {
            get { return _isFilled; }
            set
            {
                if(!value)
                   this.FontFamily = (FontFamily)Application.Current.Resources["FluentIcons"];
                else
                   this.FontFamily = (FontFamily)Application.Current.Resources["FluentIconsFilled"];
            }
        }
    }
}
