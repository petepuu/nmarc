// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace NMARC
{
    partial class FrmNativeModeConc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNativeModeConc));
            this.BtnLoadYamlFile = new System.Windows.Forms.Button();
            this.txtYamlInputPath = new System.Windows.Forms.TextBox();
            this.BtnSetOutputDir = new System.Windows.Forms.Button();
            this.TxtOutputPath = new System.Windows.Forms.TextBox();
            this.txtResultsBox = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.dlgOpenYaml = new System.Windows.Forms.OpenFileDialog();
            this.DlgSelectOutputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblCsvSeparator = new System.Windows.Forms.Label();
            this.txtCsvSeparator = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnLoadYamlFile
            // 
            this.BtnLoadYamlFile.Location = new System.Drawing.Point(18, 18);
            this.BtnLoadYamlFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnLoadYamlFile.Name = "BtnLoadYamlFile";
            this.BtnLoadYamlFile.Size = new System.Drawing.Size(186, 35);
            this.BtnLoadYamlFile.TabIndex = 0;
            this.BtnLoadYamlFile.Text = "Select YAML File";
            this.toolTip.SetToolTip(this.BtnLoadYamlFile, "Specify the path to the Alignment Report downloaded from Yammer.");
            this.BtnLoadYamlFile.UseVisualStyleBackColor = true;
            this.BtnLoadYamlFile.Click += new System.EventHandler(this.LoadYamlFile_Click);
            // 
            // txtYamlInputPath
            // 
            this.txtYamlInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYamlInputPath.Location = new System.Drawing.Point(213, 22);
            this.txtYamlInputPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtYamlInputPath.Name = "txtYamlInputPath";
            this.txtYamlInputPath.ReadOnly = true;
            this.txtYamlInputPath.Size = new System.Drawing.Size(972, 26);
            this.txtYamlInputPath.TabIndex = 1;
            // 
            // BtnSetOutputDir
            // 
            this.BtnSetOutputDir.Location = new System.Drawing.Point(20, 65);
            this.BtnSetOutputDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSetOutputDir.Name = "BtnSetOutputDir";
            this.BtnSetOutputDir.Size = new System.Drawing.Size(184, 35);
            this.BtnSetOutputDir.TabIndex = 2;
            this.BtnSetOutputDir.Text = "Set Output Folder";
            this.toolTip.SetToolTip(this.BtnSetOutputDir, "Set an empty output folder where the CSV files will be created.");
            this.BtnSetOutputDir.UseVisualStyleBackColor = true;
            this.BtnSetOutputDir.Click += new System.EventHandler(this.BtnSetOutputDir_Click);
            // 
            // TxtOutputPath
            // 
            this.TxtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtOutputPath.Location = new System.Drawing.Point(214, 68);
            this.TxtOutputPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtOutputPath.Name = "TxtOutputPath";
            this.TxtOutputPath.ReadOnly = true;
            this.TxtOutputPath.Size = new System.Drawing.Size(970, 26);
            this.TxtOutputPath.TabIndex = 3;
            // 
            // txtResultsBox
            // 
            this.txtResultsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultsBox.Location = new System.Drawing.Point(18, 176);
            this.txtResultsBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtResultsBox.Multiline = true;
            this.txtResultsBox.Name = "txtResultsBox";
            this.txtResultsBox.ReadOnly = true;
            this.txtResultsBox.Size = new System.Drawing.Size(1166, 561);
            this.txtResultsBox.TabIndex = 4;
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(948, 748);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(238, 35);
            this.btnConvert.TabIndex = 5;
            this.btnConvert.Text = "Convert Alignment Report";
            this.toolTip.SetToolTip(this.btnConvert, "Start conversion when the input and output options are selected.");
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // dlgOpenYaml
            // 
            this.dlgOpenYaml.Filter = "Alignment Reports (*.yml)|*.yml|All files (*.*)|*.*";
            this.dlgOpenYaml.Title = "Select an Alignment Report";
            // 
            // DlgSelectOutputFolder
            // 
            this.DlgSelectOutputFolder.Description = "Select an output folder for the CSV files produced by this tool. This needs to be" +
    " an empty folder.";
            // 
            // lblCsvSeparator
            // 
            this.lblCsvSeparator.AutoSize = true;
            this.lblCsvSeparator.Location = new System.Drawing.Point(32, 117);
            this.lblCsvSeparator.Name = "lblCsvSeparator";
            this.lblCsvSeparator.Size = new System.Drawing.Size(114, 20);
            this.lblCsvSeparator.TabIndex = 6;
            this.lblCsvSeparator.Text = "CSV separator";
            // 
            // txtCsvSeparator
            // 
            this.txtCsvSeparator.Location = new System.Drawing.Point(214, 117);
            this.txtCsvSeparator.MaxLength = 1;
            this.txtCsvSeparator.Name = "txtCsvSeparator";
            this.txtCsvSeparator.Size = new System.Drawing.Size(50, 26);
            this.txtCsvSeparator.TabIndex = 7;
            this.txtCsvSeparator.Text = ",";
            // 
            // FrmNativeModeConc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 802);
            this.Controls.Add(this.txtCsvSeparator);
            this.Controls.Add(this.lblCsvSeparator);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtResultsBox);
            this.Controls.Add(this.TxtOutputPath);
            this.Controls.Add(this.BtnSetOutputDir);
            this.Controls.Add(this.txtYamlInputPath);
            this.Controls.Add(this.BtnLoadYamlFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmNativeModeConc";
            this.Text = "Native Mode Alignment Report Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoadYamlFile;
        private System.Windows.Forms.TextBox txtYamlInputPath;
        private System.Windows.Forms.Button BtnSetOutputDir;
        private System.Windows.Forms.TextBox TxtOutputPath;
        private System.Windows.Forms.TextBox txtResultsBox;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.OpenFileDialog dlgOpenYaml;
        private System.Windows.Forms.FolderBrowserDialog DlgSelectOutputFolder;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblCsvSeparator;
        private System.Windows.Forms.TextBox txtCsvSeparator;
    }
}

