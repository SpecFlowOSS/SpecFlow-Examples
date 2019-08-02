// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BookShop.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Xunit.TraitAttribute("Category", "automated")]
    public partial class US03_ShoppingCartFeature : Xunit.IClassFixture<US03_ShoppingCartFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "US03_ShopingCart.feature"
#line hidden
        
        public US03_ShoppingCartFeature(US03_ShoppingCartFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "US03 - Shopping cart", "\tAs a potential customer\r\n\tI want to collect books in a shopping cart\r\n\tSo that I" +
                    " can order several books at once.", ProgrammingLanguage.CSharp, new string[] {
                        "automated"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Author",
                        "Title",
                        "Price"});
            table6.AddRow(new string[] {
                        "Martin Fowler",
                        "Analysis Patterns",
                        "50.20"});
            table6.AddRow(new string[] {
                        "Eric Evans",
                        "Domain Driven Design",
                        "46.34"});
            table6.AddRow(new string[] {
                        "Ted Pattison",
                        "Inside Windows SharePoint Services",
                        "31.49"});
            table6.AddRow(new string[] {
                        "Gojko Adzic",
                        "Bridging the Communication Gap",
                        "24.75"});
#line 8
 testRunner.Given("the following books", ((string)(null)), table6, "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Books can be placed into shopping cart")]
        [Xunit.TraitAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Xunit.TraitAttribute("Description", "Books can be placed into shopping cart")]
        public virtual void BooksCanBePlacedIntoShoppingCart()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Books can be placed into shopping cart", null, ((string[])(null)));
#line 16
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
this.FeatureBackground();
#line 17
 testRunner.Given("I have a shopping cart with: \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.When("I place \'Domain Driven Design\' into the shopping cart", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("my shopping cart should contain 2 types of items", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("my shopping cart should contain 1 copy of \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("my shopping cart should contain 1 copy of \'Domain Driven Design\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Shopping cart should show total number of items and total price")]
        [Xunit.TraitAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Xunit.TraitAttribute("Description", "Shopping cart should show total number of items and total price")]
        public virtual void ShoppingCartShouldShowTotalNumberOfItemsAndTotalPrice()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Shopping cart should show total number of items and total price", null, ((string[])(null)));
#line 24
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
this.FeatureBackground();
#line 25
 testRunner.Given("I have a shopping cart with: \'Analysis Patterns\', \'Domain Driven Design\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.When("I place \'Analysis Patterns\' into the shopping cart", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
 testRunner.Then("my shopping cart should contain 2 types of items", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
 testRunner.And("my shopping cart should contain 3 items in total", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("my shopping cart should show a total price of 146.74", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="The shopping cart should be initially empty")]
        [Xunit.TraitAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Xunit.TraitAttribute("Description", "The shopping cart should be initially empty")]
        public virtual void TheShoppingCartShouldBeInitiallyEmpty()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The shopping cart should be initially empty", null, ((string[])(null)));
#line 32
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
this.FeatureBackground();
#line 33
 testRunner.When("I enter the shop", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.Then("my shopping cart should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="A type of book can be entirely removed from the shopping cart")]
        [Xunit.TraitAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Xunit.TraitAttribute("Description", "A type of book can be entirely removed from the shopping cart")]
        public virtual void ATypeOfBookCanBeEntirelyRemovedFromTheShoppingCart()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A type of book can be entirely removed from the shopping cart", null, ((string[])(null)));
#line 37
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
this.FeatureBackground();
#line 38
 testRunner.Given("I have a shopping cart with: \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.When("I delete \'Analysis Patterns\' from the shopping cart", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
 testRunner.Then("my shopping cart should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Adding the same book to shopping cart again should increase quantity")]
        [Xunit.TraitAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Xunit.TraitAttribute("Description", "Adding the same book to shopping cart again should increase quantity")]
        public virtual void AddingTheSameBookToShoppingCartAgainShouldIncreaseQuantity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adding the same book to shopping cart again should increase quantity", null, ((string[])(null)));
#line 43
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
this.FeatureBackground();
#line 44
 testRunner.Given("I have a shopping cart with: \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.When("I place \'Analysis Patterns\' into the shopping cart", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.Then("my shopping cart should contain 1 type of item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.And("my shopping cart should contain 2 copies of \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Quantity of a book can be changed")]
        [Xunit.TraitAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Xunit.TraitAttribute("Description", "Quantity of a book can be changed")]
        public virtual void QuantityOfABookCanBeChanged()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Quantity of a book can be changed", null, ((string[])(null)));
#line 50
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
this.FeatureBackground();
#line 51
 testRunner.Given("I have a shopping cart with: \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
 testRunner.When("I change the quantity of \'Analysis Patterns\' to 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.Then("my shopping cart should contain 1 type of item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
 testRunner.And("my shopping cart should contain 3 copies of \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Changing quantity of book to 0 should remove book from shopping cart")]
        [Xunit.TraitAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Xunit.TraitAttribute("Description", "Changing quantity of book to 0 should remove book from shopping cart")]
        public virtual void ChangingQuantityOfBookTo0ShouldRemoveBookFromShoppingCart()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Changing quantity of book to 0 should remove book from shopping cart", null, ((string[])(null)));
#line 57
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
this.FeatureBackground();
#line 58
 testRunner.Given("I have a shopping cart with: \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
 testRunner.When("I change the quantity of \'Analysis Patterns\' to 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
 testRunner.Then("my shopping cart should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                US03_ShoppingCartFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                US03_ShoppingCartFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
