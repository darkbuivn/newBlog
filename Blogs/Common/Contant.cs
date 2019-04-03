using System;

namespace Common
{
    public static class Contant
    {
        public enum BlockPosition
        {
            Left = 0,
            Right = 1,
            Top = 2,
            Bottom = 3
        };

        public class GeneralOperation
        {
            public const string CREATE = "Create";
            public const string EDIT = "Edit";
            public const string DELETE = "Delete";
            public const string VIEW = "View";
            public const string BROWSE = "Browse";
            public const string SELECT = "Select";
        }

        public class TextDisplay
        {
            public const string COPYRIGHT = "Copyright &copy; 2019 - MrHie Solution";
            public const string LABEL_MANAGEMENT = "MANAGEMENT";
            public const string LABEL_NAVIGATION = "NAVIGATION";
            public const string LABEL_CATEGORY_MANAGEMENT = "CATEGORY MANAGEMENT";
            public const string LABEL_SEARCH = "SEARCH";
        }

        public class PageTitle
        {
            public const string HOME_PAGE = "Home";
            public const string MANAGEMENT = "Management";
            public const string ABOUT = "About Me";
            public const string CONTACT = "Contact";
        }

        public class PostLabel
        {
            public const string TITLE = "Title";
            public const string ID = "Id";
            public const string SHORT_DESCRIPTION = "Short Description";
            public const string MAIN_CONTENT = "Content";
            public const string IMG = "Image";
            public const string CATEGORY_ID = "Category Id";
            public const string CATEGORY_NAME = "Category";
            public const string CREATED_DATE = "Created Date";
            public const string UPDATED_DATE = "Updated Date";
            public const string FRIENDLY_URL = "Friendly URL";
            public const string LAST_POSTS = "Older Posts";
        }
    }
}
