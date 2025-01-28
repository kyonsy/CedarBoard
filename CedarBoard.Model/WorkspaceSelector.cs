// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using System.Runtime.CompilerServices;
using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Text.Json;
using System.Text.Json.Serialization;
[assembly:InternalsVisibleTo("CedarBoardTest.Tests")]
namespace CedarBoard.Model
{
    /// <summary>
    /// ���[�N�X�y�[�X��I�Ԃ��߂̂��́B�A�v���P�[�V�����̋N���Ɠ����ɃC���X�^���X�������
    /// </summary>
    public sealed class WorkspaceSelector : JsonFileBase
    {
        /// <summary>
        /// setting.json�ɕR�t����ꂽPOCO
        /// </summary>
        [JsonInclude]
        public SelectorPoco SelectorPoco { get; set; }

        /// <summary>
        /// �t�@�C������p�I�u�W�F�N�g
        /// </summary>
        [JsonIgnore]
        internal ITextFile TextFile { get; }

        /// <summary>
        /// �f�B���N�g������p�I�u�W�F�N�g
        /// </summary>
        [JsonIgnore]
        internal IDirectory Directory { get; }

        /// <summary>
        /// setting.json������p�X
        /// </summary>
        private string SettingPath { get; } = @$"{AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\')}\setting.json";

        /// <summary>
        /// �Z���N�^�̃R���X�g���N�^
        /// </summary>
        /// <param name="textFile">�e�X�g�p�Ɩ{�ԗp�Ŏg��������B�t�@�C������p�̃I�u�W�F�N�g</param>
        /// <param name="directory">�e�X�g�p�Ɩ{�ԗp�Ŏg��������B�f�B���N�g������̂��߂̃I�u�W�F�N�g</param>
        public WorkspaceSelector(ITextFile textFile, IDirectory directory)
        {
            TextFile = textFile;
            Directory = directory;
            SelectorPoco = GetSelectorPoco();   
        }

        /// <summary>
        /// �V�������[�N�X�y�[�X��ǉ�����B������Workspace���C���X�^���X�������킯�ł͂Ȃ��_�ɒ���
        /// </summary>
        /// <param name="setting">�V�������[�N�X�y�[�X�̐ݒ�</param>
        /// <param name="path">���[�N�X�y�[�X�̃p�X</param>
        /// <returns>�V�������[�N�X�y�[�X</returns>
        public void Add(Setting setting,string path)
        {
            Directory.Create(path);
            WorkspacePoco wPoco = new() { Setting = setting,ProjectDictionary = [] };
            TextFile.Create(@$"{path}\workspace.json",Serialize(wPoco));
            SelectorPoco.PathDictionary.Add(setting.Name, path);
            Workspace workspace = GetWorkSpace(setting.Name);
            workspace.Add("MainProject");
            workspace.Save();
        }

        /// <summary>
        /// �w�肳�ꂽ���[�N�X�y�[�X���폜����
        /// </summary>
        /// <param name="workspace">�폜���������[�N�X�y�[�X�̖��O</param>
        public void Remove(string workspace)
        {
            Directory.Delete(SelectorPoco.PathDictionary[workspace]);
            SelectorPoco.PathDictionary.Remove(workspace);
        }

        /// <summary>
        /// �w�肵�����[�N�X�y�[�X�̖��O��ς���
        /// </summary>
        /// <param name="workspaceName">���̖��O</param>
        /// <param name="newWorkspaceName">�V�������O</param>
        public void Rename(string workspaceName,string newWorkspaceName)
        {
            Workspace workspace = GetWorkSpace(workspaceName);
            workspace.WorkspacePoco.Setting.Name = newWorkspaceName;
            workspace.Save();
            SelectorPoco.PathDictionary.Add(newWorkspaceName,SelectorPoco.PathDictionary[workspaceName]);
            SelectorPoco.PathDictionary.Remove(workspaceName);
            
        }


        /// <summary>
        /// �w�肳�ꂽ���O�̃��[�N�X�y�[�X��Ԃ�
        /// </summary>
        /// <param name="workspace">�~�������[�N�X�y�[�X�̖��O</param>
        /// <returns>�w�肵�����[�N�X�y�[�X</returns>
        public Workspace GetWorkSpace(string workspace)
        {
            string path = SelectorPoco.PathDictionary[workspace];
            return new Workspace(TextFile, Directory, path);
        }

        /// <summary>
        /// �Z���N�^�̏���ۑ�����
        /// </summary>
        public override void Save()
        {
            // string s = Serialize(this); // �f�o�b�N�p�ɍ�����ϐ�
            TextFile.SetData(SettingPath, Serialize(SelectorPoco));
        }

        /// <summary>
        /// �Z���N�^������ĕԂ�
        /// </summary>
        /// <param name="json">Json������</param>
        /// <returns>�f�V���A���C�Y���ꂽPoco</returns>
        /// <exception cref="FormatException"></exception>
        protected override SelectorPoco Deserialize(string json) {
            SelectorPoco sel = JsonSerializer.Deserialize<SelectorPoco>(json, GetOptions()) ??
                throw new FormatException("Json������Ƃ��ĔF���ł��܂���");
            return sel;
        }

        /// <summary>
        /// �f�V���A���C�Y���s��SelectorPoco��Ԃ�
        /// </summary>
        /// <returns>�f�V���A���C�Y���ꂽPoco</returns>
        private SelectorPoco GetSelectorPoco() {
            if (TextFile.Exists(SettingPath))
            {
                return Deserialize(TextFile.GetData(SettingPath));
            }
            else
            {
                SelectorPoco poco = new() { PathDictionary = [] };
                TextFile.Create(SettingPath, Serialize(poco));
                return poco;
            }
        }
}
}

