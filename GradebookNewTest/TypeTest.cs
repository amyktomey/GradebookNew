using GradebookNew;

namespace GradebookNewTest
{
    public class TypeTest
    {
        public static void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(3, x);
        }

        private static void SetInt(ref int x)
        {
            x = 42;
        }

        private static int GetInt()
        {
            return 3;
        }

        [Fact]
        public static void CSharpIsPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private static void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public static void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private static void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public static void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        public static void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public static void StringsBehaveLikeValueTypes()
        {
            string name = "Amy";
            var upper = MakeUppercase(name);

            Assert.Equal("Amy", name);
            Assert.Equal("AMY", upper);
        }

        private static string MakeUppercase(string paramater)
        {
            return paramater.ToUpper();
        }

        [Fact]
        public static void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public static void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(ReferenceEquals(book1, book2));

        }

        public static Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
