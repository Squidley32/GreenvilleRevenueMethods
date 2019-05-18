using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenvilleRevenueMethods
{
    class GreenvilleRevenuMethods
    {
        /*****MOVED THE CONTSTANTS TO A LEVEL THAT IS ACCESSIBLE TO ALL METHODS *****************/
        const int ENTRANCE_FEE = 25;
        const int MIN_CONTESTANTS = 0;
        const int MAX_CONTESTANTS = 30;

        static void Main()
        {


            int numThisYear;
            int numLastYear;
            int revenue;
            //multi-dimensional array that will hold contestant talents
            string[,] talents = null;

            /************CALL METHOD #1 TWICE: RETRIEVE THE CONSTESTANT INFORMATION FROM EACH YEAR*************/
            //prompt user for last year's contestants
            Console.WriteLine("Please enter information for last year's contestants");
            Console.WriteLine("Enter number of Contestants");
            //Get last years contestants 
            numLastYear = GetContestants(Convert.ToInt32(Console.ReadLine()));

            //prompt user for this year's contestants
            Console.WriteLine("Thank you for last year.  Now, please enter information for this year's contestants");
            Console.WriteLine("Enter number of Contestants");
            numThisYear = GetContestants(Convert.ToInt32(Console.ReadLine()));


            /*********CALL METHOD #2: PRINTS OUT RELATIONSHIP BETWEEN CONTESTANTS THIS YEAR AND LAST**********/
            PrintComparisonInfo(numLastYear, numThisYear);

            /*********CALL METHOD #3: REQUEST THE TALENT CODE FOR EACH OF THIS YEAR'S CONTESTANTS**********/
            PromptForTalents(numThisYear, out talents);

            //calulate this year's revenue
            revenue = numThisYear * ENTRANCE_FEE;

            //********ALREADY COMPLETED IN PREVIOUS ASSIGNMENT*************//
            Console.WriteLine("The expected revenue is {0}", revenue.ToString("C"));

            //****CALL METHOD #4: PRINTS OUT THE NUMBER OF CONTESTANTS WITH EACH TALENT****************//
            //pass in the array from other method
            //try to print out a row or something simple to practice first
            PrintTalentTotals(talents, numThisYear);

            //**************KEEPS THE CONSOLE WINDOW OPEN IN DEBUG********************//
            int x = Console.Read();
        }

        /************METHOD 1: RETRIEVES THE CONSTESTANT INFORMATION *************/
        static int GetContestants(int numOfContestants)
        {
            return numOfContestants;
        }

        /************METHOD 2: PRINTS RESULTS OF COMPARING CONSTESTANT INFORMATION *************/
        static void PrintComparisonInfo(int lastYearContestants, int thisYearContestants)
        {
            Console.WriteLine("Last year we had {0} contestants, and this year we have {1} contestants.", lastYearContestants, thisYearContestants);

        }

        /************METHOD 3: PROMPS FOR CONTESTANT TALENTS *************/
        //pass in number of contestants this year, then pass in the array, 
        static void PromptForTalents(int num, out string[,] contestTalents)
        {

            string talent;
            string name;
            bool result = true;
            //declaration for array, num is the number of rows(how many , 2 is how many columns
            contestTalents = new string[num, 2];
            //loop, how many times are we gonna loop? however many contestants there is is how many times loop
            for (int i = 0; i < num; i++)
            {
                //get the contestant's name
                Console.WriteLine("Enter the contestants name");
                name = Console.ReadLine();
                //store the name in the array
                //i is 0 first time through, first column first row. 
                //colum 0 is always going to be names so 0 can be a constant
                contestTalents[i, 0] = name;

                //create do loop to give many chances to put right input in.
                do
                {
                    //get the talent
                    //let user know issue if this is second+ time requesting the information(if result false)
                    if (result == false)
                    {
                        Console.WriteLine("Incorrect talent code");
                    }
                    Console.WriteLine("Talents are S (Singing), D (Dancing), M (Playing Musical Instrument) or O (other)");
                    Console.WriteLine("Please enter 1 talent for contestant {0}", name);
                    //read talent
                    talent = Console.ReadLine();

                    //validate the talent, make sure they entered something valid
                    switch (talent)
                    {
                        case "S":
                        case "D":
                        case "M":
                        case "O":
                            //if valid data the true
                            result = true;
                            break;
                        default:
                            //if not true its false
                            result = false;
                            break;
                    }


                } while (result == false);

                //valid value has been entered - place the talent information in the array
                //hard coded the 1 because we are now looking at row 0 column 1
                contestTalents[i, 1] = talent;
            }
        }

        /************METHOD 4: PRINTS SUMMARY COUNTS OF CONTESTANT TALENTS *************/
        //print out each talent ([0,i]) and how many contestants([i,0]) have that talent code in their column 1
        static void PrintTalentTotals(string[,] contestTalents, int numContestants)
        {
            int sCount = 0;
            int dCount = 0;
            int mCount = 0;
            int oCount = 0;


            for (int i = 0; i < numContestants; i++)
            {


                //if element in talent column = s, then add 1 to the sCount. repeat until end of nunmContestants
                if (contestTalents[0, 1] == "S")
                {
                    sCount = sCount++;

                }

                else if (contestTalents[0, 1] == "D")
                {
                    dCount++;

                }
                else if (contestTalents[0, 1] == "M")
                {
                    mCount++;

                }
                else if (contestTalents[0, 1] == "O")
                {
                    oCount++;
                }
            }

            Console.WriteLine("Talent Summary:");
            Console.WriteLine("Singing: {0}", sCount);
            Console.WriteLine("Dancing: {0}", dCount);
            Console.WriteLine("Playing musical instrument: {0}", mCount);
            Console.WriteLine("Other:   {0}", oCount);
            
        }


    }

}




    

