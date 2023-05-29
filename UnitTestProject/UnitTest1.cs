using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Windows.Forms;

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
        public void TestSvgData1()
        {
            SvgData.SvgData d = new SvgData.SvgData("../../Resources/Buttons/BWSVG/Layer1.svg");
            Assert.AreEqual(104, d.GetHeight());
            Assert.AreEqual(158, d.GetWidth());
        }
        [TestMethod]
        public void TestSvgData2()
        {
            SvgData.SvgData d = new SvgData.SvgData("../../Resources/Buttons/BWSVG/Layer2.svg");
            Assert.AreEqual(68, d.GetHeight());
            Assert.AreEqual(185, d.GetWidth());
        }

        [TestMethod]
        public void TestGridQuestions()
        {
           /* Proiect_Teste_Cultura_Generala.GridQuestions gridQuestions = new Proiect_Teste_Cultura_Generala.GridQuestions();
            PrivateObject obj = new PrivateObject(gridQuestions);
            System.Windows.Forms.Button answer1;
            gridQuestions.Invoke(CheckAnswer(answer1));
            SvgData.SvgData d = new SvgData.SvgData("../../Resources/Buttons/BWSVG/Layer1.svg");
            Assert.AreEqual(104, d.GetHeight());
            Assert.AreEqual(158, d.GetWidth());*/
        }

        private Delegate CheckAnswer(Button answer1)
        {
            throw new NotImplementedException();
        }
    }
}
