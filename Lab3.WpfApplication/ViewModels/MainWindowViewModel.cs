using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab2.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab3.WpfApplication.ViewModels
{
    public class MainWindowViewModel : ObservableObject, INotifyPropertyChanged
    {
        private AuthorDbContext _db;
        private Author[] _authors;
        private List<Book> _books = new List<Book>();
        private Author _selectedAuthor;

        public MainWindowViewModel()
        {
            _db = new AuthorDbContext();
            SelectAuthorCommand = new RelayCommand(LoadBooks);
        }

        public Author[] Authors
        {
            get => _authors;
            private set
            {
                _authors = value;
                OnPropertyChanged();
            }
        }

        public List<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

        public Author SelectedAuthor
        {
            get => _selectedAuthor;
            set
            {
                _selectedAuthor = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectAuthorCommand { get; }

        public void Load()
        {
            Authors = _db.Authors.ToArray();
        }

        public void LoadBooks()
        {
            if (SelectedAuthor == null)
            {
                Books = new List<Book>();
                return;
            }

            Books = _db.Books.Where(b => b.Author.Id == SelectedAuthor.Id).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
