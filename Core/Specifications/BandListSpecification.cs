
using Core.Entities;

namespace Core.Specifications
{
    public class BandListSpecification : BaseSpecification<Product, string>
    {
        public BandListSpecification()
        {
            AddSelect(x => x.Brand);
            ApplyDistinct();
        }
    }
}