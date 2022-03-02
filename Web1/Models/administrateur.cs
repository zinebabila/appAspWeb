public class administrateur
{
    public string email { get; set; }
    public string password { get; set; }
    public administrateur(){

}
    public administrateur(string e,string pas)
    {
        email = e;
        password = pas;
       
    }
}