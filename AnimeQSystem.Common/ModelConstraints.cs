namespace AnimeQSystem.Common
{
    public static class ModelConstraints
    {
        public static class Anime
        {
            public const int TitleMinLength = 1;
            public const int TitleMaxLength = 200;

            public const int EpisodesMin = 0;
            public const int EpisodesMax = 10_000;

            public const int SeasonsMin = 0;
            public const int SeasonsMax = 100;
        }

        public static class Person
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 50;

            public const int AgeMin = 0;
            public const int AgeMax = 100_000;

            public const int HeightMin = 1;
        }

        public static class AppUser
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 50;

            public const int CountryMinLength = 1;
            public const int CountryMaxLength = 50;

            public const int AgeMin = 0;
            public const int AgeMax = 120;
        }

        public static class Character
        {
            public const int SkillMinLength = 1;
            public const int SkillMaxLength = 100;

            public const int WeaponMinLength = 1;
            public const int WeaponMaxLength = 100;

            public const int WeaknessMinLength = 1;
            public const int WeaknessMaxLength = 100;
        }

        public static class Quiz
        {
            public const int TitleMinLength = 1;
            public const int TitleMaxLength = 100;

            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = 200;
        }

        public static class QuizQuestion
        {
            public const int TitleMinLength = 1;
            public const int TitleMaxLength = 100;

            public const int AnswerMinLength = 1;
        }

        public static class QuizOption
        {
            public const int OptionTextMinLength = 1;
            public const int OptionTextMaxLength = 100;
        }

        public static class Genre
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 50;

            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = 200;
        }

        public static class Studio
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 50;
        }
    }
}