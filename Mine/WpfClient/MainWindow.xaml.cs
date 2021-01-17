using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Windows;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DiscoveryDocumentResponse _disco;
        private string _accessToken;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void RequestAccessToken_ButtonClick(object sender, RoutedEventArgs e)
        {
            AccessTokenTextBlock.Clear();
            var userName = UserNameInput.Text;
            var password = PasswordInput.Password;

            // request access token
            var client = new HttpClient();

            _disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
            if (_disco.IsError)
            {
                Console.WriteLine(_disco.Error);
                return;
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = _disco.TokenEndpoint,
                ClientId = "wpf client",
                ClientSecret = "wpf secrect",
                Scope = "scope1 openid profile address phone email",

                UserName = userName,
                Password = password
            });

            if (tokenResponse.IsError)
            {
                MessageBox.Show(tokenResponse.Error);
                return;
            }

            _accessToken = tokenResponse.AccessToken;
            AccessTokenTextBlock.Text = tokenResponse.Json.ToString();
        }

        private async void RequestApiResource_ButtonClick(object sender, RoutedEventArgs e)
        {
            // call API Resource
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(_accessToken);

            var response = await apiClient.GetAsync("http://localhost:5001/identity");
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(response.StatusCode.ToString());
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                ApiResourceTextBlock.Text = content;
            }
        }

        private async void RequestIdenityResource_ButtonClick(object sender, RoutedEventArgs e)
        {
            // call Identity Resource from Identity Server
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(_accessToken);

            var response = await apiClient.GetAsync(_disco.UserInfoEndpoint);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(response.StatusCode.ToString());
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                IdenityResourceTextBlock.Text = content;
            }
        }
    }
}
