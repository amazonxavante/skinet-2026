namespace Core.Specifications
{
    public class ProductSpecParams :PagingParams
    {
        private List<string> _brands = [];
        public List<string> Brands
        {
            get => _brands;
            set
            {
                _brands = value.SelectMany(x => x.Split(',', 
                  StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
        }



        private List<string> _stypes = [];
        public List<string> Types
        {
            get => _stypes;
            set
            {
                _stypes = value.SelectMany(x => x.Split(',', 
                  StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
        }

        public string? Sort { get; set; }

        private string? _search;
        public string Search
        {
            get { return _search ?? ""; }
            set { _search = value.ToLower(); }
        }
        
        
    }
}