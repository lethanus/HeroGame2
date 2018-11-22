﻿
using BoDi;
using HeroesGame.Configuration;
using HeroesGame.RefresingMechanism;
using HeroesGame.Accounts;
using HeroesGame.Repositories;
using HeroesGame.Mercenaries;
using System.IO;
using HeroesGame.Core.Randomizers;
using HeroesGame.PackBuilding;
using HeroesGame.Inventory;

namespace ConstructionYard
{
    public class TestInstaler
    {

        public static void InitializeRepository(IObjectContainer objectContainer)
        {
            var valueRandomizer = new ValueRandomizer();
            objectContainer.RegisterInstanceAs<IValueRandomizer>(valueRandomizer);
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
            var mercenaryRepo = new MercenaryJsonFileRepository(Directory.GetCurrentDirectory());
            objectContainer.RegisterInstanceAs<IMercenaryRepository>(mercenaryRepo);
            var recruitRepo = new RecruitsJsonRepository(Directory.GetCurrentDirectory());
            objectContainer.RegisterInstanceAs<IRecruitsRepository>(recruitRepo);
            var mercenaryTemplateRepository = new MercenaryTemplateJsonFileRepository("mercenaryTemplates.json");
            objectContainer.RegisterInstanceAs<IMercenaryTemplateRepository>(mercenaryTemplateRepository);
            var mercenaryManagement = new MercenaryManagement(mercenaryRepo, accountManagement, mercenaryTemplateRepository, valueRandomizer, configRepo, recruitRepo);
            objectContainer.RegisterInstanceAs<IMercenaryManagement>(mercenaryManagement);

            var packFormationRepository = new PackFormationJsonFileRepository(Directory.GetCurrentDirectory());
            objectContainer.RegisterInstanceAs<IPackFormationRepository>(packFormationRepository);

            var packFormationBuilder = new PackFormationBuilder(packFormationRepository, accountManagement);
            objectContainer.RegisterInstanceAs<IPackFormationBuilder>(packFormationBuilder);

            var itemTemplateRepository = new ItemTemplateJsonFileRepository("itemTemplates.json");
            objectContainer.RegisterInstanceAs<IItemTemplateRepository>(itemTemplateRepository);
            var positionInInventoryRepository = new PositionInInventoryJsonFileRepository(Directory.GetCurrentDirectory());
            objectContainer.RegisterInstanceAs<IPositionInInventoryRepository>(positionInInventoryRepository);
            var inventoryManagement = new InventoryManagement(itemTemplateRepository, positionInInventoryRepository, accountManagement);
            objectContainer.RegisterInstanceAs<IInventoryManagement>(inventoryManagement);

        }

        public static void CleanupRepository()
        {
            File.Delete("accounts.json");
            File.Delete("configuration.json");
            File.Delete("mercenaryTemplates.json");
            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                if (file.Contains("RefreshFacts_") || file.Contains("Mercenaries_") || file.Contains("Recruits_") || file.Contains("PackFormation_"))
                    File.Delete(file);
            }
        }

    }
}
