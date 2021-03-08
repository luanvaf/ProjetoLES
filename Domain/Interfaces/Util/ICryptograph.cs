using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Util
{
    public interface ICryptograph
    {
        string EncryptPassword(string password);
        bool VerifyPassword(string password, string encryptedPassword);
    }
}
