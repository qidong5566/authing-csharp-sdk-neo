﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authing.ApiClient.Domain.Model;
using Xunit;

namespace Authing.ApiClient.Framework.Test.Management.Userpool
{
    public class UserpoolClientTest:BaseTest
    {
        [Fact]
        public async Task Userpool_Detail()
        {
            var result = await managementClient.Userpool.Detail();
            Assert.Equal(result.Id,UserPoolId);
        }

        [Fact]
        public async Task Userpool_Update()
        {
            var result = await managementClient.Userpool.Detail();
            result.Description = "测试描述";
            result = await managementClient.Userpool.Update(new UpdateUserpoolInput(){Description = "测试描述"});
            Assert.Equal(result.Description,"测试描述");
        }

        [Fact]
        public async Task Userpool_ListEnv()
        {
            var result = await managementClient.Userpool.ListEnv();
        }
    }
}
