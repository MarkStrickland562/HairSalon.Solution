DROP DATABASE mark_strickland;
DROP DATABASE mark_strickland_test;

CREATE DATABASE mark_strickland;

USE mark_strickland;

CREATE TABLE stylists (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                       name VARCHAR(255) NOT NULL,
                       specialty VARCHAR(255) NOT NULL,
                       hire_date DATETIME NOT NULL)
ENGINE=InnoDB;

CREATE TABLE clients (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                      name VARCHAR(255) NOT NULL,
                      gender enum ("Male", "Female", "Non-Binary"),
                      stylist_id INT NOT NULL)
ENGINE=InnoDB;

CREATE DATABASE mark_strickland_test;

USE mark_strickland_test;

CREATE TABLE stylists (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                       name VARCHAR(255) NOT NULL,
                       specialty VARCHAR(255) NOT NULL,
                       hire_date DATETIME NOT NULL)
ENGINE=InnoDB;

CREATE TABLE clients (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                      name VARCHAR(255) NOT NULL,
                      gender enum ("Male", "Female", "non-binary"),
                      stylist_id INT NOT NULL)
ENGINE=InnoDB;
