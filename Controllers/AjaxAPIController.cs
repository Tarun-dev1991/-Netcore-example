using System;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Cors;

namespace jQuery_AJAX_WebAPI_CRUD_MVC.Controllers
{
    [EnableCors(origins: "https://digital-crumbs-script.com", headers: "*", methods: "*")]
   public class AjaxAPIController : ApiController
    {

        [Route("api/AjaxAPI/InsertUser")]
        [HttpPost]
        public User InsertUser(User _user)
        {
            using (UserAnalyticsEntities entities = new UserAnalyticsEntities())
            {
                if (_user != null && _user.Id == 0)
                {
                    User obj = new User();
                    obj = entities.Users.Where(x => x.UserIP == _user.UserIP && x.DomainName == _user.DomainName && x.os==_user.os && x.browser==_user.browser).FirstOrDefault();
                    if (obj == null)
                    {
                        entities.Users.Add(_user);
                        entities.SaveChanges();
                        entities.Dispose();
                    }
                    else
                    {
                        _user.Id = obj.Id;
                    }
                }
            }
            return _user;
        }

        [Route("api/AjaxAPI/InsertUserSession")]
        [HttpPost]
        public UserSession InsertUserSession(UserSession _user)
        {
            using (UserAnalyticsEntities entities = new UserAnalyticsEntities())
            {
                if (_user != null && _user.Id == 0)
                {
                    entities.UserSessions.Add(_user);
                    entities.SaveChanges();
                    entities.Dispose();
                }
            }
            return _user;
        }

        [Route("api/AjaxAPI/InsertUserDetail")]
        [HttpPost]
        public UserDetail InsertUserDetail(UserDetail _userDetail)
        {
            using (UserAnalyticsEntities entities = new UserAnalyticsEntities())
            {
                if (_userDetail != null)
                {
                    _userDetail.SessionDateTime = DateTime.Now;
                    entities.UserDetails.Add(_userDetail);
                    entities.SaveChanges();
                    entities.Dispose();
                }
            }
            return _userDetail;
        }

    }
}
