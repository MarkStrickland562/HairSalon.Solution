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

  }
}
