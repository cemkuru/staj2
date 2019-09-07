using Abis.Mbs.Business.Abstract;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal ILanguageDal)
        {
            _languageDal = ILanguageDal;
        }

        public void Add(Language Language)
        {
            _languageDal.Add(Language);
        }

        public void Delete(int languageId)
        {
            _languageDal.Delete(new Language { LanguageID = languageId });
        }

        public List<Language> GetAll()
        {
            return _languageDal.GetList();
        }

        public Language GetById(int languageId)
        {
            return _languageDal.Get(p => p.LanguageID == languageId);
        }

        public void Update(Language language)
        {
            _languageDal.Update(language);
        }
    }
}
