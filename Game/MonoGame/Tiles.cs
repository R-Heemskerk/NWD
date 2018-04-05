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
        protected Texture2D texture,
            cirkel;
        protected int getal = 12;

        protected SpriteFont font;

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
            if (getal > 0)
            {
                spriteBatch.Draw(cirkel, new Rectangle(rectangle.X + 20, rectangle.Y + 20, 24, 24), Color.White);
                spriteBatch.DrawString(font, getal.ToString(), new Vector2(rectangle.X + ( getal < 10 ? 27 : 22), rectangle.Y + 24), Color.Black);
            }

        }
    
        
    }

    class CollisionTiles : Tiles
    {
        static Random r = new Random();
        public CollisionTiles(int i, Rectangle newRectangle)
        {

            getal = r.Next(2, 13);
            switch (i)
            {
                case 6:
                    texture = Content.Load<Texture2D>("ocean");
                    getal = -1;
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
            cirkel = Content.Load<Texture2D>("Cirkel");
            font = Content.Load<SpriteFont>("Arial");
            this.Rectangle = newRectangle;
        }
    }
}
