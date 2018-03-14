using CurrencyProject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfCurrencyProject.ViewModel
{
    public class MakeChangeViewModel : BaseViewModel
    {
        ICurrencyRepo repo;
        ICurrencyRepo Repo
        {
            get { return repo; }
            set { repo = value; }
        }

        private double repoTotal;
        public double RepoTotal
        {
            get { return repoTotal; }
            set
            {
                if (repoTotal != value)
                {
                    repoTotal = value;
                    RaisePropertyChangedEvent();
                }
            }
        }

        public ObservableCollection<ICoin> Coins
        {
            get
            {
                return new ObservableCollection<ICoin>(repo.Coins);
            }
        }

        public ICommand MakeChangeCommand { get; set; }
        public ICommand SaveChangeCommand { get; set; }
        public ICommand LoadChangeCommand { get; set; }

        public MakeChangeViewModel(ICurrencyRepo repo)
        {
            this.repo = repo;
            MakeChangeCommand = new BasicCommand(UpdateMakeChange);
            SaveChangeCommand = new BasicCommand(SaveChangeMade);
            LoadChangeCommand = new BasicCommand(LoadRepo);
        }

        private void UpdateMakeChange()
        {
            this.repo = repo.MakeChange(RepoTotal);
            RaisePropertyChangedEvent("Coins");
        }
        private void SaveChangeMade()
        {
            WindowUSCurrencyRepo saveRepo = new WindowUSCurrencyRepo(Repo.Coins);

            saveRepo.Save();
        }
        public void LoadRepo()
        {
            WindowUSCurrencyRepo loadRepo = new WindowUSCurrencyRepo(new List<ICoin>());
            repo = new USCurrencyRepo((List<ICoin>)loadRepo.Load());
            RepoTotal = repo.TotalValue();
            RaisePropertyChangedEvent("Coins");
        }
    }
}
