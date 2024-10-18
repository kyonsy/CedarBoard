using CedarBoard.Model.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class TextFileMockTest
    {
        [TestMethod]
        public void ファイルの読み込みができる()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:", "qwertyuiop");
            Assert.AreEqual("qwertyuiop", mock.GetData(@"C:"));
        }

        [TestMethod]
        public void ファイルの書き出しができる_エラー()
        {
            TextFileMock mock = new();
            var exception = Assert.ThrowsException<IOException>(() =>
            {
                mock.SetData("C:/aa.txt", "aaa");
            });
            Assert.AreEqual("指定したファイルは存在しません", exception.Message);
        }

        [TestMethod]
        public void ファイルの書き出しができる()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:/aa.txt", "");
            mock.SetData(@"C:/aa.txt", "aaa");
            Assert.AreEqual("aaa", mock.FileDictionary[@"C:/aa.txt"]);
        }

        [TestMethod]
        public void ファイルの生成ができる_エラー()
        {
            TextFileMock mock = new();
            mock.Create("C:/aa.txt", "aaa");
            var exception = Assert.ThrowsException<IOException>(() =>
            {
                mock.Create("C:/aa.txt", "aaa");
            });
            Assert.AreEqual("指定したファイルは既に存在しています", exception.Message);
        }

        [TestMethod]
        public void ファイルの生成ができる()
        {
            TextFileMock mock = new();
            mock.Create(@"C:/aa.txt", "aaa");
            Assert.AreEqual("aaa", mock.FileDictionary[@"C:/aa.txt"]);
        }

        [TestMethod]
        public void ファイル名の変更ができる()
        {
            TextFileMock mock = new();
            mock.Create(@"C:/aa.txt", "aaa");
            mock.Rename(@"C:/aa.txt", @"C:/aaa.txt");
            Assert.AreEqual("aaa", mock.FileDictionary[@"C:/aaa.txt"]);
        }

        [TestMethod]
        public void ファイル名の変更ができる_前のが消されているか_false()
        {
            TextFileMock mock = new();
            mock.Create(@"C:/aa.txt", "aaa");
            mock.Rename(@"C:/aa.txt", @"C:/aaa.txt");
            Assert.AreEqual(false, mock.FileDictionary.ContainsKey(@"C:/aa.txt"));
        }

        [TestMethod]
        public void ファイルの削除ができる()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:", "aaa");
            mock.Delete(@"C:");
            Assert.AreEqual(false, mock.FileDictionary.ContainsKey(@"C:"));
        }

        [TestMethod]
        public void ファイルのコピーができる()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:", "aaa");
            mock.Copy(@"C:", @"C://");
            Assert.AreEqual("aaa", mock.FileDictionary[@"C://"]);
        }
    }
}
