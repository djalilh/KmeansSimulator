using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using KmeansClustering.Views;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using static KmeansClustering.Models.Enums;

namespace KmeansClustering
{
    public class NewSimulationViewModel
    {
        #region Public Evants

        public Action<int, int, Algorithm> OnStartSimulation;

        #endregion

        #region Public Propreties

        public List<int> CountTo10List
        {
            get
            {
                if (_countTo10List == null)
                {
                    _countTo10List = new List<int>();
                    for (int i = 2; i <= 10; i++)
                    {
                        _countTo10List.Add(i);
                    }
                }
                return _countTo10List;
            }
        }

        public List<int> CountTo1000List
        {
            get
            {
                if (_countTo1000List == null)
                {
                    _countTo1000List = new List<int>();
                    for (int i = 10; i <= 1000; i++)
                    {
                        _countTo1000List.Add(i);
                    }
                }
                return _countTo1000List;
            }
        }

        public List<Algorithm> Algorithms
        {
            get
            {
                List<Algorithm> algos = new List<Algorithm>();
                foreach (var item in Enum.GetValues(typeof(Algorithm)))
                {
                    algos.Add((Algorithm)item);
                }
                return algos;
            }
        }

        public int Clusters { get; set; }
        public int Points { get; set; }
        public Algorithm Algorithm { get; set; }

        #endregion

        #region Constructors

        public NewSimulationViewModel()
        {
            
        }

        #endregion

        #region Commands

        public ICommand StartCommand
        {
            get
            {
                if(_startCommand == null)
                {
                    _startCommand = new RelayCommand(() => StartCommand_Executed());
                }
                return _startCommand;
            }
        }


        #endregion

        #region Private Methods

        private void StartCommand_Executed()
        {
            if(Points != 0 && Clusters != 0)
            {
                OnStartSimulation?.Invoke(Clusters, Points, Algorithm);
            }

        }

        #endregion

        #region Protected Methods

        #endregion

        #region Private Propreties

        private ICommand _startCommand;
        private List<int> _countTo10List;
        private List<int> _countTo1000List;

        #endregion

    }

}
