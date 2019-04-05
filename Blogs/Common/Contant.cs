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

        public class Configuration
        {
            public const int POST_PER_PAGE = 10;
            public const int FIRST_NUMBER = 1;
            public const string UPLOAD_PATH = "~/Upload/";
        }       

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
            public const string LABEL_CREATE_NEW_TOPIC = "Create new topic";
            public const string LABEL_BLOCK_MANAGEMENT = "Block management";
            public const string LABEL_CATEGORY_LIST = "Categories list";
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
            public const string SHORT_DESCRIPTION = "Short description";
            public const string MAIN_CONTENT = "Content";
            public const string IMG = "Image";
            public const string CATEGORY_ID = "Category id";
            public const string CATEGORY_NAME = "Category";
            public const string CREATED_DATE = "Created date";
            public const string UPDATED_DATE = "Updated date";
            public const string FRIENDLY_URL = "Friendly URL";
            public const string LAST_POSTS = "Older posts";
        }

        public class CategoryLabel
        {
            public const string LABEL_CAT_NAME = "Category name";
        }
    }
}
