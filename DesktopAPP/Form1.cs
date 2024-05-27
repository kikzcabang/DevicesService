using Microsoft.AspNetCore.SignalR.Client;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

namespace DesktopAPP
{
    public partial class Form1 : Form
    {
        HubConnection? connection;
        string host = "http://localhost";
        string wwwroot = "C:\\inetpub\\wwwroot\\wwwroot\\signature\\scan";

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitSignalR();
            ConnectSignalR();
        }

        #region SignalR

        void InitSignalR()
        {
            var url = host + "/DevicesHub";


            connection = new HubConnectionBuilder()
               .WithUrl(url)
               .WithAutomaticReconnect()
               .Build();


            connection.Reconnecting += (error) =>
            {
                if (statusSignalR.InvokeRequired)
                {
                    statusSignalR.Invoke(new Action(() =>
                    {
                        statusSignalR.Text = "SignalR: Reconnecting";
                    }));
                }


                return Task.CompletedTask;
            };

            connection.Reconnected += (id) =>
            {
                if (statusSignalR.InvokeRequired)
                {
                    statusSignalR.Invoke(new Action(() =>
                    {
                        statusSignalR.Text = "SignalR: Restablished";
                    }));
                }


                return Task.CompletedTask;
            };

            connection.Closed += (error) =>
            {
                if (statusSignalR.InvokeRequired)
                {
                    statusSignalR.Invoke(new Action(() =>
                    {
                        statusSignalR.Text = "SignalR: Closed - " + error.Message;
                    }));
                }

                return Task.CompletedTask;
            };

        }



        async void ConnectSignalR()
        {
            connection.On("Client_StartSignatureScanning", Client_StartSignatureScanning);
            connection.On("Client_CancelSignatureScanning", Client_CancelSignatureScanning);
            try
            {
                statusSignalR.Text = "SignalR: Connecting";
                await connection.StartAsync();
                statusSignalR.Text = "SignalR: Established";
            }
            catch (Exception ex)
            {
                MessageBox.Show("SignalR Connect: " + ex.Message, "SignalR Connect Error");
            }
        }

        private void Client_CancelSignatureScanning()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.TopMost = false;
                }));

            }
            else
            {

                this.TopMost = false;
            }

            StopSign();
        }

        void Client_StartSignatureScanning()
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.TopMost = true;
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                    StartSign();
                }));

            }
            else
            {
                this.TopMost = true;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
                StartSign();
            }


        }


        #endregion


        void StartSign()
        {

        }

        void StopSign()
        {

        }

        private void statusSignalR_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // COMPLETE DESKTOP APP FUNCTION



            //DeleteFiles(folder);


            //.Save(wwwroot + "/sign.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            var d = new
            {
                Name = DateTime.Now.ToString("yyyyMMdd HHmmss"),
                Age = 55,
            };

            var json = JsonConvert.SerializeObject(d);

            await File.WriteAllTextAsync(wwwroot + "/data.json", json);

            // or you can save images and other data formats

            this.TopMost = false;
            this.WindowState = FormWindowState.Minimized;
           
            StopSign();

            // this will notify your webapp
            await connection.InvokeAsync("CompleteSignatureScanning");

        }
    }
}
