﻿using System;
using System.Net;
using System.Threading.Tasks;
using Abp.Rpc.Messages;

namespace Abp.Rpc.Transport
{
    /// <summary>
    /// 消息监听者。
    /// </summary>
    public class MessageListener : IMessageListener
    {
        #region Implementation of IMessageListener

        /// <summary>
        /// 接收到消息的事件。
        /// </summary>
        public event ReceivedDelegate Received;

        /// <summary>
        /// 触发接收到消息事件。
        /// </summary>
        /// <param name="sender">消息发送者。</param>
        /// <param name="message">接收到的消息。</param>
        /// <returns>一个任务。</returns>
        public async Task OnReceived(IMessageSender sender, TransportMessage message)
        {
            if (Received == null)
                return;
            await Received(sender, message);
        }

        public async Task StartAsync(EndPoint endPoint)
        {
            await Task.FromResult(1);
            return;
        }

        #endregion Implementation of IMessageListener
    }
}