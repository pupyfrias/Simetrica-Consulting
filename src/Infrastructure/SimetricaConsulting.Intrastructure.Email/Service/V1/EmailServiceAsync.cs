﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SimetricaConsulting.Application.Contracts.Services.V1;
using SimetricaConsulting.Application.Models.Dtos.V1.Email;
using SimetricaConsulting.Email.Settings;
using System.Net.Security;

namespace SimetricaConsulting.Email.Service.V1
{
    public class EmailServiceAsync : IEmailServiceAsync
    {
        private readonly MailSettings _mailSettings;

        public EmailServiceAsync(IOptions<MailSettings> option)
        {
            _mailSettings = option.Value;
        }

        public async Task SendEmailAsync(EmailDto emailDto)
        {
            var bodyBuilder = new BodyBuilder { HtmlBody = emailDto.Body };
            var mimeMessage = new MimeMessage
            {
                Subject = emailDto.Subject,
                Body = bodyBuilder.ToMessageBody()
            };

            mimeMessage.To.Add(MailboxAddress.Parse(emailDto.To));
            mimeMessage.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.EmailFrom));

            using var smtpClient = new SmtpClient();
            smtpClient.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            {
                return sslPolicyErrors == SslPolicyErrors.None;
            };

            try
            {
                await smtpClient.ConnectAsync(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                await smtpClient.AuthenticateAsync(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                await smtpClient.SendAsync(mimeMessage);
            }
            finally
            {
                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}