// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model;
using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class ProjectTest
    {

        [TestMethod]
        public void �n�߂̃m�[�h���ǉ��ł���()
        {
            Project p = new(new TextFileMock(), "C:");
            Assert.AreEqual("", p.TextFile.GetData(@"C:\origin.txt"));
        }


        [TestMethod]
        public void ��ڈȍ~�̐V�����m�[�h�ǉ��ł���()
        {
            Project p = new(new TextFileMock(), "C:");
            p.TextFile.SetData(@"C:\origin.txt", "Thanks!");
            p.Add("origin", "newNode", new(15, 15));
            Assert.AreEqual("Thanks!", p.TextFile.GetData(@"C:\newNode.txt"));
        }

        [TestMethod]
        public void �w�肳�ꂽ�m�[�h���폜�ł���()
        {
            Project p = new(new TextFileMock(), "C:");
            p.TextFile.SetData(@"C:\origin.txt", "Thanks!");
            p.Add("origin", "newNode", new(15, 15));
            p.Remove("newNode");
            var e = Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                p.Add("newNode", "falseNode", new(0, 0));
            });
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void �w�肵���m�[�h�̖��O��ύX�ł���()
        {
            Project p = new(new TextFileMock(), "C:");
            p.TextFile.SetData(@"C:\origin.txt", "Thanks!");
            p.Add("origin", "newNode", new(15, 15));
        }

        [TestMethod]
        public void �w�肵���m�[�h�̃p�X��Ԃ���()
        {
            Project p = new(new TextFileMock(), "C:");
            Assert.AreEqual(@"C:\origin.txt", p.GetNodePath("origin"));
        }
    }
}

