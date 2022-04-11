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
                                                                reader.GetDouble(3),
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
                                                                reader.GetDouble(3),
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
                                                  reader.GetDouble(3),
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
            /*string insertSql = "insert into service (sname, scat, sdur, spri, sprip, sp) " +
                                "values (:sname, :scat, :sdur, :spri, :sprip, :sp)";
            if (o.id != 0)
                insertSql = "insert into service ( sid, sname, scat, sdur, spri, sprip, sp) " +
                                "values (:sid, :sname, :scat, :sdur, :spri, :sprip, :sp)";

            string updateSql = "update service set sname=:sname, scat=:scat, sdur=:sdur, spri=:spri, sprip=:sprip, sp=:sp where sid=:sid";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(o.id, connection) ? updateSql : insertSql;
                if (o.id != 0 && command.CommandText.Equals(insertSql))
                    ParameterUtil.AddParameter(command, "sid", DbType.Int32);
                ParameterUtil.AddParameter(command, "sname", DbType.String, 30);
                ParameterUtil.AddParameter(command, "scat", DbType.String, 30);
                ParameterUtil.AddParameter(command, "sdur", DbType.Int32);
                ParameterUtil.AddParameter(command, "spri", DbType.Double);
                ParameterUtil.AddParameter(command, "sprip", DbType.Int32);
                ParameterUtil.AddParameter(command, "sp", DbType.Int32);
                if (command.CommandText.Equals(updateSql))
                    ParameterUtil.AddParameter(command, "sid", DbType.Int32);

                command.Prepare();
                if (o.id != 0)
                    ParameterUtil.SetParameterValue(command, "sid", o.id);
                ParameterUtil.SetParameterValue(command, "sname", o.name);
                ParameterUtil.SetParameterValue(command, "scat", o.category);
                ParameterUtil.SetParameterValue(command, "sdur", o.duration);
                ParameterUtil.SetParameterValue(command, "spri", o.price);
                ParameterUtil.SetParameterValue(command, "sprip", o.pointsPrice);
                ParameterUtil.SetParameterValue(command, "sp", o.pointsValue);
                return command.ExecuteNonQuery();
            }*/

            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<DBAppointment> entities)
        {
            throw new NotImplementedException();
        }
    }
}
