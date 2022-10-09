using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BookOperation
    {
       public void Delete(int bookid)
        {

            MyContext1 context = new MyContext1();
           
           // context.Procedure(bookid);
            context.SaveChanges();
        }
       


        public void InsertBook(BLClass1 bal)
        {
            MyContext1 context = new MyContext1();

            Book b = new Book();
            b.BookID = bal.Bookid;
            b.Bookname = bal.BookName;
            b.cost = bal.cost;
            b.Author = bal.Author;
            context.BookTable.Add(b);
            context.SaveChanges();

        }

       public void UpdateBook(BLClass1 bal)
        {
            MyContext1 context = new MyContext1();
            List<Book> customers = context.BookTable.ToList();
            Book obj = customers.Find(cust => cust.BookID == bal.Bookid);
            obj.Bookname = bal.BookName;
            obj.cost = bal.cost;
           
            // context.Updatebookdetails();
            context.SaveChanges();

        }

        public void Bookcount()
        {
            MyContext1 context = new MyContext1();

            Console.WriteLine("Book count : " + context.BookTable.Count());
        }
        public List<BLClass1> GetAllBooks()
        {
            MyContext1 context = new MyContext1();

            List<Book> clist = context.BookTable.ToList();
            List<BLClass1> cblist = new List<BLClass1>();
            foreach (var item in clist)
            {
                cblist.Add(new BLClass1 { Bookid = item.BookID, BookName = item.Bookname, cost = (int)item.cost, Author=item.Author });



            }
            return cblist;




        }
    



    }
}
