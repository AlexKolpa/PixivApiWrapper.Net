using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixivAPIWrapper
{
    /// <summary>
    /// 「マンガ」を表すクラスです。
    /// </summary>
    /// <remarks>
    /// Illustとは違い、imageURLsにフルサイズの画像のURLが格納されています。
    /// </remarks>
    public class Manga : Image
    {
        public Uri[] ImageURLs { get; protected set; }
        public int Pages { get; protected set; }

        public Manga(PixivAPI api, string[] data)
            : base(api, data)
        {
            this.Pages = int.Parse(data[19]);

            string rawMobileURL = this.MobileURL.ToString();
            List<Uri> urls = new List<Uri>();
            string big = (this.Id > 10000000) ? "_big" : "";
            for (int i = 0; i < this.Pages; i++)
            {
                // Pixivの漫画、原寸サイズのファイル名が、1000万を境に切り替わっているらしい・・・？
                // 1000万以前は、「_big」がついていないようだ。
                Uri aPage = new Uri(String.Format("{0}{1}{2}_p{3}.{4}", rawMobileURL.Substring(0, rawMobileURL.LastIndexOf("mobile")), this.Id, big, i, this.Ext));
                urls.Add(aPage);
            }
            this.ImageURLs = urls.ToArray();
            this.ImageURL = this.ImageURLs[0];
        }
    }
}
