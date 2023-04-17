namespace PostIT_App.Pages;

using Microsoft.Maui.Controls;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using Helpers;
using System.IdentityModel.Tokens.Jwt;
using MauiLib.DTOs;
using PostIT_App.ViewModel;

public partial class AddNotePage : ContentPage
{
    public AddNotePage(MyNotesModel postItNoteModel)
    {
        InitializeComponent();
        BindingContext = postItNoteModel;
    }

    
}