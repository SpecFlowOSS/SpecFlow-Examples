@Performance
Feature: ParallelizationPerformance



Scenario Outline: Performance for different TestThreadIsolation
	Given I have a test project 'SpecRun.TestProject'
	And I have a feature file with <Scenario Count> passing scenarios each with a duration of '<Duration per Scenario>' milliseconds
	And it is configured for '<Threads>' threads

	And it is configured for '<TestThreadIsolation>' as TestThreadIsolation

	When I execute the tests

	Then the test runtime should be lesser than '<Max Duration>' seconds

Examples: 
	| Name                     | TestThreadIsolation | Scenario Count | Duration per Scenario | Threads | Max Duration |
	| SharedAppDomain 1000/10  | SharedAppDomain     | 1000           | 10                    | 10      | 4            |
	| AppDomain 1000/10        | AppDomain           | 1000           | 10                    | 10      | 6            |
	| Process 1000/10          | Process             | 1000           | 10                    | 10      | 12           |
	| SharedAppDomain 10000/10 | SharedAppDomain     | 10000          | 10                    | 10      | 66           |
	| AppDomain 10000/10       | AppDomain           | 10000          | 10                    | 10      | 66           |
	| Process 10000/10         | Process             | 10000          | 10                    | 10      | 120          |
	| SharedAppDomain 1000/5   | SharedAppDomain     | 1000           | 10                    | 5       | 8            |
	| AppDomain 1000/5         | AppDomain           | 1000           | 10                    | 5       | 12           |
	| Process 1000/5           | Process             | 1000           | 10                    | 5       | 24           |
	| SharedAppDomain 10000/5  | SharedAppDomain     | 10000          | 10                    | 5       | 66           |
	| AppDomain 10000/5        | AppDomain           | 10000          | 10                    | 5       | 124          |
	| Process 10000/5          | Process             | 10000          | 10                    | 5       | 220          |
	| SharedAppDomain 1000/50  | SharedAppDomain     | 1000           | 10                    | 50      | 8            |
	| AppDomain 1000/50        | AppDomain           | 1000           | 10                    | 50      | 12           |
	| Process 1000/50          | Process             | 1000           | 10                    | 50      | 27           |
	| SharedAppDomain 10000/50 | SharedAppDomain     | 10000          | 10                    | 50      | 99           |
	| AppDomain 10000/50       | AppDomain           | 10000          | 10                    | 50      | 124          |
	| Process 10000/50         | Process             | 10000          | 10                    | 50      | 220          |
	| SharedAppDomain 100/50   | SharedAppDomain     | 100            | 10                    | 50      | 8            |
	| AppDomain 100/50         | AppDomain           | 100            | 10                    | 50      | 12           |
	| Process 100/50           | Process             | 100            | 10                    | 50      | 220          |


Scenario Outline: Performance for different TestThreadIsolation in Console Runner
	Given I have a test project 'SpecRun.TestProject'
	And I have a feature file with <Scenario Count> passing scenarios each with a duration of '<Duration per Scenario>' milliseconds
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Execution testThreadCount="50" />
			<Environment testThreadIsolation="SharedAppDomain" />
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
        """

	When I execute the tests through the console runner 

	Then the console runner runtime should be lesser than '<Max Duration>' seconds

Examples: 
	| Name                     | TestThreadIsolation | Scenario Count | Duration per Scenario | Threads | Max Duration |
#	| SharedAppDomain 1000/10  | SharedAppDomain     | 1000           | 10                    | 10      | 4            |
	#| AppDomain 1000/10        | AppDomain           | 1000           | 10                    | 10      | 6            |
	#| Process 1000/10          | Process             | 1000           | 10                    | 10      | 12           |
#	| SharedAppDomain 10000/10 | SharedAppDomain     | 10000          | 10                    | 10      | 33           |
	#| AppDomain 10000/10       | AppDomain           | 10000          | 10                    | 10      | 62           |
	#| Process 10000/10         | Process             | 10000          | 10                    | 10      | 110          |
#	| SharedAppDomain 1000/5   | SharedAppDomain     | 1000           | 10                    | 5       | 8            |
	#| AppDomain 1000/5         | AppDomain           | 1000           | 10                    | 5       | 12           |
	#| Process 1000/5           | Process             | 1000           | 10                    | 5       | 24           |
#	| SharedAppDomain 10000/5  | SharedAppDomain     | 10000          | 10                    | 5       | 66           |
	#| AppDomain 10000/5        | AppDomain           | 10000          | 10                    | 5       | 124          |
	#| Process 10000/5          | Process             | 10000          | 10                    | 5       | 220          |
	| SharedAppDomain 1000/50  | SharedAppDomain     | 1000           | 10                    | 50      | 8            |
	#| AppDomain 1000/50        | AppDomain           | 1000           | 10                    | 50      | 12           |
	#| Process 1000/50          | Process             | 1000           | 10                    | 50      | 24           |
	| SharedAppDomain 10000/50 | SharedAppDomain     | 10000          | 10                    | 50      | 110           |
	#| AppDomain 10000/50       | AppDomain           | 10000          | 10                    | 50      | 124          |
	#| Process 10000/50         | Process             | 10000          | 10                    | 50      | 220          |
	| SharedAppDomain 100/50   | SharedAppDomain     | 100            | 10                    | 50      | 8            |
	#| AppDomain 100/50         | AppDomain           | 100            | 10                    | 50      | 12           |
	#| Process 100/50           | Process             | 100            | 10                    | 50      | 220          |

