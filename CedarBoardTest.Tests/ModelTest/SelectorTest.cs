using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CedarBoard.Model;
using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class SelectorTest
    {
        private Selector sel = new(new TextFileMock(), new DirectoryMock());
        [TestMethod]
        public void 新しいワークスペースを追加できる()
        {

        }

        [TestMethod]
        public void 指定されたワークスペースを削除できる()
        {

        }

        [TestMethod]
        public void 指定されたワークスペースを返すことが出来る()
        {

        }

        [TestMethod]
        public void セレクタ自身の情報を保存できる()
        {

        }
    }
}
