using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookSandbox.Controllers
{
    public class MyController : ApiController
    {
        public string GetDefaultEcho()
        {
            return string.Format("GetDefaultEcho: hello from 'default'");
        }

        public string GetEcho(string echo)
        {
            return string.Format("GetEcho: hello from '{0}'", echo ?? "null");
        }

        //public string GetSayHello()
        //{
        //    return "GetSayHello: Hi there!";
        //}

        public string GetDetails(int id)
        {
            return string.Format("GetDetails: details for id='{0}'", id);
        }
        
        //public string GetEcho(string str)
        //{
        //    return string.Format("GetEcho: hello from '{0}'", str);
        //}

        //public string GetDetailsEx(string category, int year)
        //{
        //    return string.Format("GetDetailsEx: details for ['{0}' - {1}]", category, year);
        //}
    }
}
