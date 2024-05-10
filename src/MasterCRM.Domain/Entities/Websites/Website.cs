using System.ComponentModel.DataAnnotations.Schema;
using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Websites;

public class Website : BaseEntity<Guid>
{
    public required string Title { get; init; }
    
    public required string OwnerId { get; init; }
    
    [ForeignKey("OwnerId")]
    public virtual Master Master { get; init; } = null!;

    public List<Style> GlobalStyles { get; init; } = null!;

    public List<ConstructorBlock> Components { get; init; } = null!;
    
    // TODO: order/product sections
    // public ConstructorBlock OrderSection { get; init; }
    //
    // public ConstructorBlock ProductCard { get; init; }

    public Website() { }

    public Website(string title, string ownerId)
    {
        Title = title;
        OwnerId = ownerId;
    }

    // TODO: when updating blocks, this string must be changed
    public string GetWebsite() => "website is not ready";
}

/*
<div class="product-item">
  <img src="https://html5book.ru/wp-content/uploads/2015/10/black-dress.jpg">
  <div class="product-list">
    <h3>Маленькое черное платье</h3>
      <span class="price">₽ 1999</span>
      <a href="" class="button">В корзину</a>
  </div>
</div>
*/

/*
* {
   box-sizing: border-box;
}
.product-item {
   width: 300px;
   text-align: center;
   margin: 0 auto;
   border-bottom: 2px solid #F5F5F5;
   background: white;
   font-family: "Open Sans";
   transition: .3s ease-in;
}
.product-item:hover {
   border-bottom: 2px solid #fc5a5a;
}
.product-item img {
   display: block;
   width: 100%;
}
.product-list {
   background: #fafafa;
   padding: 15px 0;
}
.product-list h3 {
   font-size: 18px;
   font-weight: 400;
   color: #444444;
   margin: 0 0 10px 0;
}
.price {
   font-size: 16px;
   color: #fc5a5a;
   display: block;
   margin-bottom: 12px;
}
.button {
   text-decoration: none;
   display: inline-block;
   padding: 0 12px;
   background: #cccccc;
   color: white;
   text-transform: uppercase;
   font-size: 12px;
   line-height: 28px;
   transition: .3s ease-in;
}
.product-item:hover .button {
   background: #fc5a5a;
}
*/