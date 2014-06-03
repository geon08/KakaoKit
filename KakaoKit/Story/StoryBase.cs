using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace KakaoKit.Story
{
    public class StoryBase
    {

        internal static T Parse<T>(string Text) where T : Story.StoryBase, new()
        {
            T Output = new T();

            //try
            //{
            Output = Util.Parser.ParseJson<T>(Text);
            Output.Loaded();
            //}
            //catch { throw new Exception(); }
            return Output;
        }

        internal StoryBase()
        {
            IsLoaded = false;
        }

        internal void Loaded()
        {
            IsLoaded = true;
            dt = DateTime.Now;
        }

        /// <summary>
        /// 로드 되었는지 여부입니다.
        /// </summary>
        [JsonIgnore]
        public bool IsLoaded { get; set; }
        /// <summary>
        /// 정보를 가져온 시간을 확인합니다.
        /// </summary>
        [JsonIgnore]
        public DateTime RecievedTime { get { return dt; } }
        [JsonIgnore]
        private DateTime dt;
    }
}
