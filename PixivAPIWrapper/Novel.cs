using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixivAPIWrapper
{
    public class Novel : Item
    {
        public string Ext { get; protected set; }
        public string Server { get; protected set; }
        /// <summary>
        /// 表紙画像のサムネイルのURLです。イラスト投稿作品である場合は、リファラを設定するなりしないとダウンロードできません。
        /// </summary>
        public Uri ThumbURL { get; protected set; }

        /// <summary>
        /// 表紙画像のURLです。イラスト投稿作品である場合は、リファラを設定するなりしないとダウンロードできません。
        /// </summary>
        public Uri CoverURL { get; protected set; }

        /// <summary>
        /// 表紙が標準セットの画像ならばtrue。作者がアップロードしたものならfalse。
        /// </summary>
        public bool IsDefaultCover { get; protected set; }

        public Uri TextURL { get; protected set; }

        public Novel(PixivAPI api, string[] data)
            : base(api, data)
        {
            this.IsDefaultCover = true;
            if (!data[2].Equals("0"))
            {
                this.Ext = data[2];
                this.Server = data[4];
                this.IsDefaultCover = false;
            }
            this.ThumbURL = new Uri(data[6]);
            this.CoverURL = new Uri(data[9]);
            this.TextURL = new Uri(string.Format("http://iphone.pxv.jp/iphone/novel_text.php?id={0}", this.Id));
        }
    }
}
