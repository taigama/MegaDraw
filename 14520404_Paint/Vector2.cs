using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14520404_Paint
{
    public class Vector2
    {
        private Point point;

        public Point Point
        {
            get
            {
                return point;
            }
        }

        public int X
        {
            get
            {
                return point.X;
            }
            set
            {
                point.X = value;
            }
        }

        
        public int Y
        {
            get
            {
                return point.Y;
            }
            set
            {
                point.Y = value;
            }
        }
        
        public Vector2(int X = 0, int Y = 0)
        {
            point = new Point(X, Y);
        }

        // Hàm này: tạo vùng nhớ mới
        public Vector2 CreateVector(Vector2 A, Vector2 B)
        {
            return new Vector2(B.X - A.X, B.Y - A.Y);
        }

        // Hàm này: sửa trực tiếp trong C, chứ ko phải tạo ra vùng nhớ mới
        public void CreateVector(Vector2 A, Vector2 B, ref Vector2 C)
        {
            if (C == null)
                C = new Vector2();

            C.X = B.X - A.X;
            C.Y = B.Y - A.Y;
        }

        public bool Equal(Vector2 _Other)
        {
            if ((this.X == _Other.X) && (this.Y == _Other.Y))
                return true;

            return false;
        }

    }
}
