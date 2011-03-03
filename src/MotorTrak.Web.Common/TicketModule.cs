using System;
using System.Web;
using MotoTrak.Entities;
using Codefire.Configuration;
using Codefire.Extensions;

namespace MotoTrak.Web
{
    public class TicketModule : IHttpModule
    {
        public const string CookieName = "RevolutionTicket";

        #region [ IHttpModule Members ]

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(OnEnter);
            context.EndRequest += new EventHandler(OnLeave);
        }

        #endregion

        private void OnEnter(object source, EventArgs eventArgs)
        {
            var application = source as HttpApplication;
            var context = application.Context;

            var user = LoadIdentity(context);
            context.User = user;
        }

        private void OnLeave(object source, EventArgs eventArgs)
        {
            var application = source as HttpApplication;
            var context = application.Context;

            var user = context.User as UserIdentity;
            SaveIdentity(context, user);

            if (context.Response.StatusCode == 401)
            {
                string currentUrl = GetReturnPath(context);

                var baseUrl = GetBasePath(context);
                var loginUrl = CodefireSection.Config.Web.LoginUrl.FormatWith(baseUrl, currentUrl);
                context.Response.Redirect(loginUrl, false);
            }
        }

        private string GetBasePath(HttpContext context)
        {
            return context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/');
        }

        private string GetReturnPath(HttpContext context)
        {
            string path = context.Request.Path;
            string queryString = context.Request.QueryString.ToString();
            if (!string.IsNullOrEmpty(queryString))
            {
                path = path + "?" + queryString;
            }

            return HttpUtility.UrlEncode(path);
        }

        private UserIdentity LoadIdentity(HttpContext context)
        {
            SecurityTicket ticket;

            var persistor = new TicketPersistor();

            var cookie = context.Request.Cookies[CookieName];
            if (cookie == null)
            {
                ticket = new SecurityTicket();
            }
            else
            {
                ticket = persistor.Deserialize(cookie.Value);
            }

            var user = new UserIdentity(ticket);

            return user;
        }

        private void SaveIdentity(HttpContext context, UserIdentity user)
        {
            if (user == null) return;

            var persistor = new TicketPersistor();

            var ticket = user.Ticket;
            var data = persistor.Serialize(ticket);

            var cookie = new HttpCookie(CookieName);
            cookie.Value = data;
            context.Response.Cookies.Add(cookie);
        }
    }
}