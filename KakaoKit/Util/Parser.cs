using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace KakaoKit.Util
{
   public class Parser
    {
       
        public static string MidSplit(string Text, string Separater1, string Separater2)
        {
            return Text.Split(new string[] {Separater1},StringSplitOptions.None)[1].Split(new string[] {Separater2},StringSplitOptions.None)[0];
        }
        public static T ParseJson<T>(string Text)
        {
            return (T)JsonConvert.DeserializeObject<T>(Text);
        }
    }


}