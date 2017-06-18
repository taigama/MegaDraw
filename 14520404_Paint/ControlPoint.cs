using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14520404_Paint
{
    public enum TYPE_CONTROL
    {
        None,
        Move,
        Area
    }

    public class ControlPoint
    {
        private int range = 0;
        public int sizeDot = 3;

        List<Vector2> points = null;
        List<Vector2> subPoints = null;

        Rectangle? region;

        public int count
        {
            get
            {
                if (points == null)
                    return 0;

                return points.Count;
            }
        }

        public ControlPoint(int rangePoint)
        {
            // phạm vi để grab vào point
            range = rangePoint;

            points = new List<Vector2>();
            subPoints = new List<Vector2>();

            region = null;
        }

        public TYPE_CONTROL OnControl(Vector2 cursor, out Vector2 grabPoint)
        {
            grabPoint = null;
            Cursor.Current = Cursors.SizeAll;

            if (subPoints.Count > 0)
            {
                for (int i = 0; i < subPoints.Count; i++)
                {
                    if (IsIntersect(cursor, subPoints[i]))
                    {
                        grabPoint = subPoints[i];
                        return TYPE_CONTROL.Move;
                    }
                }
            }
            if(points.Count > 0)
            {
                for(int i = 0; i < points.Count; i++)
                {
                    if(IsIntersect(cursor, points[i]))
                    {
                        grabPoint = points[i];
                        return TYPE_CONTROL.Move;
                    }
                }           
            }             
            else if(region != null)
            {
                if (IsIntersect(cursor, region.Value))
                {
                    return TYPE_CONTROL.Area;
                }
            }

            Cursor.Current = Cursors.Arrow;
            return TYPE_CONTROL.None;
        }

        public bool HaveRegion()
        {
            if (region != null)
                return true;

            return false;
        }

        public void MoveRegion(int moveX, int moveY)
        {
            if (region == null)
                return;

            Rectangle rect = region.Value;
            rect.X += moveX;
            rect.Y += moveY;
            
        }

        bool IsIntersect(Vector2 cursor, Vector2 point)
        {
            // basic AABB intersect checking

            if (cursor.X < (point.X - range))
                return false;
            if (cursor.X > (point.X + range))
                return false;
            if (cursor.Y < (point.Y - range))
                return false;
            if (cursor.Y > (point.Y + range))
                return false;

            return true;
        }

        bool IsIntersect(Vector2 cursor, Rectangle rect)
        {
            // basic AABB intersect checking

            if (cursor.X < rect.X)
                return false;
            if (cursor.X > (rect.X + rect.Width))
                return false;
            if (cursor.Y < rect.Y)
                return false;
            if (cursor.Y > (rect.Y + rect.Height))
                return false;

            return true;
        }

        public void DrawControl(PaintEventArgs e)
        {
            if(points.Count > 0)
            {
                // draw points
                for(int i = 0; i < points.Count; i++)
                {
                    DrawPoint(e, points[i], Color.White);
                }
            }

            if (subPoints.Count > 0)
            {
                // draw points
                for (int i = 0; i < subPoints.Count; i++)
                {
                    DrawPoint(e, subPoints[i], Color.Orange);
                }
            }

            if (region != null)
            {
                // draw region
                DrawRegion(e, region.Value);
            }
        }

        // vẽ grab point ---
        private void DrawPoint(PaintEventArgs e, Vector2 point, Color color)
        {            
            // vẽ đen
            e.Graphics.FillRectangle(Brushes.Black, (point.X - sizeDot) , (point.Y - sizeDot), sizeDot * 2, sizeDot * 2);
            // vẽ trắng
            using (Brush b = new SolidBrush(color))
            {
                e.Graphics.FillRectangle(b, (point.X - sizeDot) + 1, (point.Y - sizeDot) + 1, sizeDot * 2 - 2, sizeDot * 2 - 2);
            }
        }

        private void DrawRegion(PaintEventArgs e, Rectangle rect)
        {
            using (Pen pen = new Pen(Brushes.DarkGray, 1))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;

                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        public void AddPoint(params Vector2[] _Points)
        {
            foreach (Vector2 point in _Points)
            {
                this.points.Add(point);
            }
        }

        public void AddSubPoint(params Vector2[] _Points)
        {
            foreach (Vector2 point in _Points)
            {
                this.subPoints.Add(point);
            }
        }

        public Vector2[] GetVectors()
        {
            return points.ToArray();
        }

        public Vector2[] GetSubVectors()
        {
            return subPoints.ToArray();
        }

        public Point[] GetPoints()
        {
            Point[] pps = new Point[points.Count];

            for(int i = 0; i < points.Count; i++)
            {
                pps[i].X = points[i].X;
                pps[i].Y = points[i].Y;
            }

            return pps;
        }

        public Point[] GetSubPoints()
        {
            Point[] pps = new Point[subPoints.Count];

            for (int i = 0; i < subPoints.Count; i++)
            {
                pps[i].X = subPoints[i].X;
                pps[i].Y = subPoints[i].Y;
            }

            return pps;
        }

        public void Clear()
        {
            points.Clear();
            subPoints.Clear();
            region = null;
        }

        public void ClearSub()
        {
            subPoints.Clear();
        }
    }
}
