﻿using SE.BussinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebExpress.Website;

namespace SE.Website
{
    public class ChinaAreaScriptWriter : IScriptWriter
    {
        public void WriteScripts(StringBuilder writer)
        {
            var bll = DependencyResolver.Current.GetService<ChinaAreaBussinessLogic>();
            var provinces = bll.GetProvinces();
            writer.AppendFormat("webExpress.data.china.provinces = {0};\r\n", GetItems(provinces));
            var sbCitites = new StringBuilder();
            var sbCounties = new StringBuilder();
            sbCitites.Append("webExpress.data.china.cities = {");
            sbCounties.Append("webExpress.data.china.counties = {");
            foreach (var province in provinces)
            {
                sbCitites.AppendFormat("{0}:{1},", province.Id, GetItems(province.ChinaCity));
                foreach (var city in province.ChinaCity)
                {
                    sbCounties.AppendFormat("{0}:{1},", city.Id, GetItems(city.ChinaCounty));
                }
            }
            sbCitites.Append("};\r\n");
            sbCounties.Append("};\r\n");
            writer.Append(sbCitites.ToString());
            writer.Append(sbCounties.ToString());
        }

        private string GetItems(dynamic items)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("[");
            sb.AppendFormat("{{Value:0,Text:'未填'}},");
            foreach (var item in items)
            {
                sb.AppendFormat("{{Value:{0},Text:'{1}'}},", item.Id, item.Name);
            }
            sb.AppendFormat("]");
            return sb.ToString();
        }
    }
}