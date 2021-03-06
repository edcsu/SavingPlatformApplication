﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data;
using SavingPlatformApplication.Repositories.Contracts;

namespace SavingPlatformApplication.Repositories.Implementations
{
    public class AssetRepository : BaseRepository, IAssetRepository
    {
        public AssetRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
