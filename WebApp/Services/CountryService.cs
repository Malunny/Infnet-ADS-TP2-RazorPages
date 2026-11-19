using WebApp.Models;

namespace WebApp.Services;

public class CountryService
{
    public bool CheckNameAndCodeFirstLettersAreTheSame(string countryName, string countryCode)
    {
            return countryName.FirstOrDefault() == countryCode.FirstOrDefault();
    }
}