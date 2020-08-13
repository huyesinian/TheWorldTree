using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Apps.Common;
using Microsoft.AspNetCore.Mvc;
using TheWorldTree.Data;
using TheWorldTree.EXMethod;
using TheWorldTree.Models;

namespace TheWorldTree.Controllers
{
    /// <summary>
    /// 图片文件夹
    /// </summary>
    public class AlbumFolderController : BaseVerifyController
    {
        public TreeBaseEX TreeBaseEX;
        public TreeAlbumFolderEX  albumFolderEX;
        public TreeFileInfoEX treeFileInfoEX;
        public TheWorldTreeDBContext _context;

        public AlbumFolderController(TheWorldTreeDBContext context)
        {
            albumFolderEX = new TreeAlbumFolderEX(context);
            treeFileInfoEX = new TreeFileInfoEX(context);
            TreeBaseEX = new TreeBaseEX(context);
            _context = context;
        }

        #region 查询
        /// <summary>
        /// 列表数
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="limit">数据条数</param>
        /// <param name="searchInfo">查询条件</param>
        /// <returns></returns>
        public JsonResult GetList(int page, int limit, string searchInfo)
        {
            var result = albumFolderEX.GetJsonList(page, limit, searchInfo);
            return Json(result);
        }

        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="contentID"></param>
        /// <returns></returns>
        public JsonResult GetFileList( int limit, string contentID, int page= 1)
        {
            var result = treeFileInfoEX.GetJsonList(page, limit, contentID);
            return Json(result);
        }

        /// <summary>
        /// 列表数
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="limit">数据条数</param>
        /// <param name="searchInfo">关联id</param>
        /// <returns></returns>
        public JsonResult GetChildList(int page, int limit, string contentId)
        {
            var result = treeFileInfoEX.GetJsonList(page, limit, contentId);
            return Json(result);
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            TreeAlbumFolder albumFolder = new TreeAlbumFolder()
            {
                ID = Guid.NewGuid().ToString()
            };
            return View(albumFolder);
        }

        [HttpPost]
        public JsonResult Create(TreeAlbumFolder model)
        {
            model.Creater = GetCurrentU();
            model.CreateTime = DateTime.Now;
            if (model != null && ModelState.IsValid)
            {
                try
                {
                    if (albumFolderEX.Create(model) == Suc)
                    {
                        return Json(JsonHandler.CreateMessage(Suc, "创建成功"));
                    }
                    else
                    {
                        return Json(JsonHandler.CreateMessage(Def, "创建失败"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + ex.ToString());
                    return Json(JsonHandler.CreateMessage(Def, "创建失败" + ex.ToString()));
                }

            }

            return Json(JsonHandler.CreateMessage(Def, GetEntityError()));
        }

        #region 修改
        [HttpGet]
        public ActionResult Edit(string id)
        {
            TreeAlbumFolder albumFolder = albumFolderEX.GetList<TreeAlbumFolder>().Where(x => x.ID == id).FirstOrDefault();
            return View(albumFolder);
        }

        [HttpPost]
        public JsonResult Edit(TreeAlbumFolder albumFolder)
        {
            albumFolder.UpdateOne = GetCurrentU();
            if (albumFolder != null && ModelState.IsValid)
            {
                try
                {
                    if (albumFolderEX.Edit(albumFolder) == Suc)
                    {
                        return Json(JsonHandler.CreateMessage(Suc, "修改成功"));
                    }
                    else
                    {
                        return Json(JsonHandler.CreateMessage(Def, "修改失败"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + MethodBase.GetCurrentMethod().Name + ":" + ex.ToString());
                    return Json(JsonHandler.CreateMessage(Def, "修改失败" + ex.ToString()));
                }

            }
            return Json(JsonHandler.CreateMessage(Def, GetEntityError()));

        }
        #endregion

        #region 文件夹删除
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    TreeAlbumFolder catalos = albumFolderEX.GetList<TreeAlbumFolder>().Where(x => x.ID == id).FirstOrDefault();
                    if (albumFolderEX.Delete(catalos) == Suc)
                    {
                        
                        return Json(JsonHandler.CreateMessage(Suc, "删除成功"));
                    }
                    else
                    {

                        return Json(JsonHandler.CreateMessage(Def, "删除失败"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + ex.ToString());
                    return Json(JsonHandler.CreateMessage(Def, "删除失败" + ex.ToString()));
                }

            }
            else
            {
                return Json(JsonHandler.CreateMessage(Def, "请选择要删除的数据"));
            }

        }
        #endregion

        #region 文件删除
        [HttpPost]
        public JsonResult FileDelete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    TreeFileInfo tf = albumFolderEX.GetList<TreeFileInfo>().Where(x => x.ID == id).FirstOrDefault();
                    if (albumFolderEX.Delete(tf) == Suc)
                    {
                        System.IO.File.Delete(tf.FilePath);
                        System.IO.File.Delete(tf.Thum_file);
                        return Json(JsonHandler.CreateMessage(Suc, "删除成功"));
                    }
                    else
                    {

                        return Json(JsonHandler.CreateMessage(Def, "删除失败"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Info(MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + ex.ToString());
                    return Json(JsonHandler.CreateMessage(Def, "删除失败" + ex.ToString()));
                }

            }
            else
            {
                return Json(JsonHandler.CreateMessage(Def, "请选择要删除的数据"));
            }

        }
        #endregion

        #region 上传图片

        [HttpGet]
        public ActionResult UploadImg(string id)
        {
            ViewBag.ContentId = id;
            return View();
        }
        #endregion


    }
}
