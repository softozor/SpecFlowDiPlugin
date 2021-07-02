﻿Feature: Feature Dependencies

As a tester,
I need to inject feature dependencies in my scenarios step definition classes,
so that I can access them.

    Scenario: Injected transient feature dependencies are different in all SpecFlow bindings

    A transient dependency is an object that is created anew each time it is
    being resolved. Changes in such objects made in a given SpecFlow binding
    should not be seen in another SpecFlow binding.

        Given I have injected TransientFeatureDependency in the binding class StepClass1
        And the property MyProp of TransientFeatureDependency has value 'value1' in StepClass1
        And I have injected TransientFeatureDependency in the binding class StepClass2
        When I set property MyProp of TransientFeatureDependency to 'value2' in StepClass2
        Then the property MyProp of TransientFeatureDependency has value 'value1' in StepClass1

    Scenario Outline: Injected transient feature dependencies are created anew in all scenarios

    Each time a transient feature dependency is injected in a binding class, we get a new
    instance of that class. We might expect that the transient feature dependency be transient
    over the features only, i.e. scenarios of the same feature would get the same instance, while
    scenarios of different features would get different instances. However, in our implementation
    does not put the feature container in a feature scope. This is the same behavior as with BoDi
    when the feature dependency is registered as InstancePerDependency in the feature container.
    See how TransientFeatureDependency is registered in Hooks.DependenciesConfigurator.SetupFeatureContainer.

        Given I have injected TransientFeatureDependency in the binding class StepClass1
        Then the property MyProp of TransientFeatureDependency has no value in StepClass1
        When I set property MyProp of TransientFeatureDependency to value '<value>' in StepClass1

        Examples:

          | value      |
          | irrelevant |
          | irrelevant |

    Scenario: Injected singleton feature dependencies are the same in all SpecFlow bindings

        Given I have injected SingletonFeatureDependency in the binding class StepClass1
        And I have injected SingletonFeatureDependency in the binding class StepClass2
        When I set property MyProp of SingletonFeatureDependency to 'value' in StepClass1
        Then the property MyProp of SingletonFeatureDependency has value 'value' in StepClass2

    Scenario Outline: Injected singleton feature dependencies are the same in all scenarios

        Given I have injected SingletonFeatureDependency in the binding class StepClass1
        Then the property MyProp of SingletonFeatureDependency has value '<read value>' in StepClass1 if the previous scenario set it
        When I set property MyProp of SingletonFeatureDependency to value '<written value>' in StepClass1

        Examples:

          | read value | written value |
          | irrelevant | value         |
          | value      | irrelevant    |