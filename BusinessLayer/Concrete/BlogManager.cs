using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

		public List<Blog> GetListWithCategoryByWritterBm(int id)
		{
			return _blogDal.GetListWithCategoryByWritter(id);
		}

		public Blog TGetById(int id)
		{
			return  _blogDal.GetByID(id);
		}

		public List<Blog> GetBlogById(int id)
		{
			return _blogDal.GetListAll(x => x.BlogID == id);
		}

		public List<Blog> GetList()
		{
			// blogları aldığımız mehhod
			return _blogDal.GetListAll();
		}

		public List<Blog> GetLast3Blog()
		{
			return _blogDal.GetListAll().TakeLast(3).OrderByDescending(x=>x.BlogCreateDate).ToList();
		}

		public List<Blog> GetBlogListByWritter(int id)
		{
			return _blogDal.GetListAll(x => x.WritterID == id);
		}

        public void TAdd(Blog t)
        {
			 _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
			_blogDal.Delete(t);	
        }

        public void TUpdate(Blog t)
        {
			_blogDal.Update(t);
        }
    }
}
