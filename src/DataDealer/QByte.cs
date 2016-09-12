using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qiang.QDataHelper
{
    public class QByte
    {
        public static double ToBcd2Decimal(byte[] data, int posStart, int len)
        {
            int posEnd = posStart + len - 1;
            StringBuilder sb = new StringBuilder();
            for (int i = posStart; i < posEnd; i++)
            {
                string s = data[i].ToString("X2");
                sb.Append(s);
            }
            string lastVal = data[posEnd].ToString("X2");
            sb.Append(".").Append(lastVal);
            return double.Parse(sb.ToString());
        }

        public static bool CheckAccumulation(byte[] bytesToCheck, int startPos, int endPos, int checkPos)
        {
            int _checkPos = (bytesToCheck.Length + checkPos) % bytesToCheck.Length;
            return bytesToCheck[_checkPos] == GenerateAccumulation(bytesToCheck, startPos, endPos);
        }

        public static byte GenerateAccumulation(byte[] bytesForGenerate, int startPos, int endPos)
        {
            int totalLen = bytesForGenerate.Length;
            int _endPos = (totalLen + endPos) % totalLen;

            byte checkResult = 0;
            for (int i = startPos; i <= _endPos; i++)
            {
                checkResult += bytesForGenerate[i];
            }
            return checkResult;
        }
    }
}
