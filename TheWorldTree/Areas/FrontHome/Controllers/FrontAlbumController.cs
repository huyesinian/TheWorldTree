using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorldTree.Controllers;
using TheWorldTree.Data;
using TheWorldTree.Models;

namespace TheWorldTree.Areas.FrontHome.Controllers
{
    [Area("FrontHome")]
    public class FrontAlbumController : BaseController
    {
        public RubbishSel Rubbish;
        public TheWorldTreeDBContext _context;

        public FrontAlbumController(TheWorldTreeDBContext context)
        {
            Rubbish = new RubbishSel(context);
            _context = context;
        }
        public IActionResult Index()
        {
            Rubbish.RecordUId(GetCurrentU());
            var AlbumSynthesize = (from s in _context.TreeAlbumFolder
                                   select new
                                   {
                                       TreeAlbumFolders = s
                                   ,
                                       TreeFileInfos = _context.TreeFileInfo.Where(x => x.ContentID == s.ID).ToList()

                                   }).ToList();
            List<TreeFrontAlbum> AlbumsList = new List<TreeFrontAlbum>();
            if (AlbumSynthesize.Count > 0)
            {
                foreach (var item in AlbumSynthesize)
                {
                    TreeFrontAlbum treeFrontSay = new TreeFrontAlbum()
                    {
                        TreeAlbumFolders = item.TreeAlbumFolders,
                        TreeFileInfos = item.TreeFileInfos,

                    };
                    AlbumsList.Add(treeFrontSay);
                }
            }
            ViewBag.ContentSums = AlbumsList.Count();
            ViewBag.TreeForntAlbums = AlbumsList;
            return View();
        }
    }
}
