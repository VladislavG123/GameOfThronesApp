using GameOfThrones.Models;
using Gecko;
using System;
using System.Windows;
using System.Windows.Forms.Integration;

namespace GameOfThrones
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        private Person _person;

        public InfoWindow(Person person)
        {
            _person = person;
            InitializeComponent();

            Xpcom.Initialize("Firefox");

            WindowsFormsHost host = new WindowsFormsHost();
            GeckoWebBrowser browser = new GeckoWebBrowser();

            host.Child = browser;
            gridWeb.Children.Add(host);
            browser.Navigate(person.Image);

            nameTextBlock.Text = _person.Name;

            genderTextBlock.Text = _person.Gender is null ? "-" : _person.Gender;

            aliveTextBlock.Text = _person.Alive ? "Alive" : "Dead";

            fatherTextBlock.Text = _person.Father is null ? "-" : _person.Father;

            motherTextBlock.Text = _person.Mother is null ? "-" : _person.Mother;

            houseTextBlock.Text = _person.House is null ? "-" : _person.House;

            firstSeenTextBlock.Text = _person.FirstSeen is null || _person.FirstSeen == "" ? "-" : _person.FirstSeen;

            actorTextBlock.Text = _person.Actor is null ? "-" : _person.Actor;

            if (_person.Culture.Count == 0)
            {
                cultureTextBlock.Text = "-";
            }
            else
            {
                cultureTextBlock.Text = "";
                foreach (var culture in _person.Culture)
                {
                    cultureTextBlock.Text += culture + " ";
                }
            }


            if (_person.Religion.Count == 0)
            {
                religionTextBlock.Text = "-";
            }
            else
            {
                religionTextBlock.Text = "";
                foreach (var religion in _person.Religion)
                {
                    religionTextBlock.Text += religion + " ";
                }
            }


            if (_person.Allegiances.Count == 0)
            {
                allegiancesTextBlock.Text = "-";
            }
            else
            {
                allegiancesTextBlock.Text = "";
                foreach (var allegiance in _person.Allegiances)
                {
                    allegiancesTextBlock.Text += allegiance + " ";
                }
            }

            if (_person.Seasons.Count == 0)
            {
                seasonsTextBlock.Text = "-";
            }
            else
            {
                seasonsTextBlock.Text = "";
                foreach (var season in _person.Seasons)
                {
                    seasonsTextBlock.Text += season + " ";
                }
            }
        }

    }
}
