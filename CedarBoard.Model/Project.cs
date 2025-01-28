// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

[assembly: InternalsVisibleTo("CedarBoardTest.Tests")]
namespace CedarBoard.Model
{
    /// <summary>
    /// �v���W�F�N�g�̃f�[�^�Ƃ���ɑ΂��鑀��
    /// </summary>
    public sealed class Project
    {
        /// <summary>
        /// �m�[�h�̃f�B�N�V���i��
        /// </summary>
        [JsonInclude]
        public Dictionary<string, INode> NodeDictionary { get; } = [];


        /// <summary>
        /// �v���W�F�N�g�̃p�X
        /// </summary>
        [JsonInclude]
        internal string Path { get; }

        /// <summary>
        /// �t�@�C������I�u�W�F�N�g
        /// </summary>
        [JsonIgnore]
        internal ITextFile? TextFile { get; set; } = new TextFileMock();

        /// <summary>
        /// Json����f�V���A���C�Y����Ƃ��Ɏg����f�t�H���g�R���X�g���N�^
        /// </summary>
        [JsonConstructor]
        public Project(string path, Dictionary<string, INode> nodeDictionary)
        {
            // �e�X�g�p
            Path = path;
            NodeDictionary = nodeDictionary;
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="textFile">�e�L�X�g�t�@�C���̃C���^�t�F�[�X</param>
        /// <param name="path">�v���W�F�N�g�̃p�X</param>
        public Project(ITextFile textFile, string path)
        {
            TextFile = textFile;
            Path = path;
            Add(new(100.0, 100.0));
        }

        /// <summary>
        /// �V�����m�[�h��ǉ�����(2�ڈȍ~)
        /// </summary>
        /// <param name="nodeName">�ǉ�����m�[�h</param>
        /// <param name="parentNodeName">�e�m�[�h�̖��O</param>
        /// <param name="point">�m�[�h�̍��W</param>
        /// <exception cref="ArgumentException">�n�߂̃m�[�h�̒ǉ��Ɏg���Ȃ�����</exception>
        public void Add(string nodeName, string parentNodeName, Point point)
        {
            if (NodeDictionary.Count == 0)
                throw new ArgumentException("�n�߂̃m�[�h��ǉ�����Ƃ���Add(int x,int y)���g���Ă�������");
            INode node = new Node()
            {
                ChildNode = [],
                ParentNode = parentNodeName,
                Path = @$"{Path}\{nodeName}.txt",
                Point = point,
                Message = "",
                Data = DateTime.Now,
                Name = nodeName
            };
            NodeDictionary.Add(nodeName, node);
            NodeDictionary[parentNodeName].ChildNode.Add(nodeName);
            TextFile?.Copy(NodeDictionary[parentNodeName].Path, node.Path);
            TextFile?.SetReadOnly(NodeDictionary[parentNodeName].Path);
        }

        /// <summary>
        /// ��ԍŏ��̃m�[�h��ǉ�����
        /// </summary>
        /// <exception cref="ArgumentException">��ڈȍ~�̒ǉ��Ɏg���Ȃ�����</exception>
        private void Add(Point point)
        {
            if (NodeDictionary.Count > 0)
                throw new ArgumentException(
                    "��ڈȍ~�̃m�[�h��ǉ�����Ƃ���Add(string nodeName,string newNodeName,int x,int y)���g���Ă�������"
                    );
            INode node = new OriginNode()
            {
                Path = @$"{Path}\origin.txt",
                ChildNode = [],
                Point = point,
                Message = "�ŏ��̃m�[�h",
                Data = DateTime.Now,
                Name = "origin"
            };
            NodeDictionary.Add("origin", node);

            TextFile?.Create(node.Path, "");
        }

        /// <summary>
        /// �w�肳�ꂽ�m�[�h���폜����
        /// </summary>
        /// <param name="nodeName">�폜����m�[�h�̖��O</param>
        /// <param name="parentName">�e�m�[�h�̖��O</param>
        public void Remove(string nodeName, string parentName)
        {
            if (NodeDictionary[nodeName] is Node node)
            {
                INode parentNode = NodeDictionary[node.ParentNode];
                if (parentNode.ChildNode.Count == 0)
                {
                    TextFile?.DeleteReadOnly(parentNode.Path);
                }
                TextFile?.Delete(node.Path);
                NodeDictionary.Remove(nodeName);
            }
            else
            {
                throw new Exception("���_�m�[�h�͍폜�ł��܂���");
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�m�[�h�̖��O��ύX����
        /// </summary>
        /// <param name="nodeName">�ύX�O�̃m�[�h�̖��O</param>
        /// <param name="newNodeName">�ύX��̃m�[�h�̖��O</param>
        /// <param name="message">�ύX�O�̃m�[�h�̃��b�Z�[�W</param>
        public void Rename(string nodeName, string newNodeName, string message)
        {
            if (nodeName == "origin") throw new Exception("���_�m�[�h�̖��O�͕ύX�ł��܂���");
            Node node = (Node)NodeDictionary[nodeName] with { Path = $@"{Path}/{newNodeName}.txt", Name = newNodeName, Message = message };

            // �e�m�[�h�̒��̃m�[�h�̖��O��ς���
            INode parentNode = NodeDictionary[node.ParentNode];
            int index = parentNode.ChildNode.IndexOf(nodeName);
            List<string> children = parentNode.ChildNode;
            children[index] = newNodeName;
            if (parentNode is OriginNode originNode)
            {
                NodeDictionary[node.ParentNode] = originNode with { ChildNode = children };
            }
            else if (parentNode is Node normalNode)
            {
                NodeDictionary[node.ParentNode] = normalNode with { ChildNode = children };
            }

            foreach (var childName in node.ChildNode)
            {
                NodeDictionary[childName] = (Node)NodeDictionary[childName] with { ParentNode = newNodeName };
            }
            NodeDictionary.Remove(nodeName);
            NodeDictionary.Add(newNodeName, node);
        }

        /// <summary>
        /// �m�[�h�̖��O���炻���ɕR�Â���ꂽ�e�L�X�g�t�@�C���̃p�X���擾����
        /// </summary>
        /// <param name="nodeName">�m�[�h�̖��O</param>
        /// <returns>�e�L�X�g�t�@�C���̃p�X</returns>
        public string GetNodePath(string nodeName)
        {
            return NodeDictionary[nodeName].Path;
        }
    }
}

