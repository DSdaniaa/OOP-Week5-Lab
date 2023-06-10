using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Challenge1.BL
{
    class MyLine
    {
        public MyPoint begin;
        public MyPoint end;

        public MyLine(MyPoint begin, MyPoint end)
        {
            this.begin = begin;
            this.end = end;

        }
        public MyPoint getBegin()
        {
            return begin;
        }
        public void setBegin(MyPoint begin)
        {
            this.begin = begin;
        }
        public MyPoint getEnd()
        {
            return end;
        }
        public void setEnd(MyPoint end)
        {
            this.end = end;
        }
        public double getLength()
        {
            int minX, minY;
            double result;
            minX = begin.x -end.x;
            minY = begin.y - end.y;
            minX = minX * minX;
            minY = minY * minY;
            result = minX + minY;
            result = Math.Sqrt(result);
            return result;
        }
        public double getGradient()
        {
            int minX, minY;
            double result;
            minX = begin.x - end.x;
            minY = begin.y - end.y;
            result = minY / minX;
            return result;
        }
    }
}
