using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BV1XJ411Q7B2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            MetroInfos = new ObservableCollection<MetroInfo>();

            kinds = new List<TransitionEffectKind>();
            kinds.Add(TransitionEffectKind.ExpandIn);
            kinds.Add(TransitionEffectKind.FadeIn);
            kinds.Add(TransitionEffectKind.SlideInFromLeft);
            kinds.Add(TransitionEffectKind.SlideInFromTop);
            kinds.Add(TransitionEffectKind.SlideInFromRight);
            kinds.Add(TransitionEffectKind.SlideInFromBottom);

            #region 颜色初始化Start

            colors = new List<string>();
            colors.Add("#0355D2");
            colors.Add("#B6B106");
            colors.Add("#E29450");
            colors.Add("#41DDCC");
            colors.Add("#FE8602");
            colors.Add("#FB5C92");
            colors.Add("#CF0CE7");
            colors.Add("#595393");
            colors.Add("#7D47D4");
            colors.Add("#A1BB21");
            colors.Add("#E29CA9");
            colors.Add("#9E9C73");
            colors.Add("#36133E");
            colors.Add("#74FB75");
            colors.Add("#6FC956");
            colors.Add("#3AC112");
            colors.Add("#035E72");
            colors.Add("#746EB4");
            colors.Add("#62D039");
            colors.Add("#0D2851");
            colors.Add("#FFE9DF");
            colors.Add("#87C7F7");
            colors.Add("#1A1BC7");
            colors.Add("#FFADF9");
            colors.Add("#5A4D30");
            colors.Add("#1B78A3");
            colors.Add("#68F7C7");
            colors.Add("#C5011B");
            colors.Add("#742927");
            colors.Add("#11A49E");
            colors.Add("#1EBC6F");
            colors.Add("#4A0819");
            colors.Add("#78640E");
            colors.Add("#FA884D");
            colors.Add("#8ADB97");
            colors.Add("#C92097");
            colors.Add("#E1083A");
            colors.Add("#2BF46B");
            colors.Add("#3880D8");
            colors.Add("#206139");
            colors.Add("#827F1D");
            colors.Add("#B7F803");
            colors.Add("#ED6EEC");
            colors.Add("#602E5A");
            colors.Add("#DFC895");
            colors.Add("#D55440");
            colors.Add("#49A475");
            colors.Add("#832C70");
            colors.Add("#3B9B3E");
            colors.Add("#67A168");

            #endregion 颜色初始化Start

            RefCommand = new RelayCommand(async () =>
            {
                MetroInfos.Clear();
                for (int i = 0; i < 30; i++)
                {
                    MetroInfos.Add(new MetroInfo
                    {
                        Name = "应用" + i,
                        Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colors[new Random().Next(0, 50)])),
                        Width = new Random().Next(0, 8) == 3 ? 200 : 100,
                        Height = 100,
                        Effect = new TransitionEffect
                        {
                            //Kind = TransitionEffectKind.ExpandIn,
                            Kind = kinds[new Random().Next(2, 6)],
                            Duration = new TimeSpan(0, 0, 0, 0, 900)
                        }
                    });
                    await Task.Delay(10);
                }
            });
        }

        public RelayCommand RefCommand { get; set; }

        public List<TransitionEffectKind> kinds;

        public List<string> colors { get; set; }

        private ObservableCollection<MetroInfo> metroInfos;

        public ObservableCollection<MetroInfo> MetroInfos
        {
            get { return metroInfos; }
            set { metroInfos = value; RaisePropertyChanged(); }
        }
    }
}