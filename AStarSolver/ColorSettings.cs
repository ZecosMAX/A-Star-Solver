using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStarSolver
{
    public partial class ColorSettings : Form
    {
        public static Color PathColor   = Color.DarkCyan;
        public static Color StepColor   = Color.Purple;
        public static Color StartColor  = Color.Green;
        public static Color EndColor    = Color.Red;
        public static Color WallColor   = Color.Black;

        public ColorSettings()
        {
            InitializeComponent();

            this.pathColorPanel.BackColor = PathColor;
            this.stepColorPanel.BackColor = StepColor;
            this.startColorPanel.BackColor = StartColor;
            this.endColorPanel.BackColor = EndColor;
            this.wallColorPanel.BackColor = WallColor;

            this.pathColorPanel.Click += ColorPanel_Click;
            this.stepColorPanel.Click += ColorPanel_Click;
            this.startColorPanel.Click += ColorPanel_Click;
            this.endColorPanel.Click += ColorPanel_Click;
            this.wallColorPanel.Click += ColorPanel_Click;
        }

        public static void InitializeColors()
        {
            if(!Directory.Exists("Config/")) Directory.CreateDirectory("Config/");
            if(!File.Exists("Config/Colors.json"))
            {
                var fs = File.Create("Config/Colors.json");

                JObject colorsJson = JObject.Parse(
                    "{\n" +
                    "\"PathColor\":     \"#0000FF\",\n" +
                    "\"StepColor\":     \"#800080\",\n" +
                    "\"StartColor\":    \"#008000\",\n" +
                    "\"EndColor\":      \"#FF0000\",\n" +
                    "\"WallColor\":     \"#000000\",\n" +
                    "}");

                var bytes = Encoding.UTF8.GetBytes(colorsJson.ToString());

                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
            else
            {
                JObject colorsJson = JObject.Parse(File.ReadAllText("Config/Colors.json"));

                PathColor = ColorTranslator.FromHtml(colorsJson["PathColor"].ToString());
                StepColor = ColorTranslator.FromHtml(colorsJson["StepColor"].ToString());
                StartColor = ColorTranslator.FromHtml(colorsJson["StartColor"].ToString());
                EndColor = ColorTranslator.FromHtml(colorsJson["EndColor"].ToString());
                WallColor = ColorTranslator.FromHtml(colorsJson["WallColor"].ToString());
            }

        }

        private void WriteColors()
        {
            JObject colorsJson = JObject.Parse(
                    "{\n" +
                    $"\"PathColor\":     \"{ColorTranslator.ToHtml(PathColor)}\",\n" +
                    $"\"StepColor\":     \"{ColorTranslator.ToHtml(StepColor)}\",\n" +
                    $"\"StartColor\":    \"{ColorTranslator.ToHtml(StartColor)}\",\n" +
                    $"\"EndColor\":      \"{ColorTranslator.ToHtml(EndColor)}\",\n" +
                    $"\"WallColor\":     \"{ColorTranslator.ToHtml(WallColor)}\",\n" +
                    "}");

            File.WriteAllText("Config/Colors.json", colorsJson.ToString());
        }

        private void ColorPanel_Click(object sender, EventArgs e)
        {
            Panel Sender = sender as Panel;

            switch(Convert.ToInt32(Sender.Tag))
            {
                case 0:
                    colorDialog1.Color = PathColor;
                    break;
                case 1:
                    colorDialog1.Color = StepColor;
                    break;
                case 2:
                    colorDialog1.Color = StartColor;
                    break;
                case 3:
                    colorDialog1.Color = EndColor;
                    break;
                case 4:
                    colorDialog1.Color = WallColor;
                    break;
                default:
                    break;
            }

            colorDialog1.AllowFullOpen = true;
            colorDialog1.FullOpen = true;
            colorDialog1.ShowHelp = true;
            colorDialog1.ShowDialog();

            switch (Convert.ToInt32(Sender.Tag))
            {
                case 0:
                    PathColor = colorDialog1.Color;
                    break;
                case 1:
                    StepColor = colorDialog1.Color;
                    break;
                case 2:
                    StartColor = colorDialog1.Color;
                    break;
                case 3:
                    EndColor = colorDialog1.Color;
                    break;
                case 4:
                    WallColor = colorDialog1.Color;
                    break;
                default:
                    break;
            }

            this.pathColorPanel.BackColor = PathColor;
            this.stepColorPanel.BackColor = StepColor;
            this.startColorPanel.BackColor = StartColor;
            this.endColorPanel.BackColor = EndColor;
            this.wallColorPanel.BackColor = WallColor;

            WriteColors();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
