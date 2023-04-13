using MauiLib.Models;
using PostIT_App.Helpers;
using PostIT_App.ViewModel;
using System.Net.Http.Json;
using ServiceProvider = PostIT_App.Helpers.ServiceProvider;

namespace PostIT_App.Pages;

public partial class MyNotesPage : ContentPage
{
    public MyNotesPage(MyNotesModel myNotesModel)
    {
        InitializeComponent();
        BindingContext = myNotesModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (BindingContext.GetType() == typeof(MyNotesModel))
        {
            var model = (MyNotesModel)BindingContext;
            await model.OnNavigatedTo();
        }
    }
}