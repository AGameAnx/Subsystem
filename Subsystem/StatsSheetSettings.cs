using System.Collections.Generic;

namespace Subsystem
{
	public class StatsSheetSettings
	{
		public bool Generate { get; set; } = true;

		public bool UseEntityList { get; set; } = true;
		public Dictionary<string, string[]> EntityList { get; set; } = new Dictionary<string, string[]>()
		{
			{ "C_Carrier_MP", new string[] {
				"C_Carrier_Weapon_G2All_MP",
				"C_Carrier_Weapon_G2All_PenetrationShots_MP",
				"C_CarrierMissiles_Weapon_A2G_MP",
				"C_Carrier_Weapon_CruiseMissile_MP"
			} },
			{ "C_Sob_Carrier_MP", new string[] {
				"C_Sob_Carrier_Weapon_G2All_Dummy_MP",
				"C_Sob_Carrier_Railgun_Weapon_G2G_MP",
				"C_Sob_Carrier_Weapon_Nuke_MP"
			} },
			{ "G_Carrier_MP", new string[] {
				"G_Carrier_Weapon_G2All_MP",
				"G_Carrier_Weapon_G2All_APBULLETS_MP",
				"G_Carrier_Weapon_DefaultMissile_MP",
				"G_Carrier_Weapon_BarrageMissile_MP"
			} },
			{ "K_Carrier_MP", new string[] {
				"K_Carrier_Weapon_G2All_MP",
				"G_Carrier_Weapon_G2All_APBULLETS_MP",
				"K_Carrier_Weapon_DefaultMissile_MP",
				"K_Carrier_Weapon_BarrageMissile_MP"
			} },

			{ "C_Sob_NukeEmitter_MP", null },

			{ "C_Sob_PopcapScanner", null },
			{ "N_Gun_Turret_MP", null },
			{ "N_Missle_Turret_MP", null },
			{ "N_ECMField_MP", new string[] {} },
			{ "C_Probe_MP", new string[] {} },
			{ "G_Scanner_MP", new string[] {} },
			{ "K_ExplodingSkimmer_MP", new string[] {
				"K_ExplodingSkimmerSelfDestruct_Weapon_G2G_MP"
			} },
			
			{ "C_Harvester_MP", new string[] {
				"G_Harvester_Weapon_DemoCharge_MP",
			} },
			{ "G_Harvester_MP", new string[] {
				"G_Harvester_Weapon_DemoCharge_MP",
			} },
			{ "K_Harvester_MP", new string[] {
				"G_Harvester_Weapon_DemoCharge_MP",
			} },

			{ "C_Baserunner_MP", new string[] {
				"C_Baserunner_Weapon_G2G_MP"
			} },
			{ "C_Sob_Baserunner_MP", new string[] {
				"C_Sob_Baserunner_Weapon_G2G_MP"
			} },
			{ "G_Baserunner_MP", new string[] {
				"G_Baserunner_Weapon_G2G_MP"
			} },
			{ "K_Baserunner_MP", new string[] {
				"G_Baserunner_Weapon_G2G_MP"
			} },

			{ "C_SupportCruiser_MP", new string[] {
				"C_SupportCruiser_Weapon_Repair_Small_MP",
				"C_SupportCruiser_Weapon_G2A_MP"
			} },
			{ "C_Sob_SupportCruiser_MP", new string[] {
				"C_SupportCruiser_Weapon_Repair_Small_MP",
				"C_SupportCruiser_Weapon_G2A_MP"
			} },

			{ "G_SupportCruiser_MP", new string[] {
				"G_SupportCruiser_Weapon_G2G_MP"
			} },
			{ "K_SupportCruiser_MP", new string[] {
				"G_SupportCruiser_Weapon_G2G_MP"
			} },

			{ "C_HAC_MP", new string[] {
				"C_HAC_Weapon_G2G_MP"
			} },

			{ "C_Escort_MP", new string[] {
				"C_Escort_Weapon_G2G_MP"
			} },
			{ "C_Sob_Escort_MP", new string[] {
				"C_Escort_Weapon_G2G_MP"
			} },

			{ "G_SandSkimmer_MP", new string[] {
				"G_SandSkimmer_Weapon_G2G_MP"
			} },
			{ "K_Sandskimmer_MP", new string[] {
				"G_SandSkimmer_Weapon_G2G_MP"
			} },

			{ "C_Railgun_MP", new string[] {
				"C_Railgun_Weapon_G2G_MP"
			} },
			{ "C_Sob_Railgun_MP", new string[] {
				"C_Sob_Railgun_Weapon_G2G_MP"
			} },

			{ "G_StarHullTank_MP", new string[] {
				"G_StarHull_Weapon_G2G_MP",
				"G_StarHull_Weapon_G2GEMP_MP"
			} },
			{ "K_HeavyRailgun_MP", new string[] {
				"G_StarHull_Weapon_G2G_MP",
				"G_StarHull_Weapon_G2GEMP_MP"
			} },

			{ "G_Catamaran_MP", null },
			{ "K_AssaultShip_MP", null },

			{ "C_HAC_Upgrade01_MP", null },
			{ "G_Catamaran_Upgrade01_MP", null },
			{ "K_MissileShip_MP", null },

			{ "G_StarHull_Upgrade01_MP", null },
			{ "K_AssaultRailgun_MP", null },

			{ "C_Interceptor_MP", null },
			{ "G_Interceptor_MP", null },
			{ "K_Interceptor_MP", null },

			{ "C_Bomber_MP", null },
			{ "G_Bomber_MP", null },
			{ "K_Bomber_MP", null },

			{ "C_GunShip_MP", null },

			{ "G_BattleCruiser_MP", null },
			{ "C_Sob_AssaultCruiser_MP", null },

			{ "G_HonorGuard_MP", null },
			{ "K_HonorGuard_MP", null },

			{ "C_Battlecruiser_MP", new string[] {
				"C_Battlecruiser_Weapon_G2G_MP"
			} },
			{ "C_Sob_Battlecruiser_MP", new string[] {
				"C_Sob_Battlecruiser_Railgun_Weapon_G2G_MP"
			} },

			{ "C_ArtilleryCruiser_MP", null },
			{ "G_ArtilleryCruiser_MP", null },
			{ "K_ArtilleryCruiser_MP", null },
		};

		public string Filename { get; set; } = "generated_statssheet.html";
	}
}