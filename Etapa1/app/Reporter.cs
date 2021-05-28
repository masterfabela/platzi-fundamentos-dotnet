using System;
using System.Collections.Generic;
using SchoolCore.Entidades;
using System.Linq;

namespace SchoolCore.App
{
    public class Reporter
    {
        Dictionary<DictionaryKeys, IEnumerable<SchoolBase>> _dictionary;
        public Reporter(Dictionary<DictionaryKeys, IEnumerable<SchoolBase>> schoolData)
        {
            this._dictionary = schoolData;
        }

        public IEnumerable<Evaluation> GetEvaluationsList()
        {
            if (_dictionary.TryGetValue(DictionaryKeys.Evaluation, out IEnumerable<SchoolBase> list))
            {
                return list.Cast<Evaluation>();
            }
            else
            {
                return new List<Evaluation>();
            }
        }

        public IEnumerable<String> GetSubjectList()
        {
            return GetSubjectList(out var dummy);
        }

        public IEnumerable<String> GetSubjectList(out IEnumerable<Evaluation> evaluationList)
        {
            evaluationList = GetEvaluationsList();
            return evaluationList
                .Select((evaluation) => evaluation.Subject.Name)
                .Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluation>> GetEvaluationDictionaryBySubject()
        {
            Dictionary<string, IEnumerable<Evaluation>> resultDictionary =
                new Dictionary<string, IEnumerable<Evaluation>>();
            var subjectList = GetSubjectList(out var evaluationList);
            foreach (var subject in subjectList)
            {
                var subjectEvaluations = evaluationList
                    .Where((evaluation) => evaluation.Subject.Name == subject);
                resultDictionary.Add(subject, subjectEvaluations);
            }
            return resultDictionary;
        }

        public Dictionary<string, IEnumerable<StudentAverage>> GetScoreStudentsBySubject()
        {
            var response = new Dictionary<string, IEnumerable<StudentAverage>>();
            var scoresBySubjectDictionary = GetEvaluationDictionaryBySubject();
            foreach (var subjectWithScore in scoresBySubjectDictionary)
            {
                var scoreAvg = subjectWithScore.Value
                    .GroupBy((eval) => new
                    {
                        eval.Student.UniqueId,
                        eval.Student.Name
                    })
                    .Select((eval) => new StudentAverage
                    {
                        StudentId = eval.Key.UniqueId,
                        Average = eval.Average((eval) => eval.Score),
                        StudentName = eval.Key.Name
                    });
                response.Add(subjectWithScore.Key, scoreAvg);
            }
            return response;
        }

        // Conseguir top 5 de promedio de todas las asignaturas
        public Dictionary<string, IEnumerable<StudentAverage>> GetTopStudentsBySubjects(Dictionary<string, IEnumerable<StudentAverage>> scoreStudentsBySubject)
        {
            var response = new Dictionary<string, IEnumerable<StudentAverage>>();
            foreach (var subject in scoreStudentsBySubject)
            {
                IEnumerable<StudentAverage> topAverages = subject.Value
                    .OrderByDescending((average) => average.Average)
                    .Take(5);
                response.Add(subject.Key, topAverages);
            }
            return response;
        }
    }
}