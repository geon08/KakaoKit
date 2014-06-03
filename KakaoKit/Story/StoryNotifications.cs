using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KakaoKit.Story
{
    public class StoryNotification : StoryBase
    {
        //internal StoryNotification() : base() { }

        //internal static StoryNotification Parse(string Text)
        //{
        //    StoryNotification Output = new StoryNotification();

        //    //try
        //    //{
        //        Output = Util.Parser.ParseJson<StoryNotification>(Text);
        //        Output.Loaded();
        //    //}
        //    //catch { throw new Exception(); }
        //    return Output;
        //}

        public Notification[] Notifies { get; set; }

        public class Notification
        {
            public string message { get; set; }
            public string content { get; set; }
            public string id { get; set; }
            public string thumbnail_url { get; set; }
            public bool is_new { get; set; }
            public string thumbnail_text { get; set; }
            public string scheme { get; set; }
            public Decorator[] decorators { get; set; }
            public DateTime created_at { get; set; }
            public StoryAuthorID actor { get; set; }
            public string key { get; set; }
            public string emotion { get; set; }

            public class Decorator
            {
                public string id { get; set; }
                public string text { get; set; }
                public string type { get; set; }
            }
        }

        
    }
}



