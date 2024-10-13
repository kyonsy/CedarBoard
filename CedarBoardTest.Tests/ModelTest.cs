using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace CedarBoardTest.Tests
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void ファイル操作って同期処理なのか()
        {
            StringBuilder sb = new();
            for(int i = 0; i < 100000; i++)
            {
                sb.Append(i);
                sb.Append("qwertyuioplkjhgfdsazxcvbnm\n");
            }
            File.WriteAllText(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\aaa.txt", sb.ToString());
            
            string aaa = File.ReadAllText(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\aaa.txt");
            Console.WriteLine(aaa);
            Assert.AreEqual(aaa, sb.ToString());
        }


        [TestMethod]
        public void ディレクトリの作成って同期処理なのか()
        {
            Directory.CreateDirectory(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\aaaa");
            File.WriteAllText(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\aaaa\aaa.txt", "aa");
            Assert.AreEqual(true, File.Exists(@"C:\ワークスペース\ガリレオコンテスト\work\TextFile\aaaa\aaa.txt"));
        }
    }
}
