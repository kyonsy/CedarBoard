using CedarBoard.Model.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class TextFileAcceserTest
    {
        [TestMethod]
        public void ファイルの読み込みができる()
        {
            TextFileAccessor accessor = new();
            File.WriteAllText(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\readme.txt", "hello world!");
            string readme = accessor.GetData(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\readme.txt");
            Assert.AreEqual("hello world!",readme);
            File.Delete(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\readme.txt");
        }

        [TestMethod]
        public void ファイルの書き出しができる()
        {
            TextFileAccessor accessor = new();
            using (File.Create(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\writeme.txt")) { };
            accessor.SetData(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\writeme.txt", "kkkkkkk");
            Assert.AreEqual("kkkkkkk",File.ReadAllText(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\writeme.txt"));
            File.Delete(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\writeme.txt");
        }

        [TestMethod]
        public void ファイルの生成ができる()
        {
            TextFileAccessor accessor = new();
            accessor.Create(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\createme.txt", "kkkkkkk");
            Assert.AreEqual(true,File.Exists(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\createme.txt"));
            File.Delete(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\createme.txt");
        }

        [TestMethod]
        public void ファイル名の変更ができる()
        {
            TextFileAccessor accessor= new();
            using (File.Create(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\change.txt")) { };
            accessor.Rename(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\change.txt", @"C:\ワークスペース\ガリレオコンテスト\work\TextFile\changed.txt");
            Assert.AreEqual(true, File.Exists(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\changed.txt"));
            Assert.AreEqual(false, File.Exists(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\change.txt"));
            File.Delete(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\changed.txt");
        }

        [TestMethod]
        public void ファイルの削除ができる()
        {
            TextFileAccessor accessor = new();
            using (File.Create(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete.txt")) { };
            accessor.Delete(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete.txt");
            Assert.AreEqual(false, File.Exists(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\delete.txt"));
        }

        [TestMethod]
        public void ファイルのコピーができる()
        {
            TextFileAccessor accessor = new();

            File.WriteAllText(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\copy.txt", "thank you");
            accessor.Copy(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\copy.txt", @"C:\ワークスペース\ガリレオコンテスト\work\TextFile\copied.txt");
            Assert.AreEqual("thank you", File.ReadAllText(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\copied.txt"));
            File.Delete(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\copy.txt");
            File.Delete(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\copied.txt");
        }

        [TestMethod]
        public void 最初に生成されるファイルは空文字でできているのか()
        {
            using (File.Create(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\kara.txt")) { };
            string aa = File.ReadAllText(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\kara.txt");
            Assert.AreEqual(aa, File.ReadAllText(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\kara.txt"));
            File.Delete(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\kara.txt");
        }
    }
}
