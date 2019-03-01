using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _name;
    private string _specialty;
    private DateTime _hireDate;
    private int _id;

    public Stylist(string stylistName, string stylistSpecialty, DateTime stylistHireDate,  int id = 0)
    {
      _name = stylistName;
      _specialty = stylistSpecialty;
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

    public string GetSpecialty()
    {
      return _specialty;
    }

    public void SetSpecialty(string newSpecialty)
    {
      _specialty = newSpecialty;
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
      cmd.CommandText = @"DELETE FROM stylists;";
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
      cmd.CommandText = @"INSERT INTO stylists (name, specialty, hire_date) VALUES (@name, @specialty, @hireDate);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      MySqlParameter specialty = new MySqlParameter();
      specialty.ParameterName = "@specialty";
      specialty.Value = this._specialty;
      cmd.Parameters.Add(specialty);
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
        string StylistSpecialty = rdr.GetString(2);
        DateTime StylistHireDate = rdr.GetDateTime(3);
        Stylist newStylist = new Stylist(StylistName, StylistSpecialty, StylistHireDate, StylistId);
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
      string StylistSpecialty = "";
      DateTime StylistHireDate = new DateTime(1900, 1, 1);
      while(rdr.Read())
      {
        StylistId = rdr.GetInt32(0);
        StylistName = rdr.GetString(1);
        StylistSpecialty = rdr.GetString(2);
        StylistHireDate = rdr.GetDateTime(3);
      }
      Stylist newStylist = new Stylist(StylistName, StylistSpecialty, StylistHireDate, StylistId);
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
      cmd.CommandText = @"SELECT * FROM Clients WHERE Stylist_id = @Stylist_id;";
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
        bool specialtyEquality = this.GetSpecialty().Equals(newStylist.GetSpecialty());
        bool hireDateEquality = this.GetHireDate().Equals(newStylist.GetHireDate());
        return (idEquality && nameEquality && specialtyEquality && hireDateEquality);
      }
    }
  }
}
