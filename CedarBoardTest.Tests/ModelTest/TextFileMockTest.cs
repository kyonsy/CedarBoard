// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class TextFileMockTest
    {
        [TestMethod]
        public void ファイルの読み込みができる()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:\a.txt", new("Success!"));
            Assert.AreEqual("Success!", mock.GetData(@"C:\a.txt"));
        }


        [TestMethod]
        public void ファイルの書き出しができる()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:\a.txt", new("Success!"));
            mock.SetData(@"C:\a.txt", "Success!");
            Assert.AreEqual("Success!", mock.FileDictionary[@"C:\a.txt"].Value);
        }

        [TestMethod]
        public void ファイルの書き出しができる_エラー()
        {
            TextFileMock mock = new();
            var exception = Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                mock.SetData(@"C:\a.txt", "Failure!");
            });
            Assert.IsNotNull(exception);
        }


        [TestMethod]
        public void ファイルの生成ができる()
        {
            TextFileMock mock = new();
            mock.Create(@"C:\a.txt", "Success!");
            Assert.AreEqual("Success!", mock.FileDictionary[@"C:\a.txt"].Value);
        }

        [TestMethod]
        public void ファイルの生成ができる_エラー()
        {
            TextFileMock mock = new();
            mock.Create(@"C:\a.txt", "Success!");
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                mock.Create(@"C:\a.txt", "Failure!");
            });
            Assert.IsNotNull(exception);
        }


        [TestMethod]
        public void ファイル名の変更ができる()
        {
            TextFileMock mock = new();
            mock.Create(@"C:\a.txt", "Success!");
            mock.Rename(@"C:\a.txt", @"C:\b.txt");
            Assert.AreEqual("Success!", mock.FileDictionary[@"C:\b.txt"].Value);
        }

        [TestMethod]
        public void ファイル名の変更ができる_前のが消されているか()
        {
            TextFileMock mock = new();
            mock.Create(@"C:\a.txt", "Failure!");
            mock.Rename(@"C:\a.txt", @"C:\b.txt");
            var exception = Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                string v = mock.FileDictionary[@"C:\a.txt"].Value;
            });
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void ファイルの削除ができる()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:", new("Success!"));
            mock.Delete(@"C:");
            Assert.AreEqual(false, mock.FileDictionary.ContainsKey(@"C:"));
        }

        [TestMethod]
        public void ファイルのコピーができる()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:\a.txt", new("Success!"));
            mock.Copy(@"C:\a.txt", @"C:\b.txt");
            Assert.AreEqual("Success!", mock.FileDictionary[@"C:\b.txt"].Value);
        }

        [TestMethod]
        public void ファイルを読み取り専用にできる()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:\a.txt", new("Success!"));
            mock.SetReadOnly(@"C:\a.txt");
            Assert.IsTrue(mock.FileDictionary[@"C:\a.txt"].ReadOnly);
        }

        [TestMethod]
        public void ファイルから読み取り専用属性を削除する()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:\a.txt", new("Success!"));
            mock.SetReadOnly(@"C:\a.txt");
            mock.DeleteReadOnly(@"C:\a.txt");
            Assert.IsFalse(mock.FileDictionary[@"C:\a.txt"].ReadOnly);
        }
    }
}

