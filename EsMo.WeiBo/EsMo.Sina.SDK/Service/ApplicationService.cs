using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsMo.Sina.Model.Person;
using EsMo.Sina.SDK.Storage;

namespace EsMo.Sina.SDK.Service
{
    public class ApplicationService:IApplicationService
    {
        IAccountService accountService;
        public ResourceCache ResourceCache { get; private set; }

        public ApplicationService(IAccountService accountService)
        {
            this.accountService = accountService;
            this.ResourceCache = new ResourceCache();
        }

        public Account Account
        {
            get; set;
        }
    }
}
