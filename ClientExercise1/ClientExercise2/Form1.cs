using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace ClientExercise2
{
    public partial class Form1 : Form
    {
        const string apiKey = "abdcb6922e0d826d2959df4048276068610126e99ba8";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = $"https://api.thumbnail.ws/api/" + apiKey + "/thumbnail/get?url=" + textBox1.Text + "&width=" + pictureBox1.Width;

            try
            {
                var request = WebRequest.Create(url);
                var response = request.GetResponse();
                label1.Text = ((HttpWebResponse)response).StatusDescription;
                var stream = response.GetResponseStream();
                var image = Image.FromStream(stream);
                pictureBox1.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }


    }
}
