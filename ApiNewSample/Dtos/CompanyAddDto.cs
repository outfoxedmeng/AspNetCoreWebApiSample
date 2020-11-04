using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNewSample.Dtos
{
    //P21
    public class CompanyAddDto
    {
        [Display(Name = "名")]
        [Required(ErrorMessage = "{0}是必须的")]
        [MaxLength(100, ErrorMessage = "{0}的最大长度为{1}")]
        public string Name { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public string Product { get; set; }

        [Display(Name = "jianjie")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "{0}的长度范围是从{2}到{1}")]
        public string Introduction { get; set; }

        public DateTime? BankruptTime { get; set; }

        //同时添加父子资源
        //属性名字为Employees，因此不需要额外的映射配置
        public ICollection<EmployeeCreateDto> Employees { get; set; } = new List<EmployeeCreateDto>();
    }
}
