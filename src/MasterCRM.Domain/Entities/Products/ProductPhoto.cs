using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Products;

public class ProductPhoto : BaseEntity<Guid>
{
    public Guid ProductId { get; set; }
    
    public short Order { get; set; }
    
    public string Url { get; set; } = null!;
    
    public string? Extension { get; set; }

    public void Update(short? order, string? url)
    {
        if (order != null)
            Order = (short)order;
        if (url != null)
        {
            Url = url;
            Extension = Path.GetExtension(url);
        }
    }
}