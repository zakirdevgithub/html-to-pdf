using PDF_GENERATOR.Models;
using System.Collections.Generic;

namespace PDF_GENERATOR.Utility
{
    public static class DataStorage
    {
        public static List<Employee> GetAllEmployess() =>
            new List<Employee>
            {

                new Employee { Name="Zakir", LastName="Hossain", Age=25, Gender="Male"},
                new Employee { Name="Keya", LastName="Rahman", Age=24, Gender="Female"},
                new Employee { Name="Zahid", LastName="Hasan", Age=25, Gender="Male"},
                new Employee { Name="Mitu", LastName="Rahman", Age=23, Gender="Female"},
                new Employee { Name="Rakib", LastName="Talukder", Age=23, Gender="Male"}
            };
    }
}
