namespace CalculatorCS
{
	public class Program
	{
		public static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("\nCALCULATOR" +
				                  "\nPlease, if you use floating-point number use comma operator btw numbers, NOT dot" +
				                  "\nType start to run program or exit to quit the program");

				string firstInput = Console.ReadLine();
				if (firstInput == "exit")
					break;

				else
				{

					if (!TryGetNumber("Enter 1st number: ", out double number1))
						continue;

					Console.Write("Enter type for calculating ||   *  /  +  -   ||: ");
					var typeOfOperator = Convert.ToString(Console.ReadLine());

					if (typeOfOperator.Length != 1 || !"+-*/".Contains(typeOfOperator))
					{
						Console.WriteLine("Invalid operator, please enter valid operator");
						continue;
					}

					char checkedTypeOfOperator = Convert.ToChar(typeOfOperator);

					if (!TryGetNumber("Enter 2nd number: ", out double number2))
						continue;

					double result;

					switch (checkedTypeOfOperator)
					{
						case '+':
							result = number1 + number2;
							break;
						case '-':
							result = number1 - number2;
							break;
						case '*':
							result = number1 * number2;
							break;
						case '/':
							if (number2 == 0)
							{
								Console.WriteLine("Error: Division by zero.");
								continue;
							}
							else
							{
								result = number1 / number2;
								break;
							}

						default:
							Console.WriteLine("Invalid operator, please enter a valid operator.");
							continue;
					}

					Console.WriteLine($"Result: {result}");
					Console.WriteLine();
				}
			}
		}

		public static bool TryGetNumber(string prompt, out double number)
		{
			Console.WriteLine(prompt);
			string input = Console.ReadLine();
			if (double.TryParse(input, out number))
			{
				return true;
			}
			else
			{
				Console.WriteLine("Invalid input, enter valid number.");
				return false;
			}
		}
	}
}