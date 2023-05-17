using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wallee.ESign.PersonalAuths
{
    /// <summary>
    /// 发起个人用户手机运营商3要素核身认证
    /// </summary>
    public class CreatePersonalTelecom3FactorsDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string IdNo { get; set; } = null!;
        [Required]
        public string MobileNo { get; set; } = null!;

        public string ContextId { get; set; } = null!;
        public string? NotifyUrl { get; set; } = null!;
        public string Grade { get; set; } = null!;
    }
}
