using System.Configuration;
using System.Diagnostics;
using Microsoft.Web.WebView2.Core;

namespace WebView2Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeWebView2();
        }

        private async void InitializeWebView2()
        {
            bool allowDomainSSO = true;
            string? allowDomainSSOSetting = ConfigurationManager.AppSettings["AllowDomainSSO"];
            if (!string.IsNullOrEmpty(allowDomainSSOSetting) && !bool.TryParse(allowDomainSSOSetting, out allowDomainSSO))
            {
                // Handle the invalid value case, e.g., log an error or set a default value
                allowDomainSSO = true; // or false, depending on your desired default behavior
            }

            var env = await CoreWebView2Environment.CreateAsync(null, null, new CoreWebView2EnvironmentOptions
            {
                AllowSingleSignOnUsingOSPrimaryAccount = allowDomainSSO
            });

            await webView21.EnsureCoreWebView2Async(env);

            string? startURL = ConfigurationManager.AppSettings["StartURL"];
            if (string.IsNullOrEmpty(startURL))
            {
                startURL = "http://localhost:5000";
            }

            if (allowDomainSSO)
            {
                ssoIndicatorLabel.Text = "SSO Enabled";
            }
            else
            {
                ssoIndicatorLabel.Text = "SSO Disabled";
            }

            addressBar.Text = startURL; // Add this line to set the address bar value
            webView21.CoreWebView2.Navigate(startURL);
        }      
    }
}

