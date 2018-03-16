    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace MonoGame
{
    class Tiles
    {
        protected Texture2D texture;

        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return Rectangle; }
            protected set { rectangle = value; }
        }

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get => content; 
            set => content = value; 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    
        
    }

    class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            switch(i)
            {
                case 6:
                    texture = Content.Load<Texture2D>("ocean");
                    break;
                case 1:
                    texture = Content.Load<Texture2D>("Wood");
                    break;
                case 2:
                    texture = Content.Load<Texture2D>("Stone");
                    break;
                case 3:
                    texture = Content.Load<Texture2D>("Sheep");
                    break;
                case 4:
                    texture = Content.Load<Texture2D>("Wheat");
                    break;
                case 5:
                    texture = Content.Load<Texture2D>("Mountain");
                    break;

                default:
                    break;
            }
            this.Rectangle = newRectangle;
        }
    }
}
