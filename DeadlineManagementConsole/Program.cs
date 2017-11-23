using DeadlineManagementDB.Helper;
using DeadlineManagementDB.Supporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace DeadlineManagementConsole {
    class Program {
        static void Main(string[] args) {

            CompanyHelper companyHelper = new CompanyHelper();
            BranchHelper branchHelper = new BranchHelper();
            DepartmentHelper departmentHelper = new DepartmentHelper();


            try {
                if (companyHelper.GetAll().Count > 0) {
                    companyHelper.GetAll().ToList().ForEach(c => {
                        WriteLine("\n------------- Company ------------------");
                        WriteLine($"---    {c.Name} has {c.Branches.Count} branch(es)");
                        WriteLine("----------------------------------------");

                        if (c.Branches.Count > 0) {
                            c.Branches.ToList().ForEach(b => {
                                WriteLine("\n  -------------Branch(es)----------------");
                                WriteLine($"  > {b.Name} has {departmentHelper.GetDepartmentsByBranchId(b.Id).Count} Department(s)");
                                if (departmentHelper.GetDepartmentsByBranchId(b.Id).Count > 0) {
                                    WriteLine("\n  ---------Department(s)------------");
                                    departmentHelper.GetDepartmentsByBranchId(b.Id).ForEach(d => {
                                        WriteLine($"  > {d.Name}");
                                    });
                                }
                            });
                        }
                        WriteLine("----------------------------------------");
                    });
                }
                else {
                    WriteLine("no company added to db yet");
                    WriteLine("would you like to Add a test Company ?");
                    var ans = Console.ReadLine();
                    if (ans.Equals("y",StringComparison.OrdinalIgnoreCase)) {

                        Company c = new Company {
                            Name= "MrLee Ltd",
                            Branches = new List<Branch> {
                                new Branch{
                                    Name ="Head Office",
                                    Departments = new List<Department> {
                                        new Department{ Name= "Development Department"},
                                        new Department{ Name= "Human Resources Department"},
                                        new Department{ Name= "Networking Department"},

                                    }
                                },
                                new Branch{
                                    Name ="China Office",
                                    Departments = new List<Department> {
                                        new Department{ Name= "Development Department"},
                                        new Department{ Name= "PMP Department"},
                                        new Department{ Name= "Security Analysis Department"},
                                    }
                                }
                            }
                        };
                        companyHelper.Add(c);
                        Console.WriteLine("Done!! please restart the program to view changes");
                    }
                }
            }
            catch (Exception ex) {

                WriteLine($"Error  > {ex.Message}");
            }

            ReadKey();
        }
    }
}