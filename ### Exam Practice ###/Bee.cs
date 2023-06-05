using System;
using System.Linq;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine()!); // Read the length of the matrix (2D array)
            char[,] matrix = new char[length, length]; // Create the matrix
            for (int row = 0; row < matrix.GetLength(0); row++) // For each row in the matrix
            {
                string input = Console.ReadLine()!; // Read user input to store characters in the matrix
                for (int col = 0; col < matrix.GetLength(1); col++) // For each column in the matrix
                {
                    matrix[row, col] = input[col]; // Store the current character in matrix
                }
            }

            string command; // Initialize the command
            int pollinatedCount = 0; // Keep track of the number of pollinated flowers
            bool isLost = false; // Boolean used to keep track if the Bee is lost (got outside of the matrix bounds)
            while ((command = Console.ReadLine()) != "End") // While the command is not "End"
            {
                ExecuteCommand(command, matrix, ref pollinatedCount,ref isLost); // Go in the method: =>
                if (isLost) // If at any point the Bee got lost
                {
                    break; // Break out of the loop
                }
            }
            if (isLost) // If the Bee is lost
            {
                Console.WriteLine("The bee got lost!"); // Print
            }
            
            // Print if the Bee managed to pollinate at least 5 flowers
            Console.WriteLine(pollinatedCount >= 5
                ? $"Great job, the bee managed to pollinate {pollinatedCount} flowers!"
                : $"The bee couldn't pollinate the flowers, she needed {5 - pollinatedCount} flowers more");

            // Print The 2D Array
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }

        private static void ExecuteCommand(string command, char[,] matrix, ref int pollinatedCount, ref bool isLost)
        {
            var beePosition = matrix
                .Cast<char>()
                .Select((element, index) => new { RowIndex = index / matrix.GetLength(1), ColIndex = index % matrix.GetLength(1), Element = element})
                .FirstOrDefault(item => item.Element == 'B');
            if (beePosition == null) return; 

            Bee bee = new Bee(beePosition.RowIndex, beePosition.ColIndex); // Keep track of the Bee position
            switch (command) // Moves
            {
                case "up":
                    if (bee.Row - 1 >= 0 && bee.Row - 1 < matrix.GetLength(0)) // If the new position is within the matrix
                    {
                        matrix[bee.Row, bee.Col] = '.'; // Remove the Bee from the current position
                        char elementAtTheNewPosition = matrix[bee.Row - 1, bee.Col]; // Get the element at the new position
                        switch (elementAtTheNewPosition) // Check the element at the new position
                        {
                            case 'f': // It's a flower to be pollinated
                                pollinatedCount++; // Increment the count of the pollinated flowers
                                matrix[bee.Row - 1, bee.Col] = 'B'; // Move the Bee to the new position
                                bee.Row--; // Update the row position of the bee in the property
                                break;
                            case 'O': // It's a bonus move
                                if (bee.Row - 2 >= 0 && bee.Row - 2 < matrix.Length) // If the new position is within the matrix
                                {
                                    matrix[bee.Row - 1, bee.Col] = '.'; // Remove the 'O'
                                    elementAtTheNewPosition = matrix[bee.Row - 2, bee.Col];
                                    if (elementAtTheNewPosition == 'f') // On our bonus move if the element is flower
                                    {
                                        pollinatedCount++; // Increment the count of pollinated flowers
                                    }
                                    matrix[bee.Row - 2, bee.Col] = 'B'; // Move the Bee to the new position
                                    bee.Row -= 2;  // Update the row position of the Bee in the property
                                }
                                break;
                            default: // Its an empty position
                                matrix[bee.Row - 1, bee.Col] = 'B'; // Move the Bee to the new position
                                bee.Row--; // Update the row position of the Bee in the property
                                break;
                        }
                    }
                    else
                    {
                        matrix[bee.Row, bee.Col] = '.';
                        bee.Row = bee.Col = -1;
                        isLost = true;
                    }
                    break;
                case "down":
                    if (bee.Row + 1 >= 0 && bee.Row + 1 < matrix.GetLength(0)) // If the new position is within the matrix
                    {
                        matrix[bee.Row, bee.Col] = '.'; // Remove the Bee from the current position
                        char elementAtTheNewPosition = matrix[bee.Row + 1, bee.Col]; // Get the element at the new position
                        switch (elementAtTheNewPosition) // Check the element at the new position
                        {
                            case 'f': // It's a flower to be pollinated
                                pollinatedCount++; // Increment the count of the pollinated flowers
                                matrix[bee.Row + 1, bee.Col] = 'B'; // Move the Bee to the new position
                                bee.Row++; // Update the row position of the bee in the property
                                break;
                            case 'O': // It's a bonus move
                                if (bee.Row + 2 >= 0 && bee.Row + 2 < matrix.GetLength(0)) // If the new position is within the matrix
                                {
                                    matrix[bee.Row + 1, bee.Col] = '.'; // Remove the 'O'
                                    elementAtTheNewPosition = matrix[bee.Row + 2, bee.Col];
                                    if (elementAtTheNewPosition == 'f') // On our bonus move if the element is flower
                                    {
                                        pollinatedCount++; // Increment the count of pollinated flowers
                                    }
                                    matrix[bee.Row + 2, bee.Col] = 'B'; // Move the Bee to the new position
                                    bee.Row += 2; // Update the row position of the Bee in the property
                                }
                                break;
                            default: // Its an empty position
                                matrix[bee.Row + 1, bee.Col] = 'B'; // Move the Bee to the new position
                                bee.Row++; // Update the row position of the Bee in the property
                                break;
                        }
                    }
                    else
                    {
                        matrix[bee.Row, bee.Col] = '.';
                        bee.Row = bee.Col = -1;
                        isLost = true;
                    }
                    break;
                case "left":
                    if (bee.Col - 1 >= 0 && bee.Col - 1 < matrix.GetLength(1)) // If the new position is within the matrix
                    {
                        matrix[bee.Row, bee.Col] = '.'; // Remove the Bee from the current position
                        char elementAtTheNewPosition = matrix[bee.Row, bee.Col - 1]; // Get the element at the new position
                        switch (elementAtTheNewPosition) // Check the element at the new position
                        {
                            case 'f': // It's a flower to be pollinated
                                pollinatedCount++; // Increment the count of the pollinated flowers
                                matrix[bee.Row, bee.Col - 1] = 'B'; // Move the Bee to the new position
                                bee.Col--; // Update the row position of the bee in the property
                                break;
                            case 'O': // It's a bonus move
                                if (bee.Col - 2 >= 0 && bee.Col - 2 < matrix.GetLength(1)) // If the new position is within the matrix
                                {
                                    matrix[bee.Row, bee.Col - 1] = '.'; // Remove the 'O'
                                    elementAtTheNewPosition = matrix[bee.Row, bee.Col - 2];
                                    if (elementAtTheNewPosition == 'f') // On our bonus move if the element is flower
                                    {
                                        pollinatedCount++; // Increment the count of pollinated flowers
                                    }
                                    matrix[bee.Row, bee.Col - 2] = 'B'; // Move the Bee to the new position
                                    bee.Col -= 2; // Update the col position of the Bee in the property
                                }
                                break;
                            default: // Its an empty position
                                matrix[bee.Row, bee.Col - 1] = 'B'; // Move the Bee to the new position
                                bee.Col--; // Update the col position of the Bee in the property
                                break;
                        }
                    }
                    else
                    {
                        matrix[bee.Row, bee.Col] = '.';
                        bee.Row = bee.Col = -1;
                        isLost = true;
                    }
                    break;
                case "right":
                    if (bee.Col + 1 >= 0 && bee.Col + 1 < matrix.GetLength(1)) // If the new position is within the matrix
                    {
                        matrix[bee.Row, bee.Col] = '.'; // Remove the Bee from the current position
                        char elementAtTheNewPosition = matrix[bee.Row, bee.Col + 1]; // Get the element at the new position
                        switch (elementAtTheNewPosition) // Check the element at the new position
                        {
                            case 'f': // It's a flower to be pollinated
                                pollinatedCount++; // Increment the count of the pollinated flowers
                                matrix[bee.Row, bee.Col + 1] = 'B'; // Move the Bee to the new position
                                bee.Col++; // Update the col position of the bee in the property
                                break;
                            case 'O': // It's a bonus move
                                if (bee.Col + 2 < matrix.GetLength(1)) // If the new position is within the matrix
                                {
                                    matrix[bee.Row, bee.Col + 1] = '.'; // Remove the 'O'
                                    elementAtTheNewPosition = matrix[bee.Row, bee.Col + 2];
                                    if (elementAtTheNewPosition == 'f') // On our bonus move if the element is flower
                                    {
                                        pollinatedCount++; // Increment the count of pollinated flowers
                                    }
                                    matrix[bee.Row, bee.Col + 2] = 'B'; // Move the Bee to the new position
                                    bee.Col += 2; // Update the col position of the Bee in the property
                                }
                                break;
                            default: // Its an empty position
                                matrix[bee.Row, bee.Col + 1] = 'B'; // Move the Bee to the new position
                                bee.Col++; // Update the col position of the Bee in the property
                                break;
                        }
                    }
                    else
                    {
                        matrix[bee.Row, bee.Col] = '.';
                        bee.Row = bee.Col = -1;
                        isLost = true;
                    }
                    break;
            }
        }

        private class Bee
        {
            public int Row { get; set; }
            public int Col { get; set; }

            public Bee(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }
        }
    }
}