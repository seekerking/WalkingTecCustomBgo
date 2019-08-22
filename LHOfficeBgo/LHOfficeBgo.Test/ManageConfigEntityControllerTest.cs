using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using WalkingTec.Mvvm.Core;
using LHOfficeBgo.Controllers;
using LHOfficeBgo.ViewModel.Sys.ManageConfigEntityVMs;
using LHOfficeBgo.Model.Entity;
using LHOfficeBgo.DataAccess;

namespace LHOfficeBgo.Test
{
    [TestClass]
    public class ManageConfigEntityControllerTest
    {
        private ManageConfigEntityController _controller;
        private string _seed;

        public ManageConfigEntityControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            
            _controller = MockController.CreateController<ManageConfigEntityController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ManageConfigEntityVM));

            ManageConfigEntityVM vm = rv.Model as ManageConfigEntityVM;
            ManageConfigEntity v = new ManageConfigEntity();
			
            v.DataKey = "WAVRU3elE";
            v.IosDownLoadUrl = "R4ag";
            v.AndroidDownLoadUrl = "pAiAjpeV";
            v.QrCodeUrl = "AIl";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ManageConfigEntity>().FirstOrDefault();
				
                Assert.AreEqual(data.DataKey, "WAVRU3elE");
                Assert.AreEqual(data.IosDownLoadUrl, "R4ag");
                Assert.AreEqual(data.AndroidDownLoadUrl, "pAiAjpeV");
                Assert.AreEqual(data.QrCodeUrl, "AIl");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            ManageConfigEntity v = new ManageConfigEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.DataKey = "WAVRU3elE";
                v.IosDownLoadUrl = "R4ag";
                v.AndroidDownLoadUrl = "pAiAjpeV";
                v.QrCodeUrl = "AIl";
                context.Set<ManageConfigEntity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(ManageConfigEntityVM));

            ManageConfigEntityVM vm = rv.Model as ManageConfigEntityVM;
            v = new ManageConfigEntity();
            v.ID = vm.Entity.ID;
       		
            v.DataKey = "Iir";
            v.IosDownLoadUrl = "DKTQQOWp6";
            v.AndroidDownLoadUrl = "Isu6KM";
            v.QrCodeUrl = "fCgmBvCH";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.DataKey", "");
            vm.FC.Add("Entity.IosDownLoadUrl", "");
            vm.FC.Add("Entity.AndroidDownLoadUrl", "");
            vm.FC.Add("Entity.QrCodeUrl", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ManageConfigEntity>().FirstOrDefault();
 				
                Assert.AreEqual(data.DataKey, "Iir");
                Assert.AreEqual(data.IosDownLoadUrl, "DKTQQOWp6");
                Assert.AreEqual(data.AndroidDownLoadUrl, "Isu6KM");
                Assert.AreEqual(data.QrCodeUrl, "fCgmBvCH");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            ManageConfigEntity v = new ManageConfigEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.DataKey = "WAVRU3elE";
                v.IosDownLoadUrl = "R4ag";
                v.AndroidDownLoadUrl = "pAiAjpeV";
                v.QrCodeUrl = "AIl";
                context.Set<ManageConfigEntity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(ManageConfigEntityVM));

            ManageConfigEntityVM vm = rv.Model as ManageConfigEntityVM;
            v = new ManageConfigEntity();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID,null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ManageConfigEntity>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            ManageConfigEntity v = new ManageConfigEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.DataKey = "WAVRU3elE";
                v.IosDownLoadUrl = "R4ag";
                v.AndroidDownLoadUrl = "pAiAjpeV";
                v.QrCodeUrl = "AIl";
                context.Set<ManageConfigEntity>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.ID);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ManageConfigEntity v1 = new ManageConfigEntity();
            ManageConfigEntity v2 = new ManageConfigEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DataKey = "WAVRU3elE";
                v1.IosDownLoadUrl = "R4ag";
                v1.AndroidDownLoadUrl = "pAiAjpeV";
                v1.QrCodeUrl = "AIl";
                v2.DataKey = "Iir";
                v2.IosDownLoadUrl = "DKTQQOWp6";
                v2.AndroidDownLoadUrl = "Isu6KM";
                v2.QrCodeUrl = "fCgmBvCH";
                context.Set<ManageConfigEntity>().Add(v1);
                context.Set<ManageConfigEntity>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new Guid[] { v1.ID, v2.ID });
            Assert.IsInstanceOfType(rv.Model, typeof(ManageConfigEntityBatchVM));

            ManageConfigEntityBatchVM vm = rv.Model as ManageConfigEntityBatchVM;
            vm.Ids = new Guid[] { v1.ID, v2.ID };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ManageConfigEntity>().Count(), 0);
            }
        }


    }
}
