using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SqlReadCustomer
{
    public class CustomerController  //use public access modifier so the .dll will work in the program.cs file
    {
        public bool Delete(Customer customer)
        {
            string connStr = @"server=DESKTOP-FLJH9ST\SQLEXPRESS;database=SqlTutorial;Trusted_Connection=true";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("The connection to the SQL DB did not open.");
                return false;
            }
            string sql = "DELETE FROM [Customer] WHERE Id = @Id;";

            SqlCommand cmd = new SqlCommand(sql, conn);

            //SqlParameter pId = new SqlParameter();  //SqlParameter method to call data from SqlDb; professionally, this line is never done like this
            //pId.ParameterName = "@id";  //professionally, this line is never done like this
            //pId.Value = Customerid;  //professionally, this line is never done like this
            //cmd.Parameters.Add(pId);  //create Parameter and add to Parameters list
            cmd.Parameters.Add(new SqlParameter("@Id", customer.Id));
            cmd.Parameters.Add(new SqlParameter("@Name", customer.Name));
            cmd.Parameters.Add(new SqlParameter("@City", customer.City));
            cmd.Parameters.Add(new SqlParameter("@State", customer.State));
            cmd.Parameters.Add(new SqlParameter("@IsCorpAcct", customer.IsCorpAcct));
            cmd.Parameters.Add(new SqlParameter("@CreditLimit", customer.CreditLimit));
            cmd.Parameters.Add(new SqlParameter("@Active", customer.Active));
            cmd.ExecuteNonQuery();  //this is used because we are inserting data into the table, so the reader information below is not needed
            int recsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (recsAffected != 1)
            {
                Console.WriteLine("Delete failed.");
                return false;
            }
            return true;
        }

        public bool Insert(Customer customer)
        {
            string connStr = @"server=DESKTOP-FLJH9ST\SQLEXPRESS;database=SqlTutorial;Trusted_Connection=true";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("The connection to the SQL DB did not open.");
                return false;
            }
            string sql = "INSERT INTO [Customer] "
                        + " (Name, City, State, IsCorpAcct, CreditLimit, Active) "
                        + " values (@Name, @City, @State, @IsCorpAcct, @CreditLimit, @Active);";
            SqlCommand cmd = new SqlCommand(sql, conn);

            //SqlParameter pId = new SqlParameter();  //SqlParameter method to call data from SqlDb; professionally, this line is never done like this
            //pId.ParameterName = "@id";  //professionally, this line is never done like this
            //pId.Value = Customerid;  //professionally, this line is never done like this
            //cmd.Parameters.Add(pId);  //create Parameter and add to Parameters list
            cmd.Parameters.Add(new SqlParameter("@Name", customer.Name));
            cmd.Parameters.Add(new SqlParameter("@City", customer.City));
            cmd.Parameters.Add(new SqlParameter("@State", customer.State));
            cmd.Parameters.Add(new SqlParameter("@IsCorpAcct", customer.IsCorpAcct));
            cmd.Parameters.Add(new SqlParameter("@CreditLimit", customer.CreditLimit));
            cmd.Parameters.Add(new SqlParameter("@Active", customer.Active));
            cmd.ExecuteNonQuery();  //this is used because we are inserting data into the table, so the reader information below is not needed
            int recsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (recsAffected != 1)
            {
                Console.WriteLine("Insert failed.");
                return false;
            }
            return true;
        }

        private SqlDataReader reader = cmd.ExecuteReader();
        if (!reader.HasRows)
        {
            Console.WriteLine($"Customer {Customerid} not found.");
            return null;
        }

    reader.Read();

        int id = reader.GetInt32(reader.GetOrdinal("Id"));
    string name = reader.GetString(reader.GetOrdinal("Name"));
    string city = reader.GetString(reader.GetOrdinal("City"));
    string state = reader.GetString(reader.GetOrdinal("State"));
    bool isCorpAcct = reader.GetBoolean(reader.GetOrdinal("IsCorpAcct"));
    int creditLimit = reader.GetInt32(reader.GetOrdinal("CreditLimit"));
    bool active = reader.GetBoolean(reader.GetOrdinal("Active"));

    Customer customer = new Customer();  //the data below is loaded to the collection of customer generic list
    customer.Id = id;
            customer.Name = name;
            customer.City = city;
            customer.State = state;
            customer.IsCorpAcct = isCorpAcct;
            customer.CreditLimit = creditLimit;
            customer.Active = active;

            return customer;
        }

