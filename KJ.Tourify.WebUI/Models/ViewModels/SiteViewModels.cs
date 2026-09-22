using KJ.Tourify.WebUI.Models.Entities;

namespace KJ.Tourify.WebUI.Models.ViewModels
{
    public record PageHeaderViewModel(string? Title, string? ParentTitle = null, string? ParentAction = null);

    public record GalleryCardViewModel(GalleryItem Item, string LightboxGroup);

    public record StatsViewModel(int DestinationCount, int TourCount, int TravelerCount);

    public class TourSearchViewModel
    {
        public IReadOnlyList<TourCity> Cities { get; init; } = [];
        public Guid? CityId { get; init; }
        public DateOnly? Date { get; init; }
        public int? Guests { get; init; }

        public bool Inline { get; init; }

        public bool HasFilter => CityId.HasValue || Guests.HasValue || Date.HasValue;
    }
}
