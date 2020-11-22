using System.Collections.Generic;
using System.Linq;
using shopapp.ui.Model;

namespace shopapp.ui.Data
{
    public static class CategoryRepository
    {
        private static List<Category> categoryList=null;

        static CategoryRepository(){
            categoryList=new List<Category>(){
                new Category(){id=1,name="Bilgisayar"},
                new Category(){id=2,name="Cep Telefonu"},
                new Category(){id=3,name="Buzdolabı"},
            };
        }

        public static List<Category> Categories{
            get{
                return categoryList;
            }
        }

        public static void addCategory(Category c){
            categoryList.Add(c);
        }

        public static Category GetCategory(int id){
            return categoryList.FirstOrDefault(c=>c.id==id);
        }
    }
}