public List<Customer> SearchByName(string search)
{
    string connStr = @"server=DESKTOP-FLJH9ST\SQLEXPRESS;database=SqlTutorial;Trusted_Connection=true";
    SqlConnection conn = new SqlConnection(connStr);
    conn.Open();
    if (conn.State != System.Data.ConnectionState.Open)
    {
        Console.WriteLine("The connection to the SQL DB did not open.");
        return null;
    }
    string sql = "SELECT * from [Customer]"
        + " WHERE name like '%'+@search+'%'"
        + " ORDER BY name";
    SqlCommand cmd = new SqlCommand(sql, conn);
    SqlParameter psearch = new SqlParameter("@search", search);
    cmd.Parameters.Add(psearch);

    SqlDataReader reader = cmd.ExecuteReader();
    if (!reader.HasRows)
    {
        Console.WriteLine("Result has no rows.");
        return null;
    }
    List<Customer> customers = new List<Customer>();
    while (reader.Read())
    {
        int id = reader.GetInt32(reader.GetOrdinal("Id"));
        string name = reader.GetString(reader.GetOrdinal("Name"));
        string city = reader.GetString(reader.GetOrdinal("City"));
        string state = reader.GetString(reader.GetOrdinal("State"));
        bool isCorpAcct = reader.GetBoolean(reader.GetOrdinal("IsCorpAcct"));
        int creditLimit = reader.GetInt32(reader.GetOrdinal("CreditLimit"));
        bool active = reader.GetBoolean(reader.GetOrdinal("Active"));

        Customer customer = new Customer();
        customer.Id = id;
        customer.Name = name;
        customer.City = city;
        customer.State = state;
        customer.IsCorpAcct = isCorpAcct;
        customer.CreditLimit = creditLimit;
        customer.Active = active;

        customers.Add(customer);
    }
    conn.Close();
    return customers;
}
public List<Customer> SearchByCreditLimitRange(int lower, int upper)
{
    string connStr = @"server=DESKTOP-FLJH9ST\SQLEXPRESS;database=SqlTutorial;Trusted_Connection=true";
    SqlConnection conn = new SqlConnection(connStr);
    conn.Open();
    if (conn.State != System.Data.ConnectionState.Open)
    {
        Console.WriteLine("The connection to the SQL DB did not open.");
        return null;
    }
    string sql = "SELECT * from [Customer]"
        + " WHERE CreditLimit between @lowercl and @uppercl"
        + " ORDER BY creditLimit desc";
    SqlCommand cmd = new SqlCommand(sql, conn);
    SqlParameter plower = new SqlParameter("@lowercl", lower);
    SqlParameter pupper = new SqlParameter("@uppercl", upper);
    cmd.Parameters.Add(plower);
    cmd.Parameters.Add(pupper);

    SqlDataReader reader = cmd.ExecuteReader();
    if (!reader.HasRows)
    {
        Console.WriteLine("Result has no rows.");
        return null;
    }
    List<Customer> customers = new List<Customer>();
    while (reader.Read())
    {
        int id = reader.GetInt32(reader.GetOrdinal("Id"));
        string name = reader.GetString(reader.GetOrdinal("Name"));
        string city = reader.GetString(reader.GetOrdinal("City"));
        string state = reader.GetString(reader.GetOrdinal("State"));
        bool isCorpAcct = reader.GetBoolean(reader.GetOrdinal("IsCorpAcct"));
        int creditLimit = reader.GetInt32(reader.GetOrdinal("CreditLimit"));
        bool active = reader.GetBoolean(reader.GetOrdinal("Active"));

        Customer customer = new Customer();
        customer.Id = id;
        customer.Name = name;
        customer.City = city;
        customer.State = state;
        customer.IsCorpAcct = isCorpAcct;
        customer.CreditLimit = creditLimit;
        customer.Active = active;

        customers.Add(customer);
    }
    conn.Close(); //this line needs to be here, so that when the program runs, it will return data
    return customers; //this line needs to be here, so that when the program runs, it will return data
}

