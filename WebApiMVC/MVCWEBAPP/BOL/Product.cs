namespace BOL;
public class Product
{
  public Product()
  {

  }
  public Product(int i, string n, int qty, float pri)
  {
    this.Id = i;
    this.Name = n;
    this.Quantity = qty;
    this.Price = pri;
  }
  public int Id { get; set; }
  public string Name { get; set; }
  public int Quantity { get; set; }
  public float Price { get; set; }
}