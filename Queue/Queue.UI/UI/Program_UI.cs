using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    private readonly Gremlin_Repository _gRepo = new Gremlin_Repository();
    public void Run()
    {
        //SeedData();
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to Gremlin Penitentiary");
            System.Console.WriteLine("Please make a selection\n" +
            "1. Add Gremlin to Cell\n" +
            "2. View All Jailed Gremlins\n" +
            "3. View Gremlin to be Released\n" +
            "4. Release A Gremlin\n" +
            "5. Close Application\n");

            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddGremlintoCell();
                    break;
                case "2":
                    ViewAllJailedGremlins();
                    break;
                case "3":
                    ViewGremlinToBeReleased();
                    break;
                case "4":
                    ReleaseAGremlin();
                    break;
                case "5":
                    isRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }

    private bool CloseApplication()
    {
        Console.Clear();
        PressAnyKeyToContinue();
        return false;
    }

    private void ReleaseAGremlin()
    {
        throw new NotImplementedException();
    }

    private void ViewGremlinToBeReleased()
    {
        throw new NotImplementedException();
    }

    private void ViewAllJailedGremlins()
    {
        throw new NotImplementedException();
    }

    private void AddGremlintoCell()
    {
        throw new NotImplementedException();
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press Any Key to continue...");
        Console.ReadKey();
    }

    private void SeedData()
    {

    }
}
