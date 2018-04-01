using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            Game Game1 = new Game();
            Game1.Start();
            Players P1 = new Players();
            B: P1.Diligent();
            P1.Simple();
            P1.SimpleClever();
            P1.DilCheater();
            P1.SimpleCheater();
            P1.Result();
            if (P1.Winner == 0)
            {
                Console.WriteLine("Next Round");
                Console.ReadLine();
                goto B;
            }
            Console.ReadLine();            
        }
    }
      public class Game
    {
       static public int min, max, guess;
       static public string min1, max1, guess1;
       public Random rand = new Random();

        public void Start()
        {
            Console.WriteLine("Enter the Min Value");
            Q: min1 = Console.ReadLine();
            if (Regex.IsMatch(min1, "[0-9]"))
            {
                min = Convert.ToInt32(min1);
            }
            else
            {
                Console.WriteLine("Please,enter ONLY numbers");
                goto Q;
            }
            Console.WriteLine("Enter the Max Value");
            W: max1 = Console.ReadLine();
            if (Regex.IsMatch(max1, "[0-9]"))
            {
                max = Convert.ToInt32(max1);
            }
            else
            {
                Console.WriteLine("Please,enter ONLY numbers");
                goto W;
            }

            Console.WriteLine("Enter the Guess Number");
            M: guess1 = Console.ReadLine();
            if (Regex.IsMatch(guess1, "[0-9]"))
            {
                guess = Convert.ToInt32(guess1);
            }
            else
            {
                Console.WriteLine("Please,enter ONLY numbers");
                goto M;
            }

             if (guess >max | guess < min)
            {
                    Console.WriteLine("Please,enter the Guess Number from Min Value to Max Value");
                goto M;
            }            
        }        
    }
    public class Players:Game
    {
        public int i,j,k,sc,l,w;
        public int d = 2;
        public int[] Ar = new int[(max - min)*2];
        public int[] SC = new int[(max - min) * 2];
        public int[] Win = new int[5];
        public int Winner { get; set; }

       public void Diligent()
        { 
            if (i == 0)
            {
                Ar[i] = min + 1;
            }
            else
            {
                Ar[i] =min+d ;
                d++;
            }
            Console.WriteLine("Answer of 1st player" + Ar[i]);
            if (Ar[i] == guess)
            {
                Win[0] = guess;
            }
             i++;
        }

        public void Simple()
        {
            Ar[i] = rand.Next(min, max);
            Console.WriteLine("Answer of 2nd player" + Ar[i]);
            if (Ar[i] == guess)
            {
                Win[1] = guess;
            }
            i++;
        }
        public void SimpleClever()
        {
            S: sc = rand.Next(min, max);            
            for (j = 0; j != (max - min) * 2; j++)
            {
                if (SC[j] == sc)
                {
                    goto S;  
                }                                   
            }
            j = k;
            SC[j] = sc;
            k++;
            Ar[i] = sc;            
                Console.WriteLine("Answer of 3d player" + Ar[i]);
            if (Ar[i] == guess)
            {
                Win[2] = guess;
            }
            i++;                
        }
        public void DilCheater()
        {
            sc=min+1;
            l = i;
            D: for (i = 0; i != (max - min) * 2; i++)
            {if (Ar[i] == sc)
                {
                    sc++;
                    goto D;
                }
            }
            i = l;
            Ar[i] = sc;
            Console.WriteLine("Answer of 4th player" + Ar[i]);
            if (Ar[i] == guess)
            {
                Win[3] = guess;
            }
            i++;
        }
        public void SimpleCheater()
        {
            l = i;
            F: sc = rand.Next(min, max);            
            for (i = 0; i != (max - min) * 2; i++)
            {
                if (Ar[i] == sc)
                {
                    goto F;
                }
            }
            i = l;
            Ar[i] = sc;
            Console.WriteLine("Answer of 5d player" + Ar[i]);
            if (Ar[i] == guess)
            {
                Win[4] = guess;
            }
            i++;
        }
        public void Result()
        {
            for (w = 0; w != 5; w++)
            { if (Win[w] == guess)
                {
                    Console.Write("The winner is player №");
                    Console.WriteLine(w+1);
                    Winner = 1;
                }                
            }
            if(Win[0]==0&&Win[1]==0 && Win[2] == 0 && Win[3] == 0 && Win[4] == 0)
            {
                Console.WriteLine("No winners");
                Winner = 0;

            }          

        }
    }
}
