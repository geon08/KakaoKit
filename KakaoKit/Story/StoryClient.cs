using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace KakaoKit.Story
{
    public partial class StoryClient
    {
        /// <summary>
        /// 카카오스토리 클라이언트의 메인 세션입니다.
        /// </summary>
        public Session StorySession { get; set; }

        /// <summary>
        /// 로그인이 되어있는지 여부를 확인합니다.
        /// </summary>
        public bool IsLoggedIn { get { return IsLoggedInV; } }
        private bool IsLoggedInV;


        public StoryClient()
        {
            IsLoggedInV = false;
            StorySession = new Session();
        }


        /// <summary>
        /// 카카오스토리에 로그인 합니다.
        /// </summary>
        /// <param name="Email">로그인할 이메일</param>
        /// <param name="Password">로그인할 비밀번호</param>
        /// <returns></returns>
        public ELoginResults Login(string Email, string Password)
        {
            try
            {
                string Result = StorySession.RequestPOST("https://accounts.kakao.com/external/login", String.Format("email={0}&password={1}&callback_url=", Email.Replace("@", "%40"), Password, ""),true);
                if (Result.Contains("Email or password do not match."))
                {
                    return ELoginResults.WrongIDorPassword;
                }
                
            }
            catch (NetworkConnectionException)
            {
                return ELoginResults.ConnectionFail;
            }
            IsLoggedInV=true;
            return ELoginResults.Success;
        }

        /// <summary>
        /// 최신 소식을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public StoryFeed GetLatestFeeds()
        {
            string Result = StorySession.RequestGET("http://story.kakao.com/api/feeds");
            return StoryFeed.Parse(Result);
        }

        /// <summary>
        /// 현재 알림을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public StoryNotification GetNotifications()
        {
            string Result = "{\"Notifies\": " + StorySession.RequestGET("http://story.kakao.com/api/notifications") + "}";
            //return StoryNotification.Parse(Result);
            return StoryBase.Parse<StoryNotification>(Result); 
        }

        /// <summary>
        /// 해당 ID의 유저의 프로필을 가져옵니다.
        /// </summary>
        /// <param name="ID">유저의 ID ("me" 를 입력하면 자신의 프로필을 가져옵니다.)</param>
        /// <returns></returns>
        public StoryProfile GetProfile(string ID)
        {
            string Result = StorySession.RequestGET("https://story.kakao.com/api/profiles/" + ID);
            return StoryBase.Parse<StoryProfile>(Result);
        }

        #region Story

        public void AddStringComment(string ArticleID, string Content)
        {
            StorySession.RequestPOST("https://story.kakao.com/api/activities/" + ArticleID + "/comments", "text=" + Content + "&decorater=[{\"type\":\"text\",\"text\":\"" + Content + "\"}]", false, "");
        }

        #endregion

        #region Friends

        /// <summary>
        /// 친구 목록을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public StoryAuthorID[] GetFriends()
        {
            string Result = "{\"result\": " + StorySession.RequestGET("https://story.kakao.com/api/friends") + "}";
            //return StoryNotification.Parse(Result);
            return Util.Parser.ParseJson<StoryAuthorID[]>(Result);
            
        }

        /// <summary>
        /// 현재 알림을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public StoryNotification GetNotifications()
        {
            string Result = "{\"Notifies\": " + StorySession.RequestGET("http://story.kakao.com/api/notifications") + "}";
            //return StoryNotification.Parse(Result);
            return StoryBase.Parse<StoryNotification>(Result);
        }

        /// <summary>
        /// 친구 추가 요청을 보냅니다.
        /// </summary>
        /// <param name="ID">유저의 ID</param>
        public void AddFriend(string ID)
        {
            StorySession.RequestPOST("https://story.kakao.com/api/invitations", "has_profile=true&friend_id=" + ID, false, "https://story.kakao.com/" + ID);
        }

        /// <summary>
        /// 친구 추가 요청을 허용합니다.
        /// </summary>
        /// <param name="ID">유저의 ID</param>
        public void AcceptFriend(string ID)
        {
            StorySession.RequestPOST("https://story.kakao.com/api/invitations/accpet", "has_profile=true&inviter_id=" + ID, false, "https://story.kakao.com/" + ID)
        }

        #endregion
    }
}
