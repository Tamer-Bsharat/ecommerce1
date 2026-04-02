using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.DTO.Response
{
    public class CategoryResponse
    {
        public int cat_Id { get; set; }

        public string UserCreated{  get; set; }

        //public List<CategoryTranslationRespons> Translations {  get; set; }
        public string Name { get; set; }
    }
}
