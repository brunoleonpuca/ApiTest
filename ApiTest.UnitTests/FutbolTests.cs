using ApiTestv2;
using DemoLibraryv2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace ApiTest.UnitTests
{
    [TestFixture]
    public class FutbolTests
    {
        [Test]
        public async void Functionality()
        {
            var result = await FutbolProcessor.LoadFutbolInformation();

        }
    }
}
