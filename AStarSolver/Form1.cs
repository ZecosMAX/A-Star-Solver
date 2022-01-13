using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStarSolver
{
    public partial class Form1 : Form
    {
		private int res = 30;
		private Graphics graphics;

		private Point start, end;
		private List<Point> walls = new List<Point>();

		private Solver solver;

		public Form1()
		{
			InitializeComponent();

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			graphics = Graphics.FromImage(pictureBox1.Image);
			graphics.FillRectangle(Brushes.White, new Rectangle(Point.Empty, pictureBox1.Size));

			ColorSettings.InitializeColors();

			DrawGrid(graphics, GridSizeSettings.GridWidth, GridSizeSettings.GridHeight);
		}

		#region Internal methods

		private void DrawGrid(Graphics graphics, int linesX, int linesY)
		{
			for (int i = 0; i < linesX; i++)
			{
				graphics.DrawLine(Pens.Black,
					((float)i + 1) * pictureBox1.Width / linesX,
					0,
					((float)i + 1) * pictureBox1.Width / linesX,
					pictureBox1.Height
					);
				
			}
			
			for (int i = 0; i < linesY; i++)
			{
				graphics.DrawLine(Pens.Black,
					0,
					((float)i + 1) * pictureBox1.Height / linesY,
					pictureBox1.Width,
					((float)i + 1) * pictureBox1.Height / linesY
					);

			}

		}

		private void DrawPixel(Graphics graphics, Brush b, int x, int y)
		{
			graphics.FillRectangle(b,
				(float)x * pictureBox1.Width / GridSizeSettings.GridWidth,
				(float)y * pictureBox1.Height / GridSizeSettings.GridHeight,
				(float)pictureBox1.Width / GridSizeSettings.GridWidth,
				(float)pictureBox1.Height / GridSizeSettings.GridHeight
				);
			pictureBox1.Refresh();
		}

		private void ClearPixel(Graphics graphics, int x, int y)
        {
			DrawPixel(graphics, new SolidBrush(Color.White), x, y);
			DrawGrid(graphics, GridSizeSettings.GridWidth, GridSizeSettings.GridHeight);
        }

		private void ClearPath(Graphics graphics)
		{
            Clear(graphics);
			DrawGrid(graphics, GridSizeSettings.GridWidth, GridSizeSettings.GridHeight);
            foreach (var wall in walls)
            {
				DrawPixel(
					graphics, 
					new SolidBrush(ColorSettings.WallColor), 
					wall.X,
					wall.Y);
			}

			DrawPixel(
					graphics,
					new SolidBrush(ColorSettings.StartColor),
					start.X,
					start.Y);

			DrawPixel(
					graphics,
					new SolidBrush(ColorSettings.EndColor),
					end.X,
					end.Y);
		}

		private void Clear(Graphics graphics)
        {
			graphics.Clear(Color.White);
			//pictureBox1.Refresh();
		}

		#endregion

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			Point point = new Point(
				GridSizeSettings.GridWidth * e.X / pictureBox1.Width,
				GridSizeSettings.GridHeight * e.Y / pictureBox1.Height);

			this.Text = point.ToString() + $", Задежка шага = {trackBar1.Value}мс";
			HandleMouse(e);
		}
		private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			HandleMouse(e);
		}

		private void HandleMouse(MouseEventArgs e)
        {
			Point point = new Point(
				GridSizeSettings.GridWidth * e.X / pictureBox1.Width,
				GridSizeSettings.GridHeight * e.Y / pictureBox1.Height);

			if (e.Button == MouseButtons.Left)
			{
				if (walls.Where((p) => { return (p.X == (point.X)) && (p.Y == (point.Y)); }).Count() == 0)
				{
					DrawPixel(graphics, new SolidBrush(ColorSettings.WallColor), point.X, point.Y);
					walls.Add(point);
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				if(start != default) ClearPixel(graphics, start.X, start.Y);

				DrawPixel(graphics, new SolidBrush(ColorSettings.StartColor), point.X, point.Y);
				start = point;
			}
			else if (e.Button == MouseButtons.Middle)
			{
				if (end != default) ClearPixel(graphics, end.X, end.Y);

				DrawPixel(graphics, new SolidBrush(ColorSettings.EndColor), point.X, point.Y);
				end = point;
			}
		}

        private void цветаToolStripMenuItem_Click(object sender, EventArgs e)
        {
			ColorSettings colorSettings = new ColorSettings();
			colorSettings.ShowDialog();
        }

        private void размерПоляToolStripMenuItem_Click(object sender, EventArgs e)
        {
			GridSizeSettings gridSizeSettings = new GridSizeSettings();
			gridSizeSettings.ShowDialog();

			start = default;
			end = default;
			walls = new List<Point>();

			Clear(graphics);
			DrawGrid(graphics, GridSizeSettings.GridWidth, GridSizeSettings.GridHeight);
			pictureBox1.Refresh();
		}

        private void очиститьПолеToolStripMenuItem_Click(object sender, EventArgs e)
        {
			start = default;
			end = default;
			walls = new List<Point>();

			Clear(graphics);
			DrawGrid(graphics, GridSizeSettings.GridWidth, GridSizeSettings.GridHeight);
			pictureBox1.Refresh();
		}

        private void управлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
			new ContolsForm().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
		{
			ClearPath(graphics);

			solver = new Solver(start, end, walls.ToArray(), 100);

			solver.DrawSteps = отрисовыватьШагиToolStripMenuItem.Checked;

			solver.DrawStepsCallback = (x, y, o, c) => {
				this.BeginInvoke(new Action(() =>
				{
					Color color = Color.FromArgb(
						(byte)(o * 255.0),
						ColorSettings.StepColor
					);
					DrawPixel(graphics, new SolidBrush(color), x, y);
				}));

				if(trackBar1.Value > 0 && solver.DrawSteps)
					Thread.Sleep(trackBar1.Value);
			};

			solver.DrawPathCallback = (x, y, c) =>
			{
				this.BeginInvoke(new Action(() =>
				{
					DrawPixel(graphics, new SolidBrush(ColorSettings.PathColor), x, y);
				}));
			};



			Task.Factory.StartNew(() =>
			{
				solver.Solve();
			});
		}
	}
}
