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
namespace ConstructionYard.Completed
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Range Attack Skill", SourceFile="Completed\\RangeAttackSkill.feature", SourceLine=0)]
    public partial class RangeAttackSkillFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RangeAttackSkill.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Range Attack Skill", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [TechTalk.SpecRun.ScenarioAttribute("01 Range attack should hit character on mid lane", new string[] {
                "mytag"}, SourceLine=3)]
        public virtual void _01RangeAttackShouldHitCharacterOnMidLane()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 Range attack should hit character on mid lane", null, new string[] {
                        "mytag"});
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Min_Att",
                        "Max_Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table1.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "30",
                        "30",
                        "30",
                        "30",
                        "0",
                        "10",
                        "Range_One_First"});
            table1.AddRow(new string[] {
                        "Troll_A",
                        "Troll",
                        "30",
                        "30",
                        "15",
                        "15",
                        "0",
                        "5",
                        ""});
            table1.AddRow(new string[] {
                        "Troll_B",
                        "Troll",
                        "30",
                        "30",
                        "30",
                        "30",
                        "0",
                        "5",
                        ""});
#line 5
 testRunner.Given("The following characters", ((string)(null)), table1, "Given ");
#line 10
 testRunner.And("Character \'Elf_A\' is assigned to team \'A\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("Character \'Troll_A\' is assigned to team \'B\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("Character \'Troll_B\' is assigned to team \'B\' on position \'Middle_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("Fight between \'A\' and \'B\' starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("Team \'A\' won", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Action_Order",
                        "Attacker_ID",
                        "Attacker_Position",
                        "Defender_ID",
                        "Defender_Position",
                        "Defender_New_Hp",
                        "Attacker_DMG_dealt"});
            table2.AddRow(new string[] {
                        "1",
                        "Elf_A",
                        "Front_1",
                        "Troll_B",
                        "Middle_1",
                        "0",
                        "30"});
            table2.AddRow(new string[] {
                        "2",
                        "Troll_A",
                        "Front_1",
                        "Elf_A",
                        "Front_1",
                        "15",
                        "15"});
            table2.AddRow(new string[] {
                        "3",
                        "Elf_A",
                        "Front_1",
                        "Troll_A",
                        "Front_1",
                        "0",
                        "30"});
#line 15
 testRunner.And("Replay acctions are", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 Range attack should hit character on rear lane", SourceLine=20)]
        public virtual void _02RangeAttackShouldHitCharacterOnRearLane()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 Range attack should hit character on rear lane", null, ((string[])(null)));
#line 21
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
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
                        "Elf_A",
                        "Elf",
                        "30",
                        "30",
                        "30",
                        "30",
                        "0",
                        "10",
                        "Range_One_First"});
            table3.AddRow(new string[] {
                        "Troll_A",
                        "Troll",
                        "30",
                        "30",
                        "15",
                        "15",
                        "0",
                        "5",
                        ""});
            table3.AddRow(new string[] {
                        "Troll_B",
                        "Troll",
                        "30",
                        "30",
                        "30",
                        "30",
                        "0",
                        "5",
                        ""});
#line 22
 testRunner.Given("The following characters", ((string)(null)), table3, "Given ");
#line 27
 testRunner.And("Character \'Elf_A\' is assigned to team \'A\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("Character \'Troll_A\' is assigned to team \'B\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("Character \'Troll_B\' is assigned to team \'B\' on position \'Rear_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.When("Fight between \'A\' and \'B\' starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.Then("Team \'A\' won", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Action_Order",
                        "Attacker_ID",
                        "Attacker_Position",
                        "Defender_ID",
                        "Defender_Position",
                        "Defender_New_Hp",
                        "Attacker_DMG_dealt"});
            table4.AddRow(new string[] {
                        "1",
                        "Elf_A",
                        "Front_1",
                        "Troll_B",
                        "Rear_1",
                        "0",
                        "30"});
            table4.AddRow(new string[] {
                        "2",
                        "Troll_A",
                        "Front_1",
                        "Elf_A",
                        "Front_1",
                        "15",
                        "15"});
            table4.AddRow(new string[] {
                        "3",
                        "Elf_A",
                        "Front_1",
                        "Troll_A",
                        "Front_1",
                        "0",
                        "30"});
#line 32
 testRunner.And("Replay acctions are", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("03 Range attack should hit character on mid lane then rear lane and front at the " +
            "end", SourceLine=37)]
        public virtual void _03RangeAttackShouldHitCharacterOnMidLaneThenRearLaneAndFrontAtTheEnd()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03 Range attack should hit character on mid lane then rear lane and front at the " +
                    "end", null, ((string[])(null)));
