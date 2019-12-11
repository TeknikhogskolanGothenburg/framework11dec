using Api1.DataProvider;
using Api1.Models;
using System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Api1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            APIHelper.InitilizeClient();
            getCategories();
        }

        private async void getCategories()
        {
            QuizDataProvider qdp = new QuizDataProvider();
            var categories = await qdp.GetCategories();
            foreach(var cat in categories)
            {
                Categories.Items.Add(cat);
            }
            Categories.SelectedIndex = 0;
        }

        private async void CategoryChanged(object sender, SelectionChangedEventArgs e)
        {
            Questions.Items.Clear();
            QuizDataProvider qdp = new QuizDataProvider();
            var category = Categories.SelectedItem as Category;
            var questions = await qdp.GetQuestions(category.Id);
            foreach(var question in questions)
            {
                Questions.Items.Add(question);
            }

        }
    }
}
