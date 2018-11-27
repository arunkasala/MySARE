using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Xml;
using System.Web.UI;
using System.Data.SqlClient;
using System.Collections;

namespace daikon
{
    public class DaikonSearchProfile : DaikonProfile
    {
        protected string condTerms;

        public string CondTerms
        {
            get { return condTerms; }
            set { condTerms = value; }
        }
        protected string condRegion;

        public string CondRegion
        {
            get { return condRegion; }
            set { condRegion = value; }
        }
        protected string condState;

        public string CondState
        {
            get { return condState; }
            set { condState = value; }
        }
        protected int condProjType;

        public int CondProjType
        {
            get { return condProjType; }
            set { condProjType = value; }
        }
        protected bool condApproved;

        public bool CondApproved
        {
            get { return condApproved; }
            set { condApproved = value; }
        }
        protected bool orderRanked;

        public bool OrderRanked
        {
            get { return orderRanked; }
            set { orderRanked = value; }
        }
        protected bool orderDesc;

        public bool OrderDesc
        {
            get { return orderDesc; }
            set { orderDesc = value; }
        }
        protected int rowsPerPage;

        public int RowsPerPage
        {
            get { return rowsPerPage; }
            set { rowsPerPage = value; }
        }
        protected int thisPage;

        public int ThisPage
        {
            get { return thisPage; }
            set { thisPage = value; }
        }

        protected int cata_intgfrs;

        public int Cata_intgfrs
        {
            get { return cata_intgfrs; }
            set { cata_intgfrs = value; }
        }
        protected int cata_edu_trn;

        public int Cata_edu_trn
        {
            get { return cata_edu_trn; }
            set { cata_edu_trn = value; }
        }
        protected int cata_cropprd;

        public int Cata_cropprd
        {
            get { return cata_cropprd; }
            set { cata_cropprd = value; }
        }
        protected int cata_econmkt;

        public int Cata_econmkt
        {
            get { return cata_econmkt; }
            set { cata_econmkt = value; }
        }
        protected int cata_animprd;

        public int Cata_animprd
        {
            get { return cata_animprd; }
            set { cata_animprd = value; }
        }
        protected int cata_commdev;

        public int Cata_commdev
        {
            get { return cata_commdev; }
            set { cata_commdev = value; }
        }
        protected int cata_pestmgt;

        public int Cata_pestmgt
        {
            get { return cata_pestmgt; }
            set { cata_pestmgt = value; }
        }
        protected int cata_qoflife;

        public int Cata_qoflife
        {
            get { return cata_qoflife; }
            set { cata_qoflife = value; }
        }
        protected int cata_soilmgt;

        public int Cata_soilmgt
        {
            get { return cata_soilmgt; }
            set { cata_soilmgt = value; }
        }
        protected int cata_nresenv;

        public int Cata_nresenv
        {
            get { return cata_nresenv; }
            set { cata_nresenv = value; }
        }
        protected int cata_energy;

        public int Cata_energy
        {
            get { return cata_energy; }
            set { cata_energy = value; }
        }
        protected int cata_other;

        public int Cata_other
        {
            get { return cata_other; }
            set { cata_other = value; }
        }

        protected int catb_beef;

        public int Catb_beef
        {
            get { return catb_beef; }
            set { catb_beef = value; }
        }
        protected int catb_grain;

        public int Catb_grain
        {
            get { return catb_grain; }
            set { catb_grain = value; }
        }
        protected int catb_fruitsm;

        public int Catb_fruitsm
        {
            get { return catb_fruitsm; }
            set { catb_fruitsm = value; }
        }
        protected int catb_dairy;

        public int Catb_dairy
        {
            get { return catb_dairy; }
            set { catb_dairy = value; }
        }
        protected int catb_hay;

        public int Catb_hay
        {
            get { return catb_hay; }
            set { catb_hay = value; }
        }
        protected int catb_nuts;

        public int Catb_nuts
        {
            get { return catb_nuts; }
            set { catb_nuts = value; }
        }
        protected int catb_swine;

        public int Catb_swine
        {
            get { return catb_swine; }
            set { catb_swine = value; }
        }
        protected int catb_silage;

        public int Catb_silage
        {
            get { return catb_silage; }
            set { catb_silage = value; }
        }
        protected int catb_ornturf;

        public int Catb_ornturf
        {
            get { return catb_ornturf; }
            set { catb_ornturf = value; }
        }
        protected int catb_sheep;

        public int Catb_sheep
        {
            get { return catb_sheep; }
            set { catb_sheep = value; }
        }
        protected int catb_vegcrp;

        public int Catb_vegcrp
        {
            get { return catb_vegcrp; }
            set { catb_vegcrp = value; }
        }
        protected int catb_trees;

        public int Catb_trees
        {
            get { return catb_trees; }
            set { catb_trees = value; }
        }
        protected int catb_poultry;

        public int Catb_poultry
        {
            get { return catb_poultry; }
            set { catb_poultry = value; }
        }
        protected int catb_fruittr;

        public int Catb_fruittr
        {
            get { return catb_fruittr; }
            set { catb_fruittr = value; }
        }
        protected int catb_oilcrp;

        public int Catb_oilcrp
        {
            get { return catb_oilcrp; }
            set { catb_oilcrp = value; }
        }
        protected int catb_sugarcrp;

        public int Catb_sugarcrp
        {
            get { return catb_sugarcrp; }
            set { catb_sugarcrp = value; }
        }
        protected int catb_other;

        public int Catb_other
        {
            get { return catb_other; }
            set { catb_other = value; }
        }
    }
    
    public class DaikonProfile // : IComparable
    {
        protected int assocCoreID;
        protected int profileCoreID;
		protected int profileID;
		protected bool extensionLvl1;
        protected bool extensionLvl2;
        protected String categoryA;
        protected String catAother;
        protected String categoryB;
        protected String catBother;
        protected bool aud_farmranchers;
        protected bool aud_educators;
        protected bool aud_researchers;
        protected bool aud_consumers;
        protected bool techlvl_beginner;
        protected bool techlvl_intermediate;
        protected bool techlvl_advanced;
        protected bool inv_planning;
        protected int inv_planningcount;
        protected bool inv_present;
        protected int inv_presentcount;
        protected int inv_numparticipants;
        protected bool inv_research;
        protected int inv_researchcount;
        protected bool inv_land;
        protected int inv_landcount;
        protected int inv_numideas;
        protected bool inv_extplanning;
        protected bool inv_extapplied;
        protected bool intgfrs_AgroecosystemAnalysis;
        protected bool intgfrs_WholeFarmPlanning;
        protected bool intgfrs_HolisticManagement;
        protected bool intgfrs_OrganicAgriculture;
        protected bool intgfrs_Permaculture;
        protected String intgfrs_Other;
        protected bool cropprd_Agroforestry;
        protected bool cropprd_FoliarFeeding;
        protected bool cropprd_NutrientCycling;
        protected bool cropprd_StripCropping;
        protected bool cropprd_BiologicalInoculants;
        protected bool cropprd_Forestry;
        protected bool cropprd_OrganicFertilizers;
        protected bool cropprd_StubbleMulching;
        protected bool cropprd_ContinuousCropping;
        protected bool cropprd_GreenManures;
        protected bool cropprd_OrganicMatter;
        protected bool cropprd_TissueAnalysis;
        protected bool cropprd_CoverCrops;
        protected bool cropprd_Intercropping;
        protected bool cropprd_Permaculture;
        protected bool cropprd_Transitioning;
        protected bool cropprd_DoubleCropping;
        protected bool cropprd_MinimumTillage;
        protected bool cropprd_ReducedApplications;
        protected bool cropprd_Earthworms;
        protected bool cropprd_MultipleCropping;
        protected bool cropprd_RelayCropping;
        protected bool cropprd_Fallow;
        protected bool cropprd_MunicipalWastes;
        protected bool cropprd_RidgeTillage;
        protected bool cropprd_Fertigation;
        protected bool cropprd_NoTill;
        protected bool cropprd_SoilAnalysis;
        protected bool cropprd_CatchCrops;
        protected bool cropprd_CropRotation;
        protected bool cropprd_CropBreeding;
        protected bool cropprd_Irrigation;
        protected String cropprd_Other;
        protected bool animprd_AlternativeFeedstuffs;
        protected bool animprd_FeedRations;
        protected bool animprd_MultispeciesGrazing;
        protected bool animprd_StockpiledForages;
        protected bool animprd_AlternativeHousing;
        protected bool animprd_FreeRange;
        protected bool animprd_PastureFertility;
        protected bool animprd_Vaccines;
        protected bool animprd_AlternParasiteControl;
        protected bool animprd_HerbalMedicines;
        protected bool animprd_PastureRenovation;
        protected bool animprd_WateringSystem;
        protected bool animprd_AnimalProtection;
        protected bool animprd_Homeopathy;
        protected bool animprd_PreventivePractices;
        protected bool animprd_WinterForage;
        protected bool animprd_Composting;
        protected bool animprd_Implants;
        protected bool animprd_Probiotics;
        protected bool animprd_ContinuousGrazing;
        protected bool animprd_Inoculants;
        protected bool animprd_RangeImprovement;
        protected bool animprd_FeedAdditives;
        protected bool animprd_ManureManagement;
        protected bool animprd_RotationalGrazing;
        protected bool animprd_FeedFormulation;
        protected bool animprd_MineralSupplements;
        protected bool animprd_ShadeShelter;
        protected bool animprd_Therapeutics;
        protected bool animprd_LivestockBreeding;
        protected bool animprd_StockingRate;
        protected bool animprd_grazingmanagement;
        protected String animprd_Other;
        protected bool pestmgt_Allelopathy;
        protected bool pestmgt_EconomicThreshold;
        protected bool pestmgt_MechanicalControl;
        protected bool pestmgt_SmotherCrops;
        protected bool pestmgt_BiologicalControl;
        protected bool pestmgt_Eradication;
        protected bool pestmgt_PhysicalControl;
        protected bool pestmgt_Traps;
        protected bool pestmgt_BiorationalPesticides;
        protected bool pestmgt_Flame;
        protected bool pestmgt_PlasticMulching;
        protected bool pestmgt_TrapCrops;
        protected bool pestmgt_BotanicalPesticides;
        protected bool pestmgt_FieldMonitoring;
        protected bool pestmgt_PrecisionCultivation;
        protected bool pestmgt_VegetativeMulching;
        protected bool pestmgt_ChemicalControl;
        protected bool pestmgt_GeneticResistance;
        protected bool pestmgt_PrecisionHerbicideUse;
        protected bool pestmgt_WeatherMonitoring;
        protected bool pestmgt_Competition;
        protected bool pestmgt_IPM;
        protected bool pestmgt_Prevention;
        protected bool pestmgt_WeedEcology;
        protected bool pestmgt_CompostExtracts;
        protected bool pestmgt_KilledMulches;
        protected bool pestmgt_RowCovers;
        protected bool pestmgt_WeederGeese;
        protected bool pestmgt_CulturalControl;
        protected bool pestmgt_LivingMulches;
        protected bool pestmgt_Sanitation;
        protected bool pestmgt_DiseaseVectors;
        protected bool pestmgt_MatingDisruption;
        protected bool pestmgt_SoilSolarization;
        protected String pestmgt_Other;
        protected bool soilmgt_NutrientMineralization;
        protected bool soilmgt_SoilMicrobiology;
        protected bool soilmgt_SoilOrganicMatter;
        protected bool soilmgt_SoilQuality;
        protected bool soilmgt_CarbonSequestration;
        protected bool soilmgt_SoilChemistry;
        protected bool soilmgt_SoilPhysics;
        protected String soilmgt_Other;
        protected bool nresenv_Afforestation;
        protected bool nresenv_GrassHedges;
        protected bool nresenv_RiparianPlantings;
        protected bool nresenv_Wildlife;
        protected bool nresenv_Biodiversity;
        protected bool nresenv_GrassWaterways;
        protected bool nresenv_RiverbankProtection;
        protected bool nresenv_Windbreaks;
        protected bool nresenv_Biosphere;
        protected bool nresenv_HabitatEnhancement;
        protected bool nresenv_SoilStabilization;
        protected bool nresenv_WoodyHedges;
        protected bool nresenv_ConservationTillage;
        protected bool nresenv_Hedgerows;
        protected bool nresenv_Terraces;
        protected bool nresenv_ContourCultivation;
        protected bool nresenv_Indicators;
        protected bool nresenv_Wetlands;
        protected String nresenv_Other;
        protected bool edtrain_CaseStudy;
        protected bool edtrain_Demonstration;
        protected bool edtrain_FocusGroup;
        protected bool edtrain_StudyCircle;
        protected bool edtrain_Conference;
        protected bool edtrain_Display;
        protected bool edtrain_Mentor;
        protected bool edtrain_Workshop;
        protected bool edtrain_Curriculum;
        protected bool edtrain_Extension;
        protected bool edtrain_Network;
        protected bool edtrain_Database;
        protected bool edtrain_FactSheet;
        protected bool edtrain_OnFarmResearch;
        protected bool edtrain_DecisionSupportSystem;
        protected bool edtrain_FarmerToFarmer;
        protected bool edtrain_ParticipatoryResearch;
        protected bool edtrain_YouthEducation;
        protected String edtrain_Other;
        protected bool econmkt_AlternativeEnterprise;
        protected bool econmkt_CSA;
        protected bool econmkt_FeasibilityStudy;
        protected bool econmkt_RiskManagement;
        protected bool econmkt_Budget;
        protected bool econmkt_CostAndReturns;
        protected bool econmkt_FinancialAnalysis;
        protected bool econmkt_ValueAdded;
        protected bool econmkt_Cooperatives;
        protected bool econmkt_DirectMarketing;
        protected bool econmkt_MarketStudy;
        protected bool econmkt_FoodProductQualitySafety;
        protected bool econmkt_LaborEmployment;
        protected bool econmkt_Ecommerce;
        protected bool econmkt_FarmToInstitution;
        protected String econmkt_Other;
        protected bool commdev_InfrastructureAnalysis;
        protected bool commdev_TechnicalAssistance;
        protected bool commdev_NewBusinessOpportunities;
        protected bool commdev_Partnerships;
        protected bool commdev_UrbanAgriculture;
        protected bool commdev_PublicParticipation;
        protected bool commdev_UrbanRuralIntegration;
        protected bool commdev_LocalRegionalCommunityFoodSystems;
        protected bool commdev_Agritourism;
        protected bool commdev_CommunityPlanning;
        protected bool commdev_PublicPolicy;
        protected bool commdev_LeadershipDevelopment;
        protected bool commdev_EthnicDifferencesCulturalDemographicChange;
        protected String commdev_Other;
        protected bool qoflife_AnalysisOfPersonalFamilyLife;
        protected bool qoflife_SocialCapitol;
        protected bool qoflife_SustainabilityMeasures;
        protected bool qoflife_CommunityServices;
        protected bool qoflife_SocialNetworks;
        protected bool qoflife_EmploymentOpportunities;
        protected bool qoflife_SocialPsychologicalIndicators;
        protected String qoflife_Other;
        protected bool energy_BioenergyBiofuels;
        protected bool energy_WindPower;
        protected bool energy_EnergyUseConsumption;
        protected bool energy_SolarEnergy;
        protected bool energy_EnergyConservationEfficiency;
        protected string energy_Other;
        protected bool commPlAgr_Barley;
        protected bool commPlAgr_GrassLegumeHay;
        protected bool commPlAgr_Peanuts;
        protected bool commPlAgr_Sorghum;
        protected bool commPlAgr_Sweetpotatoes;
        protected bool commPlAgr_Canola;
        protected bool commPlAgr_LegumeHay;
        protected bool commPlAgr_Potatoes;
        protected bool commPlAgr_Soybeans;
        protected bool commPlAgr_Tobacco;
        protected bool commPlAgr_Corn;
        protected bool commPlAgr_Hops;
        protected bool commPlAgr_Rapeseed;
        protected bool commPlAgr_Spelt;
        protected bool commPlAgr_Wheat;
        protected bool commPlAgr_Cotton;
        protected bool commPlAgr_Kenaf;
        protected bool commPlAgr_Rice;
        protected bool commPlAgr_Sugarbeets;
        protected bool commPlAgr_Flax;
        protected bool commPlAgr_Millet;
        protected bool commPlAgr_Rye;
        protected bool commPlAgr_Sugarcane;
        protected bool commPlAgr_GrassHay;
        protected bool commPlAgr_Oats;
        protected bool commPlAgr_Safflower;
        protected bool commPlAgr_Sunflower;
        protected String commPlAgr_Other;
        protected bool commPlVeg_Artichokes;
        protected bool commPlVeg_Cabbage;
        protected bool commPlVeg_Escarole;
        protected bool commPlVeg_Onions;
        protected bool commPlVeg_SweetCorn;
        protected bool commPlVeg_Asparagus;
        protected bool commPlVeg_Carrots;
        protected bool commPlVeg_Garlic;
        protected bool commPlVeg_Parsnips;
        protected bool commPlVeg_Tomatoes;
        protected bool commPlVeg_Beans;
        protected bool commPlVeg_Cauliflower;
        protected bool commPlVeg_Greens;
        protected bool commPlVeg_Peas;
        protected bool commPlVeg_Turnips;
        protected bool commPlVeg_Beets;
        protected bool commPlVeg_Celery;
        protected bool commPlVeg_Kale;
        protected bool commPlVeg_Peppers;
        protected bool commPlVeg_Watermelon;
        protected bool commPlVeg_Broccoli;
        protected bool commPlVeg_Cucumbers;
        protected bool commPlVeg_Lentils;
        protected bool commPlVeg_Rutabagas;
        protected bool commPlVeg_BrusselSprouts;
        protected bool commPlVeg_Eggplant;
        protected bool commPlVeg_Lettuce;
        protected bool commPlVeg_Spinach;
        protected bool commplveg_leeks;
        protected bool commPlVeg_Pumpkins;
        protected bool commPlVeg_Squashes;
        protected bool commPlVeg_Radishes;
        protected String commPlVeg_Other;
        protected bool commPlFruit_Apples;
        protected bool commPlFruit_Cherries;
        protected bool commPlFruit_Lemons;
        protected bool commPlFruit_Peaches;
        protected bool commPlFruit_Strawberries;
        protected bool commPlFruit_Apricots;
        protected bool commPlFruit_Cranberries;
        protected bool commPlFruit_Limes;
        protected bool commPlFruit_Pears;
        protected bool commPlFruit_Tangerines;
        protected bool commPlFruit_Avocados;
        protected bool commPlFruit_Figs;
        protected bool commPlFruit_Melons;
        protected bool commPlFruit_Pineapples;
        protected bool commPlFruit_Bananas;
        protected bool commPlFruit_Grapefruit;
        protected bool commPlFruit_Olives;
        protected bool commPlFruit_Plums;
        protected bool commPlFruit_Berries;
        protected bool commPlFruit_Grapes;
        protected bool commPlFruit_Oranges;
        protected bool commPlFruit_Quinces;
        protected bool commPlFruit_Brambles;
        protected bool commPlFruit_Blueberries;
        protected String commPlFruit_Other;
        protected bool commPlNuts_Almonds;
        protected bool commPlNuts_Hazelnuts;
        protected bool commPlNuts_Pecans;
        protected bool commPlNuts_Walnuts;
        protected bool commplnuts_chestnuts;
        protected bool commPlNuts_Macadamia;
        protected bool commPlNuts_Pistachios;
        protected String commPlNuts_Other;
        protected bool commPlAdd_Herbs;
        protected bool commPlAdd_Ornamentals;
        protected bool commPlAdd_Trees;
        protected bool commPlAdd_Mushrooms;
        protected bool commPlAdd_NativePlants;
        protected String commPlAdd_Other;
        protected bool commAnim_Beef;
        protected bool commAnim_Chicken;
        protected bool commAnim_Rabbits;
        protected bool commAnim_Swine;
        protected bool commAnim_Dairy;
        protected bool commAnim_Goats;
        protected bool commAnim_Sheep;
        protected bool commAnim_Turkeys;
        protected String commAnim_Other;
        protected bool commMisc_Bees;
        protected bool commMisc_Fish;
        protected bool commMisc_Ratites;
        protected bool commMisc_Shellfish;
        protected String commMisc_Other;
        protected bool submitted;
        protected String createdDate;
        protected String createdBy;
        protected String updatedDate;
        protected String updatedBy;
        protected String approvedDate;
        protected String approvedBy;
        protected bool adminOverride;
        protected String adminOverrideDate;
        protected String adminOverrideBy;
        protected bool approved;

        public DaikonProfile()
        {
            profileID = 0;
        }

        public DaikonProfile(int coreID)
        {
            string daikonSQL;
            string daikonConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection daikonConnection;
            SqlCommand daikonCommand;
            SqlDataReader daikonDataReader;

            daikonConnection = new SqlConnection(daikonConnString);

            daikonSQL = "DaikonProfilesGetProfileForCore";
            daikonCommand = new SqlCommand(daikonSQL, daikonConnection);
            daikonCommand.CommandType = CommandType.StoredProcedure;
            daikonCommand.Parameters.Add("@coreID", SqlDbType.Int);

            daikonCommand.Parameters["@coreID"].Value = coreID;

            daikonConnection.Open();
            daikonDataReader = daikonCommand.ExecuteReader();

            if (daikonDataReader.HasRows)
            {
                daikonDataReader.Read();

                assocCoreID = Convert.ToInt32(daikonDataReader["assocCoreID"]);
				profileCoreID = Convert.ToInt32(daikonDataReader["profileCoreID"]);
				profileID = Convert.ToInt32(daikonDataReader["profileID"]);
               
                categoryA = daikonDataReader["categoryA"].ToString();
                catAother = daikonDataReader["catAother"].ToString();
                categoryB = daikonDataReader["categoryB"].ToString();
                catBother = daikonDataReader["catBother"].ToString();
               
                aud_farmranchers = (bool)daikonDataReader["aud_farmranchers"];
                aud_educators = (bool)daikonDataReader["aud_educators"];
                aud_researchers = (bool)daikonDataReader["aud_researchers"];
                aud_consumers = (bool)daikonDataReader["aud_consumers"];
                techlvl_beginner = (bool)daikonDataReader["techlvl_beginner"];
                techlvl_intermediate = (bool)daikonDataReader["techlvl_intermediate"];
                techlvl_advanced = (bool)daikonDataReader["techlvl_advanced"];
                inv_planning = (bool)daikonDataReader["inv_planning"];
                inv_planningcount = Convert.ToInt32(daikonDataReader["inv_planningcount"]);
                inv_present = (bool)daikonDataReader["inv_present"];
                inv_presentcount = Convert.ToInt32(daikonDataReader["inv_presentcount"]);
                inv_numparticipants = Convert.ToInt32(daikonDataReader["inv_numparticipants"]);
                inv_research = (bool)daikonDataReader["inv_research"];
                inv_researchcount = Convert.ToInt32(daikonDataReader["inv_researchcount"]);
                inv_land = (bool)daikonDataReader["inv_land"];
                inv_landcount = Convert.ToInt32(daikonDataReader["inv_landcount"]);
                inv_numideas = Convert.ToInt32(daikonDataReader["inv_numideas"]);
                inv_extplanning = (bool)daikonDataReader["inv_extplanning"];
                inv_extapplied = (bool)daikonDataReader["inv_extapplied"];
                intgfrs_AgroecosystemAnalysis = (bool)daikonDataReader["intgfrs_AgroecosystemAnalysis"];
                intgfrs_WholeFarmPlanning = (bool)daikonDataReader["intgfrs_WholeFarmPlanning"];
                intgfrs_HolisticManagement = (bool)daikonDataReader["intgfrs_HolisticManagement"];
                intgfrs_OrganicAgriculture = (bool)daikonDataReader["intgfrs_OrganicAgriculture"];
                intgfrs_Permaculture = (bool)daikonDataReader["intgfrs_Permaculture"];
                intgfrs_Other = daikonDataReader["intgfrs_Other"].ToString();
                cropprd_Agroforestry = (bool)daikonDataReader["cropprd_Agroforestry"];
                cropprd_FoliarFeeding = (bool)daikonDataReader["cropprd_FoliarFeeding"];
                cropprd_NutrientCycling = (bool)daikonDataReader["cropprd_NutrientCycling"];
                cropprd_StripCropping = (bool)daikonDataReader["cropprd_StripCropping"];
                cropprd_BiologicalInoculants = (bool)daikonDataReader["cropprd_BiologicalInoculants"];
                cropprd_Forestry = (bool)daikonDataReader["cropprd_Forestry"];
                cropprd_OrganicFertilizers = (bool)daikonDataReader["cropprd_OrganicFertilizers"];
                cropprd_StubbleMulching = (bool)daikonDataReader["cropprd_StubbleMulching"];
                cropprd_ContinuousCropping = (bool)daikonDataReader["cropprd_ContinuousCropping"];
                cropprd_GreenManures = (bool)daikonDataReader["cropprd_GreenManures"];
                cropprd_OrganicMatter = (bool)daikonDataReader["cropprd_OrganicMatter"];
                cropprd_TissueAnalysis = (bool)daikonDataReader["cropprd_TissueAnalysis"];
                cropprd_CoverCrops = (bool)daikonDataReader["cropprd_CoverCrops"];
                cropprd_Intercropping = (bool)daikonDataReader["cropprd_Intercropping"];
                cropprd_Permaculture = (bool)daikonDataReader["cropprd_Permaculture"];
                cropprd_Transitioning = (bool)daikonDataReader["cropprd_Transitioning"];
                cropprd_DoubleCropping = (bool)daikonDataReader["cropprd_DoubleCropping"];
                cropprd_MinimumTillage = (bool)daikonDataReader["cropprd_MinimumTillage"];
                cropprd_ReducedApplications = (bool)daikonDataReader["cropprd_ReducedApplications"];
                cropprd_Earthworms = (bool)daikonDataReader["cropprd_Earthworms"];
                cropprd_MultipleCropping = (bool)daikonDataReader["cropprd_MultipleCropping"];
                cropprd_RelayCropping = (bool)daikonDataReader["cropprd_RelayCropping"];
                cropprd_Fallow = (bool)daikonDataReader["cropprd_Fallow"];
                cropprd_MunicipalWastes = (bool)daikonDataReader["cropprd_MunicipalWastes"];
                cropprd_RidgeTillage = (bool)daikonDataReader["cropprd_RidgeTillage"];
                cropprd_Fertigation = (bool)daikonDataReader["cropprd_Fertigation"];
                cropprd_NoTill = (bool)daikonDataReader["cropprd_NoTill"];
                cropprd_SoilAnalysis = (bool)daikonDataReader["cropprd_SoilAnalysis"];
                cropprd_CatchCrops = (bool)daikonDataReader["cropprd_CatchCrops"];
                cropprd_CropRotation = (bool)daikonDataReader["cropprd_CropRotation"];
                cropprd_CropBreeding = (bool)daikonDataReader["cropprd_CropBreeding"];
                cropprd_Irrigation = (bool)daikonDataReader["cropprd_Irrigation"];
                cropprd_Other = daikonDataReader["cropprd_Other"].ToString();
                animprd_AlternativeFeedstuffs = (bool)daikonDataReader["animprd_AlternativeFeedstuffs"];
                animprd_FeedRations = (bool)daikonDataReader["animprd_FeedRations"];
                animprd_MultispeciesGrazing = (bool)daikonDataReader["animprd_MultispeciesGrazing"];
                animprd_StockpiledForages = (bool)daikonDataReader["animprd_StockpiledForages"];
                animprd_AlternativeHousing = (bool)daikonDataReader["animprd_AlternativeHousing"];
                animprd_FreeRange = (bool)daikonDataReader["animprd_FreeRange"];
                animprd_PastureFertility = (bool)daikonDataReader["animprd_PastureFertility"];
                animprd_Vaccines = (bool)daikonDataReader["animprd_Vaccines"];
                animprd_AlternParasiteControl = (bool)daikonDataReader["animprd_AlternParasiteControl"];
                animprd_HerbalMedicines = (bool)daikonDataReader["animprd_HerbalMedicines"];
                animprd_PastureRenovation = (bool)daikonDataReader["animprd_PastureRenovation"];
                animprd_WateringSystem = (bool)daikonDataReader["animprd_WateringSystem"];
                animprd_AnimalProtection = (bool)daikonDataReader["animprd_AnimalProtection"];
                animprd_Homeopathy = (bool)daikonDataReader["animprd_Homeopathy"];
                animprd_PreventivePractices = (bool)daikonDataReader["animprd_PreventivePractices"];
                animprd_WinterForage = (bool)daikonDataReader["animprd_WinterForage"];
                animprd_Composting = (bool)daikonDataReader["animprd_Composting"];
                animprd_Implants = (bool)daikonDataReader["animprd_Implants"];
                animprd_Probiotics = (bool)daikonDataReader["animprd_Probiotics"];
                animprd_ContinuousGrazing = (bool)daikonDataReader["animprd_ContinuousGrazing"];
                animprd_Inoculants = (bool)daikonDataReader["animprd_Inoculants"];
                animprd_RangeImprovement = (bool)daikonDataReader["animprd_RangeImprovement"];
                animprd_FeedAdditives = (bool)daikonDataReader["animprd_FeedAdditives"];
                animprd_ManureManagement = (bool)daikonDataReader["animprd_ManureManagement"];
                animprd_RotationalGrazing = (bool)daikonDataReader["animprd_RotationalGrazing"];
                animprd_FeedFormulation = (bool)daikonDataReader["animprd_FeedFormulation"];
                animprd_MineralSupplements = (bool)daikonDataReader["animprd_MineralSupplements"];
                animprd_ShadeShelter = (bool)daikonDataReader["animprd_ShadeShelter"];
                animprd_Therapeutics = (bool)daikonDataReader["animprd_Therapeutics"];
                animprd_LivestockBreeding = (bool)daikonDataReader["animprd_LivestockBreeding"];
                animprd_StockingRate = (bool)daikonDataReader["animprd_StockingRate"];
                animprd_grazingmanagement = (bool)daikonDataReader["animprd_grazingmanagement"];
                animprd_Other = daikonDataReader["animprd_Other"].ToString();
                pestmgt_Allelopathy = (bool)daikonDataReader["pestmgt_Allelopathy"];
                pestmgt_EconomicThreshold = (bool)daikonDataReader["pestmgt_EconomicThreshold"];
                pestmgt_MechanicalControl = (bool)daikonDataReader["pestmgt_MechanicalControl"];
                pestmgt_SmotherCrops = (bool)daikonDataReader["pestmgt_SmotherCrops"];
                pestmgt_BiologicalControl = (bool)daikonDataReader["pestmgt_BiologicalControl"];
                pestmgt_Eradication = (bool)daikonDataReader["pestmgt_Eradication"];
                pestmgt_PhysicalControl = (bool)daikonDataReader["pestmgt_PhysicalControl"];
                pestmgt_Traps = (bool)daikonDataReader["pestmgt_Traps"];
                pestmgt_BiorationalPesticides = (bool)daikonDataReader["pestmgt_BiorationalPesticides"];
                pestmgt_Flame = (bool)daikonDataReader["pestmgt_Flame"];
                pestmgt_PlasticMulching = (bool)daikonDataReader["pestmgt_PlasticMulching"];
                pestmgt_TrapCrops = (bool)daikonDataReader["pestmgt_TrapCrops"];
                pestmgt_BotanicalPesticides = (bool)daikonDataReader["pestmgt_BotanicalPesticides"];
                pestmgt_FieldMonitoring = (bool)daikonDataReader["pestmgt_FieldMonitoring"];
                pestmgt_PrecisionCultivation = (bool)daikonDataReader["pestmgt_PrecisionCultivation"];
                pestmgt_VegetativeMulching = (bool)daikonDataReader["pestmgt_VegetativeMulching"];
                pestmgt_ChemicalControl = (bool)daikonDataReader["pestmgt_ChemicalControl"];
                pestmgt_GeneticResistance = (bool)daikonDataReader["pestmgt_GeneticResistance"];
                pestmgt_PrecisionHerbicideUse = (bool)daikonDataReader["pestmgt_PrecisionHerbicideUse"];
                pestmgt_WeatherMonitoring = (bool)daikonDataReader["pestmgt_WeatherMonitoring"];
                pestmgt_Competition = (bool)daikonDataReader["pestmgt_Competition"];
                pestmgt_IPM = (bool)daikonDataReader["pestmgt_IPM"];
                pestmgt_Prevention = (bool)daikonDataReader["pestmgt_Prevention"];
                pestmgt_WeedEcology = (bool)daikonDataReader["pestmgt_WeedEcology"];
                pestmgt_CompostExtracts = (bool)daikonDataReader["pestmgt_CompostExtracts"];
                pestmgt_KilledMulches = (bool)daikonDataReader["pestmgt_KilledMulches"];
                pestmgt_RowCovers = (bool)daikonDataReader["pestmgt_RowCovers"];
                pestmgt_WeederGeese = (bool)daikonDataReader["pestmgt_WeederGeese"];
                pestmgt_CulturalControl = (bool)daikonDataReader["pestmgt_CulturalControl"];
                pestmgt_LivingMulches = (bool)daikonDataReader["pestmgt_LivingMulches"];
                pestmgt_Sanitation = (bool)daikonDataReader["pestmgt_Sanitation"];
                pestmgt_DiseaseVectors = (bool)daikonDataReader["pestmgt_DiseaseVectors"];
                pestmgt_MatingDisruption = (bool)daikonDataReader["pestmgt_MatingDisruption"];
                pestmgt_SoilSolarization = (bool)daikonDataReader["pestmgt_SoilSolarization"];
                pestmgt_Other = daikonDataReader["pestmgt_Other"].ToString();
                soilmgt_NutrientMineralization = (bool)daikonDataReader["soilmgt_NutrientMineralization"];
                soilmgt_SoilMicrobiology = (bool)daikonDataReader["soilmgt_SoilMicrobiology"];
                soilmgt_SoilOrganicMatter = (bool)daikonDataReader["soilmgt_SoilOrganicMatter"];
                soilmgt_SoilQuality = (bool)daikonDataReader["soilmgt_SoilQuality"];
                soilmgt_CarbonSequestration = (bool)daikonDataReader["soilmgt_CarbonSequestration"];
                soilmgt_SoilChemistry = (bool)daikonDataReader["soilmgt_SoilChemistry"];
                soilmgt_SoilPhysics = (bool)daikonDataReader["soilmgt_SoilPhysics"];
                soilmgt_Other = daikonDataReader["soilmgt_Other"].ToString();
                nresenv_Afforestation = (bool)daikonDataReader["nresenv_Afforestation"];
                nresenv_GrassHedges = (bool)daikonDataReader["nresenv_GrassHedges"];
                nresenv_RiparianPlantings = (bool)daikonDataReader["nresenv_RiparianPlantings"];
                nresenv_Wildlife = (bool)daikonDataReader["nresenv_Wildlife"];
                nresenv_Biodiversity = (bool)daikonDataReader["nresenv_Biodiversity"];
                nresenv_GrassWaterways = (bool)daikonDataReader["nresenv_GrassWaterways"];
                nresenv_RiverbankProtection = (bool)daikonDataReader["nresenv_RiverbankProtection"];
                nresenv_Windbreaks = (bool)daikonDataReader["nresenv_Windbreaks"];
                nresenv_Biosphere = (bool)daikonDataReader["nresenv_Biosphere"];
                nresenv_HabitatEnhancement = (bool)daikonDataReader["nresenv_HabitatEnhancement"];
                nresenv_SoilStabilization = (bool)daikonDataReader["nresenv_SoilStabilization"];
                nresenv_WoodyHedges = (bool)daikonDataReader["nresenv_WoodyHedges"];
                nresenv_ConservationTillage = (bool)daikonDataReader["nresenv_ConservationTillage"];
                nresenv_Hedgerows = (bool)daikonDataReader["nresenv_Hedgerows"];
                nresenv_Terraces = (bool)daikonDataReader["nresenv_Terraces"];
                nresenv_ContourCultivation = (bool)daikonDataReader["nresenv_ContourCultivation"];
                nresenv_Indicators = (bool)daikonDataReader["nresenv_Indicators"];
                nresenv_Wetlands = (bool)daikonDataReader["nresenv_Wetlands"];
                nresenv_Other = daikonDataReader["nresenv_Other"].ToString();
                edtrain_CaseStudy = (bool)daikonDataReader["edtrain_CaseStudy"];
                edtrain_Demonstration = (bool)daikonDataReader["edtrain_Demonstration"];
                edtrain_FocusGroup = (bool)daikonDataReader["edtrain_FocusGroup"];
                edtrain_StudyCircle = (bool)daikonDataReader["edtrain_StudyCircle"];
                edtrain_Conference = (bool)daikonDataReader["edtrain_Conference"];
                edtrain_Display = (bool)daikonDataReader["edtrain_Display"];
                edtrain_Mentor = (bool)daikonDataReader["edtrain_Mentor"];
                edtrain_Workshop = (bool)daikonDataReader["edtrain_Workshop"];
                edtrain_Curriculum = (bool)daikonDataReader["edtrain_Curriculum"];
                edtrain_Extension = (bool)daikonDataReader["edtrain_Extension"];
                edtrain_Network = (bool)daikonDataReader["edtrain_Network"];
                edtrain_Database = (bool)daikonDataReader["edtrain_Database"];
                edtrain_FactSheet = (bool)daikonDataReader["edtrain_FactSheet"];
                edtrain_OnFarmResearch = (bool)daikonDataReader["edtrain_OnFarmResearch"];
                edtrain_DecisionSupportSystem = (bool)daikonDataReader["edtrain_DecisionSupportSystem"];
                edtrain_FarmerToFarmer = (bool)daikonDataReader["edtrain_FarmerToFarmer"];
                edtrain_ParticipatoryResearch = (bool)daikonDataReader["edtrain_ParticipatoryResearch"];
                edtrain_YouthEducation = (bool)daikonDataReader["edtrain_YouthEducation"];
                edtrain_Other = daikonDataReader["edtrain_Other"].ToString();
                econmkt_AlternativeEnterprise = (bool)daikonDataReader["econmkt_AlternativeEnterprise"];
                econmkt_CSA = (bool)daikonDataReader["econmkt_CSA"];
                econmkt_FeasibilityStudy = (bool)daikonDataReader["econmkt_FeasibilityStudy"];
                econmkt_RiskManagement = (bool)daikonDataReader["econmkt_RiskManagement"];
                econmkt_Budget = (bool)daikonDataReader["econmkt_Budget"];
                econmkt_CostAndReturns = (bool)daikonDataReader["econmkt_CostAndReturns"];
                econmkt_FinancialAnalysis = (bool)daikonDataReader["econmkt_FinancialAnalysis"];
                econmkt_ValueAdded = (bool)daikonDataReader["econmkt_ValueAdded"];
                econmkt_Cooperatives = (bool)daikonDataReader["econmkt_Cooperatives"];
                econmkt_DirectMarketing = (bool)daikonDataReader["econmkt_DirectMarketing"];
                econmkt_MarketStudy = (bool)daikonDataReader["econmkt_MarketStudy"];
                econmkt_FoodProductQualitySafety = (bool)daikonDataReader["econmkt_FoodProductQualitySafety"];
                econmkt_LaborEmployment = (bool)daikonDataReader["econmkt_LaborEmployment"];
                econmkt_Ecommerce = (bool)daikonDataReader["econmkt_Ecommerce"];
                econmkt_FarmToInstitution = (bool)daikonDataReader["econmkt_FarmToInstitution"];
                econmkt_Other = daikonDataReader["econmkt_Other"].ToString();
                commdev_InfrastructureAnalysis = (bool)daikonDataReader["commdev_InfrastructureAnalysis"];
                commdev_TechnicalAssistance = (bool)daikonDataReader["commdev_TechnicalAssistance"];
                commdev_NewBusinessOpportunities = (bool)daikonDataReader["commdev_NewBusinessOpportunities"];
                commdev_Partnerships = (bool)daikonDataReader["commdev_Partnerships"];
                commdev_UrbanAgriculture = (bool)daikonDataReader["commdev_UrbanAgriculture"];
                commdev_PublicParticipation = (bool)daikonDataReader["commdev_PublicParticipation"];
                commdev_UrbanRuralIntegration = (bool)daikonDataReader["commdev_UrbanRuralIntegration"];
                commdev_LocalRegionalCommunityFoodSystems = (bool)daikonDataReader["commdev_LocalRegionalCommunityFoodSystems"];
                commdev_Agritourism = (bool)daikonDataReader["commdev_Agritourism"];
                commdev_CommunityPlanning = (bool)daikonDataReader["commdev_CommunityPlanning"];
                commdev_PublicPolicy = (bool)daikonDataReader["commdev_PublicPolicy"];
                commdev_LeadershipDevelopment = (bool)daikonDataReader["commdev_LeadershipDevelopment"];
                commdev_EthnicDifferencesCulturalDemographicChange = (bool)daikonDataReader["commdev_EthnicDifferencesCulturalDemographicChange"];
                commdev_Other = daikonDataReader["commdev_Other"].ToString();
                qoflife_AnalysisOfPersonalFamilyLife = (bool)daikonDataReader["qoflife_AnalysisOfPersonalFamilyLife"];
                qoflife_SocialCapitol = (bool)daikonDataReader["qoflife_SocialCapitol"];
                qoflife_SustainabilityMeasures = (bool)daikonDataReader["qoflife_SustainabilityMeasures"];
                qoflife_CommunityServices = (bool)daikonDataReader["qoflife_CommunityServices"];
                qoflife_SocialNetworks = (bool)daikonDataReader["qoflife_SocialNetworks"];
                qoflife_EmploymentOpportunities = (bool)daikonDataReader["qoflife_EmploymentOpportunities"];
                qoflife_SocialPsychologicalIndicators = (bool)daikonDataReader["qoflife_SocialPsychologicalIndicators"];
                qoflife_Other = daikonDataReader["qoflife_Other"].ToString();
                energy_BioenergyBiofuels = (bool)daikonDataReader["energy_BioenergyBiofuels"];
                energy_WindPower = (bool)daikonDataReader["energy_WindPower"];
                energy_EnergyUseConsumption = (bool)daikonDataReader["energy_EnergyUseConsumption"];
                energy_SolarEnergy = (bool)daikonDataReader["energy_SolarEnergy"];
                energy_EnergyConservationEfficiency = (bool)daikonDataReader["energy_EnergyConservationEfficiency"];
                energy_Other = daikonDataReader["energy_Other"].ToString();
                commPlAgr_Barley = (bool)daikonDataReader["commPlAgr_Barley"];
                commPlAgr_GrassLegumeHay = (bool)daikonDataReader["commPlAgr_GrassLegumeHay"];
                commPlAgr_Peanuts = (bool)daikonDataReader["commPlAgr_Peanuts"];
                commPlAgr_Sorghum = (bool)daikonDataReader["commPlAgr_Sorghum"];
                commPlAgr_Sweetpotatoes = (bool)daikonDataReader["commPlAgr_Sweetpotatoes"];
                commPlAgr_Canola = (bool)daikonDataReader["commPlAgr_Canola"];
                commPlAgr_LegumeHay = (bool)daikonDataReader["commPlAgr_LegumeHay"];
                commPlAgr_Potatoes = (bool)daikonDataReader["commPlAgr_Potatoes"];
                commPlAgr_Soybeans = (bool)daikonDataReader["commPlAgr_Soybeans"];
                commPlAgr_Tobacco = (bool)daikonDataReader["commPlAgr_Tobacco"];
                commPlAgr_Corn = (bool)daikonDataReader["commPlAgr_Corn"];
                commPlAgr_Hops = (bool)daikonDataReader["commPlAgr_Hops"];
                commPlAgr_Rapeseed = (bool)daikonDataReader["commPlAgr_Rapeseed"];
                commPlAgr_Spelt = (bool)daikonDataReader["commPlAgr_Spelt"];
                commPlAgr_Wheat = (bool)daikonDataReader["commPlAgr_Wheat"];
                commPlAgr_Cotton = (bool)daikonDataReader["commPlAgr_Cotton"];
                commPlAgr_Kenaf = (bool)daikonDataReader["commPlAgr_Kenaf"];
                commPlAgr_Rice = (bool)daikonDataReader["commPlAgr_Rice"];
                commPlAgr_Sugarbeets = (bool)daikonDataReader["commPlAgr_Sugarbeets"];
                commPlAgr_Flax = (bool)daikonDataReader["commPlAgr_Flax"];
                commPlAgr_Millet = (bool)daikonDataReader["commPlAgr_Millet"];
                commPlAgr_Rye = (bool)daikonDataReader["commPlAgr_Rye"];
                commPlAgr_Sugarcane = (bool)daikonDataReader["commPlAgr_Sugarcane"];
                commPlAgr_GrassHay = (bool)daikonDataReader["commPlAgr_GrassHay"];
                commPlAgr_Oats = (bool)daikonDataReader["commPlAgr_Oats"];
                commPlAgr_Safflower = (bool)daikonDataReader["commPlAgr_Safflower"];
                commPlAgr_Sunflower = (bool)daikonDataReader["commPlAgr_Sunflower"];
                commPlAgr_Other = daikonDataReader["commPlAgr_Other"].ToString();
                commPlVeg_Artichokes = (bool)daikonDataReader["commPlVeg_Artichokes"];
                commPlVeg_Cabbage = (bool)daikonDataReader["commPlVeg_Cabbage"];
                commPlVeg_Escarole = (bool)daikonDataReader["commPlVeg_Escarole"];
                commPlVeg_Onions = (bool)daikonDataReader["commPlVeg_Onions"];
                commPlVeg_SweetCorn = (bool)daikonDataReader["commPlVeg_SweetCorn"];
                commPlVeg_Asparagus = (bool)daikonDataReader["commPlVeg_Asparagus"];
                commPlVeg_Carrots = (bool)daikonDataReader["commPlVeg_Carrots"];
                commPlVeg_Garlic = (bool)daikonDataReader["commPlVeg_Garlic"];
                commPlVeg_Parsnips = (bool)daikonDataReader["commPlVeg_Parsnips"];
                commPlVeg_Tomatoes = (bool)daikonDataReader["commPlVeg_Tomatoes"];
                commPlVeg_Beans = (bool)daikonDataReader["commPlVeg_Beans"];
                commPlVeg_Cauliflower = (bool)daikonDataReader["commPlVeg_Cauliflower"];
                commPlVeg_Greens = (bool)daikonDataReader["commPlVeg_Greens"];
                commPlVeg_Peas = (bool)daikonDataReader["commPlVeg_Peas"];
                commPlVeg_Turnips = (bool)daikonDataReader["commPlVeg_Turnips"];
                commPlVeg_Beets = (bool)daikonDataReader["commPlVeg_Beets"];
                commPlVeg_Celery = (bool)daikonDataReader["commPlVeg_Celery"];
                commPlVeg_Kale = (bool)daikonDataReader["commPlVeg_Kale"];
                commPlVeg_Peppers = (bool)daikonDataReader["commPlVeg_Peppers"];
                commPlVeg_Watermelon = (bool)daikonDataReader["commPlVeg_Watermelon"];
                commPlVeg_Broccoli = (bool)daikonDataReader["commPlVeg_Broccoli"];
                commPlVeg_Cucumbers = (bool)daikonDataReader["commPlVeg_Cucumbers"];
                commPlVeg_Lentils = (bool)daikonDataReader["commPlVeg_Lentils"];
                commPlVeg_Rutabagas = (bool)daikonDataReader["commPlVeg_Rutabagas"];
                commPlVeg_BrusselSprouts = (bool)daikonDataReader["commPlVeg_BrusselSprouts"];
                commPlVeg_Eggplant = (bool)daikonDataReader["commPlVeg_Eggplant"];
                commPlVeg_Lettuce = (bool)daikonDataReader["commPlVeg_Lettuce"];
                commPlVeg_Spinach = (bool)daikonDataReader["commPlVeg_Spinach"];
                commplveg_leeks = (bool)daikonDataReader["commplveg_leeks"];
                commPlVeg_Pumpkins = (bool)daikonDataReader["commPlVeg_Pumpkins"];
                commPlVeg_Squashes = (bool)daikonDataReader["commPlVeg_Squashes"];
                commPlVeg_Radishes = (bool)daikonDataReader["commPlVeg_Radishes"];
                commPlVeg_Other = daikonDataReader["commPlVeg_Other"].ToString();
                commPlFruit_Apples = (bool)daikonDataReader["commPlFruit_Apples"];
                commPlFruit_Cherries = (bool)daikonDataReader["commPlFruit_Cherries"];
                commPlFruit_Lemons = (bool)daikonDataReader["commPlFruit_Lemons"];
                commPlFruit_Peaches = (bool)daikonDataReader["commPlFruit_Peaches"];
                commPlFruit_Strawberries = (bool)daikonDataReader["commPlFruit_Strawberries"];
                commPlFruit_Apricots = (bool)daikonDataReader["commPlFruit_Apricots"];
                commPlFruit_Cranberries = (bool)daikonDataReader["commPlFruit_Cranberries"];
                commPlFruit_Limes = (bool)daikonDataReader["commPlFruit_Limes"];
                commPlFruit_Pears = (bool)daikonDataReader["commPlFruit_Pears"];
                commPlFruit_Tangerines = (bool)daikonDataReader["commPlFruit_Tangerines"];
                commPlFruit_Avocados = (bool)daikonDataReader["commPlFruit_Avocados"];
                commPlFruit_Figs = (bool)daikonDataReader["commPlFruit_Figs"];
                commPlFruit_Melons = (bool)daikonDataReader["commPlFruit_Melons"];
                commPlFruit_Pineapples = (bool)daikonDataReader["commPlFruit_Pineapples"];
                commPlFruit_Bananas = (bool)daikonDataReader["commPlFruit_Bananas"];
                commPlFruit_Grapefruit = (bool)daikonDataReader["commPlFruit_Grapefruit"];
                commPlFruit_Olives = (bool)daikonDataReader["commPlFruit_Olives"];
                commPlFruit_Plums = (bool)daikonDataReader["commPlFruit_Plums"];
                commPlFruit_Berries = (bool)daikonDataReader["commPlFruit_Berries"];
                commPlFruit_Grapes = (bool)daikonDataReader["commPlFruit_Grapes"];
                commPlFruit_Oranges = (bool)daikonDataReader["commPlFruit_Oranges"];
                commPlFruit_Quinces = (bool)daikonDataReader["commPlFruit_Quinces"];
                commPlFruit_Brambles = (bool)daikonDataReader["commPlFruit_Brambles"];
                commPlFruit_Blueberries = (bool)daikonDataReader["commPlFruit_Blueberries"];
                commPlFruit_Other = daikonDataReader["commPlFruit_Other"].ToString();
                commPlNuts_Almonds = (bool)daikonDataReader["commPlNuts_Almonds"];
                commPlNuts_Hazelnuts = (bool)daikonDataReader["commPlNuts_Hazelnuts"];
                commPlNuts_Pecans = (bool)daikonDataReader["commPlNuts_Pecans"];
                commPlNuts_Walnuts = (bool)daikonDataReader["commPlNuts_Walnuts"];
                commplnuts_chestnuts = (bool)daikonDataReader["commplnuts_chestnuts"];
                commPlNuts_Macadamia = (bool)daikonDataReader["commPlNuts_Macadamia"];
                commPlNuts_Pistachios = (bool)daikonDataReader["commPlNuts_Pistachios"];
                commPlNuts_Other = daikonDataReader["commPlNuts_Other"].ToString();
                commPlAdd_Herbs = (bool)daikonDataReader["commPlAdd_Herbs"];
                commPlAdd_Ornamentals = (bool)daikonDataReader["commPlAdd_Ornamentals"];
                commPlAdd_Trees = (bool)daikonDataReader["commPlAdd_Trees"];
                commPlAdd_Mushrooms = (bool)daikonDataReader["commPlAdd_Mushrooms"];
                commPlAdd_NativePlants = (bool)daikonDataReader["commPlAdd_NativePlants"];
                commPlAdd_Other = daikonDataReader["commPlAdd_Other"].ToString();
                commAnim_Beef = (bool)daikonDataReader["commAnim_Beef"];
                commAnim_Chicken = (bool)daikonDataReader["commAnim_Chicken"];
                commAnim_Rabbits = (bool)daikonDataReader["commAnim_Rabbits"];
                commAnim_Swine = (bool)daikonDataReader["commAnim_Swine"];
                commAnim_Dairy = (bool)daikonDataReader["commAnim_Dairy"];
                commAnim_Goats = (bool)daikonDataReader["commAnim_Goats"];
                commAnim_Sheep = (bool)daikonDataReader["commAnim_Sheep"];
                commAnim_Turkeys = (bool)daikonDataReader["commAnim_Turkeys"];
                commAnim_Other = daikonDataReader["commAnim_Other"].ToString();
                commMisc_Bees = (bool)daikonDataReader["commMisc_Bees"];
                commMisc_Fish = (bool)daikonDataReader["commMisc_Fish"];
                commMisc_Ratites = (bool)daikonDataReader["commMisc_Ratites"];
                commMisc_Shellfish = (bool)daikonDataReader["commMisc_Shellfish"];
                commMisc_Other = daikonDataReader["commMisc_Other"].ToString();
                submitted = (bool)daikonDataReader["submitted"];
                createdDate = daikonDataReader["createdDate"].ToString();
                createdBy = daikonDataReader["createdBy"].ToString();
                updatedDate = daikonDataReader["updatedDate"].ToString();
                updatedBy = daikonDataReader["updatedBy"].ToString();
                approvedDate = daikonDataReader["approvedDate"].ToString();
                approvedBy = daikonDataReader["approvedBy"].ToString();
                adminOverride = (bool)daikonDataReader["adminOverride"];
                adminOverrideDate = daikonDataReader["adminOverrideDate"].ToString();
                adminOverrideBy = daikonDataReader["adminOverrideBy"].ToString();
                if (daikonDataReader["approved"].ToString() == "")
                    approved = false;
                else
                    approved = (bool)daikonDataReader["approved"];
            }
            daikonConnection.Dispose();
        }

        public DaikonProfile(string projNum)
        {
      		string daikonSQL;
			string daikonConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
			SqlConnection daikonConnection;
			SqlCommand daikonCommand;
			SqlDataReader daikonDataReader;

			daikonConnection = new SqlConnection(daikonConnString);

            daikonSQL = "DaikonProfilesGetProfileForProject";
			daikonCommand = new SqlCommand(daikonSQL, daikonConnection);
			daikonCommand.CommandType = CommandType.StoredProcedure;
			daikonCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);

            daikonCommand.Parameters["@proj_num"].Value = projNum;
			
			daikonConnection.Open();
			daikonDataReader = daikonCommand.ExecuteReader();

            if (daikonDataReader.HasRows)
            {
                daikonDataReader.Read();

                assocCoreID = Convert.ToInt32(daikonDataReader["assocCoreID"]);
				profileCoreID = Convert.ToInt32(daikonDataReader["profileCoreID"]);
				profileID = Convert.ToInt32(daikonDataReader["profileID"]);
                
                categoryA = daikonDataReader["categoryA"].ToString();
                catAother = daikonDataReader["catAother"].ToString();
                categoryB = daikonDataReader["categoryB"].ToString();
                catBother = daikonDataReader["catBother"].ToString();
                
                aud_farmranchers = (bool)daikonDataReader["aud_farmranchers"];
                aud_educators = (bool)daikonDataReader["aud_educators"];
                aud_researchers = (bool)daikonDataReader["aud_researchers"];
                aud_consumers = (bool)daikonDataReader["aud_consumers"];
                techlvl_beginner = (bool)daikonDataReader["techlvl_beginner"];
                techlvl_intermediate = (bool)daikonDataReader["techlvl_intermediate"];
                techlvl_advanced = (bool)daikonDataReader["techlvl_advanced"];
                inv_planning = (bool)daikonDataReader["inv_planning"];
                inv_planningcount = Convert.ToInt32(daikonDataReader["inv_planningcount"]);
                inv_present = (bool)daikonDataReader["inv_present"];
                inv_presentcount = Convert.ToInt32(daikonDataReader["inv_presentcount"]);
                inv_numparticipants = Convert.ToInt32(daikonDataReader["inv_numparticipants"]);
                inv_research = (bool)daikonDataReader["inv_research"];
                inv_researchcount = Convert.ToInt32(daikonDataReader["inv_researchcount"]);
                inv_land = (bool)daikonDataReader["inv_land"];
                inv_landcount = Convert.ToInt32(daikonDataReader["inv_landcount"]);
                inv_numideas = Convert.ToInt32(daikonDataReader["inv_numideas"]);
                inv_extplanning = (bool)daikonDataReader["inv_extplanning"];
                inv_extapplied = (bool)daikonDataReader["inv_extapplied"];
                intgfrs_AgroecosystemAnalysis = (bool)daikonDataReader["intgfrs_AgroecosystemAnalysis"];
                intgfrs_WholeFarmPlanning = (bool)daikonDataReader["intgfrs_WholeFarmPlanning"];
                intgfrs_HolisticManagement = (bool)daikonDataReader["intgfrs_HolisticManagement"];
                intgfrs_OrganicAgriculture = (bool)daikonDataReader["intgfrs_OrganicAgriculture"];
                intgfrs_Permaculture = (bool)daikonDataReader["intgfrs_Permaculture"];
                intgfrs_Other = daikonDataReader["intgfrs_Other"].ToString();
                cropprd_Agroforestry = (bool)daikonDataReader["cropprd_Agroforestry"];
                cropprd_FoliarFeeding = (bool)daikonDataReader["cropprd_FoliarFeeding"];
                cropprd_NutrientCycling = (bool)daikonDataReader["cropprd_NutrientCycling"];
                cropprd_StripCropping = (bool)daikonDataReader["cropprd_StripCropping"];
                cropprd_BiologicalInoculants = (bool)daikonDataReader["cropprd_BiologicalInoculants"];
                cropprd_Forestry = (bool)daikonDataReader["cropprd_Forestry"];
                cropprd_OrganicFertilizers = (bool)daikonDataReader["cropprd_OrganicFertilizers"];
                cropprd_StubbleMulching = (bool)daikonDataReader["cropprd_StubbleMulching"];
                cropprd_ContinuousCropping = (bool)daikonDataReader["cropprd_ContinuousCropping"];
                cropprd_GreenManures = (bool)daikonDataReader["cropprd_GreenManures"];
                cropprd_OrganicMatter = (bool)daikonDataReader["cropprd_OrganicMatter"];
                cropprd_TissueAnalysis = (bool)daikonDataReader["cropprd_TissueAnalysis"];
                cropprd_CoverCrops = (bool)daikonDataReader["cropprd_CoverCrops"];
                cropprd_Intercropping = (bool)daikonDataReader["cropprd_Intercropping"];
                cropprd_Permaculture = (bool)daikonDataReader["cropprd_Permaculture"];
                cropprd_Transitioning = (bool)daikonDataReader["cropprd_Transitioning"];
                cropprd_DoubleCropping = (bool)daikonDataReader["cropprd_DoubleCropping"];
                cropprd_MinimumTillage = (bool)daikonDataReader["cropprd_MinimumTillage"];
                cropprd_ReducedApplications = (bool)daikonDataReader["cropprd_ReducedApplications"];
                cropprd_Earthworms = (bool)daikonDataReader["cropprd_Earthworms"];
                cropprd_MultipleCropping = (bool)daikonDataReader["cropprd_MultipleCropping"];
                cropprd_RelayCropping = (bool)daikonDataReader["cropprd_RelayCropping"];
                cropprd_Fallow = (bool)daikonDataReader["cropprd_Fallow"];
                cropprd_MunicipalWastes = (bool)daikonDataReader["cropprd_MunicipalWastes"];
                cropprd_RidgeTillage = (bool)daikonDataReader["cropprd_RidgeTillage"];
                cropprd_Fertigation = (bool)daikonDataReader["cropprd_Fertigation"];
                cropprd_NoTill = (bool)daikonDataReader["cropprd_NoTill"];
                cropprd_SoilAnalysis = (bool)daikonDataReader["cropprd_SoilAnalysis"];
                cropprd_CatchCrops = (bool)daikonDataReader["cropprd_CatchCrops"];
                cropprd_CropRotation = (bool)daikonDataReader["cropprd_CropRotation"];
                cropprd_CropBreeding = (bool)daikonDataReader["cropprd_CropBreeding"];
                cropprd_Irrigation = (bool)daikonDataReader["cropprd_Irrigation"];
                cropprd_Other = daikonDataReader["cropprd_Other"].ToString();
                animprd_AlternativeFeedstuffs = (bool)daikonDataReader["animprd_AlternativeFeedstuffs"];
                animprd_FeedRations = (bool)daikonDataReader["animprd_FeedRations"];
                animprd_MultispeciesGrazing = (bool)daikonDataReader["animprd_MultispeciesGrazing"];
                animprd_StockpiledForages = (bool)daikonDataReader["animprd_StockpiledForages"];
                animprd_AlternativeHousing = (bool)daikonDataReader["animprd_AlternativeHousing"];
                animprd_FreeRange = (bool)daikonDataReader["animprd_FreeRange"];
                animprd_PastureFertility = (bool)daikonDataReader["animprd_PastureFertility"];
                animprd_Vaccines = (bool)daikonDataReader["animprd_Vaccines"];
                animprd_AlternParasiteControl = (bool)daikonDataReader["animprd_AlternParasiteControl"];
                animprd_HerbalMedicines = (bool)daikonDataReader["animprd_HerbalMedicines"];
                animprd_PastureRenovation = (bool)daikonDataReader["animprd_PastureRenovation"];
                animprd_WateringSystem = (bool)daikonDataReader["animprd_WateringSystem"];
                animprd_AnimalProtection = (bool)daikonDataReader["animprd_AnimalProtection"];
                animprd_Homeopathy = (bool)daikonDataReader["animprd_Homeopathy"];
                animprd_PreventivePractices = (bool)daikonDataReader["animprd_PreventivePractices"];
                animprd_WinterForage = (bool)daikonDataReader["animprd_WinterForage"];
                animprd_Composting = (bool)daikonDataReader["animprd_Composting"];
                animprd_Implants = (bool)daikonDataReader["animprd_Implants"];
                animprd_Probiotics = (bool)daikonDataReader["animprd_Probiotics"];
                animprd_ContinuousGrazing = (bool)daikonDataReader["animprd_ContinuousGrazing"];
                animprd_Inoculants = (bool)daikonDataReader["animprd_Inoculants"];
                animprd_RangeImprovement = (bool)daikonDataReader["animprd_RangeImprovement"];
                animprd_FeedAdditives = (bool)daikonDataReader["animprd_FeedAdditives"];
                animprd_ManureManagement = (bool)daikonDataReader["animprd_ManureManagement"];
                animprd_RotationalGrazing = (bool)daikonDataReader["animprd_RotationalGrazing"];
                animprd_FeedFormulation = (bool)daikonDataReader["animprd_FeedFormulation"];
                animprd_MineralSupplements = (bool)daikonDataReader["animprd_MineralSupplements"];
                animprd_ShadeShelter = (bool)daikonDataReader["animprd_ShadeShelter"];
                animprd_Therapeutics = (bool)daikonDataReader["animprd_Therapeutics"];
                animprd_LivestockBreeding = (bool)daikonDataReader["animprd_LivestockBreeding"];
                animprd_StockingRate = (bool)daikonDataReader["animprd_StockingRate"];
                animprd_grazingmanagement = (bool)daikonDataReader["animprd_grazingmanagement"];
                animprd_Other = daikonDataReader["animprd_Other"].ToString();
                pestmgt_Allelopathy = (bool)daikonDataReader["pestmgt_Allelopathy"];
                pestmgt_EconomicThreshold = (bool)daikonDataReader["pestmgt_EconomicThreshold"];
                pestmgt_MechanicalControl = (bool)daikonDataReader["pestmgt_MechanicalControl"];
                pestmgt_SmotherCrops = (bool)daikonDataReader["pestmgt_SmotherCrops"];
                pestmgt_BiologicalControl = (bool)daikonDataReader["pestmgt_BiologicalControl"];
                pestmgt_Eradication = (bool)daikonDataReader["pestmgt_Eradication"];
                pestmgt_PhysicalControl = (bool)daikonDataReader["pestmgt_PhysicalControl"];
                pestmgt_Traps = (bool)daikonDataReader["pestmgt_Traps"];
                pestmgt_BiorationalPesticides = (bool)daikonDataReader["pestmgt_BiorationalPesticides"];
                pestmgt_Flame = (bool)daikonDataReader["pestmgt_Flame"];
                pestmgt_PlasticMulching = (bool)daikonDataReader["pestmgt_PlasticMulching"];
                pestmgt_TrapCrops = (bool)daikonDataReader["pestmgt_TrapCrops"];
                pestmgt_BotanicalPesticides = (bool)daikonDataReader["pestmgt_BotanicalPesticides"];
                pestmgt_FieldMonitoring = (bool)daikonDataReader["pestmgt_FieldMonitoring"];
                pestmgt_PrecisionCultivation = (bool)daikonDataReader["pestmgt_PrecisionCultivation"];
                pestmgt_VegetativeMulching = (bool)daikonDataReader["pestmgt_VegetativeMulching"];
                pestmgt_ChemicalControl = (bool)daikonDataReader["pestmgt_ChemicalControl"];
                pestmgt_GeneticResistance = (bool)daikonDataReader["pestmgt_GeneticResistance"];
                pestmgt_PrecisionHerbicideUse = (bool)daikonDataReader["pestmgt_PrecisionHerbicideUse"];
                pestmgt_WeatherMonitoring = (bool)daikonDataReader["pestmgt_WeatherMonitoring"];
                pestmgt_Competition = (bool)daikonDataReader["pestmgt_Competition"];
                pestmgt_IPM = (bool)daikonDataReader["pestmgt_IPM"];
                pestmgt_Prevention = (bool)daikonDataReader["pestmgt_Prevention"];
                pestmgt_WeedEcology = (bool)daikonDataReader["pestmgt_WeedEcology"];
                pestmgt_CompostExtracts = (bool)daikonDataReader["pestmgt_CompostExtracts"];
                pestmgt_KilledMulches = (bool)daikonDataReader["pestmgt_KilledMulches"];
                pestmgt_RowCovers = (bool)daikonDataReader["pestmgt_RowCovers"];
                pestmgt_WeederGeese = (bool)daikonDataReader["pestmgt_WeederGeese"];
                pestmgt_CulturalControl = (bool)daikonDataReader["pestmgt_CulturalControl"];
                pestmgt_LivingMulches = (bool)daikonDataReader["pestmgt_LivingMulches"];
                pestmgt_Sanitation = (bool)daikonDataReader["pestmgt_Sanitation"];
                pestmgt_DiseaseVectors = (bool)daikonDataReader["pestmgt_DiseaseVectors"];
                pestmgt_MatingDisruption = (bool)daikonDataReader["pestmgt_MatingDisruption"];
                pestmgt_SoilSolarization = (bool)daikonDataReader["pestmgt_SoilSolarization"];
                pestmgt_Other = daikonDataReader["pestmgt_Other"].ToString();
                soilmgt_NutrientMineralization = (bool)daikonDataReader["soilmgt_NutrientMineralization"];
                soilmgt_SoilMicrobiology = (bool)daikonDataReader["soilmgt_SoilMicrobiology"];
                soilmgt_SoilOrganicMatter = (bool)daikonDataReader["soilmgt_SoilOrganicMatter"];
                soilmgt_SoilQuality = (bool)daikonDataReader["soilmgt_SoilQuality"];
                soilmgt_CarbonSequestration = (bool)daikonDataReader["soilmgt_CarbonSequestration"];
                soilmgt_SoilChemistry = (bool)daikonDataReader["soilmgt_SoilChemistry"];
                soilmgt_SoilPhysics = (bool)daikonDataReader["soilmgt_SoilPhysics"];
                soilmgt_Other = daikonDataReader["soilmgt_Other"].ToString();
                nresenv_Afforestation = (bool)daikonDataReader["nresenv_Afforestation"];
                nresenv_GrassHedges = (bool)daikonDataReader["nresenv_GrassHedges"];
                nresenv_RiparianPlantings = (bool)daikonDataReader["nresenv_RiparianPlantings"];
                nresenv_Wildlife = (bool)daikonDataReader["nresenv_Wildlife"];
                nresenv_Biodiversity = (bool)daikonDataReader["nresenv_Biodiversity"];
                nresenv_GrassWaterways = (bool)daikonDataReader["nresenv_GrassWaterways"];
                nresenv_RiverbankProtection = (bool)daikonDataReader["nresenv_RiverbankProtection"];
                nresenv_Windbreaks = (bool)daikonDataReader["nresenv_Windbreaks"];
                nresenv_Biosphere = (bool)daikonDataReader["nresenv_Biosphere"];
                nresenv_HabitatEnhancement = (bool)daikonDataReader["nresenv_HabitatEnhancement"];
                nresenv_SoilStabilization = (bool)daikonDataReader["nresenv_SoilStabilization"];
                nresenv_WoodyHedges = (bool)daikonDataReader["nresenv_WoodyHedges"];
                nresenv_ConservationTillage = (bool)daikonDataReader["nresenv_ConservationTillage"];
                nresenv_Hedgerows = (bool)daikonDataReader["nresenv_Hedgerows"];
                nresenv_Terraces = (bool)daikonDataReader["nresenv_Terraces"];
                nresenv_ContourCultivation = (bool)daikonDataReader["nresenv_ContourCultivation"];
                nresenv_Indicators = (bool)daikonDataReader["nresenv_Indicators"];
                nresenv_Wetlands = (bool)daikonDataReader["nresenv_Wetlands"];
                nresenv_Other = daikonDataReader["nresenv_Other"].ToString();
                edtrain_CaseStudy = (bool)daikonDataReader["edtrain_CaseStudy"];
                edtrain_Demonstration = (bool)daikonDataReader["edtrain_Demonstration"];
                edtrain_FocusGroup = (bool)daikonDataReader["edtrain_FocusGroup"];
                edtrain_StudyCircle = (bool)daikonDataReader["edtrain_StudyCircle"];
                edtrain_Conference = (bool)daikonDataReader["edtrain_Conference"];
                edtrain_Display = (bool)daikonDataReader["edtrain_Display"];
                edtrain_Mentor = (bool)daikonDataReader["edtrain_Mentor"];
                edtrain_Workshop = (bool)daikonDataReader["edtrain_Workshop"];
                edtrain_Curriculum = (bool)daikonDataReader["edtrain_Curriculum"];
                edtrain_Extension = (bool)daikonDataReader["edtrain_Extension"];
                edtrain_Network = (bool)daikonDataReader["edtrain_Network"];
                edtrain_Database = (bool)daikonDataReader["edtrain_Database"];
                edtrain_FactSheet = (bool)daikonDataReader["edtrain_FactSheet"];
                edtrain_OnFarmResearch = (bool)daikonDataReader["edtrain_OnFarmResearch"];
                edtrain_DecisionSupportSystem = (bool)daikonDataReader["edtrain_DecisionSupportSystem"];
                edtrain_FarmerToFarmer = (bool)daikonDataReader["edtrain_FarmerToFarmer"];
                edtrain_ParticipatoryResearch = (bool)daikonDataReader["edtrain_ParticipatoryResearch"];
                edtrain_YouthEducation = (bool)daikonDataReader["edtrain_YouthEducation"];
                edtrain_Other = daikonDataReader["edtrain_Other"].ToString();
                econmkt_AlternativeEnterprise = (bool)daikonDataReader["econmkt_AlternativeEnterprise"];
                econmkt_CSA = (bool)daikonDataReader["econmkt_CSA"];
                econmkt_FeasibilityStudy = (bool)daikonDataReader["econmkt_FeasibilityStudy"];
                econmkt_RiskManagement = (bool)daikonDataReader["econmkt_RiskManagement"];
                econmkt_Budget = (bool)daikonDataReader["econmkt_Budget"];
                econmkt_CostAndReturns = (bool)daikonDataReader["econmkt_CostAndReturns"];
                econmkt_FinancialAnalysis = (bool)daikonDataReader["econmkt_FinancialAnalysis"];
                econmkt_ValueAdded = (bool)daikonDataReader["econmkt_ValueAdded"];
                econmkt_Cooperatives = (bool)daikonDataReader["econmkt_Cooperatives"];
                econmkt_DirectMarketing = (bool)daikonDataReader["econmkt_DirectMarketing"];
                econmkt_MarketStudy = (bool)daikonDataReader["econmkt_MarketStudy"];
                econmkt_FoodProductQualitySafety = (bool)daikonDataReader["econmkt_FoodProductQualitySafety"];
                econmkt_LaborEmployment = (bool)daikonDataReader["econmkt_LaborEmployment"];
                econmkt_Ecommerce = (bool)daikonDataReader["econmkt_Ecommerce"];
                econmkt_FarmToInstitution = (bool)daikonDataReader["econmkt_FarmToInstitution"];
                econmkt_Other = daikonDataReader["econmkt_Other"].ToString();
                commdev_InfrastructureAnalysis = (bool)daikonDataReader["commdev_InfrastructureAnalysis"];
                commdev_TechnicalAssistance = (bool)daikonDataReader["commdev_TechnicalAssistance"];
                commdev_NewBusinessOpportunities = (bool)daikonDataReader["commdev_NewBusinessOpportunities"];
                commdev_Partnerships = (bool)daikonDataReader["commdev_Partnerships"];
                commdev_UrbanAgriculture = (bool)daikonDataReader["commdev_UrbanAgriculture"];
                commdev_PublicParticipation = (bool)daikonDataReader["commdev_PublicParticipation"];
                commdev_UrbanRuralIntegration = (bool)daikonDataReader["commdev_UrbanRuralIntegration"];
                commdev_LocalRegionalCommunityFoodSystems = (bool)daikonDataReader["commdev_LocalRegionalCommunityFoodSystems"];
                commdev_Agritourism = (bool)daikonDataReader["commdev_Agritourism"];
                commdev_CommunityPlanning = (bool)daikonDataReader["commdev_CommunityPlanning"];
                commdev_PublicPolicy = (bool)daikonDataReader["commdev_PublicPolicy"];
                commdev_LeadershipDevelopment = (bool)daikonDataReader["commdev_LeadershipDevelopment"];
                commdev_EthnicDifferencesCulturalDemographicChange = (bool)daikonDataReader["commdev_EthnicDifferencesCulturalDemographicChange"];
                commdev_Other = daikonDataReader["commdev_Other"].ToString();
                qoflife_AnalysisOfPersonalFamilyLife = (bool)daikonDataReader["qoflife_AnalysisOfPersonalFamilyLife"];
                qoflife_SocialCapitol = (bool)daikonDataReader["qoflife_SocialCapitol"];
                qoflife_SustainabilityMeasures = (bool)daikonDataReader["qoflife_SustainabilityMeasures"];
                qoflife_CommunityServices = (bool)daikonDataReader["qoflife_CommunityServices"];
                qoflife_SocialNetworks = (bool)daikonDataReader["qoflife_SocialNetworks"];
                qoflife_EmploymentOpportunities = (bool)daikonDataReader["qoflife_EmploymentOpportunities"];
                qoflife_SocialPsychologicalIndicators = (bool)daikonDataReader["qoflife_SocialPsychologicalIndicators"];
                qoflife_Other = daikonDataReader["qoflife_Other"].ToString();
                energy_BioenergyBiofuels = (bool)daikonDataReader["energy_BioenergyBiofuels"];
                energy_WindPower = (bool)daikonDataReader["energy_WindPower"];
                energy_EnergyUseConsumption = (bool)daikonDataReader["energy_EnergyUseConsumption"];
                energy_SolarEnergy = (bool)daikonDataReader["energy_SolarEnergy"];
                energy_EnergyConservationEfficiency = (bool)daikonDataReader["energy_EnergyConservationEfficiency"];
                energy_Other = daikonDataReader["energy_Other"].ToString();
                commPlAgr_Barley = (bool)daikonDataReader["commPlAgr_Barley"];
                commPlAgr_GrassLegumeHay = (bool)daikonDataReader["commPlAgr_GrassLegumeHay"];
                commPlAgr_Peanuts = (bool)daikonDataReader["commPlAgr_Peanuts"];
                commPlAgr_Sorghum = (bool)daikonDataReader["commPlAgr_Sorghum"];
                commPlAgr_Sweetpotatoes = (bool)daikonDataReader["commPlAgr_Sweetpotatoes"];
                commPlAgr_Canola = (bool)daikonDataReader["commPlAgr_Canola"];
                commPlAgr_LegumeHay = (bool)daikonDataReader["commPlAgr_LegumeHay"];
                commPlAgr_Potatoes = (bool)daikonDataReader["commPlAgr_Potatoes"];
                commPlAgr_Soybeans = (bool)daikonDataReader["commPlAgr_Soybeans"];
                commPlAgr_Tobacco = (bool)daikonDataReader["commPlAgr_Tobacco"];
                commPlAgr_Corn = (bool)daikonDataReader["commPlAgr_Corn"];
                commPlAgr_Hops = (bool)daikonDataReader["commPlAgr_Hops"];
                commPlAgr_Rapeseed = (bool)daikonDataReader["commPlAgr_Rapeseed"];
                commPlAgr_Spelt = (bool)daikonDataReader["commPlAgr_Spelt"];
                commPlAgr_Wheat = (bool)daikonDataReader["commPlAgr_Wheat"];
                commPlAgr_Cotton = (bool)daikonDataReader["commPlAgr_Cotton"];
                commPlAgr_Kenaf = (bool)daikonDataReader["commPlAgr_Kenaf"];
                commPlAgr_Rice = (bool)daikonDataReader["commPlAgr_Rice"];
                commPlAgr_Sugarbeets = (bool)daikonDataReader["commPlAgr_Sugarbeets"];
                commPlAgr_Flax = (bool)daikonDataReader["commPlAgr_Flax"];
                commPlAgr_Millet = (bool)daikonDataReader["commPlAgr_Millet"];
                commPlAgr_Rye = (bool)daikonDataReader["commPlAgr_Rye"];
                commPlAgr_Sugarcane = (bool)daikonDataReader["commPlAgr_Sugarcane"];
                commPlAgr_GrassHay = (bool)daikonDataReader["commPlAgr_GrassHay"];
                commPlAgr_Oats = (bool)daikonDataReader["commPlAgr_Oats"];
                commPlAgr_Safflower = (bool)daikonDataReader["commPlAgr_Safflower"];
                commPlAgr_Sunflower = (bool)daikonDataReader["commPlAgr_Sunflower"];
                commPlAgr_Other = daikonDataReader["commPlAgr_Other"].ToString();
                commPlVeg_Artichokes = (bool)daikonDataReader["commPlVeg_Artichokes"];
                commPlVeg_Cabbage = (bool)daikonDataReader["commPlVeg_Cabbage"];
                commPlVeg_Escarole = (bool)daikonDataReader["commPlVeg_Escarole"];
                commPlVeg_Onions = (bool)daikonDataReader["commPlVeg_Onions"];
                commPlVeg_SweetCorn = (bool)daikonDataReader["commPlVeg_SweetCorn"];
                commPlVeg_Asparagus = (bool)daikonDataReader["commPlVeg_Asparagus"];
                commPlVeg_Carrots = (bool)daikonDataReader["commPlVeg_Carrots"];
                commPlVeg_Garlic = (bool)daikonDataReader["commPlVeg_Garlic"];
                commPlVeg_Parsnips = (bool)daikonDataReader["commPlVeg_Parsnips"];
                commPlVeg_Tomatoes = (bool)daikonDataReader["commPlVeg_Tomatoes"];
                commPlVeg_Beans = (bool)daikonDataReader["commPlVeg_Beans"];
                commPlVeg_Cauliflower = (bool)daikonDataReader["commPlVeg_Cauliflower"];
                commPlVeg_Greens = (bool)daikonDataReader["commPlVeg_Greens"];
                commPlVeg_Peas = (bool)daikonDataReader["commPlVeg_Peas"];
                commPlVeg_Turnips = (bool)daikonDataReader["commPlVeg_Turnips"];
                commPlVeg_Beets = (bool)daikonDataReader["commPlVeg_Beets"];
                commPlVeg_Celery = (bool)daikonDataReader["commPlVeg_Celery"];
                commPlVeg_Kale = (bool)daikonDataReader["commPlVeg_Kale"];
                commPlVeg_Peppers = (bool)daikonDataReader["commPlVeg_Peppers"];
                commPlVeg_Watermelon = (bool)daikonDataReader["commPlVeg_Watermelon"];
                commPlVeg_Broccoli = (bool)daikonDataReader["commPlVeg_Broccoli"];
                commPlVeg_Cucumbers = (bool)daikonDataReader["commPlVeg_Cucumbers"];
                commPlVeg_Lentils = (bool)daikonDataReader["commPlVeg_Lentils"];
                commPlVeg_Rutabagas = (bool)daikonDataReader["commPlVeg_Rutabagas"];
                commPlVeg_BrusselSprouts = (bool)daikonDataReader["commPlVeg_BrusselSprouts"];
                commPlVeg_Eggplant = (bool)daikonDataReader["commPlVeg_Eggplant"];
                commPlVeg_Lettuce = (bool)daikonDataReader["commPlVeg_Lettuce"];
                commPlVeg_Spinach = (bool)daikonDataReader["commPlVeg_Spinach"];
                commplveg_leeks = (bool)daikonDataReader["commplveg_leeks"];
                commPlVeg_Pumpkins = (bool)daikonDataReader["commPlVeg_Pumpkins"];
                commPlVeg_Squashes = (bool)daikonDataReader["commPlVeg_Squashes"];
                commPlVeg_Radishes = (bool)daikonDataReader["commPlVeg_Radishes"];
                commPlVeg_Other = daikonDataReader["commPlVeg_Other"].ToString();
                commPlFruit_Apples = (bool)daikonDataReader["commPlFruit_Apples"];
                commPlFruit_Cherries = (bool)daikonDataReader["commPlFruit_Cherries"];
                commPlFruit_Lemons = (bool)daikonDataReader["commPlFruit_Lemons"];
                commPlFruit_Peaches = (bool)daikonDataReader["commPlFruit_Peaches"];
                commPlFruit_Strawberries = (bool)daikonDataReader["commPlFruit_Strawberries"];
                commPlFruit_Apricots = (bool)daikonDataReader["commPlFruit_Apricots"];
                commPlFruit_Cranberries = (bool)daikonDataReader["commPlFruit_Cranberries"];
                commPlFruit_Limes = (bool)daikonDataReader["commPlFruit_Limes"];
                commPlFruit_Pears = (bool)daikonDataReader["commPlFruit_Pears"];
                commPlFruit_Tangerines = (bool)daikonDataReader["commPlFruit_Tangerines"];
                commPlFruit_Avocados = (bool)daikonDataReader["commPlFruit_Avocados"];
                commPlFruit_Figs = (bool)daikonDataReader["commPlFruit_Figs"];
                commPlFruit_Melons = (bool)daikonDataReader["commPlFruit_Melons"];
                commPlFruit_Pineapples = (bool)daikonDataReader["commPlFruit_Pineapples"];
                commPlFruit_Bananas = (bool)daikonDataReader["commPlFruit_Bananas"];
                commPlFruit_Grapefruit = (bool)daikonDataReader["commPlFruit_Grapefruit"];
                commPlFruit_Olives = (bool)daikonDataReader["commPlFruit_Olives"];
                commPlFruit_Plums = (bool)daikonDataReader["commPlFruit_Plums"];
                commPlFruit_Berries = (bool)daikonDataReader["commPlFruit_Berries"];
                commPlFruit_Grapes = (bool)daikonDataReader["commPlFruit_Grapes"];
                commPlFruit_Oranges = (bool)daikonDataReader["commPlFruit_Oranges"];
                commPlFruit_Quinces = (bool)daikonDataReader["commPlFruit_Quinces"];
                commPlFruit_Brambles = (bool)daikonDataReader["commPlFruit_Brambles"];
                commPlFruit_Blueberries = (bool)daikonDataReader["commPlFruit_Blueberries"];
                commPlFruit_Other = daikonDataReader["commPlFruit_Other"].ToString();
                commPlNuts_Almonds = (bool)daikonDataReader["commPlNuts_Almonds"];
                commPlNuts_Hazelnuts = (bool)daikonDataReader["commPlNuts_Hazelnuts"];
                commPlNuts_Pecans = (bool)daikonDataReader["commPlNuts_Pecans"];
                commPlNuts_Walnuts = (bool)daikonDataReader["commPlNuts_Walnuts"];
                commplnuts_chestnuts = (bool)daikonDataReader["commplnuts_chestnuts"];
                commPlNuts_Macadamia = (bool)daikonDataReader["commPlNuts_Macadamia"];
                commPlNuts_Pistachios = (bool)daikonDataReader["commPlNuts_Pistachios"];
                commPlNuts_Other = daikonDataReader["commPlNuts_Other"].ToString();
                commPlAdd_Herbs = (bool)daikonDataReader["commPlAdd_Herbs"];
                commPlAdd_Ornamentals = (bool)daikonDataReader["commPlAdd_Ornamentals"];
                commPlAdd_Trees = (bool)daikonDataReader["commPlAdd_Trees"];
                commPlAdd_Mushrooms = (bool)daikonDataReader["commPlAdd_Mushrooms"];
                commPlAdd_NativePlants = (bool)daikonDataReader["commPlAdd_NativePlants"];
                commPlAdd_Other = daikonDataReader["commPlAdd_Other"].ToString();
                commAnim_Beef = (bool)daikonDataReader["commAnim_Beef"];
                commAnim_Chicken = (bool)daikonDataReader["commAnim_Chicken"];
                commAnim_Rabbits = (bool)daikonDataReader["commAnim_Rabbits"];
                commAnim_Swine = (bool)daikonDataReader["commAnim_Swine"];
                commAnim_Dairy = (bool)daikonDataReader["commAnim_Dairy"];
                commAnim_Goats = (bool)daikonDataReader["commAnim_Goats"];
                commAnim_Sheep = (bool)daikonDataReader["commAnim_Sheep"];
                commAnim_Turkeys = (bool)daikonDataReader["commAnim_Turkeys"];
                commAnim_Other = daikonDataReader["commAnim_Other"].ToString();
                commMisc_Bees = (bool)daikonDataReader["commMisc_Bees"];
                commMisc_Fish = (bool)daikonDataReader["commMisc_Fish"];
                commMisc_Ratites = (bool)daikonDataReader["commMisc_Ratites"];
                commMisc_Shellfish = (bool)daikonDataReader["commMisc_Shellfish"];
                commMisc_Other = daikonDataReader["commMisc_Other"].ToString();
                submitted = (bool)daikonDataReader["submitted"];
                createdDate = daikonDataReader["createdDate"].ToString();
                createdBy = daikonDataReader["createdBy"].ToString();
                updatedDate = daikonDataReader["updatedDate"].ToString();
                updatedBy = daikonDataReader["updatedBy"].ToString();
                approvedDate = daikonDataReader["approvedDate"].ToString();
                approvedBy = daikonDataReader["approvedBy"].ToString();
                adminOverride = (bool)daikonDataReader["adminOverride"];
                adminOverrideDate = daikonDataReader["adminOverrideDate"].ToString();
                adminOverrideBy = daikonDataReader["adminOverrideBy"].ToString();
                if (daikonDataReader["approved"].ToString() == "")
                    approved = false;
                else
                    approved = (bool)daikonDataReader["approved"];
            }
            daikonConnection.Dispose();
		}

        public bool saveNewProfileToDB(string user, int sKey, int coreID)
        {
            string profileSQL;
            bool updateSuccess;
            string profileConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection profileConnection;
            SqlCommand profileCommand;

            profileConnection = new SqlConnection(profileConnString);

            profileSQL = "DaikonProfilesProfileInsert";
            profileCommand = new SqlCommand(profileSQL, profileConnection);
            profileCommand.CommandType = CommandType.StoredProcedure;

            profileCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            profileCommand.Parameters.Add("@sKey", SqlDbType.Int);
            profileCommand.Parameters.Add("@coreID", SqlDbType.BigInt);
            profileCommand.Parameters.Add("@extensionLvl1", SqlDbType.Bit);
            profileCommand.Parameters.Add("@extensionLvl2", SqlDbType.Bit);
            profileCommand.Parameters.Add("@categoryA", SqlDbType.VarChar, 50);
            profileCommand.Parameters.Add("@catAother", SqlDbType.VarChar, 80);
            profileCommand.Parameters.Add("@categoryB", SqlDbType.VarChar, 50);
            profileCommand.Parameters.Add("@catBother", SqlDbType.VarChar, 80);
            profileCommand.Parameters.Add("@aud_farmranchers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@aud_educators", SqlDbType.Bit);
            profileCommand.Parameters.Add("@aud_researchers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@aud_consumers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@techlvl_beginner", SqlDbType.Bit);
            profileCommand.Parameters.Add("@techlvl_intermediate", SqlDbType.Bit);
            profileCommand.Parameters.Add("@techlvl_advanced", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_planning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_present", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_research", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_land", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_planningcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_presentcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_researchcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_researchcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_landcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_numideas", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_extplanning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_extapplied", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_AgroecosystemAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_WholeFarmPlanning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_HolisticManagement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_OrganicAgriculture", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_Permaculture", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@cropprd_Agroforestry", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_FoliarFeeding", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_NutrientCycling", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_StripCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_BiologicalInoculants", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Forestry", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_OrganicFertilizers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_StubbleMulching", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_ContinuousCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_GreenManures", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_OrganicMatter", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_TissueAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_CoverCrops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Intercropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Permaculture", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Transitioning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_DoubleCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_MinimumTillage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_ReducedApplications", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Earthworms", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_MultipleCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_RelayCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Fallow", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_MunicipalWastes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_RidgeTillage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Fertigation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_NoTill", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_SoilAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_CatchCrops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_CropRotation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Irrigation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_CropBreeding", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@animprd_AlternativeFeedstuffs", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_FeedRations", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_MultispeciesGrazing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_StockpiledForages", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_AlternativeHousing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_FreeRange", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_PastureFertility", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Vaccines", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_AlternParasiteControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_HerbalMedicines", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_PastureRenovation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_WateringSystem", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_AnimalProtection", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Homeopathy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_PreventivePractices", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_WinterForage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Composting", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Implants", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Probiotics", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_ContinuousGrazing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Inoculants", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_RangeImprovement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_FeedAdditives", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_ManureManagement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_RotationalGrazing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_FeedFormulation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_MineralSupplements", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_ShadeShelter", SqlDbType.Bit);             
            profileCommand.Parameters.Add("@animprd_Therapeutics", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_LivestockBreeding", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_StockingRate", SqlDbType.Bit);            
            profileCommand.Parameters.Add("@animprd_grazingmanagement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@pestmgt_Allelopathy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_EconomicThreshold", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_MechanicalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_SmotherCrops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_BiologicalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Eradication", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_PhysicalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Traps", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_BiorationalPesticides", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Flame", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_PlasticMulching", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_TrapCrops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_BotanicalPesticides", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_FieldMonitoring", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_PrecisionCultivation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_VegetativeMulching", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_ChemicalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_GeneticResistance", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_PrecisionHerbicideUse", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_WeatherMonitoring", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Competition", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_IPM", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Prevention", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_WeedEcology", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_CompostExtracts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_KilledMulches", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_RowCovers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_WeederGeese", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_CulturalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_LivingMulches", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Sanitation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_DiseaseVectors", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_MatingDisruption", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_SoilSolarization", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@soilmgt_NutrientMineralization", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilMicrobiology", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilOrganicMatter", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilQuality", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_CarbonSequestration", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilChemistry", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilPhysics", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@nresenv_Afforestation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_GrassHedges", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_RiparianPlantings", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Wildlife", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Biodiversity", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_GrassWaterways", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_RiverbankProtection", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Windbreaks", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Biosphere", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_HabitatEnhancement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_SoilStabilization", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_WoodyHedges", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_ConservationTillage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Hedgerows", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Terraces", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_ContourCultivation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Indicators", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Wetlands", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@edtrain_CaseStudy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Demonstration", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_FocusGroup", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_StudyCircle", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Conference", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Display", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Mentor", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Workshop", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Curriculum", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Extension", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Network", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Database", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_FactSheet", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_OnFarmResearch", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_DecisionSupportSystem", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_FarmerToFarmer", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_ParticipatoryResearch", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_YouthEducation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@econmkt_AlternativeEnterprise", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_CSA", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_FeasibilityStudy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_RiskManagement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_Budget", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_CostAndReturns", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_FinancialAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_ValueAdded", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_Cooperatives", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_DirectMarketing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_MarketStudy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_FoodProductQualitySafety", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_LaborEmployment", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_Ecommerce", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_FarmToInstitution", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commdev_InfrastructureAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_TechnicalAssistance", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_NewBusinessOpportunities", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_Partnerships", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_UrbanAgriculture", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_PublicParticipation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_UrbanRuralIntegration", SqlDbType.Bit);     
            profileCommand.Parameters.Add("@commdev_LocalRegionalCommunityFoodSystems", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_Agritourism", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_PublicPolicy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_CommunityPlanning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_LeadershipDevelopment", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_EthnicDifferencesCulturalDemographicChange", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@qoflife_AnalysisOfPersonalFamilyLife", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_SocialCapitol", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_SustainabilityMeasures", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_CommunityServices", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_SocialNetworks", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_EmploymentOpportunities", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_SocialPsychologicalIndicators", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@energy_BioenergyBiofuels", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_WindPower", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_EnergyUseConsumption", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_SolarEnergy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_EnergyConservationEfficiency", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commPlAgr_Barley", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_GrassLegumeHay", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Peanuts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sorghum", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sweetpotatoes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Canola", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_LegumeHay", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Potatoes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Soybeans", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Tobacco", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Corn", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Hops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Rapeseed", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Spelt", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Wheat", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Cotton", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Kenaf", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Rice", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sugarbeets", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Flax", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Millet", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Rye", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sugarcane", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_GrassHay", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Oats", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Safflower", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sunflower", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commPlVeg_Artichokes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Cabbage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Escarole", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Onions", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_SweetCorn", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Asparagus", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Carrots", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Garlic", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Parsnips", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Tomatoes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Beans", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Cauliflower", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Greens", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Peas", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Turnips", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Beets", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Celery", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Kale", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Peppers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Watermelon", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Broccoli", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Cucumbers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Lentils", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Rutabagas", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_BrusselSprouts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Eggplant", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Lettuce", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Spinach", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commplveg_leeks", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Pumpkins", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Squashes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Radishes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commPlFruit_Apples", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Cherries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Lemons", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Peaches", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Strawberries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Apricots", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Cranberries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Limes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Pears", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Tangerines", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Avocados", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Figs", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Melons", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Pineapples", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Bananas", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Grapefruit", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Olives", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Plums", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Berries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Grapes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Oranges", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Quinces", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Brambles", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Blueberries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commPlNuts_Almonds", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Hazelnuts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Pecans", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Walnuts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commplnuts_chestnuts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Macadamia", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Pistachios", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commPlAdd_Herbs", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_Ornamentals", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_Trees", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_Mushrooms", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_NativePlants", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commAnim_Beef", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Chicken", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Rabbits", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Swine", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Dairy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Goats", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Sheep", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Turkeys", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commMisc_Bees", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commMisc_Fish", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commMisc_Ratites", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commMisc_Shellfish", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commMisc_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@submitted", SqlDbType.Bit);
            profileCommand.Parameters.Add("@ID", SqlDbType.Int);

            profileCommand.Parameters["@user"].Value = (user);
            profileCommand.Parameters["@sKey"].Value = (sKey);
            profileCommand.Parameters["@coreID"].Value = (coreID);
            profileCommand.Parameters["@extensionLvl1"].Value = (extensionLvl1);
            profileCommand.Parameters["@extensionLvl2"].Value = (extensionLvl2);
            profileCommand.Parameters["@categoryA"].Value = (categoryA);
            profileCommand.Parameters["@catAother"].Value = (catAother);
            profileCommand.Parameters["@categoryB"].Value = (categoryB);
            profileCommand.Parameters["@catBother"].Value = (catBother);
            profileCommand.Parameters["@aud_farmranchers"].Value = (aud_farmranchers);
            profileCommand.Parameters["@aud_educators"].Value = (aud_educators);
            profileCommand.Parameters["@aud_researchers"].Value = (aud_researchers);
            profileCommand.Parameters["@aud_consumers"].Value = (aud_consumers);
            profileCommand.Parameters["@techlvl_beginner"].Value = (techlvl_beginner);
            profileCommand.Parameters["@techlvl_intermediate"].Value = (techlvl_intermediate);
            profileCommand.Parameters["@techlvl_advanced"].Value = (techlvl_advanced);

            profileCommand.Parameters["@inv_planning"].Value = (inv_planning);
            profileCommand.Parameters["@inv_present"].Value = (inv_present);
            profileCommand.Parameters["@inv_research"].Value = (inv_research);
            profileCommand.Parameters["@inv_land"].Value = (inv_land);
            profileCommand.Parameters["@inv_planningcount"].Value = (inv_planningcount);
            profileCommand.Parameters["@inv_presentcount"].Value = (inv_presentcount);
            profileCommand.Parameters["@inv_researchcount"].Value = (inv_researchcount);
            profileCommand.Parameters["@inv_researchcount"].Value = (inv_researchcount);
            profileCommand.Parameters["@inv_landcount"].Value = (inv_landcount);
            profileCommand.Parameters["@inv_numparticipants"].Value = (inv_numparticipants);
            profileCommand.Parameters["@inv_numideas"].Value = (inv_numideas);
            profileCommand.Parameters["@inv_extplanning"].Value = (inv_extplanning);
            profileCommand.Parameters["@inv_extapplied"].Value = (inv_extapplied);

            profileCommand.Parameters["@intgfrs_AgroecosystemAnalysis"].Value = (intgfrs_AgroecosystemAnalysis);
            profileCommand.Parameters["@intgfrs_WholeFarmPlanning"].Value = (intgfrs_WholeFarmPlanning);
            profileCommand.Parameters["@intgfrs_HolisticManagement"].Value = (intgfrs_HolisticManagement);
            profileCommand.Parameters["@intgfrs_OrganicAgriculture"].Value = (intgfrs_OrganicAgriculture);
            profileCommand.Parameters["@intgfrs_Permaculture"].Value = (intgfrs_Permaculture);
            profileCommand.Parameters["@intgfrs_Other"].Value = (intgfrs_Other);
            profileCommand.Parameters["@cropprd_Agroforestry"].Value = (cropprd_Agroforestry);
            profileCommand.Parameters["@cropprd_FoliarFeeding"].Value = (cropprd_FoliarFeeding);
            profileCommand.Parameters["@cropprd_NutrientCycling"].Value = (cropprd_NutrientCycling);
            profileCommand.Parameters["@cropprd_StripCropping"].Value = (cropprd_StripCropping);
            profileCommand.Parameters["@cropprd_BiologicalInoculants"].Value = (cropprd_BiologicalInoculants);
            profileCommand.Parameters["@cropprd_Forestry"].Value = (cropprd_Forestry);
            profileCommand.Parameters["@cropprd_OrganicFertilizers"].Value = (cropprd_OrganicFertilizers);
            profileCommand.Parameters["@cropprd_StubbleMulching"].Value = (cropprd_StubbleMulching);
            profileCommand.Parameters["@cropprd_ContinuousCropping"].Value = (cropprd_ContinuousCropping);
            profileCommand.Parameters["@cropprd_GreenManures"].Value = (cropprd_GreenManures);
            profileCommand.Parameters["@cropprd_OrganicMatter"].Value = (cropprd_OrganicMatter);
            profileCommand.Parameters["@cropprd_TissueAnalysis"].Value = (cropprd_TissueAnalysis);
            profileCommand.Parameters["@cropprd_CoverCrops"].Value = (cropprd_CoverCrops);
            profileCommand.Parameters["@cropprd_Intercropping"].Value = (cropprd_Intercropping);
            profileCommand.Parameters["@cropprd_Permaculture"].Value = (cropprd_Permaculture);
            profileCommand.Parameters["@cropprd_Transitioning"].Value = (cropprd_Transitioning);
            profileCommand.Parameters["@cropprd_DoubleCropping"].Value = (cropprd_DoubleCropping);
            profileCommand.Parameters["@cropprd_MinimumTillage"].Value = (cropprd_MinimumTillage);
            profileCommand.Parameters["@cropprd_ReducedApplications"].Value = (cropprd_ReducedApplications);
            profileCommand.Parameters["@cropprd_Earthworms"].Value = (cropprd_Earthworms);
            profileCommand.Parameters["@cropprd_MultipleCropping"].Value = (cropprd_MultipleCropping);
            profileCommand.Parameters["@cropprd_RelayCropping"].Value = (cropprd_RelayCropping);
            profileCommand.Parameters["@cropprd_Fallow"].Value = (cropprd_Fallow);
            profileCommand.Parameters["@cropprd_MunicipalWastes"].Value = (cropprd_MunicipalWastes);
            profileCommand.Parameters["@cropprd_RidgeTillage"].Value = (cropprd_RidgeTillage);
            profileCommand.Parameters["@cropprd_Fertigation"].Value = (cropprd_Fertigation);
            profileCommand.Parameters["@cropprd_NoTill"].Value = (cropprd_NoTill);
            profileCommand.Parameters["@cropprd_SoilAnalysis"].Value = (cropprd_SoilAnalysis);
            profileCommand.Parameters["@cropprd_CatchCrops"].Value = (cropprd_CatchCrops);
            profileCommand.Parameters["@cropprd_CropRotation"].Value = (cropprd_CropRotation);
            profileCommand.Parameters["@cropprd_CropBreeding"].Value = (cropprd_CropBreeding);
            profileCommand.Parameters["@cropprd_Irrigation"].Value = (cropprd_Irrigation);
            profileCommand.Parameters["@cropprd_Other"].Value = (cropprd_Other);
            profileCommand.Parameters["@animprd_AlternativeFeedstuffs"].Value = (animprd_AlternativeFeedstuffs);
            profileCommand.Parameters["@animprd_FeedRations"].Value = (animprd_FeedRations);
            profileCommand.Parameters["@animprd_MultispeciesGrazing"].Value = (animprd_MultispeciesGrazing);
            profileCommand.Parameters["@animprd_StockpiledForages"].Value = (animprd_StockpiledForages);
            profileCommand.Parameters["@animprd_AlternativeHousing"].Value = (animprd_AlternativeHousing);
            profileCommand.Parameters["@animprd_FreeRange"].Value = (animprd_FreeRange);
            profileCommand.Parameters["@animprd_PastureFertility"].Value = (animprd_PastureFertility);
            profileCommand.Parameters["@animprd_Vaccines"].Value = (animprd_Vaccines);
            profileCommand.Parameters["@animprd_AlternParasiteControl"].Value = (animprd_AlternParasiteControl);
            profileCommand.Parameters["@animprd_HerbalMedicines"].Value = (animprd_HerbalMedicines);
            profileCommand.Parameters["@animprd_PastureRenovation"].Value = (animprd_PastureRenovation);
            profileCommand.Parameters["@animprd_WateringSystem"].Value = (animprd_WateringSystem);
            profileCommand.Parameters["@animprd_AnimalProtection"].Value = (animprd_AnimalProtection);
            profileCommand.Parameters["@animprd_Homeopathy"].Value = (animprd_Homeopathy);
            profileCommand.Parameters["@animprd_PreventivePractices"].Value = (animprd_PreventivePractices);
            profileCommand.Parameters["@animprd_WinterForage"].Value = (animprd_WinterForage);
            profileCommand.Parameters["@animprd_Composting"].Value = (animprd_Composting);
            profileCommand.Parameters["@animprd_Implants"].Value = (animprd_Implants);
            profileCommand.Parameters["@animprd_Probiotics"].Value = (animprd_Probiotics);
            profileCommand.Parameters["@animprd_ContinuousGrazing"].Value = (animprd_ContinuousGrazing);
            profileCommand.Parameters["@animprd_Inoculants"].Value = (animprd_Inoculants);
            profileCommand.Parameters["@animprd_RangeImprovement"].Value = (animprd_RangeImprovement);
            profileCommand.Parameters["@animprd_FeedAdditives"].Value = (animprd_FeedAdditives);
            profileCommand.Parameters["@animprd_ManureManagement"].Value = (animprd_ManureManagement);
            profileCommand.Parameters["@animprd_RotationalGrazing"].Value = (animprd_RotationalGrazing);
            profileCommand.Parameters["@animprd_FeedFormulation"].Value = (animprd_FeedFormulation);
            profileCommand.Parameters["@animprd_MineralSupplements"].Value = (animprd_MineralSupplements);
            profileCommand.Parameters["@animprd_ShadeShelter"].Value = (animprd_ShadeShelter);
            profileCommand.Parameters["@animprd_Therapeutics"].Value = (animprd_Therapeutics);
            profileCommand.Parameters["@animprd_LivestockBreeding"].Value = (animprd_LivestockBreeding);
            profileCommand.Parameters["@animprd_StockingRate"].Value = (animprd_StockingRate);
            profileCommand.Parameters["@animprd_grazingmanagement"].Value = (animprd_grazingmanagement);
            profileCommand.Parameters["@animprd_Other"].Value = (animprd_Other);
            profileCommand.Parameters["@pestmgt_Allelopathy"].Value = (pestmgt_Allelopathy);
            profileCommand.Parameters["@pestmgt_EconomicThreshold"].Value = (pestmgt_EconomicThreshold);
            profileCommand.Parameters["@pestmgt_MechanicalControl"].Value = (pestmgt_MechanicalControl);
            profileCommand.Parameters["@pestmgt_SmotherCrops"].Value = (pestmgt_SmotherCrops);
            profileCommand.Parameters["@pestmgt_BiologicalControl"].Value = (pestmgt_BiologicalControl);
            profileCommand.Parameters["@pestmgt_Eradication"].Value = (pestmgt_Eradication);
            profileCommand.Parameters["@pestmgt_PhysicalControl"].Value = (pestmgt_PhysicalControl);
            profileCommand.Parameters["@pestmgt_Traps"].Value = (pestmgt_Traps);
            profileCommand.Parameters["@pestmgt_BiorationalPesticides"].Value = (pestmgt_BiorationalPesticides);
            profileCommand.Parameters["@pestmgt_Flame"].Value = (pestmgt_Flame);
            profileCommand.Parameters["@pestmgt_PlasticMulching"].Value = (pestmgt_PlasticMulching);
            profileCommand.Parameters["@pestmgt_TrapCrops"].Value = (pestmgt_TrapCrops);
            profileCommand.Parameters["@pestmgt_BotanicalPesticides"].Value = (pestmgt_BotanicalPesticides);
            profileCommand.Parameters["@pestmgt_FieldMonitoring"].Value = (pestmgt_FieldMonitoring);
            profileCommand.Parameters["@pestmgt_PrecisionCultivation"].Value = (pestmgt_PrecisionCultivation);
            profileCommand.Parameters["@pestmgt_VegetativeMulching"].Value = (pestmgt_VegetativeMulching);
            profileCommand.Parameters["@pestmgt_ChemicalControl"].Value = (pestmgt_ChemicalControl);
            profileCommand.Parameters["@pestmgt_GeneticResistance"].Value = (pestmgt_GeneticResistance);
            profileCommand.Parameters["@pestmgt_PrecisionHerbicideUse"].Value = (pestmgt_PrecisionHerbicideUse);
            profileCommand.Parameters["@pestmgt_WeatherMonitoring"].Value = (pestmgt_WeatherMonitoring);
            profileCommand.Parameters["@pestmgt_Competition"].Value = (pestmgt_Competition);
            profileCommand.Parameters["@pestmgt_IPM"].Value = (pestmgt_IPM);
            profileCommand.Parameters["@pestmgt_Prevention"].Value = (pestmgt_Prevention);
            profileCommand.Parameters["@pestmgt_WeedEcology"].Value = (pestmgt_WeedEcology);
            profileCommand.Parameters["@pestmgt_CompostExtracts"].Value = (pestmgt_CompostExtracts);
            profileCommand.Parameters["@pestmgt_KilledMulches"].Value = (pestmgt_KilledMulches);
            profileCommand.Parameters["@pestmgt_RowCovers"].Value = (pestmgt_RowCovers);
            profileCommand.Parameters["@pestmgt_WeederGeese"].Value = (pestmgt_WeederGeese);
            profileCommand.Parameters["@pestmgt_CulturalControl"].Value = (pestmgt_CulturalControl);
            profileCommand.Parameters["@pestmgt_LivingMulches"].Value = (pestmgt_LivingMulches);
            profileCommand.Parameters["@pestmgt_Sanitation"].Value = (pestmgt_Sanitation);
            profileCommand.Parameters["@pestmgt_DiseaseVectors"].Value = (pestmgt_DiseaseVectors);
            profileCommand.Parameters["@pestmgt_MatingDisruption"].Value = (pestmgt_MatingDisruption);
            profileCommand.Parameters["@pestmgt_SoilSolarization"].Value = (pestmgt_SoilSolarization);
            profileCommand.Parameters["@pestmgt_Other"].Value = (pestmgt_Other);
            profileCommand.Parameters["@soilmgt_NutrientMineralization"].Value = (soilmgt_NutrientMineralization);
            profileCommand.Parameters["@soilmgt_SoilMicrobiology"].Value = (soilmgt_SoilMicrobiology);
            profileCommand.Parameters["@soilmgt_SoilOrganicMatter"].Value = (soilmgt_SoilOrganicMatter);
            profileCommand.Parameters["@soilmgt_SoilQuality"].Value = (soilmgt_SoilQuality);
            profileCommand.Parameters["@soilmgt_CarbonSequestration"].Value = (soilmgt_CarbonSequestration);
            profileCommand.Parameters["@soilmgt_SoilChemistry"].Value = (soilmgt_SoilChemistry);
            profileCommand.Parameters["@soilmgt_SoilPhysics"].Value = (soilmgt_SoilPhysics);
            profileCommand.Parameters["@soilmgt_Other"].Value = (soilmgt_Other);
            profileCommand.Parameters["@nresenv_Afforestation"].Value = (nresenv_Afforestation);
            profileCommand.Parameters["@nresenv_GrassHedges"].Value = (nresenv_GrassHedges);
            profileCommand.Parameters["@nresenv_RiparianPlantings"].Value = (nresenv_RiparianPlantings);
            profileCommand.Parameters["@nresenv_Wildlife"].Value = (nresenv_Wildlife);
            profileCommand.Parameters["@nresenv_Biodiversity"].Value = (nresenv_Biodiversity);
            profileCommand.Parameters["@nresenv_GrassWaterways"].Value = (nresenv_GrassWaterways);
            profileCommand.Parameters["@nresenv_RiverbankProtection"].Value = (nresenv_RiverbankProtection);
            profileCommand.Parameters["@nresenv_Windbreaks"].Value = (nresenv_Windbreaks);
            profileCommand.Parameters["@nresenv_Biosphere"].Value = (nresenv_Biosphere);
            profileCommand.Parameters["@nresenv_HabitatEnhancement"].Value = (nresenv_HabitatEnhancement);
            profileCommand.Parameters["@nresenv_SoilStabilization"].Value = (nresenv_SoilStabilization);
            profileCommand.Parameters["@nresenv_WoodyHedges"].Value = (nresenv_WoodyHedges);
            profileCommand.Parameters["@nresenv_ConservationTillage"].Value = (nresenv_ConservationTillage);
            profileCommand.Parameters["@nresenv_Hedgerows"].Value = (nresenv_Hedgerows);
            profileCommand.Parameters["@nresenv_Terraces"].Value = (nresenv_Terraces);
            profileCommand.Parameters["@nresenv_ContourCultivation"].Value = (nresenv_ContourCultivation);
            profileCommand.Parameters["@nresenv_Indicators"].Value = (nresenv_Indicators);
            profileCommand.Parameters["@nresenv_Wetlands"].Value = (nresenv_Wetlands);
            profileCommand.Parameters["@nresenv_Other"].Value = (nresenv_Other);
            profileCommand.Parameters["@edtrain_CaseStudy"].Value = (edtrain_CaseStudy);
            profileCommand.Parameters["@edtrain_Demonstration"].Value = (edtrain_Demonstration);
            profileCommand.Parameters["@edtrain_FocusGroup"].Value = (edtrain_FocusGroup);
            profileCommand.Parameters["@edtrain_StudyCircle"].Value = (edtrain_StudyCircle);
            profileCommand.Parameters["@edtrain_Conference"].Value = (edtrain_Conference);
            profileCommand.Parameters["@edtrain_Display"].Value = (edtrain_Display);
            profileCommand.Parameters["@edtrain_Mentor"].Value = (edtrain_Mentor);
            profileCommand.Parameters["@edtrain_Workshop"].Value = (edtrain_Workshop);
            profileCommand.Parameters["@edtrain_Curriculum"].Value = (edtrain_Curriculum);
            profileCommand.Parameters["@edtrain_Extension"].Value = (edtrain_Extension);
            profileCommand.Parameters["@edtrain_Network"].Value = (edtrain_Network);
            profileCommand.Parameters["@edtrain_Database"].Value = (edtrain_Database);
            profileCommand.Parameters["@edtrain_FactSheet"].Value = (edtrain_FactSheet);
            profileCommand.Parameters["@edtrain_OnFarmResearch"].Value = (edtrain_OnFarmResearch);
            profileCommand.Parameters["@edtrain_DecisionSupportSystem"].Value = (edtrain_DecisionSupportSystem);
            profileCommand.Parameters["@edtrain_FarmerToFarmer"].Value = (edtrain_FarmerToFarmer);
            profileCommand.Parameters["@edtrain_ParticipatoryResearch"].Value = (edtrain_ParticipatoryResearch);
            profileCommand.Parameters["@edtrain_YouthEducation"].Value = (edtrain_YouthEducation);
            profileCommand.Parameters["@edtrain_Other"].Value = (edtrain_Other);
            profileCommand.Parameters["@econmkt_AlternativeEnterprise"].Value = (econmkt_AlternativeEnterprise);
            profileCommand.Parameters["@econmkt_CSA"].Value = (econmkt_CSA);
            profileCommand.Parameters["@econmkt_FeasibilityStudy"].Value = (econmkt_FeasibilityStudy);
            profileCommand.Parameters["@econmkt_RiskManagement"].Value = (econmkt_RiskManagement);
            profileCommand.Parameters["@econmkt_Budget"].Value = (econmkt_Budget);
            profileCommand.Parameters["@econmkt_CostAndReturns"].Value = (econmkt_CostAndReturns);
            profileCommand.Parameters["@econmkt_FinancialAnalysis"].Value = (econmkt_FinancialAnalysis);
            profileCommand.Parameters["@econmkt_ValueAdded"].Value = (econmkt_ValueAdded);
            profileCommand.Parameters["@econmkt_Cooperatives"].Value = (econmkt_Cooperatives);
            profileCommand.Parameters["@econmkt_DirectMarketing"].Value = (econmkt_DirectMarketing);
            profileCommand.Parameters["@econmkt_MarketStudy"].Value = (econmkt_MarketStudy);
            profileCommand.Parameters["@econmkt_FoodProductQualitySafety"].Value = (econmkt_FoodProductQualitySafety);
            profileCommand.Parameters["@econmkt_LaborEmployment"].Value = (econmkt_LaborEmployment);
            profileCommand.Parameters["@econmkt_Ecommerce"].Value = (econmkt_Ecommerce);
            profileCommand.Parameters["@econmkt_FarmToInstitution"].Value = (econmkt_FarmToInstitution);
            profileCommand.Parameters["@econmkt_Other"].Value = (econmkt_Other);
            profileCommand.Parameters["@commdev_InfrastructureAnalysis"].Value = (commdev_InfrastructureAnalysis);
            profileCommand.Parameters["@commdev_TechnicalAssistance"].Value = (commdev_TechnicalAssistance);
            profileCommand.Parameters["@commdev_NewBusinessOpportunities"].Value = (commdev_NewBusinessOpportunities);
            profileCommand.Parameters["@commdev_Partnerships"].Value = (commdev_Partnerships);
            profileCommand.Parameters["@commdev_UrbanAgriculture"].Value = (commdev_UrbanAgriculture);
            profileCommand.Parameters["@commdev_PublicParticipation"].Value = (commdev_PublicParticipation);
            profileCommand.Parameters["@commdev_UrbanRuralIntegration"].Value = (commdev_UrbanRuralIntegration);
            profileCommand.Parameters["@commdev_LocalRegionalCommunityFoodSystems"].Value = (commdev_LocalRegionalCommunityFoodSystems);
            profileCommand.Parameters["@commdev_Agritourism"].Value = (commdev_Agritourism);
            profileCommand.Parameters["@commdev_CommunityPlanning"].Value = (commdev_CommunityPlanning);
            profileCommand.Parameters["@commdev_PublicPolicy"].Value = (commdev_PublicPolicy);
            profileCommand.Parameters["@commdev_LeadershipDevelopment"].Value = (commdev_LeadershipDevelopment);
            profileCommand.Parameters["@commdev_EthnicDifferencesCulturalDemographicChange"].Value = (commdev_EthnicDifferencesCulturalDemographicChange);
            profileCommand.Parameters["@commdev_Other"].Value = (commdev_Other);
            profileCommand.Parameters["@qoflife_AnalysisOfPersonalFamilyLife"].Value = (qoflife_AnalysisOfPersonalFamilyLife);
            profileCommand.Parameters["@qoflife_SocialCapitol"].Value = (qoflife_SocialCapitol);
            profileCommand.Parameters["@qoflife_SustainabilityMeasures"].Value = (qoflife_SustainabilityMeasures);
            profileCommand.Parameters["@qoflife_CommunityServices"].Value = (qoflife_CommunityServices);
            profileCommand.Parameters["@qoflife_SocialNetworks"].Value = (qoflife_SocialNetworks);
            profileCommand.Parameters["@qoflife_EmploymentOpportunities"].Value = (qoflife_EmploymentOpportunities);
            profileCommand.Parameters["@qoflife_SocialPsychologicalIndicators"].Value = (qoflife_SocialPsychologicalIndicators);
            profileCommand.Parameters["@qoflife_Other"].Value = (qoflife_Other);
            profileCommand.Parameters["@energy_BioenergyBiofuels"].Value = (energy_BioenergyBiofuels);
            profileCommand.Parameters["@energy_WindPower"].Value = (energy_WindPower);
            profileCommand.Parameters["@energy_EnergyUseConsumption"].Value = (energy_EnergyUseConsumption);
            profileCommand.Parameters["@energy_SolarEnergy"].Value = (energy_SolarEnergy);
            profileCommand.Parameters["@energy_EnergyConservationEfficiency"].Value = (energy_EnergyConservationEfficiency);
            profileCommand.Parameters["@energy_Other"].Value = (energy_Other);
            profileCommand.Parameters["@commPlAgr_Barley"].Value = (commPlAgr_Barley);
            profileCommand.Parameters["@commPlAgr_GrassLegumeHay"].Value = (commPlAgr_GrassLegumeHay);
            profileCommand.Parameters["@commPlAgr_Peanuts"].Value = (commPlAgr_Peanuts);
            profileCommand.Parameters["@commPlAgr_Sorghum"].Value = (commPlAgr_Sorghum);
            profileCommand.Parameters["@commPlAgr_Sweetpotatoes"].Value = (commPlAgr_Sweetpotatoes);
            profileCommand.Parameters["@commPlAgr_Canola"].Value = (commPlAgr_Canola);
            profileCommand.Parameters["@commPlAgr_LegumeHay"].Value = (commPlAgr_LegumeHay);
            profileCommand.Parameters["@commPlAgr_Potatoes"].Value = (commPlAgr_Potatoes);
            profileCommand.Parameters["@commPlAgr_Soybeans"].Value = (commPlAgr_Soybeans);
            profileCommand.Parameters["@commPlAgr_Tobacco"].Value = (commPlAgr_Tobacco);
            profileCommand.Parameters["@commPlAgr_Corn"].Value = (commPlAgr_Corn);
            profileCommand.Parameters["@commPlAgr_Hops"].Value = (commPlAgr_Hops);
            profileCommand.Parameters["@commPlAgr_Rapeseed"].Value = (commPlAgr_Rapeseed);
            profileCommand.Parameters["@commPlAgr_Spelt"].Value = (commPlAgr_Spelt);
            profileCommand.Parameters["@commPlAgr_Wheat"].Value = (commPlAgr_Wheat);
            profileCommand.Parameters["@commPlAgr_Cotton"].Value = (commPlAgr_Cotton);
            profileCommand.Parameters["@commPlAgr_Kenaf"].Value = (commPlAgr_Kenaf);
            profileCommand.Parameters["@commPlAgr_Rice"].Value = (commPlAgr_Rice);
            profileCommand.Parameters["@commPlAgr_Sugarbeets"].Value = (commPlAgr_Sugarbeets);
            profileCommand.Parameters["@commPlAgr_Flax"].Value = (commPlAgr_Flax);
            profileCommand.Parameters["@commPlAgr_Millet"].Value = (commPlAgr_Millet);
            profileCommand.Parameters["@commPlAgr_Rye"].Value = (commPlAgr_Rye);
            profileCommand.Parameters["@commPlAgr_Sugarcane"].Value = (commPlAgr_Sugarcane);
            profileCommand.Parameters["@commPlAgr_GrassHay"].Value = (commPlAgr_GrassHay);
            profileCommand.Parameters["@commPlAgr_Oats"].Value = (commPlAgr_Oats);
            profileCommand.Parameters["@commPlAgr_Safflower"].Value = (commPlAgr_Safflower);
            profileCommand.Parameters["@commPlAgr_Sunflower"].Value = (commPlAgr_Sunflower);
            profileCommand.Parameters["@commPlAgr_Other"].Value = (commPlAgr_Other);
            profileCommand.Parameters["@commPlVeg_Artichokes"].Value = (commPlVeg_Artichokes);
            profileCommand.Parameters["@commPlVeg_Cabbage"].Value = (commPlVeg_Cabbage);
            profileCommand.Parameters["@commPlVeg_Escarole"].Value = (commPlVeg_Escarole);
            profileCommand.Parameters["@commPlVeg_Onions"].Value = (commPlVeg_Onions);
            profileCommand.Parameters["@commPlVeg_SweetCorn"].Value = (commPlVeg_SweetCorn);
            profileCommand.Parameters["@commPlVeg_Asparagus"].Value = (commPlVeg_Asparagus);
            profileCommand.Parameters["@commPlVeg_Carrots"].Value = (commPlVeg_Carrots);
            profileCommand.Parameters["@commPlVeg_Garlic"].Value = (commPlVeg_Garlic);
            profileCommand.Parameters["@commPlVeg_Parsnips"].Value = (commPlVeg_Parsnips);
            profileCommand.Parameters["@commPlVeg_Tomatoes"].Value = (commPlVeg_Tomatoes);
            profileCommand.Parameters["@commPlVeg_Beans"].Value = (commPlVeg_Beans);
            profileCommand.Parameters["@commPlVeg_Cauliflower"].Value = (commPlVeg_Cauliflower);
            profileCommand.Parameters["@commPlVeg_Greens"].Value = (commPlVeg_Greens);
            profileCommand.Parameters["@commPlVeg_Peas"].Value = (commPlVeg_Peas);
            profileCommand.Parameters["@commPlVeg_Turnips"].Value = (commPlVeg_Turnips);
            profileCommand.Parameters["@commPlVeg_Beets"].Value = (commPlVeg_Beets);
            profileCommand.Parameters["@commPlVeg_Celery"].Value = (commPlVeg_Celery);
            profileCommand.Parameters["@commPlVeg_Kale"].Value = (commPlVeg_Kale);
            profileCommand.Parameters["@commPlVeg_Peppers"].Value = (commPlVeg_Peppers);
            profileCommand.Parameters["@commPlVeg_Watermelon"].Value = (commPlVeg_Watermelon);
            profileCommand.Parameters["@commPlVeg_Broccoli"].Value = (commPlVeg_Broccoli);
            profileCommand.Parameters["@commPlVeg_Cucumbers"].Value = (commPlVeg_Cucumbers);
            profileCommand.Parameters["@commPlVeg_Lentils"].Value = (commPlVeg_Lentils);
            profileCommand.Parameters["@commPlVeg_Rutabagas"].Value = (commPlVeg_Rutabagas);
            profileCommand.Parameters["@commPlVeg_BrusselSprouts"].Value = (commPlVeg_BrusselSprouts);
            profileCommand.Parameters["@commPlVeg_Eggplant"].Value = (commPlVeg_Eggplant);
            profileCommand.Parameters["@commPlVeg_Lettuce"].Value = (commPlVeg_Lettuce);
            profileCommand.Parameters["@commPlVeg_Spinach"].Value = (commPlVeg_Spinach);
            profileCommand.Parameters["@commplveg_leeks"].Value = (commplveg_leeks);
            profileCommand.Parameters["@commPlVeg_Pumpkins"].Value = (commPlVeg_Pumpkins);
            profileCommand.Parameters["@commPlVeg_Squashes"].Value = (commPlVeg_Squashes);
            profileCommand.Parameters["@commPlVeg_Radishes"].Value = (commPlVeg_Radishes);
            profileCommand.Parameters["@commPlVeg_Other"].Value = (commPlVeg_Other);
            profileCommand.Parameters["@commPlFruit_Apples"].Value = (commPlFruit_Apples);
            profileCommand.Parameters["@commPlFruit_Cherries"].Value = (commPlFruit_Cherries);
            profileCommand.Parameters["@commPlFruit_Lemons"].Value = (commPlFruit_Lemons);
            profileCommand.Parameters["@commPlFruit_Peaches"].Value = (commPlFruit_Peaches);
            profileCommand.Parameters["@commPlFruit_Strawberries"].Value = (commPlFruit_Strawberries);
            profileCommand.Parameters["@commPlFruit_Apricots"].Value = (commPlFruit_Apricots);
            profileCommand.Parameters["@commPlFruit_Cranberries"].Value = (commPlFruit_Cranberries);
            profileCommand.Parameters["@commPlFruit_Limes"].Value = (commPlFruit_Limes);
            profileCommand.Parameters["@commPlFruit_Pears"].Value = (commPlFruit_Pears);
            profileCommand.Parameters["@commPlFruit_Tangerines"].Value = (commPlFruit_Tangerines);
            profileCommand.Parameters["@commPlFruit_Avocados"].Value = (commPlFruit_Avocados);
            profileCommand.Parameters["@commPlFruit_Figs"].Value = (commPlFruit_Figs);
            profileCommand.Parameters["@commPlFruit_Melons"].Value = (commPlFruit_Melons);
            profileCommand.Parameters["@commPlFruit_Pineapples"].Value = (commPlFruit_Pineapples);
            profileCommand.Parameters["@commPlFruit_Bananas"].Value = (commPlFruit_Bananas);
            profileCommand.Parameters["@commPlFruit_Grapefruit"].Value = (commPlFruit_Grapefruit);
            profileCommand.Parameters["@commPlFruit_Olives"].Value = (commPlFruit_Olives);
            profileCommand.Parameters["@commPlFruit_Plums"].Value = (commPlFruit_Plums);
            profileCommand.Parameters["@commPlFruit_Berries"].Value = (commPlFruit_Berries);
            profileCommand.Parameters["@commPlFruit_Grapes"].Value = (commPlFruit_Grapes);
            profileCommand.Parameters["@commPlFruit_Oranges"].Value = (commPlFruit_Oranges);
            profileCommand.Parameters["@commPlFruit_Quinces"].Value = (commPlFruit_Quinces);
            profileCommand.Parameters["@commPlFruit_Brambles"].Value = (commPlFruit_Brambles);
            profileCommand.Parameters["@commPlFruit_Blueberries"].Value = (commPlFruit_Blueberries);
            profileCommand.Parameters["@commPlFruit_Other"].Value = (commPlFruit_Other);
            profileCommand.Parameters["@commPlNuts_Almonds"].Value = (commPlNuts_Almonds);
            profileCommand.Parameters["@commPlNuts_Hazelnuts"].Value = (commPlNuts_Hazelnuts);
            profileCommand.Parameters["@commPlNuts_Pecans"].Value = (commPlNuts_Pecans);
            profileCommand.Parameters["@commPlNuts_Walnuts"].Value = (commPlNuts_Walnuts);
            profileCommand.Parameters["@commplnuts_chestnuts"].Value = (commplnuts_chestnuts);
            profileCommand.Parameters["@commPlNuts_Macadamia"].Value = (commPlNuts_Macadamia);
            profileCommand.Parameters["@commPlNuts_Pistachios"].Value = (commPlNuts_Pistachios);
            profileCommand.Parameters["@commPlNuts_Other"].Value = (commPlNuts_Other);
            profileCommand.Parameters["@commPlAdd_Herbs"].Value = (commPlAdd_Herbs);
            profileCommand.Parameters["@commPlAdd_Ornamentals"].Value = (commPlAdd_Ornamentals);
            profileCommand.Parameters["@commPlAdd_Trees"].Value = (commPlAdd_Trees);
            profileCommand.Parameters["@commPlAdd_Mushrooms"].Value = (commPlAdd_Mushrooms);
            profileCommand.Parameters["@commPlAdd_NativePlants"].Value = (commPlAdd_NativePlants);
            profileCommand.Parameters["@commPlAdd_Other"].Value = (commPlAdd_Other);
            profileCommand.Parameters["@commAnim_Beef"].Value = (commAnim_Beef);
            profileCommand.Parameters["@commAnim_Chicken"].Value = (commAnim_Chicken);
            profileCommand.Parameters["@commAnim_Rabbits"].Value = (commAnim_Rabbits);
            profileCommand.Parameters["@commAnim_Swine"].Value = (commAnim_Swine);
            profileCommand.Parameters["@commAnim_Dairy"].Value = (commAnim_Dairy);
            profileCommand.Parameters["@commAnim_Goats"].Value = (commAnim_Goats);
            profileCommand.Parameters["@commAnim_Sheep"].Value = (commAnim_Sheep);
            profileCommand.Parameters["@commAnim_Turkeys"].Value = (commAnim_Turkeys);
            profileCommand.Parameters["@commAnim_Other"].Value = (commAnim_Other);
            profileCommand.Parameters["@commMisc_Bees"].Value = (commMisc_Bees);
            profileCommand.Parameters["@commMisc_Fish"].Value = (commMisc_Fish);
            profileCommand.Parameters["@commMisc_Ratites"].Value = (commMisc_Ratites);
            profileCommand.Parameters["@commMisc_Shellfish"].Value = (commMisc_Shellfish);
            profileCommand.Parameters["@commMisc_Other"].Value = (commMisc_Other);
            profileCommand.Parameters["@submitted"].Value = (submitted);

            profileConnection.Open();
            updateSuccess = (bool)profileCommand.ExecuteScalar();

            profileConnection.Dispose();

            return updateSuccess;

        }

        public int cancelNewHighProfileProjectFromDB(string user, int sKey, int profileID)
        {
            string profileSQL;
            string profileConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection profileConnection;
            SqlCommand profileCommand;
            
            profileConnection = new SqlConnection(profileConnString);

            profileSQL = "DaikonProfilesProfileDeleteHigh";
            profileCommand = new SqlCommand(profileSQL, profileConnection);
            profileCommand.CommandType = CommandType.StoredProcedure;

            profileCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            profileCommand.Parameters.Add("@sKey", SqlDbType.Int);
            profileCommand.Parameters.Add("@profileID", SqlDbType.BigInt);  

            profileCommand.Parameters["@user"].Value = user;
            profileCommand.Parameters["@sKey"].Value = sKey;
            profileCommand.Parameters["@profileID"].Value = profileID;

            profileConnection.Open();
            profileCommand.ExecuteScalar();
           
            profileConnection.Dispose();

            return 1;
        }

        public int saveNewHighProfileProjectToDB(string user, int sKey, string projectNumber)
        {
            string profileSQL;
            string profileConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection profileConnection;
            SqlCommand profileCommand;
           

            profileConnection = new SqlConnection(profileConnString);

            profileSQL = "DaikonProfilesProfileInsertHighForProject";
            profileCommand = new SqlCommand(profileSQL, profileConnection);
            profileCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            profileCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            profileCommand.Parameters.Add("@sKey", SqlDbType.Int);
            profileCommand.Parameters.Add("@projNum", SqlDbType.VarChar, 50);           

            profileCommand.Parameters.Add("@categoryA", SqlDbType.VarChar, 50);
            profileCommand.Parameters.Add("@catAother", SqlDbType.VarChar, 80);
            profileCommand.Parameters.Add("@categoryB", SqlDbType.VarChar, 50);
            profileCommand.Parameters.Add("@catBother", SqlDbType.VarChar, 80);

            profileCommand.Parameters.Add("@aud_farmranchers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@aud_educators", SqlDbType.Bit);
            profileCommand.Parameters.Add("@aud_researchers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@aud_consumers", SqlDbType.Bit);

            profileCommand.Parameters.Add("@techlvl_beginner", SqlDbType.Bit);
            profileCommand.Parameters.Add("@techlvl_intermediate", SqlDbType.Bit);
            profileCommand.Parameters.Add("@techlvl_advanced", SqlDbType.Bit);

            profileCommand.Parameters.Add("@inv_planning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_present", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_research", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_land", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_planningcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_presentcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_researchcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_landcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_numparticipants", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_numideas", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_extplanning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_extapplied", SqlDbType.Bit);

            profileCommand.Parameters.Add(keyOutput);

            profileCommand.Parameters["@user"].Value = user;
            profileCommand.Parameters["@sKey"].Value = sKey;
            profileCommand.Parameters["@projNum"].Value = projectNumber;
            

            profileCommand.Parameters["@categoryA"].Value = categoryA;
            if (catAother == null)
                profileCommand.Parameters["@catAother"].Value = "";
            else
                profileCommand.Parameters["@catAother"].Value = catAother;
            profileCommand.Parameters["@categoryB"].Value = categoryB;
            if (catBother == null)
                profileCommand.Parameters["@catBother"].Value = "";
            else
                profileCommand.Parameters["@catBother"].Value = catBother;

            profileCommand.Parameters["@aud_farmranchers"].Value = aud_farmranchers;
            profileCommand.Parameters["@aud_educators"].Value = aud_educators;
            profileCommand.Parameters["@aud_researchers"].Value = aud_researchers;
            profileCommand.Parameters["@aud_consumers"].Value = aud_consumers;

            profileCommand.Parameters["@techlvl_beginner"].Value = techlvl_beginner;
            profileCommand.Parameters["@techlvl_intermediate"].Value = techlvl_intermediate;
            profileCommand.Parameters["@techlvl_advanced"].Value = techlvl_advanced;

            profileCommand.Parameters["@inv_planning"].Value = inv_planning;
            profileCommand.Parameters["@inv_present"].Value = inv_present;
            profileCommand.Parameters["@inv_research"].Value = inv_research;
            profileCommand.Parameters["@inv_land"].Value = inv_land;
            profileCommand.Parameters["@inv_planningcount"].Value =inv_planningcount;
            profileCommand.Parameters["@inv_presentcount"].Value = inv_presentcount;
            profileCommand.Parameters["@inv_researchcount"].Value = inv_researchcount;
            profileCommand.Parameters["@inv_landcount"].Value = inv_landcount;
            profileCommand.Parameters["@inv_numparticipants"].Value = 0;
            profileCommand.Parameters["@inv_numideas"].Value = 0;

            profileCommand.Parameters["@inv_extplanning"].Value = (inv_extplanning);
            profileCommand.Parameters["@inv_extapplied"].Value = (inv_extapplied);

            profileConnection.Open();
            profileCommand.ExecuteScalar();
            profileID = Convert.ToInt32(keyOutput.Value);
            ProfileID = profileID;
            
            profileConnection.Dispose();

            return profileID;
        }

        public bool saveNewLowProfileProjectToDB(string user, int sKey)
        {
            string profileSQL;
            string profileConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection profileConnection;
            SqlCommand profileCommand;
           
            profileConnection = new SqlConnection(profileConnString);

            profileSQL = "DaikonProfilesProfileInsertLow";
            profileCommand = new SqlCommand(profileSQL, profileConnection);
            profileCommand.CommandType = CommandType.StoredProcedure;

            profileCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            profileCommand.Parameters.Add("@sKey", SqlDbType.Int);
            profileCommand.Parameters.Add("@profileID", SqlDbType.BigInt);
            
            profileCommand.Parameters.Add("@intgfrs_AgroecosystemAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_WholeFarmPlanning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_HolisticManagement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_OrganicAgriculture", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_Permaculture", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@cropprd_Agroforestry", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_FoliarFeeding", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_NutrientCycling", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_StripCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_BiologicalInoculants", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Forestry", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_OrganicFertilizers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_StubbleMulching", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_ContinuousCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_GreenManures", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_OrganicMatter", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_TissueAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_CoverCrops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Intercropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Permaculture", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Transitioning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_DoubleCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_MinimumTillage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_ReducedApplications", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Earthworms", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_MultipleCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_RelayCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Fallow", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_MunicipalWastes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_RidgeTillage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Fertigation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_NoTill", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_SoilAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_CatchCrops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_CropRotation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Irrigation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_CropBreeding", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@animprd_AlternativeFeedstuffs", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_FeedRations", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_MultispeciesGrazing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_StockpiledForages", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_AlternativeHousing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_FreeRange", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_PastureFertility", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Vaccines", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_AlternParasiteControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_HerbalMedicines", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_PastureRenovation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_WateringSystem", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_AnimalProtection", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Homeopathy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_PreventivePractices", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_WinterForage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Composting", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Implants", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Probiotics", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_ContinuousGrazing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Inoculants", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_RangeImprovement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_FeedAdditives", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_ManureManagement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_RotationalGrazing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_FeedFormulation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_MineralSupplements", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_ShadeShelter", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Therapeutics", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_LivestockBreeding", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_StockingRate", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_grazingmanagement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@pestmgt_Allelopathy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_EconomicThreshold", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_MechanicalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_SmotherCrops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_BiologicalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Eradication", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_PhysicalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Traps", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_BiorationalPesticides", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Flame", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_PlasticMulching", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_TrapCrops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_BotanicalPesticides", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_FieldMonitoring", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_PrecisionCultivation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_VegetativeMulching", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_ChemicalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_GeneticResistance", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_PrecisionHerbicideUse", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_WeatherMonitoring", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Competition", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_IPM", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Prevention", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_WeedEcology", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_CompostExtracts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_KilledMulches", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_RowCovers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_WeederGeese", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_CulturalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_LivingMulches", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Sanitation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_DiseaseVectors", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_MatingDisruption", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_SoilSolarization", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@soilmgt_NutrientMineralization", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilMicrobiology", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilOrganicMatter", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilQuality", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_CarbonSequestration", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilChemistry", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilPhysics", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@nresenv_Afforestation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_GrassHedges", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_RiparianPlantings", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Wildlife", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Biodiversity", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_GrassWaterways", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_RiverbankProtection", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Windbreaks", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Biosphere", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_HabitatEnhancement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_SoilStabilization", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_WoodyHedges", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_ConservationTillage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Hedgerows", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Terraces", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_ContourCultivation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Indicators", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Wetlands", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@edtrain_CaseStudy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Demonstration", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_FocusGroup", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_StudyCircle", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Conference", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Display", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Mentor", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Workshop", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Curriculum", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Extension", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Network", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Database", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_FactSheet", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_OnFarmResearch", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_DecisionSupportSystem", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_FarmerToFarmer", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_ParticipatoryResearch", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_YouthEducation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@econmkt_AlternativeEnterprise", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_CSA", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_FeasibilityStudy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_RiskManagement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_Budget", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_CostAndReturns", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_FinancialAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_ValueAdded", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_Cooperatives", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_DirectMarketing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_MarketStudy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_FoodProductQualitySafety", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_LaborEmployment", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_Ecommerce", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_FarmToInstitution", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@commdev_InfrastructureAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_TechnicalAssistance", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_NewBusinessOpportunities", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_Partnerships", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_UrbanAgriculture", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_PublicParticipation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_UrbanRuralIntegration", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_LocalRegionalCommunityFoodSystems", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_Agritourism", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_PublicPolicy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_CommunityPlanning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_LeadershipDevelopment", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_EthnicDifferencesCulturalDemographicChange", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@qoflife_AnalysisOfPersonalFamilyLife", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_SocialCapitol", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_SustainabilityMeasures", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_CommunityServices", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_SocialNetworks", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_EmploymentOpportunities", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_SocialPsychologicalIndicators", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@energy_BioenergyBiofuels", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_WindPower", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_EnergyUseConsumption", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_SolarEnergy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_EnergyConservationEfficiency", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@commPlAgr_Barley", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_GrassLegumeHay", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Peanuts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sorghum", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sweetpotatoes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Canola", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_LegumeHay", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Potatoes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Soybeans", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Tobacco", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Corn", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Hops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Rapeseed", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Spelt", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Wheat", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Cotton", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Kenaf", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Rice", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sugarbeets", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Flax", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Millet", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Rye", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sugarcane", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_GrassHay", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Oats", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Safflower", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sunflower", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commPlVeg_Artichokes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Cabbage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Escarole", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Onions", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_SweetCorn", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Asparagus", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Carrots", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Garlic", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Parsnips", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Tomatoes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Beans", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Cauliflower", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Greens", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Peas", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Turnips", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Beets", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Celery", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Kale", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Peppers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Watermelon", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Broccoli", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Cucumbers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Lentils", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Rutabagas", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_BrusselSprouts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Eggplant", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Lettuce", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Spinach", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commplveg_leeks", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Pumpkins", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Squashes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Radishes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@commPlFruit_Apples", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Cherries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Lemons", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Peaches", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Strawberries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Apricots", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Cranberries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Limes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Pears", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Tangerines", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Avocados", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Figs", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Melons", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Pineapples", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Bananas", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Grapefruit", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Olives", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Plums", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Berries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Grapes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Oranges", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Quinces", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Brambles", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Blueberries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commPlNuts_Almonds", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Hazelnuts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Pecans", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Walnuts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commplnuts_chestnuts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Macadamia", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Pistachios", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commPlAdd_Herbs", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_Ornamentals", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_Trees", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_Mushrooms", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_NativePlants", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@commAnim_Beef", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Chicken", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Rabbits", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Swine", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Dairy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Goats", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Sheep", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Turkeys", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commMisc_Bees", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commMisc_Fish", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commMisc_Ratites", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commMisc_Shellfish", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commMisc_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@submitted", SqlDbType.Bit);

            profileCommand.Parameters["@user"].Value = dbNullify(user);
            profileCommand.Parameters["@sKey"].Value = sKey;
            profileCommand.Parameters["@profileID"].Value = profileID;
           

            profileCommand.Parameters["@intgfrs_AgroecosystemAnalysis"].Value = (intgfrs_AgroecosystemAnalysis);
            profileCommand.Parameters["@intgfrs_WholeFarmPlanning"].Value = (intgfrs_WholeFarmPlanning);
            profileCommand.Parameters["@intgfrs_HolisticManagement"].Value = (intgfrs_HolisticManagement);
            profileCommand.Parameters["@intgfrs_OrganicAgriculture"].Value = (intgfrs_OrganicAgriculture);
            profileCommand.Parameters["@intgfrs_Permaculture"].Value = (intgfrs_Permaculture);
            profileCommand.Parameters["@intgfrs_Other"].Value = (intgfrs_Other);

            profileCommand.Parameters["@cropprd_Agroforestry"].Value = (cropprd_Agroforestry);
            profileCommand.Parameters["@cropprd_FoliarFeeding"].Value = (cropprd_FoliarFeeding);
            profileCommand.Parameters["@cropprd_NutrientCycling"].Value = (cropprd_NutrientCycling);
            profileCommand.Parameters["@cropprd_StripCropping"].Value = (cropprd_StripCropping);
            profileCommand.Parameters["@cropprd_BiologicalInoculants"].Value = (cropprd_BiologicalInoculants);
            profileCommand.Parameters["@cropprd_Forestry"].Value = (cropprd_Forestry);
            profileCommand.Parameters["@cropprd_OrganicFertilizers"].Value = (cropprd_OrganicFertilizers);
            profileCommand.Parameters["@cropprd_StubbleMulching"].Value = (cropprd_StubbleMulching);
            profileCommand.Parameters["@cropprd_ContinuousCropping"].Value = (cropprd_ContinuousCropping);
            profileCommand.Parameters["@cropprd_GreenManures"].Value = (cropprd_GreenManures);
            profileCommand.Parameters["@cropprd_OrganicMatter"].Value = (cropprd_OrganicMatter);
            profileCommand.Parameters["@cropprd_TissueAnalysis"].Value = (cropprd_TissueAnalysis);
            profileCommand.Parameters["@cropprd_CoverCrops"].Value = (cropprd_CoverCrops);
            profileCommand.Parameters["@cropprd_Intercropping"].Value = (cropprd_Intercropping);
            profileCommand.Parameters["@cropprd_Permaculture"].Value = (cropprd_Permaculture);
            profileCommand.Parameters["@cropprd_Transitioning"].Value = (cropprd_Transitioning);
            profileCommand.Parameters["@cropprd_DoubleCropping"].Value = (cropprd_DoubleCropping);
            profileCommand.Parameters["@cropprd_MinimumTillage"].Value = (cropprd_MinimumTillage);
            profileCommand.Parameters["@cropprd_ReducedApplications"].Value = (cropprd_ReducedApplications);
            profileCommand.Parameters["@cropprd_Earthworms"].Value = (cropprd_Earthworms);
            profileCommand.Parameters["@cropprd_MultipleCropping"].Value = (cropprd_MultipleCropping);
            profileCommand.Parameters["@cropprd_RelayCropping"].Value = (cropprd_RelayCropping);
            profileCommand.Parameters["@cropprd_Fallow"].Value = (cropprd_Fallow);
            profileCommand.Parameters["@cropprd_MunicipalWastes"].Value = (cropprd_MunicipalWastes);
            profileCommand.Parameters["@cropprd_RidgeTillage"].Value = (cropprd_RidgeTillage);
            profileCommand.Parameters["@cropprd_Fertigation"].Value = (cropprd_Fertigation);
            profileCommand.Parameters["@cropprd_NoTill"].Value = (cropprd_NoTill);
            profileCommand.Parameters["@cropprd_SoilAnalysis"].Value = (cropprd_SoilAnalysis);
            profileCommand.Parameters["@cropprd_CatchCrops"].Value = (cropprd_CatchCrops);
            profileCommand.Parameters["@cropprd_CropRotation"].Value = (cropprd_CropRotation);
            profileCommand.Parameters["@cropprd_CropBreeding"].Value = (cropprd_CropBreeding);
            profileCommand.Parameters["@cropprd_Irrigation"].Value = (cropprd_Irrigation);
            profileCommand.Parameters["@cropprd_Other"].Value = (cropprd_Other);

            profileCommand.Parameters["@animprd_AlternativeFeedstuffs"].Value = (animprd_AlternativeFeedstuffs);
            profileCommand.Parameters["@animprd_FeedRations"].Value = (animprd_FeedRations);
            profileCommand.Parameters["@animprd_MultispeciesGrazing"].Value = (animprd_MultispeciesGrazing);
            profileCommand.Parameters["@animprd_StockpiledForages"].Value = (animprd_StockpiledForages);
            profileCommand.Parameters["@animprd_AlternativeHousing"].Value = (animprd_AlternativeHousing);
            profileCommand.Parameters["@animprd_FreeRange"].Value = (animprd_FreeRange);
            profileCommand.Parameters["@animprd_PastureFertility"].Value = (animprd_PastureFertility);
            profileCommand.Parameters["@animprd_Vaccines"].Value = (animprd_Vaccines);
            profileCommand.Parameters["@animprd_AlternParasiteControl"].Value = (animprd_AlternParasiteControl);
            profileCommand.Parameters["@animprd_HerbalMedicines"].Value = (animprd_HerbalMedicines);
            profileCommand.Parameters["@animprd_PastureRenovation"].Value = (animprd_PastureRenovation);
            profileCommand.Parameters["@animprd_WateringSystem"].Value = (animprd_WateringSystem);
            profileCommand.Parameters["@animprd_AnimalProtection"].Value = (animprd_AnimalProtection);
            profileCommand.Parameters["@animprd_Homeopathy"].Value = (animprd_Homeopathy);
            profileCommand.Parameters["@animprd_PreventivePractices"].Value = (animprd_PreventivePractices);
            profileCommand.Parameters["@animprd_WinterForage"].Value = (animprd_WinterForage);
            profileCommand.Parameters["@animprd_Composting"].Value = (animprd_Composting);
            profileCommand.Parameters["@animprd_Implants"].Value = (animprd_Implants);
            profileCommand.Parameters["@animprd_Probiotics"].Value = (animprd_Probiotics);
            profileCommand.Parameters["@animprd_ContinuousGrazing"].Value = (animprd_ContinuousGrazing);
            profileCommand.Parameters["@animprd_Inoculants"].Value = (animprd_Inoculants);
            profileCommand.Parameters["@animprd_RangeImprovement"].Value = (animprd_RangeImprovement);
            profileCommand.Parameters["@animprd_FeedAdditives"].Value = (animprd_FeedAdditives);
            profileCommand.Parameters["@animprd_ManureManagement"].Value = (animprd_ManureManagement);
            profileCommand.Parameters["@animprd_RotationalGrazing"].Value = (animprd_RotationalGrazing);
            profileCommand.Parameters["@animprd_FeedFormulation"].Value = (animprd_FeedFormulation);
            profileCommand.Parameters["@animprd_MineralSupplements"].Value = (animprd_MineralSupplements);
            profileCommand.Parameters["@animprd_ShadeShelter"].Value = (animprd_ShadeShelter);
            profileCommand.Parameters["@animprd_Therapeutics"].Value = (animprd_Therapeutics);
            profileCommand.Parameters["@animprd_LivestockBreeding"].Value = (animprd_LivestockBreeding);
            profileCommand.Parameters["@animprd_StockingRate"].Value = (animprd_StockingRate);
            profileCommand.Parameters["@animprd_grazingmanagement"].Value = (animprd_grazingmanagement);
            profileCommand.Parameters["@animprd_Other"].Value = (animprd_Other);

            profileCommand.Parameters["@pestmgt_Allelopathy"].Value = (pestmgt_Allelopathy);
            profileCommand.Parameters["@pestmgt_EconomicThreshold"].Value = (pestmgt_EconomicThreshold);
            profileCommand.Parameters["@pestmgt_MechanicalControl"].Value = (pestmgt_MechanicalControl);
            profileCommand.Parameters["@pestmgt_SmotherCrops"].Value = (pestmgt_SmotherCrops);
            profileCommand.Parameters["@pestmgt_BiologicalControl"].Value = (pestmgt_BiologicalControl);
            profileCommand.Parameters["@pestmgt_Eradication"].Value = (pestmgt_Eradication);
            profileCommand.Parameters["@pestmgt_PhysicalControl"].Value = (pestmgt_PhysicalControl);
            profileCommand.Parameters["@pestmgt_Traps"].Value = (pestmgt_Traps);
            profileCommand.Parameters["@pestmgt_BiorationalPesticides"].Value = (pestmgt_BiorationalPesticides);
            profileCommand.Parameters["@pestmgt_Flame"].Value = (pestmgt_Flame);
            profileCommand.Parameters["@pestmgt_PlasticMulching"].Value = (pestmgt_PlasticMulching);
            profileCommand.Parameters["@pestmgt_TrapCrops"].Value = (pestmgt_TrapCrops);
            profileCommand.Parameters["@pestmgt_BotanicalPesticides"].Value = (pestmgt_BotanicalPesticides);
            profileCommand.Parameters["@pestmgt_FieldMonitoring"].Value = (pestmgt_FieldMonitoring);
            profileCommand.Parameters["@pestmgt_PrecisionCultivation"].Value = (pestmgt_PrecisionCultivation);
            profileCommand.Parameters["@pestmgt_VegetativeMulching"].Value = (pestmgt_VegetativeMulching);
            profileCommand.Parameters["@pestmgt_ChemicalControl"].Value = (pestmgt_ChemicalControl);
            profileCommand.Parameters["@pestmgt_GeneticResistance"].Value = (pestmgt_GeneticResistance);
            profileCommand.Parameters["@pestmgt_PrecisionHerbicideUse"].Value = (pestmgt_PrecisionHerbicideUse);
            profileCommand.Parameters["@pestmgt_WeatherMonitoring"].Value = (pestmgt_WeatherMonitoring);
            profileCommand.Parameters["@pestmgt_Competition"].Value = (pestmgt_Competition);
            profileCommand.Parameters["@pestmgt_IPM"].Value = (pestmgt_IPM);
            profileCommand.Parameters["@pestmgt_Prevention"].Value = (pestmgt_Prevention);
            profileCommand.Parameters["@pestmgt_WeedEcology"].Value = (pestmgt_WeedEcology);
            profileCommand.Parameters["@pestmgt_CompostExtracts"].Value = (pestmgt_CompostExtracts);
            profileCommand.Parameters["@pestmgt_KilledMulches"].Value = (pestmgt_KilledMulches);
            profileCommand.Parameters["@pestmgt_RowCovers"].Value = (pestmgt_RowCovers);
            profileCommand.Parameters["@pestmgt_WeederGeese"].Value = (pestmgt_WeederGeese);
            profileCommand.Parameters["@pestmgt_CulturalControl"].Value = (pestmgt_CulturalControl);
            profileCommand.Parameters["@pestmgt_LivingMulches"].Value = (pestmgt_LivingMulches);
            profileCommand.Parameters["@pestmgt_Sanitation"].Value = (pestmgt_Sanitation);
            profileCommand.Parameters["@pestmgt_DiseaseVectors"].Value = (pestmgt_DiseaseVectors);
            profileCommand.Parameters["@pestmgt_MatingDisruption"].Value = (pestmgt_MatingDisruption);
            profileCommand.Parameters["@pestmgt_SoilSolarization"].Value = (pestmgt_SoilSolarization);
            profileCommand.Parameters["@pestmgt_Other"].Value = (pestmgt_Other);

            profileCommand.Parameters["@soilmgt_NutrientMineralization"].Value = (soilmgt_NutrientMineralization);
            profileCommand.Parameters["@soilmgt_SoilMicrobiology"].Value = (soilmgt_SoilMicrobiology);
            profileCommand.Parameters["@soilmgt_SoilOrganicMatter"].Value = (soilmgt_SoilOrganicMatter);
            profileCommand.Parameters["@soilmgt_SoilQuality"].Value = (soilmgt_SoilQuality);
            profileCommand.Parameters["@soilmgt_CarbonSequestration"].Value = (soilmgt_CarbonSequestration);
            profileCommand.Parameters["@soilmgt_SoilChemistry"].Value = (soilmgt_SoilChemistry);
            profileCommand.Parameters["@soilmgt_SoilPhysics"].Value = (soilmgt_SoilPhysics);
            profileCommand.Parameters["@soilmgt_Other"].Value = (soilmgt_Other);

            profileCommand.Parameters["@nresenv_Afforestation"].Value = (nresenv_Afforestation);
            profileCommand.Parameters["@nresenv_GrassHedges"].Value = (nresenv_GrassHedges);
            profileCommand.Parameters["@nresenv_RiparianPlantings"].Value = (nresenv_RiparianPlantings);
            profileCommand.Parameters["@nresenv_Wildlife"].Value = (nresenv_Wildlife);
            profileCommand.Parameters["@nresenv_Biodiversity"].Value = (nresenv_Biodiversity);
            profileCommand.Parameters["@nresenv_GrassWaterways"].Value = (nresenv_GrassWaterways);
            profileCommand.Parameters["@nresenv_RiverbankProtection"].Value = (nresenv_RiverbankProtection);
            profileCommand.Parameters["@nresenv_Windbreaks"].Value = (nresenv_Windbreaks);
            profileCommand.Parameters["@nresenv_Biosphere"].Value = (nresenv_Biosphere);
            profileCommand.Parameters["@nresenv_HabitatEnhancement"].Value = (nresenv_HabitatEnhancement);
            profileCommand.Parameters["@nresenv_SoilStabilization"].Value = (nresenv_SoilStabilization);
            profileCommand.Parameters["@nresenv_WoodyHedges"].Value = (nresenv_WoodyHedges);
            profileCommand.Parameters["@nresenv_ConservationTillage"].Value = (nresenv_ConservationTillage);
            profileCommand.Parameters["@nresenv_Hedgerows"].Value = (nresenv_Hedgerows);
            profileCommand.Parameters["@nresenv_Terraces"].Value = (nresenv_Terraces);
            profileCommand.Parameters["@nresenv_ContourCultivation"].Value = (nresenv_ContourCultivation);
            profileCommand.Parameters["@nresenv_Indicators"].Value = (nresenv_Indicators);
            profileCommand.Parameters["@nresenv_Wetlands"].Value = (nresenv_Wetlands);
            profileCommand.Parameters["@nresenv_Other"].Value = (nresenv_Other);

            profileCommand.Parameters["@edtrain_CaseStudy"].Value = (edtrain_CaseStudy);
            profileCommand.Parameters["@edtrain_Demonstration"].Value = (edtrain_Demonstration);
            profileCommand.Parameters["@edtrain_FocusGroup"].Value = (edtrain_FocusGroup);
            profileCommand.Parameters["@edtrain_StudyCircle"].Value = (edtrain_StudyCircle);
            profileCommand.Parameters["@edtrain_Conference"].Value = (edtrain_Conference);
            profileCommand.Parameters["@edtrain_Display"].Value = (edtrain_Display);
            profileCommand.Parameters["@edtrain_Mentor"].Value = (edtrain_Mentor);
            profileCommand.Parameters["@edtrain_Workshop"].Value = (edtrain_Workshop);
            profileCommand.Parameters["@edtrain_Curriculum"].Value = (edtrain_Curriculum);
            profileCommand.Parameters["@edtrain_Extension"].Value = (edtrain_Extension);
            profileCommand.Parameters["@edtrain_Network"].Value = (edtrain_Network);
            profileCommand.Parameters["@edtrain_Database"].Value = (edtrain_Database);
            profileCommand.Parameters["@edtrain_FactSheet"].Value = (edtrain_FactSheet);
            profileCommand.Parameters["@edtrain_OnFarmResearch"].Value = (edtrain_OnFarmResearch);
            profileCommand.Parameters["@edtrain_DecisionSupportSystem"].Value = (edtrain_DecisionSupportSystem);
            profileCommand.Parameters["@edtrain_FarmerToFarmer"].Value = (edtrain_FarmerToFarmer);
            profileCommand.Parameters["@edtrain_ParticipatoryResearch"].Value = (edtrain_ParticipatoryResearch);
            profileCommand.Parameters["@edtrain_YouthEducation"].Value = (edtrain_YouthEducation);
            profileCommand.Parameters["@edtrain_Other"].Value = (edtrain_Other);

            profileCommand.Parameters["@econmkt_AlternativeEnterprise"].Value = (econmkt_AlternativeEnterprise);
            profileCommand.Parameters["@econmkt_CSA"].Value = (econmkt_CSA);
            profileCommand.Parameters["@econmkt_FeasibilityStudy"].Value = (econmkt_FeasibilityStudy);
            profileCommand.Parameters["@econmkt_RiskManagement"].Value = (econmkt_RiskManagement);
            profileCommand.Parameters["@econmkt_Budget"].Value = (econmkt_Budget);
            profileCommand.Parameters["@econmkt_CostAndReturns"].Value = (econmkt_CostAndReturns);
            profileCommand.Parameters["@econmkt_FinancialAnalysis"].Value = (econmkt_FinancialAnalysis);
            profileCommand.Parameters["@econmkt_ValueAdded"].Value = (econmkt_ValueAdded);
            profileCommand.Parameters["@econmkt_Cooperatives"].Value = (econmkt_Cooperatives);
            profileCommand.Parameters["@econmkt_DirectMarketing"].Value = (econmkt_DirectMarketing);
            profileCommand.Parameters["@econmkt_MarketStudy"].Value = (econmkt_MarketStudy);
            profileCommand.Parameters["@econmkt_FoodProductQualitySafety"].Value = (econmkt_FoodProductQualitySafety);
            profileCommand.Parameters["@econmkt_LaborEmployment"].Value = (econmkt_LaborEmployment);
            profileCommand.Parameters["@econmkt_Ecommerce"].Value = (econmkt_Ecommerce);
            profileCommand.Parameters["@econmkt_FarmToInstitution"].Value = (econmkt_FarmToInstitution);
            profileCommand.Parameters["@econmkt_Other"].Value = (econmkt_Other);

            profileCommand.Parameters["@commdev_InfrastructureAnalysis"].Value = (commdev_InfrastructureAnalysis);
            profileCommand.Parameters["@commdev_TechnicalAssistance"].Value = (commdev_TechnicalAssistance);
            profileCommand.Parameters["@commdev_NewBusinessOpportunities"].Value = (commdev_NewBusinessOpportunities);
            profileCommand.Parameters["@commdev_Partnerships"].Value = (commdev_Partnerships);
            profileCommand.Parameters["@commdev_UrbanAgriculture"].Value = (commdev_UrbanAgriculture);
            profileCommand.Parameters["@commdev_PublicParticipation"].Value = (commdev_PublicParticipation);
            profileCommand.Parameters["@commdev_UrbanRuralIntegration"].Value = (commdev_UrbanRuralIntegration);
            profileCommand.Parameters["@commdev_LocalRegionalCommunityFoodSystems"].Value = (commdev_LocalRegionalCommunityFoodSystems);
            profileCommand.Parameters["@commdev_Agritourism"].Value = (commdev_Agritourism);
            profileCommand.Parameters["@commdev_CommunityPlanning"].Value = (commdev_CommunityPlanning);
            profileCommand.Parameters["@commdev_PublicPolicy"].Value = (commdev_PublicPolicy);
            profileCommand.Parameters["@commdev_LeadershipDevelopment"].Value = (commdev_LeadershipDevelopment);
            profileCommand.Parameters["@commdev_EthnicDifferencesCulturalDemographicChange"].Value = (commdev_EthnicDifferencesCulturalDemographicChange);
            profileCommand.Parameters["@commdev_Other"].Value = (commdev_Other);

            profileCommand.Parameters["@qoflife_AnalysisOfPersonalFamilyLife"].Value = (qoflife_AnalysisOfPersonalFamilyLife);
            profileCommand.Parameters["@qoflife_SocialCapitol"].Value = (qoflife_SocialCapitol);
            profileCommand.Parameters["@qoflife_SustainabilityMeasures"].Value = (qoflife_SustainabilityMeasures);
            profileCommand.Parameters["@qoflife_CommunityServices"].Value = (qoflife_CommunityServices);
            profileCommand.Parameters["@qoflife_SocialNetworks"].Value = (qoflife_SocialNetworks);
            profileCommand.Parameters["@qoflife_EmploymentOpportunities"].Value = (qoflife_EmploymentOpportunities);
            profileCommand.Parameters["@qoflife_SocialPsychologicalIndicators"].Value = (qoflife_SocialPsychologicalIndicators);
            profileCommand.Parameters["@qoflife_Other"].Value = (qoflife_Other);

            profileCommand.Parameters["@energy_BioenergyBiofuels"].Value = (energy_BioenergyBiofuels);
            profileCommand.Parameters["@energy_WindPower"].Value = (energy_WindPower);
            profileCommand.Parameters["@energy_EnergyUseConsumption"].Value = (energy_EnergyUseConsumption);
            profileCommand.Parameters["@energy_SolarEnergy"].Value = (energy_SolarEnergy);
            profileCommand.Parameters["@energy_EnergyConservationEfficiency"].Value = (energy_EnergyConservationEfficiency);
            profileCommand.Parameters["@energy_Other"].Value = (energy_Other);

            profileCommand.Parameters["@commPlAgr_Barley"].Value = (commPlAgr_Barley);
            profileCommand.Parameters["@commPlAgr_GrassLegumeHay"].Value = (commPlAgr_GrassLegumeHay);
            profileCommand.Parameters["@commPlAgr_Peanuts"].Value = (commPlAgr_Peanuts);
            profileCommand.Parameters["@commPlAgr_Sorghum"].Value = (commPlAgr_Sorghum);
            profileCommand.Parameters["@commPlAgr_Sweetpotatoes"].Value = (commPlAgr_Sweetpotatoes);
            profileCommand.Parameters["@commPlAgr_Canola"].Value = (commPlAgr_Canola);
            profileCommand.Parameters["@commPlAgr_LegumeHay"].Value = (commPlAgr_LegumeHay);
            profileCommand.Parameters["@commPlAgr_Potatoes"].Value = (commPlAgr_Potatoes);
            profileCommand.Parameters["@commPlAgr_Soybeans"].Value = (commPlAgr_Soybeans);
            profileCommand.Parameters["@commPlAgr_Tobacco"].Value = (commPlAgr_Tobacco);
            profileCommand.Parameters["@commPlAgr_Corn"].Value = (commPlAgr_Corn);
            profileCommand.Parameters["@commPlAgr_Hops"].Value = (commPlAgr_Hops);
            profileCommand.Parameters["@commPlAgr_Rapeseed"].Value = (commPlAgr_Rapeseed);
            profileCommand.Parameters["@commPlAgr_Spelt"].Value = (commPlAgr_Spelt);
            profileCommand.Parameters["@commPlAgr_Wheat"].Value = (commPlAgr_Wheat);
            profileCommand.Parameters["@commPlAgr_Cotton"].Value = (commPlAgr_Cotton);
            profileCommand.Parameters["@commPlAgr_Kenaf"].Value = (commPlAgr_Kenaf);
            profileCommand.Parameters["@commPlAgr_Rice"].Value = (commPlAgr_Rice);
            profileCommand.Parameters["@commPlAgr_Sugarbeets"].Value = (commPlAgr_Sugarbeets);
            profileCommand.Parameters["@commPlAgr_Flax"].Value = (commPlAgr_Flax);
            profileCommand.Parameters["@commPlAgr_Millet"].Value = (commPlAgr_Millet);
            profileCommand.Parameters["@commPlAgr_Rye"].Value = (commPlAgr_Rye);
            profileCommand.Parameters["@commPlAgr_Sugarcane"].Value = (commPlAgr_Sugarcane);
            profileCommand.Parameters["@commPlAgr_GrassHay"].Value = (commPlAgr_GrassHay);
            profileCommand.Parameters["@commPlAgr_Oats"].Value = (commPlAgr_Oats);
            profileCommand.Parameters["@commPlAgr_Safflower"].Value = (commPlAgr_Safflower);
            profileCommand.Parameters["@commPlAgr_Sunflower"].Value = (commPlAgr_Sunflower);
            profileCommand.Parameters["@commPlAgr_Other"].Value = (commPlAgr_Other);

            profileCommand.Parameters["@commPlVeg_Artichokes"].Value = (commPlVeg_Artichokes);
            profileCommand.Parameters["@commPlVeg_Cabbage"].Value = (commPlVeg_Cabbage);
            profileCommand.Parameters["@commPlVeg_Escarole"].Value = (commPlVeg_Escarole);
            profileCommand.Parameters["@commPlVeg_Onions"].Value = (commPlVeg_Onions);
            profileCommand.Parameters["@commPlVeg_SweetCorn"].Value = (commPlVeg_SweetCorn);
            profileCommand.Parameters["@commPlVeg_Asparagus"].Value = (commPlVeg_Asparagus);
            profileCommand.Parameters["@commPlVeg_Carrots"].Value = (commPlVeg_Carrots);
            profileCommand.Parameters["@commPlVeg_Garlic"].Value = (commPlVeg_Garlic);
            profileCommand.Parameters["@commPlVeg_Parsnips"].Value = (commPlVeg_Parsnips);
            profileCommand.Parameters["@commPlVeg_Tomatoes"].Value = (commPlVeg_Tomatoes);
            profileCommand.Parameters["@commPlVeg_Beans"].Value = (commPlVeg_Beans);
            profileCommand.Parameters["@commPlVeg_Cauliflower"].Value = (commPlVeg_Cauliflower);
            profileCommand.Parameters["@commPlVeg_Greens"].Value = (commPlVeg_Greens);
            profileCommand.Parameters["@commPlVeg_Peas"].Value = (commPlVeg_Peas);
            profileCommand.Parameters["@commPlVeg_Turnips"].Value = (commPlVeg_Turnips);
            profileCommand.Parameters["@commPlVeg_Beets"].Value = (commPlVeg_Beets);
            profileCommand.Parameters["@commPlVeg_Celery"].Value = (commPlVeg_Celery);
            profileCommand.Parameters["@commPlVeg_Kale"].Value = (commPlVeg_Kale);
            profileCommand.Parameters["@commPlVeg_Peppers"].Value = (commPlVeg_Peppers);
            profileCommand.Parameters["@commPlVeg_Watermelon"].Value = (commPlVeg_Watermelon);
            profileCommand.Parameters["@commPlVeg_Broccoli"].Value = (commPlVeg_Broccoli);
            profileCommand.Parameters["@commPlVeg_Cucumbers"].Value = (commPlVeg_Cucumbers);
            profileCommand.Parameters["@commPlVeg_Lentils"].Value = (commPlVeg_Lentils);
            profileCommand.Parameters["@commPlVeg_Rutabagas"].Value = (commPlVeg_Rutabagas);
            profileCommand.Parameters["@commPlVeg_BrusselSprouts"].Value = (commPlVeg_BrusselSprouts);
            profileCommand.Parameters["@commPlVeg_Eggplant"].Value = (commPlVeg_Eggplant);
            profileCommand.Parameters["@commPlVeg_Lettuce"].Value = (commPlVeg_Lettuce);
            profileCommand.Parameters["@commPlVeg_Spinach"].Value = (commPlVeg_Spinach);
            profileCommand.Parameters["@commplveg_leeks"].Value = (commplveg_leeks);
            profileCommand.Parameters["@commPlVeg_Pumpkins"].Value = (commPlVeg_Pumpkins);
            profileCommand.Parameters["@commPlVeg_Squashes"].Value = (commPlVeg_Squashes);
            profileCommand.Parameters["@commPlVeg_Radishes"].Value = (commPlVeg_Radishes);
            profileCommand.Parameters["@commPlVeg_Other"].Value = (commPlVeg_Other);

            profileCommand.Parameters["@commPlFruit_Apples"].Value = (commPlFruit_Apples);
            profileCommand.Parameters["@commPlFruit_Cherries"].Value = (commPlFruit_Cherries);
            profileCommand.Parameters["@commPlFruit_Lemons"].Value = (commPlFruit_Lemons);
            profileCommand.Parameters["@commPlFruit_Peaches"].Value = (commPlFruit_Peaches);
            profileCommand.Parameters["@commPlFruit_Strawberries"].Value = (commPlFruit_Strawberries);
            profileCommand.Parameters["@commPlFruit_Apricots"].Value = (commPlFruit_Apricots);
            profileCommand.Parameters["@commPlFruit_Cranberries"].Value = (commPlFruit_Cranberries);
            profileCommand.Parameters["@commPlFruit_Limes"].Value = (commPlFruit_Limes);
            profileCommand.Parameters["@commPlFruit_Pears"].Value = (commPlFruit_Pears);
            profileCommand.Parameters["@commPlFruit_Tangerines"].Value = (commPlFruit_Tangerines);
            profileCommand.Parameters["@commPlFruit_Avocados"].Value = (commPlFruit_Avocados);
            profileCommand.Parameters["@commPlFruit_Figs"].Value = (commPlFruit_Figs);
            profileCommand.Parameters["@commPlFruit_Melons"].Value = (commPlFruit_Melons);
            profileCommand.Parameters["@commPlFruit_Pineapples"].Value = (commPlFruit_Pineapples);
            profileCommand.Parameters["@commPlFruit_Bananas"].Value = (commPlFruit_Bananas);
            profileCommand.Parameters["@commPlFruit_Grapefruit"].Value = (commPlFruit_Grapefruit);
            profileCommand.Parameters["@commPlFruit_Olives"].Value = (commPlFruit_Olives);
            profileCommand.Parameters["@commPlFruit_Plums"].Value = (commPlFruit_Plums);
            profileCommand.Parameters["@commPlFruit_Berries"].Value = (commPlFruit_Berries);
            profileCommand.Parameters["@commPlFruit_Grapes"].Value = (commPlFruit_Grapes);
            profileCommand.Parameters["@commPlFruit_Oranges"].Value = (commPlFruit_Oranges);
            profileCommand.Parameters["@commPlFruit_Quinces"].Value = (commPlFruit_Quinces);
            profileCommand.Parameters["@commPlFruit_Brambles"].Value = (commPlFruit_Brambles);
            profileCommand.Parameters["@commPlFruit_Blueberries"].Value = (commPlFruit_Blueberries);
            profileCommand.Parameters["@commPlFruit_Other"].Value = (commPlFruit_Other);

            profileCommand.Parameters["@commPlNuts_Almonds"].Value = (commPlNuts_Almonds);
            profileCommand.Parameters["@commPlNuts_Hazelnuts"].Value = (commPlNuts_Hazelnuts);
            profileCommand.Parameters["@commPlNuts_Pecans"].Value = (commPlNuts_Pecans);
            profileCommand.Parameters["@commPlNuts_Walnuts"].Value = (commPlNuts_Walnuts);
            profileCommand.Parameters["@commplnuts_chestnuts"].Value = (commplnuts_chestnuts);
            profileCommand.Parameters["@commPlNuts_Macadamia"].Value = (commPlNuts_Macadamia);
            profileCommand.Parameters["@commPlNuts_Pistachios"].Value = (commPlNuts_Pistachios);
            profileCommand.Parameters["@commPlNuts_Other"].Value = (commPlNuts_Other);

            profileCommand.Parameters["@commPlAdd_Herbs"].Value = (commPlAdd_Herbs);
            profileCommand.Parameters["@commPlAdd_Ornamentals"].Value = (commPlAdd_Ornamentals);
            profileCommand.Parameters["@commPlAdd_Trees"].Value = (commPlAdd_Trees);
            profileCommand.Parameters["@commPlAdd_Mushrooms"].Value = (commPlAdd_Mushrooms);
            profileCommand.Parameters["@commPlAdd_NativePlants"].Value = (commPlAdd_NativePlants);
            profileCommand.Parameters["@commPlAdd_Other"].Value = (commPlAdd_Other);

            profileCommand.Parameters["@commAnim_Beef"].Value = (commAnim_Beef);
            profileCommand.Parameters["@commAnim_Chicken"].Value = (commAnim_Chicken);
            profileCommand.Parameters["@commAnim_Rabbits"].Value = (commAnim_Rabbits);
            profileCommand.Parameters["@commAnim_Swine"].Value = (commAnim_Swine);
            profileCommand.Parameters["@commAnim_Dairy"].Value = (commAnim_Dairy);
            profileCommand.Parameters["@commAnim_Goats"].Value = (commAnim_Goats);
            profileCommand.Parameters["@commAnim_Sheep"].Value = (commAnim_Sheep);
            profileCommand.Parameters["@commAnim_Turkeys"].Value = (commAnim_Turkeys);
            profileCommand.Parameters["@commAnim_Other"].Value = (commAnim_Other);

            profileCommand.Parameters["@commMisc_Bees"].Value = (commMisc_Bees);
            profileCommand.Parameters["@commMisc_Fish"].Value = (commMisc_Fish);
            profileCommand.Parameters["@commMisc_Ratites"].Value = (commMisc_Ratites);
            profileCommand.Parameters["@commMisc_Shellfish"].Value = (commMisc_Shellfish);
            profileCommand.Parameters["@commMisc_Other"].Value = (commMisc_Other);
            profileCommand.Parameters["@submitted"].Value = (submitted);

            profileConnection.Open();
            //updateSuccess = (bool)profileCommand.ExecuteScalar();
            SqlDataReader userDataReader = profileCommand.ExecuteReader();

            profileConnection.Dispose();

            //return updateSuccess;
            return true;

        }

        public bool saveProfileToDB(string user, int sKey)
        {
            string profileSQL;
            string profileConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection profileConnection;
            SqlCommand profileCommand;
            

            profileConnection = new SqlConnection(profileConnString);

            profileSQL = "DaikonProfilesProfileUpdate";
            profileCommand = new SqlCommand(profileSQL, profileConnection);
            profileCommand.CommandType = CommandType.StoredProcedure;

            profileCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            profileCommand.Parameters.Add("@sKey", SqlDbType.Int);
            profileCommand.Parameters.Add("@profileID", SqlDbType.VarChar, 50);

            profileCommand.Parameters.Add("@categoryA", SqlDbType.VarChar, 50);
            profileCommand.Parameters.Add("@catAother", SqlDbType.VarChar, 80);
            profileCommand.Parameters.Add("@categoryB", SqlDbType.VarChar, 50);
            profileCommand.Parameters.Add("@catBother", SqlDbType.VarChar, 80);

            profileCommand.Parameters.Add("@aud_farmranchers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@aud_educators", SqlDbType.Bit);
            profileCommand.Parameters.Add("@aud_researchers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@aud_consumers", SqlDbType.Bit);

            profileCommand.Parameters.Add("@techlvl_beginner", SqlDbType.Bit);
            profileCommand.Parameters.Add("@techlvl_intermediate", SqlDbType.Bit);
            profileCommand.Parameters.Add("@techlvl_advanced", SqlDbType.Bit);

            profileCommand.Parameters.Add("@inv_planning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_present", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_research", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_land", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_planningcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_presentcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_researchcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_landcount", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_numparticipants", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_numideas", SqlDbType.Int);
            profileCommand.Parameters.Add("@inv_extplanning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@inv_extapplied", SqlDbType.Bit);

            profileCommand.Parameters["@user"].Value = user;
            profileCommand.Parameters["@sKey"].Value = sKey;
            profileCommand.Parameters["@profileID"].Value = profileID;

            profileCommand.Parameters["@categoryA"].Value = categoryA;
            profileCommand.Parameters["@catAother"].Value = catAother;
            profileCommand.Parameters["@categoryB"].Value = categoryB;
            profileCommand.Parameters["@catBother"].Value = catBother;

            profileCommand.Parameters["@aud_farmranchers"].Value = aud_farmranchers;
            profileCommand.Parameters["@aud_educators"].Value = aud_educators;
            profileCommand.Parameters["@aud_researchers"].Value = aud_researchers;
            profileCommand.Parameters["@aud_consumers"].Value = aud_consumers;

            profileCommand.Parameters["@techlvl_beginner"].Value = techlvl_beginner;
            profileCommand.Parameters["@techlvl_intermediate"].Value = techlvl_intermediate;
            profileCommand.Parameters["@techlvl_advanced"].Value = techlvl_advanced;

            profileCommand.Parameters["@inv_planning"].Value = inv_planning;
            profileCommand.Parameters["@inv_present"].Value = inv_present;
            profileCommand.Parameters["@inv_research"].Value = inv_research;
            profileCommand.Parameters["@inv_land"].Value = inv_land;
            profileCommand.Parameters["@inv_planningcount"].Value = inv_planningcount;
            profileCommand.Parameters["@inv_presentcount"].Value = inv_presentcount;
            profileCommand.Parameters["@inv_researchcount"].Value = inv_researchcount;
            profileCommand.Parameters["@inv_landcount"].Value = inv_landcount;
            profileCommand.Parameters["@inv_numparticipants"].Value = 0;
            profileCommand.Parameters["@inv_numideas"].Value = 0;
            profileCommand.Parameters["@inv_extplanning"].Value = (inv_extplanning);
            profileCommand.Parameters["@inv_extapplied"].Value = (inv_extapplied);

            profileCommand.Parameters.Add("@intgfrs_AgroecosystemAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_HolisticManagement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_OrganicAgriculture", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_Permaculture", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_WholeFarmPlanning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@intgfrs_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@cropprd_Agroforestry", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_FoliarFeeding", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_NutrientCycling", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_StripCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_BiologicalInoculants", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Forestry", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_OrganicFertilizers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_StubbleMulching", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_ContinuousCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_GreenManures", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_OrganicMatter", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_TissueAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_CoverCrops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Intercropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Permaculture", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Transitioning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_DoubleCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_MinimumTillage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_ReducedApplications", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Earthworms", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_MultipleCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_RelayCropping", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Fallow", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_MunicipalWastes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_RidgeTillage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Fertigation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_NoTill", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_SoilAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_CatchCrops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_CropRotation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Irrigation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_CropBreeding", SqlDbType.Bit);
            profileCommand.Parameters.Add("@cropprd_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@animprd_AlternativeFeedstuffs", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_FeedRations", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_MultispeciesGrazing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_StockpiledForages", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_AlternativeHousing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_FreeRange", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_PastureFertility", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Vaccines", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_AlternParasiteControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_HerbalMedicines", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_PastureRenovation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_WateringSystem", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_AnimalProtection", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Homeopathy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_PreventivePractices", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_WinterForage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Composting", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Implants", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Probiotics", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_ContinuousGrazing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Inoculants", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_RangeImprovement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_FeedAdditives", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_ManureManagement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_RotationalGrazing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_FeedFormulation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_MineralSupplements", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_ShadeShelter", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Therapeutics", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_LivestockBreeding", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_StockingRate", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_grazingmanagement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@animprd_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@pestmgt_Allelopathy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_EconomicThreshold", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_MechanicalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_SmotherCrops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_BiologicalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Eradication", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_PhysicalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Traps", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_BiorationalPesticides", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Flame", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_PlasticMulching", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_TrapCrops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_BotanicalPesticides", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_FieldMonitoring", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_PrecisionCultivation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_VegetativeMulching", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_ChemicalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_GeneticResistance", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_PrecisionHerbicideUse", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_WeatherMonitoring", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Competition", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_IPM", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Prevention", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_WeedEcology", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_CompostExtracts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_KilledMulches", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_RowCovers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_WeederGeese", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_CulturalControl", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_LivingMulches", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Sanitation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_DiseaseVectors", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_MatingDisruption", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_SoilSolarization", SqlDbType.Bit);
            profileCommand.Parameters.Add("@pestmgt_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@soilmgt_NutrientMineralization", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilMicrobiology", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilOrganicMatter", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilQuality", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_CarbonSequestration", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilChemistry", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_SoilPhysics", SqlDbType.Bit);
            profileCommand.Parameters.Add("@soilmgt_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@nresenv_Afforestation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_GrassHedges", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_RiparianPlantings", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Wildlife", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Biodiversity", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_GrassWaterways", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_RiverbankProtection", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Windbreaks", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Biosphere", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_HabitatEnhancement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_SoilStabilization", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_WoodyHedges", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_ConservationTillage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Hedgerows", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Terraces", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_ContourCultivation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Indicators", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Wetlands", SqlDbType.Bit);
            profileCommand.Parameters.Add("@nresenv_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@edtrain_CaseStudy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Demonstration", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_FocusGroup", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_StudyCircle", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Conference", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Display", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Mentor", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Workshop", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Curriculum", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Extension", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Network", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Database", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_FactSheet", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_OnFarmResearch", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_DecisionSupportSystem", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_FarmerToFarmer", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_ParticipatoryResearch", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_YouthEducation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@edtrain_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@econmkt_AlternativeEnterprise", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_CSA", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_FeasibilityStudy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_RiskManagement", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_Budget", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_CostAndReturns", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_FinancialAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_ValueAdded", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_Cooperatives", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_DirectMarketing", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_MarketStudy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_FoodProductQualitySafety", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_LaborEmployment", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_Ecommerce", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_FarmToInstitution", SqlDbType.Bit);
            profileCommand.Parameters.Add("@econmkt_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@commdev_InfrastructureAnalysis", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_TechnicalAssistance", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_NewBusinessOpportunities", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_Partnerships", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_UrbanAgriculture", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_PublicParticipation", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_UrbanRuralIntegration", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_LocalRegionalCommunityFoodSystems", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_Agritourism", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_PublicPolicy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_CommunityPlanning", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_LeadershipDevelopment", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_EthnicDifferencesCulturalDemographicChange", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commdev_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@qoflife_AnalysisOfPersonalFamilyLife", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_SocialCapitol", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_SustainabilityMeasures", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_CommunityServices", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_SocialNetworks", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_EmploymentOpportunities", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_SocialPsychologicalIndicators", SqlDbType.Bit);
            profileCommand.Parameters.Add("@qoflife_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@energy_BioenergyBiofuels", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_WindPower", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_EnergyUseConsumption", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_SolarEnergy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_EnergyConservationEfficiency", SqlDbType.Bit);
            profileCommand.Parameters.Add("@energy_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@commPlAgr_Barley", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_GrassLegumeHay", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Peanuts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sorghum", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sweetpotatoes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Canola", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_LegumeHay", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Potatoes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Soybeans", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Tobacco", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Corn", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Hops", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Rapeseed", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Spelt", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Wheat", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Cotton", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Kenaf", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Rice", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sugarbeets", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Flax", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Millet", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Rye", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sugarcane", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_GrassHay", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Oats", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Safflower", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Sunflower", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAgr_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commPlVeg_Artichokes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Cabbage", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Escarole", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Onions", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_SweetCorn", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Asparagus", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Carrots", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Garlic", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Parsnips", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Tomatoes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Beans", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Cauliflower", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Greens", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Peas", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Turnips", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Beets", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Celery", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Kale", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Peppers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Watermelon", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Broccoli", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Cucumbers", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Lentils", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Rutabagas", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_BrusselSprouts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Eggplant", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Lettuce", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Spinach", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commplveg_leeks", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Pumpkins", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Squashes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Radishes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlVeg_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@commPlFruit_Apples", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Cherries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Lemons", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Peaches", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Strawberries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Apricots", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Cranberries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Limes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Pears", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Tangerines", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Avocados", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Figs", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Melons", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Pineapples", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Bananas", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Grapefruit", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Olives", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Plums", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Berries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Grapes", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Oranges", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Quinces", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Brambles", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Blueberries", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlFruit_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commPlNuts_Almonds", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Hazelnuts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Pecans", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Walnuts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commplnuts_chestnuts", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Macadamia", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Pistachios", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlNuts_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commPlAdd_Herbs", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_Ornamentals", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_Trees", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_Mushrooms", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_NativePlants", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commPlAdd_Other", SqlDbType.NVarChar, 80);

            profileCommand.Parameters.Add("@commAnim_Beef", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Chicken", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Rabbits", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Swine", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Dairy", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Goats", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Sheep", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Turkeys", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commAnim_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@commMisc_Bees", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commMisc_Fish", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commMisc_Ratites", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commMisc_Shellfish", SqlDbType.Bit);
            profileCommand.Parameters.Add("@commMisc_Other", SqlDbType.NVarChar, 80);
            profileCommand.Parameters.Add("@submitted", SqlDbType.Bit);

            profileCommand.Parameters["@intgfrs_AgroecosystemAnalysis"].Value = (intgfrs_AgroecosystemAnalysis);
            profileCommand.Parameters["@intgfrs_WholeFarmPlanning"].Value = (intgfrs_WholeFarmPlanning);
            profileCommand.Parameters["@intgfrs_HolisticManagement"].Value = (intgfrs_HolisticManagement);
            profileCommand.Parameters["@intgfrs_OrganicAgriculture"].Value = (intgfrs_OrganicAgriculture);
            profileCommand.Parameters["@intgfrs_Permaculture"].Value = (intgfrs_Permaculture);
            if (intgfrs_Other == null)
                intgfrs_Other = "";
            profileCommand.Parameters["@intgfrs_Other"].Value = (intgfrs_Other);

            profileCommand.Parameters["@cropprd_Agroforestry"].Value = (cropprd_Agroforestry);
            profileCommand.Parameters["@cropprd_FoliarFeeding"].Value = (cropprd_FoliarFeeding);
            profileCommand.Parameters["@cropprd_NutrientCycling"].Value = (cropprd_NutrientCycling);
            profileCommand.Parameters["@cropprd_StripCropping"].Value = (cropprd_StripCropping);
            profileCommand.Parameters["@cropprd_BiologicalInoculants"].Value = (cropprd_BiologicalInoculants);
            profileCommand.Parameters["@cropprd_Forestry"].Value = (cropprd_Forestry);
            profileCommand.Parameters["@cropprd_OrganicFertilizers"].Value = (cropprd_OrganicFertilizers);
            profileCommand.Parameters["@cropprd_StubbleMulching"].Value = (cropprd_StubbleMulching);
            profileCommand.Parameters["@cropprd_ContinuousCropping"].Value = (cropprd_ContinuousCropping);
            profileCommand.Parameters["@cropprd_GreenManures"].Value = (cropprd_GreenManures);
            profileCommand.Parameters["@cropprd_OrganicMatter"].Value = (cropprd_OrganicMatter);
            profileCommand.Parameters["@cropprd_TissueAnalysis"].Value = (cropprd_TissueAnalysis);
            profileCommand.Parameters["@cropprd_CoverCrops"].Value = (cropprd_CoverCrops);
            profileCommand.Parameters["@cropprd_Intercropping"].Value = (cropprd_Intercropping);
            profileCommand.Parameters["@cropprd_Permaculture"].Value = (cropprd_Permaculture);
            profileCommand.Parameters["@cropprd_Transitioning"].Value = (cropprd_Transitioning);
            profileCommand.Parameters["@cropprd_DoubleCropping"].Value = (cropprd_DoubleCropping);
            profileCommand.Parameters["@cropprd_MinimumTillage"].Value = (cropprd_MinimumTillage);
            profileCommand.Parameters["@cropprd_ReducedApplications"].Value = (cropprd_ReducedApplications);
            profileCommand.Parameters["@cropprd_Earthworms"].Value = (cropprd_Earthworms);
            profileCommand.Parameters["@cropprd_MultipleCropping"].Value = (cropprd_MultipleCropping);
            profileCommand.Parameters["@cropprd_RelayCropping"].Value = (cropprd_RelayCropping);
            profileCommand.Parameters["@cropprd_Fallow"].Value = (cropprd_Fallow);
            profileCommand.Parameters["@cropprd_MunicipalWastes"].Value = (cropprd_MunicipalWastes);
            profileCommand.Parameters["@cropprd_RidgeTillage"].Value = (cropprd_RidgeTillage);
            profileCommand.Parameters["@cropprd_Fertigation"].Value = (cropprd_Fertigation);
            profileCommand.Parameters["@cropprd_NoTill"].Value = (cropprd_NoTill);
            profileCommand.Parameters["@cropprd_SoilAnalysis"].Value = (cropprd_SoilAnalysis);
            profileCommand.Parameters["@cropprd_CatchCrops"].Value = (cropprd_CatchCrops);
            profileCommand.Parameters["@cropprd_CropRotation"].Value = (cropprd_CropRotation);
            profileCommand.Parameters["@cropprd_CropBreeding"].Value = (cropprd_CropBreeding);
            profileCommand.Parameters["@cropprd_Irrigation"].Value = (cropprd_Irrigation);
            if (cropprd_Other == null)
                cropprd_Other = "";
            profileCommand.Parameters["@cropprd_Other"].Value = (cropprd_Other);

            profileCommand.Parameters["@animprd_AlternativeFeedstuffs"].Value = (animprd_AlternativeFeedstuffs);
            profileCommand.Parameters["@animprd_FeedRations"].Value = (animprd_FeedRations);
            profileCommand.Parameters["@animprd_MultispeciesGrazing"].Value = (animprd_MultispeciesGrazing);
            profileCommand.Parameters["@animprd_StockpiledForages"].Value = (animprd_StockpiledForages);
            profileCommand.Parameters["@animprd_AlternativeHousing"].Value = (animprd_AlternativeHousing);
            profileCommand.Parameters["@animprd_FreeRange"].Value = (animprd_FreeRange);
            profileCommand.Parameters["@animprd_PastureFertility"].Value = (animprd_PastureFertility);
            profileCommand.Parameters["@animprd_Vaccines"].Value = (animprd_Vaccines);
            profileCommand.Parameters["@animprd_AlternParasiteControl"].Value = (animprd_AlternParasiteControl);
            profileCommand.Parameters["@animprd_HerbalMedicines"].Value = (animprd_HerbalMedicines);
            profileCommand.Parameters["@animprd_PastureRenovation"].Value = (animprd_PastureRenovation);
            profileCommand.Parameters["@animprd_WateringSystem"].Value = (animprd_WateringSystem);
            profileCommand.Parameters["@animprd_AnimalProtection"].Value = (animprd_AnimalProtection);
            profileCommand.Parameters["@animprd_Homeopathy"].Value = (animprd_Homeopathy);
            profileCommand.Parameters["@animprd_PreventivePractices"].Value = (animprd_PreventivePractices);
            profileCommand.Parameters["@animprd_WinterForage"].Value = (animprd_WinterForage);
            profileCommand.Parameters["@animprd_Composting"].Value = (animprd_Composting);
            profileCommand.Parameters["@animprd_Implants"].Value = (animprd_Implants);
            profileCommand.Parameters["@animprd_Probiotics"].Value = (animprd_Probiotics);
            profileCommand.Parameters["@animprd_ContinuousGrazing"].Value = (animprd_ContinuousGrazing);
            profileCommand.Parameters["@animprd_Inoculants"].Value = (animprd_Inoculants);
            profileCommand.Parameters["@animprd_RangeImprovement"].Value = (animprd_RangeImprovement);
            profileCommand.Parameters["@animprd_FeedAdditives"].Value = (animprd_FeedAdditives);
            profileCommand.Parameters["@animprd_ManureManagement"].Value = (animprd_ManureManagement);
            profileCommand.Parameters["@animprd_RotationalGrazing"].Value = (animprd_RotationalGrazing);
            profileCommand.Parameters["@animprd_FeedFormulation"].Value = (animprd_FeedFormulation);
            profileCommand.Parameters["@animprd_MineralSupplements"].Value = (animprd_MineralSupplements);
            profileCommand.Parameters["@animprd_ShadeShelter"].Value = (animprd_ShadeShelter);
            profileCommand.Parameters["@animprd_Therapeutics"].Value = (animprd_Therapeutics);
            profileCommand.Parameters["@animprd_LivestockBreeding"].Value = (animprd_LivestockBreeding);
            profileCommand.Parameters["@animprd_StockingRate"].Value = (animprd_StockingRate);
            profileCommand.Parameters["@animprd_grazingmanagement"].Value = (animprd_grazingmanagement);
            if (animprd_Other == null)
                animprd_Other = "";
            profileCommand.Parameters["@animprd_Other"].Value = (animprd_Other);

            profileCommand.Parameters["@pestmgt_Allelopathy"].Value = (pestmgt_Allelopathy);
            profileCommand.Parameters["@pestmgt_EconomicThreshold"].Value = (pestmgt_EconomicThreshold);
            profileCommand.Parameters["@pestmgt_MechanicalControl"].Value = (pestmgt_MechanicalControl);
            profileCommand.Parameters["@pestmgt_SmotherCrops"].Value = (pestmgt_SmotherCrops);
            profileCommand.Parameters["@pestmgt_BiologicalControl"].Value = (pestmgt_BiologicalControl);
            profileCommand.Parameters["@pestmgt_Eradication"].Value = (pestmgt_Eradication);
            profileCommand.Parameters["@pestmgt_PhysicalControl"].Value = (pestmgt_PhysicalControl);
            profileCommand.Parameters["@pestmgt_Traps"].Value = (pestmgt_Traps);
            profileCommand.Parameters["@pestmgt_BiorationalPesticides"].Value = (pestmgt_BiorationalPesticides);
            profileCommand.Parameters["@pestmgt_Flame"].Value = (pestmgt_Flame);
            profileCommand.Parameters["@pestmgt_PlasticMulching"].Value = (pestmgt_PlasticMulching);
            profileCommand.Parameters["@pestmgt_TrapCrops"].Value = (pestmgt_TrapCrops);
            profileCommand.Parameters["@pestmgt_BotanicalPesticides"].Value = (pestmgt_BotanicalPesticides);
            profileCommand.Parameters["@pestmgt_FieldMonitoring"].Value = (pestmgt_FieldMonitoring);
            profileCommand.Parameters["@pestmgt_PrecisionCultivation"].Value = (pestmgt_PrecisionCultivation);
            profileCommand.Parameters["@pestmgt_VegetativeMulching"].Value = (pestmgt_VegetativeMulching);
            profileCommand.Parameters["@pestmgt_ChemicalControl"].Value = (pestmgt_ChemicalControl);
            profileCommand.Parameters["@pestmgt_GeneticResistance"].Value = (pestmgt_GeneticResistance);
            profileCommand.Parameters["@pestmgt_PrecisionHerbicideUse"].Value = (pestmgt_PrecisionHerbicideUse);
            profileCommand.Parameters["@pestmgt_WeatherMonitoring"].Value = (pestmgt_WeatherMonitoring);
            profileCommand.Parameters["@pestmgt_Competition"].Value = (pestmgt_Competition);
            profileCommand.Parameters["@pestmgt_IPM"].Value = (pestmgt_IPM);
            profileCommand.Parameters["@pestmgt_Prevention"].Value = (pestmgt_Prevention);
            profileCommand.Parameters["@pestmgt_WeedEcology"].Value = (pestmgt_WeedEcology);
            profileCommand.Parameters["@pestmgt_CompostExtracts"].Value = (pestmgt_CompostExtracts);
            profileCommand.Parameters["@pestmgt_KilledMulches"].Value = (pestmgt_KilledMulches);
            profileCommand.Parameters["@pestmgt_RowCovers"].Value = (pestmgt_RowCovers);
            profileCommand.Parameters["@pestmgt_WeederGeese"].Value = (pestmgt_WeederGeese);
            profileCommand.Parameters["@pestmgt_CulturalControl"].Value = (pestmgt_CulturalControl);
            profileCommand.Parameters["@pestmgt_LivingMulches"].Value = (pestmgt_LivingMulches);
            profileCommand.Parameters["@pestmgt_Sanitation"].Value = (pestmgt_Sanitation);
            profileCommand.Parameters["@pestmgt_DiseaseVectors"].Value = (pestmgt_DiseaseVectors);
            profileCommand.Parameters["@pestmgt_MatingDisruption"].Value = (pestmgt_MatingDisruption);
            profileCommand.Parameters["@pestmgt_SoilSolarization"].Value = (pestmgt_SoilSolarization);
            if (pestmgt_Other == null)
                pestmgt_Other = "";
            profileCommand.Parameters["@pestmgt_Other"].Value = (pestmgt_Other);

            profileCommand.Parameters["@soilmgt_NutrientMineralization"].Value = (soilmgt_NutrientMineralization);
            profileCommand.Parameters["@soilmgt_SoilMicrobiology"].Value = (soilmgt_SoilMicrobiology);
            profileCommand.Parameters["@soilmgt_SoilOrganicMatter"].Value = (soilmgt_SoilOrganicMatter);
            profileCommand.Parameters["@soilmgt_SoilQuality"].Value = (soilmgt_SoilQuality);
            profileCommand.Parameters["@soilmgt_CarbonSequestration"].Value = (soilmgt_CarbonSequestration);
            profileCommand.Parameters["@soilmgt_SoilChemistry"].Value = (soilmgt_SoilChemistry);
            profileCommand.Parameters["@soilmgt_SoilPhysics"].Value = (soilmgt_SoilPhysics);
            if (soilmgt_Other == null)
                soilmgt_Other = "";
            profileCommand.Parameters["@soilmgt_Other"].Value = (soilmgt_Other);

            profileCommand.Parameters["@nresenv_Afforestation"].Value = (nresenv_Afforestation);
            profileCommand.Parameters["@nresenv_GrassHedges"].Value = (nresenv_GrassHedges);
            profileCommand.Parameters["@nresenv_RiparianPlantings"].Value = (nresenv_RiparianPlantings);
            profileCommand.Parameters["@nresenv_Wildlife"].Value = (nresenv_Wildlife);
            profileCommand.Parameters["@nresenv_Biodiversity"].Value = (nresenv_Biodiversity);
            profileCommand.Parameters["@nresenv_GrassWaterways"].Value = (nresenv_GrassWaterways);
            profileCommand.Parameters["@nresenv_RiverbankProtection"].Value = (nresenv_RiverbankProtection);
            profileCommand.Parameters["@nresenv_Windbreaks"].Value = (nresenv_Windbreaks);
            profileCommand.Parameters["@nresenv_Biosphere"].Value = (nresenv_Biosphere);
            profileCommand.Parameters["@nresenv_HabitatEnhancement"].Value = (nresenv_HabitatEnhancement);
            profileCommand.Parameters["@nresenv_SoilStabilization"].Value = (nresenv_SoilStabilization);
            profileCommand.Parameters["@nresenv_WoodyHedges"].Value = (nresenv_WoodyHedges);
            profileCommand.Parameters["@nresenv_ConservationTillage"].Value = (nresenv_ConservationTillage);
            profileCommand.Parameters["@nresenv_Hedgerows"].Value = (nresenv_Hedgerows);
            profileCommand.Parameters["@nresenv_Terraces"].Value = (nresenv_Terraces);
            profileCommand.Parameters["@nresenv_ContourCultivation"].Value = (nresenv_ContourCultivation);
            profileCommand.Parameters["@nresenv_Indicators"].Value = (nresenv_Indicators);
            profileCommand.Parameters["@nresenv_Wetlands"].Value = (nresenv_Wetlands);
            if (nresenv_Other == null)
                nresenv_Other = "";
            profileCommand.Parameters["@nresenv_Other"].Value = (nresenv_Other);

            profileCommand.Parameters["@edtrain_CaseStudy"].Value = (edtrain_CaseStudy);
            profileCommand.Parameters["@edtrain_Demonstration"].Value = (edtrain_Demonstration);
            profileCommand.Parameters["@edtrain_FocusGroup"].Value = (edtrain_FocusGroup);
            profileCommand.Parameters["@edtrain_StudyCircle"].Value = (edtrain_StudyCircle);
            profileCommand.Parameters["@edtrain_Conference"].Value = (edtrain_Conference);
            profileCommand.Parameters["@edtrain_Display"].Value = (edtrain_Display);
            profileCommand.Parameters["@edtrain_Mentor"].Value = (edtrain_Mentor);
            profileCommand.Parameters["@edtrain_Workshop"].Value = (edtrain_Workshop);
            profileCommand.Parameters["@edtrain_Curriculum"].Value = (edtrain_Curriculum);
            profileCommand.Parameters["@edtrain_Extension"].Value = (edtrain_Extension);
            profileCommand.Parameters["@edtrain_Network"].Value = (edtrain_Network);
            profileCommand.Parameters["@edtrain_Database"].Value = (edtrain_Database);
            profileCommand.Parameters["@edtrain_FactSheet"].Value = (edtrain_FactSheet);
            profileCommand.Parameters["@edtrain_OnFarmResearch"].Value = (edtrain_OnFarmResearch);
            profileCommand.Parameters["@edtrain_DecisionSupportSystem"].Value = (edtrain_DecisionSupportSystem);
            profileCommand.Parameters["@edtrain_FarmerToFarmer"].Value = (edtrain_FarmerToFarmer);
            profileCommand.Parameters["@edtrain_ParticipatoryResearch"].Value = (edtrain_ParticipatoryResearch);
            profileCommand.Parameters["@edtrain_YouthEducation"].Value = (edtrain_YouthEducation);
            if (edtrain_Other == null)
                edtrain_Other = "";
            profileCommand.Parameters["@edtrain_Other"].Value = (edtrain_Other);

            profileCommand.Parameters["@econmkt_AlternativeEnterprise"].Value = (econmkt_AlternativeEnterprise);
            profileCommand.Parameters["@econmkt_CSA"].Value = (econmkt_CSA);
            profileCommand.Parameters["@econmkt_FeasibilityStudy"].Value = (econmkt_FeasibilityStudy);
            profileCommand.Parameters["@econmkt_RiskManagement"].Value = (econmkt_RiskManagement);
            profileCommand.Parameters["@econmkt_Budget"].Value = (econmkt_Budget);
            profileCommand.Parameters["@econmkt_CostAndReturns"].Value = (econmkt_CostAndReturns);
            profileCommand.Parameters["@econmkt_FinancialAnalysis"].Value = (econmkt_FinancialAnalysis);
            profileCommand.Parameters["@econmkt_ValueAdded"].Value = (econmkt_ValueAdded);
            profileCommand.Parameters["@econmkt_Cooperatives"].Value = (econmkt_Cooperatives);
            profileCommand.Parameters["@econmkt_DirectMarketing"].Value = (econmkt_DirectMarketing);
            profileCommand.Parameters["@econmkt_MarketStudy"].Value = (econmkt_MarketStudy);
            profileCommand.Parameters["@econmkt_FoodProductQualitySafety"].Value = (econmkt_FoodProductQualitySafety);
            profileCommand.Parameters["@econmkt_LaborEmployment"].Value = (econmkt_LaborEmployment);
            profileCommand.Parameters["@econmkt_Ecommerce"].Value = (econmkt_Ecommerce);
            profileCommand.Parameters["@econmkt_FarmToInstitution"].Value = (econmkt_FarmToInstitution);
            if (econmkt_Other == null)
                econmkt_Other = "";
            profileCommand.Parameters["@econmkt_Other"].Value = (econmkt_Other);

            profileCommand.Parameters["@commdev_InfrastructureAnalysis"].Value = (commdev_InfrastructureAnalysis);
            profileCommand.Parameters["@commdev_TechnicalAssistance"].Value = (commdev_TechnicalAssistance);
            profileCommand.Parameters["@commdev_NewBusinessOpportunities"].Value = (commdev_NewBusinessOpportunities);
            profileCommand.Parameters["@commdev_Partnerships"].Value = (commdev_Partnerships);
            profileCommand.Parameters["@commdev_UrbanAgriculture"].Value = (commdev_UrbanAgriculture);
            profileCommand.Parameters["@commdev_PublicParticipation"].Value = (commdev_PublicParticipation);
            profileCommand.Parameters["@commdev_UrbanRuralIntegration"].Value = (commdev_UrbanRuralIntegration);
            profileCommand.Parameters["@commdev_LocalRegionalCommunityFoodSystems"].Value = (commdev_LocalRegionalCommunityFoodSystems);
            profileCommand.Parameters["@commdev_Agritourism"].Value = (commdev_Agritourism);
            profileCommand.Parameters["@commdev_CommunityPlanning"].Value = (commdev_CommunityPlanning);
            profileCommand.Parameters["@commdev_PublicPolicy"].Value = (commdev_PublicPolicy);
            profileCommand.Parameters["@commdev_LeadershipDevelopment"].Value = (commdev_LeadershipDevelopment);
            profileCommand.Parameters["@commdev_EthnicDifferencesCulturalDemographicChange"].Value = (commdev_EthnicDifferencesCulturalDemographicChange);
            if (commdev_Other == null)
                commdev_Other = "";
            profileCommand.Parameters["@commdev_Other"].Value = (commdev_Other);

            profileCommand.Parameters["@qoflife_AnalysisOfPersonalFamilyLife"].Value = (qoflife_AnalysisOfPersonalFamilyLife);
            profileCommand.Parameters["@qoflife_SocialCapitol"].Value = (qoflife_SocialCapitol);
            profileCommand.Parameters["@qoflife_SustainabilityMeasures"].Value = (qoflife_SustainabilityMeasures);
            profileCommand.Parameters["@qoflife_CommunityServices"].Value = (qoflife_CommunityServices);
            profileCommand.Parameters["@qoflife_SocialNetworks"].Value = (qoflife_SocialNetworks);
            profileCommand.Parameters["@qoflife_EmploymentOpportunities"].Value = (qoflife_EmploymentOpportunities);
            profileCommand.Parameters["@qoflife_SocialPsychologicalIndicators"].Value = (qoflife_SocialPsychologicalIndicators);
            if (qoflife_Other == null)
                qoflife_Other = "";
            profileCommand.Parameters["@qoflife_Other"].Value = (qoflife_Other);

            profileCommand.Parameters["@energy_BioenergyBiofuels"].Value = (energy_BioenergyBiofuels);
            profileCommand.Parameters["@energy_WindPower"].Value = (energy_WindPower);
            profileCommand.Parameters["@energy_EnergyUseConsumption"].Value = (energy_EnergyUseConsumption);
            profileCommand.Parameters["@energy_SolarEnergy"].Value = (energy_SolarEnergy);
            profileCommand.Parameters["@energy_EnergyConservationEfficiency"].Value = (energy_EnergyConservationEfficiency);
            if (energy_Other == null)
                energy_Other = "";
            profileCommand.Parameters["@energy_Other"].Value = (energy_Other);

            profileCommand.Parameters["@commPlAgr_Barley"].Value = (commPlAgr_Barley);
            profileCommand.Parameters["@commPlAgr_GrassLegumeHay"].Value = (commPlAgr_GrassLegumeHay);
            profileCommand.Parameters["@commPlAgr_Peanuts"].Value = (commPlAgr_Peanuts);
            profileCommand.Parameters["@commPlAgr_Sorghum"].Value = (commPlAgr_Sorghum);
            profileCommand.Parameters["@commPlAgr_Sweetpotatoes"].Value = (commPlAgr_Sweetpotatoes);
            profileCommand.Parameters["@commPlAgr_Canola"].Value = (commPlAgr_Canola);
            profileCommand.Parameters["@commPlAgr_LegumeHay"].Value = (commPlAgr_LegumeHay);
            profileCommand.Parameters["@commPlAgr_Potatoes"].Value = (commPlAgr_Potatoes);
            profileCommand.Parameters["@commPlAgr_Soybeans"].Value = (commPlAgr_Soybeans);
            profileCommand.Parameters["@commPlAgr_Tobacco"].Value = (commPlAgr_Tobacco);
            profileCommand.Parameters["@commPlAgr_Corn"].Value = (commPlAgr_Corn);
            profileCommand.Parameters["@commPlAgr_Hops"].Value = (commPlAgr_Hops);
            profileCommand.Parameters["@commPlAgr_Rapeseed"].Value = (commPlAgr_Rapeseed);
            profileCommand.Parameters["@commPlAgr_Spelt"].Value = (commPlAgr_Spelt);
            profileCommand.Parameters["@commPlAgr_Wheat"].Value = (commPlAgr_Wheat);
            profileCommand.Parameters["@commPlAgr_Cotton"].Value = (commPlAgr_Cotton);
            profileCommand.Parameters["@commPlAgr_Kenaf"].Value = (commPlAgr_Kenaf);
            profileCommand.Parameters["@commPlAgr_Rice"].Value = (commPlAgr_Rice);
            profileCommand.Parameters["@commPlAgr_Sugarbeets"].Value = (commPlAgr_Sugarbeets);
            profileCommand.Parameters["@commPlAgr_Flax"].Value = (commPlAgr_Flax);
            profileCommand.Parameters["@commPlAgr_Millet"].Value = (commPlAgr_Millet);
            profileCommand.Parameters["@commPlAgr_Rye"].Value = (commPlAgr_Rye);
            profileCommand.Parameters["@commPlAgr_Sugarcane"].Value = (commPlAgr_Sugarcane);
            profileCommand.Parameters["@commPlAgr_GrassHay"].Value = (commPlAgr_GrassHay);
            profileCommand.Parameters["@commPlAgr_Oats"].Value = (commPlAgr_Oats);
            profileCommand.Parameters["@commPlAgr_Safflower"].Value = (commPlAgr_Safflower);
            profileCommand.Parameters["@commPlAgr_Sunflower"].Value = (commPlAgr_Sunflower);
            if (commPlAgr_Other == null)
                commPlAgr_Other = "";
            profileCommand.Parameters["@commPlAgr_Other"].Value = (commPlAgr_Other);

            profileCommand.Parameters["@commPlVeg_Artichokes"].Value = (commPlVeg_Artichokes);
            profileCommand.Parameters["@commPlVeg_Cabbage"].Value = (commPlVeg_Cabbage);
            profileCommand.Parameters["@commPlVeg_Escarole"].Value = (commPlVeg_Escarole);
            profileCommand.Parameters["@commPlVeg_Onions"].Value = (commPlVeg_Onions);
            profileCommand.Parameters["@commPlVeg_SweetCorn"].Value = (commPlVeg_SweetCorn);
            profileCommand.Parameters["@commPlVeg_Asparagus"].Value = (commPlVeg_Asparagus);
            profileCommand.Parameters["@commPlVeg_Carrots"].Value = (commPlVeg_Carrots);
            profileCommand.Parameters["@commPlVeg_Garlic"].Value = (commPlVeg_Garlic);
            profileCommand.Parameters["@commPlVeg_Parsnips"].Value = (commPlVeg_Parsnips);
            profileCommand.Parameters["@commPlVeg_Tomatoes"].Value = (commPlVeg_Tomatoes);
            profileCommand.Parameters["@commPlVeg_Beans"].Value = (commPlVeg_Beans);
            profileCommand.Parameters["@commPlVeg_Cauliflower"].Value = (commPlVeg_Cauliflower);
            profileCommand.Parameters["@commPlVeg_Greens"].Value = (commPlVeg_Greens);
            profileCommand.Parameters["@commPlVeg_Peas"].Value = (commPlVeg_Peas);
            profileCommand.Parameters["@commPlVeg_Turnips"].Value = (commPlVeg_Turnips);
            profileCommand.Parameters["@commPlVeg_Beets"].Value = (commPlVeg_Beets);
            profileCommand.Parameters["@commPlVeg_Celery"].Value = (commPlVeg_Celery);
            profileCommand.Parameters["@commPlVeg_Kale"].Value = (commPlVeg_Kale);
            profileCommand.Parameters["@commPlVeg_Peppers"].Value = (commPlVeg_Peppers);
            profileCommand.Parameters["@commPlVeg_Watermelon"].Value = (commPlVeg_Watermelon);
            profileCommand.Parameters["@commPlVeg_Broccoli"].Value = (commPlVeg_Broccoli);
            profileCommand.Parameters["@commPlVeg_Cucumbers"].Value = (commPlVeg_Cucumbers);
            profileCommand.Parameters["@commPlVeg_Lentils"].Value = (commPlVeg_Lentils);
            profileCommand.Parameters["@commPlVeg_Rutabagas"].Value = (commPlVeg_Rutabagas);
            profileCommand.Parameters["@commPlVeg_BrusselSprouts"].Value = (commPlVeg_BrusselSprouts);
            profileCommand.Parameters["@commPlVeg_Eggplant"].Value = (commPlVeg_Eggplant);
            profileCommand.Parameters["@commPlVeg_Lettuce"].Value = (commPlVeg_Lettuce);
            profileCommand.Parameters["@commPlVeg_Spinach"].Value = (commPlVeg_Spinach);
            profileCommand.Parameters["@commplveg_leeks"].Value = (commplveg_leeks);
            profileCommand.Parameters["@commPlVeg_Pumpkins"].Value = (commPlVeg_Pumpkins);
            profileCommand.Parameters["@commPlVeg_Squashes"].Value = (commPlVeg_Squashes);
            profileCommand.Parameters["@commPlVeg_Radishes"].Value = (commPlVeg_Radishes);
            if (commPlVeg_Other == null)
                commPlVeg_Other = "";
            profileCommand.Parameters["@commPlVeg_Other"].Value = (commPlVeg_Other);

            profileCommand.Parameters["@commPlFruit_Apples"].Value = (commPlFruit_Apples);
            profileCommand.Parameters["@commPlFruit_Cherries"].Value = (commPlFruit_Cherries);
            profileCommand.Parameters["@commPlFruit_Lemons"].Value = (commPlFruit_Lemons);
            profileCommand.Parameters["@commPlFruit_Peaches"].Value = (commPlFruit_Peaches);
            profileCommand.Parameters["@commPlFruit_Strawberries"].Value = (commPlFruit_Strawberries);
            profileCommand.Parameters["@commPlFruit_Apricots"].Value = (commPlFruit_Apricots);
            profileCommand.Parameters["@commPlFruit_Cranberries"].Value = (commPlFruit_Cranberries);
            profileCommand.Parameters["@commPlFruit_Limes"].Value = (commPlFruit_Limes);
            profileCommand.Parameters["@commPlFruit_Pears"].Value = (commPlFruit_Pears);
            profileCommand.Parameters["@commPlFruit_Tangerines"].Value = (commPlFruit_Tangerines);
            profileCommand.Parameters["@commPlFruit_Avocados"].Value = (commPlFruit_Avocados);
            profileCommand.Parameters["@commPlFruit_Figs"].Value = (commPlFruit_Figs);
            profileCommand.Parameters["@commPlFruit_Melons"].Value = (commPlFruit_Melons);
            profileCommand.Parameters["@commPlFruit_Pineapples"].Value = (commPlFruit_Pineapples);
            profileCommand.Parameters["@commPlFruit_Bananas"].Value = (commPlFruit_Bananas);
            profileCommand.Parameters["@commPlFruit_Grapefruit"].Value = (commPlFruit_Grapefruit);
            profileCommand.Parameters["@commPlFruit_Olives"].Value = (commPlFruit_Olives);
            profileCommand.Parameters["@commPlFruit_Plums"].Value = (commPlFruit_Plums);
            profileCommand.Parameters["@commPlFruit_Berries"].Value = (commPlFruit_Berries);
            profileCommand.Parameters["@commPlFruit_Grapes"].Value = (commPlFruit_Grapes);
            profileCommand.Parameters["@commPlFruit_Oranges"].Value = (commPlFruit_Oranges);
            profileCommand.Parameters["@commPlFruit_Quinces"].Value = (commPlFruit_Quinces);
            profileCommand.Parameters["@commPlFruit_Brambles"].Value = (commPlFruit_Brambles);
            profileCommand.Parameters["@commPlFruit_Blueberries"].Value = (commPlFruit_Blueberries);
            if (commPlFruit_Other == null)
                commPlFruit_Other = "";
            profileCommand.Parameters["@commPlFruit_Other"].Value = (commPlFruit_Other);

            profileCommand.Parameters["@commPlNuts_Almonds"].Value = (commPlNuts_Almonds);
            profileCommand.Parameters["@commPlNuts_Hazelnuts"].Value = (commPlNuts_Hazelnuts);
            profileCommand.Parameters["@commPlNuts_Pecans"].Value = (commPlNuts_Pecans);
            profileCommand.Parameters["@commPlNuts_Walnuts"].Value = (commPlNuts_Walnuts);
            profileCommand.Parameters["@commplnuts_chestnuts"].Value = (commplnuts_chestnuts);
            profileCommand.Parameters["@commPlNuts_Macadamia"].Value = (commPlNuts_Macadamia);
            profileCommand.Parameters["@commPlNuts_Pistachios"].Value = (commPlNuts_Pistachios);
            if (commPlNuts_Other == null)
                commPlNuts_Other = "";
            profileCommand.Parameters["@commPlNuts_Other"].Value = (commPlNuts_Other);

            profileCommand.Parameters["@commPlAdd_Herbs"].Value = (commPlAdd_Herbs);
            profileCommand.Parameters["@commPlAdd_Ornamentals"].Value = (commPlAdd_Ornamentals);
            profileCommand.Parameters["@commPlAdd_Trees"].Value = (commPlAdd_Trees);
            profileCommand.Parameters["@commPlAdd_Mushrooms"].Value = (commPlAdd_Mushrooms);
            profileCommand.Parameters["@commPlAdd_NativePlants"].Value = (commPlAdd_NativePlants);
            if (commPlAdd_Other == null)
                commPlAdd_Other = "";
            profileCommand.Parameters["@commPlAdd_Other"].Value = (commPlAdd_Other);

            profileCommand.Parameters["@commAnim_Beef"].Value = (commAnim_Beef);
            profileCommand.Parameters["@commAnim_Chicken"].Value = (commAnim_Chicken);
            profileCommand.Parameters["@commAnim_Rabbits"].Value = (commAnim_Rabbits);
            profileCommand.Parameters["@commAnim_Swine"].Value = (commAnim_Swine);
            profileCommand.Parameters["@commAnim_Dairy"].Value = (commAnim_Dairy);
            profileCommand.Parameters["@commAnim_Goats"].Value = (commAnim_Goats);
            profileCommand.Parameters["@commAnim_Sheep"].Value = (commAnim_Sheep);
            profileCommand.Parameters["@commAnim_Turkeys"].Value = (commAnim_Turkeys);
            if (commAnim_Other == null)
                commAnim_Other = "";
            profileCommand.Parameters["@commAnim_Other"].Value = (commAnim_Other);

            profileCommand.Parameters["@commMisc_Bees"].Value = (commMisc_Bees);
            profileCommand.Parameters["@commMisc_Fish"].Value = (commMisc_Fish);
            profileCommand.Parameters["@commMisc_Ratites"].Value = (commMisc_Ratites);
            profileCommand.Parameters["@commMisc_Shellfish"].Value = (commMisc_Shellfish);
            if (commMisc_Other == null)
                commMisc_Other = "";
            profileCommand.Parameters["@commMisc_Other"].Value = (commMisc_Other);
            profileCommand.Parameters["@submitted"].Value = (submitted);

            profileConnection.Open();
            //updateSuccess = (bool)profileCommand.ExecuteScalar();
            SqlDataReader userDataReader = profileCommand.ExecuteReader();

            profileConnection.Dispose();

            //return updateSuccess;
            return true;

        }


        public void toXml(XmlTextWriter xmlOut)
        {
            //if (!((null == assocCoreID) || (null == profileID) || (0 == profileID)))
            //{
            xmlOut.WriteStartElement("profile");
            xmlOut.WriteAttributeString("assocCoreID", assocCoreID.ToString());
            xmlOut.WriteAttributeString("profileID", profileID.ToString());

/*
                xmlOut.WriteStartElement("profilecategory");
                xmlOut.WriteAttributeString("name", "nam");
                xmlOut.WriteAttributeString("label", "Label");

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "nam");
                    xmlOut.WriteAttributeString("label", "Label");
                    xmlOut.WriteAttributeString("value", value.ToString());
                    xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();

categoryA
catAother
categoryB
catBother
*/
                xmlOut.WriteStartElement("profilecategory");
                xmlOut.WriteAttributeString("name", "cata");
                xmlOut.WriteAttributeString("label", "Project Category A");

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", CategoryA);
                    xmlOut.WriteAttributeString("label", "Category A");
                    xmlOut.WriteAttributeString("priority", "1");
                    xmlOut.WriteAttributeString("value", CatAother);
                    xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();

                xmlOut.WriteStartElement("profilecategory");
                xmlOut.WriteAttributeString("name", "catb");
                xmlOut.WriteAttributeString("label", "Project Category B");

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", CategoryB);
                    xmlOut.WriteAttributeString("label", "Category B");
                    xmlOut.WriteAttributeString("priority", "1");
                    xmlOut.WriteAttributeString("value", CatBother);
                    xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();


                xmlOut.WriteStartElement("profilecategory");
                xmlOut.WriteAttributeString("name", "aud");
                xmlOut.WriteAttributeString("label", "Audience");

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "farmranchers");
                    xmlOut.WriteAttributeString("label", "Farmers and Ranchers");
                    xmlOut.WriteAttributeString("value", aud_farmranchers.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "educators");
                    xmlOut.WriteAttributeString("label", "Educators");
                    xmlOut.WriteAttributeString("value", aud_educators.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "researchers");
                    xmlOut.WriteAttributeString("label", "Researchers");
                    xmlOut.WriteAttributeString("value", aud_researchers.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "consumers");
                    xmlOut.WriteAttributeString("label", "Consumers");
                    xmlOut.WriteAttributeString("value", aud_consumers.ToString());
                    xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();

                xmlOut.WriteStartElement("profilecategory");
                xmlOut.WriteAttributeString("name", "techlvl");
                xmlOut.WriteAttributeString("label", "Tech Level");

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "beginner");
                    xmlOut.WriteAttributeString("label", "Beginner");
                    xmlOut.WriteAttributeString("value", techlvl_beginner.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "intermediate");
                    xmlOut.WriteAttributeString("label", "Intermediate");
                    xmlOut.WriteAttributeString("value", techlvl_intermediate.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "advanced");
                    xmlOut.WriteAttributeString("label", "Advanced");
                    xmlOut.WriteAttributeString("value", techlvl_advanced.ToString());
                    xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();

                xmlOut.WriteStartElement("profilecategory");
                xmlOut.WriteAttributeString("name", "inv");
                xmlOut.WriteAttributeString("label", "Involvement");

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "planning");
                    xmlOut.WriteAttributeString("label", "Planning");
                    xmlOut.WriteAttributeString("value", inv_planning.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "planningcount");
                    xmlOut.WriteAttributeString("label", "Label");
                    xmlOut.WriteAttributeString("value", inv_planningcount.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "present");
                    xmlOut.WriteAttributeString("label", "Label");
                    xmlOut.WriteAttributeString("value", inv_present.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "presentcount");
                    xmlOut.WriteAttributeString("label", "Label");
                    xmlOut.WriteAttributeString("value", inv_presentcount.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "numparticipants");
                    xmlOut.WriteAttributeString("label", "Label");
                    xmlOut.WriteAttributeString("value", inv_numparticipants.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "research");
                    xmlOut.WriteAttributeString("label", "Label");
                    xmlOut.WriteAttributeString("value", inv_research.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "researchcount");
                    xmlOut.WriteAttributeString("label", "Label");
                    xmlOut.WriteAttributeString("value", inv_researchcount.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "land");
                    xmlOut.WriteAttributeString("label", "Label");
                    xmlOut.WriteAttributeString("value", inv_land.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "landcount");
                    xmlOut.WriteAttributeString("label", "Label");
                    xmlOut.WriteAttributeString("value", inv_landcount.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "numideas");
                    xmlOut.WriteAttributeString("label", "Label");
                    xmlOut.WriteAttributeString("value", inv_numideas.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "extplanning");
                    xmlOut.WriteAttributeString("label", "Label");
                    xmlOut.WriteAttributeString("value", inv_extplanning.ToString());
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profileoption");
                    xmlOut.WriteAttributeString("name", "extapplied");
                    xmlOut.WriteAttributeString("label", "Label");
                    xmlOut.WriteAttributeString("value", inv_extapplied.ToString());
                    xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();

                xmlOut.WriteStartElement("profilecategory");
                xmlOut.WriteAttributeString("name", "practices");
                xmlOut.WriteAttributeString("label", "Profile Category A: Practices");

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "intgfrs");
                    xmlOut.WriteAttributeString("label", "Integrated Farm/Ranch System");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "agroecosystemanalysis");
                        xmlOut.WriteAttributeString("label", "Agroecosystem Analysis");
                        xmlOut.WriteAttributeString("value", intgfrs_AgroecosystemAnalysis.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "holisticmanagement");
                        xmlOut.WriteAttributeString("label", "Holistic Management");
                        xmlOut.WriteAttributeString("value", intgfrs_HolisticManagement.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "organicagriculture");
                        xmlOut.WriteAttributeString("label", "Organic Agriculture");
                        xmlOut.WriteAttributeString("value", intgfrs_OrganicAgriculture.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "permaculture");
                        xmlOut.WriteAttributeString("label", "Permaculture");
                        xmlOut.WriteAttributeString("value", intgfrs_Permaculture.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "wholefarmplanning");
                        xmlOut.WriteAttributeString("label", "Whole Farm Planning");
                        xmlOut.WriteAttributeString("value", intgfrs_WholeFarmPlanning.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (IntgfrsOther == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", IntgfrsOther.ToString());
                        xmlOut.WriteEndElement();

                    xmlOut.WriteEndElement();
                    
                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "cropprd");
                    xmlOut.WriteAttributeString("label", "Crop Production");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "agroforestry");
                        xmlOut.WriteAttributeString("label", "Agroforestry");
                        xmlOut.WriteAttributeString("value", cropprd_Agroforestry.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "biologicalinoculants");
                        xmlOut.WriteAttributeString("label", "Biological Inoculants");
                        xmlOut.WriteAttributeString("value", cropprd_BiologicalInoculants.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "catchcrops");
                        xmlOut.WriteAttributeString("label", "Catch Crops");
                        xmlOut.WriteAttributeString("value", cropprd_CatchCrops.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "continuouscropping");
                        xmlOut.WriteAttributeString("label", "Continuous Cropping");
                        xmlOut.WriteAttributeString("value", cropprd_ContinuousCropping.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "covercrops");
                        xmlOut.WriteAttributeString("label", "Cover Crops");
                        xmlOut.WriteAttributeString("value", cropprd_CoverCrops.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "cropbreeding");
                        xmlOut.WriteAttributeString("label", "Crop Breeding");
                        xmlOut.WriteAttributeString("value", cropprd_CropBreeding.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "croprotation");
                        xmlOut.WriteAttributeString("label", "Crop Rotation");
                        xmlOut.WriteAttributeString("value", cropprd_CropRotation.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "doublecropping");
                        xmlOut.WriteAttributeString("label", "Double Cropping");
                        xmlOut.WriteAttributeString("value", cropprd_DoubleCropping.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "earthworms");
                        xmlOut.WriteAttributeString("label", "Earthworms");
                        xmlOut.WriteAttributeString("value", cropprd_Earthworms.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "fallow");
                        xmlOut.WriteAttributeString("label", "Fallow");
                        xmlOut.WriteAttributeString("value", cropprd_Fallow.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "fertigation");
                        xmlOut.WriteAttributeString("label", "Fertigation");
                        xmlOut.WriteAttributeString("value", cropprd_Fertigation.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "foliarfeeding");
                        xmlOut.WriteAttributeString("label", "Foliar Feeding");
                        xmlOut.WriteAttributeString("value", cropprd_FoliarFeeding.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "forestry");
                        xmlOut.WriteAttributeString("label", "Forestry");
                        xmlOut.WriteAttributeString("value", cropprd_Forestry.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "greenmanures");
                        xmlOut.WriteAttributeString("label", "Green Manures");
                        xmlOut.WriteAttributeString("value", cropprd_GreenManures.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "intercropping");
                        xmlOut.WriteAttributeString("label", "Intercropping");
                        xmlOut.WriteAttributeString("value", cropprd_Intercropping.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "irrigation");
                        xmlOut.WriteAttributeString("label", "Irrigation");
                        xmlOut.WriteAttributeString("value", cropprd_Irrigation.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "minimumtillage");
                        xmlOut.WriteAttributeString("label", "Minimum Tillage");
                        xmlOut.WriteAttributeString("value", cropprd_MinimumTillage.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "multiplecropping");
                        xmlOut.WriteAttributeString("label", "Multiple Cropping");
                        xmlOut.WriteAttributeString("value", cropprd_MultipleCropping.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "municipalwastes");
                        xmlOut.WriteAttributeString("label", "Municipal Wastes");
                        xmlOut.WriteAttributeString("value", cropprd_MunicipalWastes.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "notill");
                        xmlOut.WriteAttributeString("label", "No-Till");
                        xmlOut.WriteAttributeString("value", cropprd_NoTill.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "nutrientcycling");
                        xmlOut.WriteAttributeString("label", "Nutrient Cycling");
                        xmlOut.WriteAttributeString("value", cropprd_NutrientCycling.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "organicfertilizers");
                        xmlOut.WriteAttributeString("label", "Organic Fertilizers");
                        xmlOut.WriteAttributeString("value", cropprd_OrganicFertilizers.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "organicmatter");
                        xmlOut.WriteAttributeString("label", "Organic Matter");
                        xmlOut.WriteAttributeString("value", cropprd_OrganicMatter.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "permaculture");
                        xmlOut.WriteAttributeString("label", "Permaculture");
                        xmlOut.WriteAttributeString("value", cropprd_Permaculture.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "reducedapplications");
                        xmlOut.WriteAttributeString("label", "Reduced Applications");
                        xmlOut.WriteAttributeString("value", cropprd_ReducedApplications.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "relaycropping");
                        xmlOut.WriteAttributeString("label", "Relay Cropping");
                        xmlOut.WriteAttributeString("value", cropprd_RelayCropping.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "ridgetillage");
                        xmlOut.WriteAttributeString("label", "Ridge Tillage");
                        xmlOut.WriteAttributeString("value", cropprd_RidgeTillage.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "soilanalysis");
                        xmlOut.WriteAttributeString("label", "Soil Analysis");
                        xmlOut.WriteAttributeString("value", cropprd_SoilAnalysis.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "stripcropping");
                        xmlOut.WriteAttributeString("label", "Strip Cropping");
                        xmlOut.WriteAttributeString("value", cropprd_StripCropping.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "stubblemulching");
                        xmlOut.WriteAttributeString("label", "Stubble Mulching");
                        xmlOut.WriteAttributeString("value", cropprd_StubbleMulching.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "tissueanalysis");
                        xmlOut.WriteAttributeString("label", "Tissue Analysis");
                        xmlOut.WriteAttributeString("value", cropprd_TissueAnalysis.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "transitioning");
                        xmlOut.WriteAttributeString("label", "Transitioning To Organic");
                        xmlOut.WriteAttributeString("value", cropprd_Transitioning.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (cropprd_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", cropprd_Other.ToString());
                        xmlOut.WriteEndElement();

                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "animprd");
                    xmlOut.WriteAttributeString("label", "Animal Production");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "alternativefeedstuffs");
                        xmlOut.WriteAttributeString("label", "Alternative Feedstuffs");
                        xmlOut.WriteAttributeString("value", animprd_AlternativeFeedstuffs.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "alternativehousing");
                        xmlOut.WriteAttributeString("label", "Alternative Housing");
                        xmlOut.WriteAttributeString("value", animprd_AlternativeHousing.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "alternparasitecontrol");
                        xmlOut.WriteAttributeString("label", "Altern. Parasite Control");
                        xmlOut.WriteAttributeString("value", animprd_AlternParasiteControl.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "animalprotection");
                        xmlOut.WriteAttributeString("label", "Animal Protection");
                        xmlOut.WriteAttributeString("value", animprd_AnimalProtection.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "composting");
                        xmlOut.WriteAttributeString("label", "Composting");
                        xmlOut.WriteAttributeString("value", animprd_Composting.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "continuousgrazing");
                        xmlOut.WriteAttributeString("label", "Continuous Grazing");
                        xmlOut.WriteAttributeString("value", animprd_ContinuousGrazing.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "feedadditives");
                        xmlOut.WriteAttributeString("label", "FeedAdditives");
                        xmlOut.WriteAttributeString("value", animprd_FeedAdditives.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "feedformulation");
                        xmlOut.WriteAttributeString("label", "Feed Formulation");
                        xmlOut.WriteAttributeString("value", animprd_FeedFormulation.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "feedrations");
                        xmlOut.WriteAttributeString("label", "Feed Rations");
                        xmlOut.WriteAttributeString("value", animprd_FeedRations.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "freerange");
                        xmlOut.WriteAttributeString("label", "Free-Range");
                        xmlOut.WriteAttributeString("value", animprd_FreeRange.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "grazingmanagement");
                        xmlOut.WriteAttributeString("label", "Grazing Management");
                        xmlOut.WriteAttributeString("value", animprd_grazingmanagement.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "herbalmedicines");
                        xmlOut.WriteAttributeString("label", "Herbal Medicines");
                        xmlOut.WriteAttributeString("value", animprd_HerbalMedicines.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "homeopathy");
                        xmlOut.WriteAttributeString("label", "Homeopathy");
                        xmlOut.WriteAttributeString("value", animprd_Homeopathy.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "implants");
                        xmlOut.WriteAttributeString("label", "Implants");
                        xmlOut.WriteAttributeString("value", animprd_Implants.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "inoculants");
                        xmlOut.WriteAttributeString("label", "Inoculants");
                        xmlOut.WriteAttributeString("value", animprd_Inoculants.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "livestockbreeding");
                        xmlOut.WriteAttributeString("label", "Livestock Breeding");
                        xmlOut.WriteAttributeString("value", animprd_LivestockBreeding.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "manuremanagement");
                        xmlOut.WriteAttributeString("label", "Manure Management");
                        xmlOut.WriteAttributeString("value", animprd_ManureManagement.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "mineralsupplements");
                        xmlOut.WriteAttributeString("label", "Mineral Supplements");
                        xmlOut.WriteAttributeString("value", animprd_MineralSupplements.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "multispeciesgrazing");
                        xmlOut.WriteAttributeString("label", "Multispecies Grazing");
                        xmlOut.WriteAttributeString("value", animprd_MultispeciesGrazing.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "pasturefertility");
                        xmlOut.WriteAttributeString("label", "Pasture Fertility");
                        xmlOut.WriteAttributeString("value", animprd_PastureFertility.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "pasturerenovation");
                        xmlOut.WriteAttributeString("label", "Pasture Renovation");
                        xmlOut.WriteAttributeString("value", animprd_PastureRenovation.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "preventivepractices");
                        xmlOut.WriteAttributeString("label", "Preventive Practices");
                        xmlOut.WriteAttributeString("value", animprd_PreventivePractices.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "probiotics");
                        xmlOut.WriteAttributeString("label", "Probiotics");
                        xmlOut.WriteAttributeString("value", animprd_Probiotics.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "rangeimprovement");
                        xmlOut.WriteAttributeString("label", "Range Improvement");
                        xmlOut.WriteAttributeString("value", animprd_RangeImprovement.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "rotationalgrazing");
                        xmlOut.WriteAttributeString("label", "Rotational Grazing");
                        xmlOut.WriteAttributeString("value", animprd_RotationalGrazing.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "shadeshelter");
                        xmlOut.WriteAttributeString("label", "Shade/Shelter");
                        xmlOut.WriteAttributeString("value", animprd_ShadeShelter.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "stockingrate");
                        xmlOut.WriteAttributeString("label", "Stocking Rate");
                        xmlOut.WriteAttributeString("value", animprd_StockingRate.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "stockpiledforages");
                        xmlOut.WriteAttributeString("label", "Stockpiled Forages");
                        xmlOut.WriteAttributeString("value", animprd_StockpiledForages.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "therapeutics");
                        xmlOut.WriteAttributeString("label", "Therapeutics");
                        xmlOut.WriteAttributeString("value", animprd_Therapeutics.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "vaccines");
                        xmlOut.WriteAttributeString("label", "Vaccines");
                        xmlOut.WriteAttributeString("value", animprd_Vaccines.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "wateringsystem");
                        xmlOut.WriteAttributeString("label", "Watering System");
                        xmlOut.WriteAttributeString("value", animprd_WateringSystem.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "winterforage");
                        xmlOut.WriteAttributeString("label", "Winter Forage");
                        xmlOut.WriteAttributeString("value", animprd_WinterForage.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (animprd_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", animprd_Other.ToString());
                        xmlOut.WriteEndElement();                        

                    xmlOut.WriteEndElement();
                    
                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "pestmgt");
                    xmlOut.WriteAttributeString("label", "Pest Management");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "allelopathy");
                        xmlOut.WriteAttributeString("label", "Allelopathy");
                        xmlOut.WriteAttributeString("value", pestmgt_Allelopathy.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "biologicalcontrol");
                        xmlOut.WriteAttributeString("label", "Biological Control");
                        xmlOut.WriteAttributeString("value", pestmgt_BiologicalControl.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "biorationalpesticides");
                        xmlOut.WriteAttributeString("label", "Biorational Pesticides");
                        xmlOut.WriteAttributeString("value", pestmgt_BiorationalPesticides.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "botanicalpesticides");
                        xmlOut.WriteAttributeString("label", "Botanical Pesticides");
                        xmlOut.WriteAttributeString("value", pestmgt_BotanicalPesticides.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "chemicalcontrol");
                        xmlOut.WriteAttributeString("label", "Chemical Control");
                        xmlOut.WriteAttributeString("value", pestmgt_ChemicalControl.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "competition");
                        xmlOut.WriteAttributeString("label", "Competition");
                        xmlOut.WriteAttributeString("value", pestmgt_Competition.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "compostextracts");
                        xmlOut.WriteAttributeString("label", "Compost Extracts");
                        xmlOut.WriteAttributeString("value", pestmgt_CompostExtracts.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "culturalcontrol");
                        xmlOut.WriteAttributeString("label", "Cultural Control");
                        xmlOut.WriteAttributeString("value", pestmgt_CulturalControl.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "diseasevectors");
                        xmlOut.WriteAttributeString("label", "Disease Vectors");
                        xmlOut.WriteAttributeString("value", pestmgt_DiseaseVectors.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "economicthreshold");
                        xmlOut.WriteAttributeString("label", "Economic Threshold");
                        xmlOut.WriteAttributeString("value", pestmgt_EconomicThreshold.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "eradication");
                        xmlOut.WriteAttributeString("label", "Eradication");
                        xmlOut.WriteAttributeString("value", pestmgt_Eradication.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "fieldmonitoring");
                        xmlOut.WriteAttributeString("label", "Field Monitoring");
                        xmlOut.WriteAttributeString("value", pestmgt_FieldMonitoring.ToString());
                        xmlOut.WriteEndElement();
                        
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "flame");
                        xmlOut.WriteAttributeString("label", "Flame");
                        xmlOut.WriteAttributeString("value", pestmgt_Flame.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "geneticresistance");
                        xmlOut.WriteAttributeString("label", "Genetic Resistance");
                        xmlOut.WriteAttributeString("value", pestmgt_GeneticResistance.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "ipm");
                        xmlOut.WriteAttributeString("label", "IPM");
                        xmlOut.WriteAttributeString("value", pestmgt_IPM.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "killedmulches");
                        xmlOut.WriteAttributeString("label", "Killed Mulches");
                        xmlOut.WriteAttributeString("value", pestmgt_KilledMulches.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "livingmulches");
                        xmlOut.WriteAttributeString("label", "Living Mulches");
                        xmlOut.WriteAttributeString("value", pestmgt_LivingMulches.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "matingdisruption");
                        xmlOut.WriteAttributeString("label", "Mating Disruption");
                        xmlOut.WriteAttributeString("value", pestmgt_MatingDisruption.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "mechanicalcontrol");
                        xmlOut.WriteAttributeString("label", "Mechanical Control");
                        xmlOut.WriteAttributeString("value", pestmgt_MechanicalControl.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "physicalcontrol");
                        xmlOut.WriteAttributeString("label", "Physical Control");
                        xmlOut.WriteAttributeString("value", pestmgt_PhysicalControl.ToString());
                        xmlOut.WriteEndElement();
                        
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "plasticmulching");
                        xmlOut.WriteAttributeString("label", "Plastic Mulching");
                        xmlOut.WriteAttributeString("value", pestmgt_PlasticMulching.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "precisioncultivation");
                        xmlOut.WriteAttributeString("label", "Precision Cultivation");
                        xmlOut.WriteAttributeString("value", pestmgt_PrecisionCultivation.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "precisionherbicideuse");
                        xmlOut.WriteAttributeString("label", "Precision Herbicide Use");
                        xmlOut.WriteAttributeString("value", pestmgt_PrecisionHerbicideUse.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "prevention");
                        xmlOut.WriteAttributeString("label", "Prevention");
                        xmlOut.WriteAttributeString("value", pestmgt_Prevention.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "rowcovers");
                        xmlOut.WriteAttributeString("label", "Row Covers");
                        xmlOut.WriteAttributeString("value", pestmgt_RowCovers.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "sanitation");
                        xmlOut.WriteAttributeString("label", "Sanitation");
                        xmlOut.WriteAttributeString("value", pestmgt_Sanitation.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "smothercrops");
                        xmlOut.WriteAttributeString("label", "Smother Crops");
                        xmlOut.WriteAttributeString("value", pestmgt_SmotherCrops.ToString());
                        xmlOut.WriteEndElement();
                        
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "soilsolarization");
                        xmlOut.WriteAttributeString("label", "Soil Solarization");
                        xmlOut.WriteAttributeString("value", pestmgt_SoilSolarization.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "trapcrops");
                        xmlOut.WriteAttributeString("label", "Trap Crops");
                        xmlOut.WriteAttributeString("value", pestmgt_TrapCrops.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "traps");
                        xmlOut.WriteAttributeString("label", "Traps");
                        xmlOut.WriteAttributeString("value", pestmgt_Traps.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "vegetativemulching");
                        xmlOut.WriteAttributeString("label", "Vegetative Mulching");
                        xmlOut.WriteAttributeString("value", pestmgt_VegetativeMulching.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "weathermonitoring");
                        xmlOut.WriteAttributeString("label", "Weather Monitoring");
                        xmlOut.WriteAttributeString("value", pestmgt_WeatherMonitoring.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "weedecology");
                        xmlOut.WriteAttributeString("label", "Weed Ecology");
                        xmlOut.WriteAttributeString("value", pestmgt_WeedEcology.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "weedergeese");
                        xmlOut.WriteAttributeString("label", "Weeder Geese");
                        xmlOut.WriteAttributeString("value", pestmgt_WeederGeese.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (pestmgt_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", pestmgt_Other.ToString());
                        xmlOut.WriteEndElement();
                        
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "soilmgt");
                    xmlOut.WriteAttributeString("label", "Soil Management");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "carbonsequestration");
                        xmlOut.WriteAttributeString("label", "Carbon Sequestration");
                        xmlOut.WriteAttributeString("value", soilmgt_CarbonSequestration.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "nutrientmineralization");
                        xmlOut.WriteAttributeString("label", "Nutrient Mineralization");
                        xmlOut.WriteAttributeString("value", soilmgt_NutrientMineralization.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "soilchemistry");
                        xmlOut.WriteAttributeString("label", "Soil Chemistry");
                        xmlOut.WriteAttributeString("value", soilmgt_SoilChemistry.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "soilmicrobiology");
                        xmlOut.WriteAttributeString("label", "Soil Microbiology");
                        xmlOut.WriteAttributeString("value", soilmgt_SoilMicrobiology.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "soilorganicmatter");
                        xmlOut.WriteAttributeString("label", "Soil Organic Matter");
                        xmlOut.WriteAttributeString("value", soilmgt_SoilOrganicMatter.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "soilphysics");
                        xmlOut.WriteAttributeString("label", "Soil Physics");
                        xmlOut.WriteAttributeString("value", soilmgt_SoilPhysics.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "soilquality");
                        xmlOut.WriteAttributeString("label", "Soil Quality");
                        xmlOut.WriteAttributeString("value", soilmgt_SoilQuality.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (soilmgt_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", soilmgt_Other.ToString());
                        xmlOut.WriteEndElement();

                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "nresenv");
                    xmlOut.WriteAttributeString("label", "Natural Resources/Environment");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "afforestation");
                        xmlOut.WriteAttributeString("label", "Afforestation");
                        xmlOut.WriteAttributeString("value", nresenv_Afforestation.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "biodiversity");
                        xmlOut.WriteAttributeString("label", "Biodiversity");
                        xmlOut.WriteAttributeString("value", nresenv_Biodiversity.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "biosphere");
                        xmlOut.WriteAttributeString("label", "Biosphere");
                        xmlOut.WriteAttributeString("value", nresenv_Biosphere.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "conservationtillage");
                        xmlOut.WriteAttributeString("label", "Conservation Tillage");
                        xmlOut.WriteAttributeString("value", nresenv_ConservationTillage.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "contourcultivation");
                        xmlOut.WriteAttributeString("label", "Contour Cultivation");
                        xmlOut.WriteAttributeString("value", nresenv_ContourCultivation.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "grasshedges");
                        xmlOut.WriteAttributeString("label", "Grass Hedges");
                        xmlOut.WriteAttributeString("value", nresenv_GrassHedges.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "grasswaterways");
                        xmlOut.WriteAttributeString("label", "Grass Waterways");
                        xmlOut.WriteAttributeString("value", nresenv_GrassWaterways.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "habitatenhancement");
                        xmlOut.WriteAttributeString("label", "Habitat Enhancement");
                        xmlOut.WriteAttributeString("value", nresenv_HabitatEnhancement.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "hedgerows");
                        xmlOut.WriteAttributeString("label", "Hedgerows");
                        xmlOut.WriteAttributeString("value", nresenv_Hedgerows.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "indicators");
                        xmlOut.WriteAttributeString("label", "Indicators");
                        xmlOut.WriteAttributeString("value", nresenv_Indicators.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "riparianplantings");
                        xmlOut.WriteAttributeString("label", "Riparian Plantings");
                        xmlOut.WriteAttributeString("value", nresenv_RiparianPlantings.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "riverbankprotection");
                        xmlOut.WriteAttributeString("label", "Riverbank Protection");
                        xmlOut.WriteAttributeString("value", nresenv_RiverbankProtection.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "soilstabilization");
                        xmlOut.WriteAttributeString("label", "Soil Stabilization");
                        xmlOut.WriteAttributeString("value", nresenv_SoilStabilization.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "terraces");
                        xmlOut.WriteAttributeString("label", "Terraces");
                        xmlOut.WriteAttributeString("value", nresenv_Terraces.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "wetlands");
                        xmlOut.WriteAttributeString("label", "Wetlands");
                        xmlOut.WriteAttributeString("value", nresenv_Wetlands.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "wildlife");
                        xmlOut.WriteAttributeString("label", "Wildlife");
                        xmlOut.WriteAttributeString("value", nresenv_Wildlife.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "windbreaks");
                        xmlOut.WriteAttributeString("label", "Windbreaks");
                        xmlOut.WriteAttributeString("value", nresenv_Windbreaks.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "woodyhedges");
                        xmlOut.WriteAttributeString("label", "Woody Hedges");
                        xmlOut.WriteAttributeString("value", nresenv_WoodyHedges.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (nresenv_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", nresenv_Other.ToString());
                        xmlOut.WriteEndElement();

                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "edu_trn");
                    xmlOut.WriteAttributeString("label", "Education &amp; Training");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "casestudy");
                        xmlOut.WriteAttributeString("label", "Case Study");
                        xmlOut.WriteAttributeString("value", edtrain_CaseStudy.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "conference");
                        xmlOut.WriteAttributeString("label", "Conference");
                        xmlOut.WriteAttributeString("value", edtrain_Conference.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "curriculum");
                        xmlOut.WriteAttributeString("label", "Curriculum");
                        xmlOut.WriteAttributeString("value", edtrain_Curriculum.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "database");
                        xmlOut.WriteAttributeString("label", "Database");
                        xmlOut.WriteAttributeString("value", edtrain_Database.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "decisionsupportsystem");
                        xmlOut.WriteAttributeString("label", "Decision Support System");
                        xmlOut.WriteAttributeString("value", edtrain_DecisionSupportSystem.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "demonstration");
                        xmlOut.WriteAttributeString("label", "Demonstration");
                        xmlOut.WriteAttributeString("value", edtrain_Demonstration.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "display");
                        xmlOut.WriteAttributeString("label", "Display");
                        xmlOut.WriteAttributeString("value", edtrain_Display.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "extension");
                        xmlOut.WriteAttributeString("label", "Extension");
                        xmlOut.WriteAttributeString("value", edtrain_Extension.ToString());
                        xmlOut.WriteEndElement();
                        
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "factsheet");
                        xmlOut.WriteAttributeString("label", "Fact Sheet");
                        xmlOut.WriteAttributeString("value", edtrain_FactSheet.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "farmertofarmer");
                        xmlOut.WriteAttributeString("label", "Farmer To Farmer");
                        xmlOut.WriteAttributeString("value", edtrain_FarmerToFarmer.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "focusgroup");
                        xmlOut.WriteAttributeString("label", "Focus Group");
                        xmlOut.WriteAttributeString("value", edtrain_FocusGroup.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "mentoring");
                        xmlOut.WriteAttributeString("label", "Mentoring");
                        xmlOut.WriteAttributeString("value", edtrain_Mentor.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "network");
                        xmlOut.WriteAttributeString("label", "Network");
                        xmlOut.WriteAttributeString("value", edtrain_Network.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "onfarmresearch");
                        xmlOut.WriteAttributeString("label", "On-Farm Research");
                        xmlOut.WriteAttributeString("value", edtrain_OnFarmResearch.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "participatoryresearch");
                        xmlOut.WriteAttributeString("label", "Participatory Research");
                        xmlOut.WriteAttributeString("value", edtrain_ParticipatoryResearch.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "studycircle");
                        xmlOut.WriteAttributeString("label", "Study Circle");
                        xmlOut.WriteAttributeString("value", edtrain_StudyCircle.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "workshop");
                        xmlOut.WriteAttributeString("label", "Workshop");
                        xmlOut.WriteAttributeString("value", edtrain_Workshop.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "youtheducation");
                        xmlOut.WriteAttributeString("label", "Youth Education");
                        xmlOut.WriteAttributeString("value", edtrain_YouthEducation.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (edtrain_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", edtrain_Other.ToString());
                        xmlOut.WriteEndElement();                        

                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "econmkt");
                    xmlOut.WriteAttributeString("label", "Economic/Marketing");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "alternativeenterprise");
                        xmlOut.WriteAttributeString("label", "Alternative Enterprise");
                        xmlOut.WriteAttributeString("value",econmkt_AlternativeEnterprise.ToString() );
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "budget");
                        xmlOut.WriteAttributeString("label", "Budget");
                        xmlOut.WriteAttributeString("value", econmkt_Budget.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "cooperatives");
                        xmlOut.WriteAttributeString("label", "Cooperatives");
                        xmlOut.WriteAttributeString("value", econmkt_Cooperatives.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "costandreturns");
                        xmlOut.WriteAttributeString("label", "Cost And Returns");
                        xmlOut.WriteAttributeString("value", econmkt_CostAndReturns.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "csa");
                        xmlOut.WriteAttributeString("label", "CSA");
                        xmlOut.WriteAttributeString("value", econmkt_CSA.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "directmarketing");
                        xmlOut.WriteAttributeString("label", "Direct Marketing");
                        xmlOut.WriteAttributeString("value", econmkt_DirectMarketing.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "ecommerce");
                        xmlOut.WriteAttributeString("label", "E-Commerce");
                        xmlOut.WriteAttributeString("value",econmkt_Ecommerce.ToString() );
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "farmtoinstitution");
                        xmlOut.WriteAttributeString("label", "Farm-To-Institution");
                        xmlOut.WriteAttributeString("value", econmkt_FarmToInstitution.ToString());
                        xmlOut.WriteEndElement();
                        
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "feasibilitystudy");
                        xmlOut.WriteAttributeString("label", "Feasibility Study");
                        xmlOut.WriteAttributeString("value", econmkt_FeasibilityStudy.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "financialanalysis");
                        xmlOut.WriteAttributeString("label", "Financial Analysis");
                        xmlOut.WriteAttributeString("value", econmkt_FinancialAnalysis.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "foodproductqualitysafety");
                        xmlOut.WriteAttributeString("label", "Food/Product/Quality/Safety");
                        xmlOut.WriteAttributeString("value", econmkt_FoodProductQualitySafety.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "laboremployment");
                        xmlOut.WriteAttributeString("label", "Labor/Employment");
                        xmlOut.WriteAttributeString("value", econmkt_LaborEmployment.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "marketstudy");
                        xmlOut.WriteAttributeString("label", "Market Study");
                        xmlOut.WriteAttributeString("value", econmkt_MarketStudy.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "riskmanagement");
                        xmlOut.WriteAttributeString("label", "RiskM anagement");
                        xmlOut.WriteAttributeString("value",econmkt_RiskManagement.ToString() );
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "valueadded");
                        xmlOut.WriteAttributeString("label", "Value Added");
                        xmlOut.WriteAttributeString("value", econmkt_ValueAdded.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (econmkt_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", econmkt_Other.ToString());
                        xmlOut.WriteEndElement();


                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "commdev");
                    xmlOut.WriteAttributeString("label", "Community Development");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "agritourism");
                        xmlOut.WriteAttributeString("label", "Agritourism");
                        xmlOut.WriteAttributeString("value", commdev_Agritourism.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "communityplanning");
                        xmlOut.WriteAttributeString("label", "Community Planning");
                        xmlOut.WriteAttributeString("value", commdev_CommunityPlanning.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "ethnicdifferencesculturaldemographicchange");
                        xmlOut.WriteAttributeString("label", "Ethnic Differences/Cultural &amp; Demographic Change");
                        xmlOut.WriteAttributeString("value", commdev_EthnicDifferencesCulturalDemographicChange.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "infrastructureanalysis");
                        xmlOut.WriteAttributeString("label", "Infrastructure Analysis");
                        xmlOut.WriteAttributeString("value", commdev_InfrastructureAnalysis.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "leadershipdevelopment");
                        xmlOut.WriteAttributeString("label", "Leadership Development");
                        xmlOut.WriteAttributeString("value", commdev_LeadershipDevelopment.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "localregionalcommunityfoodsystems");
                        xmlOut.WriteAttributeString("label", "Local/Regional/Community Food Systems");
                        xmlOut.WriteAttributeString("value", commdev_LocalRegionalCommunityFoodSystems.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "newbusinessopportunities");
                        xmlOut.WriteAttributeString("label", "New Business Opportunities");
                        xmlOut.WriteAttributeString("value", commdev_NewBusinessOpportunities.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "partnerships");
                        xmlOut.WriteAttributeString("label", "Partnerships");
                        xmlOut.WriteAttributeString("value", commdev_Partnerships.ToString());
                        xmlOut.WriteEndElement();
                        
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "publicparticipation");
                        xmlOut.WriteAttributeString("label", "Public Participation");
                        xmlOut.WriteAttributeString("value", commdev_PublicParticipation.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "publicpolicy");
                        xmlOut.WriteAttributeString("label", "Public Policy");
                        xmlOut.WriteAttributeString("value", commdev_PublicPolicy.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "technicalassistance");
                        xmlOut.WriteAttributeString("label", "Technical Assistance");
                        xmlOut.WriteAttributeString("value", commdev_TechnicalAssistance.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "urbanagriculture");
                        xmlOut.WriteAttributeString("label", "Urban Agriculture");
                        xmlOut.WriteAttributeString("value", commdev_UrbanAgriculture.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "urbanruralintegration");
                        xmlOut.WriteAttributeString("label", "Urban/Rural Integration");
                        xmlOut.WriteAttributeString("value", commdev_UrbanRuralIntegration.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (commdev_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", commdev_Other.ToString());
                        xmlOut.WriteEndElement();                        

                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "qoflife");
                    xmlOut.WriteAttributeString("label", "Quality of Life");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "analysisofpersonalfamilylife");
                        xmlOut.WriteAttributeString("label", "Analysis Of Personal/Family Life");
                        xmlOut.WriteAttributeString("value", qoflife_AnalysisOfPersonalFamilyLife.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "communityservices");
                        xmlOut.WriteAttributeString("label", "Community Services");
                        xmlOut.WriteAttributeString("value", qoflife_CommunityServices.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "employmentopportunities");
                        xmlOut.WriteAttributeString("label", "Employment Opportunities");
                        xmlOut.WriteAttributeString("value", qoflife_EmploymentOpportunities.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "socialcapital");
                        xmlOut.WriteAttributeString("label", "Social Capital");
                        xmlOut.WriteAttributeString("value", qoflife_SocialCapitol.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "socialnetworks");
                        xmlOut.WriteAttributeString("label", "Social Networks");
                        xmlOut.WriteAttributeString("value", qoflife_SocialNetworks.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "socialpsychologicalindicators");
                        xmlOut.WriteAttributeString("label", "Social Psychological Indicators");
                        xmlOut.WriteAttributeString("value", qoflife_SocialPsychologicalIndicators.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "sustainabilitymeasures");
                        xmlOut.WriteAttributeString("label", "Sustainability Measures");
                        xmlOut.WriteAttributeString("value", qoflife_SustainabilityMeasures.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (qoflife_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                        xmlOut.WriteAttributeString("value", qoflife_Other.ToString());
                        xmlOut.WriteEndElement();                        
                       
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "engcons");
                    xmlOut.WriteAttributeString("label", "Energy Concervation &amp; Renewable Energy");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "bioenergybiofuels");
                        xmlOut.WriteAttributeString("label", "Bioenergy and Biofuels");
                        xmlOut.WriteAttributeString("value", energy_BioenergyBiofuels.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "energyconservationefficiency");
                        xmlOut.WriteAttributeString("label", "Energy Conservation/Efficiency");
                        xmlOut.WriteAttributeString("value", energy_EnergyConservationEfficiency.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "energyuseconsumption");
                        xmlOut.WriteAttributeString("label", "Energy Use and Consumption");
                        xmlOut.WriteAttributeString("value", energy_EnergyUseConsumption.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "solarenergy");
                        xmlOut.WriteAttributeString("label", "Solar Energy");
                        xmlOut.WriteAttributeString("value", energy_SolarEnergy.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "windpower");
                        xmlOut.WriteAttributeString("label", "Wind Power");
                        xmlOut.WriteAttributeString("value", energy_WindPower.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (energy_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", energy_Other.ToString());
                        xmlOut.WriteEndElement();                        

                    xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();

                xmlOut.WriteStartElement("profilecategory");
                xmlOut.WriteAttributeString("name", "commodities");
                xmlOut.WriteAttributeString("label", "Profile Category B: Commodities");

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "commplagr");
                    xmlOut.WriteAttributeString("label", "Agronomic");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "barley");
                        xmlOut.WriteAttributeString("label", "Barley");
                        xmlOut.WriteAttributeString("value", commPlAgr_Barley.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "canola");
                        xmlOut.WriteAttributeString("label", "Canola");
                        xmlOut.WriteAttributeString("value", commPlAgr_Canola.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "corn");
                        xmlOut.WriteAttributeString("label", "Corn");
                        xmlOut.WriteAttributeString("value", commPlAgr_Corn.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "cotton");
                        xmlOut.WriteAttributeString("label", "Cotton");
                        xmlOut.WriteAttributeString("value", commPlAgr_Cotton.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "flax");
                        xmlOut.WriteAttributeString("label", "Flax");
                        xmlOut.WriteAttributeString("value", commPlAgr_Flax.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "grasshay");
                        xmlOut.WriteAttributeString("label", "Grass Hay");
                        xmlOut.WriteAttributeString("value", commPlAgr_GrassHay.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "grasslegumehay");
                        xmlOut.WriteAttributeString("label", "Grass/Legume Hay");
                        xmlOut.WriteAttributeString("value", commPlAgr_GrassLegumeHay.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "hops");
                        xmlOut.WriteAttributeString("label", "Hops");
                        xmlOut.WriteAttributeString("value", commPlAgr_Hops.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "kenaf");
                        xmlOut.WriteAttributeString("label", "Kenaf");
                        xmlOut.WriteAttributeString("value", commPlAgr_Kenaf.ToString());
                        xmlOut.WriteEndElement();
                        
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "legumehay");
                        xmlOut.WriteAttributeString("label", "Legume Hay");
                        xmlOut.WriteAttributeString("value", commPlAgr_LegumeHay.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "millet");
                        xmlOut.WriteAttributeString("label", "Millet");
                        xmlOut.WriteAttributeString("value", commPlAgr_Millet.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "oats");
                        xmlOut.WriteAttributeString("label", "Oats");
                        xmlOut.WriteAttributeString("value", commPlAgr_Oats.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "peanuts");
                        xmlOut.WriteAttributeString("label", "Peanuts");
                        xmlOut.WriteAttributeString("value", commPlAgr_Peanuts.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "potatoes");
                        xmlOut.WriteAttributeString("label", "Potatoes");
                        xmlOut.WriteAttributeString("value", commPlAgr_Potatoes.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "rapeseed");
                        xmlOut.WriteAttributeString("label", "Rapeseed");
                        xmlOut.WriteAttributeString("value", commPlAgr_Rapeseed.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "rice");
                        xmlOut.WriteAttributeString("label", "Rice");
                        xmlOut.WriteAttributeString("value", commPlAgr_Rice.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "rye");
                        xmlOut.WriteAttributeString("label", "Rye");
                        xmlOut.WriteAttributeString("value", commPlAgr_Rye.ToString());
                        xmlOut.WriteEndElement();
                        
                         xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "safflower");
                        xmlOut.WriteAttributeString("label", "Safflower");
                        xmlOut.WriteAttributeString("value", commPlAgr_Safflower.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "sorghum");
                        xmlOut.WriteAttributeString("label", "Sorghum");
                        xmlOut.WriteAttributeString("value", commPlAgr_Sorghum.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "soybeans");
                        xmlOut.WriteAttributeString("label", "Soybeans");
                        xmlOut.WriteAttributeString("value", commPlAgr_Soybeans.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "spelt");
                        xmlOut.WriteAttributeString("label", "Spelt");
                        xmlOut.WriteAttributeString("value", commPlAgr_Spelt.ToString());
                        xmlOut.WriteEndElement();  
         
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "sugarbeets");
                        xmlOut.WriteAttributeString("label", "Sugarbeets");
                        xmlOut.WriteAttributeString("value", commPlAgr_Sugarbeets.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "sugarcane");
                        xmlOut.WriteAttributeString("label", "Sugarcane");
                        xmlOut.WriteAttributeString("value", commPlAgr_Sugarcane.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "sunflower");
                        xmlOut.WriteAttributeString("label", "Sunflower");
                        xmlOut.WriteAttributeString("value", commPlAgr_Sunflower.ToString());
                        xmlOut.WriteEndElement();           

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "sweetpotatoes");
                        xmlOut.WriteAttributeString("label", "Sweetpotatoes");
                        xmlOut.WriteAttributeString("value", commPlAgr_Sweetpotatoes.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "tobacco");
                        xmlOut.WriteAttributeString("label", "Tobacco");
                        xmlOut.WriteAttributeString("value", commPlAgr_Tobacco.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "wheat");
                        xmlOut.WriteAttributeString("label", "Wheat");
                        xmlOut.WriteAttributeString("value", commPlAgr_Wheat.ToString());
                        xmlOut.WriteEndElement();
           
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (commPlAgr_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", commPlAgr_Other.ToString());
                        xmlOut.WriteEndElement();           

                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "commplveg");
                    xmlOut.WriteAttributeString("label", "Vegetable");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "artichokes");
                        xmlOut.WriteAttributeString("label", "Artichokes");
                        xmlOut.WriteAttributeString("value", commPlVeg_Artichokes.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "asparagus");
                        xmlOut.WriteAttributeString("label", "Asparagus");
                        xmlOut.WriteAttributeString("value", commPlVeg_Asparagus.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "beans");
                        xmlOut.WriteAttributeString("label", "Beans");
                        xmlOut.WriteAttributeString("value", commPlVeg_Beans.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "beets");
                        xmlOut.WriteAttributeString("label", "Beets");
                        xmlOut.WriteAttributeString("value", commPlVeg_Beets.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "broccoli");
                        xmlOut.WriteAttributeString("label", "Broccoli");
                        xmlOut.WriteAttributeString("value", commPlVeg_Broccoli.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "brusselsprouts");
                        xmlOut.WriteAttributeString("label", "Brussel Sprouts");
                        xmlOut.WriteAttributeString("value", commPlVeg_BrusselSprouts.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "cabbage");
                        xmlOut.WriteAttributeString("label", "Cabbage");
                        xmlOut.WriteAttributeString("value", commPlVeg_Cabbage.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "carrots");
                        xmlOut.WriteAttributeString("label", "Carrots");
                        xmlOut.WriteAttributeString("value", commPlVeg_Carrots.ToString());
                        xmlOut.WriteEndElement();
                        
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "cauliflower");
                        xmlOut.WriteAttributeString("label", "Cauliflower");
                        xmlOut.WriteAttributeString("value", commPlVeg_Cauliflower.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "celery");
                        xmlOut.WriteAttributeString("label", "Celery");
                        xmlOut.WriteAttributeString("value", commPlVeg_Celery.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "cucumbers");
                        xmlOut.WriteAttributeString("label", "Cucumbers");
                        xmlOut.WriteAttributeString("value", commPlVeg_Cucumbers.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "eggplant");
                        xmlOut.WriteAttributeString("label", "Eggplant");
                        xmlOut.WriteAttributeString("value", commPlVeg_Eggplant.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "escarole");
                        xmlOut.WriteAttributeString("label", "Escarole");
                        xmlOut.WriteAttributeString("value", commPlVeg_Escarole.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "garlic");
                        xmlOut.WriteAttributeString("label", "Garlic");
                        xmlOut.WriteAttributeString("value", commPlVeg_Garlic.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "greens");
                        xmlOut.WriteAttributeString("label", "Greens");
                        xmlOut.WriteAttributeString("value", commPlVeg_Greens.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "kale");
                        xmlOut.WriteAttributeString("label", "Kale");
                        xmlOut.WriteAttributeString("value", commPlVeg_Kale.ToString());
                        xmlOut.WriteEndElement();
                        
                         xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "leeks");
                        xmlOut.WriteAttributeString("label", "Leeks");
                        xmlOut.WriteAttributeString("value", commplveg_leeks.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "lentils");
                        xmlOut.WriteAttributeString("label", "Lentils");
                        xmlOut.WriteAttributeString("value", commPlVeg_Lentils.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "lettuce");
                        xmlOut.WriteAttributeString("label", "Lettuce");
                        xmlOut.WriteAttributeString("value", commPlVeg_Lettuce.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "onions");
                        xmlOut.WriteAttributeString("label", "Onions");
                        xmlOut.WriteAttributeString("value", commPlVeg_Onions.ToString());
                        xmlOut.WriteEndElement(); 
            
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "parsnips");
                        xmlOut.WriteAttributeString("label", "Parsnips");
                        xmlOut.WriteAttributeString("value", commPlVeg_Parsnips.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "peas");
                        xmlOut.WriteAttributeString("label", "Peas");
                        xmlOut.WriteAttributeString("value", commPlVeg_Peas.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "peppers");
                        xmlOut.WriteAttributeString("label", "Peppers");
                        xmlOut.WriteAttributeString("value", commPlVeg_Peppers.ToString());
                        xmlOut.WriteEndElement();
                        
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "pumpkins");
                        xmlOut.WriteAttributeString("label", "Pumpkins");
                        xmlOut.WriteAttributeString("value", commPlVeg_Pumpkins.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "radishes");
                        xmlOut.WriteAttributeString("label", "Radishes");
                        xmlOut.WriteAttributeString("value", commPlVeg_Radishes.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "rutabagas");
                        xmlOut.WriteAttributeString("label", "Rutabagas");
                        xmlOut.WriteAttributeString("value", commPlVeg_Rutabagas.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "spinach");
                        xmlOut.WriteAttributeString("label", "Spinach");
                        xmlOut.WriteAttributeString("value", commPlVeg_Spinach.ToString());
                        xmlOut.WriteEndElement();    
                    
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "squashes");
                        xmlOut.WriteAttributeString("label", "Squashes");
                        xmlOut.WriteAttributeString("value", commPlVeg_Squashes.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "sweetcorn");
                        xmlOut.WriteAttributeString("label", "SweetCorn");
                        xmlOut.WriteAttributeString("value", commPlVeg_SweetCorn.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "tomatoes");
                        xmlOut.WriteAttributeString("label", "Tomatoes");
                        xmlOut.WriteAttributeString("value", commPlVeg_Tomatoes.ToString());
                        xmlOut.WriteEndElement();
                        
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "turnips");
                        xmlOut.WriteAttributeString("label", "Turnips");
                        xmlOut.WriteAttributeString("value", commPlVeg_Turnips.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "watermelon");
                        xmlOut.WriteAttributeString("label", "Watermelon");
                        xmlOut.WriteAttributeString("value", commPlVeg_Watermelon.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (commPlVeg_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", commPlVeg_Other.ToString());
                        xmlOut.WriteEndElement();
                        
                    xmlOut.WriteEndElement();

                
                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "commplfruit");
                    xmlOut.WriteAttributeString("label", "Fruit");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "apples");
                        xmlOut.WriteAttributeString("label", "Apples");
                        xmlOut.WriteAttributeString("value", commPlFruit_Apples.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "apricots");
                        xmlOut.WriteAttributeString("label", "Apricots");
                        xmlOut.WriteAttributeString("value", commPlFruit_Apricots.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "avocados");
                        xmlOut.WriteAttributeString("label", "Avocados");
                        xmlOut.WriteAttributeString("value", commPlFruit_Avocados.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "bananas");
                        xmlOut.WriteAttributeString("label", "Bananas");
                        xmlOut.WriteAttributeString("value", commPlFruit_Bananas.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "berries");
                        xmlOut.WriteAttributeString("label", "Berries");
                        xmlOut.WriteAttributeString("value", commPlFruit_Berries.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "blueberries");
                        xmlOut.WriteAttributeString("label", "Blueberries");
                        xmlOut.WriteAttributeString("value", commPlFruit_Blueberries.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "brambles");
                        xmlOut.WriteAttributeString("label", "Brambles");
                        xmlOut.WriteAttributeString("value", commPlFruit_Brambles.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "cherries");
                        xmlOut.WriteAttributeString("label", "Cherries");
                        xmlOut.WriteAttributeString("value", commPlFruit_Cherries.ToString());
                        xmlOut.WriteEndElement();
                        
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "cranberries");
                        xmlOut.WriteAttributeString("label", "Cranberries");
                        xmlOut.WriteAttributeString("value", commPlFruit_Cranberries.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "figs");
                        xmlOut.WriteAttributeString("label", "Figs");
                        xmlOut.WriteAttributeString("value", commPlFruit_Figs.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "grapefruit");
                        xmlOut.WriteAttributeString("label", "Grapefruit");
                        xmlOut.WriteAttributeString("value", commPlFruit_Grapefruit.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "grapes");
                        xmlOut.WriteAttributeString("label", "Grapes");
                        xmlOut.WriteAttributeString("value", commPlFruit_Grapes.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "lemons");
                        xmlOut.WriteAttributeString("label", "Lemons");
                        xmlOut.WriteAttributeString("value", commPlFruit_Lemons.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "limes");
                        xmlOut.WriteAttributeString("label", "Limes");
                        xmlOut.WriteAttributeString("value", commPlFruit_Limes.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "melons");
                        xmlOut.WriteAttributeString("label", "Melons");
                        xmlOut.WriteAttributeString("value", commPlFruit_Melons.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "olives");
                        xmlOut.WriteAttributeString("label", "Olives");
                        xmlOut.WriteAttributeString("value", commPlFruit_Olives.ToString());
                        xmlOut.WriteEndElement();
                        
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "oranges");
                        xmlOut.WriteAttributeString("label", "Oranges");
                        xmlOut.WriteAttributeString("value", commPlFruit_Oranges.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "peaches");
                        xmlOut.WriteAttributeString("label", "Peaches");
                        xmlOut.WriteAttributeString("value", commPlFruit_Peaches.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "pears");
                        xmlOut.WriteAttributeString("label", "Pears");
                        xmlOut.WriteAttributeString("value", commPlFruit_Pears.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "pineapples");
                        xmlOut.WriteAttributeString("label", "Pineapples");
                        xmlOut.WriteAttributeString("value", commPlFruit_Pineapples.ToString());
                        xmlOut.WriteEndElement();   
            
                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "plums");
                        xmlOut.WriteAttributeString("label", "Plums");
                        xmlOut.WriteAttributeString("value", commPlFruit_Plums.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "quinces");
                        xmlOut.WriteAttributeString("label", "Quinces");
                        xmlOut.WriteAttributeString("value", commPlFruit_Quinces.ToString());
                        xmlOut.WriteEndElement();
                        
                         xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "strawberries");
                        xmlOut.WriteAttributeString("label", "Strawberries");
                        xmlOut.WriteAttributeString("value", commPlFruit_Strawberries.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "tangerines");
                        xmlOut.WriteAttributeString("label", "Tangerines");
                        xmlOut.WriteAttributeString("value", commPlFruit_Tangerines.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (commPlFruit_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", commPlFruit_Other.ToString());
                        xmlOut.WriteEndElement();
                       
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "commplnuts");
                    xmlOut.WriteAttributeString("label", "Nuts");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "almonds");
                        xmlOut.WriteAttributeString("label", "Almonds");
                        xmlOut.WriteAttributeString("value", commPlNuts_Almonds.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "chestnuts");
                        xmlOut.WriteAttributeString("label", "Chestnuts");
                        xmlOut.WriteAttributeString("value", commplnuts_chestnuts.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "hazelnuts");
                        xmlOut.WriteAttributeString("label", "Hazelnuts");
                        xmlOut.WriteAttributeString("value", commPlNuts_Hazelnuts.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "macadamia");
                        xmlOut.WriteAttributeString("label", "Macadamia");
                        xmlOut.WriteAttributeString("value", commPlNuts_Macadamia.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "pecans");
                        xmlOut.WriteAttributeString("label", "Pecans");
                        xmlOut.WriteAttributeString("value", commPlNuts_Pecans.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "pistachios");
                        xmlOut.WriteAttributeString("label", "Pistachios");
                        xmlOut.WriteAttributeString("value", commPlNuts_Pistachios.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "walnuts");
                        xmlOut.WriteAttributeString("label", "Walnuts");
                        xmlOut.WriteAttributeString("value", commPlNuts_Walnuts.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (commPlAdd_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", commPlNuts_Other.ToString());
                        xmlOut.WriteEndElement();
                        
                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "commpladd");
                    xmlOut.WriteAttributeString("label", "Additional Plants");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "herbs");
                        xmlOut.WriteAttributeString("label", "Herbs");
                        xmlOut.WriteAttributeString("value", commPlAdd_Herbs.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "mushrooms");
                        xmlOut.WriteAttributeString("label", "Mushrooms");
                        xmlOut.WriteAttributeString("value", commPlAdd_Mushrooms.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "nativeplants");
                        xmlOut.WriteAttributeString("label", "Native Plants (grasses, shrubs, trees)");
                        xmlOut.WriteAttributeString("value", commPlAdd_NativePlants.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "ornamentals");
                        xmlOut.WriteAttributeString("label", "Ornamentals (flowers, shrubs, trees, turf)");
                        xmlOut.WriteAttributeString("value", commPlAdd_Ornamentals.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "trees");
                        xmlOut.WriteAttributeString("label", "Trees (Christmas, fiber, windbreaks)");
                        xmlOut.WriteAttributeString("value", commPlAdd_Trees.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (commPlAdd_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", commPlAdd_Other.ToString());
                        xmlOut.WriteEndElement();                        

                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "commanim");
                    xmlOut.WriteAttributeString("label", "Animals");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "beef");
                        xmlOut.WriteAttributeString("label", "Beef");
                        xmlOut.WriteAttributeString("value", commAnim_Beef.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "chicken");
                        xmlOut.WriteAttributeString("label", "Chicken");
                        xmlOut.WriteAttributeString("value", commAnim_Chicken.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "dairy");
                        xmlOut.WriteAttributeString("label", "Dairy");
                        xmlOut.WriteAttributeString("value", commAnim_Dairy.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "goats");
                        xmlOut.WriteAttributeString("label", "Goats");
                        xmlOut.WriteAttributeString("value", commAnim_Goats.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "rabbits");
                        xmlOut.WriteAttributeString("label", "Rabbits");
                        xmlOut.WriteAttributeString("value", commAnim_Rabbits.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "sheep");
                        xmlOut.WriteAttributeString("label", "Sheep");
                        xmlOut.WriteAttributeString("value", commAnim_Sheep.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "swine");
                        xmlOut.WriteAttributeString("label", "Swine");
                        xmlOut.WriteAttributeString("value", commAnim_Swine.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "turkeys");
                        xmlOut.WriteAttributeString("label", "Turkeys");
                        xmlOut.WriteAttributeString("value", commAnim_Turkeys.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (commAnim_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", commAnim_Other.ToString());
                        xmlOut.WriteEndElement(); 

                    xmlOut.WriteEndElement();

                    xmlOut.WriteStartElement("profilesubcat");
                    xmlOut.WriteAttributeString("name", "commmisc");
                    xmlOut.WriteAttributeString("label", "Miscellaneous");

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "bees");
                        xmlOut.WriteAttributeString("label", "Bees");
                        xmlOut.WriteAttributeString("value", commMisc_Bees.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "fish");
                        xmlOut.WriteAttributeString("label", "Fish");
                        xmlOut.WriteAttributeString("value", commMisc_Fish.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "ratites");
                        xmlOut.WriteAttributeString("label", "Ratites");
                        xmlOut.WriteAttributeString("value", commMisc_Ratites.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "shellfish");
                        xmlOut.WriteAttributeString("label", "Shellfish");
                        xmlOut.WriteAttributeString("value", commMisc_Shellfish.ToString());
                        xmlOut.WriteEndElement();

                        xmlOut.WriteStartElement("profileoption");
                        xmlOut.WriteAttributeString("name", "other");
                        xmlOut.WriteAttributeString("label", "Other");
                        if (commMisc_Other == null)
                            xmlOut.WriteAttributeString("value", "");
                        else
                            xmlOut.WriteAttributeString("value", commMisc_Other.ToString());
                        xmlOut.WriteEndElement();       

                    xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();

                xmlOut.WriteElementString("submitted", submitted.ToString());
                xmlOut.WriteElementString("approved", approved.ToString());

            xmlOut.WriteEndElement();
            //}
        }

        public object dbNullify(object o)
        {
            if (o == null)
                o = DBNull.Value;
            else if (string.Compare((string)(o), "") == 0)
                o = DBNull.Value;
            else if (string.Compare((string)(o), "--") == 0)
                o = DBNull.Value;

            return o;
        }
        
        public bool InvPlanning
        {
            get
            {
                return inv_planning;
            }
            set
            {
                inv_planning = value;
            }
        }

        public bool InvPresent
        {
            get
            {
                return inv_present;
            }
            set
            {
                inv_present = value;
            }
        }

        public bool InvResearch
        {
            get
            {
                return inv_research;
            }
            set
            {
                inv_research = value;
            }
        }

        public bool InvLand
        {
            get
            {
                return inv_land;
            }
            set
            {
                inv_land = value;
            }
        }

        public int InvNumPlanning
        {
            get
            {
                return inv_planningcount;
            }
            set
            {
                inv_planningcount = value;
            }
        }

        public int InvNumPresent
        {
            get
            {
                return inv_presentcount;
            }
            set
            {
                inv_presentcount = value;
            }
        }

        public int InvNumResearch
        {
            get
            {
                return inv_researchcount;
            }
            set
            {
                inv_researchcount = value;
            }
        }

        public int InvNumLand
        {
            get
            {
                return inv_landcount;
            }
            set
            {
                inv_landcount = value;
            }
        }

        public int InvNumParticipants
        {
            get
            {
                return inv_numparticipants;
            }
            set
            {
                inv_numparticipants = value;
            }
        }

        public int InvNumIdeas
        {
            get
            {
                return inv_numideas;
            }
            set
            {
                inv_numideas = value;
            }
        }

        public bool InvExtPlanning
        {
            get
            {
                return inv_extplanning;
            }
            set
            {
                inv_extplanning = value;
            }
        }

        public bool InvExtApplied
        {
            get
            {
                return inv_extapplied;
            }
            set
            {
                inv_extapplied = value;
            }
        }       

        public bool ExtensionLvl1
        {
            get
            {
                return extensionLvl1;
            }
            set
            {
                extensionLvl1 = value;
            }
        }

        public bool ExtensionLvl2
        {
            get
            {
                return extensionLvl2;
            }
            set
            {
                extensionLvl2 = value;
            }
        }
        
        public bool AudFarmRanchers
        {
            get
            {
                return aud_farmranchers;
            }
            set
            {
                aud_farmranchers = value;
            }
        }

        public bool AudEducators
        {
            get
            {
                return aud_educators;
            }
            set
            {
                aud_educators = value;
            }
        }

        public bool AudResearchers
        {
            get
            {
                return aud_researchers;
            }
            set
            {
                aud_researchers = value;
            }
        }

        public bool Audconsumers
        {
            get
            {
                return aud_consumers;
            }
            set
            {
                aud_consumers = value;
            }
        }

        public bool TechlvlBeginner
        {
            get
            {
                return techlvl_beginner;
            }
            set
            {
                techlvl_beginner = value;
            }
        }

        public bool TechlvlIntermediate
        {
            get
            {
                return techlvl_intermediate;
            }
            set
            {
                techlvl_intermediate = value;
            }
        }

        public bool TechlvlAdvanced
        {
            get
            {
                return techlvl_advanced;
            }
            set
            {
                techlvl_advanced = value;
            }
        }

        public String CategoryA
        {
            get
            {
                return categoryA;
            }
            set
            {
                categoryA = value;
            }
        }

        public string CatAother
        {
            get
            {
                return catAother;
            }
            set
            {
                catAother = value;
            }
        }

        public String CategoryB
        {
            get
            {
                return categoryB;
            }
            set
            {
                categoryB = value;
            }
        }

        public string CatBother
        {
            get
            {
                return catBother;
            }
            set
            {
                catBother = value;
            }
        }

        public bool IntgfrsAgroEcoSystemAnalysis
        {
            get
            {
                return intgfrs_AgroecosystemAnalysis;
            }
            set
            {
                intgfrs_AgroecosystemAnalysis = value;
            }
        }

        public bool IntgfrsWholeFarmPlanning
        {
            get
            {
                return intgfrs_WholeFarmPlanning;
            }
            set
            {
                intgfrs_WholeFarmPlanning = value;
            }
        }

        public bool IntgfrsHolisticMgmt
        {
            get
            {
                return intgfrs_HolisticManagement;
            }
            set
            {
                intgfrs_HolisticManagement = value;
            }
        }

        public bool IntgfrsOrgAgri
        {
            get
            {
                return intgfrs_OrganicAgriculture;
            }
            set
            {
                intgfrs_OrganicAgriculture = value;
            }
        }

        public bool IntgfrsPermaCulture
        {
            get
            {
                return intgfrs_Permaculture;
            }
            set
            {
                intgfrs_Permaculture = value;
            }
        }

        public string IntgfrsOther
        {
            get
            {
                return intgfrs_Other;
            }
            set
            {
                intgfrs_Other = value;
            }
        }

        public bool CropprdAgroforesty
        {
            get
            {
                return cropprd_Agroforestry;
            }
            set
            {
                cropprd_Agroforestry = value;
            }
        }

        public bool CropprdNutriCycling
        {
            get
            {
                return cropprd_NutrientCycling;
            }
            set
            {
                cropprd_NutrientCycling = value;
            }
        }

        public bool CropprdBioInoculants
        {
            get
            {
                return cropprd_BiologicalInoculants;
            }
            set
            {
                cropprd_BiologicalInoculants = value;
            }
        }

        public bool CropprdForestry
        {
            get
            {
                return cropprd_Forestry;
            }
            set
            {
                cropprd_Forestry = value;
            }
        }

        public bool CropprdContinousCrop
        {
            get
            {
                return cropprd_ContinuousCropping;
            }
            set
            {
                cropprd_ContinuousCropping = value;
            }
        }

        public bool CropprdCoverCrops
        {
            get
            {
                return cropprd_CoverCrops;
            }
            set
            {
                cropprd_CoverCrops = value;
            }
        }

        public bool CropprdDoubleCropping
        {
            get
            {
                return cropprd_DoubleCropping;
            }
            set
            {
                cropprd_DoubleCropping = value;
            }
        }

        public bool CropprdEarthworms
        {
            get
            {
                return cropprd_Earthworms;
            }
            set
            {
                cropprd_Earthworms = value;
            }
        }

        public bool CropprdFallow
        {
            get
            {
                return cropprd_Fallow;
            }
            set
            {
                cropprd_Fallow = value;
            }
        }

        public bool CropprdFertigation
        {
            get
            {
                return cropprd_Fertigation;
            }
            set
            {
                cropprd_Fertigation = value;
            }
        }

        public bool CropprdFoliarFeeding
        {
            get
            {
                return cropprd_FoliarFeeding;
            }
            set
            {
                cropprd_FoliarFeeding = value;
            }
        }

        public bool CropprdGreenManures
        {
            get
            {
                return cropprd_GreenManures;
            }
            set
            {
                cropprd_GreenManures = value;
            }
        }

        public bool CropprdInterCropping
        {
            get
            {
                return cropprd_Intercropping;
            }
            set
            {
                cropprd_Intercropping = value;
            }
        }

        public bool CropprdMiniTillage
        {
            get
            {
                return cropprd_MinimumTillage;
            }
            set
            {
                cropprd_MinimumTillage = value;
            }
        }

        public bool CropprdMultiCropping
        {
            get
            {
                return cropprd_MultipleCropping;
            }
            set
            {
                cropprd_MultipleCropping = value;
            }
        }

        public bool CropprdMunicipalWastes
        {
            get
            {
                return cropprd_MunicipalWastes;
            }
            set
            {
                cropprd_MunicipalWastes = value;
            }
        }

        public bool CropprdNoTill
        {
            get
            {
                return cropprd_NoTill;
            }
            set
            {
                cropprd_NoTill = value;
            }
        }

        public bool CropprdOrgFertilizers
        {
            get
            {
                return cropprd_OrganicFertilizers;
            }
            set
            {
                cropprd_OrganicFertilizers = value;
            }
        }

        public bool CropprdOrgMatter
        {
            get
            {
                return cropprd_OrganicMatter;
            }
            set
            {
                cropprd_OrganicMatter = value;
            }
        }

        public string CropprdOther
        {
            get
            {
                return cropprd_Other;
            }
            set
            {
                cropprd_Other = value;
            }
        }

        public bool CropprdPermaCulture
        {
            get
            {
                return cropprd_Permaculture;
            }
            set
            {
                cropprd_Permaculture = value;
            }
        }

        public bool CropprdReduceApps
        {
            get
            {
                return cropprd_ReducedApplications;
            }
            set
            {
                cropprd_ReducedApplications = value;
            }
        }

        public bool CropprdRelayCropping
        {
            get
            {
                return cropprd_RelayCropping;
            }
            set
            {
                cropprd_RelayCropping = value;
            }
        }

        public bool CropprdRidgeTillage
        {
            get
            {
                return cropprd_RidgeTillage;
            }
            set
            {
                cropprd_RidgeTillage = value;
            }
        }

        public bool CropprdSoilAnalysis
        {
            get
            {
                return cropprd_SoilAnalysis;
            }
            set
            {
                cropprd_SoilAnalysis = value;
            }
        }

        public bool CropprdStripCropping
        {
            get
            {
                return cropprd_StripCropping;
            }
            set
            {
                cropprd_StripCropping = value;
            }
        }

        public bool CropprdStubbleMulch
        {
            get
            {
                return cropprd_StubbleMulching;
            }
            set
            {
                cropprd_StubbleMulching = value;
            }
        }

        public bool CropprdTissueAnalysis
        {
            get
            {
                return cropprd_TissueAnalysis;
            }
            set
            {
                cropprd_TissueAnalysis = value;
            }
        }

        public bool CropprdTrans
        {
            get
            {
                return cropprd_Transitioning;
            }
            set
            {
                cropprd_Transitioning = value;
            }
        }

        public bool CropprdCatchCrops
        {
            get
            {
                return cropprd_CatchCrops;
            }
            set
            {
                cropprd_CatchCrops = value;
            }
        }

        public bool CropprdCropRotation
        {
            get
            {
                return cropprd_CropRotation;
            }
            set
            {
                cropprd_CropRotation = value;
            }
        }

        public bool CropprdCropBreeding
        {
            get
            {
                return cropprd_CropBreeding;
            }
            set
            {
                cropprd_CropBreeding = value;
            }
        }

        public bool CropprdIrrigation
        {
            get
            {
                return cropprd_Irrigation;
            }
            set
            {
                cropprd_Irrigation = value;
            }
        }

        public bool AnimprdAltFeedstuffs
        {
            get
            {
                return animprd_AlternativeFeedstuffs;
            }
            set
            {
                animprd_AlternativeFeedstuffs = value;
            }
        }

        public bool AnimprdAltHousing
        {
            get
            {
                return animprd_AlternativeHousing;
            }
            set
            {
                animprd_AlternativeHousing = value;
            }
        }

        public bool AnimprdAltParasiteControl
        {
            get
            {
                return animprd_AlternParasiteControl;
            }
            set
            {
                animprd_AlternParasiteControl = value;
            }
        }

        public bool AnimprdAnimalProtection
        {
            get
            {
                return animprd_AnimalProtection;
            }
            set
            {
                animprd_AnimalProtection = value;
            }
        }

        public bool AnimprdComposting
        {
            get
            {
                return animprd_Composting;
            }
            set
            {
                animprd_Composting = value;
            }
        }

        public bool AnimprdContGrazing
        {
            get
            {
                return animprd_ContinuousGrazing;
            }
            set
            {
                animprd_ContinuousGrazing = value;
            }
        }

        public bool AnimprdFeedAdditives
        {
            get
            {
                return animprd_FeedAdditives;
            }
            set
            {
                animprd_FeedAdditives = value;
            }
        }

        public bool AnimprdFeedFormulation
        {
            get
            {
                return animprd_FeedFormulation;
            }
            set
            {
                animprd_FeedFormulation = value;
            }
        }

        public bool AnimprdFeedRations
        {
            get
            {
                return animprd_FeedRations;
            }
            set
            {
                animprd_FeedRations = value;
            }
        }

        public bool AnimprdFreeRange
        {
            get
            {
                return animprd_FreeRange;
            }
            set
            {
                animprd_FreeRange = value;
            }
        }

        public bool AnimprdHerbalMed
        {
            get
            {
                return animprd_HerbalMedicines;
            }
            set
            {
                animprd_HerbalMedicines = value;
            }
        }

        public bool AnimprdHomeopathy
        {
            get
            {
                return animprd_Homeopathy;
            }
            set
            {
                animprd_Homeopathy = value;
            }
        }

        public bool AnimprdImplants
        {
            get
            {
                return animprd_Implants;
            }
            set
            {
                animprd_Implants = value;
            }
        }

        public bool AnimprdInoculants
        {
            get
            {
                return animprd_Inoculants;
            }
            set
            {
                animprd_Inoculants = value;
            }
        }

        public bool AnimprdManureMgmt
        {
            get
            {
                return animprd_ManureManagement;
            }
            set
            {
                animprd_ManureManagement = value;
            }
        }

        public bool AnimprdMineralSupp
        {
            get
            {
                return animprd_MineralSupplements;
            }
            set
            {
                animprd_MineralSupplements = value;
            }
        }

        public bool AnimprdMultiSpeciesGrazing
        {
            get
            {
                return animprd_MultispeciesGrazing;
            }
            set
            {
                animprd_MultispeciesGrazing = value;
            }
        }

        public string AnimprdOther
        {
            get
            {
                return animprd_Other;
            }
            set
            {
                animprd_Other = value;
            }
        }

        public bool AnimprdPastureFerti
        {
            get
            {
                return animprd_PastureFertility;
            }
            set
            {
                animprd_PastureFertility = value;
            }
        }

        public bool AnimprdPastureRenovation
        {
            get
            {
                return animprd_PastureRenovation;
            }
            set
            {
                animprd_PastureRenovation = value;
            }
        }

        public bool AnimprdPreventivePract
        {
            get
            {
                return animprd_PreventivePractices;
            }
            set
            {
                animprd_PreventivePractices = value;
            }
        }

        public bool AnimprdProbiotics
        {
            get
            {
                return animprd_Probiotics;
            }
            set
            {
                animprd_Probiotics = value;
            }
        }

        public bool AnimprdRangeImprovement
        {
            get
            {
                return animprd_RangeImprovement;
            }
            set
            {
                animprd_RangeImprovement = value;
            }
        }

        public bool AnimprdRotGrazing
        {
            get
            {
                return animprd_RotationalGrazing;
            }
            set
            {
                animprd_RotationalGrazing = value;
            }
        }

        public bool AnimprdShadeShelter
        {
            get
            {
                return animprd_ShadeShelter;
            }
            set
            {
                animprd_ShadeShelter = value;
            }
        }

        public bool AnimprdStockpiledForages
        {
            get
            {
                return animprd_StockpiledForages;
            }
            set
            {
                animprd_StockpiledForages = value;
            }
        }

        public bool AnimprdVaccines
        {
            get
            {
                return animprd_Vaccines;
            }
            set
            {
                animprd_Vaccines = value;
            }
        }

        public bool AnimprdWateringSys
        {
            get
            {
                return animprd_WateringSystem;
            }
            set
            {
                animprd_WateringSystem = value;
            }
        }

        public bool AnimprdWinterForage
        {
            get
            {
                return animprd_WinterForage;
            }
            set
            {
                animprd_WinterForage = value;
            }
        }

        public bool AnimprdTherapeutics
        {
            get
            {
                return animprd_Therapeutics;
            }
            set
            {
                animprd_Therapeutics = value;
            }
        }

        public bool AnimprdLivestockBreeding
        {
            get
            {
                return animprd_LivestockBreeding;
            }
            set
            {
                animprd_LivestockBreeding = value;
            }
        }

        public bool AnimprdStockingRate
        {
            get
            {
                return animprd_StockingRate;
            }
            set
            {
                animprd_StockingRate = value;
            }
        }

        public bool AnimprdGrazMgmt
        {
            get
            {
                return animprd_grazingmanagement;
            }
            set
            {
                animprd_grazingmanagement = value;
            }
        }

        public bool PestMgmtAllelopathy
        {
            get
            {
                return pestmgt_Allelopathy;
            }
            set
            {
                pestmgt_Allelopathy = value;
            }
        }

        public bool PestMgmtBioControl
        {
            get
            {
                return pestmgt_BiologicalControl;
            }
            set
            {
                pestmgt_BiologicalControl = value;
            }
        }

        public bool PestMgmtBioPest
        {
            get
            {
                return pestmgt_BiorationalPesticides;
            }
            set
            {
                pestmgt_BiorationalPesticides = value;
            }
        }

        public bool PestMgmtBotaPest
        {
            get
            {
                return pestmgt_BotanicalPesticides;
            }
            set
            {
                pestmgt_BotanicalPesticides = value;
            }
        }

        public bool PestMgmtChemControl
        {
            get
            {
                return pestmgt_ChemicalControl;
            }
            set
            {
                pestmgt_ChemicalControl = value;
            }
        }

        public bool PestMgmtCompetition
        {
            get
            {
                return pestmgt_Competition;
            }
            set
            {
                pestmgt_Competition = value;
            }
        }

        public bool PestMgmtCompostExtracts
        {
            get
            {
                return pestmgt_CompostExtracts;
            }
            set
            {
                pestmgt_CompostExtracts = value;
            }
        }

        public bool PestMgmtCulturalControl
        {
            get
            {
                return pestmgt_CulturalControl;
            }
            set
            {
                pestmgt_CulturalControl = value;
            }
        }

        public bool PestMgmtDiseaseVectors
        {
            get
            {
                return pestmgt_DiseaseVectors;
            }
            set
            {
                pestmgt_DiseaseVectors = value;
            }
        }

        public bool PestMgmtEcoThreshold
        {
            get
            {
                return pestmgt_EconomicThreshold;
            }
            set
            {
                pestmgt_EconomicThreshold = value;
            }
        }

        public bool PestMgmtEradication
        {
            get
            {
                return pestmgt_Eradication;
            }
            set
            {
                pestmgt_Eradication = value;
            }
        }

        public bool PestMgmtFieldMonitoring
        {
            get
            {
                return pestmgt_FieldMonitoring;
            }
            set
            {
                pestmgt_FieldMonitoring = value;
            }
        }

        public bool PestMgmtFlame
        {
            get
            {
                return pestmgt_Flame;
            }
            set
            {
                pestmgt_Flame = value;
            }
        }

        public bool PestMgmtGeneticResis
        {
            get
            {
                return pestmgt_GeneticResistance;
            }
            set
            {
                pestmgt_GeneticResistance = value;
            }
        }

        public bool PestMgmtIPM
        {
            get
            {
                return pestmgt_IPM;
            }
            set
            {
                pestmgt_IPM = value;
            }
        }

        public bool PestMgmtKilledMulches
        {
            get
            {
                return pestmgt_KilledMulches;
            }
            set
            {
                pestmgt_KilledMulches = value;
            }
        }

        public bool PestMgmtLivingMulches
        {
            get
            {
                return pestmgt_LivingMulches;
            }
            set
            {
                pestmgt_LivingMulches = value;
            }
        }

        public bool PestMgmtMatingDisruption
        {
            get
            {
                return pestmgt_MatingDisruption;
            }
            set
            {
                pestmgt_MatingDisruption = value;
            }
        }

        public bool PestMgmtMechControl
        {
            get
            {
                return pestmgt_MechanicalControl;
            }
            set
            {
                pestmgt_MechanicalControl = value;
            }
        }

        public string PestMgmtOther
        {
            get
            {
                return pestmgt_Other;
            }
            set
            {
                pestmgt_Other = value;
            }
        }

        public bool PestMgmtPhyControl
        {
            get
            {
                return pestmgt_PhysicalControl;
            }
            set
            {
                pestmgt_PhysicalControl = value;
            }
        }

        public bool PestMgmtPlasticMulch
        {
            get
            {
                return pestmgt_PlasticMulching;
            }
            set
            {
                pestmgt_PlasticMulching = value;
            }
        }

        public bool PestMgmtPrecisiCulti
        {
            get
            {
                return pestmgt_PrecisionCultivation;
            }
            set
            {
                pestmgt_PrecisionCultivation = value;
            }
        }

        public bool PestMgmtPrecisiHerbicideUse
        {
            get
            {
                return pestmgt_PrecisionHerbicideUse;
            }
            set
            {
                pestmgt_PrecisionHerbicideUse = value;
            }
        }

        public bool PestMgmtPrevention
        {
            get
            {
                return pestmgt_Prevention;
            }
            set
            {
                pestmgt_Prevention = value;
            }
        }

        public bool PestMgmtRowCovers
        {
            get
            {
                return pestmgt_RowCovers;
            }
            set
            {
                pestmgt_RowCovers = value;
            }
        }

        public bool PestMgmtSanitation
        {
            get
            {
                return pestmgt_Sanitation;
            }
            set
            {
                pestmgt_Sanitation = value;
            }
        }

        public bool PestMgmtSmotherCrops
        {
            get
            {
                return pestmgt_SmotherCrops;
            }
            set
            {
                pestmgt_SmotherCrops = value;
            }
        }

        public bool PestMgmtSoilSolar
        {
            get
            {
                return pestmgt_SoilSolarization;
            }
            set
            {
                pestmgt_SoilSolarization = value;
            }
        }

        public bool PestMgmtTrapCrops
        {
            get
            {
                return pestmgt_TrapCrops;
            }
            set
            {
                pestmgt_TrapCrops = value;
            }
        }

        public bool PestMgmtTraps
        {
            get
            {
                return pestmgt_Traps;
            }
            set
            {
                pestmgt_Traps = value;
            }
        }

        public bool PestMgmtVegMulch
        {
            get
            {
                return pestmgt_VegetativeMulching;
            }
            set
            {
                pestmgt_VegetativeMulching = value;
            }
        }

        public bool PestMgmtWeatherMoni
        {
            get
            {
                return pestmgt_WeatherMonitoring;
            }
            set
            {
                pestmgt_WeatherMonitoring = value;
            }
        }

        public bool PestMgmtWeedEco
        {
            get
            {
                return pestmgt_WeedEcology;
            }
            set
            {
                pestmgt_WeedEcology = value;
            }
        }

        public bool PestMgmtWeedGeese
        {
            get
            {
                return pestmgt_WeederGeese;
            }
            set
            {
                pestmgt_WeederGeese = value;
            }
        }

        public bool SoilMgmtNutriMineralization
        {
            get
            {
                return soilmgt_NutrientMineralization;
            }
            set
            {
                soilmgt_NutrientMineralization = value;
            }
        }

        public bool SoilMgmtSoilMicroBio
        {
            get
            {
                return soilmgt_SoilMicrobiology;
            }
            set
            {
                soilmgt_SoilMicrobiology = value;
            }
        }

        public bool SoilMgmtOrgtMatter
        {
            get
            {
                return soilmgt_SoilOrganicMatter;
            }
            set
            {
                soilmgt_SoilOrganicMatter = value;
            }
        }

        public bool SoilMgmtQty
        {
            get
            {
                return soilmgt_SoilQuality;
            }
            set
            {
                soilmgt_SoilQuality = value;
            }
        }
        
        public bool SoilMgmtCarbonSequestration
        {
            get
            {
                return soilmgt_CarbonSequestration;
            }
            set
            {
                soilmgt_CarbonSequestration = value;
            }
        }        

        public bool SoilMgmtSoilChem
        {
            get
            {
                return soilmgt_SoilChemistry;
            }
            set
            {
                soilmgt_SoilChemistry = value;
            }
        }

        public bool SoilMgmtSoilPhy
        {
            get
            {
                return soilmgt_SoilPhysics;
            }
            set
            {
                soilmgt_SoilPhysics = value;
            }
        }

        public string SoilMgmtOther
        {
            get
            {
                return soilmgt_Other;
            }
            set
            {
                soilmgt_Other = value;
            }
        }

        public bool NResEnvAfforestation
        {
            get
            {
                return nresenv_Afforestation;
            }
            set
            {
                nresenv_Afforestation = value;
            }
        }

        public bool NResEnvBiodiver
        {
            get
            {
                return nresenv_Biodiversity;
            }
            set
            {
                nresenv_Biodiversity = value;
            }
        }

        public bool NResEnvBiosphere
        {
            get
            {
                return nresenv_Biosphere;
            }
            set
            {
                nresenv_Biosphere = value;
            }
        }

        public bool NResEnvConserTillage
        {
            get
            {
                return nresenv_ConservationTillage;
            }
            set
            {
                nresenv_ConservationTillage = value;
            }
        }

        public bool NResEnvContourCulti
        {
            get
            {
                return nresenv_ContourCultivation;
            }
            set
            {
                nresenv_ContourCultivation = value;
            }
        }

        public bool NResEnvGrassHedges
        {
            get
            {
                return nresenv_GrassHedges;
            }
            set
            {
                nresenv_GrassHedges = value;
            }
        }

        public bool NResEnvGrassWaterWays
        {
            get
            {
                return nresenv_GrassWaterways;
            }
            set
            {
                nresenv_GrassWaterways = value;
            }
        }

        public bool NResEnvHabitatEnhance
        {
            get
            {
                return nresenv_HabitatEnhancement;
            }
            set
            {
                nresenv_HabitatEnhancement = value;
            }
        }

        public bool NResEnvHedgerows
        {
            get
            {
                return nresenv_Hedgerows;
            }
            set
            {
                nresenv_Hedgerows = value;
            }
        }

        public bool NResEnvIndi
        {
            get
            {
                return nresenv_Indicators;
            }
            set
            {
                nresenv_Indicators = value;
            }
        }

        public string NResEnvOther
        {
            get
            {
                return nresenv_Other;
            }
            set
            {
                nresenv_Other = value;
            }
        }

        public bool NResEnvRiparianPlantings
        {
            get
            {
                return nresenv_RiparianPlantings;
            }
            set
            {
                nresenv_RiparianPlantings = value;
            }
        }

        public bool NResEnvRiverBnkProtect
        {
            get
            {
                return nresenv_RiverbankProtection;
            }
            set
            {
                nresenv_RiverbankProtection = value;
            }
        }

        public bool NResEnvSoilStabilization
        {
            get
            {
                return nresenv_SoilStabilization;
            }
            set
            {
                nresenv_SoilStabilization = value;
            }
        }

        public bool NResEnvTerraces
        {
            get
            {
                return nresenv_Terraces;
            }
            set
            {
                nresenv_Terraces = value;
            }
        }

        public bool NResEnvWetlands
        {
            get
            {
                return nresenv_Wetlands;
            }
            set
            {
                nresenv_Wetlands = value;
            }
        }

        public bool NResEnvWildlife
        {
            get
            {
                return nresenv_Wildlife;
            }
            set
            {
                nresenv_Wildlife = value;
            }
        }

        public bool NResEnvWindbreaks
        {
            get
            {
                return nresenv_Windbreaks;
            }
            set
            {
                nresenv_Windbreaks = value;
            }
        }

        public bool NResEnvWoodyHedges
        {
            get
            {
                return nresenv_WoodyHedges;
            }
            set
            {
                nresenv_WoodyHedges = value;
            }
        }

        public bool EdTrainCaseStudy
        {
            get
            {
                return edtrain_CaseStudy;
            }
            set
            {
                edtrain_CaseStudy = value;
            }
        }

        public bool EdTrainConference
        {
            get
            {
                return edtrain_Conference;
            }
            set
            {
                edtrain_Conference = value;
            }
        }

        public bool EdTrainCurriculum
        {
            get
            {
                return edtrain_Curriculum;
            }
            set
            {
                edtrain_Curriculum = value;
            }
        }

        public bool EdTrainDB
        {
            get
            {
                return edtrain_Database;
            }
            set
            {
                edtrain_Database = value;
            }
        }

        public bool EdTrainDecisionSupportSys
        {
            get
            {
                return edtrain_DecisionSupportSystem;
            }
            set
            {
                edtrain_DecisionSupportSystem = value;
            }
        }

        public bool EdTrainDemo
        {
            get
            {
                return edtrain_Demonstration;
            }
            set
            {
                edtrain_Demonstration = value;
            }
        }

        public bool EdTrainDisplay
        {
            get
            {
                return edtrain_Display;
            }
            set
            {
                edtrain_Display = value;
            }
        }

        public bool EdTrainExt
        {
            get
            {
                return edtrain_Extension;
            }
            set
            {
                edtrain_Extension = value;
            }
        }

        public bool EdTrainFactSheet
        {
            get
            {
                return edtrain_FactSheet;
            }
            set
            {
                edtrain_FactSheet = value;
            }
        }

        public bool EdTrainFarmerToFarmer
        {
            get
            {
                return edtrain_FarmerToFarmer;
            }
            set
            {
                edtrain_FarmerToFarmer = value;
            }
        }

        public bool EdTrainFocusGroup
        {
            get
            {
                return edtrain_FocusGroup;
            }
            set
            {
                edtrain_FocusGroup = value;
            }
        }

        public bool EdTrainMentor
        {
            get
            {
                return edtrain_Mentor;
            }
            set
            {
                edtrain_Mentor = value;
            }
        }

        public bool EdTrainNet
        {
            get
            {
                return edtrain_Network;
            }
            set
            {
                edtrain_Network = value;
            }
        }

        public bool EdTrainOnFarmResearch
        {
            get
            {
                return edtrain_OnFarmResearch;
            }
            set
            {
                edtrain_OnFarmResearch = value;
            }
        }

        public bool EdTrainParticipatoryResearch
        {
            get
            {
                return edtrain_ParticipatoryResearch;
            }
            set
            {
                edtrain_ParticipatoryResearch = value;
            }
        }

        public bool EdTrainStudyCircle
        {
            get
            {
                return edtrain_StudyCircle;
            }
            set
            {
                edtrain_StudyCircle = value;
            }
        }

        public bool EdTrainWorkshop
        {
            get
            {
                return edtrain_Workshop;
            }
            set
            {
                edtrain_Workshop = value;
            }
        }

        public bool EdTrainYouthEdu
        {
            get
            {
                return edtrain_YouthEducation;
            }
            set
            {
                edtrain_YouthEducation = value;
            }
        }

        public string EdTrainOther
        {
            get
            {
                return edtrain_Other;
            }
            set
            {
                edtrain_Other = value;
            }
        }

        public bool EconMktAltEnt
        {
            get
            {
                return econmkt_AlternativeEnterprise;
            }
            set
            {
                econmkt_AlternativeEnterprise = value;
            }
        }

        public bool EconMktBudget
        {
            get
            {
                return econmkt_Budget;
            }
            set
            {
                econmkt_Budget = value;
            }
        }

        public bool EconMktCoop
        {
            get
            {
                return econmkt_Cooperatives;
            }
            set
            {
                econmkt_Cooperatives = value;
            }
        }

        public bool EconMktCostNReturns
        {
            get
            {
                return econmkt_CostAndReturns;
            }
            set
            {
                econmkt_CostAndReturns = value;
            }
        }

        public bool EconMktCSA
        {
            get
            {
                return econmkt_CSA;
            }
            set
            {
                econmkt_CSA = value;
            }
        }

        public bool EconMktDirectMkt
        {
            get
            {
                return econmkt_DirectMarketing;
            }
            set
            {
                econmkt_DirectMarketing = value;
            }
        }

        public bool EconMktFeasibilityStudy
        {
            get
            {
                return econmkt_FeasibilityStudy;
            }
            set
            {
                econmkt_FeasibilityStudy = value;
            }
        }

        public bool EconMktFinAnalysis
        {
            get
            {
                return econmkt_FinancialAnalysis;
            }
            set
            {
                econmkt_FinancialAnalysis = value;
            }
        }

        public bool EconMktMarketStudy
        {
            get
            {
                return econmkt_MarketStudy;
            }
            set
            {
                econmkt_MarketStudy = value;
            }
        }

        public bool EconMktRiskMgmt
        {
            get
            {
                return econmkt_RiskManagement;
            }
            set
            {
                econmkt_RiskManagement = value;
            }
        }

        public bool EconMktValueAdd
        {
            get
            {
                return econmkt_ValueAdded;
            }
            set
            {
                econmkt_ValueAdded = value;
            }
        }

        public bool EconMktFoodProductQtySafety
        {
            get
            {
                return econmkt_FoodProductQualitySafety;
            }
            set
            {
                econmkt_FoodProductQualitySafety = value;
            }
        }

        public bool EconMktLaborEmp
        {
            get
            {
                return econmkt_LaborEmployment;
            }
            set
            {
                econmkt_LaborEmployment = value;
            }
        }

        public bool EconMktECom
        {
            get
            {
                return econmkt_Ecommerce;
            }
            set
            {
                econmkt_Ecommerce = value;
            }
        }

        public bool EconMktFarmToInstitution
        {
            get
            {
                return econmkt_FarmToInstitution;
            }
            set
            {
                econmkt_FarmToInstitution = value;
            }
        }
        
        public string EconMktOther
        {
            get
            {
                return econmkt_Other;
            }
            set
            {
                econmkt_Other = value;
            }
        }

        public bool CommDevInfraAnalysis
        {
            get
            {
                return commdev_InfrastructureAnalysis;
            }
            set
            {
                commdev_InfrastructureAnalysis = value;
            }
        }

        public bool CommDevNewBusOpp
        {
            get
            {
                return commdev_NewBusinessOpportunities;
            }
            set
            {
                commdev_NewBusinessOpportunities = value;
            }
        }

        public bool CommDevPartner
        {
            get
            {
                return commdev_Partnerships;
            }
            set
            {
                commdev_Partnerships = value;
            }
        }

        public bool CommDevPubPart
        {
            get
            {
                return commdev_PublicParticipation;
            }
            set
            {
                commdev_PublicParticipation = value;
            }
        }

        public bool CommDevTechAssist
        {
            get
            {
                return commdev_TechnicalAssistance;
            }
            set
            {
                commdev_TechnicalAssistance = value;
            }
        }

        public bool CommDevUrbanAgri
        {
            get
            {
                return commdev_UrbanAgriculture;
            }
            set
            {
                commdev_UrbanAgriculture = value;
            }
        }

        public bool CommDevUrbanRuralInt
        {
            get
            {
                return commdev_UrbanRuralIntegration;
            }
            set
            {
                commdev_UrbanRuralIntegration = value;
            }
        }

        public bool CommDevLocalRegionalCommunityFoodSys
        {
            get
            {
                return commdev_LocalRegionalCommunityFoodSystems;
            }
            set
            { 
                 commdev_LocalRegionalCommunityFoodSystems = value;
            }
        }
        
        public bool CommDevAgritourism
        {
            get
            {
                return commdev_Agritourism;
            }
            set
            {
                commdev_Agritourism = value;
            }
        }

        public bool CommDevCommunityPlanning
        {
            get
            {
                return commdev_CommunityPlanning;
            }
            set
            {
                commdev_CommunityPlanning = value;
            }

        }
        public bool CommDevPublicPolicy
        {
            get
            {
                return commdev_PublicPolicy;
            }
            set
            {
                commdev_PublicPolicy = value;
            }

        }

        public bool CommDevLeadershipDev
        {
            get
            {
                return commdev_LeadershipDevelopment;
            }
            set
            {
                commdev_LeadershipDevelopment = value;
            }

        }

        public bool CommDevEthnicDiffCulturDemoChange
        {
            get
            {
                return commdev_EthnicDifferencesCulturalDemographicChange;
            }
            set
            {
                commdev_EthnicDifferencesCulturalDemographicChange = value;
            }

        }

        public string CommDevOther
        {
            get
            {
                return commdev_Other;
            }
            set
            {
                commdev_Other = value;
            }
        }

        public bool QofLifeAnalysisOfPersonalFamilyLife
        {
            get
            {
                return qoflife_AnalysisOfPersonalFamilyLife;
            }
            set
            {
                qoflife_AnalysisOfPersonalFamilyLife = value;
            }
        }

        public bool QofLifeCommunitySrv
        {
            get
            {
                return qoflife_CommunityServices;
            }
            set
            {
                qoflife_CommunityServices = value;
            }
        }

        public bool QofLifeEmpOpp
        {
            get
            {
                return qoflife_EmploymentOpportunities;
            }
            set
            {
                qoflife_EmploymentOpportunities = value;
            }
        }

        public bool QofLifeSocialCap
        {
            get
            {
                return qoflife_SocialCapitol;
            }
            set
            {
                qoflife_SocialCapitol = value;
            }
        }

        public bool QofLifeSocialNet
        {
            get
            {
                return qoflife_SocialNetworks;
            }
            set
            {
                qoflife_SocialNetworks = value;
            }
        }

        public bool QofLifeSocialPsyInd
        {
            get
            {
                return qoflife_SocialPsychologicalIndicators;
            }
            set
            {
                qoflife_SocialPsychologicalIndicators = value;
            }
        }

        public bool QofLifeSustainMeasures
        {
            get
            {
                return qoflife_SustainabilityMeasures;
            }
            set
            {
                qoflife_SustainabilityMeasures = value;
            }
        }

        public string QofLifeOther
        {
            get
            {
                return qoflife_Other;
            }
            set
            {
                qoflife_Other = value;
            }
        }

        public bool EngBioEngFuels
        {
            get
            {
                return energy_BioenergyBiofuels;
            }
            set
            {
                energy_BioenergyBiofuels = value;
            }
        }

        public bool EngEngConservEff
        {
            get
            {
                return energy_EnergyConservationEfficiency;
            }
            set
            {
                energy_EnergyConservationEfficiency = value;
            }
        }

        public bool EngEngUseConsumption
        {
            get
            {
                return energy_EnergyUseConsumption;
            }
            set
            {
                energy_EnergyUseConsumption = value;
            }
        }

        public bool EngSolarEng
        {
            get
            {
                return energy_SolarEnergy;
            }
            set
            {
                energy_SolarEnergy = value;
            }
        }

        public bool EngWindPower
        {
            get
            {
                return energy_WindPower;
            }
            set
            {
                energy_WindPower = value;
            }
        }

        public string EngOther
        {
            get
            {
                return energy_Other;
            }
            set
            {
                energy_Other = value;
            }
        }

        public bool CommPlAgrBarley
        {
            get
            {
                return commPlAgr_Barley;
            }
            set
            {
                commPlAgr_Barley = value;
            }
        }

        public bool CommPlAgrCanola
        {
            get
            {
                return commPlAgr_Canola;
            }
            set
            {
                commPlAgr_Canola = value;
            }
        }

        public bool CommPlAgrCorn
        {
            get
            {
                return commPlAgr_Corn;
            }
            set
            {
                commPlAgr_Corn = value;
            }
        }

        public bool CommPlAgrCotton
        {
            get
            {
                return commPlAgr_Cotton;
            }
            set
            {
                commPlAgr_Cotton = value;
            }
        }

        public bool CommPlAgrFlax
        {
            get
            {
                return commPlAgr_Flax;
            }
            set
            {
                commPlAgr_Flax = value;
            }
        }

        public bool CommPlAgrGrassHay
        {
            get
            {
                return commPlAgr_GrassHay;
            }
            set
            {
                commPlAgr_GrassHay = value;
            }
        }

        public bool CommPlAgrGrassLegHay
        {
            get
            {
                return commPlAgr_GrassLegumeHay;
            }
            set
            {
                commPlAgr_GrassLegumeHay = value;
            }
        }

        public bool CommPlAgrHops
        {
            get
            {
                return commPlAgr_Hops;
            }
            set
            {
                commPlAgr_Hops = value;
            }
        }

        public bool CommPlAgrKenaf
        {
            get
            {
                return commPlAgr_Kenaf;
            }
            set
            {
                commPlAgr_Kenaf = value;
            }
        }

        public bool CommPlAgrLegHay
        {
            get
            {
                return commPlAgr_LegumeHay;
            }
            set
            {
                commPlAgr_LegumeHay = value;
            }
        }

        public bool CommPlAgrMillet
        {
            get
            {
                return commPlAgr_Millet;
            }
            set
            {
                commPlAgr_Millet = value;
            }
        }

        public bool CommPlAgrOats
        {
            get
            {
                return commPlAgr_Oats;
            }
            set
            {
                commPlAgr_Oats = value;
            }
        }

        public string CommPlAgrOther
        {
            get
            {
                return commPlAgr_Other;
            }
            set
            {
                commPlAgr_Other = value;
            }
        }

        public bool CommPlAgrPeanuts
        {
            get
            {
                return commPlAgr_Peanuts;
            }
            set
            {
                commPlAgr_Peanuts = value;
            }
        }

        public bool CommPlAgrPotatoes
        {
            get
            {
                return commPlAgr_Potatoes;
            }
            set
            {
                commPlAgr_Potatoes = value;
            }
        }

        public bool CommPlAgrRapeseed
        {
            get
            {
                return commPlAgr_Rapeseed;
            }
            set
            {
                commPlAgr_Rapeseed = value;
            }
        }

        public bool CommPlAgrRice
        {
            get
            {
                return commPlAgr_Rice;
            }
            set
            {
                commPlAgr_Rice = value;
            }
        }

        public bool CommPlAgrRye
        {
            get
            {
                return commPlAgr_Rye;
            }
            set
            {
                commPlAgr_Rye = value;
            }
        }

        public bool CommPlAgrSafflower
        {
            get
            {
                return commPlAgr_Safflower;
            }
            set
            {
                commPlAgr_Safflower = value;
            }
        }

        public bool CommPlAgrSorghum
        {
            get
            {
                return commPlAgr_Sorghum;

            }
            set
            {
                commPlAgr_Sorghum = value;
            }
        }

        public bool CommPlAgrSoybeans
        {
            get
            {
                return commPlAgr_Soybeans;
            }
            set
            {
                commPlAgr_Soybeans = value;
            }
        }

        public bool CommPlAgrSpelt
        {
            get
            {
                return commPlAgr_Spelt;
            }
            set
            {
                commPlAgr_Spelt = value;
            }
        }

        public bool CommPlAgrSugarbeets
        {
            get
            {
                return commPlAgr_Sugarbeets;
            }
            set
            {
                commPlAgr_Sugarbeets = value;
            }
        }

        public bool CommPlAgrSugarcane
        {
            get
            {
                return commPlAgr_Sugarcane;
            }
            set
            {
                commPlAgr_Sugarcane = value;
            }
        }

        public bool CommPlAgrSunflower
        {
            get
            {
                return commPlAgr_Sunflower;
            }
            set
            {
                commPlAgr_Sunflower = value;
            }
        }

        public bool CommPlAgrSweetpotatoes
        {
            get
            {
                return commPlAgr_Sweetpotatoes;
            }
            set
            {
                commPlAgr_Sweetpotatoes = value;
            }
        }

        public bool CommPlAgrTobacco
        {
            get
            {
                return commPlAgr_Tobacco;
            }
            set
            {
                commPlAgr_Tobacco = value;
            }
        }

        public bool CommPlAgrWheat
        {
            get
            {
                return commPlAgr_Wheat;
            }
            set
            {
                commPlAgr_Wheat = value;
            }
        }

        public bool CommPlNutsAlmonds
        {
            get
            {
                return commPlNuts_Almonds;
            }
            set
            {
                commPlNuts_Almonds = value;
            }
        }

        public bool CommPlNutsHazel
        {
            get
            {
                return commPlNuts_Hazelnuts;
            }
            set
            {
                commPlNuts_Hazelnuts = value;
            }
        }

        public bool CommPlNutsPecans
        {
            get
            {
                return commPlNuts_Pecans;
            }
            set
            {
                commPlNuts_Pecans = value;
            }
        }

        public bool CommPlNutsWalnuts
        {
            get
            {
                return commPlNuts_Walnuts;
            }
            set
            {
                commPlNuts_Walnuts = value;
            }
        }
        
        public bool CommPlNutsChestnuts
        {
            get
            {
                return commplnuts_chestnuts;
            }
            set
            {
                commplnuts_chestnuts = value;
            }
        }

        public bool CommPlNutsMacadamia
        {
            get
            {
                return commPlNuts_Macadamia;
            }
            set
            {
                commPlNuts_Macadamia = value;
            }
        }

        public bool CommPlNutsPistachios
        {
            get
            {
                return commPlNuts_Pistachios;
            }
            set
            {
                commPlNuts_Pistachios = value;
            }
        }

        public string CommPlNutsOther
        {
            get
            {
                return commPlNuts_Other;
            }
            set
            {
                commPlNuts_Other = value;
            }
        }

        public bool CommPlAddHerbs
        {
            get
            {
                return commPlAdd_Herbs;
            }
            set
            {
                commPlAdd_Herbs = value;
            }
        }

        public bool CommPlAddMushrooms
        {
            get
            {
                return commPlAdd_Mushrooms;
            }
            set
            {
                commPlAdd_Mushrooms = value;
            }
        }

        public bool CommPlAddNativePlants
        {
            get
            {
                return commPlAdd_NativePlants;
            }
            set
            {
                commPlAdd_NativePlants = value;
            }
        }

        public bool CommPlAddOrnamentals
        {
            get
            {
                return commPlAdd_Ornamentals;
            }
            set
            {
                commPlAdd_Ornamentals = value;
            }
        }

        public bool CommPlAddTrees
        {
            get
            {
                return commPlAdd_Trees;
            }
            set
            {
                commPlAdd_Trees = value;
            }
        }

        public string CommPlAddOther
        {
            get
            {
                return commPlAdd_Other;
            }
            set
            {
                commPlAdd_Other = value;
            }
        }

        public bool CommAnimBeef
        {
            get
            {
                return commAnim_Beef;
            }
            set
            {
                commAnim_Beef = value;
            }
        }

        public bool CommAnimChicken
        {
            get
            {
                return commAnim_Chicken;
            }
            set
            {
                commAnim_Chicken = value;
            }
        }

        public bool CommAnimDairy
        {
            get
            {
                return commAnim_Dairy;
            }
            set
            {
                commAnim_Dairy = value;
            }
        }

        public bool CommAnimGoats
        {
            get
            {
                return commAnim_Goats;
            }
            set
            {
                commAnim_Goats = value;
            }
        }

        public bool CommAnimRabbits
        {
            get
            {
                return commAnim_Rabbits;
            }
            set
            {
                commAnim_Rabbits = value;
            }
        }

        public bool CommAnimSheep
        {
            get
            {
                return commAnim_Sheep;
            }
            set
            {
                commAnim_Sheep = value;
            }
        }

        public bool CommAnimSwine
        {
            get
            {
                return commAnim_Swine;
            }
            set
            {
                commAnim_Swine = value;
            }
        }

        public bool CommAnimTurkeys
        {
            get
            {
                return commAnim_Turkeys;
            }
            set
            {
                commAnim_Turkeys = value;
            }
        }

        public string CommAnimOther
        {
            get
            {
                return commAnim_Other;
            }
            set
            {
                commAnim_Other = value;
            }
        }

        public bool CommMiscBees
        {
            get
            {
                return commMisc_Bees;
            }
            set
            {
                commMisc_Bees = value;
            }
        }

        public bool CommMiscFish
        {
            get
            {
                return commMisc_Fish;
            }
            set
            {
                commMisc_Fish = value;
            }
        }

        public bool CommMiscRatites
        {
            get
            {
                return commMisc_Ratites;
            }
            set
            {
                commMisc_Ratites = value;
            }
        }

        public bool CommMiscShellfish
        {
            get
            {
                return commMisc_Shellfish;
            }
            set
            {
                commMisc_Shellfish = value;
            }
        }

        public string CommMiscOther
        {
            get
            {
                return commMisc_Other;
            }
            set
            {
                commMisc_Other = value;
            }
        }

        public bool CommPlVegArtichokes
        {
            get
            {
                return commPlVeg_Artichokes;
            }
            set
            {
                commPlVeg_Artichokes = value;
            }
        }

        public bool CommPlVegAsparagus
        {
            get
            {
                return commPlVeg_Asparagus;
            }
            set
            {
                commPlVeg_Asparagus = value;
            }
        }

        public bool CommPlVegBeans
        {
            get
            {
                return commPlVeg_Beans;
            }
            set
            {
                commPlVeg_Beans = value;
            }
        }

        public bool CommPlVegBeets
        {
            get
            {
                return commPlVeg_Beets;
            }
            set
            {
                commPlVeg_Beets = value;
            }
        }

        public bool CommPlVegBroccoli
        {
            get
            {
                return commPlVeg_Broccoli;
            }
            set
            {
                commPlVeg_Broccoli = value;
            }
        }

        public bool CommPlVegBrusselSprouts
        {
            get
            {
                return commPlVeg_BrusselSprouts;
            }
            set
            {
                commPlVeg_BrusselSprouts = value;
            }
        }

        public bool CommPlVegCabbage
        {
            get
            {
                return commPlVeg_Cabbage;
            }
            set
            {
                commPlVeg_Cabbage = value;
            }
        }

        public bool CommPlVegCarrots
        {
            get
            {
                return commPlVeg_Carrots;
            }
            set
            {
                commPlVeg_Carrots = value;
            }
        }

        public bool CommPlVegCauliflower
        {
            get
            {
                return commPlVeg_Cauliflower;
            }
            set
            {
                commPlVeg_Cauliflower = value;
            }
        }

        public bool CommPlVegCelery
        {
            get
            {
                return commPlVeg_Celery;
            }
            set
            {
                commPlVeg_Celery = value;
            }
        }

        public bool CommPlVegCucumbers
        {
            get
            {
                return commPlVeg_Cucumbers;
            }
            set
            {
                commPlVeg_Cucumbers = value;
            }
        }

        public bool CommPlVegEggplant
        {
            get
            {
                return commPlVeg_Eggplant;
            }
            set
            {
                commPlVeg_Eggplant = value;
            }
        }

        public bool CommPlVegEscarole
        {
            get
            {
                return commPlVeg_Escarole;
            }
            set
            {
                commPlVeg_Escarole = value;
            }
        }

        public bool CommPlVegGarlic
        {
            get
            {
                return commPlVeg_Garlic;
            }
            set
            {
                commPlVeg_Garlic = value;
            }
        }

        public bool CommPlVegGreens
        {
            get
            {
                return commPlVeg_Greens;
            }
            set
            {
                commPlVeg_Greens = value;
            }
        }

        public bool CommPlVegKale
        {
            get
            {
                return commPlVeg_Kale;
            }
            set
            {
                commPlVeg_Kale = value;
            }
        }

        public bool CommPlVegLentils
        {
            get
            {
                return commPlVeg_Lentils;
            }
            set
            {
                commPlVeg_Lentils = value;
            }
        }

        public bool CommPlVegLettuce
        {
            get
            {
                return commPlVeg_Lettuce;
            }
            set
            {
                commPlVeg_Lettuce = value;
            }
        }

        public bool CommPlVegOnions
        {
            get
            {
                return commPlVeg_Onions;
            }
            set
            {
                commPlVeg_Onions = value;
            }
        }

        public string CommPlVegOther
        {
            get
            {
                return commPlVeg_Other;
            }
            set
            {
                commPlVeg_Other = value;
            }
        }

        public bool CommPlVegParsnips
        {
            get
            {
                return commPlVeg_Parsnips;
            }
            set
            {
                commPlVeg_Parsnips = value;
            }
        }

        public bool CommPlVegPeas
        {
            get
            {
                return commPlVeg_Peas;
            }
            set
            {
                commPlVeg_Peas = value;
            }
        }

        public bool CommPlVegPeppers
        {
            get
            {
                return commPlVeg_Peppers;
            }
            set
            {
                commPlVeg_Peppers = value;
            }
        }

        public bool CommPlVegRutabagas
        {
            get
            {
                return commPlVeg_Rutabagas;
            }
            set
            {
                commPlVeg_Rutabagas = value;
            }
        }

        public bool CommPlVegSpinach
        {
            get
            {
                return commPlVeg_Spinach;
            }
            set
            {
                commPlVeg_Spinach = value;
            }
        }
        
        public bool CommPlVegLeeks
        {
            get
            {
                return commplveg_leeks;
            }
            set
            {
                commplveg_leeks = value;
            }
        }

        public bool CommPlVegPumpkins
        {
            get
            {
                return commPlVeg_Pumpkins;
            }
            set
            {
                commPlVeg_Pumpkins = value;
            }
        }
        public bool CommPlVegSquashes
        {
            get
            {
                return commPlVeg_Squashes;
            }
            set
            {
                commPlVeg_Squashes = value;
            }
        }
        public bool CommPlVegRadishes
        {
            get
            {
                return commPlVeg_Radishes;
            }
            set
            {
                commPlVeg_Radishes = value;
            }
        }
        
        public bool CommPlVegSweetCorn
        {
            get
            {
                return commPlVeg_SweetCorn;
            }
            set
            {
                commPlVeg_SweetCorn = value;
            }
        }

        public bool CommPlVegTomatoes
        {
            get
            {
                return commPlVeg_Tomatoes;
            }
            set
            {
                commPlVeg_Tomatoes = value;
            }
        }

        public bool CommPlVegTurnips
        {
            get
            {
                return commPlVeg_Turnips;
            }
            set
            {
                commPlVeg_Turnips = value;
            }
        }

        public bool CommPlVegWatermelon
        {
            get
            {
                return commPlVeg_Watermelon;
            }
            set
            {
                commPlVeg_Watermelon = value;
            }
        }

        public bool CommPlFruitApples
        {
            get
            {
                return commPlFruit_Apples;
            }
            set
            {
                commPlFruit_Apples = value;
            }
        }

        public bool CommPlFruitApricots
        {
            get
            {
                return commPlFruit_Apricots;
            }
            set
            {
                commPlFruit_Apricots = value;
            }
        }

        public bool CommPlFruitAvocados
        {
            get
            {
                return commPlFruit_Avocados;
            }
            set
            {
                commPlFruit_Avocados = value;
            }
        }

        public bool CommPlFruitBananas
        {
            get
            {
                return commPlFruit_Bananas;
            }
            set
            {
                commPlFruit_Bananas = value;
            }
        }

        public bool CommPlFruitBerries
        {
            get
            {
                return commPlFruit_Berries;
            }
            set
            {
                commPlFruit_Berries = value;
            }
        }

        public bool CommPlFruitCherries
        {
            get
            {
                return commPlFruit_Cherries;
            }
            set
            {
                commPlFruit_Cherries = value;
            }
        }

        public bool CommPlFruitCranberries
        {
            get
            {
                return commPlFruit_Cranberries;
            }
            set
            {
                commPlFruit_Cranberries = value;
            }
        }

        public bool CommPlFruitFigs
        {
            get
            {
                return commPlFruit_Figs;
            }
            set
            {
                commPlFruit_Figs = value;
            }
        }

        public bool CommPlFruitGrapefruit
        {
            get
            {
                return commPlFruit_Grapefruit;
            }
            set
            {
                commPlFruit_Grapefruit = value;
            }
        }

        public bool CommPlFruitGrapes
        {
            get
            {
                return commPlFruit_Grapes;
            }
            set
            {
                commPlFruit_Grapes = value;
            }
        }

        public bool CommPlFruitLemons
        {
            get
            {
                return commPlFruit_Lemons;
            }
            set
            {
                commPlFruit_Lemons = value;
            }
        }

        public bool CommPlFruitLimes
        {
            get
            {
                return commPlFruit_Limes;
            }
            set
            {
                commPlFruit_Limes = value;
            }
        }

        public bool CommPlFruitMelons
        {
            get
            {
                return commPlFruit_Melons;
            }
            set
            {
                commPlFruit_Melons = value;
            }
        }

        public bool CommPlFruitOlives
        {
            get
            {
                return commPlFruit_Olives;
            }
            set
            {
                commPlFruit_Olives = value;
            }
        }

        public bool CommPlFruitOranges
        {
            get
            {
                return commPlFruit_Oranges;
            }
            set
            {
                commPlFruit_Oranges = value;
            }
        }

        public string CommPlFruitOther
        {
            get
            {
                return commPlFruit_Other;
            }
            set
            {
                commPlFruit_Other = value;
            }
        }

        public bool CommPlFruitPeaches
        {
            get
            {
                return commPlFruit_Peaches;
            }
            set
            {
                commPlFruit_Peaches = value;
            }
        }

        public bool CommPlFruitPears
        {
            get
            {
                return commPlFruit_Pears;
            }
            set
            {
                commPlFruit_Pears = value;
            }
        }

        public bool CommPlFruitPineapples
        {
            get
            {
                return commPlFruit_Pineapples;
            }
            set
            {
                commPlFruit_Pineapples = value;
            }
        }

        public bool CommPlFruitPlums
        {
            get
            {
                return commPlFruit_Plums;
            }
            set
            {
                commPlFruit_Plums = value;
            }
        }

        public bool CommPlFruitQuinces
        {
            get
            {
                return commPlFruit_Quinces;
            }
            set
            {
                commPlFruit_Quinces = value;
            }
        }

        public bool CommPlFruitBrambles
        {
            get
            {
                return commPlFruit_Brambles;
            }
            set
            {
                commPlFruit_Brambles = value;
            }
        }

        public bool CommPlFruitBlueberries
        {
            get
            {
                return commPlFruit_Blueberries;
            }
            set
            {
                commPlFruit_Blueberries = value;
            }
        }

        public bool CommPlFruitStrawberries
        {
            get
            {
                return commPlFruit_Strawberries;
            }
            set
            {
                commPlFruit_Strawberries = value;
            }
        }

        public bool CommPlFruitTangerines
        {
            get
            {
                return commPlFruit_Tangerines;
            }
            set
            {
                commPlFruit_Tangerines = value;
            }
        }

		public int ProfileCoreID
		{
			get
			{
				return profileCoreID;
			}
			set
			{
				profileCoreID = value;
			}
		}
		public int ProfileID
        {
            get
            {
                return profileID;
            }
            set
            {
                profileID = value;
            }
        }
        public int countTerms()
        {
            int termCount = 0;

            termCount += aud_farmranchers.CompareTo(false);
            termCount += aud_educators.CompareTo(false);
            termCount += aud_researchers.CompareTo(false);
            termCount += aud_consumers.CompareTo(false);
            termCount += techlvl_beginner.CompareTo(false);
            termCount += techlvl_intermediate.CompareTo(false);
            termCount += techlvl_advanced.CompareTo(false);
            termCount += inv_planning.CompareTo(false);
            termCount += inv_present.CompareTo(false);
            termCount += inv_research.CompareTo(false);
            termCount += inv_land.CompareTo(false);
            termCount += inv_extplanning.CompareTo(false);
            termCount += inv_extapplied.CompareTo(false);
            termCount += intgfrs_AgroecosystemAnalysis.CompareTo(false);
            termCount += intgfrs_WholeFarmPlanning.CompareTo(false);
            termCount += intgfrs_HolisticManagement.CompareTo(false);
            termCount += intgfrs_OrganicAgriculture.CompareTo(false);
            termCount += intgfrs_Permaculture.CompareTo(false);

            termCount += cropprd_Agroforestry.CompareTo(false);
            termCount += cropprd_FoliarFeeding.CompareTo(false);
            termCount += cropprd_NutrientCycling.CompareTo(false);
            termCount += cropprd_StripCropping.CompareTo(false);
            termCount += cropprd_BiologicalInoculants.CompareTo(false);
            termCount += cropprd_Forestry.CompareTo(false);
            termCount += cropprd_OrganicFertilizers.CompareTo(false);
            termCount += cropprd_StubbleMulching.CompareTo(false);
            termCount += cropprd_ContinuousCropping.CompareTo(false);
            termCount += cropprd_GreenManures.CompareTo(false);
            termCount += cropprd_OrganicMatter.CompareTo(false);
            termCount += cropprd_TissueAnalysis.CompareTo(false);
            termCount += cropprd_CoverCrops.CompareTo(false);
            termCount += cropprd_Intercropping.CompareTo(false);
            termCount += cropprd_Permaculture.CompareTo(false);
            termCount += cropprd_Transitioning.CompareTo(false);
            termCount += cropprd_DoubleCropping.CompareTo(false);
            termCount += cropprd_MinimumTillage.CompareTo(false);
            termCount += cropprd_ReducedApplications.CompareTo(false);
            termCount += cropprd_Earthworms.CompareTo(false);
            termCount += cropprd_MultipleCropping.CompareTo(false);
            termCount += cropprd_RelayCropping.CompareTo(false);
            termCount += cropprd_Fallow.CompareTo(false);
            termCount += cropprd_MunicipalWastes.CompareTo(false);
            termCount += cropprd_RidgeTillage.CompareTo(false);
            termCount += cropprd_Fertigation.CompareTo(false);
            termCount += cropprd_NoTill.CompareTo(false);
            termCount += cropprd_SoilAnalysis.CompareTo(false);
            termCount += cropprd_CatchCrops.CompareTo(false);
            termCount += cropprd_CropRotation.CompareTo(false);
            termCount += cropprd_CropBreeding.CompareTo(false);
            termCount += cropprd_Irrigation.CompareTo(false);

            termCount += animprd_AlternativeFeedstuffs.CompareTo(false);
            termCount += animprd_FeedRations.CompareTo(false);
            termCount += animprd_MultispeciesGrazing.CompareTo(false);
            termCount += animprd_StockpiledForages.CompareTo(false);
            termCount += animprd_AlternativeHousing.CompareTo(false);
            termCount += animprd_FreeRange.CompareTo(false);
            termCount += animprd_PastureFertility.CompareTo(false);
            termCount += animprd_Vaccines.CompareTo(false);
            termCount += animprd_AlternParasiteControl.CompareTo(false);
            termCount += animprd_HerbalMedicines.CompareTo(false);
            termCount += animprd_PastureRenovation.CompareTo(false);
            termCount += animprd_WateringSystem.CompareTo(false);
            termCount += animprd_AnimalProtection.CompareTo(false);
            termCount += animprd_Homeopathy.CompareTo(false);
            termCount += animprd_PreventivePractices.CompareTo(false);
            termCount += animprd_WinterForage.CompareTo(false);
            termCount += animprd_Composting.CompareTo(false);
            termCount += animprd_Implants.CompareTo(false);
            termCount += animprd_Probiotics.CompareTo(false);
            termCount += animprd_ContinuousGrazing.CompareTo(false);
            termCount += animprd_Inoculants.CompareTo(false);
            termCount += animprd_RangeImprovement.CompareTo(false);
            termCount += animprd_FeedAdditives.CompareTo(false);
            termCount += animprd_ManureManagement.CompareTo(false);
            termCount += animprd_RotationalGrazing.CompareTo(false);
            termCount += animprd_FeedFormulation.CompareTo(false);
            termCount += animprd_MineralSupplements.CompareTo(false);
            termCount += animprd_ShadeShelter.CompareTo(false);
            termCount += animprd_Therapeutics.CompareTo(false);
            termCount += animprd_LivestockBreeding.CompareTo(false);
            termCount += animprd_StockingRate.CompareTo(false);
            termCount += animprd_grazingmanagement.CompareTo(false);

            termCount += pestmgt_Allelopathy.CompareTo(false);
            termCount += pestmgt_EconomicThreshold.CompareTo(false);
            termCount += pestmgt_MechanicalControl.CompareTo(false);
            termCount += pestmgt_SmotherCrops.CompareTo(false);
            termCount += pestmgt_BiologicalControl.CompareTo(false);
            termCount += pestmgt_Eradication.CompareTo(false);
            termCount += pestmgt_PhysicalControl.CompareTo(false);
            termCount += pestmgt_Traps.CompareTo(false);
            termCount += pestmgt_BiorationalPesticides.CompareTo(false);
            termCount += pestmgt_Flame.CompareTo(false);
            termCount += pestmgt_PlasticMulching.CompareTo(false);
            termCount += pestmgt_TrapCrops.CompareTo(false);
            termCount += pestmgt_BotanicalPesticides.CompareTo(false);
            termCount += pestmgt_FieldMonitoring.CompareTo(false);
            termCount += pestmgt_PrecisionCultivation.CompareTo(false);
            termCount += pestmgt_VegetativeMulching.CompareTo(false);
            termCount += pestmgt_ChemicalControl.CompareTo(false);
            termCount += pestmgt_GeneticResistance.CompareTo(false);
            termCount += pestmgt_PrecisionHerbicideUse.CompareTo(false);
            termCount += pestmgt_WeatherMonitoring.CompareTo(false);
            termCount += pestmgt_Competition.CompareTo(false);
            termCount += pestmgt_IPM.CompareTo(false);
            termCount += pestmgt_Prevention.CompareTo(false);
            termCount += pestmgt_WeedEcology.CompareTo(false);
            termCount += pestmgt_CompostExtracts.CompareTo(false);
            termCount += pestmgt_KilledMulches.CompareTo(false);
            termCount += pestmgt_RowCovers.CompareTo(false);
            termCount += pestmgt_WeederGeese.CompareTo(false);
            termCount += pestmgt_CulturalControl.CompareTo(false);
            termCount += pestmgt_LivingMulches.CompareTo(false);
            termCount += pestmgt_Sanitation.CompareTo(false);
            termCount += pestmgt_DiseaseVectors.CompareTo(false);
            termCount += pestmgt_MatingDisruption.CompareTo(false);
            termCount += pestmgt_SoilSolarization.CompareTo(false);

            termCount += soilmgt_NutrientMineralization.CompareTo(false);
            termCount += soilmgt_SoilMicrobiology.CompareTo(false);
            termCount += soilmgt_SoilOrganicMatter.CompareTo(false);
            termCount += soilmgt_SoilQuality.CompareTo(false);
            termCount += soilmgt_CarbonSequestration.CompareTo(false);
            termCount += soilmgt_SoilChemistry.CompareTo(false);
            termCount += soilmgt_SoilPhysics.CompareTo(false);

            termCount += nresenv_Afforestation.CompareTo(false);
            termCount += nresenv_GrassHedges.CompareTo(false);
            termCount += nresenv_RiparianPlantings.CompareTo(false);
            termCount += nresenv_Wildlife.CompareTo(false);
            termCount += nresenv_Biodiversity.CompareTo(false);
            termCount += nresenv_GrassWaterways.CompareTo(false);
            termCount += nresenv_RiverbankProtection.CompareTo(false);
            termCount += nresenv_Windbreaks.CompareTo(false);
            termCount += nresenv_Biosphere.CompareTo(false);
            termCount += nresenv_HabitatEnhancement.CompareTo(false);
            termCount += nresenv_SoilStabilization.CompareTo(false);
            termCount += nresenv_WoodyHedges.CompareTo(false);
            termCount += nresenv_ConservationTillage.CompareTo(false);
            termCount += nresenv_Hedgerows.CompareTo(false);
            termCount += nresenv_Terraces.CompareTo(false);
            termCount += nresenv_ContourCultivation.CompareTo(false);
            termCount += nresenv_Indicators.CompareTo(false);
            termCount += nresenv_Wetlands.CompareTo(false);

            termCount += edtrain_CaseStudy.CompareTo(false);
            termCount += edtrain_Demonstration.CompareTo(false);
            termCount += edtrain_FocusGroup.CompareTo(false);
            termCount += edtrain_StudyCircle.CompareTo(false);
            termCount += edtrain_Conference.CompareTo(false);
            termCount += edtrain_Display.CompareTo(false);
            termCount += edtrain_Mentor.CompareTo(false);
            termCount += edtrain_Workshop.CompareTo(false);
            termCount += edtrain_Curriculum.CompareTo(false);
            termCount += edtrain_Extension.CompareTo(false);
            termCount += edtrain_Network.CompareTo(false);
            termCount += edtrain_Database.CompareTo(false);
            termCount += edtrain_FactSheet.CompareTo(false);
            termCount += edtrain_OnFarmResearch.CompareTo(false);
            termCount += edtrain_DecisionSupportSystem.CompareTo(false);
            termCount += edtrain_FarmerToFarmer.CompareTo(false);
            termCount += edtrain_ParticipatoryResearch.CompareTo(false);
            termCount += edtrain_YouthEducation.CompareTo(false);

            termCount += econmkt_AlternativeEnterprise.CompareTo(false);
            termCount += econmkt_CSA.CompareTo(false);
            termCount += econmkt_FeasibilityStudy.CompareTo(false);
            termCount += econmkt_RiskManagement.CompareTo(false);
            termCount += econmkt_Budget.CompareTo(false);
            termCount += econmkt_CostAndReturns.CompareTo(false);
            termCount += econmkt_FinancialAnalysis.CompareTo(false);
            termCount += econmkt_ValueAdded.CompareTo(false);
            termCount += econmkt_Cooperatives.CompareTo(false);
            termCount += econmkt_DirectMarketing.CompareTo(false);
            termCount += econmkt_MarketStudy.CompareTo(false);
            termCount += econmkt_FoodProductQualitySafety.CompareTo(false);
            termCount += econmkt_LaborEmployment.CompareTo(false);
            termCount += econmkt_Ecommerce.CompareTo(false);
            termCount += econmkt_FarmToInstitution.CompareTo(false);

            termCount += commdev_InfrastructureAnalysis.CompareTo(false);
            termCount += commdev_TechnicalAssistance.CompareTo(false);
            termCount += commdev_NewBusinessOpportunities.CompareTo(false);
            termCount += commdev_Partnerships.CompareTo(false);
            termCount += commdev_UrbanAgriculture.CompareTo(false);
            termCount += commdev_PublicParticipation.CompareTo(false);
            termCount += commdev_UrbanRuralIntegration.CompareTo(false);
            termCount += commdev_LocalRegionalCommunityFoodSystems.CompareTo(false);
            termCount += commdev_Agritourism.CompareTo(false);
            termCount += commdev_CommunityPlanning.CompareTo(false);
            termCount += commdev_PublicPolicy.CompareTo(false);
            termCount += commdev_LeadershipDevelopment.CompareTo(false);
            termCount += commdev_EthnicDifferencesCulturalDemographicChange.CompareTo(false);

            termCount += qoflife_AnalysisOfPersonalFamilyLife.CompareTo(false);
            termCount += qoflife_SocialCapitol.CompareTo(false);
            termCount += qoflife_SustainabilityMeasures.CompareTo(false);
            termCount += qoflife_CommunityServices.CompareTo(false);
            termCount += qoflife_SocialNetworks.CompareTo(false);
            termCount += qoflife_EmploymentOpportunities.CompareTo(false);
            termCount += qoflife_SocialPsychologicalIndicators.CompareTo(false);

            termCount += energy_BioenergyBiofuels.CompareTo(false);
            termCount += energy_WindPower.CompareTo(false);
            termCount += energy_EnergyUseConsumption.CompareTo(false);
            termCount += energy_SolarEnergy.CompareTo(false);
            termCount += energy_EnergyConservationEfficiency.CompareTo(false);

            termCount += commPlAgr_Barley.CompareTo(false);
            termCount += commPlAgr_GrassLegumeHay.CompareTo(false);
            termCount += commPlAgr_Peanuts.CompareTo(false);
            termCount += commPlAgr_Sorghum.CompareTo(false);
            termCount += commPlAgr_Sweetpotatoes.CompareTo(false);
            termCount += commPlAgr_Canola.CompareTo(false);
            termCount += commPlAgr_LegumeHay.CompareTo(false);
            termCount += commPlAgr_Potatoes.CompareTo(false);
            termCount += commPlAgr_Soybeans.CompareTo(false);
            termCount += commPlAgr_Tobacco.CompareTo(false);
            termCount += commPlAgr_Corn.CompareTo(false);
            termCount += commPlAgr_Hops.CompareTo(false);
            termCount += commPlAgr_Rapeseed.CompareTo(false);
            termCount += commPlAgr_Spelt.CompareTo(false);
            termCount += commPlAgr_Wheat.CompareTo(false);
            termCount += commPlAgr_Cotton.CompareTo(false);
            termCount += commPlAgr_Kenaf.CompareTo(false);
            termCount += commPlAgr_Rice.CompareTo(false);
            termCount += commPlAgr_Sugarbeets.CompareTo(false);
            termCount += commPlAgr_Flax.CompareTo(false);
            termCount += commPlAgr_Millet.CompareTo(false);
            termCount += commPlAgr_Rye.CompareTo(false);
            termCount += commPlAgr_Sugarcane.CompareTo(false);
            termCount += commPlAgr_GrassHay.CompareTo(false);
            termCount += commPlAgr_Oats.CompareTo(false);
            termCount += commPlAgr_Safflower.CompareTo(false);
            termCount += commPlAgr_Sunflower.CompareTo(false);

            termCount += commPlVeg_Artichokes.CompareTo(false);
            termCount += commPlVeg_Cabbage.CompareTo(false);
            termCount += commPlVeg_Escarole.CompareTo(false);
            termCount += commPlVeg_Onions.CompareTo(false);
            termCount += commPlVeg_SweetCorn.CompareTo(false);
            termCount += commPlVeg_Asparagus.CompareTo(false);
            termCount += commPlVeg_Carrots.CompareTo(false);
            termCount += commPlVeg_Garlic.CompareTo(false);
            termCount += commPlVeg_Parsnips.CompareTo(false);
            termCount += commPlVeg_Tomatoes.CompareTo(false);
            termCount += commPlVeg_Beans.CompareTo(false);
            termCount += commPlVeg_Cauliflower.CompareTo(false);
            termCount += commPlVeg_Greens.CompareTo(false);
            termCount += commPlVeg_Peas.CompareTo(false);
            termCount += commPlVeg_Turnips.CompareTo(false);
            termCount += commPlVeg_Beets.CompareTo(false);
            termCount += commPlVeg_Celery.CompareTo(false);
            termCount += commPlVeg_Kale.CompareTo(false);
            termCount += commPlVeg_Peppers.CompareTo(false);
            termCount += commPlVeg_Watermelon.CompareTo(false);
            termCount += commPlVeg_Broccoli.CompareTo(false);
            termCount += commPlVeg_Cucumbers.CompareTo(false);
            termCount += commPlVeg_Lentils.CompareTo(false);
            termCount += commPlVeg_Rutabagas.CompareTo(false);
            termCount += commPlVeg_BrusselSprouts.CompareTo(false);
            termCount += commPlVeg_Eggplant.CompareTo(false);
            termCount += commPlVeg_Lettuce.CompareTo(false);
            termCount += commPlVeg_Spinach.CompareTo(false);
            termCount += commplveg_leeks.CompareTo(false);
            termCount += commPlVeg_Pumpkins.CompareTo(false);
            termCount += commPlVeg_Squashes.CompareTo(false);
            termCount += commPlVeg_Radishes.CompareTo(false);

            termCount += commPlFruit_Apples.CompareTo(false);
            termCount += commPlFruit_Cherries.CompareTo(false);
            termCount += commPlFruit_Lemons.CompareTo(false);
            termCount += commPlFruit_Peaches.CompareTo(false);
            termCount += commPlFruit_Strawberries.CompareTo(false);
            termCount += commPlFruit_Apricots.CompareTo(false);
            termCount += commPlFruit_Cranberries.CompareTo(false);
            termCount += commPlFruit_Limes.CompareTo(false);
            termCount += commPlFruit_Pears.CompareTo(false);
            termCount += commPlFruit_Tangerines.CompareTo(false);
            termCount += commPlFruit_Avocados.CompareTo(false);
            termCount += commPlFruit_Figs.CompareTo(false);
            termCount += commPlFruit_Melons.CompareTo(false);
            termCount += commPlFruit_Pineapples.CompareTo(false);
            termCount += commPlFruit_Bananas.CompareTo(false);
            termCount += commPlFruit_Grapefruit.CompareTo(false);
            termCount += commPlFruit_Olives.CompareTo(false);
            termCount += commPlFruit_Plums.CompareTo(false);
            termCount += commPlFruit_Berries.CompareTo(false);
            termCount += commPlFruit_Grapes.CompareTo(false);
            termCount += commPlFruit_Oranges.CompareTo(false);
            termCount += commPlFruit_Quinces.CompareTo(false);
            termCount += commPlFruit_Brambles.CompareTo(false);
            termCount += commPlFruit_Blueberries.CompareTo(false);

            termCount += commPlNuts_Almonds.CompareTo(false);
            termCount += commPlNuts_Hazelnuts.CompareTo(false);
            termCount += commPlNuts_Pecans.CompareTo(false);
            termCount += commPlNuts_Walnuts.CompareTo(false);
            termCount += commplnuts_chestnuts.CompareTo(false);
            termCount += commPlNuts_Macadamia.CompareTo(false);
            termCount += commPlNuts_Pistachios.CompareTo(false);

            termCount += commPlAdd_Herbs.CompareTo(false);
            termCount += commPlAdd_Ornamentals.CompareTo(false);
            termCount += commPlAdd_Trees.CompareTo(false);
            termCount += commPlAdd_Mushrooms.CompareTo(false);
            termCount += commPlAdd_NativePlants.CompareTo(false);

            termCount += commAnim_Beef.CompareTo(false);
            termCount += commAnim_Chicken.CompareTo(false);
            termCount += commAnim_Rabbits.CompareTo(false);
            termCount += commAnim_Swine.CompareTo(false);
            termCount += commAnim_Dairy.CompareTo(false);
            termCount += commAnim_Goats.CompareTo(false);
            termCount += commAnim_Sheep.CompareTo(false);
            termCount += commAnim_Turkeys.CompareTo(false);

            termCount += commMisc_Bees.CompareTo(false);
            termCount += commMisc_Fish.CompareTo(false);
            termCount += commMisc_Ratites.CompareTo(false);
            termCount += commMisc_Shellfish.CompareTo(false);

            return termCount;
        }
    }
}
