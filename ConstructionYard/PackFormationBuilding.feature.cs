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
    [TechTalk.SpecRun.FeatureAttribute("Pack Formation Building", Description="\tMechanizm to ensure proper and valid formation in the pack for the fight", SourceFile="PackFormationBuilding.feature", SourceLine=0)]
    public partial class PackFormationBuildingFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PackFormationBuilding.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Pack Formation Building", "\tMechanizm to ensure proper and valid formation in the pack for the fight", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [TechTalk.SpecRun.ScenarioAttribute("01 Setting character in Front 1", new string[] {
                "mytag"}, SourceLine=5)]
        public virtual void _01SettingCharacterInFront1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 Setting character in Front 1", null, new string[] {
                        "mytag"});
#line 6
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
#line 7
 testRunner.Given("Some accounts exists in system", ((string)(null)), table1, "Given ");
#line 10
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
#line 11
 testRunner.And("Account \'ID_1\' already have some mercenaries", ((string)(null)), table2, "And ");
#line 15
 testRunner.When("Player will set character with ID \'Elf_A\' to position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Position",
                        "Character_ID"});
            table3.AddRow(new string[] {
                        "Front_1",
                        "Elf_A"});
            table3.AddRow(new string[] {
                        "Front_2",
                        ""});
            table3.AddRow(new string[] {
                        "Front_3",
                        ""});
            table3.AddRow(new string[] {
                        "Middle_1",
                        ""});
            table3.AddRow(new string[] {
                        "Middle_2",
                        ""});
            table3.AddRow(new string[] {
                        "Middle_3",
                        ""});
            table3.AddRow(new string[] {
                        "Middle_4",
                        ""});
            table3.AddRow(new string[] {
                        "Rear_1",
                        ""});
            table3.AddRow(new string[] {
                        "Rear_2",
                        ""});
            table3.AddRow(new string[] {
                        "Rear_3",
                        ""});
#line 16
 testRunner.Then("Pack formation should look like this", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 Replacing character from the position", SourceLine=29)]
        public virtual void _02ReplacingCharacterFromThePosition()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 Replacing character from the position", null, ((string[])(null)));
#line 30
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Login",
                        "Password"});
            table4.AddRow(new string[] {
                        "ID_1",
                        "test",
                        "test"});
#line 31
 testRunner.Given("Some accounts exists in system", ((string)(null)), table4, "Given ");
#line 34
 testRunner.And("I try to login for \'test\' and password \'test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Min_Att",
                        "Max_Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table5.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "10",
                        "5",
                        "10",
                        ""});
            table5.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "10",
                        "10",
                        "5",
                        "5",
                        "0",
                        "5",
                        ""});
#line 35
 testRunner.And("Account \'ID_1\' already have some mercenaries", ((string)(null)), table5, "And ");
#line 39
 testRunner.When("Player will set character with ID \'Elf_A\' to position \'Middle_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
 testRunner.When("Player will set character with ID \'Goblin_B\' to position \'Middle_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Position",
                        "Character_ID"});
            table6.AddRow(new string[] {
                        "Front_1",
                        ""});
            table6.AddRow(new string[] {
                        "Front_2",
                        ""});
            table6.AddRow(new string[] {
                        "Front_3",
                        ""});
            table6.AddRow(new string[] {
                        "Middle_1",
                        "Goblin_B"});
            table6.AddRow(new string[] {
                        "Middle_2",
                        ""});
            table6.AddRow(new string[] {
                        "Middle_3",
                        ""});
            table6.AddRow(new string[] {
                        "Middle_4",
                        ""});
            table6.AddRow(new string[] {
                        "Rear_1",
                        ""});
            table6.AddRow(new string[] {
                        "Rear_2",
                        ""});
            table6.AddRow(new string[] {
                        "Rear_3",
                        ""});
#line 41
 testRunner.Then("Pack formation should look like this", ((string)(null)), table6, "Then ");
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
