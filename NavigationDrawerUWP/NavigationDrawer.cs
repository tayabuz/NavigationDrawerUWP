using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace NavigationDrawerUWP
{
    public class NavigationDrawer: Grid
    {
        private SplitView _splitViewLeft;
        private SplitView _splitViewRight;
        public NavigationDrawer()
        {
            SetupLeftMenu();
            SetupRightMenu();
        }

        private void OpenButtonRightOnClick(object sender, RoutedEventArgs e)
        {
            if(!IsRightMenuOpen()) OpenRightMenu();
            else CloseRightMenu();
        }

        private void OpenButtonLeftOnClick(object sender, RoutedEventArgs e)
        {
           if(!IsLeftMenuOpen()) OpenLeftMenu();
           else CloseLeftMenu();
        }

        public void Destruct() {
            if (!IsDestructed) 
            {
                Children.Clear();
                _splitViewLeft = null;
                _splitViewLeft = null;
            }
            IsDestructed = true;
        }

        public bool IsDestructed { get; private set; }

        public void OpenLeftMenu()
        {
            _splitViewLeft.IsPaneOpen = true;
        }

        public void CloseLeftMenu()
        {
            _splitViewLeft.IsPaneOpen = false;
        }

        public bool IsLeftMenuOpen()
        {
            if (_splitViewLeft == null) return false;
            return _splitViewLeft.IsPaneOpen;
        }

        public void SetLeftLock(bool isLock)
        {
            if (isLock)
            {
                _splitViewLeft.DisplayMode = SplitViewDisplayMode.Inline;
                _splitViewLeft.IsEnabled = false;
            }
            else
            {
                _splitViewLeft.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                _splitViewLeft.IsEnabled = true;
            }
        }

        public void OpenRightMenu()
        {
            _splitViewRight.IsPaneOpen = true;
        }

        public void CloseRightMenu()
        {
            _splitViewRight.IsPaneOpen = false;
        }

        public bool IsRightMenuOpen() {
            if (_splitViewRight== null) return false;
            return _splitViewRight.IsPaneOpen;
        }

        public void SetRightLock(bool isLock)
        {
            if (isLock)
            {
                _splitViewRight.DisplayMode = SplitViewDisplayMode.Inline;
                _splitViewRight.IsEnabled = false;
            }
            else
            {
                _splitViewRight.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                _splitViewRight.IsEnabled = true;
            }
        }

        public void SetContent(UIElement element)
        {
            Children.Add(element);
            Children.Move(Convert.ToUInt32(Children.IndexOf(element)), GetIndexForContent());
        }

        private uint GetIndexForContent()
        {
            var leftMenuIndexChindrenInGrid = Children.IndexOf(_splitViewLeft);
            var rightMenuIndexChildrenInGrid = Children.IndexOf(_splitViewRight);
            uint indexForContent;
            if (rightMenuIndexChildrenInGrid == 0 || leftMenuIndexChindrenInGrid == 0) { return 0; }
            if (leftMenuIndexChindrenInGrid > rightMenuIndexChildrenInGrid) { indexForContent = Convert.ToUInt32(rightMenuIndexChildrenInGrid - 1); }
            else { indexForContent = Convert.ToUInt32(leftMenuIndexChindrenInGrid - 1); }
            return indexForContent;
        }

        public void SetLeftMenu(UIElement element)
        {
            _splitViewLeft.Pane = element;
        }

        public void SetRightMenu(UIElement element)
        {
            _splitViewRight.Pane = element;
        }

        private void SetupRightMenu() {
            _splitViewRight = new SplitView()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                IsTabStop = false,
                IsEnabled = true,
                PanePlacement = SplitViewPanePlacement.Right,
            };
           
            Children.Add(_splitViewRight);

            Button openButtonRight = new Button();
            openButtonRight.HorizontalAlignment = HorizontalAlignment.Right;
            openButtonRight.VerticalAlignment = VerticalAlignment.Stretch;
            openButtonRight.Background = new SolidColorBrush(Colors.Transparent);
            openButtonRight.Click += OpenButtonRightOnClick;
            _splitViewRight.Content = openButtonRight;
        }

        private void SetupLeftMenu() {
            _splitViewLeft = new SplitView()
            {
                HorizontalAlignment = HorizontalAlignment.Left, 
                IsTabStop = false,
                IsEnabled = true,
                PanePlacement = SplitViewPanePlacement.Left,
            };
            Children.Add(_splitViewLeft);

            Button openButtonLeft = new Button();
            openButtonLeft.HorizontalAlignment = HorizontalAlignment.Left;
            openButtonLeft.VerticalAlignment = VerticalAlignment.Stretch;
            openButtonLeft.Background = new SolidColorBrush(Colors.Transparent);
            openButtonLeft.Click += OpenButtonLeftOnClick;
            _splitViewLeft.Content = openButtonLeft;
        }

    }
}
