// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class TextFileMockTest
    {
        [TestMethod]
        public void �t�@�C���̓ǂݍ��݂��ł���()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:\a.txt", new("Success!"));
            Assert.AreEqual("Success!", mock.GetData(@"C:\a.txt"));
        }


        [TestMethod]
        public void �t�@�C���̏����o�����ł���()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:\a.txt", new("Success!"));
            mock.SetData(@"C:\a.txt", "Success!");
            Assert.AreEqual("Success!", mock.FileDictionary[@"C:\a.txt"].Value);
        }

        [TestMethod]
        public void �t�@�C���̏����o�����ł���_�G���[()
        {
            TextFileMock mock = new();
            var exception = Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                mock.SetData(@"C:\a.txt", "Failure!");
            });
            Assert.IsNotNull(exception);
        }


        [TestMethod]
        public void �t�@�C���̐������ł���()
        {
            TextFileMock mock = new();
            mock.Create(@"C:\a.txt", "Success!");
            Assert.AreEqual("Success!", mock.FileDictionary[@"C:\a.txt"].Value);
        }

        [TestMethod]
        public void �t�@�C���̐������ł���_�G���[()
        {
            TextFileMock mock = new();
            mock.Create(@"C:\a.txt", "Success!");
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                mock.Create(@"C:\a.txt", "Failure!");
            });
            Assert.IsNotNull(exception);
        }


        [TestMethod]
        public void �t�@�C�����̕ύX���ł���()
        {
            TextFileMock mock = new();
            mock.Create(@"C:\a.txt", "Success!");
            mock.Rename(@"C:\a.txt", @"C:\b.txt");
            Assert.AreEqual("Success!", mock.FileDictionary[@"C:\b.txt"].Value);
        }

        [TestMethod]
        public void �t�@�C�����̕ύX���ł���_�O�̂�������Ă��邩()
        {
            TextFileMock mock = new();
            mock.Create(@"C:\a.txt", "Failure!");
            mock.Rename(@"C:\a.txt", @"C:\b.txt");
            var exception = Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                string v = mock.FileDictionary[@"C:\a.txt"].Value;
            });
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void �t�@�C���̍폜���ł���()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:", new("Success!"));
            mock.Delete(@"C:");
            Assert.AreEqual(false, mock.FileDictionary.ContainsKey(@"C:"));
        }

        [TestMethod]
        public void �t�@�C���̃R�s�[���ł���()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:\a.txt", new("Success!"));
            mock.Copy(@"C:\a.txt", @"C:\b.txt");
            Assert.AreEqual("Success!", mock.FileDictionary[@"C:\b.txt"].Value);
        }

        [TestMethod]
        public void �t�@�C����ǂݎ���p�ɂł���()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:\a.txt", new("Success!"));
            mock.SetReadOnly(@"C:\a.txt");
            Assert.IsTrue(mock.FileDictionary[@"C:\a.txt"].ReadOnly);
        }

        [TestMethod]
        public void �t�@�C������ǂݎ���p�������폜����()
        {
            TextFileMock mock = new();
            mock.FileDictionary.Add(@"C:\a.txt", new("Success!"));
            mock.SetReadOnly(@"C:\a.txt");
            mock.DeleteReadOnly(@"C:\a.txt");
            Assert.IsFalse(mock.FileDictionary[@"C:\a.txt"].ReadOnly);
        }
    }
}

