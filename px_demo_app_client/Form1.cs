using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace px_demo_app_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region UI_Event_Handle_Methods
        
        private void btnGo_Click(object sender, EventArgs e)
        {
            string URI = textBoxRequest.Text;
            RestClient restClient = new RestClient(URI, HttpRequests.GET);

            string output = restClient.MakeRequest();
            
            DebugOutput(output);
        }

        #endregion UI_Event_Handle_Methods

        #region Debug_Methods
        /// <summary>
        /// Used for debugging.
        /// </summary>
        /// <param name="text">The debug text.</param>
        private void DebugOutput(string text)
        {
            try
            {
                System.Diagnostics.Debug.Write(text + Environment.NewLine);
                textBoxResponse.Text = textBoxResponse.Text + text + Environment.NewLine;
                textBoxResponse.SelectionStart = textBoxResponse.TextLength;
                textBoxResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
        #endregion Debug_Methods
    }
}
