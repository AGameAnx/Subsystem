using System.Collections.Generic;

namespace Subsystem
{
	public class StatsSheetSettings
	{

		public bool Generate { get; set; } = true;

		public string[] TechTrees = new string[]
		{
			"Coalition",
			"Gaalsi_MP",
			"Khaaneph",
			"SobanTechTree"
		};

		public class UnitSetting
		{
			public string readableName;
			public string[] weapons;

			public UnitSetting(string readableName = null, string[] weapons = null)
			{
				this.readableName = readableName;
				this.weapons = weapons;
			}
		}

		public Dictionary<string, UnitSetting> CarrierList { get; set; } = new Dictionary<string, UnitSetting>()
		{
			{ "C_Carrier_MP", new UnitSetting("C Carrier", new string[] {
				"C_Carrier_Weapon_G2All_MP",
				"C_Carrier_Weapon_G2All_PenetrationShots_MP",
				"C_CarrierMissiles_Weapon_A2G_MP",
				"C_Carrier_Weapon_CruiseMissile_MP"
			}) },
			{ "C_Sob_Carrier_MP", new UnitSetting("S Carrier", new string[] {
				"C_Sob_Carrier_Railgun_Weapon_G2G_MP",
				"C_Sob_CarrierMissiles_Weapon_A2G_MP",
				"C_Sob_Carrier_Weapon_Nuke_MP"
			}) },
			{ "G_Carrier_MP", new UnitSetting("G Carrier", new string[] {
				"G_Carrier_Weapon_G2All_MP",
				"G_Carrier_Weapon_G2All_APBULLETS_MP",
				"G_Carrier_Weapon_DefaultMissile_MP",
				"G_Carrier_Weapon_BarrageMissile_MP"
			}) },
			{ "K_Carrier_MP", new UnitSetting("K Carrier", new string[] {
				"K_Carrier_Weapon_G2All_MP",
				"G_Carrier_Weapon_G2All_APBULLETS_MP",
				"K_Carrier_Weapon_DefaultMissile_MP",
				"K_Carrier_Weapon_BarrageMissile_MP"
			}) }
		};

