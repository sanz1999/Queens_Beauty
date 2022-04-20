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
    public class SIADAOImpl : ISIADAO
    {
        public int Count()
        {
            string query = "select count(*) from sia";

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

        public int Delete(DBSIA entity)
        {
            return DeleteById(entity.id);
        }

        public int DeleteAll()
        {
            string query = "delete from sia";

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

        public int DeleteById(Tuple<int, int> id)
        {
            string query = "delete from sia where aid =:aid and sid=:sid";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "aid", DbType.Int32);
                    ParameterUtil.AddParameter(command, "sid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "aid", id.Item1);
                    ParameterUtil.SetParameterValue(command, "sid", id.Item2);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(Tuple<int, int> id)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return ExistsById(id, connection);
            }
        }

        private bool ExistsById(Tuple<int, int> id, IDbConnection connection)
        {
            string query = "select * from sia where aid=:aid and sid=:sid";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "aid", DbType.Int32);
                ParameterUtil.AddParameter(command, "sid", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "aid", id.Item1);
                ParameterUtil.SetParameterValue(command, "sid", id.Item2);
                return command.ExecuteScalar() != null;
            }
        }

        public IEnumerable<DBSIA> FindAll()
        {
            string query = "select * from sia order by aid, sid";
            List<DBSIA> returnList = new List<DBSIA>();

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
                            Tuple<int,int> temp = new Tuple<int, int>(reader.GetInt32(0), reader.GetInt32(1));
                            DBSIA o = new DBSIA(temp,
                                                reader.GetInt32(2));

                            returnList.Add(o);
                        }
                    }
                }
            }

            return returnList;
        }

        public IEnumerable<DBSIA> FindAllById(IEnumerable<Tuple<int, int>> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from sia where (aid, sid) in (");
            foreach (Tuple<int, int> id in ids)
            {
                sb.Append("(:aid" + id.Item1 + id.Item2 + "," + ":sid" + id.Item1 + id.Item2 + "),");
            }
            sb.Remove(sb.Length - 1, 1); // delete last ','
            sb.Append(")");            

            //DEBUG
            Console.WriteLine(sb.ToString());

            List<DBSIA> returnList = new List<DBSIA>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (Tuple<int, int> id in ids)
                    {
                        ParameterUtil.AddParameter(command, "aid" + id, DbType.Int32);
                        ParameterUtil.AddParameter(command, "sid" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (Tuple<int, int> id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "aid" + id, id.Item1);
                        ParameterUtil.SetParameterValue(command, "sid" + id, id.Item2);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tuple<int, int> temp = new Tuple<int, int>(reader.GetInt32(0), reader.GetInt32(1));
                            DBSIA o = new DBSIA(temp, reader.GetInt32(2));
                            returnList.Add(o);
                        }
                    }
                }
            }

            return returnList;
        }

        public DBSIA FindById(Tuple<int, int> id)
        {
            string query = "select * from sia where aid = :aid and sid=:sid";
            DBSIA o = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "aid", DbType.Int32);
                    ParameterUtil.AddParameter(command, "sid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "aid", id.Item1);
                    ParameterUtil.SetParameterValue(command, "sid", id.Item2);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Tuple<int, int> temp = new Tuple<int, int>(reader.GetInt32(0), reader.GetInt32(1));
                            o = new DBSIA(temp, reader.GetInt32(2));
                        }
                    }
                }
            }

            return o;
        }

        public int Save(DBSIA entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }
        private int Save(DBSIA o, IDbConnection connection)
        {
            string insertSql = "insert into sia (aid, sid, wid) values (:aid, :sid, :wid)";
                                 
            string updateSql = "update sia set wid=:wid where aid=:aid and sid=:sid";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(o.id, connection) ? updateSql : insertSql.ToString();
                if (command.CommandText.Equals(insertSql))
                {
                    ParameterUtil.AddParameter(command, "aid", DbType.Int32);
                    ParameterUtil.AddParameter(command, "sid", DbType.Int32);
                }    
                ParameterUtil.AddParameter(command, "wid", DbType.Int32);
                if (command.CommandText.Equals(updateSql))
                {
                    ParameterUtil.AddParameter(command, "aid", DbType.Int32);
                    ParameterUtil.AddParameter(command, "sid", DbType.Int32);
                }

                command.Prepare();                
                
                ParameterUtil.SetParameterValue(command, "aid", o.id.Item1);
                ParameterUtil.SetParameterValue(command, "sid", o.id.Item2);
                ParameterUtil.SetParameterValue(command, "wid", o.workerId);
                return command.ExecuteNonQuery();
            }
        }

        public int SaveAll(IEnumerable<DBSIA> entities)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction();

                int numSaved = 0;

                foreach (DBSIA entity in entities)
                {
                    numSaved += Save(entity, connection);
                }

                transaction.Commit();

                return numSaved;
            }
        }

        public IEnumerable<Tuple<int, int>> GetAllServicesForId(int id)
        {
            string query = "select * from sia where aid =:aid order by sid";
            List<Tuple<int,int>> returnList = new List<Tuple<int, int>>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "aid", DbType.Int32);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "aid", id);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tuple<int, int> temp = new Tuple<int, int>(reader.GetInt32(1), reader.GetInt32(2));
                            
                            returnList.Add(temp);
                        }
                    }
                }
            }

            return returnList;
        }

        public int DeleteAllByAppointmentId(int id)
        {
            string query = "delete from sia where aid =:aid";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "aid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "aid", id);
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
