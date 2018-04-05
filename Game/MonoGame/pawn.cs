using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class pawn
    {
        public Texture2D texture;


        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("stad");
        }
    }
}
