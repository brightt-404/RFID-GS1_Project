using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Threading;
using System.Configuration;

namespace GS1.MySQL
{
    public class Database
    {

        // private static readonly string connStr =
        //    ConfigurationManager.ConnectionStrings["GS1Db"]?.ConnectionString
        //    ?? "server=localhost;port=3306;user=root;password=;database=gs1;";

        private static readonly string connStr =
            ConfigurationManager.ConnectionStrings["GS1Db"]?.ConnectionString
            ?? "server=103.221.223.9;port=3306;user=rmowigco_rmowigco;password=@KhacGiang10;database=rmowigco_project_rfid;";
        private const int CommandTimeoutSeconds = 15;
        private const int MaxRetryCount = 3;
        private const int RetryDelayMs = 400;

        public Database() { }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }

        private static bool IsTransient(Exception ex)
        {
            if (ex is EndOfStreamException || ex is IOException || ex is TimeoutException)
                return true;

            if (ex is MySqlException mysqlEx)
            {
                // Common transient connectivity conditions when using remote hosts/proxies.
                return mysqlEx.Number == 0   // connection/network failure
                    || mysqlEx.Number == 1042 // unable to connect to host
                    || mysqlEx.Number == 1047 // unknown command (proxy hiccup)
                    || mysqlEx.Number == 1159 // read timeout
                    || mysqlEx.Number == 1161 // write timeout
                    || mysqlEx.Number == 2013 // lost connection during query
                    || mysqlEx.Number == 2006; // server has gone away
            }

            return ex.InnerException != null && IsTransient(ex.InnerException);
        }

        private T ExecuteWithRetry<T>(Func<T> action)
        {
            Exception lastEx = null;

            for (int attempt = 1; attempt <= MaxRetryCount; attempt++)
            {
                try
                {
                    return action();
                }
                catch (Exception ex) when (IsTransient(ex) && attempt < MaxRetryCount)
                {
                    lastEx = ex;
                    Thread.Sleep(RetryDelayMs * attempt);
                }
                catch (Exception ex)
                {
                    lastEx = ex;
                    break;
                }
            }

            throw lastEx ?? new Exception("Database operation failed.");
        }

        public DataTable GetData(string query, params MySqlParameter[] param)
        {
            return ExecuteWithRetry(() =>
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn)
                    {
                        CommandTimeout = CommandTimeoutSeconds
                    };

                    if (param != null)
                        cmd.Parameters.AddRange(param);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            });
        }

        public void Execute(string query, params MySqlParameter[] param)
        {
            ExecuteWithRetry(() =>
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn)
                    {
                        CommandTimeout = CommandTimeoutSeconds
                    };

                    if (param != null)
                        cmd.Parameters.AddRange(param);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            });
        }

        public object ExecuteScalar(string query, params MySqlParameter[] param)
        {
            return ExecuteWithRetry(() =>
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn)
                    {
                        CommandTimeout = CommandTimeoutSeconds
                    };

                    if (param != null)
                        cmd.Parameters.AddRange(param);

                    return cmd.ExecuteScalar();
                }
            });
        }

    }
}
