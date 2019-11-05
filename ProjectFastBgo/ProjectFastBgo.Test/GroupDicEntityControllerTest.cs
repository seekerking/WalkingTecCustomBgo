using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using ProjectFastBgo.Controllers;
using ProjectFastBgo.ViewModel.EmojiMaster.GroupDicEntityVMs;
using ProjectFastBgo.Model.Entity.EmojiMaster;
using ProjectFastBgo.DataAccess;

namespace ProjectFastBgo.Test
{
    [TestClass]
    public class GroupDicEntityControllerTest
    {
        private GroupDicEntityController _controller;
        private string _seed;

        public GroupDicEntityControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<GroupDicEntityController>(_seed, "user");
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
            Assert.IsInstanceOfType(rv.Model, typeof(GroupDicEntityVM));

            GroupDicEntityVM vm = rv.Model as GroupDicEntityVM;
            GroupDicEntity v = new GroupDicEntity();
			
            v.Title = "IMx";
            v.Sort = 16;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<GroupDicEntity>().FirstOrDefault();
				
                Assert.AreEqual(data.Title, "IMx");
                Assert.AreEqual(data.Sort, 16);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            GroupDicEntity v = new GroupDicEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Title = "IMx";
                v.Sort = 16;
                context.Set<GroupDicEntity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(GroupDicEntityVM));

            GroupDicEntityVM vm = rv.Model as GroupDicEntityVM;
            v = new GroupDicEntity();
            v.ID = vm.Entity.ID;
       		
            v.Title = "B3HO";
            v.Sort = 53;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Title", "");
            vm.FC.Add("Entity.Sort", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<GroupDicEntity>().FirstOrDefault();
 				
                Assert.AreEqual(data.Title, "B3HO");
                Assert.AreEqual(data.Sort, 53);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            GroupDicEntity v = new GroupDicEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Title = "IMx";
                v.Sort = 16;
                context.Set<GroupDicEntity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(GroupDicEntityVM));

            GroupDicEntityVM vm = rv.Model as GroupDicEntityVM;
            v = new GroupDicEntity();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID,null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<GroupDicEntity>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            GroupDicEntity v = new GroupDicEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Title = "IMx";
                v.Sort = 16;
                context.Set<GroupDicEntity>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.ID);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            GroupDicEntity v1 = new GroupDicEntity();
            GroupDicEntity v2 = new GroupDicEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Title = "IMx";
                v1.Sort = 16;
                v2.Title = "B3HO";
                v2.Sort = 53;
                context.Set<GroupDicEntity>().Add(v1);
                context.Set<GroupDicEntity>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new Guid[] { v1.ID, v2.ID });
            Assert.IsInstanceOfType(rv.Model, typeof(GroupDicEntityBatchVM));

            GroupDicEntityBatchVM vm = rv.Model as GroupDicEntityBatchVM;
            vm.Ids = new Guid[] { v1.ID, v2.ID };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<GroupDicEntity>().Count(), 0);
            }
        }


    }
}
