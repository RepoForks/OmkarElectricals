using OmkarElectricals.Behavior;
using OmkarElectricals.DataAccess;
using OmkarElectricals.Models;
using Xamarin.Forms;

namespace OmkarElectricals.Views
{
    public class AddUpdateCustomerPage : ContentPage
    {
        public AddUpdateCustomerPage(string customerName = "", string customerAddress = "", string customerMobileNumber = "")
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
                Placeholder = "Enter Enter customer name",
                Text = customerName,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry))
            };

            Entry customerAddressEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 400,
                Placeholder = "Enter customer address",
                Text = customerAddress,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry))
            };

            Entry customerMobileNumberEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 400,
                Keyboard = Keyboard.Telephone,
                Placeholder = "Enter customer mobile number",
                Text = customerMobileNumber,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry))
            };
            customerMobileNumberEntry.Behaviors.Add(new NumberValidationBehavior());

            Button addCustomerButton = new Button
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 400,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button))
            };
            if (string.IsNullOrWhiteSpace(customerName))
            {
                addCustomerButton.Text = "Add Customer";
            }
            else
            {
                addCustomerButton.Text = "Update Customer";
            }
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
                        bool status = await customerDatabase.InsertOrUpdateCustomerAsync(new Customer { CustomerName = customerNameEntry.Text.Trim(), CustomerAddress = customerAddressEntry.Text.Trim(), CustomerMobileNumber = long.Parse(customerMobileNumberEntry.Text.Trim()) });
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
