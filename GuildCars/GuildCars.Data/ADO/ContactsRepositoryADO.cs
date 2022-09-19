using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class ContactsRepositoryADO : IContactsRepository
    {
        public void AddContact(Contact contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@ContactName", contact.ContactName);
                cmd.Parameters.AddWithValue("@EmailAddress", contact.EmailAddress);
                cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                cmd.Parameters.AddWithValue("@Message", contact.Message);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

            public List<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Contact currentRow = new Contact();
                        currentRow.ContactID = (int)dr["ContactID"];
                        currentRow.ContactName = dr["ContactName"].ToString();
                        currentRow.EmailAddress = dr["EmailAddress"].ToString();
                        currentRow.PhoneNumber = dr["PhoneNumber"].ToString();
                        currentRow.Message = dr["Message"].ToString();
                        
                        contacts.Add(currentRow);
                    }
                }
            }

            return contacts;
        }
    }
}
