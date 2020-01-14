using System;
using System.Data;
using System.Data.Common;

namespace AttendanceSystemWebAPI.DAL
{
    public static class DbCommandExt
    {
        public static DbCommand CreateDbCMD(this DbConnection con, CommandType cmdtype, string cmdtext)
        {
            DbCommand cmd = con.CreateCommand();
            cmd.CommandType = cmdtype;
            cmd.CommandText = cmdtext;
            cmd.Connection = con;
            return cmd;
        }

        public static DbCommand CreateStoredProcedureCMD(this DbConnection con, string cmdtext)
        {
            DbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = cmdtext;
            cmd.Connection = con;
            return cmd;
        }

        public static void AddCMDParam(this DbCommand cmd, string parametername, object value)
        {
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = parametername;
            param.Value = value;
            cmd.Parameters.Add(param);
        }
        public static void AddCMDParam(this DbCommand cmd, string parametername, object value, DbType dbtype)
        {
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = parametername;
            param.Value = value == null ? DBNull.Value : value;
            param.DbType = dbtype;
            cmd.Parameters.Add(param);
        }

        public static void AddCMDOutParam(this DbCommand cmd, string parametername, DbType dbtype)
        {
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = parametername;
            param.DbType = dbtype;
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
        }

        public static bool IsDBNull(this DbDataReader dataReader, string columnName)
        {
            return dataReader[columnName] == DBNull.Value;
        }

        public static DataSet ExecuteDataSet(this DbCommand cmd)
        {
            DataSet oDataSet = new DataSet();
            DbDataAdapter oDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
            oDataAdapter.SelectCommand = cmd;
            oDataAdapter.Fill(oDataSet);
            return oDataSet;
        }

        public static DataTable ExecuteDataTable(this DbCommand cmd)
        {
            DataTable oDataTable = new DataTable();
            oDataTable.Load(cmd.ExecuteReader());
            return oDataTable;
        }
    }
}