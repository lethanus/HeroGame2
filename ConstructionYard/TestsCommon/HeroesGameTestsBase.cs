using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using BoDi;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;

namespace ConstructionYard
{
    [Binding]
    public class HeroesGameTestsBase
    {
        protected IObjectContainer objectContainer;

        public HeroesGameTestsBase(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeRepository()
        {
            TestInstaler.InitializeRepository(objectContainer);
        }

        [AfterScenario]
        public void CleanupRepository()
        {
            TestInstaler.CleanupRepository();
        }
    }
}
