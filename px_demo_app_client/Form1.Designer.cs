
namespace px_demo_app_client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRequest = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxResponse = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Request URI:";
            // 
            // textBoxRequest
            // 
            this.textBoxRequest.Location = new System.Drawing.Point(116, 53);
            this.textBoxRequest.Name = "textBoxRequest";
            this.textBoxRequest.Size = new System.Drawing.Size(244, 22);
            this.textBoxRequest.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(384, 44);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(81, 40);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Response:";
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResponse.Location = new System.Drawing.Point(117, 99);
            this.textBoxResponse.Multiline = true;
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResponse.Size = new System.Drawing.Size(418, 181);
            this.textBoxResponse.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 308);
            this.Controls.Add(this.textBoxResponse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.textBoxRequest);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "px_demo_app_client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRequest;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxResponse;
    }
}

