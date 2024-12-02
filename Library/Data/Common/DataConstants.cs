namespace Library.Data.Common
{
    public static class DataConstants
    {
        // Book constants:
        public const int TitleMinLength = 10;
        public const int TitleMaxLength = 50;

        public const int AuthorMinLength = 5;
        public const int AuthorMaxLength = 50;

        public const int DescriptionMinLength = 5;
        public const int DescriptionMaxLength = 5000;

        public const int ImageUrlMaxLength = 255;

        public const string RatingMinValue = "0.0";
        public const string RatingMaxValue = "10.0";

        // Category constants:
        public const int CategoryNameMinLength = 5;
        public const int CategoryNameMaxLength = 50;

        public const string CategoryInvalid = "This category does not exist.";

        // Names of actions and controllers:
        public const string AllAction = "All";
        public const string BookContr = "Book";
    }
}
