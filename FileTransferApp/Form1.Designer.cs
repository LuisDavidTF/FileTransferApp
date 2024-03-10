
namespace FileTransferApp
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RadioButton rbServidor;
        private System.Windows.Forms.RadioButton rbCliente;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbServidor = new System.Windows.Forms.RadioButton();
            this.rbCliente = new System.Windows.Forms.RadioButton();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rbServidor
            // 
            this.rbServidor.AutoSize = true;
            this.rbServidor.Location = new System.Drawing.Point(12, 12);
            this.rbServidor.Name = "rbServidor";
            this.rbServidor.Size = new System.Drawing.Size(68, 17);
            this.rbServidor.TabIndex = 0;
            this.rbServidor.TabStop = true;
            this.rbServidor.Text = "Servidor";
            this.rbServidor.UseVisualStyleBackColor = true;
            // 
            // rbCliente
            // 
            this.rbCliente.AutoSize = true;
            this.rbCliente.Location = new System.Drawing.Point(86, 12);
            this.rbCliente.Name = "rbCliente";
            this.rbCliente.Size = new System.Drawing.Size(61, 17);
            this.rbCliente.TabIndex = 1;
            this.rbCliente.TabStop = true;
            this.rbCliente.Text = "Cliente";
            this.rbCliente.UseVisualStyleBackColor = true;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(153, 8);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(12, 43);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 13);
            this.lblEstado.TabIndex = 3;
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Location = new System.Drawing.Point(12, 59);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(216, 20);
            this.txtRutaArchivo.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 91);
            this.Controls.Add(this.txtRutaArchivo);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.rbCliente);
            this.Controls.Add(this.rbServidor);
            this.Name = "Form1";
            this.Text = "File Transfer App";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