public Customer Get(int Customerid)
{
    string connStr = @"server=DESKTOP-FLJH9ST\SQLEXPRESS;database=SqlTutorial;Trusted_Connection=true";
    SqlConnection conn = new SqlConnection(connStr);
    conn.Open();
    if (conn.State != System.Data.ConnectionState.Open)
    {
        Console.WriteLine("The connection to the SQL DB did not open.");
    }
    string sql = "select * from customer where id = @id";
    SqlCommand cmd = new SqlCommand(sql, conn);
    SqlParameter pId = new SqlParameter();  //SqlParameter method to call data from SqlDb; professionally, this line is never done like this
    pId.ParameterName = "@id";  //professionally, this line is never done like this
    pId.Value = Customerid;  //professionally, this line is never done like this
    cmd.Parameters.Add(pId);  //create Parameter and add to Parameters list
    SqlDataReader reader = cmd.ExecuteReader();
    if (!reader.HasRows)
    {
        Console.WriteLine($"Customer {Customerid} not found.");
        return null;
    }
    reader.Read();

    int id = reader.GetInt32(reader.GetOrdinal("Id"));
    string name = reader.GetString(reader.GetOrdinal("Name"));
    string city = reader.GetString(reader.GetOrdinal("City"));
    string state = reader.GetString(reader.GetOrdinal("State"));
    bool isCorpAcct = reader.GetBoolean(reader.GetOrdinal("IsCorpAcct"));
    int creditLimit = reader.GetInt32(reader.GetOrdinal("CreditLimit"));
    bool active = reader.GetBoolean(reader.GetOrdinal("Active"));

    Customer customer = new Customer();  //the data below is loaded to the collection of customer generic list
    customer.Id = id;
    customer.Name = name;
    customer.City = city;
    customer.State = state;
    customer.IsCorpAcct = isCorpAcct;
    customer.CreditLimit = creditLimit;
    customer.Active = active;

    return customer;
}
public List<Customer> List()  //only Customer instances can go in the List; a List is like an Array but more special because it is coming from the Generic Collection
{
    string connStr = @"server=DESKTOP-FLJH9ST\SQLEXPRESS;database=SqlTutorial;Trusted_Connection=true";  //prior to adding the @, the build on this was not correct and returned error message: Unrecognized Escape Sequence, this was because of the server= having a \ in it, to resolve, add an @ at the beginning of the "...." and that should resolve that error message; server name is found in the SSMS at the top in the Connection list, point to the name of the DB you need to use, then set the trusted connection to true, with setting that to true, superAdmin rights are granted, if not set to true, a UN & PW will need to be set in the connStr
    SqlConnection conn = new SqlConnection(connStr);  //create an instance of SqlConnection, ensure that the using statement is at the top in the using statements section, using System.Data.SqlClient, the pass the connStr through, so it will not need to be set up separately later on
    conn.Open();
    if (conn.State != System.Data.ConnectionState.Open)
    {
        Console.WriteLine("The connection to the SQL DB did not open.");  //this lets you know whether the connection was successful or not
        return null; //this is null because there are not supposed to be nulls in the table and if it returns nothing, then there is an issue with the table
    }
    string sql = "select * from customer";  //create variable sql to start with selecting data from the SQL DB
    SqlCommand cmd = new SqlCommand(sql, conn);  //create a variable cmd and pass sql and conn through on the SqlCommand
    SqlDataReader reader = cmd.ExecuteReader(); //reader is what is used when performing a select statement to use from the the SQL DB
    if (!reader.HasRows)  //if !reader means that if not the reader has rows, it returns results has no rows
    {
        Console.WriteLine("Result has no rows.");
        return null; //this is null because there are not supposed to be nulls in the table and if it returns nothing, then there is an issue with the table
    }
    List<Customer> customers = new List<Customer>();  //this needs to be outside the while loop because it needs to exist when the while loop is finished running; this has to go above the while loop so that the information it is calling can be read and returned to screen
    while (reader.Read())  //if the reader has rows then it should process the information below 1 row @ a time; anything with reader should now be pointing to the data in the first row
    {
        int id = reader.GetInt32(reader.GetOrdinal("Id"));
        string name = reader.GetString(reader.GetOrdinal("Name"));  //GetOrdinal is an int and since we don't know the number of the column, we use that and then enter the Column Name next in ()
        string city = reader.GetString(reader.GetOrdinal("City"));
        string state = reader.GetString(reader.GetOrdinal("State"));
        bool isCorpAcct = reader.GetBoolean(reader.GetOrdinal("IsCorpAcct"));
        int creditLimit = reader.GetInt32(reader.GetOrdinal("CreditLimit"));
        bool active = reader.GetBoolean(reader.GetOrdinal("Active"));

        Customer customer = new Customer();  //the data below is loaded to the collection of customer generic list
        customer.Id = id;
        customer.Name = name;
        customer.City = city;
        customer.State = state;
        customer.IsCorpAcct = isCorpAcct;
        customer.CreditLimit = creditLimit;
        customer.Active = active;

        customers.Add(customer);

        //Console.WriteLine($"Name is {name}"); //use for testing purposes to confirm the connection to the DB will return data requested
    }

    conn.Close(); //this will close the connection to the DB when finished with it
    return customers;  //this returns th collection class of customers to whatever called it, List<Customer> customers = cust.List();

    //Console.WriteLine("Connection open was successful!");
}
    }
}