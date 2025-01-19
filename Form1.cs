using System;
using System.Windows.Forms;
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
            var env = await CoreWebView2Environment.CreateAsync(null, null, new CoreWebView2EnvironmentOptions
            {
                AllowSingleSignOnUsingOSPrimaryAccount = true
            });
            await webView21.EnsureCoreWebView2Async(env);
            webView21.CoreWebView2.Navigate("http://localhost:5000");
        }
    }
}

