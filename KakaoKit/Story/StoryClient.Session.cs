using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

using System.Diagnostics;
namespace KakaoKit.Story
{
    public partial class StoryClient
    {
        public class Session
        {
            #region Properties


            HttpWebRequest HttpSession { get; set; }
            public bool IsAlive { get { return HttpSession != null; } }
            public string CurrentAddress { get { return HttpSession.RequestUri.AbsolutePath; } }
            private CookieCollection CurrentCookie;

            #endregion

            #region Vars

            //public bool IsAliveV;

            #endregion

            internal Session()
            {
                //IsAliveV = false;
                HttpSession = null;
                CurrentCookie = new CookieCollection();
            }

            private void SetCookie(CookieCollection Cookies)
            {
                CurrentCookie = new CookieCollection();
                foreach (Cookie i in Cookies)
                {
                    CurrentCookie.Add(i);
                }

                return;
            }

            internal void GetCookie(string URL)
            {
                CurrentCookie = new CookieCollection();
                HttpSession = (HttpWebRequest)WebRequest.Create(URL);
                HttpSession.CookieContainer = new CookieContainer();
                HttpSession.CookieContainer.Add(CurrentCookie);
                HttpWebResponse response = (HttpWebResponse)HttpSession.GetResponse();
                CurrentCookie = response.Cookies;

            }

            public string RequestGET(string URL, bool CookieSet = false)
            {
                try
                {
                    HttpSession = (HttpWebRequest)WebRequest.Create(URL);
                    HttpSession.ContentType = "application/x-www-form-urlencoded";
                    HttpSession.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.114 Safari/537.36";
                    HttpSession.Method = "GET";
                    
                    //HttpSession.AllowAutoRedirect = false;
                    HttpSession.UseDefaultCredentials = true;
                    HttpSession.CookieContainer = new CookieContainer();
                    HttpSession.CookieContainer.Add(CurrentCookie);

                    HttpWebResponse Response = (HttpWebResponse)HttpSession.GetResponse();
                    if (CookieSet)
                    {
                        SetCookie(Response.Cookies);
                    }
                    return new StreamReader(Response.GetResponseStream(), System.Text.Encoding.UTF8).ReadToEnd();
                }
                catch (Exception)
                {
                    throw new NetworkConnectionException();
                }
                    

            }

            public string RequestPOST(string URL, string Content, bool CookieSet = false, string Referer = "")
            {
                try
                {
                    HttpSession = (HttpWebRequest)WebRequest.Create(URL);
                    HttpSession.ContentType = "application/x-www-form-urlencoded";
                    HttpSession.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.114 Safari/537.36";
                    HttpSession.Method = "POST";
                    HttpSession.AllowAutoRedirect = false;
                    HttpSession.UseDefaultCredentials = true;

                    if (Referer != "")
                    {
                        HttpSession.Referer = Referer;
                    }

                    HttpSession.CookieContainer = new CookieContainer();
                    HttpSession.CookieContainer.Add(CurrentCookie);

                    StreamWriter Swriter = new StreamWriter(HttpSession.GetRequestStream());
                    Swriter.Write(Content);
                    Swriter.Close();

                    HttpWebResponse Response = (HttpWebResponse)HttpSession.GetResponse();
                    if (CookieSet)
                    {
                        SetCookie(Response.Cookies);
                    }
                    string Result = new StreamReader(Response.GetResponseStream(), System.Text.Encoding.UTF8).ReadToEnd();

                    return Result;
                }
                catch (Exception) 
                {
                    throw new NetworkConnectionException(); 
                }
            }

            public void Disconnect()
            {
                HttpSession = null;
            }
        }
    }
}
