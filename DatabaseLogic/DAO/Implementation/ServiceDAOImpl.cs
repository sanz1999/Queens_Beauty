﻿using DatabaseLogic.Connection;
using DatabaseLogic.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogic.DAO.Implementation
{
    public class ServiceDAOImpl : IServiceDAO
    {
        public int Count()
        {
            string query = "select count(*) from service";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {

                    //Console.WriteLine("Konekcija uspesna");
                    command.CommandText = query;
                    command.Prepare();

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int Delete(Model.Service entity)
        {
            return DeleteById(entity.id);
        }

        public int DeleteAll()
        {
            string query = "delete from service";

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
            string query = "delete from service where sid =:sid";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "sid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "sid", id);
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
            string query = "select * from service where sid=:sid";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "sid", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "sid", id);
                return command.ExecuteScalar() != null;
            }
        }

        public IEnumerable<Model.Service> FindAll()
        {
            string query = "select sid, sname, scat, sdur, spri, sprip, sp from service order by sid";
            List<Model.Service> listaUsluga = new List<Model.Service>();

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
                            //Console.WriteLine("Debug");

                            Model.Service usluga = new Model.Service(reader.GetInt32(0),
                                                       reader.GetString(1),
                                                       reader.GetString(2),
                                                       reader.GetInt32(3),
                                                       reader.GetDouble(4),
                                                       reader.GetInt32(5),
                                                       reader.GetInt32(6));

                            listaUsluga.Add(usluga);
                        }
                    }
                }
            }

            return listaUsluga;
        }

        public IEnumerable<Model.Service> FindAllById(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from service where sid in (");
            foreach (int id in ids)
            {
                sb.Append(":sid" + id + ",");
            }
            sb.Remove(sb.Length - 1, 1); // delete last ','
            sb.Append(")");

            List<Model.Service> serviceList = new List<Model.Service>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (int id in ids)
                    {
                        ParameterUtil.AddParameter(command, "sid" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (int id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "sid" + id, id);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Model.Service service = new Model.Service(reader.GetInt32(0),
                                                                      reader.GetString(1),
                                                                      reader.GetString(2),
                                                                      reader.GetInt32(3),
                                                                      reader.GetDouble(4),
                                                                      reader.GetInt32(5),
                                                                      reader.GetInt32(6));
                            serviceList.Add(service);
                        }
                    }
                }
            }

            return serviceList;
        }

        public Model.Service FindById(int id)
        {
            string query = "select * from service where sid = :sid";
            Model.Service service = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "sid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "sid", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            service = new Model.Service(reader.GetInt32(0),
                                                        reader.GetString(1),
                                                        reader.GetString(2),
                                                        reader.GetInt32(3),
                                                        reader.GetDouble(4),
                                                        reader.GetInt32(5),
                                                        reader.GetInt32(6));
                        }
                    }
                }
            }

            return service;
        }

        public int Save(Model.Service entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        private int Save(Model.Service usluga, IDbConnection connection)
        {
            string insertSql = "insert into service (sname, scat, sdur, spri, sprip, sp) " +
                                "values (:sname, :scat, :sdur, :spri, :sprip, :sp)";
            if (usluga.id != 0)
                insertSql = "insert into service ( sid, sname, scat, sdur, spri, sprip, sp) " +
                                "values (:sid, :sname, :scat, :sdur, :spri, :sprip, :sp)";

            string updateSql = "update service set sname=:sname, scat=:scat, sdur=:sdur, spri=:spri, sprip=:sprip, sp=:sp where sid=:sid";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(usluga.id, connection) ? updateSql : insertSql;
                if (usluga.id != 0 && command.CommandText.Equals(insertSql))
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
                if (usluga.id != 0)
                    ParameterUtil.SetParameterValue(command, "sid", usluga.id);
                ParameterUtil.SetParameterValue(command, "sname", usluga.name);
                ParameterUtil.SetParameterValue(command, "scat", usluga.category);
                ParameterUtil.SetParameterValue(command, "sdur", usluga.duration);
                ParameterUtil.SetParameterValue(command, "spri", usluga.price);
                ParameterUtil.SetParameterValue(command, "sprip", usluga.pointsPrice);
                ParameterUtil.SetParameterValue(command, "sp", usluga.pointsValue);
                return command.ExecuteNonQuery();
            }
        }

        public int SaveAll(IEnumerable<Model.Service> entities)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction();

                int numSaved = 0;

                foreach (Model.Service entity in entities)
                {
                    numSaved += Save(entity, connection);
                }

                transaction.Commit();

                return numSaved;
            }
        }
    }
}