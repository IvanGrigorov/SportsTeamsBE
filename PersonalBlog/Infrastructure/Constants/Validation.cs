namespace PersonalBlog.Infrastructure.Constants
{
    public class Validation
    {
        public class Project
        {
            public const int DescriptionValidationLength = 200000;

            public const int TitleValidationLength = 2000;
        }

        public class Article
        {
            public const int BodyValidationLength = 200000;

            public const int TitleValidationLength = 2000;

            public const int TagsValidationLength = 2000;
        }

        public class Technology
        {
            public const int DescriptionValidationLength = 20000;

            public const int TitleValidationLength = 2000;
        }

        public class Image
        {
            public static readonly string[] ImageExtensions = { ".jpeg", ".png", ".gif", ".jpg" };

            public const int ImageMaxSize = 20000000;
        }
        
        public class Request
        {
            public const int RequestBodySize = 20000000;
        }
    }
}
