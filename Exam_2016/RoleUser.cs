using Exam_2016.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Exam_2016
{
    internal class RoleUser<T>
    {
        private UserStore<ApplicationUser> userStore;

        public RoleUser(UserStore<ApplicationUser> userStore)
        {
            this.userStore = userStore;
        }
    }
}