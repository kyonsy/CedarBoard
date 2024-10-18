using CedarBoard.Model.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class DirectoryMockTest
    {
        [TestMethod]
        public void ディレクトリの削除ができる()
        {
            DirectoryMock directoryMock = new();
            directoryMock.DirectorySet.Add(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete");
            directoryMock.Delete(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete");
            Assert.AreEqual(false, directoryMock.DirectorySet.Contains(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete"));
        }

        [TestMethod]
        public void ディレクトリの作成ができる()
        {
            DirectoryMock directoryMock = new();
            directoryMock.Create(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete");
            Assert.AreEqual(true, directoryMock.DirectorySet.Contains(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete"));
        }
    }
}
