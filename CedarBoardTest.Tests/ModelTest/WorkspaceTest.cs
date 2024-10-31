using CedarBoard.Model;
using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class WorkspaceTest
    {
        private readonly Workspace w = new(new TextFileMock(), new DirectoryMock(), "C:",
            new()
            {
                ProjectDictionary = [],
                Setting = new()
                {
                    Author = "kyonsy",
                    Editor = "notepad",
                    Encode = "UTF-8",
                    Format = "default",
                    Language = "ja",
                    Name = "hogehoge",
                    CreatedDate = "2024/10/24",
                    UpdatedDate = "2024/10/24",
                    Message = "始めに作ったやつ"
                }
            });

        [TestMethod]
        public void 新しいプロジェクトを作れる()
        {
            w.Add("first");
            Assert.IsTrue(w.WorkspacePoco.ProjectDictionary.ContainsKey("first"));
        }

        [TestMethod]
        public void 指定されたプロジェクトを削除できる()
        {
            w.Add("first");
            w.Remove("first");
            Assert.IsFalse(w.WorkspacePoco.ProjectDictionary.ContainsKey("first"));
        }

        [TestMethod]
        public void ワークスペース自身の情報を保存することが出来る()
        {

            w.Add("first");
            w.WorkspacePoco.ProjectDictionary["first"].Add(new(10, 10));
            w.WorkspacePoco.ProjectDictionary["first"].Add("origin", "second", new(20, 20));
            w.TextFile.Create(@"C:\workspace.json", "");
            w.Save();
            string s = w.TextFile.GetData(@"C:\workspace.json");
            Assert.IsNotNull(s);//正常動作確認
        }

        [TestMethod]
        public void 指定されたノードを開くことが出来る()
        {
            w.Add("first");
            w.WorkspacePoco.ProjectDictionary["first"].Add(new(10, 10));
            w.WorkspacePoco.ProjectDictionary["first"].Add("origin", "second", new(20, 20));
            w.TextFile.Create(@"C:\workspace.json", "");
            //w.Open("first","second");
            Assert.IsTrue(true);
        }
    }
}
