using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace CHENGTUAN.Components
{
    public class Units
    {

        public static string[] GetPages(long count, int pageSize, int pageNo)
        {
            string[] data = null;
            int pageCount = count > pageSize ? (int)(count % pageSize > 0 ? count / pageSize + 1 : count / pageSize) : 1;

            int n = 0;
            #region 小于10页的处理方式
            if (pageCount <= 10)
            {
                data = new string[pageCount];
                for (int i = 0; i < pageCount; i++)
                {
                    data[i] = Convert.ToString(i + 1);
                    n++;
                }
            }
            #endregion
            else
            {
                //大于等于10页的处理方式
                #region 当前页在第1页和第9页之间
                if (pageNo >= 0 && pageNo < 9)
                {
                    #region 如果总页面大于12页情况,则省略中间项只显示1-10页和最后2页
                    if (pageCount > 12)
                    {
                        data = new string[12];
                        for (int i = 0; i < pageCount; i++)
                        {
                            if (i <= 8 && n < data.Length)
                            {
                                data[n] = Convert.ToString(i + 1);
                                n++;
                            }
                            else
                            {
                                if (i <= pageCount - 3)
                                {
                                    if (n == 9)
                                    {
                                        data[n] = "...";
                                        n++;
                                    }

                                }
                                else
                                {
                                    data[n] = Convert.ToString(i + 1);
                                    n++;
                                }
                            }
                        }
                    }
                    #endregion
                    else
                    {
                        data = new string[pageCount];
                        for (int i = 0; i < pageCount; i++)
                        {
                            data[n] = Convert.ToString(i + 1);
                            n++;
                        }
                    }

                }
                #endregion

                //当前页在第10页和第pageCount-8页之间
                else if (pageNo >= 9 && pageNo <= pageCount - 7)
                {
                    if (pageCount <= 13)
                    {
                        data = new string[pageCount];
                        for (int i = 0; i < pageCount; i++)
                        {
                            data[i] = Convert.ToString(i + 1);
                        }
                    }
                    else
                    {
                        data = new string[11];
                        for (int i = 0; i < pageCount; i++)
                        {
                            if ((i == 0 || i == 1 || i == pageCount - 1 || i == pageCount - 2) && n < data.Length)
                            {
                                data[n] = Convert.ToString(i + 1);
                                n++;
                            }
                            else if ((i == 2 || i == pageCount - 3) && n < data.Length)
                            {
                                data[n] = "...";
                                n++;
                            }
                            else if ((i > 3 && i < pageCount - 3) && n < data.Length)
                            {
                                // 在页数大于2 and 页数小于 总数 - 3 
                                if (i > pageNo - 4 && i < pageNo + 2)
                                {
                                    data[n] = Convert.ToString(i + 1);
                                    n++;
                                }
                            }
                        }
                    }
                }
                //当前页在第pageCount-8到pageCount页之间
                else
                {
                    if (pageCount <= 13)
                    {
                        data = new string[pageCount];
                        for (int i = 0; i < pageCount; i++)
                        {
                            data[n] = Convert.ToString(i + 1);
                            n++;
                        }
                    }
                    else
                    {
                        data = new string[11];
                        for (int i = 0; i < pageCount; i++)
                        {
                            if (i == 0 || i == 1 || (i >= pageCount - 8 && i <= pageCount - 1))
                            {
                                if (n < 11)
                                {
                                    data[n] = Convert.ToString(i + 1);
                                    n++;
                                }
                            }
                            else if (i == 2)
                            {
                                data[n] = "...";
                                n++;
                            }
                            else { }
                        }
                    }
                }
            }
            return data;
        }

        /// <summary>
        /// 获取分页数据源
        /// </summary>
        /// <param name="count">返回的查询记录总数</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">当前页面</param>
        /// <returns></returns>
        public static string[] GetPages(int count, int pageSize, int pageIndex)
        {
            string[] data = null;
            int pageCount = count > pageSize ? (int)(count % pageSize > 0 ? count / pageSize + 1 : count / pageSize) : 1;

            int n = 0;

            #region 小于10页的处理方式
            if (pageCount <= 10)
            {
                data = new string[pageCount];
                for (int i = 0; i < pageCount; i++)
                {
                    data[i] = Convert.ToString(i + 1);
                    n++;
                }
            }
            #endregion
            else
            {
                //大于等于10页的处理方式
                #region 当前页在第1页和第9页之间
                if (pageIndex >= 0 && pageIndex < 9)
                {
                    #region 如果总页面大于12页情况,则省略中间项只显示1-10页和最后2页
                    if (pageCount > 12)
                    {
                        data = new string[12];
                        for (int i = 0; i < pageCount; i++)
                        {
                            if (i <= 8 && n < data.Length)
                            {
                                data[n] = Convert.ToString(i + 1);
                                n++;
                            }
                            else
                            {
                                if (i <= pageCount - 3)
                                {
                                    if (n == 9)
                                    {
                                        data[n] = "...";
                                        n++;
                                    }

                                }
                                else
                                {
                                    data[n] = Convert.ToString(i + 1);
                                    n++;
                                }
                            }
                        }
                    }
                    #endregion
                    else
                    {
                        data = new string[pageCount];
                        for (int i = 0; i < pageCount; i++)
                        {
                            data[n] = Convert.ToString(i + 1);
                            n++;
                        }
                    }

                }
                #endregion

                //当前页在第10页和第pageCount-8页之间
                else if (pageIndex >= 9 && pageIndex <= pageCount - 7)
                {
                    if (pageCount <= 13)
                    {
                        data = new string[pageCount];
                        for (int i = 0; i < pageCount; i++)
                        {
                            data[i] = Convert.ToString(i + 1);
                        }
                    }
                    else
                    {
                        data = new string[11];
                        for (int i = 0; i < pageCount; i++)
                        {
                            if ((i == 0 || i == 1 || i == pageCount - 1 || i == pageCount - 2) && n < data.Length)
                            {
                                data[n] = Convert.ToString(i + 1);
                                n++;
                            }
                            else if ((i == 2 || i == pageCount - 3) && n < data.Length)
                            {
                                data[n] = "...";
                                n++;
                            }
                            else if ((i > 3 && i < pageCount - 3) && n < data.Length)
                            {
                                // 在页数大于2 and 页数小于 总数 - 3 
                                if (i > pageIndex - 4 && i < pageIndex + 2)
                                {
                                    data[n] = Convert.ToString(i + 1);
                                    n++;
                                }
                            }
                        }
                    }
                }
                //当前页在第pageCount-8到pageCount页之间
                else
                {
                    if (pageCount <= 13)
                    {
                        data = new string[pageCount];
                        for (int i = 0; i < pageCount; i++)
                        {
                            data[n] = Convert.ToString(i + 1);
                            n++;
                        }
                    }
                    else
                    {
                        data = new string[11];
                        for (int i = 0; i < pageCount; i++)
                        {
                            if (i == 0 || i == 1 || (i >= pageCount - 8 && i <= pageCount - 1))
                            {
                                if (n < 11)
                                {
                                    data[n] = Convert.ToString(i + 1);
                                    n++;
                                }
                            }
                            else if (i == 2)
                            {
                                data[n] = "...";
                                n++;
                            }
                            else { }
                        }
                    }
                }
            }
            return data;
        }

        /// <summary>
        /// 获取物理路径
        /// </summary>
        /// <param name="strPath">相对路径</param>
        /// <returns></returns>
        public static string MapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //多线程 
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
    }
}
