﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authing.ApiClient.Domain.Client.Impl.ManagementBaseClient
{
    public partial class ManagementClient
    {
        public UserpoolManagement Userpool { get; set; }

        public class UserpoolManagement
        {
            private readonly ManagementClient client;

            public UserpoolManagement(ManagementClient client)
            {
                this.client = client;
            }
        }
    }
}