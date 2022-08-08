﻿using Authing.ApiClient.Domain.Model.Management.Tenant;
using Authing.Library.Domain.Model.Exceptions;
using System.Collections.Generic;
using Xunit;

namespace Authing.ApiClient.Framework.Test.Management.Tenant
{
    public class TennatTest : BaseTest
    {
        /// <summary>
        /// 2022-8-8 测试通过
        /// </summary>
        [Fact]
        public async void Tenant_List()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.List(authingErrorBox:authingErrorBox);
            Assert.NotEmpty(result.List);
        }

        /// <summary>
        /// 2022-8-8 测试通过
        /// </summary>
        [Fact]
        public async void Tenant_Details()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.Details("62f0dae6f44905bf6d4d435a",authingErrorBox:authingErrorBox);
            Assert.NotNull(result);
        }

        /// <summary>
        /// 2022-8-8 测试通过
        /// </summary>
        [Fact]
        public async void Tenant_Create()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.Create(new CreateTenantOption()
            {
                Name = "测试10-2",
                AppIds = "61c2d04b36324259776af784"
            },authingErrorBox);
            Assert.NotNull(result);
        }

        /// <summary>
        /// 2022-8-8 测试通过
        /// </summary>
        [Fact]
        public async void Tenant_Update()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.Update("62f0db981be55e0d24559829", new CreateTenantOption()
            {
                Name = "测试10-1",
            },authingErrorBox);
            Assert.True(result);
        }

        /// <summary>
        /// 2022-8-8 测试通过
        /// </summary>
        [Fact]
        public async void Tenant_Delete()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.Delete("62f0db981be55e0d24559829",authingErrorBox);
            Assert.Equal(result.Code, 200);
        }

        /// <summary>
        /// 2022-8-8 测试通过
        /// </summary>
        [Fact]
        public async void Tenant_Config()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.Config("62f0dae6f44905bf6d4d435a", new ConfigTenantOption()
            {
                SsoPageCustomizationSettings = new SsoPageCustomizationSettings()
                {
                    AutoRegisterThenLogin = true
                }
            },authingErrorBox);
            Assert.True(result);
        }

        /// <summary>
        /// 2022-8-8 测试通过
        /// </summary>
        [Fact]
        public async void Tenant_Members()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.Members("62f0dae6f44905bf6d4d435a", new TenantMembersOption() { },authingErrorBox);
            Assert.NotEmpty(result.List);
        }

        [Fact]
        public async void Tenant_AddMembers()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.AddMembers("61c963adcc6da58494a3ef43", new string[] { "61b1c0794929eb12c163305d" },authingErrorBox:authingErrorBox);
            Assert.NotNull(result);
        }

        [Fact]
        public async void Tenant_RemoveMembers()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.RemoveMembers("61c963adcc6da58494a3ef43", "61b1c0794929eb12c163305d",authingErrorBox);
            Assert.NotNull(result);
        }

        [Fact]
        public async void Tenant_ListExtIdp()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.ListExtIdp("61c963adcc6da58494a3ef43",authingErrorBox);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void Tenant_ExtIdpDetail()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.ExtIdpDetail("tennat",authingErrorBox);
            Assert.NotNull(result);
        }

        [Fact]
        public async void Tenant_CreateExtIdp()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.CreateExtIdp(new CreateExtIdpOption()
            {
                Name = "wechat",
                Type = Types.ExtIdpType.WECHAT,
                TenantId = "61c963adcc6da58494a3ef43",
                Connections = new ExtIdpConnDetailInput[] { new ExtIdpConnDetailInput() {
                    DisplayName = "weixin2",
                    Type = Types.ExtIdpConnType.WECHATPC,
                    Identifier = "weixin2",
                    Fields = new Dictionary<string, object>(){
                        { "clientID", "1234567890" },
                        { "clientSecret", "qwertyuiop" }
                    }
                } }
            },authingErrorBox);
            Assert.NotNull(result);
        }

        [Fact]
        public async void Tenant_UpdateExtIdp()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.UpdateExtIdp("tennat", new UpdateExtIdpOption()
            {
                Name = "gitlab"
            }, authingErrorBox);
            Assert.Equal(result.Code, 200);
        }

        [Fact]
        public async void Tenant_DeleteExtIdp()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.DeleteExtIdp("weixin1",authingErrorBox);
            Assert.NotNull(result);
        }

        [Fact]
        public async void Tenant_CreateExtIdpConnection()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.CreateExtIdpConnection(new CreateExtIdpConnectionOption()
            {
                ExtIdpId = "61cc12d21769b93fb1f55e56",
                DisplayName = "weixin3",
                Type = Types.ExtIdpConnType.WECHATPC,
                Identifier = "weixin3",
                Fields = new Dictionary<string, object>(){
                    { "clientID", "12345678901" },
                    { "clientSecret", "qwertyuiop1" }
                }
            },authingErrorBox);
            Assert.NotNull(result);
        }

        [Fact]
        public async void Tenant_UpdateExtIdpConnection()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.UpdateExtIdpConnection("61cbd8194b78e22761c523ca", new UpdateExtIdpConnectionOption()
            {
                DisplayName = "oauth--3",
                Fields = new Dictionary<string, object>() {
                    { "clientID", "123456789012345" },
                    { "clientSecret", "qwertyuiop12345" }
                }
            },authingErrorBox);
            Assert.Equal(result.Code, 200);
        }

        [Fact]
        public async void Tenant_DeleteExtIdpConnection()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.DeleteExtIdpConnection("61cbd7ca95b42360f5374892",authingErrorBox);
            Assert.Equal(result.Code, 200);
        }

        [Fact]
        public async void Tenant_CheckExtIdpConnectionIdentifierUnique()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.CheckExtIdpConnectionIdentifierUnique("saml1",authingErrorBox);
            Assert.True(result);
        }

        [Fact]
        public async void Tenant_ChangeExtIdpConnectionState()
        {
            AuthingErrorBox authingErrorBox = new AuthingErrorBox();

            var client = managementClient;
            var result = await client.Tennat.ChangeExtIdpConnectionState("61cbca29206969bf63d38da9", new ChangeExtIdpConnectionStateOption()
            {
                Enabled = false
            },authingErrorBox);
            Assert.True(result);
        }

        [Fact]
        public async void Tenant_BatchChangeExtIdpConnectionState()
        {
            var client = managementClient;
            var result = await client.Tennat.BatchChangeExtIdpConnectionState("61c963adcc6da58494a3ef43", new ChangeExtIdpConnectionStateOption()
            {
                Enabled = false
            });
            Assert.True(result);
        }
    }
}