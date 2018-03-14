using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyProject;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfCurrencyProject.ViewModel
{
    public class CurrencyRepoViewModel : BaseViewModel
    {
        ICurrencyRepo repo;
        ICurrencyRepo Repo
        {
            get { return repo; }
            set { repo = value; }
        }

        private ObservableCollection<ICoin> coinType;
        public ObservableCollection<ICoin> CoinType
        {
            get { return coinType; }
            set { coinType = value; }
        }

        private string coinName;
        public string CoinName
        {
            get { return coinName; }
            set
            {
                if(value != coinName)
                {
                    coinName = value;
                    RaisePropertyChangedEvent();
                }
            }
        }

        private int coinNum;
        public int CoinNum
        {
            get { return coinNum; }
            set
            {
                if(value != coinNum)
                {
                    coinNum = value;
                    RaisePropertyChangedEvent();
                }
            }
        }

        public ICommand AddCoinCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        public double RepoTotal
        {
            get { return repo.TotalValue(); }
        }

        public CurrencyRepoViewModel(ICurrencyRepo repo)
        {
            this.repo = repo;
            AddCoinCommand = new BasicCommand(AddCoinsToRepo);
            SaveCommand = new BasicCommand(SaveRepo);
            LoadCommand = new BasicCommand(LoadRepo);

            CoinType = new ObservableCollection<ICoin>(((USCurrencyRepo)repo).CurrencyList);
            this.CoinNum = 1;
        }

        public ICoin GetCoinByName(string name)
        {
            var coin = from c in CoinType
                       where c.ToString() == name
                       select c;
            return coin.First();
        }

        private void AddCoinsToRepo()
        {
            for (int i = 0; i < this.CoinNum; ++i)
                this.AddCoin(GetCoinByName(CoinName));
        }
        public void AddCoin(ICoin c)
        {
            repo.AddCoin(c);
            RaisePropertyChangedEvent("RepoTotal");
        }

        public void SaveRepo()
        {
            WindowUSCurrencyRepo saveRepo = new WindowUSCurrencyRepo(Repo.Coins);

            saveRepo.Save();
        }
        public void LoadRepo()
        {
            WindowUSCurrencyRepo loadRepo = new WindowUSCurrencyRepo(new List<ICoin>());
            repo = new USCurrencyRepo((List<ICoin>)loadRepo.Load());
            RaisePropertyChangedEvent("RepoTotal");
        }
    }
}
