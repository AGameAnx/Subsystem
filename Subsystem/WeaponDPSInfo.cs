
using System;
using System.Linq;
using System.Collections.Generic;
using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem
{
	public class WeaponDPSInfo
	{
		public double AverageShotsPerBurst { get; protected set; }
		public double TrueROF { get; protected set; }
		public double SequenceDuration { get; protected set; }
		public double PureDPS { get; protected set; }

		private WeaponAttributes _weapon;

		public WeaponAttributes Weapon
		{
			get { return _weapon; }
			set
			{
				_weapon = value;
				Recalc();
			}
		}

		public WeaponDPSInfo(WeaponAttributes weapon)
		{
			Weapon = weapon;
		}

		protected void Recalc()
		{
			double avgBurst = (Weapon.BurstPeriodMaxTimeMS + Weapon.BurstPeriodMinTimeMS) * 0.5;
			if (Weapon.RateOfFire > 0)
			{
				int burstVariance = Weapon.BurstPeriodMaxTimeMS - Weapon.BurstPeriodMinTimeMS;

				int shotDuration = Math.Max(1, 1000 / Weapon.RateOfFire);

				int shotsMin = Math.Max(1, Weapon.BurstPeriodMinTimeMS / shotDuration);
				int shotsMax = Math.Max(1, Weapon.BurstPeriodMaxTimeMS / shotDuration);

				int lowBracket = Math.Min(Weapon.BurstPeriodMinTimeMS, shotDuration - 1 - (Weapon.BurstPeriodMinTimeMS - shotsMin * shotDuration));
				int midBracket = Math.Max(0, shotsMax - shotsMin - 1) * shotDuration;
				int highBracket = shotsMin < shotsMax ? Weapon.BurstPeriodMaxTimeMS - shotsMax * shotDuration + 1 : 0;


				AverageShotsPerBurst = burstVariance == 0 ? shotsMin : (double)(shotsMin * lowBracket + (shotsMax + shotsMin) / 2 * midBracket + shotsMax * highBracket) / (lowBracket + midBracket + highBracket);
				TrueROF = AverageShotsPerBurst / avgBurst * 1000;

				SequenceDuration = (Weapon.WindUpTimeMS + (avgBurst + Weapon.CooldownTimeMS) * (Weapon.NumberOfBursts - 1) + avgBurst + Weapon.ReloadTimeMS) / 1000;

				PureDPS = Fixed64.UnsafeDoubleValue(Weapon.BaseDamagePerRound) * AverageShotsPerBurst * Weapon.NumberOfBursts / SequenceDuration;
			}
			else
			{
				AverageShotsPerBurst = 1;
				TrueROF = 1;

				SequenceDuration = (Weapon.WindUpTimeMS + (avgBurst + Weapon.CooldownTimeMS) * (Weapon.NumberOfBursts - 1) + avgBurst + Weapon.ReloadTimeMS) / 1000;

				PureDPS = Fixed64.UnsafeDoubleValue(Weapon.BaseDamagePerRound) * AverageShotsPerBurst * Weapon.NumberOfBursts / SequenceDuration;
			}
		}

		public Dictionary<WeaponRange, double> ArmorDPS(int armor = 0)
		{
			Dictionary<WeaponRange, double> result = new Dictionary<WeaponRange, double>();

			double dps = Math.Max(1, Fixed64.UnsafeDoubleValue(Weapon.BaseDamagePerRound) - armor * Weapon.DamagePacketsPerShot) * AverageShotsPerBurst * Weapon.NumberOfBursts / SequenceDuration;
			foreach (var range in Weapon.Ranges.OrderBy(r => r.Range))
				result[range.Range] = dps * Math.Min(1, Math.Max(0, Fixed64.UnsafeDoubleValue(range.Accuracy) * 0.01));

			return result;
		}
	}
}
