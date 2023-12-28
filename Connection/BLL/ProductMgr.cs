namespace BLL.connect;
using BOL;
using DAL.connect;


public class ProductMgr{

      public List<Product> getAllProduct()
      {
            List<Product> allPro = new List<Product>();
            allPro = DBManager.getAllDetails();
            return allPro;
      }
}