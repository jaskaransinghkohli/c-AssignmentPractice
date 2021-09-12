using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOne
{
    public enum Sports
    {
        Baseball = 200,
        Hockey = 280,
        Football = 470 

    };
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
            Console.ReadLine();
        }
        public void Start()
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-CA");
                
                var totalSportsPlayed = Enum.GetNames(typeof(Sports));
                string ticketsPurchasedString = string.Empty;
                //Initializing Values for tickets purchased for every sport
                int totalTicketsPurchased = 0;
                int totalTicketPurchasedForBaseball = 0;
                int totalTicketPurchasedForHockey = 0;
                int totalTicketPurchasedForFootball = 0;
                
                decimal totalMoneySpend = 0;

                Console.WriteLine("Hello Walter, I hope you are having a great day. I have some questions for you. \nLet me start by asking,");
                
                foreach (string sport in totalSportsPlayed)
                {
                    int costOfSport = (int)Enum.Parse(typeof(Sports), sport);
                    int ticketsPurchased = 0;
                    Console.Write("How many tickets did u purchase for {0} costing {1} per ticket? ", sport,costOfSport.ToString("c"));
                    ticketsPurchasedString = Console.ReadLine();
                    int.TryParse(ticketsPurchasedString, out ticketsPurchased);
                    if (Enum.TryParse(sport, out Sports sportEnum) && ticketsPurchased > 0)
                    {
                        switch (sportEnum)
                        {
                            case Sports.Baseball:
                                totalTicketPurchasedForBaseball = ticketsPurchased;
                                totalTicketsPurchased += totalTicketPurchasedForBaseball;
                                totalMoneySpend += (costOfSport * totalTicketPurchasedForBaseball);
                                break;
                            case Sports.Hockey:
                                totalTicketPurchasedForHockey = ticketsPurchased;
                                totalTicketsPurchased += totalTicketPurchasedForHockey;
                                totalMoneySpend += (costOfSport * totalTicketPurchasedForHockey);
                                break;
                            case Sports.Football:
                                totalTicketPurchasedForFootball = ticketsPurchased;
                                totalTicketsPurchased += totalTicketPurchasedForFootball;
                                totalMoneySpend += (costOfSport * totalTicketPurchasedForFootball);
                                break;

                            default:
                                break;
                        }
                    }
                }
                //Calculate Average
                decimal averageCost = 0;
                if (totalTicketsPurchased != 0)
                {
                     averageCost = totalMoneySpend / totalTicketsPurchased;
                }
                //Summary
                Console.WriteLine("\t\t\t*** SUMMARY ***");
                //Total Money Spend and tickets purchased
                Console.WriteLine("Total number tickets purchased by Walter for every sport : {0}", totalTicketsPurchased);
                foreach (string sport in totalSportsPlayed)
                {
                    int costOfSport = (int)Enum.Parse(typeof(Sports), sport);

                    if (sport == Sports.Baseball.ToString())
                    {
                        Console.WriteLine("Walter purchased {0} Basketball tickets at {1} each and it's total is {2} ", totalTicketPurchasedForBaseball, costOfSport.ToString("c"),(totalTicketPurchasedForBaseball * costOfSport).ToString("c"));
                    }
                    else if (sport == Sports.Hockey.ToString())
                    {
                        Console.WriteLine("Walter purchased {0} Hockey tickets at {1} each and it's total is {2} ", totalTicketPurchasedForHockey, costOfSport.ToString("c"), (totalTicketPurchasedForHockey * costOfSport).ToString("c"));
                    }
                    else if (sport == Sports.Football.ToString())
                    {
                        Console.WriteLine("Walter purchased {0} Football tickets at {1} each and it's total is {2} ", totalTicketPurchasedForFootball, costOfSport.ToString("c"), (totalTicketPurchasedForFootball * costOfSport).ToString("c"));
                    }

                }
                Console.WriteLine("Total money spent by Walter : {0} \nAverage price of watching these games by Walter : {1}", totalMoneySpend.ToString("c"), averageCost.ToString("c"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

        }
    }
}
