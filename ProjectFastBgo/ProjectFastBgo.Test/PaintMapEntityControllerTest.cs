using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using ProjectFastBgo.Controllers;
using ProjectFastBgo.ViewModel.EmojiMaster.PaintMapEntityVMs;
using ProjectFastBgo.Model.Entity.EmojiMaster;
using ProjectFastBgo.DataAccess;

namespace ProjectFastBgo.Test
{
    [TestClass]
    public class PaintMapEntityControllerTest
    {
        private PaintMapEntityController _controller;
        private string _seed;

        public PaintMapEntityControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<PaintMapEntityController>(_seed, "user");
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
            Assert.IsInstanceOfType(rv.Model, typeof(PaintMapEntityVM));

            PaintMapEntityVM vm = rv.Model as PaintMapEntityVM;
            PaintMapEntity v = new PaintMapEntity();
			
            v.Img = "UoG";
            v.Sort = 70;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PaintMapEntity>().FirstOrDefault();
				
                Assert.AreEqual(data.Img, "UoG");
                Assert.AreEqual(data.Sort, 70);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            PaintMapEntity v = new PaintMapEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Img = "UoG";
                v.Sort = 70;
                context.Set<PaintMapEntity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(PaintMapEntityVM));

            PaintMapEntityVM vm = rv.Model as PaintMapEntityVM;
            v = new PaintMapEntity();
            v.ID = vm.Entity.ID;
       		
            v.Img = "GHW50BY8";
            v.Sort = 23;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Img", "");
            vm.FC.Add("Entity.Sort", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PaintMapEntity>().FirstOrDefault();
 				
                Assert.AreEqual(data.Img, "GHW50BY8");
                Assert.AreEqual(data.Sort, 23);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            PaintMapEntity v = new PaintMapEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Img = "UoG";
                v.Sort = 70;
                context.Set<PaintMapEntity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(PaintMapEntityVM));

            PaintMapEntityVM vm = rv.Model as PaintMapEntityVM;
            v = new PaintMapEntity();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID,null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PaintMapEntity>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            PaintMapEntity v = new PaintMapEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Img = "UoG";
                v.Sort = 70;
                context.Set<PaintMapEntity>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID);
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.ID);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PaintMapEntity v1 = new PaintMapEntity();
            PaintMapEntity v2 = new PaintMapEntity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Img = "UoG";
                v1.Sort = 70;
                v2.Img = "GHW50BY8";
                v2.Sort = 23;
                context.Set<PaintMapEntity>().Add(v1);
                context.Set<PaintMapEntity>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new Guid[] { v1.ID, v2.ID });
            Assert.IsInstanceOfType(rv.Model, typeof(PaintMapEntityBatchVM));

            PaintMapEntityBatchVM vm = rv.Model as PaintMapEntityBatchVM;
            vm.Ids = new Guid[] { v1.ID, v2.ID };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PaintMapEntity>().Count(), 0);
            }
        }


    }
}
