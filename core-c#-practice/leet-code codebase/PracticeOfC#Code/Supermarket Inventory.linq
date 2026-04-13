<Query Kind="Statements" />

class Program {

public abstract class  Product{
     
	 public string name {get;set;}
	 public double price {get;set;}
	 public int quantity {get;set;}
	 
	 public Product (string Name , double Price , int Quantity){
	    this.name = Name ;
		this.price = Price ;
		this.quantity = Quantity ;
	 }
	 public abstract void display() ; // to be implemented by the child classes
	 public double calculateValue(){
	      double value = price * (double)quantity ;
		  return value ;
	 }
	 
	 public string getName(){
	    return name ;
	 }
}

public class Electronics : Product {
      public int warranty {get;set;}
      public Electronics (string Name , double Price , int Quantity , int Warranty ) : base( Name , Price , Quantity) {
	     
		 this.warranty = Warranty ;
	  
	  }
	  public override void display(){
	      Console.WriteLine($"{name},{price},{quantity},{warranty}");
	  }
}

public class Clothing : Product {
     public string size {get;set;}
	 
	 public Clothing (string name ,double price , int quantity , string size) : base (name , price , quantity ) {
	       this.size =  size ;
	 }
	 
	 public override void display(){
	   Console.WriteLine($"{name},{price},{quantity},{size}");
	 }
}

public class InventoryManager{
    List<Product> p = new List<Product>();
	
	public void addProduct(Product product) {
	   p.Add(product) ;
	   Console.WriteLine($"Product added to the inventory.{product.getName()}" ) ; // Confirmation message
	}
	
	public void displayInventory(){
	    Console.WriteLine("Inventory:");
		foreach (var e in p ) {
		    e.display();
		}
	}
	
	public void calculateTotalValue(){
	     double total = default ;
		 foreach (var e in p ) {
		   total += e.calculateValue();
		 }
	     Console.WriteLine($"Total inventory value : {total:F2}");
	}
}

public static void Main(){
       
	   int n = Convert.ToInt32(Console.ReadLine());
	   InventoryManager im = new InventoryManager() ;
	   
	   for ( int i = 0 ; i < n ; i ++ ) {
	      string input = Console.ReadLine();
		  
		  string[] parts = input.Split(',');
		  
		  // Trim space manually
		  for ( int j = 0 ; j < parts.Length ; j++){
		    parts[j] = parts[j].Trim();
		  }
		  
		  string type = parts[0];
		  
		  if ( type == "Electronics") {
		    string name = parts[1];
			double price = Convert.ToDouble(parts[2]);
			int quantity = Convert.ToInt32(parts[3]);
			int warranty = Convert.ToInt32(parts[4]);
			
			Electronics e = new Electronics (name , price , quantity , warranty ) ;
			im.addProduct(e);
		  } else if ( type == "Clothing"){
		     string name = parts [1];
			 double price = Convert.ToDouble(parts[2]);
			 int quantity = Convert.ToInt32(parts[3]);
			 string size = parts[4];
			 
			 Clothing c = new Clothing (name , price , quantity , size);
			 im.addProduct(c);
		  }
	     
	   }
	   
	   im.displayInventory();
	   im.calculateTotalValue ();
	   
    
	
	
  }

}