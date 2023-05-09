using System;
using System.Linq;

namespace Hedgehogs
{
    enum Color
    {
        Red = 0,
        Green,
        Blue
    }

    class Program
    {
        static void Main()
        {
            int[] population = new int[3] { 3, 0, 6 };
            int desiredColor = 1;

            //  ManuaInput(population,ref desiredColor);

            Console.WriteLine("Input data: ");
            for (int i = 0; i < population.Length; i++)
                Console.WriteLine($"{(Color)i}: {population[i]}");

            Console.WriteLine($"Selected color: {(Color)desiredColor}");

            int count = GetMeetingsToChangeColor(population, desiredColor);
            Console.WriteLine($"Step count: {count}");
            Console.WriteLine("Enter any button to close the program...");
            Console.ReadKey();
        }

        private static int GetMeetingsToChangeColor(int[] population, int desiredColor)
        {
            int[] indexes = Enumerable.Range(0, population.Length)
                .Where(x => x != desiredColor)
                .ToArray();

            int colorA = indexes[0],
                colorB = indexes[1],
                count = 0;

            if ((population[colorB] - population[colorA]) % 3 != 0 || population.Count(x => x == 0) >= 2)
            {
                return -1;
            }
            else
            {
                while (population[colorA] != population[colorB])
                {
                    count++;
                    if (population[desiredColor] > 0 && population[colorA] > population[colorB])
                    {
                        population[colorB] += 2;
                        population[desiredColor] -= 1;
                        population[colorA] -= 1;
                    }
                    else if (population[desiredColor] > 0 && population[colorA] < population[colorB])
                    {
                        population[colorA] += 2;
                        population[desiredColor] -= 1;
                        population[colorB] -= 1;
                    }
                    else
                    {
                        population[desiredColor] += 2;
                        population[colorA] -= 1;
                        population[colorB] -= 1;
                    }
                }

                return count += population[colorA];
            }
        }

        private static void ManuaInput(int[] population, ref int desiredColor)
        {
            Console.WriteLine("Enter each population hedgehogs");

            for (int i = 0; i < 3; i++)
                population[i] = ReadIntegerValue($"{(Color)i}:");

            desiredColor = ReadIntegerValue($"Write desired color:", 0, 2);
        }

        private static int ReadIntegerValue(string message, int minValue = 0, int maxValue = int.MaxValue)
        {
            int value;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out value) || value < minValue || value > maxValue);

            return value;
        }


    }

}
