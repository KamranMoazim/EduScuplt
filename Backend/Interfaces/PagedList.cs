
using Backend.Models.HelpingModels;

namespace Backend.Interfaces
{
    public class PagedList<T> where T : Identity
    {
        public IEnumerable<T> Source { get; set; }
        public int? NumberOfRows { get; set; }
        public int? NumberOfPages { get; set; }

        public PagedList(IEnumerable<T> source, int numOfRows, int pageSize)
        {
            Source = source;
            NumberOfRows = numOfRows;
            NumberOfPages = numOfRows / pageSize <= 0 ? 1 : pageSize;
        }
    }
}