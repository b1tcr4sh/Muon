using PhotonBot.Util;
using PhotonAPI;
using PhotonAPI.API;
using PhotonAPI.API.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DotEnv dotEnv = new DotEnv();
            string username = dotEnv.Get("VRCHAT_USERNAME");
            string password = dotEnv.Get("VRCHAT_PASSWORD");

            Console.Title = "Photon API Test = VRChat";
            Authorization VRChatAuthorization = new Authorization();
            var AuthCookie = "authcookie_01d6b4bd-13b2-439c-b48f-4a90f7ce324f";
            VRChatAuthorization.AddAuthParameter("token", AuthCookie);
            // VRChatAuthorization.AddAuthParameter("user", ClientExtensions.GetUserID(AuthCookie));
            VRChatAuthorization.AddAuthParameter("user", await ClientExtensions.GetUserIDWithUsernamePasswordAsync(username, password));
            ConnectionDetails VRChatConfiguration = new ConnectionDetails("bd6fb72d-9fb2-47fe-95a5-083e352c85a4", "2022-12-02t19-00-44-the-roll-of-tim", PhotonRegion.USW, "ns.exitgames.com", VRChatAuthorization);
            VRChatClient client = new VRChatClient(VRChatConfiguration); 
            client.ConnectToRegionMaster("USW");
            Console.ReadLine();
        }
    }
}