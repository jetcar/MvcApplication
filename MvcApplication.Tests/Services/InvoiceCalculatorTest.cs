﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication.Models;
using MvcApplication.Services;

namespace MvcApplication.Tests.Services
{
    [TestClass]
    public class InvoiceCalculatorTest
    {
        [TestMethod]
        public void TestRegular()
        {
            IInvoiceCalculator calc = new InvoiceCalculator();

            var client = new Client();
            client.Id = 1;
            client.ParkingTimeList = new[]
            {
                new ParkingTimeInfoModel()
                {
                    StartTime = DateTime.Today.AddHours(8).AddMinutes(12),
                    EndTime = DateTime.Today.AddHours(10).AddMinutes(45),
                },
                new ParkingTimeInfoModel()
                {
                    StartTime = DateTime.Today.AddHours(19).AddMinutes(40),
                    EndTime = DateTime.Today.AddHours(20).AddMinutes(35),
                },
            };
            var invoice = calc.ClaculateInvoice(client);
            Assert.AreEqual(invoice.Price,11.0m);
            Assert.IsTrue(invoice.ClientId > 0);
        }

        [TestMethod]
        public void TestPremium()
        {
            IInvoiceCalculator calc = new InvoiceCalculator();

            var client = new PremiumClient();
            client.Id = 1;

            client.ParkingTimeList = new[]
            {
                new ParkingTimeInfoModel()
                {
                    StartTime = DateTime.Today.AddHours(8).AddMinutes(12),
                    EndTime = DateTime.Today.AddHours(10).AddMinutes(45),
                },
                new ParkingTimeInfoModel()
                {
                    StartTime = DateTime.Today.AddHours(7).AddMinutes(2),
                    EndTime = DateTime.Today.AddHours(11).AddMinutes(56),
                },
                new ParkingTimeInfoModel()
                {
                    StartTime = DateTime.Today.AddHours(22).AddMinutes(10),
                    EndTime = DateTime.Today.AddHours(22).AddMinutes(35),
                },
                new ParkingTimeInfoModel()
                {
                    StartTime = DateTime.Today.AddHours(19).AddMinutes(40),
                    EndTime = DateTime.Today.AddHours(20).AddMinutes(35),
                },
            };
            var invoice = calc.ClaculateInvoice(client);
            Assert.AreEqual(invoice.Price,38.25m);
            Assert.IsTrue(invoice.ClientId > 0);

        }
    }
}