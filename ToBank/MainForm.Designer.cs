/*
 * Created by SharpDevelop.
 * User: Familia
 * Date: 14/05/2016
 * Time: 21:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace App
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
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.btnOpenExcel = new System.Windows.Forms.Button();
			this.btnPagos = new System.Windows.Forms.Button();
			this.btnAltas = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOpenExcel
			// 
			this.btnOpenExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOpenExcel.Location = new System.Drawing.Point(12, 45);
			this.btnOpenExcel.Name = "btnOpenExcel";
			this.btnOpenExcel.Size = new System.Drawing.Size(146, 41);
			this.btnOpenExcel.TabIndex = 0;
			this.btnOpenExcel.Text = "&1 Abrir tabla";
			this.btnOpenExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOpenExcel.UseVisualStyleBackColor = true;
			this.btnOpenExcel.Click += new System.EventHandler(this.BtnOpenExcelClick);
			// 
			// btnPagos
			// 
			this.btnPagos.Enabled = false;
			this.btnPagos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
			this.btnPagos.Location = new System.Drawing.Point(12, 138);
			this.btnPagos.Name = "btnPagos";
			this.btnPagos.Size = new System.Drawing.Size(146, 41);
			this.btnPagos.TabIndex = 1;
			this.btnPagos.Text = "&3 Generar pagos";
			this.btnPagos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPagos.UseVisualStyleBackColor = true;
			this.btnPagos.Click += new System.EventHandler(this.BtnPagosClick);
			// 
			// btnAltas
			// 
			this.btnAltas.Enabled = false;
			this.btnAltas.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
			this.btnAltas.Location = new System.Drawing.Point(12, 92);
			this.btnAltas.Name = "btnAltas";
			this.btnAltas.Size = new System.Drawing.Size(146, 41);
			this.btnAltas.TabIndex = 2;
			this.btnAltas.Text = "&2 Generar altas";
			this.btnAltas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAltas.UseVisualStyleBackColor = true;
			this.btnAltas.Click += new System.EventHandler(this.BtnAltasClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tsslStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 193);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(374, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsslStatus
			// 
			this.tsslStatus.ForeColor = System.Drawing.Color.DarkBlue;
			this.tsslStatus.Name = "tsslStatus";
			this.tsslStatus.Size = new System.Drawing.Size(0, 17);
			this.tsslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.label1.ForeColor = System.Drawing.Color.Navy;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(340, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Alta empleados y pagos de haberes";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(164, 45);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(200, 134);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(374, 215);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnAltas);
			this.Controls.Add(this.btnPagos);
			this.Controls.Add(this.btnOpenExcel);
			this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "SPERANTIA";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
