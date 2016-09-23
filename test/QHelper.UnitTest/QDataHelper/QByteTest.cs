using Qiang.QDataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Qiang.UnitTest.QDataHelper
{
    public class QByteTest
    {

        #region 测试 BCD

        [Fact]
        public void Test_ToBcd2Decimal()
        {
            //0.arrange
            byte[] bytes = new byte[]
            {
                0x88, 0x88,
                0x12, 0x34, 0x056, 0x78, 0x99,
                0x88
            };
            //1.action
            double vol = QByte.ToBcd2Decimal(bytes, 2, 5);
            //2.assert
            Assert.Equal(12345678.99d, vol);
        }
        

        [Fact]
        public void Test_ToBcdStr()
        {
            //0.arrange
            byte[] bytes = new byte[]
            {
                0x88, 0x88,
                0x12, 0x34, 0x056, 0x78, 0x99,
                0x88
            };
            //1.action
            string str = QByte.ToBcdStr(bytes, 2, 5);
            //2.assert
            Assert.Equal("1234567899", str);
        }


        [Fact]
        public void Test_ToBcd()
        {
            //0.arrange
            byte[] bytes = new byte[]
            {
                0x88, 0x88,
                0x12, 0x34, 0x056, 0x78, 0x99,
                0x88
            };
            //1.action
            int val = QByte.ToBcdInt(bytes, 2, 5);
            //2.assert
            Assert.Equal(1234567899, val);
        }

        #endregion




        #region 测试 校验和

        /// <summary>
        /// 生成校验码 正确
        /// </summary>
        [Fact]
        public void Test_GenerateAccumulation()
        {
            //0.arrange
            byte[] bytesToCheck = new byte[] {
                0x68, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x68, 0x13, 0x07, 0x44, 0x44, 0x55, 0x66, 0x77, 0x88, 0x33,
                0xf5, //to check
                0xff  //end
            };
            int startPos = 0;
            int endPos = -3;
            
            //1.action
            byte accumActual = QByte.GenerateAccumulation(bytesToCheck, startPos, endPos);

            //2.assert
            Assert.Equal(0xf5, accumActual);
        }

        /// <summary>
        /// 生成校验码 正确 默认位置 
        /// </summary>
        [Fact]
        public void Test_GenerateAccumulation_DefaultPos()
        {     //0.arrange
            byte[] bytesToCheck = new byte[] {
                0x68, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x68, 0x13, 0x07, 0x44, 0x44, 0x55, 0x66, 0x77, 0x88, 0x33,
                0xf5, //to check
                0xff  //end
            };
            
            //1.action
            byte accumActual = QByte.GenerateAccumulation(bytesToCheck);

            //2.assert
            Assert.Equal(0xf5, accumActual);
        }


        /// <summary>
        /// 检查校验码 正确
        /// </summary>
        [Fact]
        public void Test_CheckAccumulation() {
            //0.arrange
            byte[] bytesToCheck = new byte[] {
                0x68, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x68, 0x13, 0x07, 0x44, 0x44, 0x55, 0x66, 0x77, 0x88, 0x33,
                0xf5, //to check
                0xff  //end
            };
            int startPos = 0;
            int endPos = -3;
            int checkPos = -2;

            //1.action
            bool isValid = QByte.CheckAccumulation(bytesToCheck, startPos, endPos, checkPos);

            //2.assert
            Assert.True(isValid);
        }

        /// <summary>
        /// 检查校验码 正确 默认位置
        /// </summary>
        [Fact]
        public void Test_CheckAccumulation_DefaultPos()
        {
            //0.arrange
            byte[] bytesToCheck = new byte[] {
                0x68, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x68, 0x13, 0x07, 0x44, 0x44, 0x55, 0x66, 0x77, 0x88, 0x33,
                0xf5, //to check
                0xff  //end
            };

            //1.action
            bool isValid = QByte.CheckAccumulation(bytesToCheck);

            //2.assert
            Assert.True(isValid);
        }

        #endregion




        #region 测试 十六进制值

        [Fact]
        public void Test_TwoBytesToInt() {
            //0.arrange
            byte[] bytes = new byte[]
            {
                0x88, 0x88,
                0x12, 0x34,
                0x056, 0x78, 0x99, 0x88
            };
            //1.action
            int vol = QByte.TwoBytesToInt(bytes, 2);
            //2.assert
            Assert.Equal(4660, vol);
        }

        #endregion




        //0.arrange
        //1.action
        //2.assert
    }
}
