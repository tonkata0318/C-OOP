using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private readonly SubjectRepository subjects;
        private readonly StudentRepository students;
        private readonly UniversityRepository universitys;
        public Controller()
        {
            subjects= new SubjectRepository();
            students= new StudentRepository();
            universitys= new UniversityRepository();
        }
        public string AddStudent(string firstName, string lastName)
        {
            string result = "";
            if (this.students.FindByName($"{firstName} {lastName}") != null)
            {
                result = string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            else
            {
                IStudent student=new Student(students.Models.Count+1,firstName, lastName);
                students.AddModel(student);
                result = string.Format(OutputMessages.StudentAddedSuccessfully,firstName,lastName,nameof(StudentRepository));
            }
            return result.TrimEnd();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            string result = "";

            if (subjectType != nameof(TechnicalSubject) &&
                subjectType != nameof(EconomicalSubject) &&
                subjectType != nameof(HumanitySubject))
            {
                result = string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            else if (subjects.FindByName(subjectName) != null)
            {
                result = String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            else
            {
                ISubject subject;
                int subjectId = subjects.Models.Count + 1;

                if (subjectType == nameof(TechnicalSubject))
                {
                    subject = new TechnicalSubject(subjectId, subjectName);
                }
                else if (subjectType == nameof(EconomicalSubject))
                {
                    subject = new EconomicalSubject(subjectId, subjectName);
                }
                else
                {
                    subject = new HumanitySubject(subjectId, subjectName);
                }

                this.subjects.AddModel(subject);
                result = string
                    .Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, nameof(SubjectRepository));
            }

            return result.TrimEnd();
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            string result = string.Empty;
            if (universitys.FindByName(universityName)!=null)
            {
                result = string.Format(OutputMessages.AlreadyAddedUniversity,universityName);
            }
            else
            {
                List<int> requieredSubjectsId=new List<int>();
                foreach (var subName in requiredSubjects)
                {
                    requieredSubjectsId.Add(this.subjects.FindByName(subName).Id);
                }
                IUniversity university = new University(universitys.Models.Count + 1, universityName, category, capacity,requieredSubjectsId);
                universitys.AddModel(university);
                result = string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));
            }
            return result.TrimEnd();
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string result = "";

            string firstName = studentName.Split(" ")[0];
            string lastName = studentName.Split(" ")[1];

            var student = this.students.FindByName(studentName);
            var university = this.universitys.FindByName(universityName);

            if (student == null)
            {
                result = string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }
            else if (university == null)
            {
                result = string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            else if (!university.RequiredSubjects.All(x => student.CoveredExams.Any(e => e == x)))
            {
                result = string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            else if (student.University != null && student.University.Name == universityName)
            {
                result = string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }
            else
            {
                student.JoinUniversity(university);
                result = string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
            }

            return result.TrimEnd();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            string result = "";
            if (students.FindById(studentId)==null)
            {
                result= string.Format(OutputMessages.InvalidStudentId);
            }
            else if(subjects.FindById(subjectId)==null) 
            {
                result=string.Format(OutputMessages.InvalidSubjectId);
            }
            else if (students.FindById(studentId).CoveredExams.Contains(subjectId))
            {
                IStudent student = students.FindById(studentId);
                result = string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subjects.FindById(subjectId).Name);
            }
            else
            {
                IStudent student = students.FindById(studentId);
                student.CoverExam(subjects.FindById(subjectId));
                result = string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subjects.FindById(subjectId).Name);
            }
            return result.TrimEnd();
        }

        public string UniversityReport(int universityId)
        {
            StringBuilder sb = new StringBuilder();
            IUniversity university=universitys.FindById(universityId);
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {students.Models.Where(x=>x.University==university).Count()}");
            sb.AppendLine($"University vacancy: {university.Capacity - students.Models.Where(x => x.University == university).Count()}");
            return sb.ToString().TrimEnd();
        }
    }
}
