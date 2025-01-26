using Market.DTO;
using Market.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAO
{
    internal interface ArticleDAO
    {
        List<Article> GetAll();
        Article GetArticle(string barcode);
        bool AddArticle(Article article);
        bool UpdateArticle(Article article, string barcode);
        bool DeleteArticle(Article article);
    }
}
