using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixivAPIWrapper
{
    /// <summary>
    /// ユーザーを表すクラスです。
    /// </summary>
    public class User
    {
        private readonly PixivAPI Api;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Uri MobileURL { get; private set; }
        public string Ename { get; private set; }
        public Uri Thumbnail { get; private set; }

        public User(PixivAPI api, string[] data)
        {
            this.Api = api;
            Id = int.Parse(data[1]);
            Name = data[5];
            Thumbnail = new Uri(data[6]);
            Ename = data[24];
        }

        /// <summary>
        /// このユーザの投稿画像数を取得する
        /// </summary>
        /// <returns>投稿画像総数</returns>
        public int GetImageSize()
        {
            return this.Api.GetImageSize(this.Id);
        }
    }
}
