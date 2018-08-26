﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OldAuntie;
using System.Globalization;

namespace Ababu
{
    public partial class CtrlPrescription : UserControl
    {
        public Pet oPet { get; set; }
        public Prescription Prescrizione { get; set; }


        public CtrlPrescription(Pet pet)
        {
            oPet = pet;
            InitializeComponent();
        }

        private void CtrlPrescription_Load(object sender, EventArgs e)
        {
            FillControl();
        }

        public void FillControl()
        {
            CmbMedicines.DataSource = Medicine.Search();
            
            CmbMedicines.ValueMember = "mid";
            CmbMedicines.DisplayMember = "value";
            CmbMedicines.SelectedValue = 0;

            DataTable DtPrescriptions = Prescription.GetPrescriptionByPid(oPet.Pid);
            DataColumn DcProblemEssential = DtPrescriptions.Columns.Add("in_evidenve_image", typeof(Image));


            for (int j = 0; j < DtPrescriptions.Rows.Count; j++)
            {
                bool in_evidence = (bool)DtPrescriptions.Rows[j]["in_evidence"];

                
                // Set column for essential information
                if (in_evidence == true)
                {
                    DtPrescriptions.Rows[j]["in_evidenve_image"] = (Image)Properties.Resources.tick;
                }
                else
                {
                    DtPrescriptions.Rows[j]["in_evidenve_image"] = (Image)Properties.Resources.lightbulb_off;
                }
            }



            GrdPrescriptions.DataSource = DtPrescriptions;

            // formmating the datagridview
            GrdPrescriptions.Columns["created"].DefaultCellStyle.Format = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            GrdPrescriptions.Columns["created"].DisplayIndex = 0;

            GrdPrescriptions.Columns["prescription_id"].Visible = false;
            GrdPrescriptions.Columns["pid"].Visible = false;
            GrdPrescriptions.Columns["mid"].Visible = false;
            GrdPrescriptions.Columns["in_evidence"].Visible = false;
            GrdPrescriptions.Columns["date_of_issue"].Visible = false;
            GrdPrescriptions.Columns["date_of_withdrawal"].Visible = false;

            GrdPrescriptions.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CmbMedicines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbMedicines.SelectedItem != null && CmbMedicines.SelectedValue != null)
                {
                    OpenPrescriptionEdit(CmbMedicines.SelectedValue.ToString(), oPet);
                }
            }
        }


        private void OpenPrescriptionEdit(string mid, Pet pet, int prescription_id = 0)
        {
            FrmPrescriptionEdit frmPrescriptionEdit = new FrmPrescriptionEdit(prescription_id);
            frmPrescriptionEdit.oMedicine = new Medicine(mid);
            frmPrescriptionEdit.oPet = pet;
            frmPrescriptionEdit.FormClosing += new FormClosingEventHandler(PrescriptionEdit_FormClosing);
            frmPrescriptionEdit.ShowDialog();
        }


        private void PrescriptionEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            FillControl();
        }

        private void GrdPrescriptions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // DateTime created = (DateTime)GrdPrescriptions.Rows[e.RowIndex].Cells[0].Value;
            int prescription_id = (int)GrdPrescriptions.Rows[e.RowIndex].Cells[0].Value;
            string mid = GrdPrescriptions.Rows[e.RowIndex].Cells[1].Value.ToString();
            
            OpenPrescriptionEdit(mid, oPet, prescription_id);
            // MessageBox.Show(created.ToString());
            /*
            if (e.ColumnIndex == 6)
            {
                MessageBox.Show("change evidence to ... " + pid.ToString());
            }
            else
            {
                OpenProblemEdit(diangosis_id, P.Pid);
            }
            */
        }
    }
}
