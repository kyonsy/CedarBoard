// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
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
        public void �t�@�C���̓ǂݍ��݂��ł���()
        {
            TextFileAccessor accessor = new();
            File.WriteAllText(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\readme.txt", "hello world!");
            string readme = accessor.GetData(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\readme.txt");
            Assert.AreEqual("hello world!",readme);
            File.Delete(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\readme.txt");
        }

        [TestMethod]
        public void �t�@�C���̏����o�����ł���()
        {
            TextFileAccessor accessor = new();
            using (File.Create(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\writeme.txt")) { };
            accessor.SetData(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\writeme.txt", "kkkkkkk");
            Assert.AreEqual("kkkkkkk",File.ReadAllText(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\writeme.txt"));
            File.Delete(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\writeme.txt");
        }

        [TestMethod]
        public void �t�@�C���̐������ł���()
        {
            TextFileAccessor accessor = new();
            accessor.Create(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\createme.txt", "kkkkkkk");
            Assert.AreEqual(true,File.Exists(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\createme.txt"));
            File.Delete(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\createme.txt");
        }

        [TestMethod]
        public void �t�@�C�����̕ύX���ł���()
        {
            TextFileAccessor accessor= new();
            using (File.Create(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\change.txt")) { };
            accessor.Rename(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\change.txt", @"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\changed.txt");
            Assert.AreEqual(true, File.Exists(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\changed.txt"));
            Assert.AreEqual(false, File.Exists(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\change.txt"));
            File.Delete(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\changed.txt");
        }

        [TestMethod]
        public void �t�@�C���̍폜���ł���()
        {
            TextFileAccessor accessor = new();
            using (File.Create(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\delete.txt")) { };
            accessor.Delete(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\delete.txt");
            Assert.AreEqual(false, File.Exists(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\delete.txt"));
        }

        [TestMethod]
        public void �t�@�C���̃R�s�[���ł���()
        {
            TextFileAccessor accessor = new();

            File.WriteAllText(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\copy.txt", "thank you");
            accessor.Copy(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\copy.txt", @"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\copied.txt");
            Assert.AreEqual("thank you", File.ReadAllText(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\copied.txt"));
            File.Delete(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\copy.txt");
            File.Delete(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\copied.txt");
        }

        [TestMethod]
        public void �ŏ��ɐ��������t�@�C���͋󕶎��łł��Ă���̂�()
        {
            using (File.Create(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\kara.txt")) { };
            string aa = File.ReadAllText(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\kara.txt");
            Assert.AreEqual(aa, File.ReadAllText(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\kara.txt"));
            File.Delete(@"C:\���[�N�X�y�[�X\�K�����I�R���e�X�g\work\TextFile\kara.txt");
        }
    }
}

