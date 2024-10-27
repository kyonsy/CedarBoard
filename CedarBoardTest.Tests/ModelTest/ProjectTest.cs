using CedarBoard.Model;
using CedarBoard.Model.Accessor;
using Moq;
using System.Windows.Controls;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class ProjectTest
    {

        [TestMethod]
        public void 始めのノードが追加できる()
        {
            Project p = new(new TextFileMock(), "C:");
            p.Add(new(10, 10));
            Assert.AreEqual("", p.TextFile.GetData(@"C:\origin.txt"));
        }

        [TestMethod] 
        public void 二つ目以降のメゾットで一引数だとエラーがでる()
        {
            Project p = new(new TextFileMock(), "C:");
            p.Add(new(10, 10));
            var e = Assert.ThrowsException<ArgumentException>(() =>
            {
                p.Add(new(10, 10));
            });
            Assert.IsNotNull(e);
        }

        [TestMethod] 
        public void 最初のノードを追加するときは親のindexを指定するとエラーになる()
        {
            Project p = new(new TextFileMock(), "C:");
            var e = Assert.ThrowsException<ArgumentException>(() =>
            {
                p.Add("aa","bb",new(10, 10));
            });
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void 二つ目以降の新しいノード追加できる()
        {
            Project p = new(new TextFileMock(), "C:");
            p.Add(new(10, 10));
            p.TextFile.SetData(@"C:\origin.txt", "Thanks!");
            p.Add("origin", "newNode",new(15,15));
            Assert.AreEqual("Thanks!", p.TextFile.GetData(@"C:\newNode.txt"));
        }

        [TestMethod]
        public void 指定されたノードを削除できる()
        {
            Project p = new(new TextFileMock(), "C:");
            p.Add(new(10, 10));
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
            p.Add(new(10, 10));
            p.TextFile.SetData(@"C:\origin.txt", "Thanks!");
            p.Add("origin", "newNode", new(15, 15));
        }

        [TestMethod]
        public void 指定したノードのパスを返せる()
        {
            Project p = new(new TextFileMock(), "C:");
            p.Add(new(10, 10));
            Assert.AreEqual(@"C:\origin.txt", p.GetNodePath("origin"));
        }
    }
}
