using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using WpfSchools.Client.Models;
using WpfSchools.Client.Support;

namespace WpfSchools.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SchoolsPagedContentSupport PagedSupport { get; set; }
        public IConfiguration _configuration;

        public MainWindow()
        {
            InitializeComponent();

            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("WpfSchools.json", optional: false, reloadOnChange: true);

            var Configuration = builder.Build();

            _configuration = Configuration;
            PagedSupport = new SchoolsPagedContentSupport(_configuration);
            ShowHome();
        }



        public void OnClickHomePress(object sender, RoutedEventArgs e)
        {
            ShowHome();
        }

        public void ShowHome()
        {
            ShowHtml(false, "");
            textPageTitle.Text = "    Hello and welcome to School Data WPF Example";
            textPageText.Text = "\r\n   This Windows Presentation Manager example has similar look";
            textPageText.Text += "\r\n   and appearence of the Blazor Application which calls the";
            textPageText.Text += "\r\n   same Blazor Webassembly REST services included in the";
            textPageText.Text += "\r\n   BlazorSchool.Server";
            textPageText.Text += "\r\n\r\n   The Main Purpose is not actual WPF but see is the";
            textPageText.Text += "\r\n   same Webassembly Services can executed from WPF application. ";
            textPageText.Text += "\r\n   WPF code was written just to show it";

            ShowPagedButtons(false);
            textPageHeader.Visibility = Visibility.Collapsed;
            textPageText.Visibility = Visibility.Visible;
            EnableListItems(0);
        }

        public void OnClickAbout(object sender, RoutedEventArgs e)
        {
            textPageTitle.Text = "   About Microsoft Presentation Manager";
            textPageText.Text = "\r\n";
            textPageText.Visibility = Visibility.Visible;

            ShowPagedButtons(false);
            textPageHeader.Visibility = Visibility.Collapsed;

            EnableListItems(0);

            string str = _configuration["AboutURL"]; ;
            ShowHtml(true, str);
        }

        public void OnClickSchoolsPress(object sender, RoutedEventArgs e)
        {
            ShowLoading("   School API Data");
            ProcessUITasks();
            btnSchoolsLoad.RaiseEvent(e);
        }

        public void OnClickSchoolsLoad(object sender, RoutedEventArgs e)
        {
            textPageTitle.Text = "   School API Data";
            textPageText.Text = "   Only Top 14 items shown";

            SchoolsContentSupport Support = new SchoolsContentSupport(_configuration);

            try
            {
                IPageDataModel Data = Support.CreatePageDataModel();

                textPageTitle.Text = "   " + Data.Title;
                textPageText.Visibility = Visibility.Visible;
                textPageText.Text = Support.StatusMessage;
                ShowPagedButtons(false);

                if (Data.HasContent == true)
                {
                    ShowTableData(Data);
                    EnableListItems(Data.Content.Length);
                }
            }
            catch (Exception ex)
            {
                textPageTitle.Text = "   School API Data Exception";
                textPageText.Text = "   Exception loading School API Data with " + ex.Message;
                textPageText.Visibility = Visibility.Visible;


                textPageHeader.Visibility = Visibility.Collapsed;
                EnableListItems(0);
            }

        }

        public void OnClickSchoolsPagesPress(object sender, RoutedEventArgs e)
        {
            ShowLoading("   School API Data Pages");
            ProcessUITasks();
            btnSchoolsPagesLoad.RaiseEvent(e);
        }

        public void OnClickSchoolsPagesLoad(object sender, RoutedEventArgs e)
        {
            textPageTitle.Text = "   School API Data Pages";
            textPageText.Text = "";
            ShowPagedContent(0);
        }

        public void OnClickPerformancePress(object sender, RoutedEventArgs e)
        {
            ShowLoading("    School API Performance Data");
            ProcessUITasks();
            btnPerformanceLoad.RaiseEvent(e);
        }

        public void OnClickPerformanceLoad(object sender, RoutedEventArgs e)
        {

            PerformancePageContentSupport Support = new PerformancePageContentSupport(_configuration);

            try
            {
                IPageDataModel Data = Support.CreatePageDataModel();

                textPageTitle.Text = "    " + Data.Title;
                textPageText.Visibility = Visibility.Collapsed;
                ShowPagedButtons(false);
                NextPrevGrid.Visibility = Visibility.Collapsed;

                if (Data.HasContent == true)
                {
                    ShowTableData(Data);
                    EnableListItems(Data.Content.Length);
                }
            }
            catch (Exception ex)
            {
                textPageTitle.Text = "   School API Performance Data Exception";
                textPageText.Text = "   Exception loading School API Performance Data with " + ex.Message;
                textPageText.Visibility = Visibility.Visible;


                textPageHeader.Visibility = Visibility.Collapsed;
                EnableListItems(0);
            }

        }

        public void ShowPagedContent(int nextIndex)
        {
            textPageTitle.Text = "   School API Data Pages";
            textPageText.Text = "";

            try
            {
                if (PagedSupport == null)
                    PagedSupport = new SchoolsPagedContentSupport(_configuration);
                IPageDataModel Data = PagedSupport.CreatePageDataModel(nextIndex);

                ShowPagedButtons(true);
                textPageTitle.Text = "   " + Data.Title;
                textPageText.Visibility = Visibility.Visible;
                textPageText.Text = PagedSupport.StatusMessage;

                if (Data.HasContent == true)
                {
                    ShowTableData(Data);
                    EnableListItems(Data.Content.Length);
                }
            }
            catch (Exception ex)
            {
                textPageTitle.Text = "   School API Data Exception";
                textPageText.Text = "   Exception loading School API Data with " + ex.Message;
                textPageText.Visibility = Visibility.Visible;


                textPageHeader.Visibility = Visibility.Collapsed;
                EnableListItems(0);
            }
        }

        public void OnClickNextPress(object sender, RoutedEventArgs e)
        {
            int nextIndex = 0;
            if (PagedSupport != null)
                nextIndex = PagedSupport.NextIndex();
            ShowPagedContent(nextIndex);
        }

        public void OnClickPrevPress(object sender, RoutedEventArgs e)
        {
            int nextIndex = 0;
            if (PagedSupport != null)
                nextIndex = PagedSupport.PrevIndex();
            ShowPagedContent(nextIndex);
        }

        private void ShowLoading(string title)
        {
            ShowHtml(false, "");
            textPageTitle.Text = title;
            textPageText.Text = "   Loading...";
            textPageText.Visibility = Visibility.Visible;
            textPageHeader.Visibility = Visibility.Collapsed;
            ShowPagedButtons(false);
            EnableListItems(0);

        }

        private void ShowPagedButtons(bool show)
        {
            if (show == true)
                NextPrevGrid.Visibility = Visibility.Visible;
            else
                NextPrevGrid.Visibility = Visibility.Hidden;
        }

        private void ShowTableData(IPageDataModel Data)
        {
            if (Data.HasHeader == true)
            {
                textPageHeader.Text = Data.Header;
                textPageHeader.FontSize = Data.ContentFontSize;
                textPageHeader.Visibility = Visibility.Visible;
            }
            else
                textPageHeader.Visibility = Visibility.Collapsed;

            int count = 0;
            if (Data.HasContent == true)
            {
                listBox.ItemsSource = null;

                ArrayList arrayList = new ArrayList();

                count = Data.Content.Length;
                for (int index = 0; index < count; index++)
                {
                    arrayList.Add(Data.Content[index]);
                }
                listBox.ItemsSource = arrayList;
            }
        }

        private void EnableListItems(int count)
        {
            if (count > 0 )
                listBox.Visibility = Visibility.Visible;
            else
            {
                listBox.ItemsSource = null;
                listBox.Visibility = Visibility.Collapsed;
            }
 
        }

        private void ShowHtml(bool show, string str)
        {
            if (show == true)
            {
                HtmlCanvas.Visibility = Visibility.Visible;
                HtmlFrame.Navigate(new Uri(str));
            }
            else
                HtmlCanvas.Visibility = Visibility.Collapsed;
        }

        private void ProcessUITasks()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(delegate (object parameter)
            {
                frame.Continue = false;
                return null;
            }), null);
            Dispatcher.PushFrame(frame);
        }
    }
}
