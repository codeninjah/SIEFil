using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SIEFil
{
	public class Program
	{


		static void Main(string[] args)
		{
			Console.WriteLine("Ange SIE Filens sökväg");
			var sökväg = Console.ReadLine();
			var amount = 0M;
			var amount2 = 0M;
			var testvar = "";
			var rowCount = 0;
			var accounts = new Dictionary<string, decimal>();

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
					var accountId = match[4];
					amount2 = decimal.Parse(match[6], CultureInfo.InvariantCulture);

					if (accounts.ContainsKey(accountId))
						accounts[accountId] += amount2;
					else
						accounts[accountId] = amount2;
				}

			}
			foreach (var entry in accounts.OrderBy(e => e.Key))
				Console.WriteLine($"{entry.Key} {entry.Value.ToString("F2")}");

			Console.WriteLine($"Totala antalet konton är: {rowCount}");
				Console.WriteLine($"Totala beloppet på kontona är: {amount}");
				Console.ReadKey();
			}
	}
	}

