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
    public class CustomerDAOImpl : ICustomerDAO
    {
        public int Count()
        {
            string query = "select count(*) from customer";

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

        public int Delete(DBCustomer entity)
        {
            return DeleteById(entity.id);
        }

        public int DeleteAll()
        {
            string query = "delete from customer";

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
            string query = "delete from customer where cid =:cid";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "cid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "cid", id);
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
            string query = "select * from customer where cid=:cid";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "cid", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "cid", id);
                return command.ExecuteScalar() != null;
            }
        }

        public IEnumerable<DBCustomer> FindAll()
        {
            string query = "select * from customer order by cid";
            List<DBCustomer> returnList = new List<DBCustomer>();

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
                            DBCustomer o = new DBCustomer(reader.GetInt32(0),
                                                          reader.GetString(1),
                                                          reader.GetString(2),
                                                          (reader.IsDBNull(3)) ? DateTime.MaxValue : reader.GetDateTime(3),
                                                          reader.GetString(4),
                                                          reader.IsDBNull(5) ? "" : reader.GetString(5),
                                                          reader.IsDBNull(6) ? "N" : reader.GetString(6),
                                                          reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                                                          reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                                                          reader.GetInt32(9));

                            returnList.Add(o);
                        }
                    }
                }
            }

            return returnList;
        }

        public IEnumerable<DBCustomer> FindAllById(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from customer where cid in (");
            foreach (int id in ids)
            {
                sb.Append(":cid" + id + ",");
            }
            sb.Remove(sb.Length - 1, 1); // delete last ','
            sb.Append(")");

            List<DBCustomer> returnList = new List<DBCustomer>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (int id in ids)
                    {
                        ParameterUtil.AddParameter(command, "cid" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (int id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "cid" + id, id);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DBCustomer o = new DBCustomer(reader.GetInt32(0),
                                                          reader.GetString(1),
                                                          reader.GetString(2),
                                                          (reader.IsDBNull(3)) ? DateTime.MaxValue : reader.GetDateTime(3),
                                                          reader.GetString(4),
                                                          reader.IsDBNull(5) ? "" : reader.GetString(5),
                                                          reader.IsDBNull(6) ? "N" : reader.GetString(6),
                                                          reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                                                          reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                                                          reader.GetInt32(9));

                            returnList.Add(o);
                        }
                    }
                }
            }

            return returnList;
        }

        public DBCustomer FindById(int id)
        {
            string query = "select * from customer where cid = :cid";
            DBCustomer o = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "cid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "cid", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            o = new DBCustomer(reader.GetInt32(0),
                                                          reader.GetString(1),
                                                          reader.GetString(2),
                                                          (reader.IsDBNull(3)) ? DateTime.MaxValue : reader.GetDateTime(3),
                                                          reader.GetString(4),
                                                          reader.IsDBNull(5) ? "" : reader.GetString(5),
                                                          reader.IsDBNull(6) ? "N" : reader.GetString(6),
                                                          reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                                                          reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                                                          reader.GetInt32(9));

                        }
                    }
                }
            }

            return o;
        }

        public int Save(DBCustomer entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        private int Save(DBCustomer entity, IDbConnection connection) 
        { 
            StringBuilder insertSql = new StringBuilder();

            //insert into customer (cid, cname, csname, cdob, cnum, cmail, csex, cp, cloyal) values (:cid, :cname, :csname, :cdob, :cnum, :cmail, :csex, :cp, :cloyal)

            insertSql.Append("insert into customer (");
            if (entity.id != 0)
                insertSql.Append("cid,");

            insertSql.Append(" cname, csname");

            if (entity.dateOfBirth != DateTime.MaxValue)
                insertSql.Append(", cdob");

            insertSql.Append(", cnum");

            if (entity.email != null)
                insertSql.Append(", cmail");

            if(entity.gender != null)
                insertSql.Append(", csex");

            if (entity.points != 0)
                insertSql.Append(", cp");

            if (entity.loyaltyNumber != 0)
                insertSql.Append(", cloyal");

            insertSql.Append(") values (");

            if (entity.id != 0)
                insertSql.Append(":cid,");

            insertSql.Append(" :cname, :csname");

            if (entity.dateOfBirth != DateTime.MaxValue)
                insertSql.Append(", :cdob");

            insertSql.Append(", :cnum");

            if (entity.email != null)
                insertSql.Append(", :cmail");

            if (entity.gender != null)
                insertSql.Append(", :csex");

            if (entity.points != 0)
                insertSql.Append(", :cp");

            if (entity.loyaltyNumber != 0)
                insertSql.Append(", :cloyal");

            insertSql.Append(")");

            StringBuilder updateSql = new StringBuilder();

            //update customer set cname=:cname, csname=:csname, cdob=:cdob, cnum=:cnum, cmail=:cmail, csex=:csex, cp=:cp, cloyal=:cloyal where cid=:cid

            updateSql.Append("update customer set cname=:cname, csname=:csname");

            if (entity.dateOfBirth != DateTime.MaxValue)
                updateSql.Append(", cdob=:cdob");

            updateSql.Append(", cnum=:cnum");

            if (entity.email != null)
                updateSql.Append(", cmail=:cmail");

            if (entity.gender != null)
                updateSql.Append(", csex=:csex");

            if (entity.points != 0)
                updateSql.Append(", cp=:cp");

            if (entity.loyaltyNumber != 0)
                updateSql.Append(", cloyal=:cloyal");

            updateSql.Append(" where cid=:cid");
            
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(entity.id, connection) ? updateSql.ToString() : insertSql.ToString();
                if (entity.id != 0 && command.CommandText.Equals(insertSql.ToString()))
                    ParameterUtil.AddParameter(command, "cid", DbType.Int32);
                ParameterUtil.AddParameter(command, "cname", DbType.String, 30);
                ParameterUtil.AddParameter(command, "csname", DbType.String, 30);

                if (entity.dateOfBirth != DateTime.MaxValue)
                    ParameterUtil.AddParameter(command, "cdob", DbType.Date);

                ParameterUtil.AddParameter(command, "cnum", DbType.String, 30);

                if (entity.email != null)
                    ParameterUtil.AddParameter(command, "cmail", DbType.String, 30);

                if (entity.gender != null)
                    ParameterUtil.AddParameter(command, "csex", DbType.String, 1);

                if (entity.points != 0)
                    ParameterUtil.AddParameter(command, "cp", DbType.Int32);

                if(entity.loyaltyNumber != 0)
                    ParameterUtil.AddParameter(command, "cloyal", DbType.Int32);

                if (command.CommandText.Equals(updateSql.ToString()))
                    ParameterUtil.AddParameter(command, "cid", DbType.Int32);

                command.Prepare();
                if (entity.id != 0)
                    ParameterUtil.SetParameterValue(command, "cid", entity.id);
                ParameterUtil.SetParameterValue(command, "cname", entity.name);
                ParameterUtil.SetParameterValue(command, "csname", entity.surname);
                if (entity.dateOfBirth != DateTime.MaxValue)
                    ParameterUtil.SetParameterValue(command, "cdob", entity.dateOfBirth);
                ParameterUtil.SetParameterValue(command, "cnum", entity.phoneNumber);
                if (entity.email != null)
                    ParameterUtil.SetParameterValue(command, "cmail", entity.email);
                if (entity.gender != null)
                    ParameterUtil.SetParameterValue(command, "csex", entity.gender);
                if (entity.points != 0)
                    ParameterUtil.SetParameterValue(command, "cp", entity.points);
                if (entity.loyaltyNumber != 0)
                    ParameterUtil.SetParameterValue(command, "cloyal", entity.loyaltyNumber);
                return command.ExecuteNonQuery();
            }
        }

        public int SaveAll(IEnumerable<DBCustomer> entities)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction();

                int numSaved = 0;

                foreach (DBCustomer entity in entities)
                {
                    numSaved += Save(entity, connection);
                }

                transaction.Commit();

                return numSaved;
            }
        }

        public bool ExistsByLoyaltyNumber(int id)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return ExistsByLoyalty(id, connection);
            }
        }

        private bool ExistsByLoyalty(int id, IDbConnection connection)
        {
            string query = "select * from customer where cloyal=:cloyal";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "cloyal", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "cloyal", id);
                return command.ExecuteScalar() != null;
            }
        }

        public int DeleteByIdLog(int id)
        {
            string query = "update customer set cex = 0 where cid=:cid";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "cid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "cid", id);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<DBCustomer> FindAllExisting()
        {
            string query = "select * from customer where cex != 0 order by cid";
            List<DBCustomer> returnList = new List<DBCustomer>();

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
                            DBCustomer o = new DBCustomer(reader.GetInt32(0),
                                                          reader.GetString(1),
                                                          reader.GetString(2),
                                                          (reader.IsDBNull(3)) ? DateTime.MaxValue : reader.GetDateTime(3),
                                                          reader.GetString(4),
                                                          reader.IsDBNull(5) ? "" : reader.GetString(5),
                                                          reader.IsDBNull(6) ? "N" : reader.GetString(6),
                                                          reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                                                          reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                                                          reader.GetInt32(9));

                            returnList.Add(o);
                        }
                    }
                }
            }

            return returnList;
        }
    }
}
