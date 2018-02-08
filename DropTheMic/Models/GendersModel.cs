using System;
using System.Collections.Generic;

namespace DropTheMic.Models
{
	public class GendersModel
	{
		public static int FromString(string gender)
		{
			switch(gender)
			{
				case "Male":
					return 1;

				case "Female":
					return 2;

				case "Undefined":
					return 3;
			}
			return 0;
		}

		public static string FromInt(int i)
		{
			switch(i)
			{
				case 1:
					return "Male";
				case 2:
					return "Female";
				case 3:
					return "Undefined";
			}
			return "";
		}

		private GendersModel()
		{
		}
	}
}
