using DatabaseLogic.Connection;
using DatabaseLogic.Utils;
using Model.DBModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogic.DAO.Implementation
{
    public class WorkerDAOImpl : IWorkerDAO
    {
        public int Count()
        {
            string query = "select count(*) from worker";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int Delete(DBWorker entity)
        {
            return DeleteById(entity.id);
        }

        public int DeleteAll()
        {
            string query = "delete from worker";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteById(int id)
        {
            string query = "delete from worker where wid =:wid";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "wid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "wid", id);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(int id)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return ExistsById(id, connection);
            }
        }

        private bool ExistsById(int id, IDbConnection connection)
        {
            string query = "select * from worker where wid=:wid";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "wid", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "wid", id);
                return command.ExecuteScalar() != null;
            }
        }

        public IEnumerable<DBWorker> FindAll()
        {
            string query = "select * from worker order by wid";
            List<DBWorker> returnList = new List<DBWorker>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DBWorker o = new DBWorker(reader.GetInt32(0),
                                                      reader.GetString(1),
                                                      reader.GetInt32(2));

                            returnList.Add(o);
                        }
                    }
                }
            }

            return returnList;
        }

        public IEnumerable<DBWorker> FindAllById(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from worker where wid in (");
            foreach (int id in ids)
            {
                sb.Append(":wid" + id + ",");
            }
            sb.Remove(sb.Length - 1, 1); // delete last ','
            sb.Append(")");

            List<DBWorker> returnList = new List<DBWorker>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (int id in ids)
                    {
                        ParameterUtil.AddParameter(command, "wid" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (int id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "wid" + id, id);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DBWorker o = new DBWorker(reader.GetInt32(0),
                                                      reader.GetString(1),
                                                      reader.GetInt32(2));
                            returnList.Add(o);
                        }
                    }
                }
            }

            return returnList;
        }

        public DBWorker FindById(int id)
        {
            string query = "select * from worker where wid = :wid";
            DBWorker o = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "wid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "wid", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            o = new DBWorker(reader.GetInt32(0),
                                             reader.GetString(1),
                                             reader.GetInt32(2));
                        }
                    }
                }
            }

            return o;
        }

        public int Save(DBWorker entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        private int Save(DBWorker o, IDbConnection connection)
        {
            StringBuilder insertSql = new StringBuilder();

            insertSql.Append("insert into worker (");
            if (o.id != 0)
                insertSql.Append("wid,");
            insertSql.Append("wname) values (");
            if (o.id != 0)
                insertSql.Append(":wid,");
            insertSql.Append(":wname)");

            string updateSql = "update worker set wname=:wname where wid=:wid";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(o.id, connection) ? updateSql : insertSql.ToString();
                if (o.id != 0 && command.CommandText.Equals(insertSql.ToString()))
                    ParameterUtil.AddParameter(command, "wid", DbType.Int32);
                ParameterUtil.AddParameter(command, "wname", DbType.String, 30);
                if (command.CommandText.Equals(updateSql))
                    ParameterUtil.AddParameter(command, "wid", DbType.Int32);

                command.Prepare();
                if (o.id != 0)
                    ParameterUtil.SetParameterValue(command, "wid", o.id);
                ParameterUtil.SetParameterValue(command, "wname", o.name);
                return command.ExecuteNonQuery();
            }
        }

        public int SaveAll(IEnumerable<DBWorker> entities)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction();

                int numSaved = 0;

                foreach (DBWorker entity in entities)
                {
                    numSaved += Save(entity, connection);
                }

                transaction.Commit();

                return numSaved;
            }
        }

        public int DeleteByIdLog(int id)
        {
            string query = "update worker set wex = 0 where wid=:wid";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "wid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "wid", id);
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
