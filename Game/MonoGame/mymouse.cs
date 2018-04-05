using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public  static class mymouse
    {
        public static  MouseState curstate, prevState;

        public static void update ()
        {
            prevState = curstate;
            curstate = Mouse.GetState();
        }

        public static Rectangle GetRectangle()
        {
            return new Rectangle(curstate.Position.X, curstate.Position.Y, 1,1);
        }
    }
}
