using Xamarin.Forms;

namespace OmkarElectricals.Views
{
    public class AddSelectCustomerPage : ContentPage
    {
        public AddSelectCustomerPage()
        {
            Title = "Omkar Electricals";

            Label selectCustomerLabel = new Label
            {
                Text = "Select Customer",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Large,typeof(Label))
            };

            Picker selectCustomerPicker = new Picker();

            Label orLabel = new Label
            {
                Text = "OR",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            Button addNewCustomerButton = new Button
            {
                Text = "Add New Customer",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button))
            };

            Content = new StackLayout
            {
                Children = { selectCustomerLabel, selectCustomerPicker, orLabel, addNewCustomerButton },
                Spacing = 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
        }
    }
}
