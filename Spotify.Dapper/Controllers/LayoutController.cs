using Microsoft.AspNetCore.Mvc;

namespace Spotify.Dapper.Controllers
{
	public class LayoutController : Controller
	{
		public PartialViewResult HeadPartial()
		{
			return PartialView();
		}
		public PartialViewResult HeaderPartial()
		{
			return PartialView();
		}
		public PartialViewResult SidebarPartial()
		{
			return PartialView();
		}
		public PartialViewResult FooterPartial()
		{
			return PartialView();
		}
		public PartialViewResult ScriptPartial()
		{
			return PartialView();
		}
	}
}
