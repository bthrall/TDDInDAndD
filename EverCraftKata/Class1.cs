using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EverCraftKata
{
	[TestFixture]
	public class EverCraftTests
	{
		Character hero;
		Attack attack;
		Character attacker;

		[SetUp]
		public void SetUp()
		{
			hero = new Character();
			attack = new Attack();
			attacker = new Character();
		}

		[Test]
		public void CharacterCanHaveName()
		{
			hero.name = "Bob";
			Assert.AreEqual(hero.name, "Bob");
		}

		[Test]
		public void CharacterHasAlignment()
		{
			hero.alignment = Character.Alignment.GOOD;
			Assert.AreEqual(hero.alignment, Character.Alignment.GOOD);
		}

		[Test]
		public void CharacterAlignmentMustBeAnEnum()
		{
			Assert.IsInstanceOf(typeof(Enum), hero.alignment);
		}

		[Test]
		public void CharacterAlignmentCanBeEvil()
		{
			hero.alignment = Character.Alignment.EVIL;
			Assert.AreEqual(hero.alignment, Character.Alignment.EVIL);
		}

		[Test]
		public void CharacterAlignmentCanBeNeutral()
		{
			hero.alignment = Character.Alignment.NEUTRAL;
			Assert.AreEqual(hero.alignment, Character.Alignment.NEUTRAL);
		}

		[Test]
		public void CharacterHasArmorClass()
		{
			Assert.AreEqual(hero.armorClass, 10);
		}

		[Test]
		public void CharacterHas5HitPointsByDefault()
		{
			Assert.AreEqual(hero.hitPoints, 5);
		}

		[Test]
		public void CharacterAttackRollIs20OrLess()
		{
			var dieRoll = hero.RollDie(19);
			Assert.IsTrue(dieRoll <= 20 && dieRoll >= 0);
		}

		[Test]
		public void CharacterIsHitIfAttackRollIsGreaterThanAC()
		{
			
			Assert.IsTrue(attack.Defend(attacker, hero, 12));
			
		}

		[Test]
		public void CharacterIsNotHitIfAttackRollIsLessThanAC()
		{
			hero.armorClass = 5;
			Assert.IsFalse(attack.Defend(attacker, hero, 3));
		}

		[Test]
		public void CharacterIsHitIfAttackRollIsEqualToAC()
		{
			hero.armorClass = 10;
			Assert.IsTrue(attack.Defend(attacker, hero, 10));
		}

		[Test]
		public void CharacterTakes1PointOfDamageIfHit()
		{

			hero.hitPoints = 10;
			hero.armorClass = 5;

			attack.Defend(attacker, hero, 10);
			Assert.AreEqual(9, hero.hitPoints);
		}

		[Test]
		public void CharacterHasLessHealthAfterSuccessfulAttack()
		{
			hero.hitPoints = 15;
			hero.armorClass = 10;
			attack.Defend(attacker, hero, 13);
			Assert.AreEqual(14, hero.hitPoints);
		}

		[Test]
		public void CharacterTakesNoDamageIfAttackUnsuccessful()
		{
			hero.hitPoints = 15;
			hero.armorClass = 10;
			attack.Defend(attacker, hero, 3);
			Assert.AreEqual(15, hero.hitPoints);
		}

		[Test]
		public void CharacterTakesDoubleDamageOnCriticalHit()
		{
			hero.hitPoints = 15;
			hero.armorClass = 10;
			attack.Defend(attacker, hero, 20);
			Assert.AreEqual(13, hero.hitPoints);
		}

		[Test]
		public void CharacterIsDeadIfHPIs0()
		{
			hero.hitPoints = 0;
			Assert.IsFalse(hero.IsAlive());
		}

		[Test]
		public void CharacterIsAliveIfHPIsGreaterThan0()
		{
			hero.hitPoints = 1;
			Assert.IsTrue(hero.IsAlive());
		}

		[Test]
		public void CharacterHasAbilities()
		{
			Assert.IsNotNull(hero.Abilities);
		}
	}
}
