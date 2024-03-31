using Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Domain
{
    public class Book : AbstractEntity
    {
        public string? Publisher { get; set; }
        public required string Title { get; set; }
        public required string ContainerTitle { get; set; }  
        public required string AuthorLastName { get; set; }
        public required string AuthorFirstName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public long? VolumeNumber { get; set; }

        public long PublicationYear { get; set; }
        public string? PublicationMonth { get; set; }

        public long PageStartNumber { get; set; }
        public long PageEndNumber { get; set; }
        public string? URL { get; set; }

        public string CitationDetails
        {
            get
            {
                return $"{AuthorLastName}, {AuthorFirstName}. \"{Title}\" <i>{ContainerTitle},</i> {Publisher}, {PublicationYear}, pp. {PageStartNumber}-{PageEndNumber}.";
            }
        }

        public string ChicagoCitationDetails
        {
            
            get
            {
                var volumeNumber = "";
                if(VolumeNumber != null && VolumeNumber != 0)
                {
                    volumeNumber = $"no. {VolumeNumber}";
                }
         
                return $"{AuthorLastName}, {AuthorFirstName}. {PublicationYear}. \"{Title}\" <i>{ContainerTitle},</i> {volumeNumber} ({PublicationMonth} {PublicationYear}): {PageStartNumber}-{PageEndNumber}. {URL}.";
            }
        }
    }
}
