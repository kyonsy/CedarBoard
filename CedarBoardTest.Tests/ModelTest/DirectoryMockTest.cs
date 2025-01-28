// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class DirectoryMockTest
    {
        [TestMethod]
        public void �f�B���N�g���̍쐬���ł���()
        {
            DirectoryMock mock = new();
            mock.Create(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\delete");
            Assert.AreEqual(false, mock.DirectoryDictionary[@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\delete"].Compressed);
        }

        [TestMethod]
        public void �f�B���N�g���̍폜���ł���()
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

