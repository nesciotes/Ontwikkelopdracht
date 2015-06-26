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

            //Het aanmaken van de 3 boot types om te gebruiken bij het aanmaken van missies
            cbBoattype.Items.Add(new Boat("Klein", 50, 4));
            cbBoattype.Items.Add(new Boat("Middel", 45, 8));
            cbBoattype.Items.Add(new Boat("Groot", 32, 15));

            foreach (MissionProfile mp in Administration.Administration_.profiles)
            {
                cbProfile.Items.Add(mp);
            }

            //LoadAllTemplates();
            Unittest_Distance();
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
            //Wanneer er een naam ingevuld is en er wordt op Laad gedrukt wordt de betreffende missie ingeladen en de informatie getoond in de textboxes
            btSaveMission.Visible = true;
            btDeleteMission.Visible = true;
            SIN mission = Administration.Administration_.LoadMission(tbName.Text);
            tbDate.Text = Convert.ToString(mission.startdate);
            tbX.Text = Convert.ToString(mission.location.X);
            tbY.Text = Convert.ToString(mission.location.Y);
            tbDescription.Text = mission.description;
        }

        private void cbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cbProfile.SelectedItem.)
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

        private void btCreateMission_Click(object sender, EventArgs e)
        {
            //Bij het aanmaken van een missie sturen we de waarden van de textboxes door en creëren we een object
            if (cbMissiontype.Text == "SIN")
            {
                Administration.Administration_.AddMission(
                    new SIN(
                        Convert.ToDateTime(tbDate),
                        new Point(Convert.ToInt32(tbX.Text),
                            Convert.ToInt32(tbY.Text)),
                        tbDescription.Text,
                        true,
                        "Missie"));
            }
        }

        public void Unittest_Distance()
        {
            Mission mission = new SIN(100, 100);
            List<Boat> boats = new List<Boat>();

            boats.Add(new Boat(500, 120));
            boats.Add(new Boat(400, 50));
            boats.Add(new Boat(90, 70));

            //Deze is het dichtst bij
            boats.Add(new Boat(100, 110));

            boats.Add(new Boat(400, 50));

            //Als het algoritme klopt zou de messagebox moeten weergeven "X=100, Y=110" en is de unittest geslaagd
            Boat nearestboat = Administration.Administration_.Nearestboat(boats, mission);
            MessageBox.Show(Convert.ToString(nearestboat.location));

        }
    }
}
