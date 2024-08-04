using System.Runtime.Serialization;

namespace EventManagementProject.Services
{
    [Serializable]
    public class InvalidEmailOrPasswordException : Exception
    {
       

        public InvalidEmailOrPasswordException() : base("Invalid Email or Password!!")
        {
        }

       
    }
}