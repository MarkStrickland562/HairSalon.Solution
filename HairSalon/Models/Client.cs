using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    private string _gender;
    private int _stylistId;
    private int _id;

    public Client(string clientName, string clientGender, int clientStylistId,  int id = 0)
    {
      _name = clientName;
      _gender = clientGender;
      _stylistId = clientStylistId;
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

    public string GetGender()
    {
      return _gender;
    }

    public void SetGender(string newGender)
    {
      _gender = newGender;
    }

    public int GetStylistId()
    {
      return _stylistId;
    }

    public void SetStylistId(int newStylistId)
    {
      _stylistId = newStylistId;
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
      cmd.CommandText = @"DELETE FROM clients;";
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
      cmd.CommandText = @"INSERT INTO clients (name, gender, stylist_id) VALUES (@name, @gender, @stylistId);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      MySqlParameter gender = new MySqlParameter();
      gender.ParameterName = "@gender";
      gender.Value = this._gender;
      cmd.Parameters.Add(gender);
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylistId";
      stylistId.Value = this._stylistId;
      cmd.Parameters.Add(stylistId);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string clientGender = rdr.GetString(2);
        int clientStylistId = rdr.GetInt32(3);
        Client newClient = new Client(clientName, clientGender, clientStylistId, clientId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.GetId() == newClient.GetId();
        bool nameEquality = this.GetName() == newClient.GetName();
        bool genderEquality = this.GetGender() == newClient.GetGender();
        bool stylistIdEquality = this.GetStylistId() == newClient.GetStylistId();
        return (idEquality && nameEquality && genderEquality && stylistIdEquality);
      }
    }

  }
}
