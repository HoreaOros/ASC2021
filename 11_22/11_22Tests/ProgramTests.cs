using Microsoft.VisualStudio.TestTools.UnitTesting;
using _11_22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_22.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest1()
        {
            // Arrange
            //creez un fisiere in care pun rezultatul la care ma astept

            // Act 
            Program.P3();

            // Assert
            // Verifica faptul ca fisierul creat in faza arrange este identic cu fisierul obtinut in urma rularii functiei P3();
        }
        [TestMethod()]
        public void MainTest2()
        {
            // Arrange
            //creez un fisiere in care pun rezultatul la care ma astept

            // Act 
            Program.P3();

            // Assert
            // Verifica faptul ca fisierul creat in faza arrange este identic cu fisierul obtinut in urma rularii functiei P3();
        }
    }
}
