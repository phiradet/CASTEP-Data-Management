namespace CASTEP_Management
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.list_Files = new System.Windows.Forms.ListView();
            this.Filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FullPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_SaveFilename = new System.Windows.Forms.Button();
            this.txt_SaveFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.Location = new System.Drawing.Point(451, 12);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(49, 23);
            this.btn_SelectFile.TabIndex = 0;
            this.btn_SelectFile.Text = "Add";
            this.btn_SelectFile.UseVisualStyleBackColor = true;
            this.btn_SelectFile.Click += new System.EventHandler(this.btn_SelectFile_Click);
            // 
            // list_Files
            // 
            this.list_Files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Filename,
            this.Stress,
            this.FullPath});
            this.list_Files.Location = new System.Drawing.Point(12, 12);
            this.list_Files.Name = "list_Files";
            this.list_Files.Size = new System.Drawing.Size(433, 141);
            this.list_Files.TabIndex = 1;
            this.list_Files.UseCompatibleStateImageBehavior = false;
            this.list_Files.View = System.Windows.Forms.View.Details;
            // 
            // Filename
            // 
            this.Filename.Text = "Filename";
            this.Filename.Width = 116;
            // 
            // Stress
            // 
            this.Stress.Text = "Stress";
            // 
            // FullPath
            // 
            this.FullPath.Text = "Full Path";
            this.FullPath.Width = 253;
            // 
            // btn_SaveFilename
            // 
            this.btn_SaveFilename.Location = new System.Drawing.Point(451, 168);
            this.btn_SaveFilename.Name = "btn_SaveFilename";
            this.btn_SaveFilename.Size = new System.Drawing.Size(49, 23);
            this.btn_SaveFilename.TabIndex = 2;
            this.btn_SaveFilename.Text = "...";
            this.btn_SaveFilename.UseVisualStyleBackColor = true;
            this.btn_SaveFilename.Click += new System.EventHandler(this.btn_SaveFilename_Click);
            // 
            // txt_SaveFilename
            // 
            this.txt_SaveFilename.Location = new System.Drawing.Point(63, 171);
            this.txt_SaveFilename.Name = "txt_SaveFilename";
            this.txt_SaveFilename.Size = new System.Drawing.Size(382, 20);
            this.txt_SaveFilename.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Output";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(451, 41);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(49, 23);
            this.btn_Clear.TabIndex = 5;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(15, 207);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(81, 23);
            this.btn_Run.TabIndex = 6;
            this.btn_Run.Text = "Run";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(102, 207);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(343, 23);
            this.progressBar.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 245);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_SaveFilename);
            this.Controls.Add(this.btn_SaveFilename);
            this.Controls.Add(this.list_Files);
            this.Controls.Add(this.btn_SelectFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "CASTEP To XLS Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_SelectFile;
        private System.Windows.Forms.ListView list_Files;
        private System.Windows.Forms.ColumnHeader Filename;
        private System.Windows.Forms.ColumnHeader Stress;
        private System.Windows.Forms.ColumnHeader FullPath;
        private System.Windows.Forms.Button btn_SaveFilename;
        private System.Windows.Forms.TextBox txt_SaveFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

