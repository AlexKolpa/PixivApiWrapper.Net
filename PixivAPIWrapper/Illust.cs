using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixivAPIWrapper
{
    /// <summary>
    /// 「イラスト」を表すクラスです。
    /// </summary>
    public class Illust : Image
    {
        public Illust(string[] data)
            : base(data)
        {
            string rawMobileURL = this.MobileURL.ToString();
            this.ImageURL = new Uri(String.Format("{0}{1}.{2}", rawMobileURL.Substring(0, rawMobileURL.LastIndexOf("mobile")), this.Id, this.Ext));
        }
    }
}
