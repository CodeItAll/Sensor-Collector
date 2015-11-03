using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Library
{
    /// <summary>
    /// Generic Functions Class
    /// </summary>
    internal static class Generic
    {
        
        public static byte[] getBytes<T>(T str)
        {
            byte[] arr = null;
            IntPtr ptr = IntPtr.Zero;
            try
            {
                int size = Marshal.SizeOf(str);
                arr = new byte[size];
                ptr = Marshal.AllocHGlobal(size);

                Marshal.StructureToPtr(str, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);               
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return arr;
        }
                
       

        public static T DeserializeMsg<T>(Byte[] data) where T : struct
        {
            int objsize = Marshal.SizeOf(typeof(T));
            IntPtr buff = Marshal.AllocHGlobal(objsize);
            Marshal.Copy(data, 0, buff, objsize);
            T retStruct = (T)Marshal.PtrToStructure(buff, typeof(T));
            Marshal.FreeHGlobal(buff);
            return retStruct;
        }

        public static byte[] GetBytesFromString(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetStringFromBytes(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static byte[] StringToNibbleArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 1), 16))
                             .ToArray();
        }


        public static UInt16 ComputeAdditionChecksum(byte[] data)
        {
            UInt16 sum = 0;
            unchecked // Let overflow occur without exceptions
            {
                foreach (byte b in data)
                {
                    sum += b;
                }
            }
            return sum;
        }

        public static byte[] ChecksumCalc(byte[] ByteArray)
        {
            UInt16 add = Generic.ComputeAdditionChecksum(ByteArray);
            byte[] ChecksumChar = new byte[4];
            ChecksumChar[3] = (byte)((byte)(0x000F & add) + 0x30);
            ChecksumChar[2] = (byte)((byte)((0x00F0 & add) >> 4) + 0x30);
            ChecksumChar[1] = (byte)((byte)((0x0F00 & add) >> 8) + 0x30);
            ChecksumChar[0] = (byte)((byte)((0xF000 & add) >> 12) + 0x30);
            return ChecksumChar;
        }

       
      
    }
}
