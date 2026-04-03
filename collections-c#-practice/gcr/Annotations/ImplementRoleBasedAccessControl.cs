using System;
using System.Reflection;

public class roleCtrl 
{
    // custom attribute for role check
    [AttributeUsage(AttributeTargets.Method)]
    public class RoleAllowedAttribute : Attribute
    {
        public string RequiredRole { get; set; }

        public RoleAllowedAttribute(string role)
        {
            RequiredRole = role;
        }
    }

    public class SecureAdmin
    {
        [RoleAllowed("ADMIN")]
        public void DeleteUser()
        {
            Console.WriteLine("User deleted successfully");
        }
    }

    public static void callWithRoleCheck(string currentUserRole)
    {
        SecureAdmin admin = new SecureAdmin();

        MethodInfo method = typeof(SecureAdmin).GetMethod("DeleteUser");

        object[] attrs = method.GetCustomAttributes(typeof(RoleAllowedAttribute), false);

        if(attrs.Length > 0)
        {
            RoleAllowedAttribute roleAttr = (RoleAllowedAttribute)attrs[0];

            if(currentUserRole != roleAttr.RequiredRole)
            {
                Console.WriteLine("Access Denied! Required role: " + roleAttr.RequiredRole);
                return;
            }
        }

        method.Invoke(admin, null);
    }

    public static void Main(string[] args) 
    {
        /*
        5️⃣ Implement Role-Based Access Control with RoleAllowed
        Problem Statement: Define a class-level attribute RoleAllowed to restrict method access based on roles.
        Requirements:
        * [RoleAllowed("ADMIN")] should only allow ADMIN users to execute the method.
        * Simulate user roles and validate access before invoking the method.
        * If a non-admin tries to access it, print Access Denied!
        */

        Console.WriteLine("Role-Based Access Control with Attribute\n");

        Console.Write("Waiting , for user to enter your role (ADMIN or USER) : ");
        string role = Console.ReadLine().ToUpper();

        Console.WriteLine("\nTrying to delete user...");
        callWithRoleCheck(role);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
