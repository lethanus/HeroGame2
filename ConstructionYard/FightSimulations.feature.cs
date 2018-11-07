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
    [TechTalk.SpecRun.FeatureAttribute("FightSimulations", Description="\tFighting ", SourceFile="FightSimulations.feature", SourceLine=0)]
    public partial class FightSimulationsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FightSimulations.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "FightSimulations", "\tFighting ", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [TechTalk.SpecRun.ScenarioAttribute("01 Fast Elf killing Goblin in first turn", new string[] {
                "mytag"}, SourceLine=4)]
        public virtual void _01FastElfKillingGoblinInFirstTurn()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 Fast Elf killing Goblin in first turn", null, new string[] {
                        "mytag"});
#line 5
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed"});
            table1.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "5",
                        "10"});
            table1.AddRow(new string[] {
                        "Golbin_B",
                        "Golbin",
                        "10",
                        "10",
                        "5",
                        "0",
                        "5"});
#line 6
 testRunner.Given("The following characters", ((string)(null)), table1, "Given ");
#line 10
 testRunner.And("Character \'Elf_A\' is assigned to team A", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("Character \'Golbin_B\' is assigned to team B", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When("Fight turn 1 ends", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed"});
            table2.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "5",
                        "10"});
            table2.AddRow(new string[] {
                        "Golbin_B",
                        "Golbin",
                        "10",
                        "0",
                        "5",
                        "0",
                        "5"});
#line 13
 testRunner.Then("The following characters status is", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 Goblins are hurting each other after 1 turn", SourceLine=19)]
        public virtual void _02GoblinsAreHurtingEachOtherAfter1Turn()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 Goblins are hurting each other after 1 turn", null, ((string[])(null)));
#line 20
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed"});
            table3.AddRow(new string[] {
                        "Golbin_A",
                        "Golbin",
                        "10",
                        "10",
                        "5",
                        "0",
                        "5"});
            table3.AddRow(new string[] {
                        "Golbin_B",
                        "Golbin",
                        "10",
                        "10",
                        "5",
                        "0",
                        "5"});
#line 21
 testRunner.Given("The following characters", ((string)(null)), table3, "Given ");
#line 25
 testRunner.And("Character \'Golbin_A\' is assigned to team A", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("Character \'Golbin_B\' is assigned to team B", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.When("Fight turn 1 ends", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed"});
            table4.AddRow(new string[] {
                        "Golbin_A",
                        "Golbin",
                        "10",
                        "5",
                        "5",
                        "0",
                        "5"});
            table4.AddRow(new string[] {
                        "Golbin_B",
                        "Golbin",
                        "10",
                        "5",
                        "5",
                        "0",
                        "5"});
#line 28
 testRunner.Then("The following characters status is", ((string)(null)), table4, "Then ");
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
