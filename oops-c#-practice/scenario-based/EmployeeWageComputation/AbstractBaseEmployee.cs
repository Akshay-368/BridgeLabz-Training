// abstract base class for employees
public abstract class emp : iemp
{
   private int id;       
   private string nm;    
   protected int hrs;    
   protected double rat = 20;   

   // encapsulation of the properties
   public int idi
   { 
      get { return id ;}
      set { id = value ;}
   }

   public string nme
   { 
      get { return nm ;}
      set { nm = value ;}
   }

   // abstract method for wage
   public abstract double calw();

   // overload for days , polymorphism later
   public virtual double calw(int dys)
   {
      double tot = 0;
      for(int i=0; i<dys; i++)
         tot += calw();
      return tot;
   }

   // override ToString for printng
   public override string ToString()
   {
      return "Employee ID : " + id + "\nName: " + nm + "\nHourly Rate: " + rat;
   }
}

