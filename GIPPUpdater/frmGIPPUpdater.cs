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
            btnUpdate.Enabled = false;
            try
            {   // Abrir o arquivo para ler o caminho do servidor.
                using (StreamReader sr = new StreamReader(@"C:\Program Files (x86)\GIPP\path"))
                {
                    // Ler o conteudo do arquivo para uma string.
                    String line = sr.ReadToEnd();
                    // Define o local do .exe de atualização no diretório correspondente.
                    txtFilesPath.Text = line + @"\GIPP Updater\";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arquivo não pode ser lido: " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Define o diretório destino do .exe.
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
                // Encontra os subdiretórios do diretório especificado.
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);

                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
                }

                DirectoryInfo[] dirs = dir.GetDirectories();
                // Se o diretório destinado não existe, crie-o.
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                // Encontra os arquivos de um diretório e os copia para o novo local.
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

                // Se estiver copiando diretórios, copia qualquer conteúdo para a nova localização.
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
            this.btnUpdate.BeginInvoke((MethodInvoker)delegate () { btnUpdate.Enabled = false; });
            try
            {

                int i = 5;
                while (i > 0)
                {
                    // Mostra em tempo real a espera para iniciar o processo (esse tempo é necessário para evitar que esse Thread inicie seu serviços antes que a Thread principal seja totalmente criada).
                    this.lblFiles.BeginInvoke((MethodInvoker)delegate () { this.lblFiles.Text = "A atualização inicia em " + i.ToString() + " segundos"; });
                    Thread.Sleep(1000);
                    i -= 1;
                }
                // Guarda em variáveis os caminhos de origem e destino.
                string sourcePath = @"" + txtFilesPath.Text;
                string targetPath = @"" + txtToPath.Text;
                // Copia o .exe de atualização.
                System.IO.File.Copy(sourcePath + "GIPP.exe", targetPath + "GIPP.exe", true);

                i = 5;
                while (i > 0)
                {
                    // Tempo de espera para fechar todas as Threads e ativar o .exe copiado.
                    this.lblFiles.BeginInvoke((MethodInvoker)delegate () {
                        this.lblFiles.Text = "A atualização terminou, reiniciando GIPP em: " + i.ToString() + " segundos"; });
                    Thread.Sleep(1000);
                    i -= 1;
                }
                // Executa o .exe.
                System.Diagnostics.Process.Start(targetPath + "GIPP.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.lblFiles.BeginInvoke((MethodInvoker)delegate () { this.lblFiles.Text = "A atualização falhou!"; });
                this.btnUpdate.BeginInvoke((MethodInvoker)delegate () { btnUpdate.Enabled = true; });
            }
            // Desativa a Trhead principal.
            this.lblFiles.BeginInvoke((MethodInvoker)delegate () { this.Close(); });

            
        }
    }
}
