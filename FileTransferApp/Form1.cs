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
using System.Net;
using System.Net.Sockets;

namespace FileTransferApp
{
    public partial class Form1 : Form
    {
        private const int puerto = 12345;
        private TcpListener servidor;
        private TcpClient cliente;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (rbServidor.Checked)
            {
                IniciarServidor();
            }
            else if (rbCliente.Checked)
            {
                SeleccionarArchivoYEnviar();
            }
            else
            {
                MessageBox.Show("Selecciona si deseas ser el servidor o el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IniciarServidor()
        {
            try
            {
                servidor = new TcpListener(IPAddress.Any, puerto);
                servidor.Start();

                cliente = servidor.AcceptTcpClient();

                ManejarTransferencia();

                servidor.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar el servidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManejarTransferencia()
        {
            using (NetworkStream networkStream = cliente.GetStream())
            using (BinaryReader reader = new BinaryReader(networkStream))
            {
                // Ruta donde se guardará el archivo recibido.
                string rutaArchivo = Path.Combine(Application.StartupPath, "archivo_recibido.txt");

                using (FileStream fileStream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }
                }

                this.Invoke((MethodInvoker)delegate
                {
                    lblEstado.Text = "Archivo recibido exitosamente.";
                    txtRutaArchivo.Text = rutaArchivo;
                });
            }
        }

        private void SeleccionarArchivoYEnviar()
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        cliente = new TcpClient("192.168.1.1", puerto);

                        using (NetworkStream networkStream = cliente.GetStream())
                        using (BinaryWriter writer = new BinaryWriter(networkStream))
                        using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;

                            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                writer.Write(buffer, 0, bytesRead);
                            }
                        }

                        MessageBox.Show("Transferencia completada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la transferencia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cliente.Close();
            }
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No se pudo encontrar la dirección IP local.");
        }
    }
}

