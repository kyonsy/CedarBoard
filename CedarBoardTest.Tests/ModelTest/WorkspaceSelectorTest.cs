// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model;
using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class WorkspaceSelectorTest
    {
        [TestMethod]
        public void �V�������[�N�X�y�[�X��ǉ��ł���()
        {
            WorkspaceSelector sel = new(new TextFileMock(), new DirectoryMock()) { SelectorPoco = new() { PathDictionary = [] } };
            sel.Add(new()
            {
                Author = "kyonsy",
                Editor = "notepad",
                Encode = "UTF-8",
                Format = "default",
                Language = "ja",
                Name = "hogehoge",
                CreatedDate = "2024/10/24",
                UpdatedDate = "2024/10/24",
                Message = "�n�߂ɍ�������"
            }, "C:");
            Assert.AreEqual(true, sel.Directory.Exists("C:"));
        }

        [TestMethod]
        public void �w�肳�ꂽ���[�N�X�y�[�X���폜�ł���()
        {
            WorkspaceSelector sel = new(new TextFileMock(), new DirectoryMock()) { SelectorPoco = new() { PathDictionary = [] } };
            sel.Add(new()
            {
                Author = "kyonsy",
                Editor = "notepad",
                Encode = "UTF-8",
                Format = "default",
                Language = "ja",
                Name = "hogehoge",
                CreatedDate = "2024/10/24",
                UpdatedDate = "2024/10/24",
                Message = "�n�߂ɍ�������"
            }, "C:");
            sel.Remove("hogehoge");
            Assert.AreEqual(false, sel.Directory.Exists("C:"));
        }

        [TestMethod]
        public void �w�肳�ꂽ���[�N�X�y�[�X��Ԃ����Ƃ��o����()
        {
            WorkspaceSelector sel = new(new TextFileMock(), new DirectoryMock())
            {
                SelectorPoco = new() { PathDictionary = [] }
            };
            sel.Add(new()
            {
                Author = "kyonsy",
                Editor = "notepad",
                Encode = "UTF-8",
                Format = "default",
                Language = "ja",
                Name = "hogehoge",
                CreatedDate = "2024/10/24",
                UpdatedDate = "2024/10/24",
                Message = "�n�߂ɍ�������"
            }, "C:");
            Workspace w = sel.GetWorkSpace("hogehoge");
            Assert.IsNotNull(w);
        }

        [TestMethod]
        public void �Z���N�^���g�̏���ۑ��ł���()
        {
            WorkspaceSelector sel = new(new TextFileMock(), new DirectoryMock()) { SelectorPoco = new() { PathDictionary = [] } };
            sel.Add(new()
            {
                Author = "kyonsy",
                Editor = "notepad",
                Encode = "UTF-8",
                Format = "default",
                Language = "ja",
                Name = "hogehoge",
                CreatedDate = "2024/10/24",
                UpdatedDate = "2024/10/24",
                Message = "�n�߂ɍ�������"
            }, "C:");
            sel.Save();
        }
    }
}

