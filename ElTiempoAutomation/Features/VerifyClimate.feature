Feature: Verify Climate

Tests to verify the climate according to zone and daytime

@ClimateByZoneAndHour
Scenario Outline: Verify Climate at certain hour
	Given climate page is open
	When I search for <City>
	And I select <Zone> zone
	And I select <Time> hour
	Then Information related to the zone and hour will be shown
	Examples: 
	|City			| Zone					| Time		|
	|"Madrid"		|"Las Rozas de Madrid"	|"23:00"	|
	|"Madrid"		|"Las Rozas de Madrid"	|"19:30"	|