using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CTCRM.Common;

namespace CTCRM.admin.CommonContr
{
    public partial class Pagination : System.Web.UI.UserControl
    {
        private GridView _controlledGridView;
        private int _rowsPerPage = 15;
        private int _defaultBeginPage = 1;
        private int _currentPage = 1;
        private int _pageCount;
        private int _rowCount;
        private DataSet _dataSource = new DataSet();
        private bool _isShowHead = false;
        public event DataRefreshEventHandler DataRefreshing;
        public bool IsShowHead
        {
            set
            {
                _isShowHead = value;
            }
        }
        // 方法

        /// <summary>
        /// 从数据服务器中重新获取数据并刷新表格。
        /// </summary>
        public void Refresh()
        {
            Refresh(_currentPage, _rowsPerPage);
        }

        /// <summary>
        /// 按指定的每页记录数从数据服务器中重新获取当前页数据并刷新表格。
        /// </summary>
        /// <param name="currentPage">指定的当前页序号。</param>
        /// <param name="rowsPerPage">每页记录数。</param>
        public void Refresh(int currentPage, int rowsPerPage)
        {
            _currentPage = currentPage;
            _rowsPerPage = rowsPerPage;

            OnDataRefreshing(new DataRefreshEventArgs(_currentPage, _rowsPerPage, ref _rowCount, ref _dataSource));
        }

        /// <summary>
        /// 将指定的数字字符串转换为整型类型，如果指定字符串不能转换成整型则返回默认值。
        /// </summary>
        /// <param name="s">需要被转换字符串。</param>
        /// <param name="defaultValue">默认值。</param>
        /// <returns>转换后整型值。</returns>
        private int ToInt(string s, int defaultValue)
        {
            try
            {
                int n = Convert.ToInt32(s);
                if (n <= 0)
                {
                    n = defaultValue;
                }
                return n;
            }
            catch
            {
                return defaultValue;
            }
        }
        // 事件
        private void OnDataRefreshing(DataRefreshEventArgs e)
        {
            if ((DataRefreshing != null))
            {
                DataRefreshing(this, e);
                if (e.DataSource != null && e.RowCount > 0)
                {
                    CurrentPage = e.CurrentPage;
                    RowsPerPage = e.RowsPerPage;
                    RowCount = e.RowCount;
                    decimal rowCountDecimal = RowCount;
                    PageCount = Convert.ToInt32(Decimal.Ceiling(rowCountDecimal / RowsPerPage));

                    #region
                    ///当CurrentPage > PageCount 时 ，页面会出错
                    CurrentPage = CurrentPage > PageCount ? PageCount : CurrentPage;
                    #endregion  end
                    _controlledGridView.DataSource = e.DataSource;
                    _controlledGridView.DataBind();


                    // 设置导航按钮的可用状态
                    btnPrevious.Enabled = (_currentPage != 1);
                    btnFirst.Enabled = btnPrevious.Enabled;

                    btnNext.Enabled = (_currentPage != _pageCount);
                    btnLast.Enabled = btnNext.Enabled;
                }
                else if (e.DataSource != null && e.RowCount == 0)
                {
                    CurrentPage = 1;
                    RowsPerPage = e.RowsPerPage;
                    RowCount = e.RowCount;
                    decimal rowCountDecimal = RowCount;
                    PageCount = Convert.ToInt32(Decimal.Ceiling(rowCountDecimal / RowsPerPage));
                    _controlledGridView.DataSource = e.DataSource;
                    _controlledGridView.DataBind();

                    // 设置导航按钮的可用状态
                    btnPrevious.Enabled = false;
                    btnFirst.Enabled = btnPrevious.Enabled;

                    btnNext.Enabled = false;
                    btnLast.Enabled = btnNext.Enabled;
                }
                else
                {
                    _controlledGridView.DataSource = e.DataSource;
                    _controlledGridView.DataBind();
                }
                if (_isShowHead)
                {
                    _controlledGridView.Rows[0].Visible = false;
                }
            }
        }

        // 属性

        /// <summary>
        /// 获取或设置表格控件的实例，该表格控件的数据内容将受分页控件的控制。
        /// </summary>
        public GridView ControlledGridView
        {
            get
            {
                return _controlledGridView;
            }
            set
            {
                _controlledGridView = value;
            }
        }

        /// <summary>
        /// 获取或设置分页控件的每页记录数。
        /// </summary>
        public int RowsPerPage
        {
            get
            {
                return _rowsPerPage;
            }
            set
            {
                _rowsPerPage = value;
                txtRowsPerPage.Text = _rowsPerPage.ToString();
            }
        }

        /// <summary>
        /// 设置默认的开始页序号。
        /// </summary>
        public int DefaultBeginPage
        {
            set
            {
                _defaultBeginPage = value;
            }
        }

        /// <summary>
        /// 获取或设置当前页序号。
        /// </summary>
        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                if (_pageCount != 0 && value > _pageCount)
                {
                    //throw new ArgumentOutOfRangeException("CurrentPage", "设置当前数据页时发生了错误。指定的数据页不存在。");
                }
                else
                {
                    _currentPage = value;
                    txtCurrentPage.Text = _currentPage.ToString();
                    lblCurrentPage.Text = _currentPage.ToString();
                }
            }
        }

        /// <summary>
        /// 获取或设置当前页序号。
        /// </summary>
        public int PageCount
        {
            get
            {
                return _pageCount;
            }
            set
            {
                _pageCount = value;
                lblPageCount.Text = _pageCount.ToString();
            }
        }

        /// <summary>
        /// 获取或设置当前页序号。
        /// </summary>
        public int RowCount
        {
            get
            {
                return _rowCount;
            }
            set
            {
                _rowCount = value;
                lblRowCount.Text = _rowCount.ToString();
            }
        }

        // 从页面触发的事件。

        protected void Page_Load(object sender, EventArgs e)
        {
            // 根据用户控件中子控件的属性来初始化用户控件属性。
            if (txtCurrentPage.Text != string.Empty)
            {
                CurrentPage = ToInt(txtCurrentPage.Text, 1);
            }
            else
            {
                CurrentPage = _defaultBeginPage;
            }
            PageCount = ToInt(lblPageCount.Text, 0);
            RowCount = ToInt(lblRowCount.Text, 0);
            RowsPerPage = ToInt(txtRowsPerPage.Text, _rowsPerPage);
        }
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                CurrentPage = 1;
                Refresh();
            }
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                CurrentPage -= 1;
                Refresh();
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _pageCount || _pageCount == 0)
            {
                CurrentPage += 1;
                Refresh();
            }
        }
        protected void btnLast_Click(object sender, EventArgs e)
        {
            if (_currentPage < _pageCount)
            {
                CurrentPage = _pageCount;
                Refresh();
            }
        }
        protected void txtRowsPerPage_TextChanged(object sender, EventArgs e)
        {
            RowsPerPage = ToInt(txtRowsPerPage.Text, _rowsPerPage);
            // 每页行数改变后，当前页必须回到第一页，否则可能会导致指定的页不存在的问题。
            CurrentPage = 1;
        }
        protected void txtCurrentPage_TextChanged(object sender, EventArgs e)
        {
            int currentPage = ToInt(txtCurrentPage.Text, _pageCount);
            // 判断指定的页是否存在
            if (currentPage > _pageCount)
            {
                currentPage = _pageCount;
            }

            CurrentPage = currentPage;
        }
        protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            Refresh();
        }
    }
}