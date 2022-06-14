using System.Collections.Generic;

namespace kolokwium.Models.DTOs
{
    public class MusicianGet
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }

        public List<TrackGet> MusicianTracks { get; set; }
    }
    public class TrackGet
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int? IdMusicAlbum { get; set; }
    }
}
