using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Apps.Models.Func
{
    /// <summary>
    /// 邮件发送
    /// </summary>
    public class MailIntegration
    {
        public IConfiguration Configuration { get; }
        public MailIntegration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

       

        /// <summary>
        /// 邮件发送方法
        /// </summary>
        /// <param name="TInfo">接收人信息</param>
        /// <param name = "title" > 邮件标题 </ param >
        /// <param name="mailContent">邮件内容</param>
        /// <param name="sysMailInfo">邮件验证相关信息</param>
        /// <returns></returns>
        public string SendMailMethod(object TInfo, string title, string mailContent)
        {
            var sysMailInfo = Configuration.GetConnectionString("SendmailPara");
            try
            {
                if ("接收人邮箱地址".Length > 0)
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(sysMailInfo[1].ToString(), sysMailInfo[1].ToString()));//发件人名称，发件人地址
                    message.To.Add(new MailboxAddress("接收人名字", "接收人邮箱地址"));
                    message.Subject = title;
                    message.Body = new TextPart("plain")
                    {
                        Text = mailContent
                    };
                    using (var client = new SmtpClient())
                    {
                        // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                        client.Connect(sysMailInfo[0].ToString(), 587, false);
                        // Note: only needed if the SMTP server requires authentication
                        client.Authenticate(sysMailInfo[2].ToString(), sysMailInfo[3].ToString());
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Info((new StackTrace()).GetFrame(1).GetMethod().Name + ":" + ex.ToString());
                return ex.ToString();
            }

            return "OK";
        }

        /// <summary>
        /// 发送邮件所需参数
        /// </summary>
        /// <param name="no">编码</param>
        /// <param name="fUserId">当前需要提示的人</param>
        /// <param name="tUserId">当前需要审核的人</param>
        /// <param name="modelName">功能模板名（获取相关的标题和内容）</param>
        /// <param name="departName">部门名称</param>
        /// <returns></returns>
        public string GetMailElement(string no, string fUserId, string tUserId, string modelName, string departName)
        {
           
            try
            {
                for (int i = 0; i < 0; i++)
                {
                    string mailcont = "";
                    switch (i)
                    {
                        case 0:
                            mailcont = "Dear，" + "???"+ ",您好：\r\n";
                            mailcont += "   有编号为" + no + "的" + modelName + "，需要您的处理！" + "\r\n";
                            mailcont += "   申请人为：" + "???" + "，所在部门：" + departName + "，请您在方便的时候进行处理,以下是我们公司的OA网址！\r\n";
                            mailcont += "    http://192.168.16.69:91  (若您在公司，请使用内部IP登录)或：http://183.233.194.90:91 (若您现在不在公司，请使用外部IP登录)\r\n\r\n";
                            mailcont += "    注：此邮件为美信OA系统自动发送，请不要直接回复，若有疑问请联系IT部同事，非常感谢！";
                            break;
                        case 1:
                            mailcont = "Dear，" + "???" + ",您好：\r\n";
                            mailcont += "   你有编号为" + no + "的" + modelName + "，正在被审核，具体审核情况请在OA系统中查看！" + "\r\n";
                            mailcont += "以下是我们公司的网址\r\n";
                            mailcont += "http://192.168.16.69:91 (若您在公司，请使用内部IP登录)或：http://183.233.194.90:91 (若您现在不在公司，请使用外部IP登录)\r\n\r\n";
                            mailcont += "注：此邮件为美信OA系统自动发送，请不要直接回复，若有疑问请联系IT部同事，非常感谢！";
                            break;
                        default:
                            break;
                    }
                    string s = SendMailMethod("???", modelName, mailcont);
                    if (s != "OK")
                    {
                        return s;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Info((new StackTrace()).GetFrame(1).GetMethod().Name + ":" + ex.ToString());
                return ex.ToString();
            }

            return "OK";

        }

        public async  Task<string> EmailAsnyc(string no, string fUserId, string tUserId, string modelName, string departName)
        {
            try
            {
                return await Task.Run(() => { return GetMailElement(no, tUserId, modelName, departName, fUserId); });
            }
            catch (Exception ex)
            {
                Logger.Info((new StackTrace()).GetFrame(1).GetMethod().Name + ":" + ex.ToString());
                return null;
            }
        }


    }
}
