// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
using CedarBoard.Model;
using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class WorkspaceSelectorTest
    {
        [TestMethod]
        public void 新しいワークスペースを追加できる()
        {
            WorkspaceSelector sel = new(new TextFileMock(), new DirectoryMock()) { SelectorPoco = new() { PathDictionary = [] } };
            sel.Add(new()
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
            }, "C:");
            Assert.AreEqual(true, sel.Directory.Exists("C:"));
        }

        [TestMethod]
        public void 指定されたワークスペースを削除できる()
        {
            WorkspaceSelector sel = new(new TextFileMock(), new DirectoryMock()) { SelectorPoco = new() { PathDictionary = [] } };
            sel.Add(new()
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
            }, "C:");
            sel.Remove("hogehoge");
            Assert.AreEqual(false, sel.Directory.Exists("C:"));
        }

        [TestMethod]
        public void 指定されたワークスペースを返すことが出来る()
        {
            WorkspaceSelector sel = new(new TextFileMock(), new DirectoryMock())
            {
                SelectorPoco = new() { PathDictionary = [] }
            };
            sel.Add(new()
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
            }, "C:");
            Workspace w = sel.GetWorkSpace("hogehoge");
            Assert.IsNotNull(w);
        }

        [TestMethod]
        public void セレクタ自身の情報を保存できる()
        {
            WorkspaceSelector sel = new(new TextFileMock(), new DirectoryMock()) { SelectorPoco = new() { PathDictionary = [] } };
            sel.Add(new()
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
            }, "C:");
            sel.Save();
        }
    }
}

