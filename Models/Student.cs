using System;
using System.ComponentModel.DataAnnotations;

namespace StudentMgmtCQRS.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Department { get; private set; }

        [Required]
        public string PhoneNumber { get; private set; }

        [Range(10, 100)]
        public int Age { get; private set; }

        public int Marks { get; private set; }

        private Student() { } // EF Core requirement

        public Student(string name, string department, string phoneNumber, int age, int marks)
        {
            UpdateDetails(name, department, phoneNumber, age, marks);
        }

        public void UpdateDetails(string name, string department, string phoneNumber, int age, int marks)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 5)
                throw new ArgumentException("Name must be at least 5 characters long.");
            if (string.IsNullOrWhiteSpace(department))
                throw new ArgumentException("Department is required.");
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length != 10)
                throw new ArgumentException("Phone number must be exactly 10 digits.");
            if (age <= 10)
                throw new ArgumentException("Age must be greater than 10.");

            Name = name;
            Department = department;
            PhoneNumber = phoneNumber;
            Age = age;
            Marks = marks;
        }

        public void UpdateMarks(int marks)
        {
            if (marks < 0 || marks > 100)
                throw new ArgumentException("Marks must be between 0 and 100.");
            Marks = marks;
        }
    }
}
