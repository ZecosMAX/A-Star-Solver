using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStarSolver
{
	class Solver
	{
		private Point start, end;
		private Point[] walls;

		private List<Point> open = new List<Point>();
		private List<Point> closed = new List<Point>();

		private int ms;

		private List<List<Point>> Paths = new List<List<Point>>();


		public bool DrawSteps { get; set; }
		public Color StepsColor { get; set; } = Color.Purple;
		public Color PathColor { get; set; } = Color.LightBlue;
		public Action<int, int, float, Color> DrawStepsCallback { get; set; }
		public Action<int, int, Color> DrawPathCallback { get; set; }

		public Solver(Point start, Point end, Point[] walls, int awaiter)
		{
			this.start = start;
			this.end = end;
			this.walls = walls;
			this.ms = awaiter;
		}

		public void Solve()
		{
			List<Point> FP = new List<Point>();
			FP.Add(start);
			open.Add(start);
			Paths.Add(FP);

            #region | initialization |

			float Distance = Heuristic(start, end);

            #endregion

            bool solved = false;

			while (!solved)
			{

				List<float> fValues = new List<float>();

				int pathsCount = Paths.Count;
				for (int i = 0; i < pathsCount; i++)
				{
					var Path = Paths[i]; // For Each Path
					var LastPoint = Path.Last(); // Take last point

					//find it's f-value
					float fValue = Path.Count + Heuristic(LastPoint, end);

					// record it
					fValues.Add(fValue);
				}

				// Find to what path belongs point with minimal f-value
				int minIndex = fValues.IndexOf(fValues.Min());

				// Take it's last point
				var MinLastPoint = Paths[minIndex].Last();

				// Do steps from this on
				for (int x = -1; x <= 1; x++)
				{
					for (int y = -1; y <= 1; y++)
					{
						// check if point is in boundaries, otherwise skip
						if (
							(MinLastPoint.X + x) < 0 || (MinLastPoint.X + x) >= GridSizeSettings.GridWidth ||
							(MinLastPoint.Y + y) < 0 || (MinLastPoint.Y + y) >= GridSizeSettings.GridHeight
							) continue;

						if (
							closed.Where((p) => { return (p.X == (MinLastPoint.X + x)) && (p.Y == (MinLastPoint.Y + y)); }).Count() == 0
							&&
							open.Where((p) => { return (p.X == (MinLastPoint.X + x)) && (p.Y == (MinLastPoint.Y + y)); }).Count() == 0
							&&
							walls.Where((p) => { return (p.X == (MinLastPoint.X + x)) && (p.Y == (MinLastPoint.Y + y)); }).Count() == 0
						)
						{
							List<Point> Path = new List<Point>(Paths[minIndex]);
							Path.Add(new Point(MinLastPoint.X + x, MinLastPoint.Y + y));
							open.Add(new Point(MinLastPoint.X + x, MinLastPoint.Y + y));
							Paths.Add(Path);

						}
					}
				}
				
				if(!MinLastPoint.Equals(start) && !MinLastPoint.Equals(end))
                {
					if (DrawSteps)
					{
						try
						{
							var thisDistance = Heuristic(MinLastPoint, end);

							DrawStepsCallback.Invoke(
								MinLastPoint.X, 
								MinLastPoint.Y,
								1.0f - 0.8f * Clamp(thisDistance / Distance, 0.0f, 1.0f),
								StepsColor);
						}
						catch
                        {

                        }
					}
				}

				if (MinLastPoint.Equals(end))
				{
					solved = true;

                    for (int i = 1; i < Paths[minIndex].Count - 1; i++)
                    {
                        Point point = Paths[minIndex][i];
                        try
						{
							DrawPathCallback.Invoke(
									point.X,
									point.Y,
									PathColor);
						}
						catch
                        {

                        }
					}
				}

				//Delete this path as it now ends on closed point
				Paths.RemoveAt(minIndex);

				// Then add this point to closed
				closed.Add(MinLastPoint);
				open.Remove(MinLastPoint);

			}
		}

		private float Clamp(float value, float minimum, float maxmimum)
        {
			float t = value < minimum ? minimum : value;
			return t > maxmimum ? maxmimum : t;
		}

		private float Heuristic(Point a, Point b)
		{
			return (float)Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
		}
	}
}
