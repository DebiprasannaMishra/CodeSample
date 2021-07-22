using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetCustomerList();
        }

        private void GetCustomerList()
        {
            HttpClient apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri("http://localhost:39482");
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = apiClient.GetAsync("api/customer").Result;
                if (response.IsSuccessStatusCode)
                    dgCustomer.ItemsSource = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                else
                    MessageBox.Show("Response Error : " + response.StatusCode);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri("http://localhost:39482");
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var customer = new Customer()
            {
                Name = txtName.Text,
                Location = txtLocation.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text
            };

            try
            {
                var response = apiClient.PostAsJsonAsync("api/customer", customer).Result;
                if (response.IsSuccessStatusCode)
                {
                    txtName.Text = "";
                    txtLocation.Text = "";
                    txtEmail.Text = "";
                    txtPhone.Text = "";

                    GetCustomerList();

                    MessageBox.Show("User Added");
                }
                else
                    MessageBox.Show("Response Error : " + response.StatusCode);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri("http://localhost:39482");
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var id = txtId.Text.Trim();
            var url = "api/customer/" + id;

            try
            {
                HttpResponseMessage response = apiClient.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("User Deleted");
                    GetCustomerList();
                }
                else
                    MessageBox.Show("Response Error : " + response.StatusCode);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri("http://localhost:39482");
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var id = txtId.Text.Trim();
            var url = "api/customer/" + id;

            try
            {
                HttpResponseMessage response = apiClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var customer = response.Content.ReadAsAsync<Customer>().Result;

                    txtName.Text = customer.Name;
                    txtLocation.Text = customer.Location;
                    txtEmail.Text = customer.Email;
                    txtPhone.Text = customer.Phone;

                    MessageBox.Show("Customer found");
                }
                else
                    MessageBox.Show("Response Code : " + response.StatusCode);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri("http://localhost:39482");
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            int.TryParse(txtId.Text, out int customerId);

            var customer = new Customer()
            {
                Id = customerId,
                Name = txtName.Text,
                Location = txtLocation.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text
            };

            try
            {
                var response = apiClient.PutAsJsonAsync("api/customer", customer).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("User Updated");

                    txtId.Text = "";
                    txtName.Text = "";
                    txtLocation.Text = "";
                    txtEmail.Text = "";
                    txtPhone.Text = "";

                    GetCustomerList();
                }
                else
                    MessageBox.Show("Response Code : " + response.StatusCode);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
