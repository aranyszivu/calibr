using System;
using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BO = BusinessLayer.BusinessObjects;

namespace Scraper
{
    class ScraperController : IDisposable
    {
        private HtmlGetter getter;
        private HtmlDecoder decoder;
        private AdAssembler assembler;
        bool disposed = false;
        SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);


        public ScraperController() { }

        public List<BO.AdPosting> ScrapeSite(EnumTypes.Websites site)
        {
            getter = new HtmlGetter();
            decoder = new HtmlDecoder();

            switch (site)
            {
                case EnumTypes.Websites.GunPost:
                    return decoder.GetAdList( getter.GunPostSearch() );
                case EnumTypes.Websites.FirearmsCanada:
                case EnumTypes.Websites.TownPost:
                default: throw new NotImplementedException();
            }
        }


        #region Dispose Functions
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if(disposing)
            {
                handle.Dispose();
                getter = null;
                decoder = null;
                assembler = null;
            }

            disposed = true;
        }
        #endregion
    }
}
