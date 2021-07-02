namespace Ninject.SpecFlowPlugin.Acceptance.TestClasses
{
    using TechTalk.SpecFlow;

    public sealed class TransientDisposableScenarioDependency2 : ITransientDisposableScenarioDependency2
    {
        private readonly FeatureContext featureContext;

        public TransientDisposableScenarioDependency2(FeatureContext featureContext)
        {
            this.featureContext = featureContext;
        }

        public void Dispose()
        {
            this.featureContext.Save(true, ContextKeys.TransientDisposableScenarioDependency2IsDisposed);
        }
    }
}