﻿using System;
using System.Collections.Generic;

namespace NeteaseMuisc
{
    public class MVResult
    {
        public string LoadingPic { get; set; }
        public string BufferPic { get; set; }
        public string LoadingPicFs { get; set; }
        public string BufferPicFs { get; set; }
        public bool Subed { get; set; }
        public Data Data { get; set; }
        public long Code { get; set; }
    }

    public class Data
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string BriefDesc { get; set; }
        public string Desc { get; set; }
        public string Cover { get; set; }
        public long CoverId { get; set; }
        public long PlayCount { get; set; }
        public long SubCount { get; set; }
        public long ShareCount { get; set; }
        public long LikeCount { get; set; }
        public long CommentCount { get; set; }
        public long Duration { get; set; }
        public long NType { get; set; }
        public DateTime PublishTime { get; set; }
        public Brs Brs { get; set; }
        public Artist[] Artists { get; set; }
        public bool IsReward { get; set; }
        public string CommentThreadId { get; set; }
    }

    public class MVArtist
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class Brs
    {
        public string The480 { get; set; }
        public string The240 { get; set; }
        public string The720 { get; set; }
    }

    public class LyricResult
    {
        public bool Sgc { get; set; }
        public bool Sfy { get; set; }
        public bool Qfy { get; set; }
        public LyricUser TransUser { get; set; }
        public LyricUser LyricUser { get; set; }
        public Lrc Lrc { get; set; }
        public Klyric Klyric { get; set; }
        public Lrc Tlyric { get; set; }
        public long Code { get; set; }
    }

    public class Klyric
    {
        public long Version { get; set; }
    }

    public class Lrc
    {
        public long Version { get; set; }
        public string Lyric { get; set; }
    }

    public class LyricUser
    {
        public long Id { get; set; }
        public long Status { get; set; }
        public long Demand { get; set; }
        public long Userid { get; set; }
        public string Nickname { get; set; }
        public long Uptime { get; set; }
    }


    public class SongUrls
    {
        public Datum[] Data { get; set; }
        public long Code { get; set; }
    }

    public class PlayListResult
    {
        public Playlist Playlist { get; set; }
        public long Code { get; set; }
        public Privilege[] Privileges { get; set; }
    }

    public class Playlist
    {
        public object[] Subscribers { get; set; }
        public bool Subscribed { get; set; }
        public User Creator { get; set; }
        public Track[] Tracks { get; set; }
        public TrackId[] TrackIds { get; set; }
        public long CoverImgId { get; set; }
        public long CreateTime { get; set; }
        public long UpdateTime { get; set; }
        public bool NewImported { get; set; }
        public long Privacy { get; set; }
        public long SpecialType { get; set; }
        public string CommentThreadId { get; set; }
        public long TrackUpdateTime { get; set; }
        public long TrackCount { get; set; }
        public bool HighQuality { get; set; }
        public long SubscribedCount { get; set; }
        public long CloudTrackCount { get; set; }
        public string CoverImgUrl { get; set; }
        public long PlayCount { get; set; }
        public long AdType { get; set; }
        public long TrackNumberUpdateTime { get; set; }
        public object Description { get; set; }
        public bool Ordered { get; set; }
        public object[] Tags { get; set; }
        public long Status { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
        public long ShareCount { get; set; }
        public string CoverImgIdStr { get; set; }
        public long CommentCount { get; set; }
    }

    public class User
    {
        public bool DefaultAvatar { get; set; }
        public long Province { get; set; }
        public long AuthStatus { get; set; }
        public bool Followed { get; set; }
        public string AvatarUrl { get; set; }
        public long AccountStatus { get; set; }
        public long Gender { get; set; }
        public long City { get; set; }
        public long Birthday { get; set; }
        public long UserId { get; set; }
        public long UserType { get; set; }
        public string Nickname { get; set; }
        public string Signature { get; set; }
        public string Description { get; set; }
        public string DetailDescription { get; set; }
        public long AvatarImgId { get; set; }
        public long BackgroundImgId { get; set; }
        public string BackgroundUrl { get; set; }
        public long Authority { get; set; }
        public bool Mutual { get; set; }
        public object ExpertTags { get; set; }
        public object Experts { get; set; }
        public long DjStatus { get; set; }
        public long VipType { get; set; }
        public object RemarkName { get; set; }
        public string BackgroundImgIdStr { get; set; }
        public string AvatarImgIdStr { get; set; }
    }

    public class Track
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public long Pst { get; set; }
        public long T { get; set; }
        public Ar[] Ar { get; set; }
        public string[] Alia { get; set; }
        public double Pop { get; set; }
        public long St { get; set; }
        public string Rt { get; set; }
        public long Fee { get; set; }
        public long V { get; set; }
        public string Crbt { get; set; }
        public string Cf { get; set; }
        public Al Al { get; set; }
        public long Dt { get; set; }
        public H H { get; set; }
        public H M { get; set; }
        public H L { get; set; }
        public object A { get; set; }
        public string Cd { get; set; }
        public long No { get; set; }
        public object RtUrl { get; set; }
        public long Ftype { get; set; }
        public object[] RtUrls { get; set; }
        public long DjId { get; set; }
        public long Copyright { get; set; }
        public long SId { get; set; }
        public long Mst { get; set; }
        public long Cp { get; set; }
        public long Mv { get; set; }
        public long Rtype { get; set; }
        public object Rurl { get; set; }
        public long PublishTime { get; set; }
        public string[] Tns { get; set; }
    }

    public class TrackId
    {
        public long Id { get; set; }
        public long V { get; set; }
    }

    public class Datum
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public long Br { get; set; }
        public long Size { get; set; }
        public string Md5 { get; set; }
        public long Code { get; set; }
        public long Expi { get; set; }
        public string Type { get; set; }
        public double Gain { get; set; }
        public long Fee { get; set; }
        public object Uf { get; set; }
        public long Payed { get; set; }
        public long Flag { get; set; }
        public bool CanExtend { get; set; }
    }

    public class SearchResult
    {
        public SResult Result { get; set; }
        public long Code { get; set; }
    }

    public class ArtistResult
    {
        public long Code { get; set; }
        public Artist Artist { get; set; }
        public bool More { get; set; }
        public List<HotSong> HotSongs { get; set; }
    }

    public class DetailResult
    {
        public Song[] Songs { get; set; }
        public Privilege[] Privileges { get; set; }
        public long Code { get; set; }
    }

    public class Artist
    {
        public long Img1V1Id { get; set; }
        public long TopicPerson { get; set; }
        public long PicId { get; set; }
        public object BriefDesc { get; set; }
        public long AlbumSize { get; set; }
        public string Img1V1Url { get; set; }
        public string PicUrl { get; set; }
        public List<string> Alias { get; set; }
        public string Trans { get; set; }
        public long MusicSize { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
        public long PublishTime { get; set; }
        public long MvSize { get; set; }
        public bool Followed { get; set; }
    }

    public class AlbumResult
    {
        public Song[] Songs { get; set; }
        public long Code { get; set; }
        public Album Album { get; set; }
    }

    public class Album
    {
        public object[] Songs { get; set; }
        public bool Paid { get; set; }
        public bool OnSale { get; set; }
        public long PicId { get; set; }
        public object[] Alias { get; set; }
        public string CommentThreadId { get; set; }
        public long PublishTime { get; set; }
        public string Company { get; set; }
        public long CopyrightId { get; set; }
        public string PicUrl { get; set; }
        public Artist Artist { get; set; }
        public object BriefDesc { get; set; }
        public string Tags { get; set; }
        public Artist[] Artists { get; set; }
        public long Status { get; set; }
        public object Description { get; set; }
        public object SubType { get; set; }
        public string BlurPicUrl { get; set; }
        public long CompanyId { get; set; }
        public long Pic { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        public string PicIdStr { get; set; }
        public Info Info { get; set; }
    }

    public class Info
    {
        public CommentThread CommentThread { get; set; }
        public object LatestLikedUsers { get; set; }
        public bool Liked { get; set; }
        public object Comments { get; set; }
        public long ResourceType { get; set; }
        public long ResourceId { get; set; }
        public long CommentCount { get; set; }
        public long LikedCount { get; set; }
        public long ShareCount { get; set; }
        public string ThreadId { get; set; }
    }

    public class CommentThread
    {
        public string Id { get; set; }
        public ResourceInfo ResourceInfo { get; set; }
        public long ResourceType { get; set; }
        public long CommentCount { get; set; }
        public long LikedCount { get; set; }
        public long ShareCount { get; set; }
        public long HotCount { get; set; }
        public object LatestLikedUsers { get; set; }
        public long ResourceId { get; set; }
        public long ResourceOwnerId { get; set; }
        public string ResourceTitle { get; set; }
    }

    public class ResourceInfo
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public object ImgUrl { get; set; }
        public object Creator { get; set; }
    }


    public class HotSong
    {
        public List<object> RtUrls { get; set; }
        public List<Ar> Ar { get; set; }
        public Al Al { get; set; }
        public long St { get; set; }
        public long Fee { get; set; }
        public long Ftype { get; set; }
        public long Rtype { get; set; }
        public object Rurl { get; set; }
        public long T { get; set; }
        public string Cd { get; set; }
        public long No { get; set; }
        public long V { get; set; }
        public object A { get; set; }
        public H M { get; set; }
        public long DjId { get; set; }
        public object Crbt { get; set; }
        public object RtUrl { get; set; }
        public List<object> Alia { get; set; }
        public long Pop { get; set; }
        public string Rt { get; set; }
        public long Mst { get; set; }
        public long Cp { get; set; }
        public string Cf { get; set; }
        public long Dt { get; set; }
        public long Pst { get; set; }
        public H H { get; set; }
        public H L { get; set; }
        public long Mv { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
        public Privilege Privilege { get; set; }
    }

    public class SResult
    {
        public List<Song> Songs { get; set; }
        public long SongCount { get; set; }
    }

    public class Song
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public long Pst { get; set; }
        public long T { get; set; }
        public List<Ar> Ar { get; set; }
        public List<object> Alia { get; set; }
        public long Pop { get; set; }
        public long St { get; set; }
        public string Rt { get; set; }
        public long Fee { get; set; }
        public long V { get; set; }
        public object Crbt { get; set; }
        public string Cf { get; set; }
        public Al Al { get; set; }
        public long Dt { get; set; }
        public H H { get; set; }
        public H M { get; set; }
        public H L { get; set; }
        public object A { get; set; }
        public string Cd { get; set; }
        public long No { get; set; }
        public object RtUrl { get; set; }
        public long Ftype { get; set; }
        public List<object> RtUrls { get; set; }
        public object Rurl { get; set; }
        public long Rtype { get; set; }
        public long Mst { get; set; }
        public long Cp { get; set; }
        public long Mv { get; set; }
        public long PublishTime { get; set; }
        public Privilege Privilege { get; set; }
    }

    public class Al
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public List<object> Tns { get; set; }
        public long Pic { get; set; }
    }

    public class Ar
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<object> Tns { get; set; }
        public List<object> Alias { get; set; }
    }

    public class H
    {
        public long Br { get; set; }
        public long Fid { get; set; }
        public long Size { get; set; }
        public double Vd { get; set; }
    }

    public class Privilege
    {
        public long Id { get; set; }
        public long Fee { get; set; }
        public long Payed { get; set; }
        public long St { get; set; }
        public long Pl { get; set; }
        public long Dl { get; set; }
        public long Sp { get; set; }
        public long Cp { get; set; }
        public long Subp { get; set; }
        public bool Cs { get; set; }
        public long Maxbr { get; set; }
        public long Fl { get; set; }
        public bool Toast { get; set; }
        public long Flag { get; set; }
    }
}