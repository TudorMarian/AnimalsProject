using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class Form1 : Form
    {
        private Catalog _catalog;
        private EventNotifier _eventNotifier;

        public Form1()
        {
            InitializeComponent();

            _catalog = Catalog.Instance;
            _eventNotifier = new EventNotifier();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;

            Book newBook = new Book(title, author);
            _catalog.AddBook(newBook);

            _eventNotifier.Notify($"Book '{title}' by {author} added to the library.");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchCriteria = txtSearch.Text;
            List<Book> searchResults = _catalog.SearchBooks(searchCriteria);

            dgvBooks.DataSource = null;
            dgvBooks.DataSource = searchResults;
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                Book selectedBook = (Book)dgvBooks.SelectedRows[0].DataBoundItem;
                selectedBook.Borrow();
                _eventNotifier.Notify($"Book '{selectedBook.Title}' borrowed successfully.");
            }
            else
            {
                MessageBox.Show("Please select a book to borrow.");
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                Book selectedBook = (Book)dgvBooks.SelectedRows[0].DataBoundItem;
                selectedBook.Return();
                _eventNotifier.Notify($"Book '{selectedBook.Title}' returned successfully.");
            }
            else
            {
                MessageBox.Show("Please select a book to return.");
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }

    public class Catalog
    {
        private static Catalog _instance;
        private List<Book> _books;

        private Catalog()
        {
            _books = new List<Book>();
        }

        public static Catalog Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Catalog();
                return _instance;
            }
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }

        public List<Book> SearchBooks(string searchCriteria)
        {
            return _books.FindAll(book =>
                book.Title.ToLower().Contains(searchCriteria.ToLower()) ||
                book.Author.ToLower().Contains(searchCriteria.ToLower()));
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; private set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsBorrowed = false;
        }

        public void Borrow()
        {
            if (!IsBorrowed)
            {
                IsBorrowed = true;
            }
            else
            {
                MessageBox.Show("Book is already borrowed.");
            }
        }

        public void Return()
        {
            if (IsBorrowed)
            {
                IsBorrowed = false;
            }
            else
            {
                MessageBox.Show("Book is not borrowed.");
            }
        }

    }

    public interface IObserver
    {
        void Update(string message);
    }

    public class EventNotifier
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }
    }
}
