using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Linq;
using CommaBoard.Store.Interface;
using CommaBoard.Store.Class;

namespace CommaBoard.Database.DataConnection
{
    public class DataAccess : IDataAccess
    {
        /// <summary>
        /// Connection string for the SQLite databasecation
        /// </summary>
        /// <returns></returns>
        private string LoadConnectionString()
        {
            return @"DataSource =.\CommaBoard.db; Version = 3;";
        }

        /// <summary>
        /// Generic Create query method
        /// </summary>
        /// <param name="querystring"></param>
        public void CreateQuery(string querystring)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(querystring, new DynamicParameters());
            }
        }

        /// <summary>
        /// Generic Update query method
        /// </summary>
        /// <param name="querystring"></param>
        public void UpdateQuery(string querystring)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(querystring, new DynamicParameters());
            }
        }

        /// <summary>
        /// Generic Delete query method
        /// </summary>
        /// <param name="querystring"></param>
        public void DeleteQuery(string querystring)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(querystring, new DynamicParameters());
            }
        }

        /// <summary>
        /// Method to load a list of Settings Parameters
        /// </summary>
        /// <param name="querystring"></param>
        /// <returns></returns>
        public List<SettingsParameter> LoadSettings(string querystring)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SettingsParameter>(querystring, new DynamicParameters());
                return output.ToList();
            }
        }

        /// <summary>
        /// Query to load a list of CommaBoard Buttons
        /// </summary>
        /// <param name="querystring"></param>
        /// <returns></returns>
        public List<CommaBoardButton> LoadCommaBoardButtons(string querystring)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CommaBoardButton>(querystring, new DynamicParameters());
                return output.ToList();
            }
        }

    }
}
