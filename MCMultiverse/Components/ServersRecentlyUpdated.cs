using MCMultiverse.Models.Application;
using MCMultiverse.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Components
{
    public class ServersRecentlyUpdated : ViewComponent
    {
        private readonly IMCServerService _mCServerService;

        public ServersRecentlyUpdated(MCServerService mCServerService)
        {
            _mCServerService = mCServerService;
        }

        public IViewComponentResult InvokeAsync(int page, int count, string filter)
        {
            ICollection<MCServer> mCServers = _mCServerService.GetServers(page, count, filter);

            return View(mCServers);
        }
    }
}
