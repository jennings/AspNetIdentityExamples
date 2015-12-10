using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace TestUtility
{
    public partial class MainForm : Form
    {
        RestClient _client;

        public MainForm()
        {
            InitializeComponent();
            _client = new RestClient();
        }

        Uri Address { get { return new Uri(addressTextBox.Text.Trim()); } }
        string Token { get { return tokenTextBox.Text.Trim(); } }

        async Task ExecuteAsync(string resource)
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = resource,
            };

            var token = Token;
            if (!string.IsNullOrWhiteSpace(token) && sendTokenCheckBox.Checked)
            {
                request.AddHeader("Authorization", "Bearer " + token);
            }

            resultTextBox.Text = "Sending...";
            await Task.Delay(100); // So you can see that something's happening
            try
            {
                _client.BaseUrl = Address;
                Render(request, await _client.ExecuteTaskAsync(request));
            }
            catch (Exception ex)
            {
                resultTextBox.Text = "EXCEPTION: " + ex.Message;
            }
        }

        void Render(IRestRequest request, IRestResponse response)
        {
            var sb = new StringBuilder();

            // Request
            sb.AppendFormat("{0} {1}\r\n", request.Method, request.Resource);
            foreach (var header in request.Parameters.Where(p => p.Type == ParameterType.HttpHeader))
            {
                sb.AppendFormat("{0}: {1}\r\n", header.Name, header.Value);
            }
            sb.AppendLine();
            sb.AppendLine();

            // Response
            sb.AppendFormat("{0} {1}\r\n", (int)response.StatusCode, response.StatusDescription);
            foreach (var header in response.Headers)
            {
                sb.AppendFormat("{0}: {1}\r\n", header.Name, header.Value);
            }
            sb.AppendLine();
            sb.AppendLine(response.Content);

            resultTextBox.Text = sb.ToString();
        }

        async void unauthenticatedButton_Click(object sender, EventArgs e)
        {
            await ExecuteAsync("test/unauthenticated");
        }

        async void authenticatedButton_Click(object sender, EventArgs e)
        {
            await ExecuteAsync("test/authenticated");
        }
    }
}
