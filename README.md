# Places
Database builder for countries, regions and airports from many sources. All this places include localized names for English and Spanish.

## Data Sources

The data source files are not included in this repo, as you might want to grab the latest versions.

### OurAirports
OurAirports CSV data dumps are all located at [ourairports.com/data](http://www.ourairports.com/data/). These data dumps give the basic structure and data of the database. Required files for this project are:

* 	[countries.csv](http://www.ourairports.com/data/countries.csv): List of countries.
* 	[regions.csv](http://www.ourairports.com/data/regions.csv): List of countries' regions.
* 	[airports.csv](http://www.ourairports.com/data/airports.csv): List and information of all airports on the site.

### MaxMind
MaxMind CSV data dumps are located at [maxmind.com/app/faq#localization](http://www.maxmind.com/app/faq#localization). These data dumps are used for localization purposes. A [zip file](http://www.maxmind.com/GeoIPLocationCSV-localized.zip) contains the required files:

*	GeoIPCity-localized.csv: List of cities with localized names.
*	fips10-4-localized.csv: List of Non-North American regions with localized names.
*	iso-3166-2-localized.csv: List of North American regions with localized names.
*	iso-3166-localized.csv: List of countries with localized names.

## Usage

After grabbing all the data sources, set all the file paths on the `Places/App.config` file. Also, if you wish to run the test suite set the paths on the `Test/App.config` file.

## Required Packages

*	[Entity Framework](http://nuget.org/packages/entityframework)
*	[FileHelpers](http://nuget.org/packages/FileHelpers)
*	[xunit](http://nuget.org/packages/xunit)

## License
[MIT License](https://github.com/jonotrujillo/places/blob/master/LICENSE.md).

## Bugs & To-dos

*	Data between OurAirports and MaxMind will not always match, then some Spanish localized names won't be found. For those `NULL` will be assigned.
*	A data dump for Metropolitan Areas was not found, hence IATA codes like `NYC`, `CHI` and `BER` won't be found in the generated database. These areas and their codes are available [here](http://wikitravel.org/en/Metropolitan_Area_Airport_Codes).