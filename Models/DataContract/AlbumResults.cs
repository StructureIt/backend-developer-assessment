using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SearchApiService.Models.DataContract
{
    [DataContract]
    public class AlbumResults
    {
        [DataMember]
        public ICollection<Release> Releases { get; set; }
    }

    [DataContract(Name = "release-group")]
    public class ReleaseGroup
    {
        [DataMember(Name = "artist-credit")]
        public ICollection<Artistcredit> Otherartists { get; set; }

        [DataMember(Name = "primary-type")]
        public string Primarytype { get; set; }
    }

    [DataContract]
    public class Release
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Date { get; set; }

        [DataMember(Name = "label-info")]
        public ICollection<LabelInfo> Labelinfo { get; set; }

        [DataMember]
        public ICollection<MediaItem> Media { get; set; }

        [DataMember(Name = "release-group")]
        public ReleaseGroup ReleaseGroup { get; set; }
    }

    [DataContract]
    public class LabelInfo
    {
        [DataMember(Name = "label")]
        public Label Releaselabel { get; set; }
    }

    [DataContract]
    public class MediaItem
    {
        [DataMember(Name = "track-count")]
        public int NumberOfTracks { get; set; }

        [DataMember]
        public ICollection<Track> Tracks { get; set; }
    }

    [DataContract]
    public class Track
    {
        [DataMember(Name = "artist-credit")]
        public ICollection<Artistcredit> Otherartists { get; set; }

        [DataMember]
        public RecordingTrack Recording { get; set; }
    }

    [DataContract]
    public class RecordingTrack
    {
        [DataMember(Name = "artist-credit")]
        public ICollection<Artistcredit> Otherartists { get; set; }
    }

    [DataContract]
    public class Artistcredit
    {
        [DataMember]
        public IdentityDomainModel Artist { get; set; }
    }

    [DataContract]
    public class Label
    {
        [DataMember]
        public string Name { get; set; }
    }
}