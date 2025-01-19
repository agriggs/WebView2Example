namespace WebView2Example
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.TextBox addressBar;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Panel addressPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            addressBar = new TextBox();
            goButton = new Button();
            addressPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            addressPanel.SuspendLayout();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(0, 30);
            webView21.Name = "webView21";
            webView21.Size = new Size(800, 420);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // addressBar
            // 
            addressBar.Dock = DockStyle.Fill;
            addressBar.Location = new Point(0, 0);
            addressBar.Name = "addressBar";
            addressBar.Size = new Size(760, 23);
            addressBar.TabIndex = 1;
            addressBar.KeyDown += AddressBar_KeyDown;
            // 
            // goButton
            // 
            goButton.Dock = DockStyle.Right;
            goButton.Location = new Point(760, 0);
            goButton.Name = "goButton";
            goButton.Size = new Size(40, 30);
            goButton.TabIndex = 2;
            goButton.Text = "Go";
            goButton.UseVisualStyleBackColor = true;
            goButton.Click += GoButton_Click;
            // 
            // addressPanel
            // 
            addressPanel.Controls.Add(addressBar);
            addressPanel.Controls.Add(goButton);
            addressPanel.Dock = DockStyle.Top;
            addressPanel.Location = new Point(0, 0);
            addressPanel.Name = "addressPanel";
            addressPanel.Size = new Size(800, 30);
            addressPanel.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(webView21);
            Controls.Add(addressPanel);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            addressPanel.ResumeLayout(false);
            addressPanel.PerformLayout();
            ResumeLayout(false);
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            // check that the address bar is text starts with http or https
            if (!addressBar.Text.StartsWith("http://") && !addressBar.Text.StartsWith("https://"))
            {
                MessageBox.Show($"Only http and https allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    webView21.Source = new Uri(addressBar.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddressBar_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                goButton.PerformClick();
                e.SuppressKeyPress = true; // Prevents the beep sound on Enter key press
            }
        }
    }
}
