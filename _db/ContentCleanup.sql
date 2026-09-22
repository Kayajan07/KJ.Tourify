USE TourifyDb;
GO

SET XACT_ABORT ON;
BEGIN TRANSACTION;

UPDATE HomePages SET
    Title1         = N'Where Do You Want To Go?',
    Title2         = N'Let''s Explore The World Together!',
    Title3         = N'Find Your Perfect Tour With Tourify',
    Description    = N'Hand-picked city breaks, cultural journeys and scenic escapes across Europe and Türkiye, led by local guides who know every hidden corner.',
    HomeButtonText = N'Explore Tours';

UPDATE HomePages SET
    HomeAboutTitle       = N'Welcome to Tourify',
    HomeAboutDescription = N'Tourify brings together carefully planned tours, trusted local guides and honest pricing so you can focus on the journey itself. From balloon flights over Cappadocia to evening walks through Paris and Rome, every route is tested by our team and shaped by feedback from real travelers.';

UPDATE BookPages SET
    BookDescription     = N'Pick a tour, tell us your dates and group size, and our team will confirm availability within one business day. Every booking includes a dedicated contact person, clear pricing with no hidden fees and free changes up to 14 days before departure.',
    BookFormDescription = N'Start your first adventure with Tourify. Leave your details and we will get back to you with the best available offer.';

UPDATE Services SET
    Service1Description = N'Guided tours across Europe and Türkiye, with carefully timed itineraries, comfortable transport and small groups for a more personal experience.',
    Service2Description = N'Central, well-reviewed hotels selected for each route, booked together with your tour so you never have to compare dozens of listings.',
    Service3Description = N'Licensed local guides who share the history, food and stories of every destination in fluent English.',
    Service4Description = N'Private group trips, celebrations and corporate outings planned end to end, from the first idea to the last transfer.',
    Service1Icon = N'fa fa-globe fa-4x text-brand',
    Service2Icon = N'fa fa-hotel fa-4x text-brand',
    Service3Icon = N'fa fa-user fa-4x text-brand',
    Service4Icon = N'fa fa-cog fa-4x text-brand';

UPDATE ContactPages SET
    ContactLocationIcon = N'fa fa-map-marker-alt fa-3x text-brand',
    ContactPhoneIcon    = N'fa fa-phone-alt fa-3x text-brand mb-3',
    ContactEmailIcon    = N'fa fa-envelope-open fa-3x text-brand mb-3';

UPDATE TourPages SET
    TourTitle = N'Choose Your Next Adventure';

UPDATE GalleryPages SET
    GalleryTitle       = N'Moments From Our Journeys',
    GalleryDescription = N'Snapshots from recent Tourify trips: sunsets over the Bosphorus, castles in Bavaria and quiet mornings in Cappadocia.';

UPDATE GalleryItems SET Title = N'Cappadocia Valleys' WHERE Title = N'Turkeyyy';
UPDATE GalleryItems SET Title = N'The Romantic Eiffel Tower' WHERE Title = N'The Romantic Eyfel Tower';

COMMIT TRANSACTION;
GO

UPDATE HomePages SET HomeDestinationButtonText = N'Let''s Find Your Tour Destination'
WHERE HomeDestinationButtonText = N'Lets Find Your Tour Destination';

UPDATE AboutPages SET AboutGuideDescription = N'Our travel guides bring local insight, calm planning and better stories to every destination.'
WHERE AboutGuideDescription = N'Our travel guides bring local Insight, calm planning, and better stories to every destination';
GO
