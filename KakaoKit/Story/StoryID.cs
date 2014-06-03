using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace KakaoKit.Story
{
    public class StoryID
    {
        /// <summary>
        /// 아이디를 나타냅니다.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }
        /// <summary>
        /// 이름을 나타냅니다.
        /// </summary>
        [JsonProperty("display_name")]
        public string Name { get; set; }


    }
    public class StoryAuthorID : StoryID
    {
        [JsonIgnore]
        public EAuthorType Type
        {
            get
            {
                if (type == null)
                {
                    return EAuthorType.Normal;
                }
                if (type == "official")
                {
                    return EAuthorType.Plus;
                }
                return EAuthorType.Else;
            }
            set
            {
                if (value == EAuthorType.Normal)
                {
                    type = null;
                }
                if (value == EAuthorType.Plus)
                {
                    type = "official";
                }
                else
                {
                    type = "";
                }
            }
        }



        /// <summary>
        /// 프로필 사진의 주소입니다.
        /// </summary>
        [JsonProperty("profile_thumbnail_url")]
        public string ProfilePictureURL { get; set; }

        /// <summary>
        /// 생일 값을 나타냅니다.
        /// </summary>
        [JsonProperty("birthday")]
        public string Birthday { get; set; }
        [JsonProperty("is_birthday")]
        public bool IsBirthday { get; set; }

        /// <summary>
        /// 상태메세지
        /// </summary>
        public Status[] status_objects { get; set; }


        /// <summary>
        /// 배경 사진의 주소입니다.
        /// </summary>
        [JsonProperty("bg_image_url")]
        public string BackgroundImageURL { get; set; }

        public string birth_type { get; set; }
        public int default_bg_id { get; set; }
        private string type { get; set; }
        public bool is_valid_user { get; set; }
        public bool is_favorite { get; set; }

        /// <summary>
        /// 나와의 친구 관계를 나타냅니다.
        /// </summary>
        [JsonProperty("relationship")]
        public string Relationship { get; set; }



        /// <summary>
        /// 친구 수를 나타냅니다.
        /// </summary>
        [JsonProperty("friend_count")]
        public int FriendCount { get; set; }

        public int activity_count { get; set; }
        public string profile_image_url { get; set; }
        public int follower_count { get; set; }
    }

    public class Status
    {
        public string message { get; set; }
        public string object_type { get; set; }

    }

    public class MusicStatus : Status
    {
        public string album_id { get; set; }
        public string title { get; set; }
        //public Play_Url play_url { get; set; }
        public Player player { get; set; }
        public string artist_id { get; set; }
        public string album_image { get; set; }
        public string artist { get; set; }
        public string album_title { get; set; }
        public string track_id { get; set; }
        public string playtime { get; set; }


        public class Player
        {
            public string icon { get; set; }
            public string name { get; set; }
        }
    }


    

    


    
    

}
