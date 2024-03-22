using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OHCPROJ.Models;
using Microsoft.Data.SqlClient;


namespace OHCPROJ.Controllers;

public class HomeController : Controller
{


    SqlConnection con=new SqlConnection();
    SqlCommand com=new SqlCommand();

    SqlDataReader? dr;


    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    void connectionString(){

      con.ConnectionString="data source= 192.168.1.240\\SQLEXPRESS ; database=cad_ohc; user ID=CADBATCH01;password=CAD@123pass; TrustServerCertificate=True;";
    }


    [HttpPost]
    public IActionResult VerifyLogin(LoginModel lmodel){
        connectionString();
        con.Open();
        com.Connection=con;
        com.CommandText="Select * from ohc_login where User_name='"+lmodel.User_name+"' and Password='"+lmodel.Password+"' ";

        dr=com.ExecuteReader();

        if(dr.Read()){
            con.Close();
             return View("Success");

        }
        else{
            con.Close();
             return View("Error");

        }


       
    }


    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult Explore()
    {
        return View();
    }
    public IActionResult ContactUs()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
void conStr(){

      con.ConnectionString="data source= 192.168.1.240\\SQLEXPRESS ; database=cad_ohc; user ID=CADBATCH01;password=CAD@123pass; TrustServerCertificate=True;";
        }


    [HttpPost]
  public IActionResult RegisterDB(RegisterModel rmodel){
        conStr();
        con.Open();
        com.Connection=con;
        com.CommandText="insert into User_reg(Username,Email,Phone_Number,Address,City,Postal_Zipcode) values (@Username,@Email,@Phone_Number,@Address,@City,@Postal_Zipcode) ";
        com.Parameters.AddWithValue("@Username",rmodel.Username);
        com.Parameters.AddWithValue("@Email",rmodel.Email);
        com.Parameters.AddWithValue("@Phone_Number",rmodel.Phone_Number);
        com.Parameters.AddWithValue("@Address",rmodel.Address);
        com.Parameters.AddWithValue("@City",rmodel.City);
        com.Parameters.AddWithValue("@Postal_Zipcode",rmodel.Postal_Zipcode );

        int rowAffected=com.ExecuteNonQuery();
        if(rowAffected>0){
            con.Close();
            return RedirectToAction("Login");
        }
        else{
            con.Close();
            return View("Error");
        }
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}