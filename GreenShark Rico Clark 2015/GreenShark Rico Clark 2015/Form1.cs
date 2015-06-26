using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenShark_Rico_Clark_2015
{
    public partial class GreenShark : Form
    {
        public GreenShark()
        {
            InitializeComponent();
            tcMissiontabs.DrawItem += new DrawItemEventHandler(tcMissiontabs_DrawItem);
            LoadAllTemplates();
        }

        private void LoadAllTemplates()
        {
            foreach (MissionProfile mp in Administration.Administration_.LoadAllTemplates())
            {
                cbMissiontype.Items.Add(mp);
            }
        }

        private void GreenShark_Load(object sender, EventArgs e)
        {
            
        }

        private void tcMissiontabs_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush b;
            TabPage page = tcMissiontabs.TabPages[e.Index];
            Rectangle bounds = tcMissiontabs.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                b = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                b = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            Font font = new Font("Microsoft Sans Serif", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);
            StringFormat flags = new StringFormat();
            flags.Alignment = StringAlignment.Center;
            flags.LineAlignment = StringAlignment.Center;
            g.DrawString(page.Text, font, b, bounds, new StringFormat(flags));

            //Code van msdn voor verticale tabbladen

        }

        private void cbMissiontype_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbMissiontype.SelectedItem.ToString() == "HOPE")
            {
                lblEnddate.Visible = true;
                tbEnddate.Visible = true;
            }
            else
            {
                lblEnddate.Visible = false;
                tbEnddate.Visible = false;
            }
        }

        private void btLoadMission_Click(object sender, EventArgs e)
        {
            btSaveMission.Visible = true;
            btDeleteMission.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btSaveMission_Click(object sender, EventArgs e)
        {
            btSaveMission.Visible = false;
            btDeleteMission.Visible = false;
        }

        private void btDeleteMission_Click(object sender, EventArgs e)
        {
            btSaveMission.Visible = false;
            btDeleteMission.Visible = false;
        }

        private void btLoadReportM_Click(object sender, EventArgs e)
        {
            btSaveReportM.Visible = true;
            btRemoveReportM.Visible = true;
        }

        private void btSaveReportM_Click(object sender, EventArgs e)
        {
            btSaveReportM.Visible = false;
            btRemoveReportM.Visible = false;
        }

        private void btRemoveReportM_Click(object sender, EventArgs e)
        {
            btSaveReportM.Visible = false;
            btRemoveReportM.Visible = false;
        }

        private void btLoadReportI_Click(object sender, EventArgs e)
        {
            btSaveReportI.Visible = true;
            btRemoveReportI.Visible = true;
        }

        private void btSaveReportI_Click(object sender, EventArgs e)
        {
            btSaveReportI.Visible = false;
            btRemoveReportI.Visible = false;
        }

        private void btRemoveReportI_Click(object sender, EventArgs e)
        {
            btSaveReportI.Visible = false;
            btRemoveReportI.Visible = false;
        }
    }
}
