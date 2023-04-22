// See https://aka.ms/new-console-template for more information
using System;

class ShootoutGame
{
    static void Main()
    {
        
        Console.WriteLine("Enter No. of Robbers: ");
        int numRobbers = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Enter the Robber with whom Sam will start shooting: ");
        int startRobber = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Enter the gap between the Robbers: ");
        int gap = Convert.ToInt16(Console.ReadLine());

        
        int currentRobber = startRobber;
        int liveTargets = numRobbers;
        int shotsTaken = 0;
        string shootSequence = "";

       
        while (liveTargets > 0)
        {
            
            shotsTaken++;
            shootSequence += currentRobber.ToString() + ",";

            Console.WriteLine("Target={0},{1} shots completed", currentRobber, shotsTaken);
            liveTargets--;

            
            int nextRobber = currentRobber + gap;
            if (nextRobber > numRobbers)
            {
                nextRobber -= numRobbers;
            }
            currentRobber = nextRobber;
        }

        
        Console.WriteLine("\n{0} shots taken", shotsTaken);
        Console.Write("The shootout sequence was ");

        shootSequence = shootSequence.Remove(shootSequence.Length - 1);
        Console.WriteLine(shootSequence);
    }
}

