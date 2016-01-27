namespace UpdateDataForLocalizedTables
{
    partial class UpdateDataForLocalizedTables
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
            this.btnCreateConnection = new System.Windows.Forms.Button();
            this.UpdateLocalizedTables = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AddCultureButton = new System.Windows.Forms.Button();
            this.btnTranslateData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateConnection
            // 
            this.btnCreateConnection.Location = new System.Drawing.Point(165, 11);
            this.btnCreateConnection.Name = "btnCreateConnection";
            this.btnCreateConnection.Size = new System.Drawing.Size(113, 23);
            this.btnCreateConnection.TabIndex = 0;
            this.btnCreateConnection.Text = "Create Connection";
            this.btnCreateConnection.UseVisualStyleBackColor = true;
            this.btnCreateConnection.Click += new System.EventHandler(this.CreateConnection);
            // 
            // UpdateLocalizedTables
            // 
            this.UpdateLocalizedTables.Location = new System.Drawing.Point(12, 11);
            this.UpdateLocalizedTables.Name = "UpdateLocalizedTables";
            this.UpdateLocalizedTables.Size = new System.Drawing.Size(113, 23);
            this.UpdateLocalizedTables.TabIndex = 1;
            this.UpdateLocalizedTables.Text = "Update Tables";
            this.UpdateLocalizedTables.UseVisualStyleBackColor = true;
            this.UpdateLocalizedTables.Click += new System.EventHandler(this.UpdateLocalizedTables_Click);
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.GridLines = true;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(12, 40);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(572, 473);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // AddCultureButton
            // 
            this.AddCultureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddCultureButton.Location = new System.Drawing.Point(471, 11);
            this.AddCultureButton.Name = "AddCultureButton";
            this.AddCultureButton.Size = new System.Drawing.Size(113, 23);
            this.AddCultureButton.TabIndex = 3;
            this.AddCultureButton.Text = "Add new Culture";
            this.AddCultureButton.UseVisualStyleBackColor = true;
            this.AddCultureButton.Click += new System.EventHandler(this.AddCultureButton_Click);
            // 
            // btnTranslateData
            // 
            this.btnTranslateData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTranslateData.Location = new System.Drawing.Point(318, 11);
            this.btnTranslateData.Name = "btnTranslateData";
            this.btnTranslateData.Size = new System.Drawing.Size(113, 23);
            this.btnTranslateData.TabIndex = 4;
            this.btnTranslateData.Text = "Translate Data";
            this.btnTranslateData.UseVisualStyleBackColor = true;
            this.btnTranslateData.Click += new System.EventHandler(this.btnTranslateData_Click);
            // 
            // UpdateDataForLocalizedTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 525);
            this.Controls.Add(this.btnTranslateData);
            this.Controls.Add(this.AddCultureButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.UpdateLocalizedTables);
            this.Controls.Add(this.btnCreateConnection);
            this.Name = "UpdateDataForLocalizedTables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Data For Localized Tables";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateConnection;
        private System.Windows.Forms.Button UpdateLocalizedTables;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button AddCultureButton;
        private System.Windows.Forms.Button btnTranslateData;
    }
}

