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
            if (_dictionary == null)
            {
                throw new ArgumentNullException(nameof(schoolData));
            }
            this._dictionary = schoolData;
        }

        public IEnumerable<School> GetEvaluationsList()
        {
            IEnumerable<School> response;
            if (_dictionary.TryGetValue(DictionaryKeys.School, out IEnumerable<SchoolBase> list))
            {
                response = list.Cast<School>();
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}