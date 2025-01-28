// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class DirectoryAccessorTest
    {
        [TestMethod]
        public void �f�B���N�g���̍폜���ł���()
        {
            Directory.CreateDirectory(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\delete");
            DirectoryAccessor accessor = new();
            accessor.Delete(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\delete");
            Assert.AreEqual(false, Directory.Exists(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\delete"));
        }

        //[TestMethod]
        //public void �f�B���N�g���̍폜���ł���_�W���֐�()
        //{
        //    Directory.CreateDirectory(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\a6");
        //    Directory.Delete(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\delete",true);
        //    Assert.AreEqual(false, Directory.Exists(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\a5"));
        //}

        [TestMethod]
        public void �f�B���N�g���̍쐬���ł���()
        {
            DirectoryAccessor accessor = new();
            accessor.Create(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\create");
            Assert.AreEqual(true, Directory.Exists(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\create"));
        }
    }
}

