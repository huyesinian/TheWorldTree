using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TheWorldTree.Data;

namespace TheWorldTree.EXMethod
{
    /// <summary>
    /// 这里是执行数据操作的方法
    /// </summary>
    public static class ExtendDBEX
    {
        /// <summary>
        /// 执行SQL返回受影响的行数
        /// </summary>
        public static int ExecSqlNoQuery<T>(this TheWorldTreeDBContext db, string sql, SqlParameter[] sqlParams = null) where T : new()
        {
            return ExecuteNoQuery<T>(db, sql, sqlParams);
        }
        /// <summary>
        /// 执行存储过程返回IEnumerable数据集
        /// </summary>
        public static IEnumerable<T> ExecProcReader<T>(this TheWorldTreeDBContext db, string sql, SqlParameter[] sqlParams = null) where T : new()
        {
            return Execute<T>(db, sql, CommandType.StoredProcedure, sqlParams);
        }
        /// <summary>
        /// 执行sql返回IEnumerable数据集
        /// </summary>
        public static IEnumerable<T> ExecSqlReader<T>(this TheWorldTreeDBContext db, string sql, SqlParameter[] sqlParams = null) where T : new()
        {
            return Execute<T>(db, sql, CommandType.Text, sqlParams);
        }
        private static int ExecuteNoQuery<T>(this TheWorldTreeDBContext db, string sql, SqlParameter[] sqlParams) where T : new()
        {
            DbConnection connection = db.Database.GetDbConnection();
            DbCommand cmd = connection.CreateCommand();
            int result = 0;
            db.Database.OpenConnection();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            if (sqlParams != null)
            {
                cmd.Parameters.AddRange(sqlParams);
            }
            result = cmd.ExecuteNonQuery();
            db.Database.CloseConnection();
            return result;
        }
        private static IEnumerable<T> Execute<T>(this TheWorldTreeDBContext db, string sql, CommandType type, SqlParameter[] sqlParams) where T : new()
        {
            DbConnection connection = db.Database.GetDbConnection();
            DbCommand cmd = connection.CreateCommand();
            db.Database.OpenConnection();
            cmd.CommandText = sql;
            cmd.CommandType = type;
            if (sqlParams != null)
            {
                cmd.Parameters.AddRange(sqlParams);
            }
            DataTable dt = new DataTable();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }
            db.Database.CloseConnection();
            return dt.ToCollection<T>();
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static T ToEntity<T>(this DataTable dt) where T : new()
        {
            IEnumerable<T> entities = dt.ToCollection<T>();
            return entities.FirstOrDefault();
        }

        public static IEnumerable<T> ToCollection<T>(this DataTable dt) where T : new()
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return Enumerable.Empty<T>();
            }
            IList<T> ts = new List<T>();
            // 获得此模型的类型 
            Type type = typeof(T);
            string tempName = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    //检查DataTable是否包含此列（列名==对象的属性名）     
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter   
                        if (!pi.CanWrite) continue;//该属性不可写，直接跳出   
                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                ts.Add(t);
            }
            return ts;
        }
    }
}
