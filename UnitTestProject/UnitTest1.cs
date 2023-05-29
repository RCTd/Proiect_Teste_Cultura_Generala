using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Windows.Forms;
using Proiect_Teste_Cultura_Generala;
using System.Collections.Generic;

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
        public void TestBad1AnswerQ1()
        {
            Questions.Question q = new Questions.Question(1);
            string s = " Cetatea Soroca ";
            Assert.AreEqual(Color.Red, q.CheckGoodAnswer(s));
        }
        [TestMethod]
        public void TestBad2AnswerQ1()
        {
            Questions.Question q = new Questions.Question(1);
            string s = " Cetatea Neamtului ";
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
        public void TestBad1AnswerQ2()
        {
            Questions.Question q = new Questions.Question(38);
            string s = "  Broasca ";
            Assert.AreEqual(Color.Red, q.CheckGoodAnswer(s));
        }
        [TestMethod]
        public void TestBad2AnswerQ2()
        {
            Questions.Question q = new Questions.Question(38);
            string s = "  Casca ";
            Assert.AreEqual(Color.Red, q.CheckGoodAnswer(s));
        }
        
        [TestMethod]
        public void TestQuestionGetQuestion()
        {
            Questions.Question q = new Questions.Question(3);
            Assert.AreEqual("Care este denumirea celei mai mari mănăstiri din România, situată în județul Suceava și inclusă în Patrimoniul Mondial UNESCO?", q.GetQuestion());
        }
        [TestMethod]
        public void TestQuestionInitQuestion()
        {
            Questions.Question q = new Questions.Question();
            PrivateObject obj = new PrivateObject(q);
            obj.Invoke("Init", 5);
            Assert.AreEqual("Ce poet roman s-a nascut in judetul Botosani?", obj.GetField("_question"));
        }
        [TestMethod]
        public void TestQuestionInitGoodAnswer()
        {
            Questions.Question q = new Questions.Question();
            PrivateObject obj = new PrivateObject(q);
            obj.Invoke("Init", 3);
            Assert.AreEqual(" Mănăstirea Putna", obj.GetField("_goodA"));
        }
        [TestMethod]
        public void TestQuestionInitBadAnswer()
        {
            Questions.Question q = new Questions.Question();
            PrivateObject obj = new PrivateObject(q);
            obj.Invoke("Init", 3);
            List<string> _badA = new List<string>();
            _badA.Add(" Mănăstirea Moldovița");
            _badA.Add(" Mănăstirea Sucevița");
            _badA.Add("Mănăstirea Voroneț");
            Assert.AreEqual(_badA.ToString(), obj.GetField("_badA").ToString());
        }
        [TestMethod]
        public void TestQuestionGetNumberOfAnswers()
        {
            Questions.Question q = new Questions.Question();
            Assert.AreEqual(4, q.GetNumberOfAnswers());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestSvgDataExeption()
        {
            SvgData.SvgData d = new SvgData.SvgData("../../Resources/Buttons/BWSVG/Layer22.svg");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestSvgButtonExeption()
        {
            SvgButton svgButton = new SvgButton();
            PrivateObject @object = new PrivateObject(svgButton);
            @object.Invoke("GetFigurePath", svgButton.ClientRectangle);
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
        public void TestSvgGetData()
        {
            SvgData.SvgData d = new SvgData.SvgData();
            Assert.AreEqual(0, d.GetHeight());
            Assert.AreEqual(0, d.GetWidth());
            d.Parse("../../Resources/Buttons/BWSVG/Layer2.svg");
            PrivateObject obj = new PrivateObject(d);
            Assert.AreEqual(68, obj.GetField("_height"));
        }

        [TestMethod]
        public void TestSvgButton()
        {
            SvgButton svgButton = new SvgButton();
            Assert.AreEqual(new Size(176, 152), svgButton.Size);
        }

        [TestMethod]
        public void TestGridQuestions()
        {
            GridQuestions gridQuestions = new GridQuestions();
            PrivateObject obj = new PrivateObject(gridQuestions);
            System.Windows.Forms.Button answer1=new System.Windows.Forms.Button();
            obj.Invoke("CheckAnswer", answer1);
            Assert.AreEqual(1, obj.GetField("_numQuestionsAnswered"));
        }

        [TestMethod]
        public void TestMap()
        {
            Map map = new Map();
            PrivateObject obj = new PrivateObject(map);
            obj.Invoke("Buttons_Click", 1);
            Assert.AreEqual(true, Map.isClicked[1]);
        }
        [TestMethod]
        public void TestMapsolved()
        {
            Map map = new Map();
            Assert.AreEqual(false, GridQuestions.isAux[1]);
        }
    }
}
