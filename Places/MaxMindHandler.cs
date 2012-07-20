using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace Places
{
    /// <summary>
    /// handler for MaxMind files loading 
    /// </summary>
    internal class MaxMindHandler
    {
        // defaults
        private const string EnglishLanguageCode = "en";

        // file paths
        private readonly string _maxMindCountriesPath =
            ConfigurationManager.AppSettings["MaxMind_CountriesPath"];
        private readonly string _maxMindNonNorthAmericaRegionsPath =
            ConfigurationManager.AppSettings["MaxMind_NonNorthAmericaRegionsPath"];
        private readonly string _maxMindNorthAmericaRegionsPath =
            ConfigurationManager.AppSettings["MaxMind_NorthAmericaRegionsPath"];
        private readonly string _maxMindCitiesPath =
            ConfigurationManager.AppSettings["MaxMind_CitiesPath"];

        // name lists
        private List<MaxMindData.CountryName> _countryNames;
        private List<MaxMindData.NonNorthAmericaRegionName> _nonNorthAmericaRegionNames;
        private List<MaxMindData.NorthAmericaRegionName> _northAmericaRegionNames;
        private List<MaxMindData.CityName> _cityNames;

        /// <summary>
        /// gets the localized Country name
        /// </summary>
        /// <param name="countryCode">the Country code</param>
        /// <param name="languageCode">the language code</param>
        /// <returns>the localized Country name</returns>
        internal string GetCountryName(string countryCode, string languageCode)
        {
            if (_countryNames == null)
                _countryNames = MaxMindData.Data.GetCountryNames(_maxMindCountriesPath).ToList();

            var localizedCountryName = _countryNames
                .SingleOrDefault(model => model.CountryCode == countryCode && model.LanguageCode == languageCode);

            return localizedCountryName != null ? localizedCountryName.LocalizedCountryName : null;
        }

        /// <summary>
        /// gets the localized North American region name
        /// </summary>
        /// <param name="countryCode">the Country code</param>
        /// <param name="regionCode">the Region code</param>
        /// <param name="langugeCode">the language code</param>
        /// <returns>the localized Region name</returns>
        internal string GetNorthAmericaRegionName(string countryCode, string regionCode, string langugeCode)
        {
            if (_northAmericaRegionNames == null)
                _northAmericaRegionNames = MaxMindData.Data.GetNorthAmericaRegionNames(_maxMindNorthAmericaRegionsPath).ToList();

            var localizedRegionName = _northAmericaRegionNames
                .SingleOrDefault(
                    model =>
                    model.CountryCode == countryCode && model.RegionCode == regionCode &&
                    model.LanguageCode == langugeCode);

            return localizedRegionName != null ? localizedRegionName.LocalizedRegionName : null;
        }

        /// <summary>
        /// gets the localized non North America region name by its English name
        /// </summary>
        /// <param name="countryCode">the Country code</param>
        /// <param name="regionEnglishName">the Region english name</param>
        /// <param name="langugeCode">the language code</param>
        /// <returns>the localized Region name</returns>
        internal string GetNonNorthAmericaRegionName(string countryCode, string regionEnglishName, string langugeCode)
        {
            if (_nonNorthAmericaRegionNames == null)
                _nonNorthAmericaRegionNames =
                    MaxMindData.Data.GetNonNorthAmericaRegionNames(_maxMindNonNorthAmericaRegionsPath).ToList();

            var currentRegionName = _nonNorthAmericaRegionNames
                .SingleOrDefault(
                    model =>
                    model.CountryCode == countryCode && model.LocalizedRegionName == regionEnglishName &&
                    model.LanguageCode == EnglishLanguageCode);

            if (currentRegionName == null) return null;

            var currentRegionFipsCode = currentRegionName.FipsRegionCode;
            var currentRegionGeonamesId = currentRegionName.GeonamesId;

            var localizedRegionName = _nonNorthAmericaRegionNames
                .SingleOrDefault(
                    model =>
                    model.FipsRegionCode == currentRegionFipsCode && model.LanguageCode == langugeCode &&
                    model.GeonamesId == currentRegionGeonamesId);

            return localizedRegionName != null ? localizedRegionName.LocalizedRegionName : null;
        }

        /// <summary>
        /// gets the localized City code by its English name
        /// </summary>
        /// <param name="cityName">the City name</param>
        /// <param name="languageCode">the language code</param>
        /// <returns>the localized name</returns>
        internal string GetCityName(string cityName, string languageCode)
        {
            if (_cityNames == null)
                _cityNames = MaxMindData.Data.GetCityNames(_maxMindCitiesPath).ToList();

            var currentCityName =
                _cityNames.FirstOrDefault(
                    model => model.LocalName == cityName && model.LanguageCode == EnglishLanguageCode);

            if (currentCityName == null) return null;

            var currentCityMaxMindId = currentCityName.MaxMindId;
            var currentCityGeonamesId = currentCityName.GeonamesId;

            var localizedCityCode =
                _cityNames.SingleOrDefault(
                    model =>
                    model.MaxMindId == currentCityMaxMindId && model.GeonamesId == currentCityGeonamesId &&
                    model.LanguageCode == languageCode);

            return localizedCityCode != null ? localizedCityCode.LocalName : null;
        }
    }
}
