using Spectrum.SharedKernel.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWS.Web.Logic
{
    public class CurrentMenuFinder
    {
        private List<MainMenuItem> userMenu;
        private string path;

        public CurrentMenuFinder()
        {
            userMenu = NavSession.GetMenu();
        }

        public void UpdateCurrentPage()
        {
            path = HttpContext.Current.Request.Url.AbsoluteUri;

            foreach (MainMenuItem mi in userMenu)
            {
                if (mi.Children != null)
                {
                    foreach (SubMenuItem si in mi.Children)
                    {
                        if (path.ToLower().Contains(si.PageUrl.RelativeUrl.Replace("~/", string.Empty).ToLower()))
                        {
                            this.SelectedTabMenuId = -1;
                            this.SelectedSubMenuId = si.Id;
                            this.SelectedMainMenuId = mi.Id;
                        }
                        if (si.Children != null)
                        {
                            
                            foreach (TabMenuItem ti in si.Children)
                            {
                                if (path.ToLower().Contains(ti.PageUrl.RelativeUrl.Replace("~/", string.Empty).ToLower()))
                                {
                                    this.SelectedTabMenuId = ti.Id;
                                    this.SelectedSubMenuId = si.Id;
                                    this.SelectedMainMenuId = mi.Id;
                                }
                            }
                        }
                    }
                }
            }
        }

        public List<TabMenuItem> GetTabs()
        {

            if (this.SelectedSubMenuId > 0)
            {
                var subMenu = userMenu.SelectMany(p => p.Children).SingleOrDefault(p => p.Id == this.SelectedSubMenuId);
                if (subMenu != null)
                {
                    return subMenu.Children;
                }
                else
                {
                    return new List<TabMenuItem>();
                }
            }
            return new List<TabMenuItem>();
        }

        public int SelectedMainMenuId { get; private set; }
        public int SelectedSubMenuId { get; private set; }
        public int SelectedTabMenuId { get; private set; }
    }
}