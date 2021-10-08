using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeeApp
{
    public partial class Form1 : Form
    {
        //Define
        List<Bee> beeList = new List<Bee>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    beeList.Add(new Bee() { Name = string.Format("{0} - {1}", "Queen", i), IsQueen = true });
                    beeList.Add(new Bee() { Name = string.Format("{0} - {1}", "Worker", i), IsWorker = true });
                    beeList.Add(new Bee() { Name = string.Format("{0} - {1}", "Drone", i), IsDrone = true });
                }

                //Iitial location
                Point labelNameLoc = new Point(5, 5);
                Point buttonLoc = new Point(150, 5);
                Point labelHealthLoc = new Point(100, 5);

                for (int i = 0; i < beeList.Count; i++)
                {
                    //Initialize
                    Button button = new Button();
                    Label labelName = new Label();
                    Label labelHealth = new Label();

                    //Id's
                    button.Name = i.ToString();
                    labelHealth.Name = "labelHealth" + i.ToString();
                    labelName.Name = "labelName" + i.ToString();

                    //Set Name
                    labelName.Text = beeList[i].Name;
                    button.Text = "Damage";
                    labelHealth.Text = Convert.ToString(beeList[i].HealthStatus());

                    //Colour
                    labelName.ForeColor = Color.Green;

                    //Size
                    button.Size = new Size(65, 20);
                    labelName.Size = new Size(65, 20);

                    //Event
                    button.Click += new EventHandler(btnClick);

                    //Location
                    labelName.Location = labelNameLoc;
                    button.Location = buttonLoc;
                    labelHealth.Location = labelHealthLoc;

                    //Update Location
                    labelNameLoc.Offset(0, labelNameLoc.X + 20);
                    buttonLoc.Offset(0, button.Height + 5);
                    labelHealthLoc.Offset(0, labelNameLoc.X + 20);

                    //Add to the panel
                    panel1.Controls.Add(labelName);
                    panel1.Controls.Add(button);
                    panel1.Controls.Add(labelHealth);
                }
            }
            catch(Exception ex)
            {
                throw ex; //Can be logged in a file
            }
        }

        private void btnClick(object sender, EventArgs e)
        {
            try
            {
                //Initialize
                Button dynamicButton = (sender as Button);
                Random r = new Random();
                int index = 0;

                int.TryParse(dynamicButton.Name, out index);

                //Find Labels
                Label lHealth = Controls.Find("labelHealth" + index.ToString(), true)[0] as Label;
                Label lName = Controls.Find("labelName" + index.ToString(), true)[0] as Label;

                //Update health
                int rInt = r.Next(0, 80);
                beeList[index].Damage(rInt);

                //Update UI
                lHealth.Text = Convert.ToString(beeList[index].HealthStatus());
                lName.ForeColor = beeList[index].IsAlive() ? Color.Green : Color.Red;
            }
            catch(Exception ex)
            {
                throw ex; //Can be logged in a file
            }
        }
    }
}
