using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    class CButton
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        // Changes colour if mouse moves over it
        Color colour = new Color(255, 255, 255, 255);

        public Vector2 size;

        public CButton(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;

            // ScreenWidth = 800 , ScreenHeight = 600
            // ImageWidth = 100, ImageHeight = 20
            // Keeps the right proportions between image and screenwith

            size = new Vector2(graphics.Viewport.Width / 8, graphics.Viewport.Height / 30);

        }

        bool down;
        public bool isClicked;
        public void Update(MouseState mouse)
        {
            //Places the button on the screen
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);

            //Makes a small rectangle at position of the mouse
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            //If the two rectangles collide th button will light up
            if (mouseRectangle.Intersects(rectangle))
            {
                //If the colour is equal to the colour in line 19 than the mouse is not intersect the rectangle
                if (colour.A == 255) down = false;
                if (colour.A == 0) down = true;
                if (down) colour.A += 3; else colour.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
            }

            else if (colour.A < 255)
            {
                colour.A += 3;
                isClicked = false;
            }
        }
        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);
        }
    }
}
