using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using DTO;

namespace UnitTest
{
    [TestClass]
    public class ClaimRequestTest
    {
        private ClaimRequestService claimRequestService;
        private ClaimRequest claimRequest;

        [TestInitialize]
        public void SetUp()
        {
            claimRequestService = new ClaimRequestService();
            claimRequestService.BeginTransaction();
        }

        [TestMethod]
        public void ClaimRequestIvalid()
        {
            
        }
    }
}
