using System;
using System.Collections.Generic;
using System.IO;


namespace ACHToggle
{
	
    class ACHToggle
	{
		private const int LINELENGTH = 94;

		public static void Main()
		{
			ToggleACH(@"C:\MW_Test_Files\ACHToggle-add-line-breaks.ach.txt");
		}

		public static void ToggleACH(string inFile, string outFile = (@"C:\MW_Test_Files\ACHToggle-add-line-breaks.ach.txt"))
		{
			while (true)
			{
				// code to test toggling - each time you press the t key the line breaks will be added or removed from the file
				if (Console.ReadLine() != "t")
				{
					break;
				}

				bool hasLineBreaks = false;

				List<string> fileData = new List<string>();

				using (StreamReader reader = new StreamReader(inFile))
				{
					while (!reader.EndOfStream)
					{
						fileData.Add(reader.ReadLine());
					}
				}

				if (fileData.Count > 1)
				{
					hasLineBreaks = true;
				}

				using (StreamWriter file = new StreamWriter(outFile))
				{
					foreach (string line in fileData)
					{
						if (hasLineBreaks)
						{
							file.Write(line);
						}
						else
						{
							for (int i = 0; i < line.Length - 1; i += LINELENGTH)
							{
								file.WriteLine(line.Substring(i, LINELENGTH));
							}

						}
					}
				}
			}
		}
	}
}
