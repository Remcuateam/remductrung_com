using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMvc.Data.ADO.NET
{
    //public class FoodDAL : DALBase<Food, int>
    //{
    //    #region[ExecuteNonQuery]
    //    public override int Insert(Food entity)
    //    {
    //        string sql = "sp_Food_Insert";
    //        SqlParameter[] parameters = new SqlParameter[3];
    //        parameters[0] = new SqlParameter("@FoodName", entity.FoodName);
    //        parameters[1] = new SqlParameter("@Price", entity.Price);
    //        parameters[2] = new SqlParameter("@CategoryId", entity.CategoryId);
    //        return SqlHelper.ExecuteNonQuery(sql, CommandType.StoredProcedure, parameters);
    //    }

    //    public override int Update(Food entity)
    //    {
    //        string sql = "sp_Food_Update";
    //        SqlParameter[] parameters = new SqlParameter[4];
    //        parameters[0] = new SqlParameter("@FoodId", entity.Id);
    //        parameters[0] = new SqlParameter("@FoodName", entity.FoodName);
    //        parameters[1] = new SqlParameter("@Price", entity.Price);
    //        parameters[2] = new SqlParameter("@CategoryId", entity.CategoryId);
    //        return SqlHelper.ExecuteNonQuery(sql, CommandType.StoredProcedure, parameters);
    //    }

    //    public override int Delete(int id)
    //    {
    //        return SqlHelper.ExecuteNonQuery("sp_Food_Delete", CommandType.StoredProcedure, new SqlParameter("@FoodId", id));
    //    }

    //    #endregion

    //    #region[ExecuteDataReader]
    //    public override Food GetById(int id)
    //    {
    //        using (SqlDataReader reader = SqlHelper.ExecuteDataReader("sp_Food_GetById", CommandType.StoredProcedure, new SqlParameter("@FoodId", id)))
    //        {
    //            if (reader.HasRows)
    //            {
    //                if (reader.Read())
    //                {
    //                    return new Food()
    //                    {
    //                        Id = reader.GetInt32(0),
    //                        FoodName = reader.GetString(1),
    //                        Price = reader.GetFloat(2),
    //                        CategoryId=reader.GetInt32(3)
    //                    };
    //                }
    //            }
    //        }
    //        return null;
    //    }

    //    public override List<Food> GetList()
    //    {
    //        List<Food> list = new List<Food>();
    //        using (SqlDataReader reader = SqlHelper.ExecuteDataReader("sp_Food_GetAll", CommandType.StoredProcedure))
    //        {
    //            if (reader.HasRows)
    //            {
    //                while (reader.Read())
    //                {
    //                    list.Add(new Food()
    //                    {
    //                        Id = reader.GetInt32(0),
    //                        FoodName = reader.GetString(1),
    //                        Price = reader.GetFloat(2),
    //                        CategoryId = reader.GetInt32(3)
    //                    });
    //                }
    //            }
    //        }
    //        return list;
    //    }
    //    #endregion

    //    #region[ExecuteDataTable]
    //    public override DataTable GetAll()
    //    {
    //        try
    //        {
    //            return SqlHelper.ExecuteDataTable("sp_Account_GetAll", CommandType.Text);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            return null;
    //        }
    //    }
    //    #endregion
    //}
}
