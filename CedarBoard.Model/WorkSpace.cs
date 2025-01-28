// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;

[assembly: InternalsVisibleTo("CedarBoardTest.Tests")]
namespace CedarBoard.Model
{
    /// <summary>
    /// ���[�N�X�y�[�X
    /// </summary>

    public sealed class Workspace : JsonFileBase
    {
        /// <summary>
        /// workspace.json�ɕR�t����ꂽPOCO
        /// </summary>
        public WorkspacePoco WorkspacePoco { get; }

        /// <summary>
        /// �t�@�C������p�I�u�W�F�N�g
        /// </summary>
        internal ITextFile TextFile { get; }

        /// <summary>
        /// �f�B���N�g������p�I�u�W�F�N�g
        /// </summary>
        internal IDirectory Directory { get; }


        /// <summary>
        /// ���[�N�X�y�[�X�̃p�X
        /// </summary>
        private string Path { get; }

        /// <summary>
        /// ���[�N�X�y�[�X�̃R���X�g���N�^
        /// </summary>
        /// <param name="textFile">�e�X�g�p�Ɩ{�ԗp�Ŏg��������B�t�@�C������̂��߂̃I�u�W�F�N�g</param>
        /// <param name="directory">�e�X�g�p�Ɩ{�ԗp�Ŏg��������B�f�B���N�g������̂��߂̃I�u�W�F�N�g</param>
        /// <param name="path">���[�N�X�y�[�X�̃p�X</param>
        public Workspace(ITextFile textFile, IDirectory directory, string path)
        {
            TextFile = textFile;
            Directory = directory;
            Path = path;
            WorkspacePoco = Deserialize(TextFile.GetData($@"{Path}\workspace.json"));
        }

        /// <summary>
        /// ���[�N�X�y�[�X�̃R���X�g���N�^�B�f�o�b�O�p
        /// </summary>
        /// <param name="textFile">�e�X�g�p�Ɩ{�ԗp�Ŏg��������B�t�@�C������̂��߂̃I�u�W�F�N�g</param>
        /// <param name="directory">�e�X�g�p�Ɩ{�ԗp�Ŏg��������B�f�B���N�g������̂��߂̃I�u�W�F�N�g</param>
        /// <param name="path">���[�N�X�y�[�X�̃p�X</param>
        /// <param name="workspacePoco">���[�N�X�y�[�X��Poco</param>
        public Workspace(ITextFile textFile, IDirectory directory, string path, WorkspacePoco workspacePoco)
        {
            TextFile = textFile;
            Directory = directory;
            Path = path;
            WorkspacePoco = workspacePoco;
        }

        /// <summary>
        /// �v���W�F�N�g����ύX����
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="newProjectName"></param>
        public void Rename(string projectName, string newProjectName)
        {
            Project project = WorkspacePoco.ProjectDictionary[projectName];
            WorkspacePoco.ProjectDictionary[newProjectName] = project;
            WorkspacePoco.ProjectDictionary.Remove(projectName);
        }

        /// <summary>
        /// �V�����v���W�F�N�g��ǉ�����
        /// </summary>
        /// <param name="projectName">�v���W�F�N�g�̖��O</param>
        public void Add(string projectName)
        {
            string newPath = @$"{Path}\{projectName}";
            Directory.Create(newPath);
            WorkspacePoco.ProjectDictionary.Add(projectName, new(TextFile, newPath));
        }

        /// <summary>
        /// �w�肳�ꂽ�v���W�F�N�g���폜����
        /// </summary>
        /// <param name="projectName">�폜�������v���W�F�N�g�̖��O</param>
        public void Remove(string projectName)
        {
            Directory.Delete(@$"{Path}\{projectName}");
            WorkspacePoco.ProjectDictionary.Remove(projectName);
        }

        /// <summary>
        /// �w�肵���m�[�h(�ɕR�}����ꂽ�e�L�X�g)���J��
        /// </summary>
        /// <param name="projectName">�v���W�F�N�g�̖��O</param>
        /// <param name="nodeName">�w�肵���m�[�h�̖��O</param>
        public void Open(string projectName, string nodeName)
        {
            ProcessStartInfo psi = new()
            {
                FileName = WorkspacePoco.Setting.Editor,
                Arguments = WorkspacePoco.ProjectDictionary[projectName].GetNodePath(nodeName),
                CreateNoWindow = true,
                UseShellExecute = false,
            };
            using (Process.Start(psi)) { };
        }

        /// <summary>
        /// ���[�N�X�y�[�X�̏�Ԃ�ۑ�����
        /// </summary>
        public override void Save()
        {
            TextFile.SetData(@$"{Path}\workspace.json", Serialize(WorkspacePoco));
        }

        /// <summary>
        /// ���[�N�X�y�[�X�̃f�[�^���f�V���A���C�Y����
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Worlspace��Poco</returns>
        /// <exception cref="FormatException">Json�������F���ł��Ȃ�</exception>
        protected override WorkspacePoco Deserialize(string json)
        {
            WorkspacePoco sel = JsonSerializer.Deserialize<WorkspacePoco>(json, GetOptions()) ??
                throw new FormatException("Json������Ƃ��ĔF���ł��܂���");
            foreach (var keyValuePair in sel.ProjectDictionary)
            {
                keyValuePair.Value.TextFile = TextFile;
            }
            return sel;
        }
    }
}

