namespace Ninject.SpecFlowPlugin.Acceptance.TestClasses
{
    using TechTalk.SpecFlow;

    public sealed class SingletonDisposableScenarioDependency2 : ISingletonDisposableScenarioDependency2
    {
        private readonly FeatureContext featureContext;

        public SingletonDisposableScenarioDependency2(FeatureContext featureContext)
        {
            this.featureContext = featureContext;
        }

        public void Dispose()
        {
            // to check that this object has been disposed, we need to be outside of the scenario,
            // since the kernel disposer hook runs as the very last AfterScenario hook;
            // for that reason, we check it in the feature context
            if (this.featureContext.Get<bool>(ContextKeys.MustDisposeSingletonScenarioDependency2))
            {
                this.featureContext.Save(true, ContextKeys.SingletonDisposableScenarioDependency2IsDisposed);
            }
        }
    }
}