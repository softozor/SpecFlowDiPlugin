namespace Ninject.SpecFlowPlugin.Acceptance.TestClasses
{
    using TechTalk.SpecFlow;

    public sealed class SingletonDisposableScenarioDependency1 : ISingletonDisposableScenarioDependency1
    {
        private readonly FeatureContext featureContext;

        public SingletonDisposableScenarioDependency1(FeatureContext featureContext)
        {
            this.featureContext = featureContext;
        }

        public void Dispose()
        {
            // to check that this object has been disposed, we need to be outside of the scenario,
            // since the kernel disposer hook runs as the very last AfterScenario hook;
            // for that reason, we check it in the feature context
            if (this.featureContext.Get<bool>(ContextKeys.MustDisposeSingletonScenarioDependency1))
            {
                this.featureContext.Save(true, ContextKeys.SingletonDisposableScenarioDependency1IsDisposed);
            }
        }
    }
}