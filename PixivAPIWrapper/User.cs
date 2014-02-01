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

        public User(PixivAPI api, string[] data)
        {
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
