@FunctionalTests
Feature: Verify Initiative Details

Background: Navigate To The Initiative Tab
	Given A user opens the initiative tab

@SmokeTests
Scenario: Verify Cost Reduction Initiative Details
	Then A user verifies the initiative details
	| Initiative Name           | Finance Approval Status | Initiative Type | Initiative Status | Initiative Category | Current Year Estimated Impact | Next Year Estimated Impact | Initiative Description | Created By    |
	| Cost Reduction Initiative | Needs Finance Approval  | Cost Reduction  | On Track          | SRT- Supplies       | 2021 Estimated $1M		  | 2022 Estimated $1.1M       | Cost Reduction         | Standart User |
	And A user verifies the created date

Scenario: Verify Revenue Increase Initiative Details
	When A user navigates to the revenue increase initiative page
	Then A user verifies the initiative details
	| Initiative Name             | Finance Approval Status | Initiative Type  | Initiative Status | Initiative Category | Current Year Estimated Impact | Next Year Estimated Impact | Initiative Description | Created By    |
	| Revenue Increase Initiative | Needs Finance Approval  | Revenue Increase | On Track          | SRT- LOS Strategy   | 2021 Estimated $560.6K	     | 2022 Estimated $675K       | Revenue Increase       | Standart User |
	And A user verifies the created date

Scenario: Verify Target Percent Initiative Details
	When A user navigates to the target percent initiative page
	Then A user verifies the initiative details
	| Initiative Name           | Finance Approval Status | Initiative Type | Initiative Status | Initiative Category  | Current Year Estimated Impact | Next Year Estimated Impact | Initiative Description | Created By    |
	| Target Percent Initiative | Approved by Finance     | Target Percent  | On Track          | Pharmacy Improvement | 2021 Estimated 6%             | 2022 5.3% of 7.5%          | Target Percent         | Standart User |
	And A user verifies the created date

Scenario: Verify Target Value Initiative Details
	When A user navigates to the target value initiative page
	Then A user verifies the initiative details
	| Initiative Name         | Finance Approval Status | Initiative Type | Initiative Status | Initiative Category		  | Current Year Estimated Impact | Next Year Estimated Impact | Initiative Description | Created By    |
	| Target Value Initiative | Approved by Finance     | Target Value    | On Track          | Revenue Cycle Improvement 	  | 2021 878.3K of 988.3K         | 2022 878.3K of 1.6M        | Target Value           | Standart User |
	And A user verifies the created date
