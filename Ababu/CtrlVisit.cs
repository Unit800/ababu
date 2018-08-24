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

namespace Ababu
{
    public partial class CtrlVisit : UserControl
    {
        public int Pid { get; set; }
        public Pet P { get; set; }





        public CtrlVisit(Pet pet = null)
        {
            InitializeComponent();

            if(pet != null)
            {
                P = pet;
            }
        }

        private void CtrlVisits_Load(object sender, EventArgs e)
        {
            LoadVisitComponents();
        }

        private void LoadVisitComponents()
        {
            // loading Problem section passing Pet to the user cotrol
            CtrlProblem ctrlProblems = new CtrlProblem(P);
            ctrlProblems.Dock = DockStyle.Fill;
            TlpVisitBody.Controls.Add(ctrlProblems, 0, 0);

            // loading Diary
            CtrlDiary ctrlDiary = new CtrlDiary(P);
            ctrlDiary.Dock = DockStyle.Fill;
            TlpVisitBody.Controls.Add(ctrlDiary, 0, 1);


            CtrlTherapy ctrlTherapy = new CtrlTherapy();
            ctrlTherapy.Dock = DockStyle.Fill;
            TlpVisitBody.Controls.Add(ctrlTherapy, 1, 0);


            CtrlExamination ctrlExamination = new CtrlExamination();
            ctrlExamination.Dock = DockStyle.Fill;
            TlpVisitBody.Controls.Add(ctrlExamination, 1, 1);

        }

    }
}
