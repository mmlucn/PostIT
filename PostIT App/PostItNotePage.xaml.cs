namespace PostIT_App;
using PostIT_Lib.Models;
using System.Net.Http.Json;

public partial class PostItNotePage : ContentPage
{
    public PostItNote PostItNote { get; set; } = new PostItNote()
    {
        Category = "",
        Created = DateTime.Now,
        Id = 0,
        Text = "",
        Title = "",
        Image = null
    };
    HttpClient _httpClient;

	public PostItNotePage(HttpClient httpClient)
	{
		InitializeComponent();
		BindingContext= this;
        _httpClient= httpClient;
	}

    private async void saveNote_Clicked(object sender, EventArgs e)
    {
        
        var res = await _httpClient.PostAsJsonAsync<PostItNote>($"https://localhost:7081/api/PostIT2?postItNote=", PostItNote);

        if (res.IsSuccessStatusCode)
        {
            await Navigation.PopAsync();

        }
    }
}