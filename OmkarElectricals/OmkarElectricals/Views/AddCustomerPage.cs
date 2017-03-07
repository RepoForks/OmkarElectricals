using OmkarElectricals.Behavior;
using OmkarElectricals.DataAccess;
using OmkarElectricals.Models;
using Xamarin.Forms;

namespace OmkarElectricals.Views
{
    public class AddCustomerPage : ContentPage
    {
        public AddCustomerPage()
        {
            Title = "";
            Label addNewCustomerLabel = new Label
            {
                Text = "Add New Customer",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

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
            customerMobileNumberEntry.Behaviors.Add(new NumberValidationBehavior());

            Button addCustomerButton = new Button
            {
                Text = "Add Customer",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 400
            };
            addCustomerButton.Clicked += async (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(customerNameEntry.Text))
                {
                    await DisplayAlert("Omkar Electricals", "Please enter customer name", "OK");
                }
                else if (string.IsNullOrWhiteSpace(customerAddressEntry.Text))
                {
                    await DisplayAlert("Omkar Electricals", "Please enter customer address", "OK");
                }
                else if (string.IsNullOrWhiteSpace(customerMobileNumberEntry.Text))
                {
                    await DisplayAlert("Omkar Electricals", "Please enter customer mobile number", "OK");
                }
                else if (customerMobileNumberEntry.Text.Length != 10)
                {
                    await DisplayAlert("Omkar Electricals", "Please enter valid 10 digit mobile number", "OK");
                }
                else
                {
                    //Insert customer to db
                    using (CustomerDatabase customerDatabase = new CustomerDatabase())
                    {
                        bool status = await customerDatabase.InsertCustomerAsync(new Customer { CustomerName = customerNameEntry.Text.Trim(), CustomerAddress = customerAddressEntry.Text.Trim(), CustomerMobileNumber = long.Parse(customerMobileNumberEntry.Text.Trim()) });
                        if (status)
                        {
                            await DisplayAlert("Omkar Electricals", "Customer record inserted successfully", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            HockeyApp.MetricsManager.TrackEvent("Something went wrong while inserting customer to database");
                            await DisplayAlert("Omkar Electricals", "Something went wrong while inserting customer to database", "OK");
                        }
                    }
                }
            };

            Content = new StackLayout
            {
                Children = { addNewCustomerLabel, customerNameEntry, customerAddressEntry, customerMobileNumberEntry, addCustomerButton},
                Spacing = 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
        }
    }
}
