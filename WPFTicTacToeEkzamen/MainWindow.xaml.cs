using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using WPFTicTacToeEkzamen.ServiceReference1;


namespace WPFTicTacToeEkzamen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameHelper game;
        TicTakServiceClient proxy;
        ITicTakServiceCallback callback;
        public MainWindow()
        {
            InitializeComponent();
            callback = new CallBackHandler();
            InstanceContext context = new InstanceContext(callback);
            proxy = new TicTakServiceClient(context);


        }

        private void InitializeField()
        {
            var buttons = grGameField.Children.Cast<Button>().ToList();

            //for (int i = 0; i < buttons.Count; i++)
            //{
            //    buttons[i].Content = SetContent(game.Field[i]);
            //}
        }

        private string SetContent(CellType cellType)
        {
            string content = null;
            switch (cellType)
            {
                case CellType.EMPTY:
                    content = "";
                    break;
                case CellType.HRESTIK:
                    content = "X";
                    break;
                case CellType.NOLIK:
                    content = "0";
                    break;
                default:
                    break;
            }

            return content;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var baton = sender as Button;
            var index = Convert.ToInt32(baton.Tag);

            if (game.Field[index] != CellType.EMPTY)
                return;

            if (game.PlayersTurn)
            {
                game.Field[index] = CellType.HRESTIK;
                game.PlayersTurn = false;
                baton.Content = "X";
            }
            else
            {
                game.Field[index] = CellType.NOLIK;
                game.PlayersTurn = true;
                baton.Content = "0";
            }

            proxy.MakeTurnAsync(index, CellType.HRESTIK);

            game = (callback as CallBackHandler).Game;
            InitializeField();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (proxy.Connect())
            {
                game = proxy.GetGameHelper();
                InitializeField();
                grGameField.IsEnabled = true;
            }
        }
    }
}
