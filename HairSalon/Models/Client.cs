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

  }
}
