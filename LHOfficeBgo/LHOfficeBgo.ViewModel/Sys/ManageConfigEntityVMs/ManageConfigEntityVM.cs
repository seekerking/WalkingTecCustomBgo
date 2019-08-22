using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using LHOfficeBgo.Model.Entity;


namespace LHOfficeBgo.ViewModel.Sys.ManageConfigEntityVMs
{
    public partial class ManageConfigEntityVM : BaseCRUDVM<ManageConfigEntity>
    {

        public ManageConfigEntityVM()
        {
        }

        protected override void InitVM()
        {
        }

        public override void DoAdd()
        {           
            //base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            DC.UpdateProperty(this.Entity, "IosDownLoadUrl");
            DC.UpdateProperty(this.Entity, "AndroidDownLoadUrl");
            DC.UpdateProperty(this.Entity, "QrCodeUrl");
            if (this.Entity.GetType().IsSubclassOf(typeof(BasePoco)))
            {
                try
                {
                    DC.UpdateProperty(Entity, "UpdateTime");
                    DC.UpdateProperty(Entity, "UpdateBy");
                }
                catch (Exception)
                {
                }
            }
            DC.SaveChanges();
            //删除不需要的附件
            if (DeletedFileIds != null)
            {
                foreach (var item in DeletedFileIds)
                {
                    FileAttachmentVM ofa = new FileAttachmentVM();
                    ofa.CopyContext(this);
                    ofa.SetEntityById(item);
                    ofa.DoDelete();
                }
            }

          
    }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
