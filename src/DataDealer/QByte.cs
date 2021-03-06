﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qiang.QDataHelper
{
    public class QByte
    {
        #region BCD

        /// <summary>
        /// 转换成带两位小数的BCD
        /// </summary>
        public double ToBcd2Decimal(byte[] data, int posStart, int len)
        {
            string strBeforePoint = ToBcdStr(data, posStart, len - 1);
            string strAfterPoint = ToBcdStr(data, posStart + len - 1, 1);
            return double.Parse(strBeforePoint + "." + strAfterPoint);            
        }

        /// <summary>
        /// 生成BCD字符串
        /// </summary>
        public string ToBcdStr(byte[] data, int posStart, int len)
        {
            int posEnd = posStart + len;
            StringBuilder sb = new StringBuilder();
            for (int i = posStart; i < posEnd; i++)
            {
                string s = data[i].ToString("X2");
                sb.Append(s);
            }
            return sb.ToString();
        }


        /// <summary>
        /// 生成BCD的int
        /// </summary>
        public int ToBcdInt(byte[] data, int posStart, int len)
        {
            string strBcd = ToBcdStr(data, posStart, len);
            return int.Parse(strBcd);
        }

        #endregion



        #region 校验和

        /// <summary>
        /// 检验校验和
        /// </summary>
        public bool CheckAccumulation(byte[] bytesToCheck, int startPos, int endPos, int checkPos)
        {
            int _checkPos = (bytesToCheck.Length + checkPos) % bytesToCheck.Length;
            return bytesToCheck[_checkPos] == GenerateAccumulation(bytesToCheck, startPos, endPos);
        }





        /// <summary>
        /// 生成校验和
        /// </summary>
        public byte GenerateAccumulation(byte[] bytesForGenerate, int startPos, int endPos)
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


        #endregion 校验和



        #region 十六进制值

        /// <summary>
        /// 两个字节取十六进制值
        /// </summary>
        public int TwoBytesToInt(byte[] data, int posStart)
        {
            return (int)data[posStart] * (byte.MaxValue + 1) + data[posStart + 1];
        }

        #endregion




        /// <summary>
        /// 结合字节数组
        /// </summary>
        public byte[] Combine(params byte[][] listOfByteArrays)
        {
            int len = listOfByteArrays.Sum(c => c.Length);
            byte[] result = new byte[len];

            int lastLen = 0;
            for (int i = 0; i < listOfByteArrays.Length; i++)
            {
                byte[] bytes = listOfByteArrays[i];
                Buffer.BlockCopy(bytes, 0, result, lastLen, bytes.Length);
                lastLen += bytes.Length;
            }
            return result;
        }


    }
}
