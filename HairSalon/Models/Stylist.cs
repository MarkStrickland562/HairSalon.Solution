using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _name;
    private DateTime _hireDate;
    private int _id;

    public Stylist(string stylistName, DateTime stylistHireDate,  int id = 0)
    {
      _name = stylistName;
      _hireDate = stylistHireDate;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public DateTime GetHireDate()
    {
      return _hireDate;
    }

    public void SetHireDate(DateTime newHireDate)
    {
      _hireDate = newHireDate;
    }

    public int GetId()
    {
      return _id;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists_specialties; DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name, hire_date) VALUES (@name, @hireDate);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      MySqlParameter hireDate = new MySqlParameter();
      hireDate.ParameterName = "@hireDate";
      hireDate.Value = this._hireDate;
      cmd.Parameters.Add(hireDate);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int StylistId = rdr.GetInt32(0);
        string StylistName = rdr.GetString(1);
        DateTime StylistHireDate = rdr.GetDateTime(2);
        Stylist newStylist = new Stylist(StylistName, StylistHireDate, StylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int StylistId = 0;
      string StylistName = "";
      DateTime StylistHireDate = new DateTime(1900, 1, 1);
      while(rdr.Read())
      {
        StylistId = rdr.GetInt32(0);
        StylistName = rdr.GetString(1);
        StylistHireDate = rdr.GetDateTime(2);
      }
      Stylist newStylist = new Stylist(StylistName, StylistHireDate, StylistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newStylist;
    }

    public List<Client> GetClients()
    {
      List<Client> allStylistClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM Clients WHERE stylists_id = @Stylist_id;";
      MySqlParameter StylistId = new MySqlParameter();
      StylistId.ParameterName = "@Stylist_id";
      StylistId.Value = this._id;
      cmd.Parameters.Add(StylistId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string clientGender = rdr.GetString(2);
        int clientStylistId = rdr.GetInt32(3);
        Client newClient = new Client(clientName, clientGender, clientStylistId, clientId);
        allStylistClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylistClients;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists_specialties WHERE stylists_id = (@searchid);
                          UPDATE clients SET stylists_id = NULL WHERE stylists_id = (@searchId);
                          DELETE FROM stylists WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this._id;
      cmd.Parameters.Add(searchId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists_specialties;
                          UPDATE clients SET stylists_id = NULL;
                          DELETE FROM stylists";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newName, DateTime newHireDate)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET name = (@stylistName), hire_date = (@stylistHireDate) WHERE id = (@stylistId);";
      MySqlParameter stylistNameParameter = new MySqlParameter();
      stylistNameParameter.ParameterName = "@stylistName";
      stylistNameParameter.Value = newName;
      cmd.Parameters.Add(stylistNameParameter);
      MySqlParameter stylistHireDateParameter = new MySqlParameter();
      stylistHireDateParameter.ParameterName = "@stylistHireDate";
      stylistHireDateParameter.Value = newHireDate;
      cmd.Parameters.Add(stylistHireDateParameter);
      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@stylistId";
      stylistIdParameter.Value = this._id;
      cmd.Parameters.Add(stylistIdParameter);
      cmd.ExecuteNonQuery();
      _name = newName;
      _hireDate = newHireDate;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void AddSpecialty(Specialty newSpecialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_specialties (stylists_id, specialties_id) VALUES (@stylistId, @specialtyId);";
      MySqlParameter specialtyIdParameter = new MySqlParameter();
      specialtyIdParameter.ParameterName = "@specialtyId";
      specialtyIdParameter.Value = newSpecialty.GetId();
      cmd.Parameters.Add(specialtyIdParameter);
      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@stylistId";
      stylistIdParameter.Value = this._id;
      cmd.Parameters.Add(stylistIdParameter);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Specialty> GetSpecialties()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT specialties.*
                            FROM stylists
                            JOIN stylists_specialties ON (stylists.id = stylists_specialties.stylists_id)
                            JOIN specialties ON (stylists_specialties.specialties_id = specialties.id)
                           WHERE stylists.id = (@stylistId);";
      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@stylistId";
      stylistIdParameter.Value = this._id;
      cmd.Parameters.Add(stylistIdParameter);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Specialty> specialtyList = new List<Specialty>{};
      while(rdr.Read())
      {
        int specialtyId = rdr.GetInt32(0);
        string specialty= rdr.GetString(1);
        Specialty newSpecialty = new Specialty(specialty, specialtyId);
        specialtyList.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
         conn.Dispose();
      }
      return specialtyList;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.GetId().Equals(newStylist.GetId());
        bool nameEquality = this.GetName().Equals(newStylist.GetName());
        bool hireDateEquality = this.GetHireDate().Equals(newStylist.GetHireDate());
        return (idEquality && nameEquality && hireDateEquality);
      }
    }
  }
}
