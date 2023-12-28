namespace BOL;

public class Product{
    public int ID{get;set;}
    public string TITLE{get;set;}
//     private string IMG_URL;

    public double PRICE{get;set;}

    public Product(int id,string title,double price){   
        this.ID = id;
        this.TITLE = title;
      //   this.IMG_URL = url;
        this.PRICE = price;

    }

   
//     public string IMG_URL{
//         get{return IMG_URL;}
//         set{this.IMG_URL = value;}
//     }
   
}