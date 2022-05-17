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
    public class AppontmentDAOImpl : IAppointmentDAO
    {
        public int Count()
        {
            string query = "select count(*) from appointment";

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

        public int Delete(DBAppointment entity)
        {
            return DeleteById(entity.appointmentId);
        }

        public int DeleteAll()
        {
            string query = "delete from appointment";

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
            string query = "delete from appointment where aid =:aid";

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
            string query = "select * from appointment where aid=:aid";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "aid", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "aid", id);
                return command.ExecuteScalar() != null;
            }
        }

        public IEnumerable<DBAppointment> FindAll()
        {
            string query = "select * from appointment order by aid";
            List<DBAppointment> returnList = new List<DBAppointment>();

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
                            DBAppointment o = new DBAppointment(reader.GetInt32(0),
                                                                reader.GetInt32(1),
                                                                reader.GetDateTime(2),
                                                                reader.IsDBNull(3) ? 0 : reader.GetDouble(3),
                                                                reader.GetInt32(4));

                            returnList.Add(o);
                        }
                    }
                }
            }

            return returnList;
        }

        public IEnumerable<DBAppointment> FindAllById(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from appointment where aid in (");
            foreach (int id in ids)
            {
                sb.Append(":aid" + id + ",");
            }
            sb.Remove(sb.Length - 1, 1); // delete last ','
            sb.Append(")");

            List<DBAppointment> returnList = new List<DBAppointment>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (int id in ids)
                    {
                        ParameterUtil.AddParameter(command, "aid" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (int id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "aid" + id, id);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DBAppointment o = new DBAppointment(reader.GetInt32(0),
                                                                reader.GetInt32(1),
                                                                reader.GetDateTime(2),
                                                                reader.IsDBNull(3) ? 0 : reader.GetDouble(3),
                                                                reader.GetInt32(4));
                            returnList.Add(o);
                        }
                    }
                }
            }

            return returnList;
        }

        public DBAppointment FindById(int id)
        {
            string query = "select * from appointment where aid = :aid";
            DBAppointment o = null;

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
                        if (reader.Read())
                        {
                            o = new DBAppointment(reader.GetInt32(0),
                                                                reader.GetInt32(1),
                                                                reader.GetDateTime(2),
                                                                reader.IsDBNull(3) ? 0 : reader.GetDouble(3),
                                                                reader.GetInt32(4));
                        }
                    }
                }
            }

            return o;
        }

        public int Save(DBAppointment entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        private int Save(DBAppointment o, IDbConnection connection)
        {
            StringBuilder insertSql = new StringBuilder();
            
            insertSql.Append("insert into appointment (");
            if (o.appointmentId != 0)
                insertSql.Append("aid,");
            insertSql.Append("cid, atime, aprice, astate) values (");
            if (o.appointmentId != 0)
                insertSql.Append(":aid,");
            insertSql.Append(":cid, :atime, :aprice, :astate)");

            string updateSql = "update appointment set cid=:cid, atime=:atime, aprice=:aprice, astate=:astate where aid=:aid";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(o.appointmentId, connection) ? updateSql : insertSql.ToString();
                if (o.appointmentId != 0 && command.CommandText.Equals(insertSql.ToString()))
                    ParameterUtil.AddParameter(command, "aid", DbType.Int32);
                ParameterUtil.AddParameter(command, "cid", DbType.Int32);
                ParameterUtil.AddParameter(command, "atime", DbType.DateTime);
                ParameterUtil.AddParameter(command, "aprice", DbType.Double);
                ParameterUtil.AddParameter(command, "astate", DbType.Int32);
                if (command.CommandText.Equals(updateSql))
                    ParameterUtil.AddParameter(command, "aid", DbType.Int32);

                command.Prepare();
                if (o.appointmentId != 0)
                    ParameterUtil.SetParameterValue(command, "aid", o.appointmentId);
                ParameterUtil.SetParameterValue(command, "cid", o.customerId);
                ParameterUtil.SetParameterValue(command, "atime", o.dateTime);
                ParameterUtil.SetParameterValue(command, "aprice", o.price);
                ParameterUtil.SetParameterValue(command, "astate", o.state);
                return command.ExecuteNonQuery();
            }
        }

        public int SaveAll(IEnumerable<DBAppointment> entities)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction();

                int numSaved = 0;

                foreach (DBAppointment entity in entities)
                {
                    numSaved += Save(entity, connection);
                }

                transaction.Commit();

                return numSaved;
            }
        }
    }
}
