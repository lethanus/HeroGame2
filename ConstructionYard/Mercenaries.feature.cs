﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ConstructionYard
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Mercenaries", Description="\tManaging mercenaries for account", SourceFile="Mercenaries.feature", SourceLine=0)]
    public partial class MercenariesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Mercenaries.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Mercenaries", "\tManaging mercenaries for account", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("01 Adding new mercenary to account", new string[] {
                "mytag"}, SourceLine=4)]
        public virtual void _01AddingNewMercenaryToAccount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 Adding new mercenary to account", null, new string[] {
                        "mytag"});
#line 5
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Login",
                        "Password"});
            table1.AddRow(new string[] {
                        "ID_1",
                        "test",
                        "test"});
#line 6
 testRunner.Given("Some accounts exists in system", ((string)(null)), table1, "Given ");
#line 9
 testRunner.And("I try to login for \'test\' and password \'test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Min_Att",
                        "Max_Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table2.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "10",
                        "5",
                        "10",
                        ""});
            table2.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "10",
                        "10",
                        "5",
                        "5",
                        "0",
                        "5",
                        ""});
#line 10
 testRunner.And("Account \'ID_1\' already have some mercenaries", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Min_Att",
                        "Max_Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table3.AddRow(new string[] {
                        "Elf_C",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "10",
                        "5",
                        "10",
                        ""});
#line 14
 testRunner.When("Player will add new mercenary", ((string)(null)), table3, "When ");
#line 17
 testRunner.Then("Logged account id is \'ID_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Min_Att",
                        "Max_Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table4.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "10",
                        "5",
                        "10",
                        ""});
            table4.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "10",
                        "10",
                        "5",
                        "5",
                        "0",
                        "5",
                        ""});
            table4.AddRow(new string[] {
                        "Elf_C",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "10",
                        "5",
                        "10",
                        ""});
#line 18
 testRunner.And("Account \'ID_1\' should have mercenaries", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
