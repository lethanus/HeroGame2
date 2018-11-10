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
                        "Speed",
                        "Skills"});
            table1.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "5",
                        "10",
                        "Normal_Attack"});
            table1.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "10",
                        "10",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
#line 6
 testRunner.Given("The following characters", ((string)(null)), table1, "Given ");
#line 10
 testRunner.And("Character \'Elf_A\' is assigned to team \'A\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("Character \'Goblin_B\' is assigned to team \'B\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When("Fight between \'A\' and \'B\' starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table2.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "5",
                        "10",
                        "Normal_Attack"});
            table2.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "10",
                        "0",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
#line 13
 testRunner.Then("The following characters status is", ((string)(null)), table2, "Then ");
#line 17
 testRunner.And("Team \'A\' won", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 Goblins are hurting each other", SourceLine=19)]
        public virtual void _02GoblinsAreHurtingEachOther()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 Goblins are hurting each other", null, ((string[])(null)));
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
                        "Speed",
                        "Skills"});
            table3.AddRow(new string[] {
                        "Goblin_A",
                        "Goblin",
                        "10",
                        "10",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
            table3.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "10",
                        "10",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
#line 21
 testRunner.Given("The following characters", ((string)(null)), table3, "Given ");
#line 25
 testRunner.And("Character \'Goblin_A\' is assigned to team \'A\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("Character \'Goblin_B\' is assigned to team \'B\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.When("Fight between \'A\' and \'B\' starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table4.AddRow(new string[] {
                        "Goblin_A",
                        "Goblin",
                        "10",
                        "5",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
            table4.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "10",
                        "0",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
#line 28
 testRunner.Then("The following characters status is", ((string)(null)), table4, "Then ");
#line 32
 testRunner.And("Team \'A\' won", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("03 Elf is to weak for a Troll", SourceLine=33)]
        public virtual void _03ElfIsToWeakForATroll()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03 Elf is to weak for a Troll", null, ((string[])(null)));
#line 34
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table5.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "5",
                        "10",
                        "Normal_Attack"});
            table5.AddRow(new string[] {
                        "Troll_B",
                        "Troll",
                        "100",
                        "100",
                        "15",
                        "5",
                        "5",
                        "Normal_Attack"});
#line 35
 testRunner.Given("The following characters", ((string)(null)), table5, "Given ");
#line 39
 testRunner.And("Character \'Elf_A\' is assigned to team \'A\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("Character \'Troll_B\' is assigned to team \'B\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.When("Fight between \'A\' and \'B\' starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table6.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "0",
                        "10",
                        "5",
                        "10",
                        "Normal_Attack"});
            table6.AddRow(new string[] {
                        "Troll_B",
                        "Troll",
                        "100",
                        "90",
                        "15",
                        "5",
                        "5",
                        "Normal_Attack"});
#line 42
 testRunner.Then("The following characters status is", ((string)(null)), table6, "Then ");
#line 46
 testRunner.And("Team \'B\' won", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("04 Two fast Elfs killing two Goblins in first turn", SourceLine=47)]
        public virtual void _04TwoFastElfsKillingTwoGoblinsInFirstTurn()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04 Two fast Elfs killing two Goblins in first turn", null, ((string[])(null)));
