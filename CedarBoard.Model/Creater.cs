using CedarBoard.Model.Accessor;
using CedarBoard.Model.Poco;

namespace CedarBoard.Model
{
    /// <summary>
    /// WorkspaceとSelectorを作る静的クラスを辛すぎ
    /// </summary>
    public class Creater
    {
        /// <summary>
        /// 指定されたパスからワークスペースを返す
        /// </summary>
        /// <param name="path">ワークスペースのパス</param>
        /// <returns>対応したワークスペース</returns>
        public static Workspace CreateWorkspace(string path)
        {
            object obj = JsonFileBase.Deserialize($@"{path}\workspace.json");
            Workspace workSpace = new(
               new TextFileAccessor(),
               new DirectoryAccessor(),
               path)
            { WorkspacePoco = (WorkspacePoco)obj };
            return workSpace;
        }

        /// <summary>
        /// セレクタを返す
        /// </summary>
        /// <returns></returns>
        public static Selector CreateSelector()
        {
            object obj = JsonFileBase.Deserialize(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'));
            Selector sel = new(new TextFileAccessor(), new DirectoryAccessor()) { SelectorPoco = (SelectorPoco)obj };
            return sel;
        }
    }
}
