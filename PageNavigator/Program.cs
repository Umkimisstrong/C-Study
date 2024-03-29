﻿using System;
using Mosti.Models;
using Mosti.Web.Mvc.Theme;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace PageNavigator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }



    public static class PageNavigatorHtml
    {
        public const string CURRENT_PAGE_NUMBER_QUERY_PARAM_KEY = "currentPageNumber";
        public const string EXPRESS_PAGE_NUMBER_QUERY_PARAM_KEY = "expressPageNumber";
        public const string PAGING_COUNT_QUERY_PARAM_KEY        = "pagingCount";
        public const string TOTAL_COUNT_FORMAT_RESOURCE_KEY = "GTPageNavigator_Total_Count_Format";
        public static MvcHtmlString PageNavigator(this HtmlHelper helper
                                                , string name
                                                , int totalRecordCount
                                                , object routeValues
                                                , string routeName = ""
                                                , bool isEncrypt = false)
        {
            RountValueDictionary routeDic = new RountValueDictionary(routeValues);
            NameValueCollection queryParam = HttpContext.Current.Request.QueryString;

            if (isEncrypt)
            {
                // 암호화를 사용하고 있는 경우 파라미터를 복호화해서 route dictionary 에 넣어준다.
                string strkey = Mosti.Configuration.GTSection.Current.Service.Settings.AspNet["QUERY_STRING_KEY"]?.Value ?? QueryStringCrypt.DefaultQueryStringKey;
                if (HttpContext.Current.Request.QueryString.Get(strKey) != null)
                {
                    string encryptedQueryString = HttpContext.Current.Request.QueryString.Get(strKey);
                    Dictionary<string, object> dicParam = QueryStringCrypt.DecryptDictionaryFromString(encryptedQueryString);

                    foreach (KeyValuePair<string, object> item in dicParam)
                    {
                        routeDic[item.Key] = item.Value;
                    }
                }
            }

            // 암호화 외에 다른 파라미터로 들어온 값도 추가한다.
            foreach (string item in queryParam)
            {
                // routedictionary 에 키가 추가되어 있지 않으면 querystring 에서 읽는다.
                if (!routeDic.ContainsKey(item) && !string.IsNullOrEmpty(queryParam[item]?.ToString()))
                    // 이미 있는 route 라는 에러나서 변경
                    // routDic.Add(item, queryParam[item]);
                    routeDic[item] = queryParam[item]?.ToString();
            }
            if (helper.ViewContext.RouteData.Values[CURRENT_PAGE_NUMBER_QUERY_PARAM_KEY] != null)
            {
                routeDic[CURRENT_PAGE_NUMBER_QUERY_PARAM_KEY] = helper.ViewContext.RouteData.Values[CURRENT_PAGE_NUMBER_QUERY_PARAM_KEY];
            }
            if (helper.ViewContext.RouteData.Values[EXPRESS_PAGE_NUMBER_QUERY_PARAM_KEY] != null)
            {
                routeDic[EXPRESS_PAGE_NUMBER_QUERY_PARAM_KEY] = helper.ViewContext.RouteData.Values[EXPRESS_PAGE_NUMBER_QUERY_PARAM_KEY];
            }
            if (helper.ViewContext.RouteData.Values[PAGING_COUNT_QUERY_PARAM_KEY] != null)
            {
                routeDic[PAGING_COUNT_QUERY_PARAM_KEY] = helper.ViewContext.RouteData.Values[PAGING_COUNT_QUERY_PARAM_KEY];
            }

            #region 계산+
            int iRecordTotalCount = totalRecordCount;   //레코드 전체 카운트
            int iPagingCount = 10;              // 페이징 숫자 표출 카운트
            int iPageRecordCount = 10;          // 한 페이지에서 표출되는 글 갯수

            int iStartPagingNumber = 1;   // 현재 페이지 번호
            int iEndPagingNumber = 10;  // 페이징 종료 번호
            int iCurrentPageNumber = 1; // 현재 페이지 번호

            if (!string.IsNullOrEmpty(routeDic[CURRENT_PAGE_NUMBER_QUERY_PARAM_KEY]?.ToString()))
            {
                int.TryParse(routeDic[CURRENT_PAGE_NUMBER_QUERY_PARAM_KEY]?.ToString(), out iCurrentPageNumber);
            }

            if (!string.IsNullOrEmpty(routeDic[EXPRESS_PAGE_NUMBER_QUERY_PARAM_KEY]?.ToString()))
            {
                int.TryParse(routeDic[EXPRESS_PAGE_NUMBER_QUERY_PARAM_KEY]?.ToString(), out iPageRecordCount);
            }
            else
            {
                routeDic[EXPRESS_PAGE_NUMBER_QUERY_PARAM_KEY] = iPageRecordCount;
            }

            if (!string.IsNullOrEmpty(routeDic[PAGING_COUNT_QUERY_PARAM_KEY]?.ToString()))
            {
                int.TryParse(routeDic[PAGING_COUNT_QUERY_PARAM_KEY]?.ToString(), out iPagingCount);
            }
            else
            {
                routeDic[PAGING_COUNT_QUERY_PARAM_KEY] = iPagingCount;
            }

            int iLastPagingNumber = iRecordTotalCount / iPageRecordCount;        // 계산 된 마지막번호   

            if (iRecordTotalCount % iPageRecordCount > 0)
            {
                // 전체 게시글 % 10으로 나눈 나머지가 0이라면
                // = 41 % 10 = 1
                // 1개의 게시물을 출력할 페이지 1개 더 필요

                iLastPagingNumber++;
            }

            if (iPageRecordCount > iRecordTotalCount)
            {
                iLastPagingNumber = 1;
            }

            if (iCurrentPageNumber > iLastPagingNumber)
            {
                iCurrentPageNumber = 1;
            }

            int iCurrentPasingBase = iCurrentPageNumber / iPagingCount; // 현재 표출되는 페이징 바탕 번호
            if (iCurrentPageNumber % iPagingCount == 0)
            {
                iCurrentPasingBase--;
            }

            iStartPagingNumber = (iPagingCount * iCurrentPasingBase) + 1;   // 페이징 바탕번호 * 페이징 숫자 표출             1, 11, 21
            iEndPagingNumber = iPagingCount * (iCurrentPasingBase + 1);     // 페이징 바탕번호 * 페이징 숫자 표출 카운트 + 1  10, 20, 


            // 마지막 페이징 번호가 현재 계산된 페이징 시작, 종료 번호 사이라면
            // 종료번호를 마지막 페이징 번호로 넣어줌
            if(iStartPagingNumber <= iLastPagingNumber && iEndPagingNumber > iLastPagingNumber)
            {
                iEndPagingNumber = iLastPagingNumber;
            }

            #endregion

            #region 페이징 블럭 생성

            Func<int?, ThemeHtmlAttributes> GetPageBlockString = new Func<int?, ThemeHtmlAttributes>((pagingNumber) =>
            {
                if (pagingNumber == 0)
                    return null;

                //TagBuilder PagingBlock = new TagBuilder("li");
                TagBuilder PaginLink = new TagBuilder("a");
                ThemeHtmlAttributes tha = new ThemeHtmlAttributes();
                tha.Text = pagingNumber.ToString();
                //PaginLink.InnerHtml = linkText;
                routeDic[CURRENT_PAGE_NUMBER_QUERY_PARAM_KEY] = pagingNumber;

                if (pagingNumber == iCurrentPageNumber)
                {
                    // PagingBlock.AddCssClass(ControlCss.ACTIVE);
                    tha.Checked = true;
                }

                if (pagingNumber != null && pagingNumber > 0)
                {
                    string strUrl = string.Empty;
                    if (isEncrypt)
                    {
                        // 암호화인 경우
                        strUrl = urlHelper.Action(HttoContext.Current.Request.RequestContext.RouteData.Values["action"].ToString(), HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString(), null);
                        strUrl = $"{strUrl}?{Mosti.Web.Mvc.Runtime.Utils.QueryStringCrypt.GetEncryptQueryStringFromDictionary(routeDic)}";
                    }
                    else if (string.IsNullOrEmpty(routeName))
                    {
                        // route 이름이 없는 경우 route dictionary 로 url 만듬
                        strUrl = urlHelper.RouteUrl(routeDic);
                    }
                    else
                    {
                        // route 이름이 있는 경우 route dictionary, route 명으로 url 생성
                        strUrl = urlHelper.RouteUrl(routeName, routeDic);
                    }
                    tha.Url = strUrl;

                }

                return tha;
            });



            Func<int, bool> GetIncludeRangeYN = new Func<int, bool>((number) =>
            {
                bool isReturn = false;

                if (iStartPagingNumber <= number && iEndPagingNumber >= number)
                {
                    isReturn = true;
                }
                return isReturn;
            });

            string strNavigator = ThemeManager.Instance.PageNavigator(routeName, isEncrypt, GetEncryptQueryStringFromDictionary, routeDic, iPagingCount, iStartPagingNumber, iEndPagingNumber, iCurrentPageNumber, iLastPagingNumber);

            if(string.IsNullOrEmpty(strNavigator))
            {
                int iPrevNumber = iStartPagingNumber - iPagingCount;
                if (iPrevNumber < 0)
                {
                    iPrevNumber = 0;
                }
                int iNextNumber = iStartPagingNumber + iPagingCount;

                List<ThemeHtmlAttributes> lstThemeHtmlAttributes = new List<ThemeHtmlAttributes>();
                ///// [ 숫자 ]
                // 생성되어야 하는 페이징 숫자만큼 for문

                for (int i = iStartPagingNumber; i <= iEndPagingNumber; i++)
                {
                    // Ul 태그 안에 li 태그 숫자블럭 추가
                    lstThemeHtmlAttributes.Add(GetPageBlockString(i));
                }

                if (iNextNumber >= iLastPagingNumber)
                {
                    iNextNumber = iLastPagingNumber;
                }

                iNextNumber = GetIncludeRangeYN(iNextNumber) ? 0 : iNextNumber;
                int iFirstNumber = GetIncludeRangeYN(1) ? 0 : 1;
                iLastPagingNumber = GetIncludeRangeYN(iLastPagingNumber) ? 0 : iLastPagingNumber;

                ThemeHtmlAttributes firstAttribute = GetPageBlockString(iFirstNumber);
                ThemeHtmlAttributes prevAttribute = GetPageBlockString(iPrevNumber);
                ThemeHtmlAttributes nextAttribute = GetPageBlockString(iNextNumber);
                ThemeHtmlAttributes lastAttribute = GetPageBlockString(iLastPagingNumber);

                strNavigator = ThemManager.Instance.PageNavigatorTag(firstAttribute, prevAttribute, lstThemeHtmlAttributes, nextAttribute, lastAttribute);



            }
            return MvcHtmlString.Create(strNavigator);

        }
        #endregion      

        


    }
}
