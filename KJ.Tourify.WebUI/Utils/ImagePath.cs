namespace KJ.Tourify.WebUI.Utils
{
    public static class ImagePath
    {
        public const string Placeholder = "~/assets/img/placeholder.svg";
        public const string AvatarPlaceholder = "~/assets/img/avatar-placeholder.svg";

        public static string Resolve(string? path, string fallback = Placeholder)
        {
            if (string.IsNullOrWhiteSpace(path))
                return fallback;

            return path.StartsWith('~') || path.StartsWith('/') ? path : "~/" + path;
        }
    }
}
