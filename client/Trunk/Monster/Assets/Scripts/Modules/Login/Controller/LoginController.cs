using UnityEngine;
using System.Collections;

public class LoginController : Singleton<LoginController>
{
    public LoginController()
    {
        
    }

    public void Login(string id, string ipAdress)
    {
        Debug.Log(string.Format("id:{0} ip:{1}", id, ipAdress));
    }
}
