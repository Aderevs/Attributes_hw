using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LoadAssembly
{
    class Program
    {
        private static List<Type> _selectedTypes = new List<Type>();
        private static List<MemberInfo> _selectedMembers = new List<MemberInfo>();
        private static Assembly _assembly = null;
        static void Main()
        {
            try
            {
                _assembly = Assembly.LoadFrom("..\\..\\..\\..\\Task2\\bin\\Debug\\net8.0\\Task2.dll");
                Console.WriteLine("Loaded assembly");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ListAllTypes(_assembly);

            SelectTypesAndMembers(_assembly);

            ListSelectedTypesAndMembers();

            ListAttributes(_assembly);
        }
        private static void ListAllTypes(Assembly assembly)
        {
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("\nListAllTypes in: {0} \n", assembly.FullName);

            Type[] types = assembly.GetTypes();

            foreach (Type t in types)
                Console.WriteLine("Type: {0}", t);
        }

        private static void SelectTypesAndMembers(Assembly assembly)
        {
            Console.WriteLine("Select types (separate by whitespace): ");
            string[] selectedTypeNames = Console.ReadLine().Split(' ');
            foreach (string name in selectedTypeNames)
            {
                string typeName = "Task2." + name;
                Type type = assembly.GetType(typeName.Trim());
                if (type != null)
                    _selectedTypes.Add(type);
            }
            foreach (Type type in _selectedTypes)
            {
                ListAllMembers(assembly, type);
            }

            Console.WriteLine(new string('=', 80));
            Console.WriteLine("Select members (separate by whitespace): ");
            string[] selectedMemberNames = Console.ReadLine().Split(' ');
            foreach (Type type in _selectedTypes)
            {
                foreach (string memberName in selectedMemberNames)
                {
                    if (type.GetMember(memberName.Trim()).Length > 0)
                    {
                        MemberInfo member = type.GetMember(memberName.Trim())[0];
                        if (member != null && !_selectedMembers.Contains(member))
                            _selectedMembers.Add(member);
                    }
                }
            }
        }

        private static void ListAllMembers(Assembly assembly, Type type)
        {
            Console.WriteLine(new string('_', 80));

            Console.WriteLine("\nListAllMembers for: {0} \n", type);

            MemberInfo[] members = type.GetMembers();

            foreach (MemberInfo element in members)
                Console.WriteLine("{0,-15}:  {1}", element.MemberType, element);
        }

        private static void ListSelectedTypesAndMembers()
        {
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("\nSelected Types and Members: \n");

            foreach (Type type in _selectedTypes)
            {
                Console.WriteLine("Type: {0}", type);
                foreach (MemberInfo member in _selectedMembers)
                {
                    if(type.GetMember(member.Name.Trim()).Length > 0)
                    {
                        Console.WriteLine("{0,-15}:  {1}", member.MemberType, member);
                        if(member.MemberType == MemberTypes.Method)
                        {
                            GetParams(_assembly, (MethodInfo)member);
                        }
                    }
                }

            }
        }

        private static void GetParams(Assembly assembly, MethodInfo method)
        {

            if (method != null)
            {
                Console.WriteLine("\nGetParams for method {0}", method.Name);
                ParameterInfo[] parameters = method.GetParameters();
                Console.WriteLine("Params length: " + parameters.Length);

                foreach (ParameterInfo parameter in parameters)
                {
                    Console.WriteLine("parameter.Name: {0}", parameter.Name);
                    Console.WriteLine("parameter.Position: {0}", parameter.Position);
                    Console.WriteLine("parameter.ParameterType: {0}", parameter.ParameterType);
                }
            }
            Console.WriteLine(new string('_', 80));
        }

        private static void ListAttributes(Assembly assembly)
        {
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("\nAttributes for Selected Types and Members: \n");

            foreach (Type type in _selectedTypes)
            {
                Console.WriteLine("Type: {0}", type);
                foreach (MemberInfo member in _selectedMembers)
                {
                    object[] attributes = member.GetCustomAttributes(false);
                    Console.WriteLine("Attributes for {0}:", member.Name);
                    foreach (object attribute in attributes)
                        Console.WriteLine(attribute);
                }
            }
        }


    }
}
