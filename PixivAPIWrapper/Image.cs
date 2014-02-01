using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixivAPIWrapper
{
    /// <summary>
    /// Abstract parent for the various Image types on Pixiv
    /// </summary>
    public abstract class Image : Item
    {
        public string Ext { get; protected set; }
        public string Server { get; protected set; }
        public Uri ThumbURL { get; protected set; }
        public Uri MobileURL { get; protected set; }
        public string Tool { get; protected set; }
        public Uri ImageURL { get; protected set; }

        public Image(string[] data) : base(data)
        {            
            this.Ext = data[2];
            this.Server = data[4];
            this.ThumbURL = new Uri(data[6]);
            this.MobileURL = new Uri(data[9]);
            this.Tool = data[14];
            this.Url = new Uri(String.Format("http://www.pixiv.net/member_illust.php?mode=medium&illust_id={0}", this.Id));            
        }
    }
}
