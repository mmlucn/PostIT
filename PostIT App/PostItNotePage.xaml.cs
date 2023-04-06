namespace PostIT_App;
using PostIT_Lib.Models;

public partial class PostItNotePage : ContentPage
{
    public PostItNote PostItNote { get; set; } = new PostItNote()
    {
        Category = "",
        Created = DateTime.Now,
        Id = 0,
        Text = "",
        Title = "",
        UserId = 0
    };

	public PostItNotePage()
	{
		InitializeComponent();
		BindingContext= this;
	}
}