using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_6
{
    internal class Circle
    {
        private float radius;
        private int ID;
        private static int NextID=1;


        public Circle() : this(1) {}

        public Circle(float radius)
        {
            this.SetRadius(radius);
            this.ID = NextID;
            NextID++;
        }

        public float GetArea()
        {
            float Area = (float)Math.PI * (radius * radius);
            //Console.WriteLine(Area);
            return (float)Area;
        }
        public float GetCircumference()
        {
            float Circumference= 2*((float)Math.PI) * radius;
            return Circumference;
        }
        public int GetID()
        {
            return ID;
        }
        public float GetRadius()
        {
            return this.radius;
        }
        public bool SetRadius(float radius)
        {
            if (radius > 0)
            {
                this.radius=radius;
                return true;
            }
            else
            {
                Console.WriteLine("Can't have a circle with a negative radius");
                return false;
            }
            
        }
    }

}
