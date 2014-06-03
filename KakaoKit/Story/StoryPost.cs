using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace KakaoKit.Story
{

    public class StoryPost : StoryArticle
    {
        
        
        
        
        [JsonProperty("feed_id")]
        public string FeedId { get; set; }



        

        /// <summary>
        /// 느낌 목록
        /// </summary>
        [JsonProperty("likes")]
        public Like[] Likes { get; set; }

        /// <summary>
        /// 덧글 목록
        /// </summary>
        [JsonProperty("comments")]
        public StoryComment[] Comments { get; set; }

        public ExternalLink scrap { get; set; }

        [JsonProperty("object")]
        public InheritObject InheritedContent { get; set; }
        public DateTime content_updated_at { get; set; }
        public Closest_With_Tags[] closest_with_tags { get; set; }

        public class ExternalLink
        {
            public string title { get; set; }
            public string description { get; set; }
            public string url { get; set; }
            public string type { get; set; }
            public string host { get; set; }
            public bool is_opengraph { get; set; }
            public string requested_url { get; set; }
            public string[] image { get; set; }
        }

        public class Like
        {
            public string id { get; set; }
            public DateTime created_at { get; set; }
            public StoryAuthorID actor { get; set; }
            public string emotion { get; set; }
        }


        

        public class Closest_With_Tags
        {
            public string relationship { get; set; }
            public string profile_thumbnail_url { get; set; }
            public string id { get; set; }
            public string display_name { get; set; }
            public string type { get; set; }
        }
    }
}
