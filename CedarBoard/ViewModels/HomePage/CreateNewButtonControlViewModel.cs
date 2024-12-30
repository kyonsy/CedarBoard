using Prism.Mvvm;
using Prism.Commands;
using Prism.Regions;
using CedarBoard.Views;

namespace CedarBoard.ViewModels.HomePage
{
    /// <summary>
    /// 新しいワークスペースを作る画面に遷移するボタン
    /// </summary>
    public class CreateNewButtonControlViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CreateNewButtonControlViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            TransCreateNewPage = new DelegateCommand(TransCreateNewPageExecute);
        }

        public DelegateCommand TransCreateNewPage { get;}
        
        /// <summary>
        /// 新しいページに遷移するコマンド
        /// </summary>
        private void TransCreateNewPageExecute()
        {
            _regionManager.RequestNavigate("MainRegion", nameof(CreateNewControl));
        }
    }
}
