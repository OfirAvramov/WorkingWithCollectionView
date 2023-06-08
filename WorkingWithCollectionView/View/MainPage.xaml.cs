using BindingToObject.Models;
using System.Collections.ObjectModel;
using WorkingWithCollectionView.ViewModels;

namespace WorkingWithCollectionView.View;

public partial class MainPage : ContentPage
{

    public MainPage(MainPageViewModel vm)
    {
        //נקשר את הדף שלנו לאובייקט המכיל את הקוד שלו
        this.BindingContext = vm;

        InitializeComponent();
    }
}

