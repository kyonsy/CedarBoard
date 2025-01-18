using CedarBoard.Model;
using CedarBoard.Views;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// 新規作成画面
    /// </summary>
	public class NewEntryUserControlViewModel : BindableBase,IDisposable
	{
        private IRegionManager _regionManager;
        private WorkspaceSelector _workspaceSelector;
        private string _name = "無題";
        private string _author = "あなた";
        private string _path = "パスを選択してください";
        private string _editor = "notepad";
        private string _message = "ここに作品のメモを書こう！";

        /// <summary>
        /// 作品名
        /// </summary>
        public string Name { get { return _name; } set { SetProperty(ref _name, value); } }

        /// <summary>
        /// 作者名
        /// </summary>
        public string Author { get { return _author; } set { SetProperty(ref _author, value); } }

        /// <summary>
        /// パス
        /// </summary>
        public string Path { get { return _path; } set { SetProperty(ref _path, value); } }

        /// <summary>
        /// 使うエディタのパス
        /// </summary>
        public string Editor { get { return _editor; } set { SetProperty(ref _editor, value); } }

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message { get { return _message; } set { SetProperty(ref _message, value); } }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewEntryUserControlViewModel(IRegionManager regionManager,WorkspaceSelector workspaceSelector)
        {
            _workspaceSelector = workspaceSelector;
            _regionManager = regionManager;
            BackHome = new DelegateCommand(BackHomeExecute);
            NewEntry = new DelegateCommand(NewEntryExecute);
            ReferPath = new DelegateCommand(ReferPathExecute);
        }

        /// <summary>
        /// ホーム画面へ戻る
        /// </summary>
        public DelegateCommand BackHome { get; }

        /// <summary>
        /// 新規作成
        /// </summary>
        public DelegateCommand NewEntry { get; }

        /// <summary>
        /// 参照
        /// </summary>
        public DelegateCommand ReferPath { get; }

        /// <summary>
        /// ホーム画面へ戻る
        /// </summary>
        private void BackHomeExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(HomeUserControl));
        }

        /// <summary>
        /// 新しいワークスペースを作成する
        /// </summary>
        private void NewEntryExecute() {
            try
            {
                _workspaceSelector.Add(new()
                {
                    Name = Name,
                    Author = Author,
                    Editor = Editor,
                    Message = Message,
                    CreatedDate = DateTime.Now.ToString(),
                    UpdatedDate = DateTime.Now.ToString(),
                    Encode = "UTF-8",
                    Language = "ja",
                    Format = "default",
                }, Path);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("無効な設定を検地しました\nエラーメッセージ: " + ex.Message, "エラー", System.Windows.MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            _workspaceSelector.Save();
            var p = new NavigationParameters()
            {
                {"Workspace",_workspaceSelector.GetWorkSpace(Name) }
            };
            _regionManager.RequestNavigate("ContentRegion", nameof(WorkspaceUserControl),p);
        }

        /// <summary>
        /// エクスプローラを参照する
        /// </summary>
        private void ReferPathExecute()
        {
            string path = "";
            using (var folderDialog = new FolderBrowserDialog()) {
                folderDialog.Description = "フォルダを選択してください";
                if(folderDialog.ShowDialog() == DialogResult.OK)
                {
                    path = folderDialog.SelectedPath + "\\" +Name;
                }
            };
            Path = path;

        }

        /// <summary>
        /// オブジェクトが廃棄されるときの処理
        /// </summary>
        public void Dispose()
        {
            
        }
    }
}
