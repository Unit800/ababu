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
        public Visit V { get; set; }
        public int Pid { get; set; }

        public CtrlVisit(int pid = 0)
        {
            InitializeComponent();
            V = new Visit();

            if(pid > 0)
            {
                Pid = pid;
            }
        }

        private void CtrlVisits_Load(object sender, EventArgs e)
        {
            LoadVisitList();
        }

        private void LoadVisitList()
        {
            // DataTable VisitList = Visit.GetVisitsList();

            /*
            DataTable VisitList = Visit.GetVisitListByPid(Pid);

            foreach(DataRow row in VisitList.Rows)
            {
                Visit v = new Visit((int)row[0]);
                CtrlVisitListItem ctrlVisitListItem = new CtrlVisitListItem(v);
            
                ctrlVisitListItem.OnVisitSelection += new EventHandler<VisitEventArgs>(LoadVisit);
            }
            */

            CtrlProblems ctrlProblems = new CtrlProblems();
            ctrlProblems.Dock = DockStyle.Fill;


            TlpVisitBody.Controls.Add(ctrlProblems, 0, 0);



        }

        public void LoadVisit(object sender, VisitEventArgs e)
        {
        }
    }
}
