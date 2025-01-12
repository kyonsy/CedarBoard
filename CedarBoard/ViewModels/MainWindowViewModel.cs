using Prism.Mvvm;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// メインウィンドウ
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// アプリケーションのタイトル
        /// </summary>
        private string _title = "CedarBoard";

        /// <summary>
        /// コンポーネントの遷移を司る奴
        /// </summary>


        /// <summary>
        /// タイトルのプロパティ
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// コンストラクタ。最初はホーム画面に遷移する
        /// </summary>
        public MainWindowViewModel()
        {
           
        }
    }
}
