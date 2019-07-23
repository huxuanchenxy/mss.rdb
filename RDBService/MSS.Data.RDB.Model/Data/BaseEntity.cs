using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MSS.Data.RDB.Model
{
    public abstract class BaseEntity
    {
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
}
