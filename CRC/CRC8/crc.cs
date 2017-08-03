/*
 * Author: 			Wenderson Oliveira < https://github.com/wnoliveira >
 * Date: 			30/07/2017
 * Version:			1.0
 */
using System;

namespace crc8_test
{
	/// <summary>
	/// Class for calculation CRC of a buffer data. 
	/// Current version suports only crc8 calculation.
	/// </summary>
	public class Crc
	{
		private byte[] crc8Table 	= new byte[256];
		private const int TAG 		= 0x07;
		
		public Crc()
		{
			initCrc8();
		}
		
		private void initCrc8()
		{
		    int i, j, crc;
		                      
		    for (i = 0; i < 256; i++) 
		    {
		        crc = i;
		        for (j = 0; j < 8; j++)
		        {
		        	crc = (crc << 1) ^ (((crc & 0x80) > 0) ? TAG : 0);
		        }
		        crc8Table[i] = (byte)(crc & 0xFF);
		    }
		}
		
		public byte crc8(byte[] buffer)
		{
		    byte prevCrc 	= 0xFF;
		    int bufferSize 	= buffer.Length;
		    
		    for(int i = 0; i < bufferSize; i++)
		    {
		    	prevCrc = crc8Table[(prevCrc) ^ (buffer[i])];
		    }
		    
		    return prevCrc;
		}
	}
}
