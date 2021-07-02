namespace Ninject.SpecFlowPlugin.Acceptance.TestClasses
{
    using TechTalk.SpecFlow;

    public sealed class TransientDisposableFeatureDependency1 : ITransientDisposableFeatureDependency1
    {
        private readonly TestThreadContext testThreadContext;

        public TransientDisposableFeatureDependency1(TestThreadContext testThreadContext)
        {
            this.testThreadContext = testThreadContext;
        }

        public void Dispose()
        {
            this.testThreadContext.Save(true, ContextKeys.TransientDisposableFeatureDependency1IsDisposed);
        }
    }
}