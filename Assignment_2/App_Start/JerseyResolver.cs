using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.FriendlyUrls.Resolvers;

namespace Assignment_2
{
	public class JerseyResolver : WebFormsFriendlyUrlResolver
	{
		/*public override string ConvertToFriendlyUrl(string path)
		{
			if (path.Contains("UL/"))
			{
				path = "~/" + path.Replace("UL/", "");
				path = path.Replace(".aspx", "");
				return path;
			}
			return base.ConvertToFriendlyUrl(path);
		}*/

		public override void PreprocessRequest(HttpContextBase httpContext, IHttpHandler httpHandler)
		{
			string path = httpContext.Request.CurrentExecutionFilePath;
			if (path.Contains("UL/"))
			{
				httpContext.Response.Redirect("~/" + path.Replace("UL/", ""));
			}

			base.PreprocessRequest(httpContext, httpHandler);
		}
	}
}