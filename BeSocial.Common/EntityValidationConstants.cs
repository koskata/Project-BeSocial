﻿namespace BeSocial.Common
{
    public static class EntityValidationConstants
    {
        public static class Comment
        {
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 200;
        }

        public static class ApplicationUser
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 25;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 25;
        }

        public static class PremiumUser
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 25;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 25;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 150;
        }

        public static class Group
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 15;
        }

        public static class Post
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;

            public const string DateFormat = "dd/MM/yyyy HH:mm";
        }
    }
}
