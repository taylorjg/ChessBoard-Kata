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
    [NUnit.Framework.DescriptionAttribute("Taking a piece.")]
    public partial class TakingAPiece_Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ChessBoard.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Taking a piece.", "In order to play chess\r\nAs a Player\r\nI want to be able to take the oppositions pi" +
                    "ece.", GenerationTargetLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Pawn at top.")]
        public virtual void PawnAtTop_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pawn at top.", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
testRunner.Given("I have a White Pawn at A8");
#line 8
testRunner.When("I try and move to A9");
#line 9
testRunner.Then("I should be warned of an illegal move message");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Knight heads off board")]
        public virtual void KnightHeadsOffBoard()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Knight heads off board", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
testRunner.Given("I have a Black knight at G8");
#line 13
testRunner.And("I have a White pawn at A1");
#line 14
testRunner.And("the pawn moves to A2");
#line 15
testRunner.When("I try and move to I7");
#line 16
testRunner.Then("I should be warned of an illegal move message");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Pawn moves legally.")]
        public virtual void PawnMovesLegally_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pawn moves legally.", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
testRunner.Given("I have a White Pawn at A7");
#line 20
testRunner.And("I have a Black knight at G8");
#line 21
testRunner.When("I try and move to A8");
#line 22
testRunner.Then("I should be shown \"Pawn to A8\"");
#line 23
testRunner.And("Pawn should be at A8");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Knight moves legally")]
        public virtual void KnightMovesLegally()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Knight moves legally", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
testRunner.Given("I have a Black knight at G8");
#line 27
testRunner.And("I have a White Pawn at A1");
#line 28
testRunner.And("the pawn moves to A2");
#line 29
testRunner.When("I try and move to H6");
#line 30
testRunner.Then("I should be shown \"Knight to H6\"");
#line 31
testRunner.And("Knight should be at H6");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Pawn Starts on home row.")]
        public virtual void PawnStartsOnHomeRow_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pawn Starts on home row.", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
testRunner.Given("the game has just started");
#line 40
testRunner.And("the Pawn is on B2");
#line 41
testRunner.And("the Knight is at G8");
#line 42
testRunner.When("I move to B3");
#line 43
testRunner.Then("I should be shown “Pawn to B3”");
#line 44
testRunner.And("Pawn should be at B3");
#line 46
testRunner.Given("the game has just started");
#line 47
testRunner.And("the Pawn is on E2");
#line 48
testRunner.And("the Knight is at G8");
#line 49
testRunner.When("I move to E4");
#line 50
testRunner.Then("I should be shown \"Pawn to E4\"");
#line 51
testRunner.And("Pawn should be at E4");
#line 53
testRunner.Given("the game has not just started");
#line 54
testRunner.And("the Pawn is on D2");
#line 55
testRunner.And("the Knight is at G8");
#line 56
testRunner.When("I move to D4");
#line 57
testRunner.Then("I should be shown \"Pawn cannot move 2 spaces unless it in the first round and is " +
                    "on the home row.\"");
#line 58
testRunner.And("Pawn should be at D2");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Pawn tries taking move when nothing to capture")]
        public virtual void PawnTriesTakingMoveWhenNothingToCapture()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pawn tries taking move when nothing to capture", ((string[])(null)));
#line 60
this.ScenarioSetup(scenarioInfo);
#line 61
testRunner.Given("I have a White Pawn at D7");
#line 62
testRunner.And("I have a Black knight at G8");
#line 63
testRunner.When("I move to C8");
#line 64
testRunner.Then("I should be shown \"Pawn cannot diagonally unless it is capturing a piece.\"");
#line 65
testRunner.And("Pawn should be at D7");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Moving the knight legally")]
        public virtual void MovingTheKnightLegally()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Moving the knight legally", ((string[])(null)));
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
testRunner.Given("I have a Black knight at D4");
#line 74
testRunner.And("I have a White pawn at A1");
#line 75
testRunner.And("the pawn moves to A2");
#line 76
testRunner.When("I move to F5");
#line 77
testRunner.Then("I should be shown \"Knight to F5\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Pawn Takes the Knight")]
        public virtual void PawnTakesTheKnight()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pawn Takes the Knight", ((string[])(null)));
#line 84
this.ScenarioSetup(scenarioInfo);
#line 85
testRunner.Given("I have a White Pawn at D3");
#line 86
testRunner.And("I have a Black knight at C4");
#line 87
testRunner.When("the pawn moves to C4");
#line 88
testRunner.Then("the knight should be taken");
#line 89
testRunner.And("the pawn should be at C4");
#line 90
testRunner.And("I should be shown \"Pawn takes Knight. Pawn wins\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Pawn collides with Knight.")]
        public virtual void PawnCollidesWithKnight_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pawn collides with Knight.", ((string[])(null)));
#line 92
this.ScenarioSetup(scenarioInfo);
#line 93
testRunner.Given("I have a White Pawn at C3");
#line 94
testRunner.And("I have a Black knight at C4");
#line 95
testRunner.When("the pawn moves to C4");
#line 96
testRunner.Then("the knight should be at C4");
#line 97
testRunner.And("the pawn should be at C3");
#line 98
testRunner.And("I should be shown \"Pawn collides with Knight. Draw\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Knight takes Pawn.")]
        public virtual void KnightTakesPawn_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Knight takes Pawn.", ((string[])(null)));
#line 101
this.ScenarioSetup(scenarioInfo);
#line 102
testRunner.Given("I have a Black knight at D6");
#line 103
testRunner.And("I have a White Pawn at F6");
#line 104
testRunner.And("the Pawn moves to F7");
#line 105
testRunner.When("I move to F7");
#line 106
testRunner.Then("the pawn should be taken");
#line 107
testRunner.And("I should be shown \"Knight takes Pawn. Knight Wins\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
