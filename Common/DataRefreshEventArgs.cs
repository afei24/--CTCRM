using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CTCRM.Common
{
    public class DataRefreshEventArgs : EventArgs
    {
        private int _currentPage;
        private int _rowsPerPage;
        private int _rowCount;
        private object _dataSource;

        public DataRefreshEventArgs(int currentPage, int rowsPerPage, ref int rowCount, ref DataSet dataSource)
        {
            _currentPage = currentPage;
            _rowsPerPage = rowsPerPage;
            _rowCount = rowCount;
            _dataSource = dataSource;
        }

        // 属性

        /// <summary>
        /// 获取或设置当前页。
        /// </summary>
        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
            }
        }

        /// <summary>
        /// 获取或设置每页行数。
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
            }
        }

        /// <summary>
        /// 获取或设置总行数。
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
            }
        }

        /// <summary>
        /// 获取或设置数据集。
        /// </summary>
        public object DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
            }
        }
    }
}
