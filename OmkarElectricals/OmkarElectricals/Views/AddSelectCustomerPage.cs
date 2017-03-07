using OmkarElectricals.DataAccess;
using OmkarElectricals.Models;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace OmkarElectricals.Views
{
    public class AddSelectCustomerPage : ContentPage
    {
        private Picker _selectCustomerPicker;

        public AddSelectCustomerPage()
        {
            Title = "";
            Label selectCustomerLabel = new Label
            {
                Text = "Select Customer",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Large,typeof(Label))
            };

            _selectCustomerPicker = new Picker
            {
                WidthRequest = 400,
            };

            Button continueButton = new Button
            {
                Text = "Continue",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button))
            };

            Button updateCustomerButton = new Button
            {
                Text = "Update Customer",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button))
            };

            Button deleteCustomerButton = new Button
            {
                Text = "Delete Customer",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button))
            };

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
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button))
            };
            addNewCustomerButton.Clicked += (s, e) =>
            {
                Navigation.PushAsync(new AddCustomerPage());
            };

            Content = new StackLayout
            {
                Children = { selectCustomerLabel, _selectCustomerPicker, continueButton, updateCustomerButton, deleteCustomerButton, orLabel, addNewCustomerButton },
                Spacing = 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            using(CustomerDatabase customerDatabase = new CustomerDatabase())
            {
                List<string> customerList = (await customerDatabase.GetAllCustomerAsync()).Select(c=>c.CustomerName).ToList();
                foreach(string customer in customerList)
                {
                    _selectCustomerPicker.Items.Add(customer);
                }
            }
        }
    }
}
