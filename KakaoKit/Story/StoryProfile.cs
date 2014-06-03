using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KakaoKit.Story
{
    public class StoryProfile : StoryBase
    {
        [Newtonsoft.Json.JsonIgnore]
        public bool IsProfileExist { get { if (error == null) { return true; } else { return false; } } }

        private string error { get; set; }

        public Section[] sections { get; set; }
        public StoryPost[] activities { get; set; }
        public StoryAuthorID profile { get; set; }

        public class Section
        {
            /// <summary>
            /// 개수
            /// </summary>
            public int count { get; set; }
            public string media_url { get; set; }
            /// <summary>
            /// 타입
            /// </summary>
            public string type { get; set; }
        }
       
    }

}
