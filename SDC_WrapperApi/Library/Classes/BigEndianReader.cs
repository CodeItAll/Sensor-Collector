using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/// <summary>
/// Code for reading big endian bianry streams
/// </summary>
namespace Library
{
    class BigEndianReader : IDisposable
    {
        private BinaryReader mBaseReader;

        public BigEndianReader(BinaryReader baseReader)
        {
            mBaseReader = baseReader;
        }

        public ushort ReadUInt16()
        {
            return BitConverter.ToUInt16(ReadBigEndianBytes(2), 0);
        }

        public UInt32 ReadUInt32()
        {
            return BitConverter.ToUInt32(ReadBigEndianBytes(4), 0);
        }

        public Int32 ReadInt32()
        {
            return BitConverter.ToInt32(ReadBigEndianBytes(4), 0);
        }

        public byte[] ReadBigEndianBytes(int count)
        {
            byte[] bytes = new byte[count];
            for (int i = count - 1; i >= 0; i--)
                bytes[i] = mBaseReader.ReadByte();

            return bytes;
        }

        public void Close()
        {
            mBaseReader.Close();
        }

        public byte[] ReadBytes(int count)
        {
            return mBaseReader.ReadBytes(count);
        }

        public byte ReadByte()
        {
            return mBaseReader.ReadByte();
        }

        public Stream BaseStream
        {
            get { return mBaseReader.BaseStream; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                mBaseReader.Dispose();
            }
        }
    }
}
