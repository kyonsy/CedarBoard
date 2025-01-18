using CedarBoard.Model;
using CedarBoard.Model.Poco;
using CedarBoard.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// 作品を編集する
    /// </summary>
	public class EditWorkUserControlViewModel : BindableBase,INavigationAware
	{
        private IRegionManager _regionManager;
        private WorkspaceSelector _workspaceSelector;

        private string _name;
        private string _firstName;
        private string _author;
        private string _editorPath;
        private string _memo;

        NavigationContext _navigationContext;

        /// <summary>
        /// 作品名
        /// </summary>
        public string Name { get { return _name; } set { SetProperty(ref _name, value); } }

        /// <summary>
        /// 作者名
        /// </summary>
        public string Author { get { return _author; } set { SetProperty(ref _author, value); } } 

        /// <summary>
        /// 使うエディタのパス
        /// </summary>
        public string EditorPath { get { return _editorPath; } set { SetProperty(ref _editorPath, value); } }

        /// <summary>
        /// メモ
        /// </summary>
        public string Memo { get { return _memo; } set { SetProperty(ref _memo, value); } }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EditWorkUserControlViewModel(IRegionManager regionManager,WorkspaceSelector workspaceSelector)
        {
            _workspaceSelector = workspaceSelector;
            _regionManager = regionManager;
            BackHome = new DelegateCommand(BackHomeExecute);
            SaveSetting = new DelegateCommand(SaveSettingExecute);
        }

        /// <summary>
        /// ホーム画面へ戻る
        /// </summary>
        public DelegateCommand BackHome { get; }

        /// <summary>
        /// 新規作成
        /// </summary>
        public DelegateCommand SaveSetting { get; }

        /// <summary>
        /// インスタンスは使いまわさない
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// この画面からナビゲートした時の動作
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        /// <summary>
        /// 他の画面からこの画面にナビゲートした時の動作
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationContext = navigationContext;
            Setting setting = navigationContext.Parameters.GetValue<Setting>("Setting");
            Name = setting.Name;
            _firstName = Name;
            Author = setting.Author;
            EditorPath = setting.Editor;
            Memo = setting.Message;
        }

        /// <summary>
        /// ホーム画面へ戻る
        /// </summary>
        private void BackHomeExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(HomeUserControl));
        }

        /// <summary>
        /// ワークスペースの設定を保存する
        /// </summary>
        private void SaveSettingExecute()
        {
            Workspace workspace = _navigationContext.Parameters.GetValue<Workspace>("Workspace");
            workspace.WorkspacePoco.Setting = workspace.WorkspacePoco.Setting with
            {
                Author = Author,
                Editor = EditorPath,
                Message = Memo
            };
            workspace.Save();
            _workspaceSelector.Rename(_firstName, Name);
            BackHomeExecute();
        }
    }
}
