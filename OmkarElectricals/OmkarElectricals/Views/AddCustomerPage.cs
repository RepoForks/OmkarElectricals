using Xamarin.Forms;

namespace OmkarElectricals.Views
{
    public class AddCustomerPage : ContentPage
    {
        public AddCustomerPage()
        {
            Title = "";

            Entry customerNameEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 400,
                Placeholder = "Enter Enter customer name"
            };

            Entry customerAddressEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 400,
                Placeholder = "Enter customer address"
            };

            Entry customerMobileNumberEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 400,
                Keyboard = Keyboard.Telephone,
                Placeholder = "Enter customer mobile number"
            };

            Content = new StackLayout
            {
                Children = { customerNameEntry, customerAddressEntry, customerMobileNumberEntry},
                Spacing = 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
        }
    }
}
