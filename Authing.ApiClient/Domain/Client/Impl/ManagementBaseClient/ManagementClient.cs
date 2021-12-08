using System;
using System.Threading.Tasks;
using Authing.ApiClient.Interfaces.ManagementClient;
using Authing.ApiClient.Types;

namespace Authing.ApiClient.Domain.Client.Impl.ManagementBaseClient
{
    public partial class ManagementClient : BaseManagementClient
    {

        public IManagementClientUdf Udf { get; private set; }

        public IManagementClientOrgs Orgs { get; private set; }

        public Action<InitAuthenticationClientOptions> Init { get; }

        public ManagementClient(string userPoolId, string secret) : base(userPoolId, secret)
        {

        }

        public ManagementClient(Action<InitAuthenticationClientOptions> init) : base(init)
        {
            Users = new ManagementClient.UsersManagementClient(this);
            Udf = new UdfManagementClient(this);
            Orgs = new OrgsManagementClient(this);
            Whitelist = new ManagementClient.WhitelistManagementClient(this);
            Groups = new GroupsManagementClient(this);
            Userpool = new UserpoolManagement(this);
            Statistics = new StatisticsManagement(this);
            Init = init ?? throw new ArgumentNullException(nameof(init));
        }

        public static async Task<ManagementClient> InitManagementClient(string userPoolId, string secret)
        {
            var manageClient = new ManagementClient(userPoolId, secret);
            await manageClient.GetAccessToken();
            manageClient.Users = new UsersManagementClient(manageClient);
            manageClient.Udf = new UdfManagementClient(manageClient);
            manageClient.Orgs = new OrgsManagementClient(manageClient);
            manageClient.Whitelist = new WhitelistManagementClient(manageClient);
            manageClient.Groups = new GroupsManagementClient(manageClient);

            manageClient.Userpool = new UserpoolManagement(manageClient);
            manageClient.Statistics = new StatisticsManagement(manageClient);
            return manageClient;
        }


        public static async Task<ManagementClient> InitManagementClient(Action<InitAuthenticationClientOptions> init)
        {
            var manageClient = new ManagementClient(init);
            await manageClient.GetAccessToken();
            manageClient.Users = new UsersManagementClient(manageClient);
            manageClient.Udf = new UdfManagementClient(manageClient);
            manageClient.Orgs = new OrgsManagementClient(manageClient);
            manageClient.Whitelist = new WhitelistManagementClient(manageClient);
            manageClient.Groups = new GroupsManagementClient(manageClient);

            manageClient.Userpool = new UserpoolManagement(manageClient);
            manageClient.Statistics = new StatisticsManagement(manageClient);
            return manageClient;
        }
    }
}
