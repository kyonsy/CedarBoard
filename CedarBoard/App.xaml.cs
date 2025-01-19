using CedarBoard.Views;
using Prism.Ioc;
using System.Windows;
using CedarBoard.Model;
using CedarBoard.Model.Accessor;

namespace CedarBoard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// シェルを作る
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// 遷移するコントロールを登録する
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterForNavigation<EditWorkUserControl>();
            containerRegistry.RegisterForNavigation<NewEntryUserControl>();
            containerRegistry.RegisterForNavigation<HomeUserControl>();
            containerRegistry.RegisterForNavigation<WorkspaceUserControl>();
            // テスト用にシングルトンにはモックを登録しておく
            containerRegistry.RegisterSingleton<WorkspaceSelector>(() =>
            {

                WorkspaceSelector sel = new(new TextFileMock(), new DirectoryMock()) { SelectorPoco = new() { PathDictionary = [] } };
                sel.Add(new()
                {
                    Author = "kyonsy",
                    Editor = "notepad",
                    Encode = "UTF-8",
                    Format = "default",
                    Language = "ja",
                    Name = "hoge",
                    CreatedDate = "2024/10/24",
                    UpdatedDate = "2024/10/24",
                    Message = "始めに作ったやつ"
                }, "C:hoge");
                sel.Add(new()
                {
                    Author = "kyonsy",
                    Editor = "notepad",
                    Encode = "UTF-8",
                    Format = "default",
                    Language = "ja",
                    Name = "fuga",
                    CreatedDate = "2024/10/24",
                    UpdatedDate = "2024/10/24",
                    Message = "二つ目に作ったやつ"
                }, "C:ワークスペースの名前\\fuga");
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
                    Message = "二つ目に作ったやつ"
                }, "C:ワークスペースの名前\\hogehoge");
                
                Workspace workspace = sel.GetWorkSpace("hoge");
                workspace.Add("hoge1");
                workspace.Add("hoge2");
                workspace.Add("hoge3");
                workspace.Save();
                return sel;
            });
        }
    }
}
