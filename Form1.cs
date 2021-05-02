using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FigureConstructor
{
    public partial class Form1 : Form
    {
        private List<int[]> coords = new List<int[]>();
        private List<int[]> FCoords = new List<int[]>();
        private List<string> FigureColors = new List<string>();
        int Active = 0;
        public int count = 0;
        public Form1()
        {
            InitializeComponent();
            string[] nm = Enum.GetNames(typeof(KnownColor));
            foreach (string item in nm)
            {
                SelectBox.Items.Add(item);
            }
        }
        private void CanUse(bool can)
        {
            AddFigure.Enabled = can;
            RemoveFigure.Enabled = can;
            saveFile.Enabled = can;
            canvas.Enabled = can;
            FigureList.Enabled = can;
            loadFile.Enabled = !can;
            SelectBox.Enabled = can;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CanUse(false);
        }

        private void canvas_Click(object sender, MouseEventArgs e)
        {
            int Xclick = canvas.PointToClient(Cursor.Position).X;
            int Yclick = canvas.PointToClient(Cursor.Position).Y;
            if(e.Button == MouseButtons.Left)
            {
                   AddToCanv(Xclick,Yclick);

            }
        }
        private void AddToCanv(int Xclick, int Yclick)
        {
            PictureBox pic = new PictureBox();
            pic.BackColor = Color.FromName(FigureColors[Active]);
            pic.Size = new Size(59, 59);
            pic.Location = new Point(Xclick / 60 * 60, Yclick / 60 * 60);
            pic.MouseClick += pictureBox1_MouseClick;
            for (int i = 0; i < coords.Count(); i++)
            {
                if (coords[i][0] == pic.Location.X && coords[i][1] == pic.Location.Y)
                {
                    return;
                }
            }
            canvas.Controls.Add(pic);
            int[] toadd = { pic.Location.X, pic.Location.Y };
            coords.Add(toadd);
            count = coords.Count();
            AutoSave();
        }
        private void RemoveFromCanv(int Xclick,int Yclick)
        {
            for (int i = 0; i < coords.Count; i++)
            {
                if (Xclick/60*60 == coords[i][0] && Yclick/60*60 == coords[i][1] && FCoords[Active].Length >= 2)
                {
                    canvas.Controls.RemoveAt(i);
                    int[] addedThis = new int[coords[i].Length-2];
                    coords.RemoveAt(i);
                    AutoSave();
                    return;
                }
            }
            
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            for (int i = 1; i < 6; i++)
            {
                e.Graphics.DrawLine(pen, 60*i, 0, 60*i, 360);
                e.Graphics.DrawLine(pen, 0, 60*i, 360, 60 * i);
            }
        }
        private void LoadFigures()
        {
            if (!File.Exists("figures.fc"))
            {
                ErrorLoad("File Not exists");
                return;
            }
            List<string> data = new List<string>();
            data = File.ReadLines("figures.fc").ToList();
            List<string> GetColor = new List<string>();
            List<int[]> FiguresCoords = new List<int[]>();
            for (int i = 0; i < data.Count(); i++)
            {
                string[] addition = data[i].Split(new char[] { '/' });
                if (addition.Length != 2)
                {
                    ErrorLoad("length not equals 2");
                    return;
                }
                GetColor.Add(addition[0]);

                string[] crds = addition[1].Split(new char[] { ';' });
                int[] cords = new int[crds.Length];
                for (int t = 0; t < crds.Length; t++)
                {
                    try
                    {
                        cords[t] = int.Parse(crds[t]);
                    }
                    catch (Exception)
                    {

                        ErrorLoad("not int coords");
                        return;
                    }
                }

                FiguresCoords.Add(cords);

            }

            for (int i = 0; i < FiguresCoords.Count(); i++)
            {
                if (FiguresCoords[i].Length % 2 != 0)
                {
                    ErrorLoad("Some coords is not pair. this %2 != 0");
                    return;
                }
                if (FiguresCoords[i].Length > 36*2)
                {
                    ErrorLoad("Too many objects");
                    return;
                }
            }
            for (int i = 0; i < FiguresCoords.Count(); i++)
            {
                for (int q = 0; q < FiguresCoords[i].Length; q += 2)
                {
                    if (FiguresCoords[i][q] % 30 != 0 || FiguresCoords[i][q] < 60 || FiguresCoords[i][q] > 210)
                    {
                        ErrorLoad("Xcoord can't multiply of base size");
                        return;
                    }
                }
                for (int q = 1; q < FiguresCoords[i].Length; q += 2)
                {
                    if (FiguresCoords[i][q] > 150 || FiguresCoords[i][q] < 0)
                    {
                        ErrorLoad("Ycoord is not in range");
                        return;
                    }
                }
            }
            string[] ColorTypes = Enum.GetNames(typeof(KnownColor));
            for (int i = 0; i < GetColor.Count(); i++)
            {
                bool truly = false;
                for (int q = 0; q < ColorTypes.Length; q++)
                {

                    if (GetColor[i] == ColorTypes[q])
                    {
                        truly = true;
                        break;
                    }
                }
                if (!truly)
                {
                    ErrorLoad("Color is not exist");
                    return;
                }
            }
            FCoords = FiguresCoords;
            FigureColors = GetColor;
            MessageBox.Show("Success");
        }
        public void ErrorLoad(string text)
        {
            MessageBox.Show("File corrupted \n Error: " + text);
        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            FCoords.Clear();
            coords.Clear();
            FigureColors.Clear();
            for (int i = 0; i < FigureList.Items.Count; i++)
            {
                FigureList.SelectedIndexChanged -= FigureList_SelectedIndexChanged;
                FigureList.Items.RemoveAt(i);
                FigureList.SelectedIndexChanged += FigureList_SelectedIndexChanged;
            }
            LoadFigures();
            LoadToList();
            CanUse(true);
        }
        private void LoadToList()
        {
            for (int i = 0; i < FCoords.Count(); i++)
            {
                FigureList.SelectedIndexChanged += FigureList_SelectedIndexChanged;
                FigureList.Items.Add(i);
                FigureList.SelectedIndexChanged -= FigureList_SelectedIndexChanged;
            }
            if (coords.Count != 0)
            {
                FigureList.SelectedIndexChanged += FigureList_SelectedIndexChanged;
                FigureList.SetSelected(0, true);
                FigureList.SelectedIndexChanged -= FigureList_SelectedIndexChanged;
            }
        }
        private void newFile_Click(object sender, EventArgs e)
        {
            var f = File.Create("figures.fc");
            f.Close();
            MessageBox.Show("Success");
            CanUse(true);
        }

        private void FigureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            coords.Clear();
            Active = FigureList.SelectedIndex;
            canvas.Controls.Clear();
            for (int i = 0; i < FCoords[Active].Length/2; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.FromName(FigureColors[Active]);
                pic.Size = new Size(59, 59);
                pic.Location = new Point((FCoords[Active][2 * i]-60)*2, FCoords[Active][2*i+1]*2);
                pic.MouseClick += pictureBox1_MouseClick;
                int[] toadd = { (FCoords[Active][2 * i] - 60)*2, FCoords[Active][(2 * i) + 1] * 2 };
                coords.Add(toadd);
                canvas.Controls.Add(pic);
            }
            for (int i = 0; i < SelectBox.Items.Count; i++)
            {
                if (SelectBox.Items[i].ToString() == FigureColors[Active])
                {
                    SelectBox.SelectedIndex = i;
                }
            }
        }
        private void FigureList_SelectedIndexChanged()
        {
            FigureColors[Active] = SelectBox.Text;
            coords.Clear();
            Active = FigureList.SelectedIndex;
            canvas.Controls.Clear();
            for (int i = 0; i < FCoords[Active].Length / 2; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.FromName(FigureColors[Active]);
                pic.Size = new Size(59, 59);
                pic.Location = new Point((FCoords[Active][2 * i] - 60) * 2, FCoords[Active][2 * i + 1] * 2);
                pic.MouseClick += pictureBox1_MouseClick;
                int[] toadd = { (FCoords[Active][2 * i] - 60) * 2, FCoords[Active][(2 * i) + 1] * 2 };
                coords.Add(toadd);
                canvas.Controls.Add(pic);
            }
        }
        private void AddFigure_Click(object sender, EventArgs e)
        {
            FigureList.Items.Add(FigureList.Items.Count);
            List<int> empty = new List<int>();
            FCoords.Add(empty.ToArray());
            FigureColors.Add("Blue");
        }

        private void RemoveFigure_Click(object sender, EventArgs e)
        {
            FigureList.SelectedIndexChanged -= FigureList_SelectedIndexChanged;
            FigureList.Items.RemoveAt(Active);
            FigureList.SelectedIndexChanged += FigureList_SelectedIndexChanged;
            FCoords.RemoveAt(Active);
            FigureColors.RemoveAt(Active);

            Active = 0;
        }
        private void AutoSave()
        {
            if (FCoords.Count == 0)
            {
                MessageBox.Show("No Figures");
                return;
            }
            int[] add = new int[coords.Count() * 2];
            for (int i = 0; i < coords.Count(); i++)
            {
                add[2 * i] = coords[i][0] / 2 + 60;
                add[(2 * i) + 1] = coords[i][1] / 2;
            }
            FCoords[Active] = add;
            FigureColors[Active] = SelectBox.Text;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int Xclick = canvas.PointToClient(Cursor.Position).X;
            int Yclick = canvas.PointToClient(Cursor.Position).Y;
            if (e.Button == MouseButtons.Right)
            {
                RemoveFromCanv(Xclick, Yclick);
            }
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            string[] toAdd = new string[FCoords.Count];
            for (int i = 0; i < FCoords.Count(); i++)
            {
                toAdd[i] = FigureColors[i] + "/";
                for (int q = 0; q < FCoords[i].Length; q++)
                {
                    toAdd[i] += FCoords[i][q] + ";";
                }
                string withoutLast = toAdd[i].Substring(0, (toAdd[i].Length - 1));
                toAdd[i] = withoutLast;
            }
                File.WriteAllLines("figures.fc",toAdd);
            MessageBox.Show("Success");
        }

        private void SelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FigureList_SelectedIndexChanged();
        }
    }
}
