using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    class Dice
    {
        Texture2D[] die = new Texture2D[6];
        int[] tally;
        // Hier worden dobbelstenen aangemaakt hoeveelheid = SIZE
        private const int SIZE = 2;
        
        private Random numberGenerator;
        // Hier worden 'willekeurige' getallen gegenereerd
        public Dice()
        {
            numberGenerator = new Random();
            Roll();
        }
        // Hier wordt bepaald welk plaatje getekend moet worden
        public void LoadContent(ContentManager contentManager)
        {
            die[0] = contentManager.Load<Texture2D>("dice 1");
            die[1] = contentManager.Load<Texture2D>("dice 2");
            die[2] = contentManager.Load<Texture2D>("dice 3");
            die[3] = contentManager.Load<Texture2D>("dice 4");
            die[4] = contentManager.Load<Texture2D>("dice 5");
            die[5] = contentManager.Load<Texture2D>("dice 6");
            
        }

        
        // Zorgt ervoor dat er SIZE keer gegooid wordt.
        public void Roll()
        {
            tally = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                tally[i] = DiceRoll();
            }
        }
        // Hier wordt een integer teruggegeven, + 1omdat 6 de getallen 1-5 zijn.
        private int DiceRoll()
        {
            return numberGenerator.Next(6) + 1;
        }
        // Hier wordt een plaatje getekend
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tally.Length; i++)
            {
                spriteBatch.Draw(texture: die[tally[i] - 1], destinationRectangle: new Rectangle(50 * i, 0, 30,30), color: Color.White);
                
            }
        }
    }
}
