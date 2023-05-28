using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        //testare ca username-ul si parola sunt corecte
        //colorare corecta in functie de scor
        [TestMethod]
        public void TestGoodAnswerQ1()
        {
            Questions.Question q = new Questions.Question(1);
            string s = "  Cetatea de Scaun ";
            Assert.AreEqual(Color.Green, q.CheckGoodAnswer(s));
        }

        [TestMethod]
        public void TestBadAnswerQ1()
        {
            Questions.Question q = new Questions.Question(1);
            string s = "   Cetatea Soroca ";
            Assert.AreEqual(Color.Red, q.CheckGoodAnswer(s));
        }

        [TestMethod]
        public void TestGoodAnswerQ2()
        {
            Questions.Question q = new Questions.Question(38);
            string s = " Pelicanul";
            Assert.AreEqual(Color.Green, q.CheckGoodAnswer(s));
        }

        [TestMethod]
        public void TestBadAnswerQ2()
        {
            Questions.Question q = new Questions.Question(38);
            string s = "  Broasca ";
            Assert.AreEqual(Color.Red, q.CheckGoodAnswer(s));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestSvgDataExeption()
        {
            SvgData.SvgData d = new SvgData.SvgData("../../Resources/Buttons/BWSVG/Layer22.svg");
        }

        [TestMethod]
        public void TestSvgData()
        {
            SvgData.SvgData d = new SvgData.SvgData("../../Resources/Buttons/BWSVG/Layer1.svg");
            Assert.AreEqual(104, d.GetHeight());
            Assert.AreEqual(158, d.GetWidth());
        }

    }
}
