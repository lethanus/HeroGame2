﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using HeroesGame.Configuration;
using HeroesGame.RefresingMechanism;
using HeroesGame.Accounts;
using HeroesGame.Repositories;
using System.IO;

namespace ConstructionYard
{
    public class TestInstaler
    {

        public static void InitializeRepository(IObjectContainer objectContainer)
        {
            var accountRepo = new AccountJsonFileRepository("accounts.json");
            objectContainer.RegisterInstanceAs<IAccountRepository>(accountRepo);
            var refreshRepo = new RefreshJsonFileRepository(Directory.GetCurrentDirectory());
            objectContainer.RegisterInstanceAs<IRefreshRepository>(refreshRepo);
            var configRepo = new ConfigJsonFileRepository("configuration.json");
            objectContainer.RegisterInstanceAs<IConfigRepository>(configRepo);
            var accountManagement = new AccountManagement(accountRepo);
            objectContainer.RegisterInstanceAs<IAccountManagement>(accountManagement);
            var refreshingMechnism = new RefreshingMechnism(refreshRepo, configRepo, accountManagement);
            objectContainer.RegisterInstanceAs<IRefreshingMechnism>(refreshingMechnism);
        }

        public static void CleanupRepository()
        {
            File.Delete("accounts.json");
            File.Delete("configuration.json");
            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                if (file.Contains("RefreshFacts_"))
                    File.Delete(file);
            }
        }

    }
}