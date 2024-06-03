namespace NotionConnection.Objects
{
    public class NotionCommentRequest
    {
        public Parent Parent { get; set; }
        public List<RichText> RichText { get; set; }
    }

    public class Parent
    {
        public string PageId { get; set; }
    }

    public class RichText
    {
        public Text Text { get; set; }
    }

    public class Text
    {
        public string Content { get; set; }
    }
}