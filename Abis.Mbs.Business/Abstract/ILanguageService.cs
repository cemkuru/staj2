using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Business.Abstract
{
   public interface ILanguageService
    {
        List<Language> GetAll();

        void Add(Language Lanugage);

        void Update(Language language);

        void Delete(int languageId);

        Language GetById(int languageId);
    }
}
