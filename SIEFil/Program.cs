﻿using System;
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

			//Console.WriteLine(sökväg);

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

					var accountId = match[4];
					amount += decimal.Parse(match[6], CultureInfo.InvariantCulture);
					rowCount++;
				}

			}

				Console.WriteLine($"Totala antalet konton är: {rowCount}");
				Console.WriteLine($"Totala beloppet på kontona är: {amount}");
				Console.ReadKey();
			}
		}
	}

