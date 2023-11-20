using EmailAPI.Configuration;
using EmailAPI.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EmailAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task<bool> EnviarEmailAsync(EmailData emailData)
        {
            try
            {
                MimeMessage emailMessage = new();
                emailMessage.From.Add(new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId));
                emailMessage.To.Add(new MailboxAddress(emailData.EmailToName, emailData.EmailToId));
                emailMessage.Subject = emailData.EmailSubject;
                BodyBuilder emailBodyBuilder = new()
                {
                    HtmlBody = emailData.EmailBody
                };
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                using (var emailClient = new SmtpClient())
                {
                    emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    // await emailClient.ConnectAsync(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                    await emailClient.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                    await emailClient.AuthenticateAsync(_emailSettings.EmailId, _emailSettings.Password);
                    await emailClient.SendAsync(emailMessage);
                    await emailClient.DisconnectAsync(true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                //throw new InvalidOperationException(ex.Message);
            }
        }


        public async Task<bool> EnviarEmailComAnexoAsync(EmailData emailData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId));
                emailMessage.To.Add(new MailboxAddress(emailData.EmailToName, emailData.EmailToId));
                emailMessage.Subject = emailData.EmailSubject;
                BodyBuilder emailBodyBuilder = new()
                {
                    HtmlBody = emailData.EmailBody
                };

                if (emailData.EmailAttachments != null)
                {
                    byte[] attachmentFileByteArray;
                    foreach (IFormFile attachmentFile in emailData.EmailAttachments)
                    {
                        if (attachmentFile.Length > 0)
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                attachmentFile.CopyTo(memoryStream);
                                attachmentFileByteArray = memoryStream.ToArray();
                            }
                            emailBodyBuilder.Attachments.Add(attachmentFile.FileName, attachmentFileByteArray, ContentType.Parse(attachmentFile.ContentType));
                        }
                    }
                }

                emailMessage.Body = emailBodyBuilder.ToMessageBody();


                using (var emailClient = new SmtpClient())
                {
                    emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await emailClient.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                    //await emailClient.ConnectAsync(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                    await emailClient.AuthenticateAsync(_emailSettings.EmailId, _emailSettings.Password);
                    await emailClient.SendAsync(emailMessage);
                    await emailClient.DisconnectAsync(true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                //throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> EnviarEmailUsandoTemplatesAsync(EmailData emailData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId));
                emailMessage.To.Add(new MailboxAddress(emailData.EmailToName, emailData.EmailToId));
                emailMessage.Subject = emailData.EmailSubject;


                //string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\Template1.html";
                //string EmailTemplateText = File.ReadAllText(FilePath);
                //EmailTemplateText = string.Format(EmailTemplateText, emailData.EmailToName, DateTime.Now.Date.ToShortDateString());

                //string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\ConclusaoPedido.html";
                //string EmailTemplateText = File.ReadAllText(FilePath);
                //EmailTemplateText = string.Format(EmailTemplateText, 123456);

                string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\ConfirmacaoConta.html";
                string EmailTemplateText = File.ReadAllText(FilePath);
                EmailTemplateText = string.Format(EmailTemplateText, emailData.EmailToId, emailData.EmailToName);


                BodyBuilder emailBodyBuilder = new()
                {
                    HtmlBody = EmailTemplateText
                };

                if (emailData.EmailAttachments != null)
                {
                    byte[] attachmentFileByteArray;
                    foreach (IFormFile attachmentFile in emailData.EmailAttachments)
                    {
                        if (attachmentFile.Length > 0)
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                attachmentFile.CopyTo(memoryStream);
                                attachmentFileByteArray = memoryStream.ToArray();
                            }
                            emailBodyBuilder.Attachments.Add(attachmentFile.FileName, attachmentFileByteArray, ContentType.Parse(attachmentFile.ContentType));
                        }
                    }
                }




                emailMessage.Body = emailBodyBuilder.ToMessageBody();


                using (var emailClient = new SmtpClient())
                {
                    emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await emailClient.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                    //await emailClient.ConnectAsync(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                    await emailClient.AuthenticateAsync(_emailSettings.EmailId, _emailSettings.Password);
                    await emailClient.SendAsync(emailMessage);
                    await emailClient.DisconnectAsync(true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                //throw new InvalidOperationException(ex.Message);
            }
        }








    }
}
