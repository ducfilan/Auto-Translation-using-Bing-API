namespace UpdateDataForLocalizedTables
{
    partial class NewCultureProp
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
            this.NewCultureNameTextBox = new System.Windows.Forms.TextBox();
            this.OUCultureKeyTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.XLSFilePathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BrowseFileExcelButton = new System.Windows.Forms.Button();
            this.AddCultureButton = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewSuccessTables = new System.Windows.Forms.ListView();
            this.listViewFailTables = new System.Windows.Forms.ListView();
            this.textBoxCultureDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCultureID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "New Culture Name";
            // 
            // NewCultureNameTextBox
            // 
            this.NewCultureNameTextBox.Location = new System.Drawing.Point(147, 12);
            this.NewCultureNameTextBox.Name = "NewCultureNameTextBox";
            this.NewCultureNameTextBox.Size = new System.Drawing.Size(88, 20);
            this.NewCultureNameTextBox.TabIndex = 0;
            this.NewCultureNameTextBox.Text = "ex: fr-FR";
            this.NewCultureNameTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewCultureNameTextBox_MouseDown);
            // 
            // OUCultureKeyTextbox
            // 
            this.OUCultureKeyTextbox.Location = new System.Drawing.Point(147, 78);
            this.OUCultureKeyTextbox.Name = "OUCultureKeyTextbox";
            this.OUCultureKeyTextbox.Size = new System.Drawing.Size(316, 20);
            this.OUCultureKeyTextbox.TabIndex = 2;
            this.OUCultureKeyTextbox.Text = "an Integer";
            this.OUCultureKeyTextbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OUCultureKeyTextbox_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "OU CULTURE KEY";
            // 
            // XLSFilePathTextBox
            // 
            this.XLSFilePathTextBox.Location = new System.Drawing.Point(147, 111);
            this.XLSFilePathTextBox.Name = "XLSFilePathTextBox";
            this.XLSFilePathTextBox.ReadOnly = true;
            this.XLSFilePathTextBox.Size = new System.Drawing.Size(267, 20);
            this.XLSFilePathTextBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "XLS Confirmed File Path";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "xls file|*.xls;*.xlsx";
            // 
            // BrowseFileExcelButton
            // 
            this.BrowseFileExcelButton.Location = new System.Drawing.Point(420, 109);
            this.BrowseFileExcelButton.Name = "BrowseFileExcelButton";
            this.BrowseFileExcelButton.Size = new System.Drawing.Size(43, 23);
            this.BrowseFileExcelButton.TabIndex = 5;
            this.BrowseFileExcelButton.Text = "...";
            this.BrowseFileExcelButton.UseVisualStyleBackColor = true;
            this.BrowseFileExcelButton.Click += new System.EventHandler(this.BrowseFileExcelButton_Click);
            // 
            // AddCultureButton
            // 
            this.AddCultureButton.Location = new System.Drawing.Point(296, 156);
            this.AddCultureButton.Name = "AddCultureButton";
            this.AddCultureButton.Size = new System.Drawing.Size(75, 23);
            this.AddCultureButton.TabIndex = 6;
            this.AddCultureButton.Text = "Add Culture";
            this.AddCultureButton.UseVisualStyleBackColor = true;
            this.AddCultureButton.Click += new System.EventHandler(this.AddCultureButton_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(390, 156);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 15;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Success tables";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(317, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Fail tables";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listViewSuccessTables, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listViewFailTables, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 196);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.754011F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.24599F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 374);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // listViewSuccessTables
            // 
            this.listViewSuccessTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSuccessTables.Location = new System.Drawing.Point(3, 32);
            this.listViewSuccessTables.Name = "listViewSuccessTables";
            this.listViewSuccessTables.Size = new System.Drawing.Size(232, 339);
            this.listViewSuccessTables.TabIndex = 1;
            this.listViewSuccessTables.UseCompatibleStateImageBehavior = false;
            this.listViewSuccessTables.View = System.Windows.Forms.View.List;
            // 
            // listViewFailTables
            // 
            this.listViewFailTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFailTables.Location = new System.Drawing.Point(241, 32);
            this.listViewFailTables.Name = "listViewFailTables";
            this.listViewFailTables.Size = new System.Drawing.Size(233, 339);
            this.listViewFailTables.TabIndex = 0;
            this.listViewFailTables.UseCompatibleStateImageBehavior = false;
            this.listViewFailTables.View = System.Windows.Forms.View.List;
            // 
            // textBoxCultureDescription
            // 
            this.textBoxCultureDescription.Location = new System.Drawing.Point(147, 45);
            this.textBoxCultureDescription.Name = "textBoxCultureDescription";
            this.textBoxCultureDescription.Size = new System.Drawing.Size(316, 20);
            this.textBoxCultureDescription.TabIndex = 1;
            this.textBoxCultureDescription.Text = "ex: EngLish-America";
            this.textBoxCultureDescription.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxCultureDescription_MouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Culture Description";
            // 
            // textBoxCultureID
            // 
            this.textBoxCultureID.Location = new System.Drawing.Point(375, 12);
            this.textBoxCultureID.Name = "textBoxCultureID";
            this.textBoxCultureID.Size = new System.Drawing.Size(88, 20);
            this.textBoxCultureID.TabIndex = 3;
            this.textBoxCultureID.Text = "an Integer";
            this.textBoxCultureID.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxCultureID_MouseDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "New Culture ID";
            // 
            // NewCultureProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 570);
            this.Controls.Add(this.textBoxCultureID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxCultureDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.AddCultureButton);
            this.Controls.Add(this.BrowseFileExcelButton);
            this.Controls.Add(this.XLSFilePathTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OUCultureKeyTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NewCultureNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "NewCultureProp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewCultureProp";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewCultureNameTextBox;
        private System.Windows.Forms.TextBox OUCultureKeyTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox XLSFilePathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BrowseFileExcelButton;
        private System.Windows.Forms.Button AddCultureButton;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listViewSuccessTables;
        private System.Windows.Forms.ListView listViewFailTables;
        private System.Windows.Forms.TextBox textBoxCultureDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCultureID;
        private System.Windows.Forms.Label label7;
    }
}