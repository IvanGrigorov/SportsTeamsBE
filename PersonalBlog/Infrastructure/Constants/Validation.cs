namespace PersonalBlog.Infrastructure.Constants
{
    public class Validation
    {
        public class Project
        {
            public const int DescriptionValidationLength = 20000;

            public const int TitleValidationLength = 2000;
        }

        public class Article
        {
            public const int BodyValidationLength = 20000;

            public const int TitleValidationLength = 2000;
        }

        public class Technology
        {
            public const int DescriptionValidationLength = 2000;

            public const int TitleValidationLength = 2000;
        }

        public class Image
        {
            public static readonly string[] ImageExtensions = { ".jpeg", ".png", ".gif", ".jpg" };

            public const int ImageMaxSize = 20000000;
        }
    }
}
