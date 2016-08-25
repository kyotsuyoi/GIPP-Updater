using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace frmGIPPUpdater
{
    public partial class frmGIPPUpdater : Form
    {
        Thread t;

        public frmGIPPUpdater()
        {
            InitializeComponent();
        }

        private void frmGIPPUpdater_Load(object sender, EventArgs e)
        {
            this.Focus();
            try
            {   // Abrir o arquivo para ler.
                using (StreamReader sr = new StreamReader(@"C:\Program Files (x86)\GIPP\path"))
                {
                    // Ler o arquivo para uma string.
                    String line = sr.ReadToEnd();

                    txtFilesPath.Text = line + @"\GIPP Updater\";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arquivo não pode ser lido: " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtToPath.Text = @"C:\Program Files (x86)\GIPP\";

            t = new Thread(ThreadProcess);
            t.Start();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //t = new Thread(ThreadProcess());
            t.Start();
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            try
            {
                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);

                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
                }

                DirectoryInfo[] dirs = dir.GetDirectories();
                // If the destination directory doesn't exist, create it.
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, false);
                    if (this.lblFiles.InvokeRequired)
                    {
                        this.lblFiles.BeginInvoke((MethodInvoker)delegate () { this.lblFiles.Text = file.ToString(); });
                    }
                    else
                    {
                        this.lblFiles.Text = "";
                    }
                }

                // If copying subdirectories, copy them and their contents to new location.
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                        this.lblFiles.BeginInvoke((MethodInvoker)delegate () { this.lblFiles.Text = subdir.ToString(); });
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ThreadProcess()
        {
            try
            {

                int i = 5;
                while (i > 0)
                {
                    this.lblFiles.BeginInvoke((MethodInvoker)delegate () { this.lblFiles.Text = "A atualização inicia em " + i.ToString() + " segundos"; });
                    Thread.Sleep(1000);
                    i -= 1;
                }

                string sourcePath = @"" + txtFilesPath.Text;
                string targetPath = @"" + txtToPath.Text;

                System.IO.File.Copy(sourcePath + "GIPP.exe", targetPath + "GIPP.exe", true);

                i = 5;
                while (i > 0)
                {
                    this.lblFiles.BeginInvoke((MethodInvoker)delegate () {
                        this.lblFiles.Text = "A atualização terminou, reiniciando GIPP em: " + i.ToString() + " segundos"; });
                    Thread.Sleep(1000);
                    i -= 1;
                }
                System.Diagnostics.Process.Start(targetPath + "GIPP.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.lblFiles.BeginInvoke((MethodInvoker)delegate () { this.lblFiles.Text = "A atualização falhou!"; });
            }
            this.lblFiles.BeginInvoke((MethodInvoker)delegate () { this.Close(); });
        }
    }
}
