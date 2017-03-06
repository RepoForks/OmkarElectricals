using Xamarin.Forms;

namespace OmkarElectricals.Views
{
    public class LoginPage : ContentPage
    {
        public LoginPage()
        {
            Label title = new Label
            {
                Text = "Welcome to Omkar Electricals",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            Entry usernameEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 400,
                Placeholder = "Enter Username"
            };

            Entry passwordEntry = new Entry
            {
                IsPassword = true,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 400,
                Placeholder = "Enter Password"
            };

            Button loginButton = new Button
            {
                Text = "Login",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 400
            };

            Content = new StackLayout
            {
                Children = { title, usernameEntry, passwordEntry, loginButton },
                Spacing = 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
        }
    }
}
