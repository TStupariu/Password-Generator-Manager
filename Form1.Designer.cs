namespace PasswordGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bEXIT = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.bGenerate = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.bClipboard = new System.Windows.Forms.Button();
            this.bManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bEXIT
            // 
            this.bEXIT.Location = new System.Drawing.Point(375, 60);
            this.bEXIT.Name = "bEXIT";
            this.bEXIT.Size = new System.Drawing.Size(75, 23);
            this.bEXIT.TabIndex = 4;
            this.bEXIT.Text = "EXIT";
            this.bEXIT.UseVisualStyleBackColor = true;
            this.bEXIT.Click += new System.EventHandler(this.bEXIT_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(12, 35);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(37, 13);
            this.labelResult.TabIndex = 4;
            this.labelResult.Text = "Result";
            // 
            // bGenerate
            // 
            this.bGenerate.Location = new System.Drawing.Point(375, 4);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(75, 44);
            this.bGenerate.TabIndex = 1;
            this.bGenerate.Text = "Generate";
            this.bGenerate.UseVisualStyleBackColor = true;
            this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 4);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(354, 20);
            this.textBox.TabIndex = 0;
            // 
            // bClipboard
            // 
            this.bClipboard.Location = new System.Drawing.Point(15, 60);
            this.bClipboard.Name = "bClipboard";
            this.bClipboard.Size = new System.Drawing.Size(270, 23);
            this.bClipboard.TabIndex = 2;
            this.bClipboard.Text = "Copy To Clipboard";
            this.bClipboard.UseVisualStyleBackColor = true;
            this.bClipboard.Click += new System.EventHandler(this.bClipboard_Click);
            // 
            // bManager
            // 
            this.bManager.Location = new System.Drawing.Point(291, 60);
            this.bManager.Name = "bManager";
            this.bManager.Size = new System.Drawing.Size(75, 23);
            this.bManager.TabIndex = 3;
            this.bManager.Text = "Manager";
            this.bManager.UseVisualStyleBackColor = true;
            this.bManager.Click += new System.EventHandler(this.bManager_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 93);
            this.Controls.Add(this.bManager);
            this.Controls.Add(this.bClipboard);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.bGenerate);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.bEXIT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(478, 132);
            this.MinimumSize = new System.Drawing.Size(478, 132);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bEXIT;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button bGenerate;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button bClipboard;
        private System.Windows.Forms.Button bManager;
    }
}

