<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.BodyFormat = System.Web.Mail.MailFormat.Text;
        mail.From = "info@parsianmovie.com";
        mail.To = "webmaster@parsianmovie.com";
        mail.Subject = "::Error::";
        mail.Priority = System.Web.Mail.MailPriority.High;
        mail.Body = Server.GetLastError().ToString();
        System.Web.Mail.SmtpMail.SmtpServer = "localhost";
        System.Web.Mail.SmtpMail.Send(mail);

        Session.Add("errormsg", Server.GetLastError().ToString());
        
        
        /*Dim mail As New MailMessage()
        Dim ErrorMessage = "The error description is as follows : " &_
            Server.GetLastError.ToString
        mail.To = "administrator@domain.com"
        mail.Subject = "Error in the Site"
        mail.Priority = MailPriority.High
        mail.BodyFormat = MailFormat.Text
        mail.Body = ErrorMessage
        SmtpMail.Send(mail)*/

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
