using System.Threading.Tasks;

namespace AdressSearchApp
{
    public class Core
    {
        public static async Task<dynamic> getAddressSearchResult(string address)
        {
            string pzNumber = address.Substring(0, 3);
            string taNumber = address.Substring(3);
            string queryString = "http://api.thni.net/jzip/X0401/JSON/" + pzNumber + "/" + taNumber + ".js";
            dynamic results = await HttpService.getDataFromService(queryString).ConfigureAwait(false);

            if ((results != null) && (!string.IsNullOrEmpty((string)results["state"])))
            {
                Address ad = new Address();
                ad.state = (string)results["state"];
                ad.stateName = (string)results["stateName"];
                ad.city = (string)results["city"];
                ad.street = (string)results["street"];
                return ad;
            }
            else
            {
                return null;
            }
        }
    }
}
