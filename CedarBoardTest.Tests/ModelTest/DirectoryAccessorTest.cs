using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class DirectoryAccessorTest
    {
        [TestMethod]
        public void ディレクトリの削除ができる()
        {
            Directory.CreateDirectory(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete");
            DirectoryAccessor accessor = new();
            accessor.Delete(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete");
            Assert.AreEqual(false, Directory.Exists(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete"));
        }

        //[TestMethod]
        //public void ディレクトリの削除ができる_標準関数()
        //{
        //    Directory.CreateDirectory(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\a6");
        //    Directory.Delete(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete",true);
        //    Assert.AreEqual(false, Directory.Exists(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\a5"));
        //}

        [TestMethod]
        public void ディレクトリの作成ができる()
        {
            DirectoryAccessor accessor = new();
            accessor.Create(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\create");
            Assert.AreEqual(true, Directory.Exists(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\create"));
        }
    }
}
