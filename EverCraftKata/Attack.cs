using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraftKata
{
	class Attack
	{
		

		public bool Defend(Character attacker, Character defender, int dieRoll)
		{
			
			if (IsHit(defender, dieRoll))
			{
				if (IsCritical(dieRoll))
				{
					defender.hitPoints--;
				}

				defender.hitPoints--;
			}
			return IsHit(defender, dieRoll);
		}

		private static bool IsCritical(int dieRoll)
		{
			return dieRoll >= 20;
		}

		private static bool IsHit(Character defender, int dieRoll)
		{
			return dieRoll >= defender.armorClass;
		}
	}
}
