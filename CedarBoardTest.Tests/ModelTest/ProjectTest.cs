// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
using CedarBoard.Model;
using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class ProjectTest
    {

        [TestMethod]
        public void 始めのノードが追加できる()
        {
            Project p = new(new TextFileMock(), "C:");
            Assert.AreEqual("", p.TextFile.GetData(@"C:\origin.txt"));
        }


        [TestMethod]
        public void 二つ目以降の新しいノード追加できる()
        {
            Project p = new(new TextFileMock(), "C:");
            p.TextFile.SetData(@"C:\origin.txt", "Thanks!");
            p.Add("origin", "newNode", new(15, 15));
            Assert.AreEqual("Thanks!", p.TextFile.GetData(@"C:\newNode.txt"));
        }

        [TestMethod]
        public void 指定されたノードを削除できる()
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
        public void 指定したノードの名前を変更できる()
        {
            Project p = new(new TextFileMock(), "C:");
            p.TextFile.SetData(@"C:\origin.txt", "Thanks!");
            p.Add("origin", "newNode", new(15, 15));
        }

        [TestMethod]
        public void 指定したノードのパスを返せる()
        {
            Project p = new(new TextFileMock(), "C:");
            Assert.AreEqual(@"C:\origin.txt", p.GetNodePath("origin"));
        }
    }
}

