using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace KakaoKit.Story
{
    public class StoryArticle
    {

        [JsonProperty("media_type")]
        public string MediaType { get; set; }
        [JsonProperty("actor")]
        public StoryAuthorID PostAuthor { get; set; }
        [JsonProperty("created_at")]
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// 내용
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
        public Media[] media { get; set; }
        [JsonProperty("share_count")]
        public int ShareCount { get; set; }

        /// <summary>
        /// 나와 함께 게시물 여부
        /// </summary>
        [JsonProperty("with_me")]
        public bool WithMe { get; set; }
        public bool blinded { get; set; }
        public bool required { get; set; }

        /// <summary>
        /// 덧글 수
        /// </summary>
        [JsonProperty("comment_count")]
        public int CommentCount { get; set; }
        public string verb { get; set; }
        public bool plus_subscribed { get; set; }

        /// <summary>
        /// 고유번호
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("modifiable")]
        public bool modifiable { get; set; }

        public bool downloadable { get; set; }
        public bool sharable { get; set; }

        public bool liked { get; set; }

        public int with_tag_count { get; set; }
        public string permission { get; set; }

        public bool has_unread_reaction { get; set; }

        public DateTime updated_at { get; set; }
        /// <summary>
        /// 느낌 수
        /// </summary>
        [JsonProperty("like_count")]
        public int LikeCount { get; set; }
        public bool deleted { get; set; }

        public class Media
        {
            public string url { get; set; }
            public string thumbnail_url { get; set; }
            public string origin_url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string preview_url { get; set; }
        }
    }

    public class InheritObject : StoryArticle
    {
        
        public string object_type { get; set; }
        public string content { get; set; }
    }



}
