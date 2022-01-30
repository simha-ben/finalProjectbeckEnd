using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ServisesBL
{
   public static class Mail
    {
        public static void SendMail(string subject, string body, string Address,string programId=null, string from = null, string PathToFile = null)
        {
            // שם המייל- ההזדהות
            MailMessage msg = new MailMessage() { From = new MailAddress("weather.mailer.project@gmail.com", "easy plan") };
            if (from != null)
            {
                //למי להחזיר את המייל(ממש לא חובה)
                msg.ReplyToList.Add(from);
            }
            //כתובת
            msg.To.Add(Address);
            //נושא
            msg.Subject = subject;
            //גוף התוכן
            msg.Body = body;
            if(subject.IndexOf("תוכנית חדשה במערכת") >= 0)
            {
              msg.Body=body+("<a href=http://localhost:63312/api/admin/changeStatus/" +programId+"/1>לחץ כאן לאישור התוכנית</a>");
            }
            //האם הצורה היא HTML כלומר DIV וכו או סתם טקסט
            msg.IsBodyHtml = true;

            //msg.Priority = MailPriority.High;
            //צירוף קובץ  למייל
            if (PathToFile != null)
            {
                try
                {
                    Attachment attach;
                    attach = new Attachment(PathToFile, "application/pdf");
                    msg.Attachments.Add(attach);
                }
                catch (Exception e)
                {

                    throw e;
                }

            }
            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("weather.mailer.project@gmail.com", "wmp123456");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(msg);
                }
                if (PathToFile != null)
                {
                    msg.Attachments.Dispose();

                }
            }
            catch (Exception e)
            {
                throw e;

            }
        }

    }
}
