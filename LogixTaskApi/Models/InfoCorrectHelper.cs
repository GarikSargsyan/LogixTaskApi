namespace LogixTaskApi.Models
{
    public static class InfoCorrectHelper
    {
        public static string AddressCorrect(string address)
        {
            var newAddress = address.Replace('.', ' ');
            newAddress = newAddress.Replace("#", "");
            newAddress = newAddress.Replace("Apartment", "APTS");
            newAddress = newAddress.Replace("Avenue", "AVE");
            newAddress = newAddress.Replace("Road", "RD");
            newAddress = newAddress.Replace("Street", "ST");
            newAddress = newAddress.Replace("  ", " ");
            newAddress = newAddress.ToUpper();

            return newAddress;
        }
    }
}
