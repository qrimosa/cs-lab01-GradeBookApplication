using System;
using System.Linq;

using GradeBook.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GradeBook.GradeBooks{
    public class RankedGradeBook : BaseGradeBook{
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted){
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5){
                throw new InvalidOperationException();
            }
            var sortedGrades = Students.Select(s => s.AverageGrade).OrderByDescending(g => g).ToList();

            int rank = sortedGrades.Count(s => s > averageGrade);

            int toptwenty = (int)Math.Ceiling(Students.Count * 0.2);

            if (rank < toptwenty)
                return 'A';
            else if (rank < toptwenty * 2) 
                return 'B';
            else if (rank < toptwenty * 3) 
                return 'C';
            else if (rank < toptwenty * 4) 
                return 'D';
            else
                return 'F';

        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5){
                System.Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else{
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5){
                System.Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else{
                base.CalculateStudentStatistics(name);
            }
        }
    }
}