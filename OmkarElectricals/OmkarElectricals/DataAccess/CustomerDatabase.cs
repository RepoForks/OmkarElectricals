using OmkarElectricals.DataAccess.Interfaces;
using OmkarElectricals.Models;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OmkarElectricals.DataAccess
{
    public class CustomerDatabase : IDisposable
    {
        private SQLiteAsyncConnection _asyncConnection;

        public CustomerDatabase()
        {
            if (_asyncConnection == null) _asyncConnection = DependencyService.Get<ISQLite>().GetAsyncConnection();
        }

        /// <summary>
        /// Fetch All customer
        /// </summary>
        /// <returns>Fetch status</returns>
        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            try
            {
                return await _asyncConnection.Table<Customer>().ToListAsync();
            }
            catch (Exception ex)
            {
                HockeyApp.MetricsManager.TrackEvent("Something went wrong while fetching customer to database. GetAllCustomerAsync()");
                return null;
            }
        }

        /// <summary>
        /// Insert new customer
        /// </summary>
        /// <returns>Insert status</returns>
        public async Task<bool> InsertCustomerAsync(Customer customer)
        {
            try
            {
                await _asyncConnection.InsertAsync(customer);
                return true;
            }
            catch (Exception ex)
            {
                HockeyApp.MetricsManager.TrackEvent("Something went wrong while inserting customer to database. InsertCustomerAsync()");
                return false;
            }
        }

        /// <summary>
        /// Update existing customer
        /// </summary>
        /// <returns>Update status</returns>
        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                await _asyncConnection.UpdateAsync(customer);
                return true;
            }
            catch (Exception ex)
            {
                HockeyApp.MetricsManager.TrackEvent("Something went wrong while updating customer to database. UpdateCustomerAsync()");
                return false;
            }
        }

        /// <summary>
        /// Delete existing customer
        /// </summary>
        /// <returns>Deletion status</returns>
        public async Task<bool> DeleteCustomerAsync(Customer customer)
        {
            try
            {
                await _asyncConnection.DeleteAsync(customer);
                return true;
            }
            catch (Exception ex)
            {
                HockeyApp.MetricsManager.TrackEvent("Something went wrong while deleting customer to database. DeleteCustomerAsync()");
                return false;
            }
        }

        public void Dispose() { }
    }
}
