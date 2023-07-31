using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        {
        }

        public int GetAppUserCount()
        {
            using var context = new Context();
            var value = context.Users.Count();
            return value;
        }

        public List<AppUser> UserListWithWorkLocation()
        {
            var context = new Context();
            return context.Users.Include(x => x.WorkLocation).ToList();
        }
    }
}
