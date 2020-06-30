namespace Blue_Botnet_Bot_Builder
{
    partial class Builder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Builder));
            this.Build = new System.Windows.Forms.Button();
            this.PanelURL = new System.Windows.Forms.TextBox();
            this.Threads = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Build
            // 
            this.Build.Location = new System.Drawing.Point(12, 76);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(263, 39);
            this.Build.TabIndex = 0;
            this.Build.Text = "Build";
            this.Build.UseVisualStyleBackColor = true;
            this.Build.Click += new System.EventHandler(this.Build_Click);
            // 
            // PanelURL
            // 
            this.PanelURL.Location = new System.Drawing.Point(12, 12);
            this.PanelURL.Name = "PanelURL";
            this.PanelURL.Size = new System.Drawing.Size(263, 26);
            this.PanelURL.TabIndex = 1;
            this.PanelURL.Text = "http://yourpanel.com";
            // 
            // Threads
            // 
            this.Threads.Location = new System.Drawing.Point(75, 44);
            this.Threads.Name = "Threads";
            this.Threads.Size = new System.Drawing.Size(200, 26);
            this.Threads.TabIndex = 2;
            this.Threads.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Threads";
            // 
            // Builder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 122);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Threads);
            this.Controls.Add(this.PanelURL);
            this.Controls.Add(this.Build);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Builder";
            this.Text = "Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Build;
        private System.Windows.Forms.TextBox PanelURL;
        private System.Windows.Forms.TextBox Threads;
        private System.Windows.Forms.Label label1;
    }
}