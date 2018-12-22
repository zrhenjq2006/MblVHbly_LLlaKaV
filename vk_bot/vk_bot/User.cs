using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vk_bot
{
    class User
    {
        public Response[] response;
        public class Response
        {
            public string id;
            public string first_name;
            public string last_name;
            public string photo_50;
            public string photo_100;
        }
    }





    public class groupsGet
    {
        public Response response

        { get; set; }
        public class Item
        {
            public int id { get; set; }
            public string name { get; set; }
            public string screen_name { get; set; }
            public int is_closed { get; set; }
            public string type { get; set; }
            public string photo_100 { get; set; }
        }

        public class Response
        {
            public int count { get; set; }
            public Item[] items { get; set; }
        }
    }
}
