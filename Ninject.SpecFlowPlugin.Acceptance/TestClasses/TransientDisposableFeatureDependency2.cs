namespace Ninject.SpecFlowPlugin.Acceptance.TestClasses
{
    using TechTalk.SpecFlow;

    public sealed class TransientDisposableFeatureDependency2 : ITransientDisposableFeatureDependency2
    {
        private readonly TestThreadContext testThreadContext;

        public TransientDisposableFeatureDependency2(TestThreadContext testThreadContext)
        {
            this.testThreadContext = testThreadContext;
        }

        public void Dispose()
        {
            this.testThreadContext.Save(true, ContextKeys.TransientDisposableFeatureDependency2IsDisposed);
        }
    }
}