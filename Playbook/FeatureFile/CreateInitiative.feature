@FunctionalTests
Feature: Create Initiative

Background: Navigate To The Initiative Modal
	Given A user opens the initiative modal

@SmokeTests
Scenario: Create Cost Reduction Initiative
	When A user enters the initiative details
	| Initiative Name           | Description    | Current Year Estimated Impact | Next Year Estimated Impact | Custom Milestone Name | Initiative Category |
	| Cost Reduction Initiative | Cost Reduction | 1000000			     | 1125580		          | Capacity Utilization  | SRT- Supplies       |
	Then A user verifies the the initiative has been created

Scenario: Create Revenue Increase Initiative
	Given A user selects revenue increase initiative type
	When A user enters the initiative details
	| Initiative Name             | Description      | Current Year Estimated Impact | Next Year Estimated Impact | Custom Milestone Name | Initiative Category |
	| Revenue Increase Initiative | Revenue Increase | 560595			 | 675000		      | Budget Variance       | SRT- LOS Strategy   |
	Then A user verifies the the initiative has been created

Scenario: Create Target Percent Initiative
	Given A user selects target percent initiative type
	When A user enters the initiative details
	| Initiative Name           | Description    | Current Year Estimated Impact | Next Year Estimated Impact | Custom Milestone Name        | Initiative Category  |
	| Target Percent Initiative | Target Percent | 6			     | 7.5			  | Process / Practice Variation | Pharmacy Improvement |
	Then A user verifies the the initiative has been created

Scenario: Create Target Value Initiative
	Given A user selects target value initiative type
	When A user enters the initiative details
	| Initiative Name           | Description  | Current Year Estimated Impact | Next Year Estimated Impact | Custom Milestone Name | Initiative Category       |
	| Target Value Initiative   | Target Value | 1550000			   | 988255			| Root Cause Analysis   | Revenue Cycle Improvement |
	Then A user verifies the the initiative has been created
