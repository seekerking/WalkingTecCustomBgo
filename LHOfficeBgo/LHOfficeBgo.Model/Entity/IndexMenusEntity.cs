using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using LHOfficeBgo.Model.Dto;
using WalkingTec.Mvvm.Core;

namespace LHOfficeBgo.Model.Entity
{
    public class IndexMenusEntity : BasePoco
    {
        [Display(Name = "父级目录")]
        public Guid? ParentId { get; set; }

        [Display(Name = "展示位置")]
        [StringLength(50, ErrorMessage = "{0}最多输入{1}个字符")]
        public string LayOutKey { get; set; }

        [Display(Name = "栏目名称")]
        [StringLength(125, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }
        [Display(Name = "链接")]
        [StringLength(125, ErrorMessage = "{0}最多输入{1}个字符")]
        public string Url { get; set; }
        [Display(Name = "栏目顺序")]
        public int SortOrder { get; set; }
        [Display(Name = "默认图")]
        [StringLength(255, ErrorMessage = "{0}最多输入{1}个字符")]
        public string DefaultImg { get; set; }
        [Display(Name = "鼠标悬停图")]
        [StringLength(255, ErrorMessage = "{0}最多输入{1}个字符")]
        public string HoverImg { get; set; }
        [Display(Name = "是否显示")]
        public bool IsShow { get; set; }
    }

    public static class IndexMenuExtension
    {

        public static List<GroupIndexMenuDto> GetGroupList(this List<IndexMenusEntity> list)
        {
            List<GroupIndexMenuDto> result = new List<GroupIndexMenuDto>();
            foreach (var item in list)
            {
                if (!item.ParentId.HasValue)
                {
                    
                    var groupItemDto = new GroupIndexMenuDto() { title=item.Name,id=item.ID.ToString("D"),children = new List<GroupIndexMenuDto>() };
                    GetSubIndexMenu(list, groupItemDto.children, item);
                    result.Add(groupItemDto);
                }

            }

            return result;

        }

        public static void GetSubIndexMenu(List<IndexMenusEntity> allList, List<GroupIndexMenuDto> subList, IndexMenusEntity parentDto)
        {
            var groupList = allList.Where(x => x.ParentId != null && x.ParentId.Value == parentDto.ID).ToList();

            foreach (var item in groupList)
            {
                
                var groupItemDto = new GroupIndexMenuDto() { title = item.Name, id = item.ID.ToString("D"), children = new List<GroupIndexMenuDto>() };
                subList.Add(groupItemDto);
                GetSubIndexMenu(allList, groupItemDto.children, item);
            }


        }



    }
}
