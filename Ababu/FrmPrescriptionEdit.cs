﻿using OldAuntie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ababu
{
    public partial class FrmPrescriptionEdit : Form
    {
        public Pet oPet { get; set; }
        public Problem Problem { get; set; }
        public Medicine Medicine { get; set; }
        public Prescription Prescription { get; set; }

        private bool IsModified = false;

        public FrmPrescriptionEdit(int prescription_id = 0)
        {
            Prescription = new Prescription(prescription_id);
            InitializeComponent();
        }

        

        private void FrmPrescriptionEdit_Load(object sender, EventArgs e)
        {
            FillForm();

            AddOnChangeHandlerToInputControls(this);
        }

        void AddOnChangeHandlerToInputControls(Control ctrl)
        {
            foreach (Control subctrl in ctrl.Controls)
            {
                if (subctrl is TextBox)
                {
                    ((TextBox)subctrl).TextChanged += new EventHandler(InputControls_OnChange);
                }
                else if (subctrl is CheckBox)
                {
                    ((CheckBox)subctrl).CheckedChanged += new EventHandler(InputControls_OnChange);
                }
                else if (subctrl is RadioButton)
                {
                    ((RadioButton)subctrl).CheckedChanged += new EventHandler(InputControls_OnChange);
                }
                else if (subctrl is ListBox)
                {
                    ((ListBox)subctrl).SelectedIndexChanged += new EventHandler(InputControls_OnChange);
                }
                else if (subctrl is ComboBox)
                {
                    ((ComboBox)subctrl).SelectedIndexChanged += new EventHandler(InputControls_OnChange);

                }
                else
                {
                    if (subctrl.Controls.Count > 0)
                    {
                        this.AddOnChangeHandlerToInputControls(subctrl);
                    }

                }
            }
        }


        void InputControls_OnChange(object sender, EventArgs e)
        {
            IsModified = true;
            PicIsModified.Image = Properties.Resources.bullet_red;
        }


        private void LockForm()
        {
            GrbPrescription.Enabled = false;

            BtnPrescriptionSave.Enabled = false;
            BtnPrescriptionDelete.Enabled = false;
            BtnPrescriptionPrint.Enabled = false;
            /*
            BtnPrescriptionSave.Enabled = false;
            TxtQuantity.Enabled = false;
            TxtDosage.Enabled = false;
            ChkInEvidence.Enabled = false;
            */
        }


        private void FillForm()
        {
            TxtMedicine.Text = Medicine.Name;

            DtpCreated.Value = Utility.IfNull(Prescription.Created, DateTime.Now);
            TxtQuantity.Text = Prescription.Quantity.ToString();
            TxtDosage.Text = Prescription.Dosage;
            ChkInEvidence.Checked = Prescription.InEvidence;

            // fill the problem combo
            // @todo: add an unlink option
            CmbProblems.DataSource = Problem.GetProblemsByPid(oPet.Pid); ;
            CmbProblems.ValueMember = "diagnosis_id";
            CmbProblems.DisplayMember = "term_name";
            CmbProblems.SelectedValue = Prescription.DiagnosisId;

            TxtMid.Text = Medicine.Mid;
            TxtMedicineName.Text = Medicine.Name;
            TxtMedicineCompany.Text = Medicine.Company;
            TxtMedicineDateOfIssue.Text = Medicine.DateOfIssue.ToShortDateString();
            TxtMedicineDateOfWithDrawal.Text = Medicine.DateOfWithDrawal.ToString();
            TxtMedicinePharmaceuticalForm.Text = Medicine.PharmaceuticalForm;
            TxtMedicineAdditionalForm.Text = Medicine.AdditionalInfo;

            // avoid to delete or print a recod that not exists
            if (Prescription.Exists() == false)
            {
                BtnPrescriptionDelete.Enabled = false;
                BtnPrescriptionPrint.Enabled = false;
            }

            // check if Medicine is still available on the market to avoid modification
            if (Medicine.DateOfWithDrawal > DateTime.MinValue)
            {
                LockForm();
            }


        }

        private void BtnPrescriptionSave_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                Prescription.Created = DtpCreated.Value;
                Prescription.Mid = Medicine.Mid;
                Prescription.Pid = oPet.Pid;
                Prescription.Quantity = Convert.ToInt32(TxtQuantity.Text);
                Prescription.Dosage = TxtDosage.Text;
                Prescription.InEvidence = ChkInEvidence.Checked;
                Prescription.DiagnosisId = Problem.DiagnosisId;

                try
                {
                    // save the problem
                    int affected_row = Prescription.Save();
                    if (affected_row > 0)
                    {
                        IsModified = false;
                        PicIsModified.Image = Properties.Resources.bullet_green;
                        this.Close();
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Globals.log.Write(ex.ToString());
                }
            }
        }



        private bool IsValidForm()
        {
            bool result = true;
            ErrPrescriptionEdit.Clear();

            if (TxtQuantity.Text.Trim() == string.Empty)
            {
                result = result & false;
                ErrPrescriptionEdit.SetError(TxtQuantity, "Quantity cannot be empty");
            }

            if (TxtDosage.Text.Trim() == string.Empty)
            {
                result = result & false;
                ErrPrescriptionEdit.SetError(TxtDosage, "Dosage cannot be empty");
            }

            return result;
        }


        private void TxtMedicineQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        private void FrmPrescriptionEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsModified == true)
            {
                DialogResult result = MessageBox.Show("Form has been modified. Would you like to discard changes ?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    //code for No
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void BtnPrescriptionDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete selected prescription (operation cannot be undone) ?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int affected_rows = Prescription.Delete();

                if (affected_rows > 0)
                {
                    this.Close();
                    this.Dispose();
                }
            }
        }

        private void ChkLockProblemCombo_CheckedChanged(object sender, EventArgs e)
        {
            // enable tha combo...
            CmbProblems.Enabled = ChkLockProblemCombo.Checked;
            // ...and change the button icon
            if (ChkLockProblemCombo.Checked == true)
            {
                ChkLockProblemCombo.Image = Properties.Resources.lock_open;
            }
            else
            {
                ChkLockProblemCombo.Image = Properties.Resources.lock_closed;
            }
        }
    }
}
