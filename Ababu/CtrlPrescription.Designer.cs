﻿namespace Ababu
{
    partial class CtrlPrescription
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.TlpPrescription = new System.Windows.Forms.TableLayoutPanel();
            this.PanPrescription = new System.Windows.Forms.Panel();
            this.BtnMedicineSelect = new System.Windows.Forms.Button();
            this.CmbMedicines = new System.Windows.Forms.ComboBox();
            this.GrdPrescriptions = new System.Windows.Forms.DataGridView();
            this.TlpPrescription.SuspendLayout();
            this.PanPrescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdPrescriptions)).BeginInit();
            this.SuspendLayout();
            // 
            // TlpPrescription
            // 
            this.TlpPrescription.ColumnCount = 1;
            this.TlpPrescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPrescription.Controls.Add(this.GrdPrescriptions, 0, 1);
            this.TlpPrescription.Controls.Add(this.PanPrescription, 0, 0);
            this.TlpPrescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpPrescription.Location = new System.Drawing.Point(0, 0);
            this.TlpPrescription.Name = "TlpPrescription";
            this.TlpPrescription.RowCount = 2;
            this.TlpPrescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TlpPrescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPrescription.Size = new System.Drawing.Size(485, 336);
            this.TlpPrescription.TabIndex = 0;
            // 
            // PanPrescription
            // 
            this.PanPrescription.Controls.Add(this.BtnMedicineSelect);
            this.PanPrescription.Controls.Add(this.CmbMedicines);
            this.PanPrescription.Location = new System.Drawing.Point(3, 3);
            this.PanPrescription.Name = "PanPrescription";
            this.PanPrescription.Size = new System.Drawing.Size(411, 33);
            this.PanPrescription.TabIndex = 4;
            // 
            // BtnMedicineSelect
            // 
            this.BtnMedicineSelect.Image = global::Ababu.Properties.Resources.accept;
            this.BtnMedicineSelect.Location = new System.Drawing.Point(255, 3);
            this.BtnMedicineSelect.Name = "BtnMedicineSelect";
            this.BtnMedicineSelect.Size = new System.Drawing.Size(25, 23);
            this.BtnMedicineSelect.TabIndex = 6;
            this.BtnMedicineSelect.UseVisualStyleBackColor = true;
            // 
            // CmbMedicines
            // 
            this.CmbMedicines.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbMedicines.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbMedicines.FormattingEnabled = true;
            this.CmbMedicines.Location = new System.Drawing.Point(3, 3);
            this.CmbMedicines.Name = "CmbMedicines";
            this.CmbMedicines.Size = new System.Drawing.Size(246, 21);
            this.CmbMedicines.TabIndex = 5;
            // 
            // GrdPrescriptions
            // 
            this.GrdPrescriptions.AllowUserToAddRows = false;
            this.GrdPrescriptions.AllowUserToDeleteRows = false;
            this.GrdPrescriptions.AllowUserToResizeColumns = false;
            this.GrdPrescriptions.AllowUserToResizeRows = false;
            this.GrdPrescriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.GrdPrescriptions.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GrdPrescriptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdPrescriptions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GrdPrescriptions.ColumnHeadersVisible = false;
            this.GrdPrescriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdPrescriptions.Location = new System.Drawing.Point(3, 48);
            this.GrdPrescriptions.Name = "GrdPrescriptions";
            this.GrdPrescriptions.ReadOnly = true;
            this.GrdPrescriptions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GrdPrescriptions.RowHeadersVisible = false;
            this.GrdPrescriptions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GrdPrescriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdPrescriptions.Size = new System.Drawing.Size(479, 285);
            this.GrdPrescriptions.TabIndex = 5;
            // 
            // CtrlPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TlpPrescription);
            this.Name = "CtrlPrescription";
            this.Size = new System.Drawing.Size(485, 336);
            this.Load += new System.EventHandler(this.CtrlPrescription_Load);
            this.TlpPrescription.ResumeLayout(false);
            this.PanPrescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdPrescriptions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlpPrescription;
        private System.Windows.Forms.Panel PanPrescription;
        private System.Windows.Forms.Button BtnMedicineSelect;
        private System.Windows.Forms.ComboBox CmbMedicines;
        private System.Windows.Forms.DataGridView GrdPrescriptions;
    }
}