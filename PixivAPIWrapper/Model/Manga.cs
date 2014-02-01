using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixivAPIWrapper.Model
{
    /// <summary>
    /// 「マンガ」を表すクラスです。
    /// </summary>
    /// <remarks>
    /// Illustとは違い、imageURLsにフルサイズの画像のURLが格納されています。
    /// </remarks>
    public class Manga : Illustration
    {
        public Manga(int id, int authorId, string title, string authorName, string date, 
            Tag[] tags, int point, int feedback, int views, string caption, 
            string ext, string server, Uri thumbUrl, Uri mobileUrl, string tool, 
            Uri imageUrl, Uri pageUrl , Uri[] imageUrLs, int pageCount) 
            : base(id, authorId, title, authorName, date, tags, point, 
            feedback, views, caption, ext, server, thumbUrl, mobileUrl, tool, imageUrl, pageUrl)
        {
            ImageURLs = imageUrLs;
            PageCount = pageCount;
        }

        internal Manga(PixivObjectFactory.MangaTransferObject obj)
            :base(obj)
        {
            ImageURLs = obj.ImageUrls;
            PageCount = obj.PageCount;
        }

        public Uri[] ImageURLs { get; protected set; }
        public int PageCount { get; protected set; }

        /*public Manga(string[] data)
            : base(data)
        {
            this.PageCount = int.Parse(data[19]);

            string rawMobileURL = this.MobileURL.ToString();
            List<Uri> urls = new List<Uri>();
            string big = (this.Id > 10000000) ? "_big" : "";
            for (int i = 0; i < this.PageCount; i++)
            {
                // Pixivの漫画、原寸サイズのファイル名が、1000万を境に切り替わっているらしい・・・？
                // 1000万以前は、「_big」がついていないようだ。
                Uri aPage = new Uri(String.Format("{0}{1}{2}_p{3}.{4}", rawMobileURL.Substring(0, rawMobileURL.LastIndexOf("mobile")), this.Id, big, i, this.Ext));
                urls.Add(aPage);
            }
            this.ImageURLs = urls.ToArray();
            this.ImageURL = this.ImageURLs[0];
        }*/
    }
}
