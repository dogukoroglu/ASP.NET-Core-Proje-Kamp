using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IMessage2Service:IGenericService<Message2>
	{
		List<Message2> GetInboxListByWritter(int id);
		List<Message2> GetSendBoxListByWritter(int id);
	}
}
