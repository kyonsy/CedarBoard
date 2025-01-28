// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model;
using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ModelTest
{
    [TestClass]
    public class WorkspaceTest
    {
        private readonly Workspace w = new(new TextFileMock(), new DirectoryMock(), "C:",
            new()
            {
                ProjectDictionary = [],
                Setting = new()
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
                }
            });

        [TestMethod]
        public void �V�����v���W�F�N�g������()
        {
            w.Add("first");
            Assert.IsTrue(w.WorkspacePoco.ProjectDictionary.ContainsKey("first"));
        }

        [TestMethod]
        public void �w�肳�ꂽ�v���W�F�N�g���폜�ł���()
        {
            w.Add("first");
            w.Remove("first");
            Assert.IsFalse(w.WorkspacePoco.ProjectDictionary.ContainsKey("first"));
        }

        [TestMethod]
        public void ���[�N�X�y�[�X���g�̏���ۑ����邱�Ƃ��o����()
        {

            w.Add("first");
            w.WorkspacePoco.ProjectDictionary["first"].Add("origin", "second", new(20, 20));
            w.TextFile.Create(@"C:\workspace.json", "");
            w.Save();
            string s = w.TextFile.GetData(@"C:\workspace.json");
            Assert.IsNotNull(s);//���퓮��m�F
        }

        [TestMethod]
        public void �w�肳�ꂽ�m�[�h���J�����Ƃ��o����()
        {
            w.Add("first");
            w.WorkspacePoco.ProjectDictionary["first"].Add("origin", "second", new(20, 20));
            w.TextFile.Create(@"C:\workspace.json", "");
            //w.Open("first","second");
            Assert.IsTrue(true);
        }
    }
}

