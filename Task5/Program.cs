namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            Programmer programmer = new Programmer();
            Director director = new Director();

            CheckAccess(manager);
            CheckAccess(programmer);
            CheckAccess(director);
        }
        static void CheckAccess(object employee)
        {
            var accessLevelAttribute = employee.GetType().GetCustomAttributes(typeof(AccessLevelAttribute), true)[0] as AccessLevelAttribute;
            int accessLevel = accessLevelAttribute.Level;

            if (accessLevel <= 2) 
            {
                var accessMethod = employee.GetType().GetMethod("AccessRestrictedSection");
                accessMethod.Invoke(employee, null);
            }
            else
            {
                Console.WriteLine("Access attempt denied. Your access level does not permit this.");
            }
        }
    }
}