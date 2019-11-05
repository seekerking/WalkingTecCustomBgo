using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using ProjectFastBgo.Controllers;
using ProjectFastBgo.ViewModel.PushTasks.PushTasksEntityVMs;
using ProjectFastBgo.Model.Entity.TikTokSound;
using ProjectFastBgo.DataAccess;

namespace ProjectFastBgo.Test
{
    [TestClass]
    public class PushTasksEntityControllerTest
    {
        private PushTasksEntityController _controller;
        private string _seed;

        public PushTasksEntityControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<PushTasksEntityController>(_seed, "user");
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
            Assert.IsInstanceOfType(rv.Model, typeof(PushTasksEntityVM));

            PushTasksEntityVM vm = rv.Model as PushTasksEntityVM;
            PushTasksEntity v = new PushTasksEntity();
			
            v.TaskTitle = "GiICb";
            v.TaskBody = "Y9etx";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PushTasksEntity>().FirstOrDefault();
				
                Assert.AreEqual(data.TaskTitle, "GiICb");
                Assert.AreEqual(data.TaskBody, "Y9etx");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            PushTasksEntity v = new PushTasksEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.TaskTitle = "GiICb";
                v.TaskBody = "Y9etx";
                context.Set<PushTasksEntity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(PushTasksEntityVM));

            PushTasksEntityVM vm = rv.Model as PushTasksEntityVM;
            v = new PushTasksEntity();
            v.ID = vm.Entity.ID;
       		
            v.TaskTitle = "5Q9";
            v.TaskBody = "V35xIN7N8";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.TaskTitle", "");
            vm.FC.Add("Entity.TaskBody", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PushTasksEntity>().FirstOrDefault();
 				
                Assert.AreEqual(data.TaskTitle, "5Q9");
                Assert.AreEqual(data.TaskBody, "V35xIN7N8");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            PushTasksEntity v = new PushTasksEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.TaskTitle = "GiICb";
                v.TaskBody = "Y9etx";
                context.Set<PushTasksEntity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(PushTasksEntityVM));

            PushTasksEntityVM vm = rv.Model as PushTasksEntityVM;
            v = new PushTasksEntity();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID,null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PushTasksEntity>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            PushTasksEntity v = new PushTasksEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.TaskTitle = "GiICb";
                v.TaskBody = "Y9etx";
                context.Set<PushTasksEntity>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.ID);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PushTasksEntity v1 = new PushTasksEntity();
            PushTasksEntity v2 = new PushTasksEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.TaskTitle = "GiICb";
                v1.TaskBody = "Y9etx";
                v2.TaskTitle = "5Q9";
                v2.TaskBody = "V35xIN7N8";
                context.Set<PushTasksEntity>().Add(v1);
                context.Set<PushTasksEntity>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new Guid[] { v1.ID, v2.ID });
            Assert.IsInstanceOfType(rv.Model, typeof(PushTasksEntityBatchVM));

            PushTasksEntityBatchVM vm = rv.Model as PushTasksEntityBatchVM;
            vm.Ids = new Guid[] { v1.ID, v2.ID };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PushTasksEntity>().Count(), 0);
            }
        }


    }
}
