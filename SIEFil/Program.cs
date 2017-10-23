using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIEFil
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Ange SIE Filens sökväg");
			var sökväg = Console.ReadLine();
			var amount = 0M;
			var rowCount = 0;

			var streamReader = File.OpenText(sökväg);


			while (true)
			{
				var line = streamReader.ReadLine();

				if (line == null)
					break;

				if (line.Contains("#TRANS"))
				{
					var match = line.Split(' ');
					amount += decimal.Parse(match[6], CultureInfo.InvariantCulture);
					rowCount++;

					//Övning 2
					Console.WriteLine($"Kontonr: {match[4]} och belopp: {match[6]}");
				}

			}

				Console.WriteLine($"Totala antalet konton är: {rowCount}");
				Console.WriteLine($"Totala beloppet på kontona är: {amount}");
				Console.ReadKey();
			}
		}
	}

