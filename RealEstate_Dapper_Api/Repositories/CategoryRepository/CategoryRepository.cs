using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select*From Category";
            using (var connection =_context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                //burada eşleştirme yapılıyor sorgu calıstırılarak resultcategory nesnesi dönüyor
                return values.ToList();
            }

            /*                      Using var kullanımı
             *    
             *    using anahtar kelimesi IDisposable arayüzünü uygulayan nesnelerle calısırken 
             *    kullanılır. using anahtarı ile bu context bağlantı süresini sınırlarız
             *    using blogu tamamlandığında Dispose metodu otomatik çağrılarak bağlantıyı kapatır
             *    bu veritabanına sızıntı yapılmasını engeller ve kaynakları düzgün serbest bırakır.
             * 

             * 
                */
        }
    }
}