		public Dictionary<string, UnitSetting> UnitList { get; set; } = new Dictionary<string, UnitSetting>()
		{
			{ "C_Carrier_MP", new UnitSetting("C Carrier", new string[] {
				"C_Carrier_Weapon_G2All_MP",
				"C_Carrier_Weapon_G2All_PenetrationShots_MP",
				"C_CarrierMissiles_Weapon_A2G_MP",
				"C_Carrier_Weapon_CruiseMissile_MP"
			}) },
			{ "C_Sob_Carrier_MP", new UnitSetting("S Carrier", new string[] {
				"C_Sob_Carrier_Weapon_G2All_Dummy_MP",
				"C_Sob_Carrier_Railgun_Weapon_G2G_MP",
				"C_Sob_Carrier_Weapon_Nuke_MP"
			}) },
			{ "G_Carrier_MP", new UnitSetting("G Carrier", new string[] {
				"G_Carrier_Weapon_G2All_MP",
				"G_Carrier_Weapon_G2All_APBULLETS_MP",
				"G_Carrier_Weapon_DefaultMissile_MP",
				"G_Carrier_Weapon_BarrageMissile_MP"
			}) },
			{ "K_Carrier_MP", new UnitSetting("K Carrier", new string[] {
				"K_Carrier_Weapon_G2All_MP",
				"G_Carrier_Weapon_G2All_APBULLETS_MP",
				"K_Carrier_Weapon_DefaultMissile_MP",
				"K_Carrier_Weapon_BarrageMissile_MP"
			}) },

			{ "C_Sob_NukeEmitter_MP", new UnitSetting("Microwave Emitter") },

			{ "C_PopcapScanner", new UnitSetting("Logistics Module") },
			{ "C_Sob_PopcapScanner", new UnitSetting("Armed Logistics Module (ALM)") },
			{ "N_Gun_Turret_MP", new UnitSetting("Baserunner Turret") },
			{ "N_Missle_Turret_MP", new UnitSetting("Baserunner AA Turret") },
			{ "N_ECMField_MP", new UnitSetting("Baserunner Targeting Jammer", new string[] {}) },
			{ "C_Probe_MP", new UnitSetting("Baserunner Probe", new string[] {}) },
			{ "G_Scanner_MP", new UnitSetting("Baserunner Scanner", new string[] {}) },
			{ "K_ExplodingSkimmer_MP", new UnitSetting("Blast Drone", new string[] {
				"K_ExplodingSkimmerSelfDestruct_Weapon_G2G_MP"
			}) },

			{ "C_Harvester_MP", new UnitSetting("C/S Salvager", new string[] {
				"G_Harvester_Weapon_DemoCharge_MP",
			}) },
			{ "G_Harvester_MP", new UnitSetting("G Salvager", new string[] {
				"G_Harvester_Weapon_DemoCharge_MP",
			}) },
			{ "K_Harvester_MP", new UnitSetting("K Salvager", new string[] {
				"G_Harvester_Weapon_DemoCharge_MP",
			}) },

			{ "C_Baserunner_MP", new UnitSetting("C Baserunner", new string[] {
				"C_Baserunner_Weapon_G2G_MP"
			}) },
			{ "C_Sob_Baserunner_MP", new UnitSetting("S Baserunner", new string[] {
				"C_Sob_Baserunner_Weapon_G2G_MP"
			}) },
			{ "G_Baserunner_MP", new UnitSetting("G Baserunner", new string[] {
				"G_Baserunner_Weapon_G2G_MP"
			}) },
			{ "K_Baserunner_MP", new UnitSetting("K Baserunner", new string[] {
				"G_Baserunner_Weapon_G2G_MP"
			}) },

			{ "C_SupportCruiser_MP", new UnitSetting("C Support Cruiser", new string[] {
				"C_SupportCruiser_Weapon_Repair_Small_MP",
				"C_SupportCruiser_Weapon_G2A_MP",
				"C_SupportCruiser_Weapon_G2G_MP"
			}) },
			{ "C_Sob_SupportCruiser_MP", new UnitSetting("S Support Cruiser", new string[] {
				"C_SupportCruiser_Weapon_Repair_Small_MP",
				"C_SupportCruiser_Weapon_G2A_MP",
				"C_SupportCruiser_Weapon_G2G_MP"
			}) },

			{ "G_SupportCruiser_MP", new UnitSetting("G Production Cruiser", new string[] {
				"G_SupportCruiser_Weapon_G2G_MP"
			}) },
			{ "K_SupportCruiser_MP", new UnitSetting("K Production Cruiser", new string[] {
				"G_SupportCruiser_Weapon_G2G_MP",
				"K_SupportCruiser_WeaponBuff_G2G_MP"
			}) },

			{ "C_HAC_MP", new UnitSetting("AAV", new string[] {
				"C_HAC_Weapon_G2G_MP"
			}) },

			{ "C_Escort_MP", new UnitSetting("C LAV", new string[] {
				"C_Escort_Weapon_G2G_MP"
			}) },
			{ "C_Sob_Escort_MP", new UnitSetting("S LAV", new string[] {
				"C_Escort_Weapon_G2G_MP"
			}) },

			{ "G_SandSkimmer_MP", new UnitSetting("G Sandskimmer", new string[] {
				"G_SandSkimmer_Weapon_G2G_MP"
			}) },
			{ "K_Sandskimmer_MP", new UnitSetting("K Sandskimmer", new string[] {
				"G_SandSkimmer_Weapon_G2G_MP"
			}) },

			{ "C_Railgun_MP", new UnitSetting("C Railgun", new string[] {
				"C_Railgun_Weapon_G2G_MP"
			}) },
			{ "C_Sob_Railgun_MP", new UnitSetting("S Railgun", new string[] {
				"C_Sob_Railgun_Weapon_G2G_MP"
			}) },

			{ "G_StarHullTank_MP", new UnitSetting("G Heavy Railgun", new string[] {
				"G_StarHull_Weapon_G2G_MP",
				"G_StarHull_Weapon_G2GEMP_MP"
			}) },
			{ "K_HeavyRailgun_MP", new UnitSetting("K Heavy Railgun", new string[] {
				"G_StarHull_Weapon_G2G_MP",
				"G_StarHull_Weapon_G2GEMP_MP"
			}) },

			{ "G_Catamaran_MP", new UnitSetting("G Assault Ship") },
			{ "K_AssaultShip_MP", new UnitSetting("K Assault Ship") },

			{ "C_HAC_Upgrade01_MP", new UnitSetting("Missile Battery") },
			{ "G_Catamaran_Upgrade01_MP", new UnitSetting("G Missile Ship", new string[] {
				"G_Catamaran_Upgrade01_Weapon_G2A_MP",
				"G_Catamaran_Upgrade01_Weapon_G2G_MP",
				"G_Catamaran_Upgrade01_Weapon_G2A_Radar_MP"
			}) },
			{ "K_MissileShip_MP", new UnitSetting("K Missile Ship", new string[] {
				"G_Catamaran_Upgrade01_Weapon_G2A_MP",
				"G_Catamaran_Upgrade01_Weapon_G2G_MP",
				"G_Catamaran_Upgrade01_Weapon_G2A_Radar_MP"
			}) },

			{ "G_StarHull_Upgrade01_MP", new UnitSetting("G Assault Railgun") },
			{ "K_AssaultRailgun_MP", new UnitSetting("K Assault Railgun") },

			{ "C_Interceptor_MP", new UnitSetting("Strike Fighter", new string[] {
				"C_Interceptor_Weapon_A2G_MP"
			}) },
			{ "G_Interceptor_MP", new UnitSetting("G Interceptor") },
			{ "K_Interceptor_MP", new UnitSetting("K Interceptor") },

			{ "C_Bomber_MP", new UnitSetting("Tactical Bomber") },
			{ "G_Bomber_MP", new UnitSetting("G Precision Bomber") },
			{ "K_Bomber_MP", new UnitSetting("K Precision Bomber") },

			{ "C_GunShip_MP", new UnitSetting("Gunship") },

			{ "G_BattleCruiser_MP", new UnitSetting("C Assault Cruiser") },
			{ "C_Sob_AssaultCruiser_MP", new UnitSetting("S Assault Cruiser") },

			{ "G_HonorGuard_MP", new UnitSetting("G Honourguard Cruiser") },
			{ "K_HonorGuard_MP", new UnitSetting("K Honourguard Cruiser") },

			{ "C_Battlecruiser_MP", new UnitSetting("C Battlecruiser", new string[] {
				"C_Battlecruiser_Weapon_G2G_MP"
			}) },
			{ "C_Sob_Battlecruiser_MP", new UnitSetting("S Battlecruiser", new string[] {
				"C_Sob_Battlecruiser_Railgun_Weapon_G2G_MP"
			}) },

			{ "C_ArtilleryCruiser_MP", new UnitSetting("Artillery Cruiser") },
			{ "G_ArtilleryCruiser_MP", new UnitSetting("G Siege Cruiser") },
			{ "K_ArtilleryCruiser_MP", new UnitSetting("K Siege Cruiser") }
		};
		public string FilenameResearch { get; set; } = "Subsystem_stats_research.yml";
		public string FilenameGeneral { get; set; } = "Subsystem_stats_general.yml";
		public string FilenameCarrier { get; set; } = "Subsystem_stats_carrier.yml";
		public string FilenameExperience { get; set; } = "Subsystem_stats_experience.yml";
		public string FilenameMovement { get; set; } = "Subsystem_stats_movement.yml";
		public string FilenameDPS { get; set; } = "Subsystem_stats_dps.yml";
		//public string FilenameOther { get; set; } = "Subsystem_stats_other.yml";
	}
}