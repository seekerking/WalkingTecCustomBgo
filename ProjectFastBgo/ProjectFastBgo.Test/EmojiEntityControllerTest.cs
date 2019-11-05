using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using ProjectFastBgo.Controllers;
using ProjectFastBgo.ViewModel.EmojiMaster.EmojiEntityVMs;
using ProjectFastBgo.Model.Entity.EmojiMaster;
using ProjectFastBgo.DataAccess;

namespace ProjectFastBgo.Test
{
    [TestClass]
    public class EmojiEntityControllerTest
    {
        private EmojiEntityController _controller;
        private string _seed;

        public EmojiEntityControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<EmojiEntityController>(_seed, "user");
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
            Assert.IsInstanceOfType(rv.Model, typeof(EmojiEntityVM));

            EmojiEntityVM vm = rv.Model as EmojiEntityVM;
            EmojiEntity v = new EmojiEntity();
			
            v.Img = "8gUVaqE3g";
            v.Title = "58P39INO";
            v.Sort = 55;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EmojiEntity>().FirstOrDefault();
				
                Assert.AreEqual(data.Img, "8gUVaqE3g");
                Assert.AreEqual(data.Title, "58P39INO");
                Assert.AreEqual(data.Sort, 55);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            EmojiEntity v = new EmojiEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Img = "8gUVaqE3g";
                v.Title = "58P39INO";
                v.Sort = 55;
                context.Set<EmojiEntity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(EmojiEntityVM));

            EmojiEntityVM vm = rv.Model as EmojiEntityVM;
            v = new EmojiEntity();
            v.ID = vm.Entity.ID;
       		
            v.Img = "iEZ4tXj7A";
            v.Title = "1R2vyV";
            v.Sort = 9;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Img", "");
            vm.FC.Add("Entity.Title", "");
            vm.FC.Add("Entity.Sort", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EmojiEntity>().FirstOrDefault();
 				
                Assert.AreEqual(data.Img, "iEZ4tXj7A");
                Assert.AreEqual(data.Title, "1R2vyV");
                Assert.AreEqual(data.Sort, 9);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            EmojiEntity v = new EmojiEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Img = "8gUVaqE3g";
                v.Title = "58P39INO";
                v.Sort = 55;
                context.Set<EmojiEntity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(EmojiEntityVM));

            EmojiEntityVM vm = rv.Model as EmojiEntityVM;
            v = new EmojiEntity();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID,null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<EmojiEntity>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            EmojiEntity v = new EmojiEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Img = "8gUVaqE3g";
                v.Title = "58P39INO";
                v.Sort = 55;
                context.Set<EmojiEntity>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.ID);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            EmojiEntity v1 = new EmojiEntity();
            EmojiEntity v2 = new EmojiEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Img = "8gUVaqE3g";
                v1.Title = "58P39INO";
                v1.Sort = 55;
                v2.Img = "iEZ4tXj7A";
                v2.Title = "1R2vyV";
                v2.Sort = 9;
                context.Set<EmojiEntity>().Add(v1);
                context.Set<EmojiEntity>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new Guid[] { v1.ID, v2.ID });
            Assert.IsInstanceOfType(rv.Model, typeof(EmojiEntityBatchVM));

            EmojiEntityBatchVM vm = rv.Model as EmojiEntityBatchVM;
            vm.Ids = new Guid[] { v1.ID, v2.ID };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<EmojiEntity>().Count(), 0);
            }
        }


    }
}
