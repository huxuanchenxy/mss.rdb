using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MSS.Data.RDB.Model
{
    public abstract class BaseEntity
    {
    }

    public class BasePageParam
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int? page { get; set; }
        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int? rows { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// asc/desc:顺序/降序
        /// </summary>
        public string order { get; set; }
    }

    public enum Code
    {
        [Description("接口调用成功")]
        Success = 0,
        [Description("接口调用失败")]
        Failure = 1,
        [Description("数据已存在")]
        DataIsExist = 2,
        [Description("数据不存在")]
        DataIsnotExist = 3,
        // 向不可添加子节点的节点添加节点
        [Description("数据校验失败")]
        CheckDataRulesFail = 4,
        [Description("绑定用户存在冲突")]
        BindUserConflict = 5
    }
    public class ApiResult
    {
        public Code code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
    }

    public class PageData<T>
    {
        /// <summary>
        /// 查询结果集
        /// </summary>
        public List<T> rows { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int total { get; set; }
    }
}
