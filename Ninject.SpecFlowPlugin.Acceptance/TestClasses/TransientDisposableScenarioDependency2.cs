﻿namespace Ninject.SpecFlowPlugin.Acceptance.TestClasses
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
            // to check that this object has been disposed, we need to be outside of the scenario,
            // since the kernel disposer hook runs as the very last AfterScenario hook;
            // for that reason, we check it in the scenario context
            if (this.featureContext.Get<bool>(ContextKeys.MustDisposeTransientScenarioDependency2))
            {
                this.featureContext.Save(true, ContextKeys.TransientDisposableScenarioDependency2IsDisposed);
            }
        }
    }
}