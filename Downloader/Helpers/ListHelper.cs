namespace Downloader.Functions
{
    public static class ListHelper
    {
        public static List<string> ToList(this string text, params string[] separators)
        {
            List<string> textlist = new List<string>();

            if (!string.IsNullOrEmpty(text))
            {
                textlist = text.Split(separators, StringSplitOptions.None).ToList();
            }

            return textlist;
        }

        public static T GetItem<T>(this IEnumerable<dynamic> list, int index, dynamic defaultItem)
        {
            T dynamicItem;
            List<dynamic> dynamicList;

            dynamicList = list?.ToList() ?? new List<dynamic>();
            dynamicItem = dynamicList.Count > index ? Convert.ChangeType(dynamicList[index], typeof(T)) : defaultItem;

            return dynamicItem;
        }
    }
}
