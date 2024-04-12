using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using QuickFind.Helpers;
using System;

namespace QuickFind
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.SizeChanged += MainWindow_SizeChanged;

            SearchBarBorderUI.PointerPressed += SearchBarBorderUI_PointerPressed;
            WindowBorderUI.PointerPressed += WindowBorderUI_PointerPressed;

            IsSuggestionFlyoutOpen = false;
        }

        #region Vars
        private double PreviousWindowWidth = 600;
        private bool IsSizeChangedListened = true;
        #endregion

        #region Props
        /// <summary>
        /// Gets or sets is search suggestion flyout opened.
        /// </summary>
        public bool IsSuggestionFlyoutOpen
        {
            get { return SuggestionFlyoutUI.IsVisible; }
            set 
            {
                int width;

                if (value) width = 690;
                else width = 600;

                SuggestionFlyoutUI.IsVisible = value;
                SetSuggestionFlyout(value, 560, width);
            }
        }
        #endregion

        /// <summary>
        /// Sets suggestion flyout state.
        /// </summary>
        /// <param name="isOpen"></param>
        /// <param name="height"></param>
        private void SetSuggestionFlyout(bool isOpen, int height, int width)
        {
            if(isOpen)
            {
                IsSizeChangedListened = false;
                this.MaxHeight = Double.PositiveInfinity;
                this.Height = height;
                this.Width = width;

                SearchBarBorderUI.Margin = new Thickness(10);
                AnimationInterop.ShowBorderAnimate(SuggestionFlyoutUI);

                var pos = this.Position;
                this.Position = new PixelPoint(pos.X - 32, pos.Y - 100);
            }
            else
            {
                IsSizeChangedListened = true;
                this.MaxHeight = 56;
                this.Width = PreviousWindowWidth;

                SearchBarBorderUI.Margin = new Thickness(0);
                AnimationInterop.HideBorderAnimate(SuggestionFlyoutUI);

                var pos = this.Position;
                this.Position = new PixelPoint(pos.X + 32, pos.Y + 100);
            }
        }

        private void MainWindow_Loaded(object? sender, RoutedEventArgs e)
        {
            var pos = this.Position;
            this.Position = new PixelPoint(pos.X, pos.Y - 166);
        }

        private void ActiveArea_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            if(IsSuggestionFlyoutOpen == false)
            IsSuggestionFlyoutOpen = true;
            else
            IsSuggestionFlyoutOpen = false;
        }

        private void MainWindow_SizeChanged(object? sender, SizeChangedEventArgs e)
        {
            if(IsSizeChangedListened) PreviousWindowWidth = e.NewSize.Width;
        }
        private void SearchBarBorderUI_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) => this.BeginMoveDrag(e);
        private void WindowBorderUI_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            PreviousWindowWidth = this.Width;
            this.BeginResizeDrag(WindowEdge.NorthEast, e);
        }
    }
}