using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Reflection;

namespace BaseClass.Classes {
    public class CollectionHelper {
        private CollectionHelper() {
            }

        public static DataTable ConvertTo<T>(IList<T> list) {

            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
                {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                    {
                    row[prop.Name] = prop.GetValue(item);
                    }

                table.Rows.Add(row);
                }

            return table;
            }
        //2
        public static IList<T> ConvertTo<T>(IList<DataRow> rows) {
            IList<T> list = null;

            if (rows != null)
                {
                list = new List<T>();

                foreach (DataRow row in rows)
                    {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                    }
                }

            return list;
            }
        //1
        public static IList<T> ConvertTo<T>(DataTable table) {
            if (table == null)
                {
                return null;
                }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
                {
                rows.Add(row);
                }

            return ConvertTo<T>(rows);
            }
        //3
        public static T CreateItem<T>(DataRow row) {
            T obj = default(T);
            if (row != null)
                {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                    {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                        {
                        object value = (row[column.ColumnName]==DBNull.Value ? null : row[column.ColumnName]);
                        if (prop != null)
                            {
                              prop.SetValue(obj,value,null);
                            }                      
                        
                        }
                    catch(Exception ex)
                        {
                        // You can log something here
                        throw;
                        }
                    }
                }

            return obj;
            }
        public static T ConvertToObject<T>(DataTable table)
        {
            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertToObject<T>(rows);
        }
        public static T ConvertToObject<T>(IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list[0];
        }
        public static DataTable CreateTable<T>() {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
                {
                table.Columns.Add(prop.Name,prop.PropertyType);
                }

            return table;
            }
        }
    public class ObjectFieldValue
    {
        private ObjectFieldValue()
        {
        }
        public static object Get<T>(string fieldName,object objectValues)
        {
            object retval=null;
            var obj = Activator.CreateInstance<T>();
            PropertyInfo prop = obj.GetType().GetProperty(fieldName);
            try
            {

                if (prop != null)
                {
                 
                   retval= prop.GetValue(objectValues);
                   //var cc= Convert.ChangeType(aa, aa.GetType());
                 
                }
               


            }
            catch (Exception ex)
            {
                // You can log something here
                throw;
            }
            
            return retval;

        } 
    }
    }
