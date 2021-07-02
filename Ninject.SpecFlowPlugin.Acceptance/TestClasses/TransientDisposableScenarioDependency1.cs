namespace Ninject.SpecFlowPlugin.Acceptance.TestClasses
{
    using TechTalk.SpecFlow;

    public sealed class TransientDisposableScenarioDependency1 : ITransientDisposableScenarioDependency1
    {
        private readonly FeatureContext featureContext;

        public TransientDisposableScenarioDependency1(FeatureContext featureContext)
        {
            this.featureContext = featureContext;
        }

        public void Dispose()
        {
            this.featureContext.Save(true, ContextKeys.TransientDisposableScenarioDependency1IsDisposed);
        }
    }
}