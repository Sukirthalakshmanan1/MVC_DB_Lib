using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Book
    {
        [Key]
        [Required]
        public int BookID { get; set; }
        [MaxLength(20, ErrorMessage = "Not allowed above 20 chars")]
        [MinLength(2, ErrorMessage = "Not allowed below 2 chars")]
        public string Bookname { get; set; }

        public string Author { get; set; }
        //1 Book---M Enrollments(members)
        public virtual ICollection<Issue> Issues { get; set; }
        //  [DataType(DataType.DateTime,ErrorMessage ="not valid date")]
        public float cost { get; set; }

    }

    public class Member
    {
        [Key]
        public int MemberID { get; set; }

        public string MemberName { get; set; }

        //[Range(10000, 200000, ErrorMessage = "not in range")]
        public int Age { get; set; }
        //1 course---- M enrollments
        public virtual ICollection<Issue> Issues { get; set; }

    }

    public class Issue
    {
        [Key]
        public int IssueID { get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }

        [ForeignKey("BookID")]
        public virtual Book bookdetails { get; set; }
        [ForeignKey("MemberID")]
        public virtual Member mem_details { get; set; }
    }

    public class MyContext1 : DbContext
    {
        public MyContext1() : base("MyContext1")
        {
            //createdatabase if not exists
            //drop create always
            //drop create if model changes

            Database.SetInitializer<MyContext1>(new CreateDatabaseIfNotExists<MyContext1>());
        }

        public virtual DbSet<Book> BookTable { get; set; }
        public virtual DbSet<Member> MemberTable { get; set; }
        public virtual DbSet<Issue> IssueTable { get; set; }

    }
}
