using PhotonBot.Util;
using APITests.lib;
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
            AuthTokens tokens = ClientExtensions.LoginUser(username, password);
            string uid = await ClientExtensions.GetUserIDAsync(tokens);

            Authorization VRChatAuthorization = new Authorization();
            VRChatAuthorization.AddAuthParameter("token", tokens.token);
            VRChatAuthorization.AddAuthParameter("user", uid);

            Console.WriteLine("Logged in as " + uid);

            // ConnectionDetails VRChatConfiguration = new ConnectionDetails("bd6fb72d-9fb2-47fe-95a5-083e352c85a4", "master-build-2023-03-08-kromer-k-spherechili", PhotonRegion.USW, "ns.exitgames.com", VRChatAuthorization);
            // VRChatClient client = new VRChatClient(VRChatConfiguration); 
            // client.ConnectToRegionMaster("USW");
            // Console.ReadLine();
        }
    }
}