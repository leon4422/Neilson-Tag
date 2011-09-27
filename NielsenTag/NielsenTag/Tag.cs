using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace NielsenTag
{
    class Tag
    {
        String tag;
        CookieContainer cookieContainer;
        static String pattern = "\\S+/(priv|cgi)-bin/[mkgjiwabso]\"?\"\\S+";//"http://<domain>/[priv|cgi]-bin/[m|k|g|j|i|w|a|b|s|o]?<query_string>";
    }
}
