namespace WinDisconArchDemo
{
    /// <summary>
    /// Entity class representing a product in the system. 
    /// This class can be expanded with properties such as Id, Name, Price, etc., to represent the attributes of a product.
    /// </summary>
    public class Product
    {
        #region Fields
        int prodId;
        string prodName;
        float price;
        string desc;
        #endregion

        #region Properties
        //CLR Properties for encapsulation of fields
        public int ProdId { 
            get => prodId; 
            set
            {
                if(value<=0 || value >= 999) { 
                    throw new MyCustomException("Product ID must be between 1 and 998.");
                }
                else
                {
                    prodId = value;
                }
            } 
        }

        public string ProdName { 
            get => prodName; 
            set => prodName = value;
        }

        public float Price { 
            get => price; 
            set
            {
                if(value < 0) { 
                    throw new MyCustomException("Price cannot be negative.");
                }
                else
                {
                    price = value;
                }
            }
        }

        public string Category { get; set; }
        public string Desc { 
            get => desc; 
            set => desc = value;
        }
        #endregion
    }
}