namespace frmGIPPUpdater
{
    partial class frmGIPPUpdater
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
            this.lblFiles = new System.Windows.Forms.Label();
            this.txtToPath = new System.Windows.Forms.TextBox();
            this.txtFilesPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(10, 104);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(13, 13);
            this.lblFiles.TabIndex = 18;
            this.lblFiles.Text = "_";
            // 
            // txtToPath
            // 
            this.txtToPath.Location = new System.Drawing.Point(195, 38);
            this.txtToPath.Name = "txtToPath";
            this.txtToPath.Size = new System.Drawing.Size(192, 20);
            this.txtToPath.TabIndex = 16;
            // 
            // txtFilesPath
            // 
            this.txtFilesPath.Location = new System.Drawing.Point(195, 12);
            this.txtFilesPath.Name = "txtFilesPath";
            this.txtFilesPath.Size = new System.Drawing.Size(192, 20);
            this.txtFilesPath.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Caminho para gravar arquivos/dados:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Caminho para copiar arquivos/dados:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(292, 64);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 23);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Atualizar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmGIPPUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 132);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblFiles);
            this.Controls.Add(this.txtToPath);
            this.Controls.Add(this.txtFilesPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmGIPPUpdater";
            this.Text = "GIPP Updater";
            this.Load += new System.EventHandler(this.frmGIPPUpdater_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.TextBox txtToPath;
        private System.Windows.Forms.TextBox txtFilesPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdate;
    }
}