#line 38
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
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
                        "61",
                        "61",
                        "30",
                        "30",
                        "0",
                        "10",
                        "Range_One_First"});
            table5.AddRow(new string[] {
                        "Troll_F",
                        "Troll",
                        "30",
                        "30",
                        "15",
                        "15",
                        "0",
                        "5",
                        ""});
            table5.AddRow(new string[] {
                        "Troll_M",
                        "Troll",
                        "30",
                        "30",
                        "30",
                        "30",
                        "0",
                        "5",
                        ""});
            table5.AddRow(new string[] {
                        "Troll_R",
                        "Troll",
                        "30",
                        "30",
                        "30",
                        "30",
                        "0",
                        "5",
                        ""});
#line 39
 testRunner.Given("The following characters", ((string)(null)), table5, "Given ");
#line 45
 testRunner.And("Character \'Elf_A\' is assigned to team \'A\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("Character \'Troll_F\' is assigned to team \'B\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("Character \'Troll_M\' is assigned to team \'B\' on position \'Middle_2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("Character \'Troll_R\' is assigned to team \'B\' on position \'Rear_3\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.When("Fight between \'A\' and \'B\' starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
 testRunner.Then("Team \'A\' won", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Action_Order",
                        "Attacker_ID",
                        "Attacker_Position",
                        "Defender_ID",
                        "Defender_Position",
                        "Defender_New_Hp",
                        "Attacker_DMG_dealt"});
            table6.AddRow(new string[] {
                        "1",
                        "Elf_A",
                        "Front_1",
                        "Troll_M",
                        "Middle_2",
                        "0",
                        "30"});
            table6.AddRow(new string[] {
                        "2",
                        "Troll_F",
                        "Front_1",
                        "Elf_A",
                        "Front_1",
                        "46",
                        "15"});
            table6.AddRow(new string[] {
                        "3",
                        "Troll_R",
                        "Rear_3",
                        "Elf_A",
                        "Front_1",
                        "16",
                        "30"});
            table6.AddRow(new string[] {
                        "4",
                        "Elf_A",
                        "Front_1",
                        "Troll_R",
                        "Rear_3",
                        "0",
                        "30"});
            table6.AddRow(new string[] {
                        "5",
                        "Troll_F",
                        "Front_1",
                        "Elf_A",
                        "Front_1",
                        "1",
                        "15"});
            table6.AddRow(new string[] {
                        "6",
                        "Elf_A",
                        "Front_1",
                        "Troll_F",
                        "Front_1",
                        "0",
                        "30"});
#line 51
 testRunner.And("Replay acctions are", ((string)(null)), table6, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("04 Range attack should hit first character on middle lane", SourceLine=59)]
        public virtual void _04RangeAttackShouldHitFirstCharacterOnMiddleLane()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04 Range attack should hit first character on middle lane", null, ((string[])(null)));
#line 60
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Min_Att",
                        "Max_Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table7.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "31",
                        "31",
                        "40",
                        "40",
                        "0",
                        "10",
                        "Range_One_First"});
            table7.AddRow(new string[] {
                        "Troll_M1",
                        "Troll",
                        "40",
                        "40",
                        "15",
                        "15",
                        "0",
                        "5",
                        ""});
            table7.AddRow(new string[] {
                        "Troll_M3",
                        "Troll",
                        "30",
                        "30",
                        "30",
                        "30",
                        "0",
                        "5",
                        ""});
#line 61
 testRunner.Given("The following characters", ((string)(null)), table7, "Given ");
#line 66
 testRunner.And("Character \'Elf_A\' is assigned to team \'A\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("Character \'Troll_M1\' is assigned to team \'B\' on position \'Middle_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("Character \'Troll_M3\' is assigned to team \'B\' on position \'Middle_3\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.When("Fight between \'A\' and \'B\' starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
 testRunner.Then("Team \'A\' won", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Action_Order",
                        "Attacker_ID",
                        "Attacker_Position",
                        "Defender_ID",
                        "Defender_Position",
                        "Defender_New_Hp",
                        "Attacker_DMG_dealt"});
            table8.AddRow(new string[] {
                        "1",
                        "Elf_A",
                        "Front_1",
                        "Troll_M1",
                        "Middle_1",
                        "0",
                        "40"});
            table8.AddRow(new string[] {
                        "2",
                        "Troll_M3",
                        "Middle_3",
                        "Elf_A",
                        "Front_1",
                        "1",
                        "30"});
            table8.AddRow(new string[] {
                        "3",
                        "Elf_A",
                        "Front_1",
                        "Troll_M3",
                        "Middle_3",
                        "0",
                        "30"});
