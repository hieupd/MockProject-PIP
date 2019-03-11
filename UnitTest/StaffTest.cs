using System;
using System.Collections.Generic;
using Business;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class StaffTest
    {
        private StaffService _service;
        private List<Staff> staffs = new List<Staff>();
        private Staff staff = new Staff()
        {
            StaffId = "1",
            StaffName = "C",
            Email = "c@example.com",
            CardNumber = "CN000001",
            Salary = 1000,
            DepartmentId = 1,
            JobRankId = 1
        };
        [TestInitialize]
        public void SetUp()
        {
            _service = new StaffService();
            _service.BeginTransaction();
        }



        //Get All case
        [TestMethod]
        public void GetAllTest()
        {
            var result = _service.GetAll(null).Count;
            Assert.AreNotEqual(0, result);
        }




        //Get Id Case
        [TestMethod]
        public void GetById1()
        {
            var result = _service.GetById(1, null);
            Assert.AreNotEqual(null, result);
        }
        [TestMethod]
        public void GetById0()
        {
            var result = _service.GetById(0, null);
            Assert.AreEqual(null, result);
        }



        //Insert Case
        [TestMethod]
        public void InsertStaff()
        {
            var result = _service.Insert(staff, new List<string>());
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void InsertStaffEmailNull()
        {
            staff.Email = null;
            var result = _service.Insert(staff, null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void InsertStaffSalaryLowerThan0()
        {
            staff.Salary = -1000;
            var result = _service.Insert(staff, null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void InsertStaffCardNumberNull()
        {
            staff.CardNumber = null;
            var result = _service.Insert(staff, null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void InsertStaffJobRankIdLowerThan0()
        {
            staff.JobRankId = -1;
            var result = _service.Insert(staff, null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void InsertStaffJobRankIdIs0()
        {
            staff.JobRankId = 0;
            var result = _service.Insert(staff, null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void InsertStaffJobRankIdTooBig()
        {
            staff.JobRankId = 10000;
            var result = _service.Insert(staff, null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void InsertStaffDepartmentIdLowerThan0()
        {
            staff.DepartmentId = -1;
            var result = _service.Insert(staff, null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void InsertStaffDepartmentIdIs0()
        {
            staff.DepartmentId = 0;
            var result = _service.Insert(staff, null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void InsertStaffDepartmentIdTooBig()
        {
            staff.DepartmentId = 10000;
            var result = _service.Insert(staff, null);
            Assert.AreEqual(0, result);
        }



        //Update Case
        [TestMethod]
        public void UpdateStaffId1()
        {
            _service.Insert(staff, null);
            staff.StaffId = "1";
            staff.StaffName = "D";
            staff.Email = "c@example.com";
            staff.CardNumber = "CN000001";
            staff.Salary = 1000;
            staff.DepartmentId = 1;
            staff.JobRankId = 1;
            var result = _service.Update(staff, null);
            Assert.AreNotEqual(0, result);
        }


        //Delete Case
        [TestMethod]
        public void DeleteStaffId1()
        {
            _service.Insert(staff,null);
            var result = _service.Delete("1", null);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void DeleteStaffIdString()
        {
            _service.Insert(staff, null);
            var result = _service.Delete("aa", null);
            Assert.AreEqual(0, result);
        }


        [TestCleanup]
        public void Clean()
        {
            _service.RollbackTransaction();
        }
    }
}
