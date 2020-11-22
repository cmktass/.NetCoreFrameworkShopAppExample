using System.Collections.Generic;
using System.Linq;
using shopapp.ui.Model;

namespace shopapp.ui.Data
{
    public static class ProductRepository
    {
        private static List<Product> productList=null;

        static ProductRepository(){
            productList=new List<Product>(){
               new Product(){id=1,name="Huawei",description="Okul Bilgisayarı",price=6500,imageUrl="https://consumer.huawei.com/content/dam/huawei-cbg-site/common/mkt/pdp/pc/matebook-x-pro-2020/img/matebook-x-pro-2020-emerald-green.png",categoryId=1},
               new Product(){id=2,name="Apple İphone 8",description="Cep Telefonu",price=5500,imageUrl="https://st2.myideasoft.com/idea/ex/95/myassets/products/824/apple-iphone-8-plus-mq8l2tu-a-64gb-uzay-grisi-29034-2.png?revision=1570980769",categoryId=2},
               new Product(){id=3,name="Samsung S10",description="Cep Telefonu",price=4500,imageUrl="https://productimages.hepsiburada.net/s/25/375/10107992703026.jpg",categoryId=2}
            };
        }

        public static List<Product> Products{
            get{
                return productList;
            }
        }

        public static void addProduct(Product p){
            productList.Add(p);
        }

        public static Product getProductById(int productId){

            return productList.FirstOrDefault(p=>p.id==productId);
        }
    }
}