using System;
using System.Collections.Generic;
using System.Text;

namespace Player.Restaurants.DTOs
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Entities
    {
    }

    public class InitialReduxState
    {
        public PageRestaurantDetail pageRestaurantDetail { get; set; }
    }

    public class PageRestaurantDetail
    {
        public object entities { get; set; }
    }

    public class Props
    {
        public InitialReduxState initialReduxState { get; set; }
    }

    public class GrabData
    {
        public Props props { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Address
    {
        public string acronym { get; set; }
        public string combinedAddress { get; set; }
        public string combinedCity { get; set; }
        public string house { get; set; }
        public string street { get; set; }
        public string suburb { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public int cityID { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int countryID { get; set; }
    }

    public class Campaign
    {
        public string ID { get; set; }
        public string campaignLevel { get; set; }
        public string campaignType { get; set; }
        public StartTime startTime { get; set; }
        public EndTime endTime { get; set; }
        public string name { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        public List<string> tcDetails { get; set; }
        public string nameForMex { get; set; }
        public int businessTag { get; set; }
    }

    public class Category
    {
        public string ID { get; set; }
        public string name { get; set; }
        public bool available { get; set; }
        public List<GrabItem> items { get; set; }
        public int sortOrder { get; set; }
    }

    public class Currency
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public int exponent { get; set; }
        public string ISOSymbol { get; set; }
    }

    public class Currency3
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public int exponent { get; set; }
        public string ISOSymbol { get; set; }
    }

    public class DiscountedPriceV2
    {
        public int amountInMinor { get; set; }
        public string amountDisplay { get; set; }
    }

    public class EndTime
    {
        public int seconds { get; set; }
    }

    public class Features
    {
        public bool enableServiceBasedMenu { get; set; }
    }

    public class FixFeeForDisplay
    {
        public int amountInMinor { get; set; }
        public string amountDisplay { get; set; }
    }

    public class From
    {
        public int seconds { get; set; }
    }

    public class GrabItem
    {
        public string ID { get; set; }
        public string name { get; set; }
        public bool available { get; set; }
        public int priceInMinorUnit { get; set; }
        public string imgHref { get; set; }
        public List<string> images { get; set; }
        public string description { get; set; }
        public List<ModifierGroup> modifierGroups { get; set; }
        public int sortOrder { get; set; }
        public string campaignID { get; set; }
        public string campaignName { get; set; }
        public int discountedPriceInMin { get; set; }
        public PriceV2 priceV2 { get; set; }
        public DiscountedPriceV2 discountedPriceV2 { get; set; }
        public Currency _currency { get; set; }
        public int position { get; set; }
    }

    public class Latlng
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Menu
    {
        public List<Category> categories { get; set; }
        public MenuMeta menuMeta { get; set; }
        public List<Campaign> campaigns { get; set; }
    }

    public class MenuMeta
    {
        public int orderValueLimit { get; set; }
    }

    public class Modifier
    {
        public string ID { get; set; }
        public string name { get; set; }
        public bool available { get; set; }
        public int priceInMinorUnit { get; set; }
        public int sortOrder { get; set; }
        public PriceV2 priceV2 { get; set; }
        public Currency _currency { get; set; }
    }

    public class ModifierGroup
    {
        public string ID { get; set; }
        public string name { get; set; }
        public bool available { get; set; }
        public int selectionType { get; set; }
        public int selectionRangeMin { get; set; }
        public int selectionRangeMax { get; set; }
        public List<Modifier> modifiers { get; set; }
    }

    public class OpeningHours
    {
        public bool open { get; set; }
        public string displayedHours { get; set; }
        public string sun { get; set; }
        public string mon { get; set; }
        public string tue { get; set; }
        public string wed { get; set; }
        public string thu { get; set; }
        public string fri { get; set; }
        public string sat { get; set; }
        public bool tempClosed { get; set; }
    }

    public class PreSelectedStartTime
    {
        public int seconds { get; set; }
    }

    public class PriceV2
    {
        public int amountInMinor { get; set; }
        public string amountDisplay { get; set; }
    }

    public class Promo
    {
        public bool hasPromo { get; set; }
        public string description { get; set; }
    }

    public class GrabRestaurantData
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string cuisine { get; set; }
        public string photoHref { get; set; }
        public string timeZone { get; set; }
        public int ETA { get; set; }
        public string description { get; set; }
        public OpeningHours openingHours { get; set; }
        public bool isIntegrated { get; set; }
        public string phoneNumber { get; set; }
        public double distanceInKm { get; set; }
        public string section { get; set; }
        public SectionOpenHours sectionOpenHours { get; set; }
        public Latlng latlng { get; set; }
        public Address address { get; set; }
        public Menu menu { get; set; }
        public Currency currency { get; set; }
        public double rating { get; set; }
        public int voteCount { get; set; }
        public string status { get; set; }
        public string deliverBy { get; set; }
        public int radius { get; set; }
        public Promo promo { get; set; }
        public SofConfiguration sofConfiguration { get; set; }
        public bool isLeadsGen { get; set; }
        public string businessType { get; set; }
        public SchedulerOrderConfig schedulerOrderConfig { get; set; }
        public Features features { get; set; }
    }

    public class SchedulerOrderConfig
    {
        public bool enableScheduleOrder { get; set; }
        public List<ScheduleTimeSlot> scheduleTimeSlots { get; set; }
        public int scheduleTimeSpan { get; set; }
        public int scheduleIntervalTime { get; set; }
        public PreSelectedStartTime preSelectedStartTime { get; set; }
        public int minAdvancePeriodInMin { get; set; }
    }

    public class ScheduleTimeSlot
    {
        public List<TimeSlot> timeSlots { get; set; }
    }

    public class SectionOpenHours
    {
        public bool open { get; set; }
        public string displayedHours { get; set; }
        public string sun { get; set; }
        public string mon { get; set; }
        public string tue { get; set; }
        public string wed { get; set; }
        public string thu { get; set; }
        public string fri { get; set; }
        public string sat { get; set; }
    }

    public class SofConfiguration
    {
        public int thresholdInMin { get; set; }
        public ThresholdForDisplay thresholdForDisplay { get; set; }
        public string calculationMode { get; set; }
        public int fixFeeInMin { get; set; }
        public FixFeeForDisplay fixFeeForDisplay { get; set; }
    }

    public class StartTime
    {
        public int seconds { get; set; }
    }

    public class ThresholdForDisplay
    {
        public int amountInMinor { get; set; }
        public string amountDisplay { get; set; }
    }

    public class TimeSlot
    {
        public From from { get; set; }
        public To to { get; set; }
        public bool available { get; set; }
    }

    public class To
    {
        public int seconds { get; set; }
    }



}
