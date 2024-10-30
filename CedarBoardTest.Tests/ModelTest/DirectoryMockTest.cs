using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class DirectoryMockTest
    {
        [TestMethod]
        public void ディレクトリの作成ができる()
        {
            DirectoryMock mock = new();
            mock.Create(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete");
            Assert.AreEqual(false, mock.DirectoryDictionary[@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete"].Compressed);
        }

        [TestMethod]
        public void ディレクトリの削除ができる()
        {
            DirectoryMock mock = new();
            mock.DirectoryDictionary.Add(@"C:\delete", new());
            mock.Delete(@"C:\delete");
            var exception = Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                bool b = mock.DirectoryDictionary[@"C:\delete"].Compressed;
            });

            Assert.IsNotNull(exception);
        }
    }
}
