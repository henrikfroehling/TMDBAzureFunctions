using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Database
{
    public class Snapshots
    {
        public int Id { get; set; }

        public string LanguageCode { get; set; }

        public string RegionCode { get; set; }

        public string CompressedBase64JSONData { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime TimeStamp { get; set; }
    }
}
