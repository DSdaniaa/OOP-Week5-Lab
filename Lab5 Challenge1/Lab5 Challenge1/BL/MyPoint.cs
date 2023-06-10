using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Challenge1.BL
{
    class MyPoint
    {
       

        public MyPoint()
        {
            this.x = 0;
            this.y = 0;
        }
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int x;
        public int y;

        public int getX()
        {
            return x;

        }
        public int getY()
        {
            return y;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public void setXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public double distanceWithCords(int x,int y)
        {
            int minX, minY;
            double result;
            minX = this.x - x;
            minY = this.y - y;
            minX = minX * minX;
            minY = minY * minY;
           result= minX + minY;
            result = Math.Sqrt(result);
            return result;
                
        }
        public double distanceWithObject(MyPoint another)
        {
            int minX, minY;
            double result;
            minX = this.x - another.x;
            minY = this.y - another.y;
            minX = minX * minX;
            minY = minY * minY;
            result = minX + minY;
            result = Math.Sqrt(result);
            return result;
        }
        public double distanceFromZero()
        {
            int minX, minY;
            double result;
            minX = this.x - 0;
            minY = this.y - 0;
            minX = minX * minX;
            minY = minY * minY;
            result = minX + minY;
            result = Math.Sqrt(result);
            return result;
        }
    }
}
