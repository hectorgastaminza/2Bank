/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 14/05/2016
 * Time: 21:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ToBank
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnOpenExcel;
		private System.Windows.Forms.Button btnPagos;
		private System.Windows.Forms.Button btnAltas;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnOpenExcel = new System.Windows.Forms.Button();
			this.btnPagos = new System.Windows.Forms.Button();
			this.btnAltas = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOpenExcel
			// 
			this.btnOpenExcel.Location = new System.Drawing.Point(22, 45);
			this.btnOpenExcel.Name = "btnOpenExcel";
			this.btnOpenExcel.Size = new System.Drawing.Size(97, 23);
			this.btnOpenExcel.TabIndex = 0;
			this.btnOpenExcel.Text = "Abrir &Tabla";
			this.btnOpenExcel.UseVisualStyleBackColor = true;
			this.btnOpenExcel.Click += new System.EventHandler(this.BtnOpenExcelClick);
			// 
			// btnPagos
			// 
			this.btnPagos.Location = new System.Drawing.Point(22, 94);
			this.btnPagos.Name = "btnPagos";
			this.btnPagos.Size = new System.Drawing.Size(97, 23);
			this.btnPagos.TabIndex = 1;
			this.btnPagos.Text = "Generar &Pagos";
			this.btnPagos.UseVisualStyleBackColor = true;
			this.btnPagos.Click += new System.EventHandler(this.BtnPagosClick);
			// 
			// btnAltas
			// 
			this.btnAltas.Location = new System.Drawing.Point(22, 144);
			this.btnAltas.Name = "btnAltas";
			this.btnAltas.Size = new System.Drawing.Size(97, 23);
			this.btnAltas.TabIndex = 2;
			this.btnAltas.Text = "Generar &Altas";
			this.btnAltas.UseVisualStyleBackColor = true;
			this.btnAltas.Click += new System.EventHandler(this.BtnAltasClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(364, 284);
			this.Controls.Add(this.btnAltas);
			this.Controls.Add(this.btnPagos);
			this.Controls.Add(this.btnOpenExcel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "ToBank";
			this.ResumeLayout(false);

		}
	}
}
