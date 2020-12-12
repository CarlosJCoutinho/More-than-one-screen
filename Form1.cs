using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace More_than_one_screen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // For each screen, add the screen properties to a list box.
            int i = 0;
            foreach (var screen in System.Windows.Forms.Screen.AllScreens)
            {
                listBox1.Items.Add("Device Name: " + screen.DeviceName);
                listBox1.Items.Add("Bounds: " +
                    screen.Bounds.ToString());
                listBox1.Items.Add("Type: " +
                    screen.GetType().ToString());
                listBox1.Items.Add("Working Area: " +
                    screen.WorkingArea.ToString());
                listBox1.Items.Add("Primary Screen: " +
                    screen.Primary.ToString());
                i++;
            }
            textBox1.Text = i.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MatrixView n = new MatrixView();
            Screen[] screens = Screen.AllScreens;
            textBox2.Text = screens.Length.ToString();
            if (screens.Length > 1)
            {
                setFormLocation(n, screens[1]);
            }
            else
            {
                setFormLocation(n, screens[0]);
            }
            n.Show();
        }

        private void setFormLocation(Form form, Screen screen)
        {
            // first method
            // Rectangle bounds = screen.Bounds;
            // form.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);

            // second method
            Point location = screen.Bounds.Location;
            Size size = screen.Bounds.Size;

            form.Left = location.X;
            form.Top = location.Y;
            form.Width = size.Width;
            form.Height = size.Height;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
