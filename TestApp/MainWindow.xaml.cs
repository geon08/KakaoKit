using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KakaoKit.Story;
using KakaoKit.Util;
using KakaoKit;

namespace TestApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public StoryClient Story;
        

        public MainWindow()
        {
            InitializeComponent();
            Story = new StoryClient();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Story.Login(Field_ID.Text, Field_PW.Password) == ELoginResults.Success)
            {
                System.Diagnostics.Debug.WriteLine(Story.StorySession.RequestGET("https://story.kakao.com/"));
                StoryProfile stp = Story.GetProfile("me");
                StoryFeed stf = Story.GetLatestFeeds();
                StoryNotification noti = Story.GetNotifications();
                System.Diagnostics.Debug.WriteLine(stf.Feeds[0].ID);
                foreach (var i in noti.Notifies)
                {
                    Field_Notify.Items.Add(new NotifyClass(i.actor.BackgroundImageURL,i.message,i.content));
                }
            }
        }
    }

    class NotifyClass
    {
        public NotifyClass(string PicURL, string title, string content)
        {
            ProfilePic = new Uri(PicURL);
            Title = title;
            Content = content;
        }
        public Uri ProfilePic { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
