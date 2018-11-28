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
    [TechTalk.SpecRun.FeatureAttribute("Fight management", SourceFile="FightManagement.feature", SourceLine=0)]
    public partial class FightManagementFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FightManagement.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Fight management", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [TechTalk.SpecRun.ScenarioAttribute("01 Player team for sure should win", new string[] {
                "mytag"}, SourceLine=4)]
        public virtual void _01PlayerTeamForSureShouldWin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 Player team for sure should win", null, new string[] {
                        "mytag"});
#line 5
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Level",
                        "Name",
                        "HP_range",
                        "Min_Attack_range",
                        "Defence_range",
                        "Speed_range",
                        "Attack_add_for_max"});
            table1.AddRow(new string[] {
                        "1",
                        "Goblin",
                        "18-22",
                        "8-12",
                        "8-12",
                        "8-10",
                        "4"});
            table1.AddRow(new string[] {
                        "2",
                        "Goblin",
                        "22-26",
                        "12-16",
                        "10-14",
                        "9-11",
                        "5"});
            table1.AddRow(new string[] {
                        "3",
                        "Goblin",
                        "26-34",
                        "16-24",
                        "12-16",
                        "10-12",
                        "7"});
            table1.AddRow(new string[] {
                        "4",
                        "Goblin",
                        "40-55",
                        "30-40",
                        "18-22",
                        "11-13",
                        "10"});
#line 6
 testRunner.Given("Some mercenary templates", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "Level",
                        "F1",
                        "F2",
                        "F3",
                        "M1",
                        "M2",
                        "M3",
                        "M4",
                        "R1",
                        "R2",
                        "R3"});
            table2.AddRow(new string[] {
                        "T_1",
                        "Goblin pack",
                        "1",
                        "Goblin@1",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        ""});
#line 12
 testRunner.And("Have some formation templates", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Login",
                        "Password"});
            table3.AddRow(new string[] {
                        "ID_1",
                        "test",
                        "test"});
#line 15
 testRunner.And("Some accounts exists in system", ((string)(null)), table3, "And ");
#line 18
 testRunner.And("I try to login for \'test\' and password \'test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                        "200",
                        "200",
                        "30",
                        "30",
                        "5",
                        "10",
                        ""});
            table4.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "100",
                        "100",
                        "20",
                        "20",
                        "0",
                        "5",
                        ""});
#line 19
 testRunner.And("Account \'ID_1\' already have some mercenaries", ((string)(null)), table4, "And ");
#line 23
 testRunner.When("Player will set character with ID \'Elf_A\' to position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.And("Player will set character with ID \'Goblin_B\' to position \'Front_2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("Fight will be vs generated team from template \'T_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.Then("Fight result should be \'Player wins\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 Player team for sure should lose", SourceLine=28)]
        public virtual void _02PlayerTeamForSureShouldLose()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 Player team for sure should lose", null, ((string[])(null)));
#line 29
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Level",
                        "Name",
                        "HP_range",
                        "Min_Attack_range",
                        "Defence_range",
                        "Speed_range",
                        "Attack_add_for_max"});
            table5.AddRow(new string[] {
                        "1",
                        "Goblin",
                        "18-22",
                        "8-12",
                        "8-12",
                        "8-10",
                        "4"});
            table5.AddRow(new string[] {
                        "2",
                        "Goblin",
                        "22-26",
                        "12-16",
                        "10-14",
                        "9-11",
                        "5"});
            table5.AddRow(new string[] {
                        "3",
                        "Goblin",
                        "26-34",
                        "16-24",
                        "12-16",
                        "10-12",
                        "7"});
            table5.AddRow(new string[] {
                        "4",
                        "Goblin",
                        "40-55",
                        "30-40",
                        "18-22",
                        "11-13",
                        "10"});
#line 30
 testRunner.Given("Some mercenary templates", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "Level",
                        "F1",
                        "F2",
                        "F3",
                        "M1",
                        "M2",
                        "M3",
                        "M4",
                        "R1",
                        "R2",
                        "R3"});
            table6.AddRow(new string[] {
                        "T_1",
                        "Goblin pack",
                        "1",
                        "Goblin@4",
                        "Goblin@4",
                        "Goblin@4",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        ""});
#line 36
 testRunner.And("Have some formation templates", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Login",
                        "Password"});
            table7.AddRow(new string[] {
                        "ID_1",
                        "test",
                        "test"});
#line 39
 testRunner.And("Some accounts exists in system", ((string)(null)), table7, "And ");
#line 42
 testRunner.And("I try to login for \'test\' and password \'test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Min_Att",
                        "Max_Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table8.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "200",
                        "20",
                        "30",
                        "30",
                        "5",
                        "7",
                        ""});
            table8.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "100",
                        "10",
                        "20",
                        "20",
                        "0",
                        "5",
                        ""});
#line 43
 testRunner.And("Account \'ID_1\' already have some mercenaries", ((string)(null)), table8, "And ");
#line 47
 testRunner.When("Player will set character with ID \'Elf_A\' to position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.And("Player will set character with ID \'Goblin_B\' to position \'Front_2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("Fight will be vs generated team from template \'T_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.Then("Fight result should be \'Player defeated\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
