using GameOfThrones.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using Newtonsoft.Json;
using Gecko;
using System.Windows.Forms.Integration;

namespace GameOfThrones.UI
{

    public partial class MainWindow : Window
    {
        private string _url;
        private List<Person> _people;

        public MainWindow()
        {
            _url = "https://api.got.show/api/show/characters";

            InitializeComponent();

            Xpcom.Initialize("Firefox");

            WindowsFormsHost host = new WindowsFormsHost();
            GeckoWebBrowser browser = new GeckoWebBrowser();

            host.Child = browser;
            gridWeb.Children.Add(host);
            browser.Navigate("http://viewers-guide.hbo.com/game-of-thrones/season-6/episode-10/map/location/77/bay-of-dragons");

            GetPeople();

            foreach (var person in _people)
            {
                peopleListBox.Items.Add(person.Name);
            }
        }

        public void GetPeople()
        {
            string json = "";
            WebClient client = new WebClient();
            using (Stream stream = client.OpenRead(_url))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        json += line;
                    }
                }
            }

            _people = JsonConvert.DeserializeObject<List<Person>>(json);
        }



        private void PeopleListBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int counter = 0;
            foreach (var item in _people)
            {
                if (counter == peopleListBox.SelectedIndex)
                {
                    InfoWindow infoWindow = new InfoWindow(item);
                    infoWindow.Show();
                    return;
                }
                counter++;
            }
        }

        private void FindTextBoxTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (findTextBox is null)
            {
                findTextBox.Text = "";
            }
            int index = 0;
            foreach (var person in _people)
            {
                if (person.Name.Contains(findTextBox.Text))
                {
                    peopleListBox.Items[index] = person;
                }
                else
                {
                    peopleListBox.Items[index] = new EmptyObject();
                }
                index++;
            }
        }
    }
}
