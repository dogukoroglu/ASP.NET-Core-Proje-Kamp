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
	public class WritterManager : IWritterService
	{
		IWritterDal _writterDal;

		public WritterManager(IWritterDal writterDal)
		{
			_writterDal = writterDal;
		}

		public List<Writter> GetList()
		{
			throw new NotImplementedException();
		}

		public List<Writter> GetWritterByID(int id)
		{
			return _writterDal.GetListAll(x => x.WritterID == id);
		}

		public void TAdd(Writter t)
		{
			_writterDal.Insert(t);
		}

		public void TDelete(Writter t)
		{
			throw new NotImplementedException();
		}

		public Writter TGetById(int id)
		{
			return _writterDal.GetByID(id);
		}

		public void TUpdate(Writter t)
		{
			_writterDal.Update(t);
		}
	}
}
