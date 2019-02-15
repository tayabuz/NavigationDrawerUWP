using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NavigationDrawerUWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void SetContentButton_OnClick(object sender, RoutedEventArgs e)
        {
            StackPanel ContentContainer = new StackPanel();
            Rectangle rectBlue = new Rectangle() {Height = 200, Width = 250, Fill = new SolidColorBrush(Colors.Blue)};
            TextBlock textBlock = new TextBlock() { Text = "HJHJGJGKGKHKGbmjhhnk20i39838565656565656", Height = 50, Foreground = new SolidColorBrush(Colors.Black)};
            ContentContainer.Children.Add(rectBlue);
            ContentContainer.Children.Add(textBlock);
            navi.SetContent(ContentContainer);
            StackPanel ContentContainer1 = new StackPanel();
            Rectangle rectBlue1 = new Rectangle() {Height = 200, Width = 250, Fill = new SolidColorBrush(Colors.Blue)};
            TextBlock textBlock1 = new TextBlock() { Text = "HJHJGJGKGKHKGbmjhhnk20i39838565656565656", Height = 50, Foreground = new SolidColorBrush(Colors.Black)};
            ContentContainer.Children.Add(rectBlue1);
            ContentContainer.Children.Add(textBlock1);
            navi.SetContent(ContentContainer1);
        }

        private void SetLeftLock_OnClick(object sender, RoutedEventArgs e)
        {
            navi.SetLeftLock(true);
        }

        private void SetMenuButton_OnClick(object sender, RoutedEventArgs e)
        {
            StackPanel LeftPanel = new StackPanel();
            Rectangle rectYellow = new Rectangle(){ Height = 100, Width = 100, Fill = new SolidColorBrush(Colors.Yellow) };
            TextBlock textLeft = new TextBlock(){Text = "HELLO HLIJJ!!HJJKHh"};
            LeftPanel.Children.Add(textLeft);
            LeftPanel.Children.Add(rectYellow);
            navi.SetLeftMenu(LeftPanel);

            StackPanel RightPanel = new StackPanel();
            Rectangle greenRect = new Rectangle(){Height = 150, Width = 100, Fill = new SolidColorBrush(Colors.Green)};
            TextBlock textRight = new TextBlock(){Text = "11325646544664+646464!!#W$"};
            RightPanel.Children.Add(greenRect);
            RightPanel.Children.Add(textRight);
            navi.SetRightMenu(RightPanel);
        }
    }
}