#line 48
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table7.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "5",
                        "10",
                        "Normal_Attack"});
            table7.AddRow(new string[] {
                        "Elf_B",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "5",
                        "10",
                        "Normal_Attack"});
            table7.AddRow(new string[] {
                        "Goblin_A",
                        "Goblin",
                        "10",
                        "10",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
            table7.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "10",
                        "10",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
#line 49
 testRunner.Given("The following characters", ((string)(null)), table7, "Given ");
#line 55
 testRunner.And("Character \'Elf_A\' is assigned to team \'A\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("Character \'Elf_B\' is assigned to team \'A\' on position \'Front_2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("Character \'Goblin_A\' is assigned to team \'B\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("Character \'Goblin_B\' is assigned to team \'B\' on position \'Front_2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.When("Fight between \'A\' and \'B\' starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table8.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "5",
                        "10",
                        "Normal_Attack"});
            table8.AddRow(new string[] {
                        "Elf_B",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "5",
                        "10",
                        "Normal_Attack"});
            table8.AddRow(new string[] {
                        "Goblin_A",
                        "Goblin",
                        "10",
                        "0",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
            table8.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "10",
                        "0",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
#line 60
 testRunner.Then("The following characters status is", ((string)(null)), table8, "Then ");
#line 66
 testRunner.And("Team \'A\' won", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("05 Fast Elf killing many Goblins and gets wounded", SourceLine=67)]
        public virtual void _05FastElfKillingManyGoblinsAndGetsWounded()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05 Fast Elf killing many Goblins and gets wounded", null, ((string[])(null)));
#line 68
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table9.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "4",
                        "10",
                        "Normal_Attack"});
            table9.AddRow(new string[] {
                        "Goblin_A",
                        "Goblin",
                        "10",
                        "10",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
            table9.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "10",
                        "10",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
            table9.AddRow(new string[] {
                        "Goblin_C",
                        "Goblin",
                        "10",
                        "10",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
            table9.AddRow(new string[] {
                        "Goblin_D",
                        "Goblin",
                        "10",
                        "10",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
#line 69
 testRunner.Given("The following characters", ((string)(null)), table9, "Given ");
#line 76
 testRunner.And("Character \'Elf_A\' is assigned to team \'A\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("Character \'Goblin_A\' is assigned to team \'B\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("Character \'Goblin_B\' is assigned to team \'B\' on position \'Front_2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("Character \'Goblin_C\' is assigned to team \'B\' on position \'Front_3\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("Character \'Goblin_D\' is assigned to team \'B\' on position \'Middle_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.When("Fight between \'A\' and \'B\' starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table10.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "14",
                        "10",
                        "4",
                        "10",
                        "Normal_Attack"});
            table10.AddRow(new string[] {
                        "Goblin_A",
                        "Goblin",
                        "10",
                        "0",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
            table10.AddRow(new string[] {
                        "Goblin_B",
                        "Goblin",
                        "10",
                        "0",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
            table10.AddRow(new string[] {
                        "Goblin_C",
                        "Goblin",
                        "10",
                        "0",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
            table10.AddRow(new string[] {
                        "Goblin_D",
                        "Goblin",
                        "10",
                        "0",
                        "5",
                        "0",
                        "5",
                        "Normal_Attack"});
#line 82
 testRunner.Then("The following characters status is", ((string)(null)), table10, "Then ");
#line 89
 testRunner.And("Team \'A\' won", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("06 Elf is not able to damage Human Palladin", SourceLine=90)]
        public virtual void _06ElfIsNotAbleToDamageHumanPalladin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06 Elf is not able to damage Human Palladin", null, ((string[])(null)));
#line 91
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table11.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "20",
                        "10",
                        "5",
                        "10",
                        "Normal_Attack"});
            table11.AddRow(new string[] {
                        "Human_B",
                        "Human",
                        "100",
                        "100",
                        "40",
                        "25",
                        "9",
                        "Normal_Attack"});
#line 92
 testRunner.Given("The following characters", ((string)(null)), table11, "Given ");
#line 96
 testRunner.And("Character \'Elf_A\' is assigned to team \'A\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("Character \'Human_B\' is assigned to team \'B\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.When("Fight between \'A\' and \'B\' starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table12.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "20",
                        "0",
                        "10",
                        "5",
                        "10",
                        "Normal_Attack"});
            table12.AddRow(new string[] {
                        "Human_B",
                        "Human",
                        "100",
                        "100",
                        "40",
                        "25",
                        "9",
                        "Normal_Attack"});
#line 99
 testRunner.Then("The following characters status is", ((string)(null)), table12, "Then ");
#line 103
 testRunner.And("Team \'B\' won", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
