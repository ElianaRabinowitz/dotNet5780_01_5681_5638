//dotNet, exercise 1
//Elisheva Nafha id 212665681 and Eliana Rabinowitz id 212375638
//This program manages a basic booking system.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_01_5681_5638
{
    class part2
    {
        static void Main(string[] args)
        {
            //create a matrix that holds all dates in the year
            bool[,] year = new bool[12, 31];
            //initialize all dates to "not booked"
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    year[i, j] = false;
                }
            }
            
            //start managing bookings
            int switchCase = 0;
            bool exit = false;
            Console.WriteLine("Enter a number from 0 to 3:\n " +
                "Enter 1 to book a visit\n " +
                "Enter 2 to show all bookings\n " +
                "Enter 3 to show number of booked days in the year\n " +
                "Enter 0 to exit");
            do
            {
                Console.WriteLine("Enter a number from 0 to 3:");
                switchCase = Convert.ToInt32(Console.ReadLine());
                switch (switchCase)
                {
                    case 0: //exit management system
                        {
                            exit = true;
                            break;
                        }
                    case 1: //book a visit
                        {
                            //read requested visit dates
                            Console.WriteLine("Enter check-in month (1-12):");
                            int month = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter day of the month (1-31):");
                            int day = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter number of visit days:");
                            int numDays = Convert.ToInt32(Console.ReadLine());

                            //Invalid input
                            if ((month < 1) || (month > 12) || (day < 1) || (day > 31)) //illegal date
                            {
                                Console.WriteLine("ERROR: Invalid input");
                                break;
                            }
                            if ((day + ((month - 1) * 31) + numDays - 1) > 372) //the system is limited to one year
                            {
                                Console.WriteLine("ERROR: Invalid input");
                                break;
                            }
                            
                            //matrix indexing starts from 0
                            month--;
                            day--;

                            //INPUT EXCEPTION: when following question's instructions, the system can't differentiate between two different bookings in two 
                            //consecutive days (free night in the middle) and one booking for two consecutive days (no free night in the middle). 
                            //Therefore, if a visit is requested for two days that are already booked, the request is denied.
                            if (numDays == 2)
                            {
                                if (year[month, day])
                                {
                                    //if last day of month
                                    if ((day + 1) > 31)
                                    {
                                        if (year[month + 1, 1])
                                        {
                                            Console.WriteLine("Request denied");
                                            break;
                                        }
                                    }
                                    else if (year[month, day + 1])
                                    {
                                        Console.WriteLine("Request denied");
                                        break;
                                    }
                                       
                                }
                            }

                            bool failed = false; //availability flag
                            int tempMonth = month;
                            int tempDay = day;
                            //check availability of requested dates
                            for (int i = 0; i < numDays - 2; i++)
                            {
                                tempDay++;
                                //if last day of the month
                                if (tempDay > 30)
                                {
                                    tempDay = 0;
                                    tempMonth++;
                                }
                                if (year[tempMonth, tempDay])
                                {
                                    failed = true;
                                    break;
                                }
                            }
                            tempDay = day;
                            tempMonth = month;
                            if (failed)
                                Console.WriteLine("Request denied");
                            //book requested days
                            else
                            {
                                for (int i = 0; i < numDays; i++)
                                {
                                    //if last day of the month
                                    if (tempDay > 30)
                                    {
                                        tempDay = 0;
                                        tempMonth++;
                                    }
                                    year[tempMonth, tempDay] = true;
                                    tempDay++;
                                }
                                Console.WriteLine("Request accepted");
                            }
                            break;
                        }
                    case 2: //show all bookings
                        {
                            Console.WriteLine("Booked dates:");
                            bool booked = false;
                            //check all dates
                            for (int i = 0; i < 12; i++)
                            {
                                for (int j = 0; j < 31; j++)
                                {
                                    //if starting booked period
                                    if ((!booked) && (year[i, j]))
                                    {
                                        Console.Write("{0}/{1} to ", j+1, i+1);
                                        booked = true;
                                    }
                                    //if finishing booked period
                                    else if ((booked) && ((!(year[i, j]))))
                                    {
                                        //if first day of the month
                                        if (j == 0)
                                        {
                                            Console.WriteLine("{0}/{1}", 31, i);
                                        }
                                        else
                                        {
                                            Console.WriteLine("{0}/{1}", j, i + 1);
                                        }
                                        booked = false;
                                    }
                                }
                            }
                            break;
                        }
                    case 3: //show number of booked days in the year
                        {
                            //count booked days
                            int sumDays = 0;
                            for (int i = 0; i < 12; i++)
                            {
                                for (int j = 0; j < 31; j++)
                                {
                                    if (year[i, j])
                                        sumDays++;
                                } 
                            }
                        
                            Console.WriteLine("Booked days in the year: {0}\nPercentage of booked days in the year: {1}%", sumDays, 100*((float)sumDays / (float)372));
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid input");
                            break;
                        }
                }
            }
            while (!exit);
        }

    };
}

//Output example:
//Enter a number from 0 to 3:
// Enter 1 to book a visit
// Enter 2 to show all bookings
// Enter 3 to show number of booked days in the year
// Enter 0 to exit
//Enter a number from 0 to 3:
//1
//Enter check-in month(1-12) :
//1
//Enter day of the month(1-31) :
//1
//Enter number of visit days:
//234
//Request accepted
//Enter a number from 0 to 3:
//3
//Booked days in the year: 234
//Percentage of booked days in the year: 62.90322%
//Enter a number from 0 to 3:
//2
//Booked dates:
//1/1 to 17/8
//Enter a number from 0 to 3:
//1
//Enter check-in month(1-12) :
//1
//Enter day of the month(1-31) :
//1
//Enter number of visit days:
//23
//Request denied
//Enter a number from 0 to 3:
//0
//Press any key to continue . . .