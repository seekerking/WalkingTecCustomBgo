using System;
using System.Collections.Generic;
using System.Text;

namespace LHOfficeBgo.Model.Dto
{
   public class GroupIndexMenuDto
    {
        public string title { get; set; }
        public string id { get; set; }
        public List<GroupIndexMenuDto> children { get; set; }
    }
}
