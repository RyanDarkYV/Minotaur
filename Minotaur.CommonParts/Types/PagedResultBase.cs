namespace Minotaur.CommonParts.Types
{
    public abstract class PagedResultBase
    {
        protected PagedResultBase()
        {

        }

        protected PagedResultBase(int currentPage, int resultsPerPage, int totalPages, long totalResults)
        {
            CurrentPage = currentPage;
            ResultsPerPage = resultsPerPage;
            TotalResults = totalResults;
            TotalPages = totalPages;
        }

        public int CurrentPage { get; }
        public int ResultsPerPage { get; }
        public int TotalPages { get; }
        public long TotalResults { get; }
    }
}