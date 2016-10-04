using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
//using TweetSharp;

namespace SocialMedia.Twitter
{
    //public class TweetinviAPI
    //{

    //    public string GetUserInfo_New(string callbackURL)
    //    {
    //        string consumer_key = "Zf7nzDNHgz5ULqyLgCE54fgJV";
    //        string consumer_secret = "twuq4jZ4zuUbkMZQ4kh0UfZutrPY9LHY834a9YMSJy2jJdOD8Z";
    //        string userToken = "325405765-0h2mQP0kwBOTLX15Jb6iVfA83xiM6AMNNPKkSq1G";
    //        string userTokenSecret = "PBaDvdw5K8ntgxTLZDOaU4AN2ob2vsA5b01tAtQZTsFsJ";

    //        TwitterService service = new TwitterService(consumer_key, consumer_secret);

    //        // Step 1 - Retrieve an OAuth Request Token
    //        OAuthRequestToken requestToken = service.GetRequestToken();

    //        // Step 2 - Redirect to the OAuth Authorization URL
    //        Uri uri = service.GetAuthorizationUri(requestToken);
    //        Process.Start(uri.ToString());

    //        // Step 3 - Exchange the Request Token for an Access Token
    //        string verifier = "123456"; // <-- This is input into your application by your user
    //        OAuthAccessToken access = service.GetAccessToken(requestToken, verifier);

    //        // Step 4 - User authenticates using the Access Token
    //        service.AuthenticateWith(access.Token, access.TokenSecret);


    //        return "";
    //    }

    //}
}
