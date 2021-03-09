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
    }
}