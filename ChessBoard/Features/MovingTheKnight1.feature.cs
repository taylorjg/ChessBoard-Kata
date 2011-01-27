// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.4.0.0
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace ChessBoard.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Moving the Knight.")]
    public partial class MovingTheKnight_Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "MovingTheKnight.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Moving the Knight.", "In order to play chess\r\nAs a Player\r\nI want to move the Knight legally.", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Moving the knight legally")]
        public virtual void MovingTheKnightLegally()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Moving the knight legally", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
testRunner.Given("I have a Black knight at D4");
#line 8
testRunner.And("I have a White pawn at A1");
#line 9
testRunner.And("I move the Pawn to A2");
#line 10
testRunner.When("I move the Knight to F5");
#line 11
testRunner.Then("I should be shown \"Knight to F5\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void IllegalMove(string position)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Illegal Move", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
testRunner.Given("I have a Black knight at D4");
#line 16
testRunner.And("the valid moves are B3,B5,C2,C6,E2,E6,F3,F5");
#line 17
testRunner.And("I have a White pawn at A1");
#line 18
testRunner.And("I move the Pawn to A2");
#line 19
testRunner.When(string.Format("I move the Knight to {0}", position));
#line 20
testRunner.Then("I should be shown \"Illegal Move\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_A1()
        {
            this.IllegalMove("A1");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_A2()
        {
            this.IllegalMove("A2");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_A3()
        {
            this.IllegalMove("A3");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_A4()
        {
            this.IllegalMove("A4");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_A5()
        {
            this.IllegalMove("A5");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_A6()
        {
            this.IllegalMove("A6");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_A7()
        {
            this.IllegalMove("A7");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_A8()
        {
            this.IllegalMove("A8");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_B1()
        {
            this.IllegalMove("B1");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_B2()
        {
            this.IllegalMove("B2");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_B4()
        {
            this.IllegalMove("B4");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_B6()
        {
            this.IllegalMove("B6");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_B7()
        {
            this.IllegalMove("B7");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_B8()
        {
            this.IllegalMove("B8");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_C1()
        {
            this.IllegalMove("C1");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_C3()
        {
            this.IllegalMove("C3");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_C4()
        {
            this.IllegalMove("C4");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_C5()
        {
            this.IllegalMove("C5");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_C7()
        {
            this.IllegalMove("C7");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_C8()
        {
            this.IllegalMove("C8");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_D1()
        {
            this.IllegalMove("D1");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_D2()
        {
            this.IllegalMove("D2");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_D3()
        {
            this.IllegalMove("D3");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_D4()
        {
            this.IllegalMove("D4");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_D5()
        {
            this.IllegalMove("D5");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_D6()
        {
            this.IllegalMove("D6");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_D7()
        {
            this.IllegalMove("D7");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_D8()
        {
            this.IllegalMove("D8");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_E1()
        {
            this.IllegalMove("E1");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_E3()
        {
            this.IllegalMove("E3");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_E4()
        {
            this.IllegalMove("E4");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_E5()
        {
            this.IllegalMove("E5");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_E7()
        {
            this.IllegalMove("E7");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_E8()
        {
            this.IllegalMove("E8");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_F1()
        {
            this.IllegalMove("F1");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_F2()
        {
            this.IllegalMove("F2");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_F4()
        {
            this.IllegalMove("F4");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_F6()
        {
            this.IllegalMove("F6");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_F7()
        {
            this.IllegalMove("F7");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_F8()
        {
            this.IllegalMove("F8");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_G1()
        {
            this.IllegalMove("G1");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_G2()
        {
            this.IllegalMove("G2");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_G3()
        {
            this.IllegalMove("G3");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_G4()
        {
            this.IllegalMove("G4");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_G5()
        {
            this.IllegalMove("G5");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_G6()
        {
            this.IllegalMove("G6");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_G7()
        {
            this.IllegalMove("G7");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_G8()
        {
            this.IllegalMove("G8");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_H1()
        {
            this.IllegalMove("H1");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_H2()
        {
            this.IllegalMove("H2");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_H3()
        {
            this.IllegalMove("H3");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_H4()
        {
            this.IllegalMove("H4");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_H5()
        {
            this.IllegalMove("H5");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_H6()
        {
            this.IllegalMove("H6");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_H7()
        {
            this.IllegalMove("H7");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Illegal Move")]
        public virtual void IllegalMove_Positions_H8()
        {
            this.IllegalMove("H8");
        }
    }
}
#endregion