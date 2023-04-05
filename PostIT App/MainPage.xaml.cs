using PostIT_Lib;
using PostIT_Lib.Models;
using System.Security.Cryptography.X509Certificates;


namespace PostIT_App
{
    public partial class MainPage : ContentPage
    {
        public PostItNote PostItNote { get; set; } = new PostItNote()
        {
            Category = "cat",
            Created = DateTime.Now,
            Id = 0,
            Text = "PostIt Note text test",
            Title = "PostIt note title test",
            UserId = 0
        };

        int count = 0;

        public string MyStringTest { get; set; } = "Hello there";

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
           
        }
    }
}