#line 71
 testRunner.And("Replay acctions are", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("05 Range attack aiming for low Hp should hit first character with lowest hp on mi" +
            "ddle lane", SourceLine=77)]
        public virtual void _05RangeAttackAimingForLowHpShouldHitFirstCharacterWithLowestHpOnMiddleLane()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05 Range attack aiming for low Hp should hit first character with lowest hp on mi" +
                    "ddle lane", null, ((string[])(null)));
#line 78
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Min_Att",
                        "Max_Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table9.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "31",
                        "31",
                        "40",
                        "40",
                        "0",
                        "10",
                        "Range_One_LowHp"});
            table9.AddRow(new string[] {
                        "Troll_M1",
                        "Troll",
                        "40",
                        "40",
                        "15",
                        "15",
                        "0",
                        "5",
                        ""});
            table9.AddRow(new string[] {
                        "Troll_M3",
                        "Troll",
                        "30",
                        "30",
                        "30",
                        "30",
                        "0",
                        "5",
                        ""});
#line 79
 testRunner.Given("The following characters", ((string)(null)), table9, "Given ");
#line 84
 testRunner.And("Character \'Elf_A\' is assigned to team \'A\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And("Character \'Troll_M1\' is assigned to team \'B\' on position \'Middle_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And("Character \'Troll_M3\' is assigned to team \'B\' on position \'Middle_3\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.When("Fight between \'A\' and \'B\' starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
 testRunner.Then("Team \'A\' won", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Action_Order",
                        "Attacker_ID",
                        "Attacker_Position",
                        "Defender_ID",
                        "Defender_Position",
                        "Defender_New_Hp",
                        "Attacker_DMG_dealt"});
            table10.AddRow(new string[] {
                        "1",
                        "Elf_A",
                        "Front_1",
                        "Troll_M3",
                        "Middle_3",
                        "0",
                        "30"});
            table10.AddRow(new string[] {
                        "2",
                        "Troll_M1",
                        "Middle_1",
                        "Elf_A",
                        "Front_1",
                        "16",
                        "15"});
            table10.AddRow(new string[] {
                        "3",
                        "Elf_A",
                        "Front_1",
                        "Troll_M1",
                        "Middle_1",
                        "0",
                        "40"});
#line 89
 testRunner.And("Replay acctions are", ((string)(null)), table10, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("06 Range attack aiming for low Hp should hit character on mid lane", SourceLine=95)]
        public virtual void _06RangeAttackAimingForLowHpShouldHitCharacterOnMidLane()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06 Range attack aiming for low Hp should hit character on mid lane", null, ((string[])(null)));
#line 96
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "Name",
                        "MaxHp",
                        "Hp",
                        "Min_Att",
                        "Max_Att",
                        "Def",
                        "Speed",
                        "Skills"});
            table11.AddRow(new string[] {
                        "Elf_A",
                        "Elf",
                        "30",
                        "30",
                        "30",
                        "30",
                        "0",
                        "10",
                        "Range_One_LowHp"});
            table11.AddRow(new string[] {
                        "Troll_A",
                        "Troll",
                        "30",
                        "30",
                        "15",
                        "15",
                        "0",
                        "5",
                        ""});
            table11.AddRow(new string[] {
                        "Troll_B",
                        "Troll",
                        "30",
                        "30",
                        "30",
                        "30",
                        "0",
                        "5",
                        ""});
#line 97
 testRunner.Given("The following characters", ((string)(null)), table11, "Given ");
#line 102
 testRunner.And("Character \'Elf_A\' is assigned to team \'A\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.And("Character \'Troll_A\' is assigned to team \'B\' on position \'Front_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.And("Character \'Troll_B\' is assigned to team \'B\' on position \'Middle_1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.When("Fight between \'A\' and \'B\' starts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
 testRunner.Then("Team \'A\' won", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Action_Order",
                        "Attacker_ID",
                        "Attacker_Position",
                        "Defender_ID",
                        "Defender_Position",
                        "Defender_New_Hp",
                        "Attacker_DMG_dealt"});
            table12.AddRow(new string[] {
                        "1",
                        "Elf_A",
                        "Front_1",
                        "Troll_B",
                        "Middle_1",
                        "0",
                        "30"});
            table12.AddRow(new string[] {
                        "2",
                        "Troll_A",
                        "Front_1",
                        "Elf_A",
                        "Front_1",
                        "15",
                        "15"});
            table12.AddRow(new string[] {
                        "3",
                        "Elf_A",
                        "Front_1",
                        "Troll_A",
                        "Front_1",
                        "0",
                        "30"});
#line 107
 testRunner.And("Replay acctions are", ((string)(null)), table12, "And ");
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
