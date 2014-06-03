using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KakaoKit.Story
{
    public class StoryComment
    {
        
            public string id { get; set; }
            public string text { get; set; }
            public string activity_id { get; set; }
            public DateTime created_at { get; set; }
            public StoryAuthorID writer { get; set; }
            public Decorator[] decorators { get; set; }

            public class Decorator
            {
                public string text { get; set; }
                public string type { get; set; }
                public string id { get; set; }
            }
    }
    
}
