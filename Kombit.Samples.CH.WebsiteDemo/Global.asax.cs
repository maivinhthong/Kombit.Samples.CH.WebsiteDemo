﻿#region

using System;
using System.Web;
using System.Web.Security;
using dk.nita.saml20.identity;
using dk.nita.saml20.Utils;

#endregion

namespace Kombit.Samples.CH.WebsiteDemo
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        ///     Example of a simple IDP selection eventhandler, that just selects the first of the possible IDP Endpoints
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Justification = "This is sample code to demonstrate about how to work with identity provider list.")]
        private readonly IDPSelectionEventHandler _idpSelectionEventHandler =
            (idpEndpoints => idpEndpoints.IDPEndPoints[0]);

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // The OIOSAML.net session could have timed out or the user could have been logget out throug SOAP logout.
            // Sign user out if user was logged in.
            if (!Saml20Identity.IsInitialized() && HttpContext.Current.User != null &&
                HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Response.Redirect(Request.RawUrl); // SignOut first have effect on next request.
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}