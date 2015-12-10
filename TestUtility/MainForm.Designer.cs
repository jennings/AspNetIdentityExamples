namespace TestUtility
{
    partial class MainForm
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
            this.tokenTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.authenticatedButton = new System.Windows.Forms.Button();
            this.unauthenticatedButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.sendTokenCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tokenTextBox
            // 
            this.tokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tokenTextBox.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tokenTextBox.Location = new System.Drawing.Point(222, 48);
            this.tokenTextBox.Name = "tokenTextBox";
            this.tokenTextBox.Size = new System.Drawing.Size(469, 30);
            this.tokenTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Service URL";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressTextBox.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressTextBox.Location = new System.Drawing.Point(222, 12);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(791, 30);
            this.addressTextBox.TabIndex = 2;
            this.addressTextBox.Text = "https://localhost:44300/ApiTokenAuthentication/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bearer Token";
            // 
            // authenticatedButton
            // 
            this.authenticatedButton.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticatedButton.Location = new System.Drawing.Point(222, 84);
            this.authenticatedButton.Name = "authenticatedButton";
            this.authenticatedButton.Size = new System.Drawing.Size(259, 63);
            this.authenticatedButton.TabIndex = 4;
            this.authenticatedButton.Text = "/authenticated";
            this.authenticatedButton.UseVisualStyleBackColor = true;
            this.authenticatedButton.Click += new System.EventHandler(this.authenticatedButton_Click);
            // 
            // unauthenticatedButton
            // 
            this.unauthenticatedButton.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unauthenticatedButton.Location = new System.Drawing.Point(487, 84);
            this.unauthenticatedButton.Name = "unauthenticatedButton";
            this.unauthenticatedButton.Size = new System.Drawing.Size(259, 63);
            this.unauthenticatedButton.TabIndex = 5;
            this.unauthenticatedButton.Text = "/unauthenticated";
            this.unauthenticatedButton.UseVisualStyleBackColor = true;
            this.unauthenticatedButton.Click += new System.EventHandler(this.unauthenticatedButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTextBox.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultTextBox.Location = new System.Drawing.Point(12, 153);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(1001, 812);
            this.resultTextBox.TabIndex = 6;
            // 
            // sendTokenCheckBox
            // 
            this.sendTokenCheckBox.AutoSize = true;
            this.sendTokenCheckBox.Checked = true;
            this.sendTokenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sendTokenCheckBox.Location = new System.Drawing.Point(698, 52);
            this.sendTokenCheckBox.Name = "sendTokenCheckBox";
            this.sendTokenCheckBox.Size = new System.Drawing.Size(121, 24);
            this.sendTokenCheckBox.TabIndex = 7;
            this.sendTokenCheckBox.Text = "Send Token";
            this.sendTokenCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 977);
            this.Controls.Add(this.sendTokenCheckBox);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.unauthenticatedButton);
            this.Controls.Add(this.authenticatedButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tokenTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tokenTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button authenticatedButton;
        private System.Windows.Forms.Button unauthenticatedButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.CheckBox sendTokenCheckBox;
    }
}

