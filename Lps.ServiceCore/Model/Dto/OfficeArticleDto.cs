﻿using System;
using System.ComponentModel.DataAnnotations;
using Lps.ServiceCore.Model.System;
using Lps.Model;
namespace Lps.ServiceCore.Model.Dto
{
    public class ArticleQueryDto : PagerInfo
    {
        public long? UserId { get; set; }
        public int IsStatus { get; set; }
        public string Title { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// 输入输出对象
    /// </summary>
    public class OfficeArticleDto
    {
        [Required(ErrorMessage = "Cid不能为空")]
        public int Cid { get; set; }
        [Required(ErrorMessage = "文章标题不能为空")]
        public string Title { get; set; }
        [Required(ErrorMessage = "文章内容不能为空")]
        public string Content { get; set; }

        public long? UserId { get; set; }

        public int IsStatus { get; set; }

        public string FmtType { get; set; }

        public string Tags { get; set; }

        public int? Hits { get; set; }

        public int? CategoryId { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string AuthorName { get; set; }

        public string CoverUrl { get; set; }

        public OfficeArticleCategory ArticleCategoryNav { get; set; }
        public string[] TagList { get; set; }
        public int IsPublic { get; set; }
    }
}
