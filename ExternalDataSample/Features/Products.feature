Feature: Products


@DataSource:products.xlsx @DataSet:other_products
Scenario: The basket price is calculated correctly for other products
	Given the price of <product> is €<price>
	And the customer has put 1 piece of <product> in the basket
	When the basket price is calculated
	Then the basket price should be €<price>