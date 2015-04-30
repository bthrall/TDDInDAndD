using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EverCraftKata
{
	internal class Character
	{
		private int _armorClass = 10;
		private int _hitPoints = 5;

		public enum Alignment 
		{
			GOOD,
			EVIL,
			NEUTRAL
		};

		public Character()
		{
			Abilities = new object();
		}
		public string name { get; set; }

		public Alignment alignment { get; set; }

		public int armorClass
		{
			get { return _armorClass;  }	
			set { _armorClass = value; }	
		}

		public int hitPoints
		{
			get { return _hitPoints; }
			set { _hitPoints = value; }
		}

		internal int RollDie(int dieValue)
		{
			return dieValue;
		}

		internal bool IsAlive()
		{
			return hitPoints > 0;
		}

		public object Abilities { get; set; }
	}
}
