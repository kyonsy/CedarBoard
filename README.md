## 仕事の割り振り
### 長谷川
MainWindowの部分を頼みます。これはWorkSpaceを開くための初期画面です。
Windowのデザインに関しては最後に整える予定なので適当でいいです。
Windowの遷移とバインドしてきた文字列の表示ができるようお願いします。
### 村田
CreateWorkSpaceWindowの部分を頼みます。これは新しいWorkSpaceの設定が作る画面です。
これもwindowのデザインはあまり力は入れなくてもいいです。
Windowの遷移とバインドしてきた文字列の表示ができるようお願いします。
### 梶
Model(内部ロジックの部分)を担当します。
### 山本 小坂
ProjectEditの部分を頼みます。ProjectNode.jsonからノードツリーを表示できるようにしてください
### 松木
デザイン

/*
/村田
*/
using System.Windows;
using System.Diagnostics;

namespace garireo
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //https://qiita.com/yasukotelin/items/605b9d4260a8c9ebcbeb
            //https://learn.microsoft.com/ja-jp/dotnet/api/system.diagnostics.processstartinfo?view=net-8.0
            var app = new ProcessStartInfo();
            app.FileName = "winword.exe";
            app.Arguments = @"""C:\Users\murat\Downloads\school\教材\04.プログラミング基礎第4回インタフェース.docx""";
            app.UseShellExecute = true;
            app.WindowStyle = ProcessWindowStyle.Maximized;

            Process.Start(app);
        }
    }
}