using System;
using System.Reflection;

public class maxLen 
{
    // custom attribute for max string length
    [AttributeUsage(AttributeTargets.Field)]
    public class MaxLengthAttribute : Attribute
    {
        public int MaxChars { get; set; }

        public MaxLengthAttribute(int max)
        {
            MaxChars = max;
        }
    }

    public class User
    {
        [MaxLength(12)]
        public string username;

        public User(string user)
        {
            username = user;

            // validate using reflection
            validateFields();
        }

        private void validateFields()
        {
            Type t = this.GetType();
            FieldInfo[] fields = t.GetFields();

            foreach(FieldInfo field in fields)
            {
                object[] attrs = field.GetCustomAttributes(typeof(MaxLengthAttribute), false);

                foreach(object attr in attrs)
                {
                    MaxLengthAttribute maxAttr = (MaxLengthAttribute)attr;

                    string value = (string)field.GetValue(this);

                    if(value != null && value.Length > maxAttr.MaxChars)
                    {
                        throw new ArgumentException("Field " + field.Name + " too long! Max " + maxAttr.MaxChars);
                    }
                }
            }
        }
    }

    public static void Main(string[] args) 
    {
        /*
        4️⃣ Create a MaxLength Attribute for Field Validation
        Problem Statement: Define a field-level attribute MaxLength(int value) that restricts the maximum length of a string field.
        Requirements:
        * Apply it to a User class field (Username).
        * Validate length in the constructor.
        * Throw ArgumentException if the limit is exceeded.
        */

        Console.WriteLine("MaxLength Attribute Validation\n");

        try
        {
            Console.Write("Waiting , for user to enter username (max 12 chars) : ");
            string name = Console.ReadLine();

            User u = new User(name);
            Console.WriteLine("User created successfully");
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine("Validation failed: " + ex.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine("other error : " + e.Message);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
