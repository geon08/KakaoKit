using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace KakaoKit.Story
{

    public class StoryFeed : StoryBase
    {

        internal StoryFeed() : base() { }

        internal static StoryFeed Parse(string Text)
        {
            StoryFeed Output = new StoryFeed();
            
            //try
            //{
                Output = Util.Parser.ParseJson<StoryFeed>(Text);
                Output.Loaded();
            //}
            //catch { throw new Exception(); }
                return Output;
        }
       
        /// <summary>
        /// 소식의 게시물들을 가져옵니다.
        /// </summary>
        [JsonProperty("feeds")]
        public StoryPost[] Feeds { get; set; }
        

        /*
        public class Feed
        {
            [JsonProperty("media_type")]
            public string MediaType { get; set; }
            [JsonProperty("modifiable")]
            public bool modifiable { get; set; }
            public int share_count { get; set; }
            [JsonProperty("object")]
            public InheritObject InheritedContent { get; set; }
            [JsonProperty("author")]
            public Author PostAuthor { get; set; }
            [JsonProperty("feed_id")]
            public string FeedId { get; set; }
            public bool downloadable { get; set; }
            public string id { get; set; }
            public string verb { get; set; }
            public bool sharable { get; set; }
            [JsonProperty("created_at")]
            public DateTime PostedDate { get; set; }

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
            public bool liked { get; set; }
            public int with_tag_count { get; set; }
            public string permission { get; set; }

            /// <summary>
            /// 내용
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; set; }
            public bool has_unread_reaction { get; set; }
            public DateTime updated_at { get; set; }

            /// <summary>
            /// 느낌 수
            /// </summary>
            [JsonProperty("like_count")]
            public int LikeCount { get; set; }

            /// <summary>
            /// 느낌 목록
            /// </summary>
            [JsonProperty("likes")]
            public Like[] Likes { get; set; }

            /// <summary>
            /// 덧글 목록
            /// </summary>
            [JsonProperty("comments")]
            public Comment[] Comments { get; set; }
            public ExternalLink scrap { get; set; }
            public Media[] media { get; set; }
            public bool plus_subscribed { get; set; }
            public DateTime content_updated_at { get; set; }
            public Closest_With_Tags[] closest_with_tags { get; set; }
        }
        public class InheritObject
        {
            public int comment_count { get; set; }
            public string media_type { get; set; }
            public bool modifiable { get; set; }
            public int share_count { get; set; }
            public bool liked { get; set; }
            public int with_tag_count { get; set; }
            public string permission { get; set; }
            public Author actor { get; set; }
            public bool deleted { get; set; }
            public bool downloadable { get; set; }
            public string id { get; set; }
            public string object_type { get; set; }
            public string content { get; set; }
            public bool has_unread_reaction { get; set; }
            public DateTime updated_at { get; set; }
            public string verb { get; set; }
            public int like_count { get; set; }
            public bool sharable { get; set; }
            public DateTime created_at { get; set; }
            public bool with_me { get; set; }
            public bool blinded { get; set; }
            public bool required { get; set; }
            public Media[] media { get; set; }
            public bool plus_subscribed { get; set; }
        }

        public class Author
        {
            public string profile_thumbnail_url { get; set; }
            public string birthday { get; set; }
            //public bool is_birthday { get; set; }

            /// <summary>
            /// 상태메세지
            /// </summary>
            public Status_Objects[] status_objects { get; set; }
            public string bg_image_url { get; set; }
            public string birth_type { get; set; }
            public int default_bg_id { get; set; }
            public string type { get; set; }
            public bool is_valid_user { get; set; }
            public bool is_favorite { get; set; }
            public string relationship { get; set; }
            public string id { get; set; }
            public string display_name { get; set; }
            public int friend_count { get; set; }
            public int activity_count { get; set; }
            public string profile_image_url { get; set; }
            public int follower_count { get; set; }
        }



        public class Status_Objects
        {
            public string message { get; set; }
            public string object_type { get; set; }

            public string album_id { get; set; }
            public string title { get; set; }
            public Play_Url play_url { get; set; }
            public Player player { get; set; }
            public string artist_id { get; set; }
            public string album_image { get; set; }
            public string artist { get; set; }
            public string album_title { get; set; }
            public string track_id { get; set; }
            public string playtime { get; set; }
        }

        public class Media
        {

            public string url { get; set; }
            public string thumbnail_url { get; set; }
            public string origin_url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string preview_url { get; set; }
        }



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
            public Author actor { get; set; }
            public string emotion { get; set; }
        }





        public class Comment
        {
            public string id { get; set; }
            public string text { get; set; }
            public string activity_id { get; set; }
            public DateTime created_at { get; set; }
            public Author writer { get; set; }
            public Decorator[] decorators { get; set; }
        }




        public class Play_Url
        {
            public string android { get; set; }
            public string ios { get; set; }
        }

        public class Player
        {
            public string icon { get; set; }
            public string name { get; set; }
        }


        public class Decorator
        {
            public string text { get; set; }
            public string type { get; set; }
            public string id { get; set; }
        }


        public class Closest_With_Tags
        {
            public string relationship { get; set; }
            public string profile_thumbnail_url { get; set; }
            public string id { get; set; }
            public string display_name { get; set; }
            public string type { get; set; }
        }*/
    }
}
