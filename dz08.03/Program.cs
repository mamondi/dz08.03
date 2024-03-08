using System;

namespace dz08._03
{
    class City
    {
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public int Population { get; set; }
        public int AreaCode { get; set; }
        public string District { get; set; }
        public string[] Districts { get; set; }

        public void SetData(string cityName, string countryName, int population, int areaCode, string district)
        {
            CityName = cityName;
            CountryName = countryName;
            Population = population;
            AreaCode = areaCode;
            District = district;
        }

        public void AddDistrict(string newDistrict)
        {
            if (Districts == null)
            {
                Districts = new string[] { newDistrict };
            }
            else
            {
                string[] temp = new string[Districts.Length + 1];
                Array.Copy(Districts, temp, Districts.Length);
                temp[temp.Length - 1] = newDistrict;
                Districts = temp;
            }
        }

        public void RemoveDistrict(string removeDistrict)
        {
            if (Districts != null)
            {
                int index = Array.IndexOf(Districts, removeDistrict);
                if (index != -1)
                {
                    string[] temp = new string[Districts.Length - 1];
                    Array.Copy(Districts, 0, temp, 0, index);
                    Array.Copy(Districts, index + 1, temp, index, Districts.Length - index - 1);
                    Districts = temp;
                }
            }
        }

        public void PrintDistricts()
        {
            if (Districts != null)
            {
                foreach (string dist in Districts)
                {
                    Console.WriteLine(dist);
                }
            }
        }

        public void PrintCity()
        {
            Console.WriteLine("City name: " + CityName);
            Console.WriteLine("Country name: " + CountryName);
            Console.WriteLine("Population: " + Population);
            Console.WriteLine("Area code: " + AreaCode);
            Console.WriteLine("Districts:");
            PrintDistricts();
        }

        public static City operator +(City city, int increase)
        {
            city.Population += increase;
            return city;
        }

        public static City operator -(City city, int decrease)
        {
            city.Population -= decrease;
            return city;
        }

        public static bool operator ==(City city1, City city2)
        {
            if (ReferenceEquals(city1, city2))
                return true;
            if (city1 is null || city2 is null)
                return false;
            return city1.Population == city2.Population;
        }

        public static bool operator !=(City city1, City city2)
        {
            return !(city1 == city2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            City other = (City)obj;
            return this.Population == other.Population;
        }

        public override int GetHashCode()
        {
            return Population.GetHashCode();
        }

        public static bool operator >(City city1, City city2)
        {
            return city1.Population > city2.Population;
        }

        public static bool operator <(City city1, City city2)
        {
            return city1.Population < city2.Population;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            City city1 = new City();
            city1.SetData("Sarajevo", "Bosnia and Herzegovina", 500000, 71000, "Centar");

            City city2 = new City();
            city2.SetData("Paris", "France", 2000000, 75000, "1st Arrondissement");

            Console.WriteLine("City 1 Population: " + city1.Population);
            Console.WriteLine("City 2 Population: " + city2.Population);

            city1 += 100000;
            Console.WriteLine("City 1 Population after increase: " + city1.Population);

            if (city1 > city2)
            {
                Console.WriteLine("City 1 has a larger population than City 2");
            }
            else
            {
                Console.WriteLine("City 2 has a larger population than City 1");
            }

            // Check if city1 population is equal to city2 population
            if (city1.Equals(city2))
            {
                Console.WriteLine("City 1 population is equal to City 2 population");
            }
            else
            {
                Console.WriteLine("City 1 population is not equal to City 2 population");
            }

        }
    }
}
