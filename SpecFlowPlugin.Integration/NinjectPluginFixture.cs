﻿namespace SpecFlowPlugin.Integration
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using FluentAssertions;
    using Moq;
    using Ninject.SpecFlowPlugin;
    using NUnit.Framework;
    using TechTalk.SpecFlow.Plugins;
    using TechTalk.SpecFlow.Tracing;

    [TestFixture(typeof(NinjectPlugin))]
    [SuppressMessage(
        "Design",
        "CA1001:Types that own disposable fields should be disposable",
        Justification = "disposed in tear down")]
    public class NinjectPluginFixture<TPluginType>
        where TPluginType : IRuntimePlugin
    {
        [Test]
        public void Can_Load_Plugin()
        {
            // Arrange
            var loader = new RuntimePluginLoader();
            var listener = Mock.Of<ITraceListener>();
            var pluginAssembly = Assembly.GetAssembly(typeof(TPluginType));
            var pathToPluginDll = pluginAssembly.Location;

            // Act
            var plugin = loader.LoadPlugin(pathToPluginDll, listener);

            // Assert
            plugin.Should().NotBeNull();
        }
    }
}