Feature: BuyEnergy

Feature to demonstrate automation of the ENSEK buy energy function

@ENS_FUNC_BUY01
Scenario: User is able to buy Energy units when units < available.
	Given I Have Logged In To The ENSEK URL "https://ensekautomationcandidatetest.azurewebsites.net"
	And I Want To Purchase Energy
	| EnergyType | Units |
	| Gas        | 1000  |
	When I Click Buy Energy
	Then And I Input Number of Units 
	And Click The Buy Button
	Then My Transaction Is Confirmed
