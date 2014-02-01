﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixivAPIWrapper
{
    /// <summary>
    /// Pixivでの、「イラスト」「マンガ」「小説」などの作品アイテムすべての基底になるクラスです。
    /// </summary>
    public class Item
    {
        protected readonly PixivAPI Api;
        public int Id { get; protected set; }
        public int AuthorId { get; protected set; }
        public string Title { get; protected set; }
        public string AuthorName { get; protected set; }
        public string Date { get; protected set; }
        public Tag[] Tags { get; protected set; }
        public int Feedback { get; protected set; }
        public int Point { get; protected set; }
        public int Views { get; protected set; }
        public string Caption { get; protected set; }
        public Uri Url { get; protected set; }

        public Item(PixivAPI api, string[] data) 
        {
            this.Api = api;
            this.Id = int.Parse(data[0]);
            if (this.Id == 0)
            {
                throw new AccessAuthorizationException("参照権限がありません。マイピク限定公開のアイテムか、非公開のアイテムか、あるいは削除されたアイテムである可能性があります。");
            }
            this.AuthorId = int.Parse(data[1]);
            this.Title = data[3];
            this.AuthorName = data[5];
            this.Date = data[12];

            string tags_org = data[13];
            List<Tag> tags = new List<Tag>();
            string[] tags_tmp = tags_org.Split(',');
            foreach (string tag_s in tags_tmp)
            {
                Tag tag = new Tag(this.Api, tag_s);
                tags.Add(tag);
            }
            this.Tags = tags.ToArray();
            this.Feedback = (!data[15].Equals("")) ? int.Parse(data[15]) : 0;
            this.Point = (!data[16].Equals("")) ? int.Parse(data[16]) : 0;
            this.Views = (!data[17].Equals("")) ? int.Parse(data[17]) : 0;
            this.Caption = data[18];
            this.Url = null;
        }
    }
}