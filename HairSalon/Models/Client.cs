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
      cmd.CommandText = @"INSERT INTO clients (name, gender, stylists_id) VALUES (@name, @gender, @stylistId);";
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

    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int clientId = 0;
      string clientName = "";
      string clientGender = "";
      int clientStylistId = 0;
      while(rdr.Read())
      {
        clientId = rdr.GetInt32(0);
        clientName = rdr.GetString(1);
        clientGender = rdr.GetString(2);
        clientStylistId = rdr.GetInt32(3);
      }
      Client newClient = new Client(clientName, clientGender, clientStylistId, clientId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newClient;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients WHERE id = (@searchId);";
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
      cmd.CommandText = @"DELETE FROM clients";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newName, string newGender, int newStylistId)
     {
       MySqlConnection conn = DB.Connection();
       conn.Open();
       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"UPDATE clients SET name = (@clientName), gender = (@clientGender), stylists_id = (@clientStylistId) WHERE id = (@clientId);";
       MySqlParameter clientNameParameter = new MySqlParameter();
       clientNameParameter.ParameterName = "@clientName";
       clientNameParameter.Value = newName;
       cmd.Parameters.Add(clientNameParameter);
       MySqlParameter clientGenderParameter = new MySqlParameter();
       clientGenderParameter.ParameterName = "@clientGender";
       clientGenderParameter.Value = newGender;
       cmd.Parameters.Add(clientGenderParameter);
       MySqlParameter clientStylistIdParameter = new MySqlParameter();
       clientStylistIdParameter.ParameterName = "@clientStylistId";
       clientStylistIdParameter.Value = newStylistId;
       cmd.Parameters.Add(clientStylistIdParameter);
       MySqlParameter clientIdParameter = new MySqlParameter();
       clientIdParameter.ParameterName = "@clientId";
       clientIdParameter.Value = this._id;
       cmd.Parameters.Add(clientIdParameter);
       cmd.ExecuteNonQuery();
       _name = newName;
       _gender = newGender;
       _stylistId = newStylistId;
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
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
