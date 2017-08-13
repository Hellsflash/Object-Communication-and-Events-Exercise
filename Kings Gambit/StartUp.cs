using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        King king = new King(Console.ReadLine());
        List<Soldier> army = new List<Soldier>();

        string[] royalGuards = Console.ReadLine().Split();
        foreach (string royalGuard in royalGuards)
        {
            RoyalGuard guard = new RoyalGuard(royalGuard);
            army.Add(guard);
            king.UnderAttack += guard.KingUnderAttack;
        }

        string[] footmans = Console.ReadLine().Split();
        foreach (string footman in footmans)
        {
            Footman foot = new Footman(footman);
            army.Add(foot);
            king.UnderAttack += foot.KingUnderAttack;
        }

        string[] command = Console.ReadLine().Split();

        while (command[0] != "End")
        {
            switch (command[0])
            {
                case "Kill":
                    Soldier soldier = army.FirstOrDefault(s => s.Name == command[1]);
                    king.UnderAttack -= soldier.KingUnderAttack;
                    army.Remove(soldier);
                    break;

                case "Attack":
                    king.OnUnderAttack();
                    break;
            }
            command = Console.ReadLine().Split();
        }
    }
}