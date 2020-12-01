using System;
using System.Collections.Generic;

namespace firstTest
{
    //random comment
    public enum Color
    {
        Blue, Gray, Green, Red, White
    }
    
    public enum Figure
    {
        Book, Mouse, Bottle, Chair, Ghost 
    }

    public class ColoredFigure
    {
        public Color C;
        public Figure F;        
        public ColoredFigure(Color x, Figure y)
        {
            C = x;
            F = y;
        }       
    }

    class Card
    {
        public ColoredFigure ColFig1;
        public ColoredFigure ColFig2;
        public int type; //0 OR 1

        public Card(ColoredFigure x, ColoredFigure y, int i)
        {
            ColFig1 = x;
            ColFig2 = y;
            type = i;
        }
    }

    class Game
    {
        
        public List<ColoredFigure> fasit = new List<ColoredFigure>();
        public List<Card> deck = new List<Card>();
        public void makeFasit()
        {
            for (int i = 0; i < 5; i++)
            {
                fasit.Add(new ColoredFigure((Color)i, (Figure)i));
            }
        }

        public void makeColoredFigureType1()
        {
            var rand = new Random();

            //ColoredFigure1
            int randInt = rand.Next(0, 5);
            Color col1 = (Color)randInt;
            Figure fig1 = (Figure)randInt;            
            ColoredFigure colFig1 = new ColoredFigure(col1, fig1);

            //ColoredFigure2
            int randFig;
            int randCol;
            while (true)
            {
                randFig = rand.Next(0, 5);
                if (randFig != randInt) { break; }                
            }
            while (true)
            {
                randCol = rand.Next(0, 5);
                if (randCol != randInt && randCol!= randFig) { break; }
            }
            Color col2 = (Color)randCol;
            Figure fig2 = (Figure)randFig;
            ColoredFigure colFig2 = new ColoredFigure(col2, fig2);

            deck.Add(new Card(colFig1, colFig2,0));
        }

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.makeFasit();
            

            for (int i = 0; i < 10; i++)
            {
                g.makeColoredFigureType1();
                Console.WriteLine("{0} {1} {2} {3} {4}, {5} {6} {7}", "Card",i + 1,
                ": Figure 1 -", g.deck[i].ColFig1.C, g.deck[i].ColFig1.F, "Figure 2 -", g.deck[i].ColFig2.C, g.deck[i].ColFig2.F);
            }
           

        }
    }
}
