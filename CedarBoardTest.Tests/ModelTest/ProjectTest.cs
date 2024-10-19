using CedarBoard.Model;
using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
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
            Project project = new(new TextFileMock());
            project.Path = "C:";
            NodePoco poco = new()
            {
                ChildNode = new List<int> { },
                Name = "first",
                Point = new()
                {
                    X = 10,
                    Y = 20
                }
            };

            project.Add(poco);
            Assert.AreEqual("first", project.NodeList[0].Name);
            Assert.AreEqual(10, project.NodeList[0].Point.X);
            Assert.AreEqual(20, project.NodeList[0].Point.Y);
            Assert.AreEqual(true, project.NodeList[0].ChildNode.Count == 0);
            Assert.AreEqual("", project.TextFile.GetData("C:/content/first.txt"));
        }

        [TestMethod] 
        public void 二つ目以降のメゾットで一引数だとエラーがでる()
        {
            Project project = new(new TextFileMock()) { Path = "C:" };
            NodePoco poco1 = new()
            {
                ChildNode = new List<int> { },
                Name = "first",
                Point = new()
                {
                    X = 10,
                    Y = 20
                }
            };

            NodePoco poco2 = new()
            {
                ChildNode = new List<int> { },
                Name = "second",
                Point = new()
                {
                    X = 10,
                    Y = 20
                }
            };
           
            project.Add(poco1);
            

            var exception2 = Assert.ThrowsException<ArgumentException>(() =>
            {
                project.Add(poco2);
            });
            Assert.AreEqual("2つ目のノードを追加する際はそのindexを引数に含めてください", exception2.Message);

        }


        [TestMethod]
        public void 二つ目以降の新しいノード追加できる()
        {

        }


        [TestMethod]
        public void 指定されたノードを削除できる()
        {

        }

        [TestMethod]
        public void 指定したノードの名前を変更できる()
        {

        }

        [TestMethod]
        public void プロジェクトの状態を保存できる()
        {

        }

        [TestMethod]
        public void ノードからそのパスへの変換ができる()
        {

        }
    }
}
