

namespace Products;

public class Product{
    private int ID;
    private string TITLE;
    private string IMG_URL;
    private string DESCIPTION;

    public Product(int id,string title,string url,string desc){   
        this.ID = id;
        this.TITLE = title;
        this.IMG_URL = url;
        this.DESCIPTION = desc;

    }

    public int ID{
        get{return ID;}
        set{this.ID = value;}
    }
    public string TITLE{
        get{return TITLE;}
        set{this.TITLE = value;}
    }
    public string IMG_URL{
        get{return IMG_URL;}
        set{this.IMG_URL = value;}
    }
    public string DESCIPTION{
        get{return DESCIPTION;}
        set{this.DESCIPTION = value;}
    }
}
