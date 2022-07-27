using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningDBFirstApproach.Models;
using Microsoft.EntityFrameworkCore;

//GET ALL EMPS WHO ARE IN DEPT 10,CLERKS,7839
namespace LearningDBFirstApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllEmpDetails();
            //GetEmpDetailsByJob();
            //GetEmpDetailsByDept();
            //GetEmpDetailsByEmpno();
            //AddEmployee();
            ////DeleteEmployee();
            //UpdateEmployee();
            //getstoredprocedue();
            updateEmployeeDetails_sp();
            //sp_insertEmp();
        }
        public static void AddEmployee()
        {
            var ctx = new akshayContext();
            var t = new Emp { Empno = 1234, Ename = "Robert", Job = "ANALYST", Mgr = 7839, Hiredate = DateTime.Now, Sal = 3000, Comm = 200, Deptno = 20 };
            ctx.Emps.Add(t);
            ctx.SaveChanges();
            var empDetails = ctx.Emps;
            foreach (var emp in empDetails)
            {
                Console.WriteLine(emp.Ename + " " + emp.Job + " " + emp.Sal);
            }
        }
        public static void DeleteEmployee()
        {
            var ctx = new akshayContext();
            var deleteEmp = ctx.Emps.Where(x => x.Ename == "JAMES").SingleOrDefault();
            ctx.Remove(deleteEmp);
            Console.WriteLine("Deleted");
            ctx.SaveChanges();
            var empDetails = ctx.Emps;
            foreach (var emp in empDetails)
            {
                Console.WriteLine(emp.Ename + " " + emp.Job + " " + emp.Sal);
            }
        }
        public static void UpdateEmployee()
        {
            var ctx = new akshayContext();
            var updateEmp = ctx.Emps.Where(x => x.Empno==7369).SingleOrDefault();
            updateEmp.Ename = "Akshay";
            ctx.Emps.Update(updateEmp);
            Console.WriteLine("Updated");
            var empDetails = ctx.Emps;
            foreach (var emp in empDetails)
            {
                Console.WriteLine(emp.Ename + " " + emp.Job + " " + emp.Sal);
            }
            ctx.SaveChanges();
        }

        public static void GetAllEmpDetails()
        {
            var ctx = new akshayContext();
            var empDetails = ctx.Emps;
            foreach(var emp in empDetails)
            {
                Console.WriteLine(emp.Ename + " " + emp.Job + " " + emp.Sal);
            }

        }
        public static void GetEmpDetailsByJob()
        {
            var ctx = new akshayContext();
            var empDetails1 = ctx.Emps.Where(x => x.Job == "MANAGER");
            Console.WriteLine("Employees doing Clerk job are : ");
            foreach (var emp in empDetails1)
            {
                
                Console.WriteLine(emp.Ename + " " + emp.Job + " " + emp.Sal);
            }
        }
        public static void GetEmpDetailsByDept()
        {
            var ctx = new akshayContext();
            var empDetails2 = ctx.Emps.Where(x => x.Deptno == 10); ;
            Console.WriteLine("Employees in Department 10 are : ");
            foreach (var emp in empDetails2)
            {
                Console.WriteLine(emp.Ename + " " + emp.Job + " " + emp.Sal);
            }
        }
        public static void GetEmpDetailsByEmpno()
        {
            var ctx = new akshayContext();
            var empDetails2 = ctx.Emps.Where(x => x.Empno == 7839); ;
            Console.WriteLine("Employee with Employee no. 7839 is : ");
            foreach (var emp in empDetails2)
            {
                Console.WriteLine(emp.Ename + " " + emp.Job + " " + emp.Sal);
            }
        }
        //public static void GetEmployeeDetails_sp()
        //{
        //    var ctx = new akshayContext();
        //    var employeees = ctx.Emps.ExecuteSqlRaw("exec [dbo].[Having_salary] @sal,@deptno",800,20);
        //    Console.WriteLine(employeees);
        //}
        private static void getstoredprocedue()
        {
            var ctx = new akshayContext();
            List<Emp> employees = ctx.Set<Emp>().FromSqlRaw("GetEmpDetails").ToList();

            foreach (Emp emp in employees)
            {
                Console.WriteLine(emp.Ename + "  " + emp.Empno);
            }

        }
        public static void updateEmployeeDetails_sp()
        {
            var ctx = new akshayContext();
            var Uemployee = ctx.Emps.FromSqlRaw("UPDATEEMP @x,@y",7782,"rAMESH");
            Console.WriteLine("Update Successfull");
            ctx.SaveChanges();
        }
        private static void sp_insertEmp()
        {
            var ctx = new akshayContext();
            var employee = ctx.Emps.FromSqlRaw("insertEmp @p0,@p1,@p2",120,"rohit",30);
            Console.WriteLine("Insert Successfull");
            ctx.SaveChanges();

        }

    }
}
