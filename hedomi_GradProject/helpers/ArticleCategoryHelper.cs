// PSEUDOCODE / PLAN (detailed):
// 1. Provide small helper methods to obtain Category ID from an Article entity.
// 2. Two surface methods:
//    a) Synchronous extension for already-loaded Article instances:
//       - Return article?.Category?.CategoryID (null if navigation or article is null).
//    b) Async method that loads the Article including the Category from the DbContext:
//       - Use EF Core Include to eagerly load Category.
//       - Query by article id, return article?.Category?.CategoryID.
//       - This avoids lazy-loading requirements and works when Category is not populated.
// 3. Keep methods null-safe and return nullable int (int?) to indicate missing category.
// 4. Place in a small static helper class under an application/helpers namespace so it's easy to call:
//    - ArticleCategoryHelper.GetCategoryIdFromArticle(article)
//    - await ArticleCategoryHelper.GetCategoryIdAsync(context, articleId)
//
// USAGE EXAMPLES:
// - If you already have article with Category loaded:
//     var catId = article.GetCategoryIdFromArticle();
// - If you only have DbContext and article id:
//     var catId = await ArticleCategoryHelper.GetCategoryIdAsync(context, articleId);

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hedomi.domain;
using hedomi.infrastructure.AppDBcontext;

namespace hedomi_GradProject.Helpers
{
    public static class ArticleCategoryHelper
    {
        /// <summary>
        /// Get the category id from an Article instance that may or may not have the Category navigation property populated.
        /// Returns null if article or Category is null.
        /// </summary>
        public static int? GetCategoryIdFromArticle(this Article? article)
        {
            return article?.Category?.CategoryID;
        }

        /// <summary>
        /// Load the Article including its Category and return the CategoryID (or null if not found).
        /// Uses EF Core Include to ensure the navigation property is populated.
        /// </summary>
        public static async Task<int?> GetCategoryIdAsync(this AppDBContext dbContext, int articleId)
        {
            if (dbContext == null) return null;

            var article = await dbContext.Articles
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.ArticleID == articleId)
                .ConfigureAwait(false);

            return article?.Category?.CategoryID;
        }
    }
}