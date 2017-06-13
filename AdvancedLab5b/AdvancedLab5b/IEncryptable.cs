using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab5b
{
    /*
  Interface: IEncryptable.cs
  Author:    Nicholas J. Corkigian
  Date:      February 18, 2010

  Purpose: This interface has two methods that classes making use of must
           implement. 

           The class implementing the Encrypt() method will use some sort
           of encryption algorithm to return some encrypted data.
 
           The class implementing the Decrypt() method will use (presumably)
           the same encryption algorithm to return a decrypted string.

           This code is not to be altered.
*/

    public interface IEncryptable
    {
        string Encrypt();
        string Decrypt();
    }
}
