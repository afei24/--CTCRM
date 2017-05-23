using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHENGTUAN.Entity
{
    /// <summary>
    /// 定义发生异常的位置
    /// </summary>
    public enum ExceptionPostion
    {
        /// <summary>
        /// web界面
        /// </summary>
        TBApply_Web_UI,
        /// <summary>
        /// web代码
        /// </summary>
        TBApply_Web_CS,
        /// <summary>
        /// 业务逻辑层
        /// </summary>
        TBApply_Components,
        /// <summary>
        /// 业务逻辑层
        /// </summary>
        CHENGTUAN_Components,
        /// <summary>
        /// 实体
        /// </summary>
        CHTUAN_ENTITY,
        /// <summary>
        /// 数据访问层
        /// </summary>
        TBApply_Data,
        /// <summary>
        /// 契约
        /// </summary>
        TBApply_Contract,
        /// <summary>
        /// 配置
        /// </summary>
        TBApply_Configuration,
        /// <summary>
        /// 淘宝APi
        /// </summary>
        TopApi

    }
    /// <summary>
    /// 定义异常级别
    /// </summary>
    public enum ExceptionRank
    {
        /// <summary>
        /// 非常重要
        /// </summary>
        urgency,
        /// <summary>
        /// 重要
        /// </summary>
        important,
        /// <summary>
        /// 一般
        /// </summary>
        average,
    }
    /// <summary>
    /// 异常实体
    /// </summary>
    public class ExceptionInfo
    {
        private int _num;
        private string _title;
        private string _body;
        private ExceptionPostion _position;
        private ExceptionRank _rank;
        /// <summary>
        /// 错误编号
        /// </summary>
        public int Num
        {
            get { return this._num; }
            set { this._num = value; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Body
        {
            get { return this._body; }
            set { this._body = value; }
        }
        /// <summary>
        /// 发生位置
        /// </summary>
        public ExceptionPostion ExceptionPosition
        {
            get { return _position; }
            set { this._position = value; }
        }
        /// <summary>
        /// </summary>
        public ExceptionRank ExceptionRank
        {
            get { return this._rank; }
            set { this._rank = value; }
        }
        public ExceptionInfo(int num, string title, string
            body, ExceptionPostion position, ExceptionRank rank)
        {
            this._num = num;
            this._title = title;
            this._body = body;
            this._position = position;
            this._rank = rank;
        }

        public ExceptionInfo()
        {

        }
    }
}
