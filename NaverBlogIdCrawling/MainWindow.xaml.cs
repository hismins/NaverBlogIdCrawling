using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NaverBlogIdCrawling
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var engine = IronPython.Hosting.Python.CreateEngine();
            var scope = engine.CreateScope();

            
            try
            {

                //파일을 읽지 않고 스크립트를 바로작성
                var source = engine.CreateScriptSourceFromFile(@"test.py");
                source.Execute(scope);

                var getPythonFuncResult = scope.GetVariable<Func<string>>("getPythonFunc");
                //Console.WriteLine("def 실행 테스트 : " + getPythonFuncResult());
                
                
                //파일을 읽지 않고 스크립트를 바로작성
                var source2 = engine.CreateScriptSourceFromString(@"print('스크립트를 직접작성해 출력 테스트')");
                source2.Execute(scope);
                result.Text = getPythonFuncResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
