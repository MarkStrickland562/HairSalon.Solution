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

  }
}
