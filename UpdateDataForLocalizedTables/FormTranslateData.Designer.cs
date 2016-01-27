namespace UpdateDataForLocalizedTables
{
    partial class FormTranslateData
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
            this.btnBrowseFileExcel = new System.Windows.Forms.Button();
            this.tbXLSFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccTxt = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccBrowse = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.listFail = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurentTb = new System.Windows.Forms.Label();
            this.lblCurentClientID = new System.Windows.Forms.Label();
            this.btCopyClientID = new System.Windows.Forms.Button();
            this.btCopyCurentTb = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseFileExcel
            // 
            this.btnBrowseFileExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFileExcel.Location = new System.Drawing.Point(402, 68);
            this.btnBrowseFileExcel.Name = "btnBrowseFileExcel";
            this.btnBrowseFileExcel.Size = new System.Drawing.Size(43, 23);
            this.btnBrowseFileExcel.TabIndex = 2;
            this.btnBrowseFileExcel.Text = "...";
            this.btnBrowseFileExcel.UseVisualStyleBackColor = true;
            this.btnBrowseFileExcel.Click += new System.EventHandler(this.BrowseFileExcelButton_Click);
            // 
            // tbXLSFilePath
            // 
            this.tbXLSFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbXLSFilePath.Location = new System.Drawing.Point(92, 69);
            this.tbXLSFilePath.Name = "tbXLSFilePath";
            this.tbXLSFilePath.ReadOnly = true;
            this.tbXLSFilePath.Size = new System.Drawing.Size(294, 20);
            this.tbXLSFilePath.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Confirmed file";
            // 
            // btnTranslate
            // 
            this.btnTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTranslate.Enabled = false;
            this.btnTranslate.Location = new System.Drawing.Point(370, 110);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(75, 23);
            this.btnTranslate.TabIndex = 4;
            this.btnTranslate.Text = "Translate";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Acc Txt file";
            // 
            // txtAccTxt
            // 
            this.txtAccTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccTxt.Location = new System.Drawing.Point(92, 28);
            this.txtAccTxt.Name = "txtAccTxt";
            this.txtAccTxt.ReadOnly = true;
            this.txtAccTxt.Size = new System.Drawing.Size(294, 20);
            this.txtAccTxt.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(278, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccBrowse
            // 
            this.btnAccBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccBrowse.Location = new System.Drawing.Point(402, 26);
            this.btnAccBrowse.Name = "btnAccBrowse";
            this.btnAccBrowse.Size = new System.Drawing.Size(43, 23);
            this.btnAccBrowse.TabIndex = 0;
            this.btnAccBrowse.Text = "...";
            this.btnAccBrowse.UseVisualStyleBackColor = true;
            this.btnAccBrowse.Click += new System.EventHandler(this.btnAccBrowse_Click);
            // 
            // listFail
            // 
            this.listFail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listFail.FormattingEnabled = true;
            this.listFail.Location = new System.Drawing.Point(6, 19);
            this.listFail.Name = "listFail";
            this.listFail.Size = new System.Drawing.Size(425, 121);
            this.listFail.TabIndex = 0;
            this.listFail.Click += new System.EventHandler(this.listFail_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Current Table";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Current ClientID";
            // 
            // lblCurentTb
            // 
            this.lblCurentTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurentTb.AutoSize = true;
            this.lblCurentTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurentTb.ForeColor = System.Drawing.Color.Red;
            this.lblCurentTb.Location = new System.Drawing.Point(88, 297);
            this.lblCurentTb.Name = "lblCurentTb";
            this.lblCurentTb.Size = new System.Drawing.Size(24, 20);
            this.lblCurentTb.TabIndex = 6;
            this.lblCurentTb.Text = "...";
            // 
            // lblCurentClientID
            // 
            this.lblCurentClientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurentClientID.AutoSize = true;
            this.lblCurentClientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurentClientID.ForeColor = System.Drawing.Color.Red;
            this.lblCurentClientID.Location = new System.Drawing.Point(88, 324);
            this.lblCurentClientID.Name = "lblCurentClientID";
            this.lblCurentClientID.Size = new System.Drawing.Size(24, 20);
            this.lblCurentClientID.TabIndex = 8;
            this.lblCurentClientID.Text = "...";
            // 
            // btCopyClientID
            // 
            this.btCopyClientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCopyClientID.Location = new System.Drawing.Point(370, 324);
            this.btCopyClientID.Name = "btCopyClientID";
            this.btCopyClientID.Size = new System.Drawing.Size(75, 23);
            this.btCopyClientID.TabIndex = 9;
            this.btCopyClientID.Text = "Copy";
            this.btCopyClientID.UseVisualStyleBackColor = true;
            this.btCopyClientID.Click += new System.EventHandler(this.btCopyClientID_Click);
            // 
            // btCopyCurentTb
            // 
            this.btCopyCurentTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCopyCurentTb.Location = new System.Drawing.Point(370, 297);
            this.btCopyCurentTb.Name = "btCopyCurentTb";
            this.btCopyCurentTb.Size = new System.Drawing.Size(75, 23);
            this.btCopyCurentTb.TabIndex = 7;
            this.btCopyCurentTb.Text = "Copy";
            this.btCopyCurentTb.UseVisualStyleBackColor = true;
            this.btCopyCurentTb.Click += new System.EventHandler(this.btCopyCurentTb_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listFail);
            this.groupBox1.Location = new System.Drawing.Point(8, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 149);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fail tables - Click to Copy";
            // 
            // FormTranslateData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 366);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCopyCurentTb);
            this.Controls.Add(this.btCopyClientID);
            this.Controls.Add(this.lblCurentClientID);
            this.Controls.Add(this.lblCurentTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAccBrowse);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtAccTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.btnBrowseFileExcel);
            this.Controls.Add(this.tbXLSFilePath);
            this.Controls.Add(this.label3);
            this.Name = "FormTranslateData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTranslateData";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseFileExcel;
        private System.Windows.Forms.TextBox tbXLSFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccTxt;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ListBox listFail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurentTb;
        private System.Windows.Forms.Label lblCurentClientID;
        private System.Windows.Forms.Button btCopyClientID;
        private System.Windows.Forms.Button btCopyCurentTb;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}