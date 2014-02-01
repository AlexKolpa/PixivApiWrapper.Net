using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixivAPIWrapper
{
    /// <summary>
    /// タグを表すクラスです。
    /// </summary>
    public class Tag
    {
        private readonly string BaseUrl = "http://dic.pixiv.net/a/";
        private readonly PixivAPI Api;
        private readonly string TagName;

        public Tag(PixivAPI api, string tag)
        {
            this.Api = api;
            this.TagName = tag;
        }

        public override string ToString()
        {
            return this.TagName;
        }

        /// <summary>
        /// このタグと同名の百科事典記事が存在するかどうか確かめます
        /// </summary>
        /// <remarks>
        /// 未実装
        /// </remarks>
        /// <returns>記事が存在すればtrue</returns>
        public bool ExistDictionaryPage()
        {
            return true;
        }

        /// <summary>
        /// このタグの百科事典のURLを返します
        /// </summary>
        /// <returns>タグの百科事典のURL</returns>
        public Uri GetDictionaryURL()
        {
            return new Uri(String.Format("{0}{1}", BaseUrl, this.TagName));
        }
    }
}
