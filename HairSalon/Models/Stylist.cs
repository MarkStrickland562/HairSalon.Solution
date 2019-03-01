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

  }
}
