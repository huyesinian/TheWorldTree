using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace TheWorldTree.Models
{
    /// <summary>
    /// redis里面的相关查询
    /// </summary>
    public class RedisAction
    {
        public RedisManagerPool redisManger = new RedisManagerPool("127.0.0.1:6379");//Redis的连接字符串
        //var redis = redisManger.GetClient();

        /// <summary>
        /// 通过传入参数到redis里面查询数据
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        public string GetLoginResult(string parameter)
        {
            var redis = redisManger.GetClient();
            return redis.Get<string>(parameter);

        }

        /// <summary>
        /// 查询用户IP错误登录次数
        /// </summary>
        /// <param name="UserIP">用户IP</param>
        /// <returns></returns>
        public string GetClientIPNum(string userIP)
        {
            var redis = redisManger.GetClient();
            var num = int.Parse(redis.Get<string>(userIP) ?? "0");
            return num >= 3 ? "当前IP错误登录次数以达到今日上限,限制登陆" : "";
        }

        /// <summary>
        /// 更新用户错误登录次数
        /// </summary>
        /// <param name="UserIP"></param>
        /// <returns></returns>
        public void UpdateClientIPErrorNum(string userIP)
        {
            var redis = redisManger.GetClient();
            var num = int.Parse(redis.Get<string>(userIP) ?? "0")+1;
            redis.Set(userIP, num);
            if (num >= 3)
            {
                SetClientIPDeadLine(userIP);
            }


        }

        /// <summary>
        /// 设置被限制IP的过期时间戳
        /// </summary>
        /// <param name="userIP"></param>
        public void SetClientIPDeadLine(string userIP)
        {
            var redis = redisManger.GetClient();
            var dt = DateTime.Now.AddSeconds(86400);
            redis.ExpireEntryAt(userIP, dt);
        }


        /// <summary>
        /// 查询用户IP当日提交留言次数
        /// </summary>
        /// <param name="UserIP">用户IP</param>
        /// <returns></returns>
        public string GetMsgIPNum(string userIP)
        {
            var redis = redisManger.GetClient();
            var num = int.Parse(redis.Get<string>(userIP) ?? "0");
            return num >= 3 ? "留言次数以达到当日上限" : "";
        }
    }
}
