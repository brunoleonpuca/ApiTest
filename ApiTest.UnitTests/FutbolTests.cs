using ApiTestv2;
using DemoLibraryv2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace ApiTest.UnitTests
{
    [TestFixture]
    public class FutbolTests
    {
        /// <summary>
        /// Until now, we made it to 20 teams in LoadFutbolInformation
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Functionality()
        {
            ApiHelper.InitializeClient();
            var result = await FutbolProcessor.LoadFutbolInformation();
            foreach (var team in result.Data)
            {
                Console.WriteLine(team.Name);
            }

        }
    }
}
